conn sys/admin as sysdba
ALTER SESSION SET container = QLBV_pdb;
GRANT EXECUTE ON dbms_rls to QLBV_dba with GRANT option;
GRANT EXECUTE ON DBMS_SESSION TO QLBV_dba with GRANT option;

conn qlbv_dba/1
--APP CONTEXT
CREATE or replace CONTEXT INFO_CTX USING INFO_CTX_PKG;

CREATE OR REPLACE PACKAGE QLBV_DBA.INFO_CTX_PKG
IS 
   PROCEDURE GET_INFO; 
END; 

CREATE OR REPLACE PACKAGE BODY QLBV_DBA.INFO_CTX_PKG
 IS
   PROCEDURE GET_INFO
   IS 
    CS_YT QLBV_dba.NhanVien.CSYT%TYPE;
    CHUYEN_KHOA QLBV_dba.NhanVien.CHUYENKHOA%TYPE;
    Vai_Tro QLBV_dba.NhanVien.VAITRO%TYPE;
   BEGIN 
    SELECT CSYT, CHUYENKHOA, vaitro INTO CS_YT, CHUYEN_KHOA, Vai_Tro FROM QLBV_dba.NhanVien
    WHERE TENDANGNHAP = SYS_CONTEXT('USERENV', 'SESSION_USER');
    DBMS_SESSION.SET_CONTEXT('INFO_CTX', 'CSYT', CS_YT);
    DBMS_SESSION.SET_CONTEXT('INFO_CTX', 'VAITRO', Vai_Tro);
    DBMS_SESSION.SET_CONTEXT('INFO_CTX', 'CHUYENKHOA', CHUYEN_KHOA);
    EXCEPTION
    WHEN OTHERS THEN
    BEGIN
    SELECT MACSYT INTO CS_YT FROM QLBV_DBA.BENHNHAN  WHERE TENDANGNHAP = SYS_CONTEXT('USERENV', 'SESSION_USER');
    CHUYEN_KHOA := 0;
    VAI_TRO := 'Benh nhan';
    DBMS_SESSION.SET_CONTEXT('INFO_CTX', 'CSYT', CS_YT);
    DBMS_SESSION.SET_CONTEXT('INFO_CTX', 'VAITRO', Vai_Tro);
    DBMS_SESSION.SET_CONTEXT('INFO_CTX', 'CHUYENKHOA', CHUYEN_KHOA);
    END;
   END;
 END;
 /
 GRANT EXECUTE ON QLBV_DBA.INFO_ctx_pkg TO public;
 CREATE TRIGGER GET_INFO_ctx_trig AFTER LOGON ON DATABASE
 BEGIN
  INFO_CTX_PKG.GET_INFO;
 END;

--
CREATE OR REPLACE FUNCTION VPD_HSBA_1 (--select
 v_schema IN VARCHAR2, 
 v_objname IN VARCHAR2)
RETURN VARCHAR2
AS 
    con VARCHAR2(300);
BEGIN
    if SYS_CONTEXT('INFO_CTX', 'VaiTro') = 'Thanh tra' then
        con := '';
    elsif SYS_CONTEXT('INFO_CTX', 'VaiTro') = 'Cơ sở y tế' THEN
       con := '(MACSYT = SYS_CONTEXT(''INFO_CTX'', ''CSYT''))';
    elsif SYS_CONTEXT('INFO_CTX', 'VaiTro') = 'Y sĩ/ bác sĩ' THEN
       con := 'MABS IN (SELECT MANV FROM NHANVIEN)';
    elsif SYS_CONTEXT('INFO_CTX', 'VaiTro') = 'Nghiên cứu' THEN
       con := 'MACSYT = SYS_CONTEXT(''INFO_CTX'', ''CSYT'') AND MAKHOA = SYS_CONTEXT(''INFO_CTX'', ''ChuyenKhoa'')';
    elsif SYS_CONTEXT('INFO_CTX', 'VaiTro') = 'Benh nhan' THEN
       con := 'MABN IN (SELECT MABN FROM BENHNHAN)';
    else con := '';
    end if;
    RETURN con;
END;
/
BEGIN
  DBMS_RLS.ADD_POLICY (
  object_schema     => 'QLBV_dba', 
  object_name       => 'HSBA',
  policy_name       => 'VPD_HSBA_F1', 
  policy_function   => 'VPD_HSBA_1',
  statement_types => 'select',
  update_check => true
  );
END;
/

--
CREATE OR REPLACE FUNCTION VPD_HSBA_2 (--update, insert
 v_schema IN VARCHAR2, 
 v_objname IN VARCHAR2)
RETURN VARCHAR2
AS 
    con VARCHAR2(300);
BEGIN
    if SYS_CONTEXT('INFO_CTX', 'VaiTro') = 'Thanh tra' then
        con := '';
    elsif SYS_CONTEXT('INFO_CTX', 'VaiTro') = 'Cơ sở y tế' THEN
       con := '(MACSYT = SYS_CONTEXT(''INFO_CTX'', ''CSYT'') AND (EXTRACT(DAY FROM SYSDATE) BETWEEN 5 AND 27))';
    elsif SYS_CONTEXT('INFO_CTX', 'VaiTro') = 'Y sĩ/ bác sĩ' THEN
       con := '';
    elsif SYS_CONTEXT('INFO_CTX', 'VaiTro') = 'Nghiên cứu' THEN
       con := '';
    elsif SYS_CONTEXT('INFO_CTX', 'VaiTro') = 'Benh nhan' THEN
       con := '';
    else con := '';
    end if;
    RETURN con;
END;
/
BEGIN
  DBMS_RLS.ADD_POLICY (
  object_schema     => 'QLBV_dba', 
  object_name       => 'HSBA',
  policy_name       => 'VPD_HSBA_F2', 
  policy_function   => 'VPD_HSBA_2',
  statement_types => 'insert, delete',
  update_check => true
  );
END;
/


CREATE OR REPLACE FUNCTION VPD_HSBA_DV_1 (--select
 v_schema IN VARCHAR2, 
 v_objname IN VARCHAR2)
RETURN VARCHAR2
AS 
    con VARCHAR2(300);
BEGIN
    if SYS_CONTEXT('INFO_CTX', 'VaiTro') = 'Thanh tra' then
        con := '';
    elsif SYS_CONTEXT('INFO_CTX', 'VaiTro') = 'Cơ sở y tế' THEN
       con := '(MAHSBA IN (SELECT MAHSBA FROM HSBA WHERE MACSYT = SYS_CONTEXT(''INFO_CTX'', ''CSYT'')))';--SELECT BÌNH THƯỜNG, CÒN UPDATE THÌ KHÁC THƯỜNG
    elsif SYS_CONTEXT('INFO_CTX', 'VaiTro') = 'Y sĩ/ bác sĩ' THEN
       con := 'MAHSBA IN (SELECT MAHSBA FROM HSBA, NHANVIEN WHERE MABS = MANV)';--GỘP BẢNG
    elsif SYS_CONTEXT('INFO_CTX', 'VaiTro') = 'Nghiên cứu' THEN
       con := 'MAHSBA IN (SELECT B.MAHSBA FROM HSBA A WHERE A.MACSYT = SYS_CONTEXT(''INFO_CTX'', ''CSYT'') AND A.MAKHOA = SYS_CONTEXT(''INFO_CTX'', ''ChuyenKhoa''))';
    elsif SYS_CONTEXT('INFO_CTX', 'VaiTro') = 'Benh nhan' THEN
       con := 'MAHSBA IN (SELECT A.MAHSBA FROM HSBA A, BENHNHAN C WHERE A.MABN=C.MABN)';
    else con := '';
    end if;
    RETURN con;
END;
/
BEGIN
  DBMS_RLS.ADD_POLICY (
  object_schema     => 'QLBV_dba', 
  object_name       => 'HSBA_DV',
  policy_name       => 'VPD_HSBA_DV_F1', 
  policy_function   => 'VPD_HSBA_DV_1',
  statement_types => 'select',
  update_check => true
  );
END;
/

CREATE OR REPLACE FUNCTION VPD_HSBA_DV_2 (--insert, update
 v_schema IN VARCHAR2, 
 v_objname IN VARCHAR2)
RETURN VARCHAR2
AS 
    con VARCHAR2(300);
BEGIN
    if SYS_CONTEXT('INFO_CTX', 'VaiTro') = 'Thanh tra' then
        con := '';
    elsif SYS_CONTEXT('INFO_CTX', 'VaiTro') = 'Cơ sở y tế' THEN
       con := '(MAHSBA IN (SELECT MAHSBA FROM HSBA WHERE MACSYT = SYS_CONTEXT(''INFO_CTX'', ''CSYT'')) AND (EXTRACT(DAY FROM SYSDAY) BETWEEN 5 AND 27 ))';--SELECT BÌNH THƯỜNG, CÒN UPDATE THÌ KHÁC THƯỜNG
    elsif SYS_CONTEXT('INFO_CTX', 'VaiTro') = 'Y sĩ/ bác sĩ' THEN
       con := '';
    elsif SYS_CONTEXT('INFO_CTX', 'VaiTro') = 'Nghiên cứu' THEN
       con := '';
    elsif SYS_CONTEXT('INFO_CTX', 'VaiTro') = 'Benh nhan' THEN
       con := '';
    else con := '';
    end if;
    RETURN con;
END;
/
BEGIN
  DBMS_RLS.ADD_POLICY (
  object_schema     => 'QLBV_dba', 
  object_name       => 'HSBA_DV',
  policy_name       => 'VPD_HSBA_DV_F2', 
  policy_function   => 'VPD_HSBA_DV_2',
  statement_types => 'insert, delete',
  update_check => true
  );
END;
/
 
CREATE OR REPLACE FUNCTION VPD_BENH_NHAN_1 (--select
 v_schema IN VARCHAR2, 
 v_objname IN VARCHAR2)
RETURN VARCHAR2
AS 
    con VARCHAR2(300);
BEGIN
    if SYS_CONTEXT('INFO_CTX', 'VaiTro') = 'Thanh tra' then
        con := '';
    elsif SYS_CONTEXT('INFO_CTX', 'VaiTro') = 'Cơ sở y tế' THEN
       con := '';
    elsif SYS_CONTEXT('INFO_CTX', 'VaiTro') = 'Y sĩ/ bác sĩ' THEN
--        DECLARE c1 QLBV_DBA.BENHNHAN.MABN%TYPE;
--        SELECT MANV INTO c1 FROM QLBV_DBA.NHANVIEN WHERE TENDANGNHAP = USER;
       con := 'MABN IN (
                SELECT A.MABN FROM qlbv_dba.HSBA A, QLBV_DBA.NHANVIEN C
                WHERE  A.MABS = C.MANV)';--GỘP BẢNG
    elsif SYS_CONTEXT('INFO_CTX', 'VaiTro') = 'Nghiên cứu' THEN
       con := '';
    elsif SYS_CONTEXT('INFO_CTX', 'VaiTro') = 'Benh nhan' THEN
       con := 'TENDANGNHAP = SYS_CONTEXT(''USERENV'', ''SESSION_USER'')';
    else con := '';
    end if;
    RETURN con;
END;
/
BEGIN
  DBMS_RLS.ADD_POLICY (
  object_schema     => 'QLBV_dba', 
  object_name       => 'BENHNHAN',
  policy_name       => 'VPD_BENH_NHAN_F1', 
  policy_function   => 'VPD_BENH_NHAN_1',
  statement_types => 'select',
  update_check => true
  );
END;
/

BEGIN
  DBMS_RLS.drop_POLICY (
  object_schema     => 'QLBV_dba', 
  object_name       => 'BENHNHAN',
  policy_name       => 'VPD_BENH_NHAN_F1'
  );
END;
/


CREATE OR REPLACE FUNCTION VPD_BENH_NHAN_2 (--update
 v_schema IN VARCHAR2, 
 v_objname IN VARCHAR2)
RETURN VARCHAR2
AS 
con VARCHAR2(300);
BEGIN
    if SYS_CONTEXT('INFO_CTX', 'VaiTro') = 'Thanh tra' then
        con := '';
    elsif SYS_CONTEXT('INFO_CTX', 'VaiTro') = 'Cơ sở y tế' THEN
       con := '';
    elsif SYS_CONTEXT('INFO_CTX', 'VaiTro') = 'Y sĩ/ bác sĩ' THEN
       con := '';--GỘP BẢNG
    elsif SYS_CONTEXT('INFO_CTX', 'VaiTro') = 'Nghiên cứu' THEN
       con := '';
    elsif SYS_CONTEXT('INFO_CTX', 'VaiTro') = 'Benh nhan' THEN
       con := 'TENDANGNHAP = SYS_CONTEXT(''USERENV'', ''SESSION_USER'')';
    else con := '';
    end if;
    RETURN con;
END;
/
BEGIN
  DBMS_RLS.ADD_POLICY (
  object_schema     => 'QLBV_dba', 
  object_name       => 'BENHNHAN',
  policy_name       => 'VPD_BENH_NHAN_F2', 
  policy_function   => 'VPD_BENH_NHAN_2',
  statement_types => 'update',
  update_check => true
  );
END;
/


CREATE OR REPLACE FUNCTION VPD_NHANVIEN_1 (
 v_schema IN VARCHAR2, 
 v_objname IN VARCHAR2)
RETURN VARCHAR2
AS 
    con VARCHAR2(100);
    BEGIN
        IF SYS_CONTEXT('INFO_CTX', 'VaiTro') = 'Thanh tra' THEN --xem đc hết trừ cái của mình
            con := '';
       -- ELSEIF SYS_CONTEXT('USERENV', 'CURRENT_USER') = 'QLBV_DBA' THEN
       --     con := '';
        else
            con := 'TENDANGNHAP = SYS_CONTEXT(''USERENV'', ''CURRENT_USER'')';
        END IF;
        RETURN con;
    END;
/

BEGIN
  DBMS_RLS.ADD_POLICY (
  object_schema     => 'qlbv_dba', 
  object_name       => 'NHANVIEN',
  policy_name       => 'VPD_NHANVIEN_F1',
  policy_function   => 'VPD_NHANVIEN_1',
  statement_types => 'select',
  update_check => true
  );
END;

CREATE OR REPLACE FUNCTION VPD_NHANVIEN_2 (
 v_schema IN VARCHAR2, 
 v_objname IN VARCHAR2)
RETURN VARCHAR2
AS 
    con VARCHAR2(100) := 'TENDANGNHAP = SYS_CONTEXT(''USERENV'', ''CURRENT_USER'')';
    BEGIN
        RETURN con;
    END;
/

BEGIN
  DBMS_RLS.ADD_POLICY (
  object_schema     => 'qlbv_dba', 
  object_name       => 'NHANVIEN',
  policy_name       => 'VPD_NHANVIEN_F2',
  policy_function   => 'VPD_NHANVIEN_2',
  statement_types => 'update',
  update_check => true
  );
END;



select * from QLBV_dba.nhanvien;
SELECT SYS_CONTEXT('vaitro_ctx', 'vaitro') vaitro FROM DUAL;