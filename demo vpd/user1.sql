CREATE USER sysadmin_ctx IDENTIFIED BY 1;
GRANT CREATE SESSION, CREATE ANY CONTEXT, CREATE PROCEDURE, CREATE TRIGGER, ADMINISTER DATABASE TRIGGER TO sysadmin_ctx;
GRANT READ ON qlbv_dba.nhanvien TO sysadmin_ctx;
grant execute on dbms_rls to qlbv_dba with GRANT option;
grant execute on dbms_rls to sysadmin_ctx;
ALTER SESSION SET container = qlbv_pdb;
ALTER SESSION SET container = cdb$root;
GRANT EXECUTE ON DBMS_SESSION TO qlbv_dba with GRANT option;
GRANT EXECUTE ON DBMS_SESSION TO sysadmin_ctx;

--them nhan vien
select * from qlbv_dba.nhanvien;
insert into nhanvien VALUEs ('1', 'HOA', 'nam', TO_DATE('31-12-2007','DD-MM-YYYY'), '020', 'qu', '234', '4', 'Thanh tra','1');
insert into nhanvien VALUEs ('2', 'HUE', 'nam', TO_DATE('31-12-2007','DD-MM-YYYY'), '020', 'qu', '234', '4', 'Bac si','1');
insert into nhanvien VALUEs ('3', 'HOE', 'nu', TO_DATE('31-12-2007','DD-MM-YYYY'), '020', 'qu', '234', '4', 'Bac si','1');
GRANT CREATE SESSION TO hoa IDENTIFIED BY 1;
grant select on qlbv_dba.nhanvien to hoa;
GRANT EXECUTE SYSADMIN_CTX.set_VaiTro_ctx_pkg.set_VaiTro TO HOA;


CREATE or replace CONTEXT VaiTro_ctx USING set_VaiTro_ctx_pkg;

CREATE OR REPLACE PACKAGE sysadmin_ctx.set_VaiTro_ctx_pkg
IS 
   PROCEDURE set_VaiTro; 
END; 

CREATE OR REPLACE PACKAGE BODY set_VaiTro_ctx_pkg 
 IS
   PROCEDURE set_VaiTro
   IS 
    Vai_Tro NVARCHAR2(20);
   BEGIN 
    SELECT QLBV_DBA.NHANVIEN.vaitro INTO Vai_Tro FROM qlbv_dba.NhanVien 
    WHERE hoten = SYS_CONTEXT('USERENV', 'SESSION_USER');
    DBMS_SESSION.SET_CONTEXT('VaiTro_ctx', 'VaiTro', Vai_Tro);
   END;
 END;

create or replace PROCEDURE set_VaiTro
   IS 
    VAI_TRO NVARCHAR2 (20);
   BEGIN 
    SELECT VAITRO INTO VAI_TRO FROM qlbv_dba.NhanVien 
    WHERE hoten = SYS_CONTEXT('USERENV', 'SESSION_USER');
    DBMS_SESSION.SET_CONTEXT('VaiTro_ctx', 'VaiTro', Vai_Tro);
   EXCEPTION  
    WHEN NO_DATA_FOUND THEN NULL;
   END;

CREATE TRIGGER set_vaitro_ctx_trig AFTER LOGON ON DATABASE
 BEGIN
  EXECUTE SYSADMIN_CTX.set_VaiTro_ctx_pkg.set_VaiTro;
 END;
ALTER TRIGGER set_vaitro_ctx_trig ENABLE;

select SYS_CONTEXT('vaitro_ctx', 'vaitro') a from dual;
select SYS_CONTEXT('USERENV', 'SESSION_USER') b from dual;
select 'phai = ''nu''' from dual;



CREATE OR REPLACE FUNCTION vaitro_user (
 v_schema IN VARCHAR2, 
 v_objname IN VARCHAR2)
RETURN VARCHAR2
AS 
    con VARCHAR2(30);
    BEGIN
        if SYS_CONTEXT('vaitro_ctx', 'vaitro') = 'Thanh tra' then
            con := 'phai = ''nam''';
        elsif SYS_CONTEXT('vaitro_ctx', 'vaitro') = 'Bac si' THEN
           con := 'phai = ''nu''';
        else con := '';
        end if;
        RETURN con;
    END;

BEGIN
 DBMS_RLS.ADD_POLICY (
  object_schema     => 'qlbv_dba', 
  object_name       => 'nhanvien',
  policy_name       => 'phan_biet_nam_nu', 
  policy_function   => 'vaitro_user'
  --sec_relevant_cols => 'cmnd, QUEQUAN'
  );
END;


select * from qlbv_dba.nhanvien;
SELECT SYS_CONTEXT('vaitro_ctx', 'vaitro') vaitro FROM DUAL;

GRANT EXECUTE ON dbms_rls to qlbv_dba with GRANT option;
ALTER SESSION SET container = qlbv_pdb;
ALTER SESSION SET container = cdb$root;
GRANT EXECUTE ON DBMS_SESSION TO qlbv_dba with GRANT option;


--them nhan vien
select * from qlbv_dba.nhanvien;
insert into nhanvien VALUEs ('1', 'HOA', 'nam', TO_DATE('31-12-2007','DD-MM-YYYY'), '020', 'qu', '234', '4', 'Thanh tra','1');
insert into nhanvien VALUEs ('2', 'HUE', 'nam', TO_DATE('31-12-2007','DD-MM-YYYY'), '020', 'qu', '234', '4', 'Bac si','1');
insert into nhanvien VALUEs ('3', 'HOE', 'nu', TO_DATE('31-12-2007','DD-MM-YYYY'), '020', 'qu', '234', '4', 'Bac si','1');
GRANT CREATE SESSION TO hoa IDENTIFIED BY 1;
grant select on qlbv_dba.nhanvien to hoa;


--APP CONTEXT
CREATE or replace CONTEXT VaiTro_ctx USING set_VaiTro_ctx_pkg;

CREATE OR REPLACE PACKAGE QLBV_DBA.set_VaiTro_ctx_pkg
IS 
   PROCEDURE set_VaiTro; 
END; 

CREATE OR REPLACE PACKAGE BODY set_VaiTro_ctx_pkg 
 IS
   PROCEDURE set_VaiTro
   IS 
    Vai_Tro NVARCHAR2(20);
   BEGIN 
    SELECT vaitro INTO Vai_Tro FROM qlbv_dba.NhanVien 
    WHERE hoten = SYS_CONTEXT('USERENV', 'SESSION_USER');
    DBMS_SESSION.SET_CONTEXT('VaiTro_ctx', 'VaiTro', Vai_Tro);
   END;
 END;
 /
 GRANT EXECUTE QLBV_DBA.set_VaiTro_ctx_pkg.set_VaiTro TO HOA;

 CREATE TRIGGER set_vaitro_ctx_trig AFTER LOGON ON DATABASE
 BEGIN
  EXECUTE SYSADMIN_CTX.set_VaiTro_ctx_pkg.set_VaiTro;
 END;
--VPD

select SYS_CONTEXT('vaitro_ctx', 'vaitro') a from dual;
--select SYS_CONTEXT('USERENV', 'SESSION_USER') b from dual;
-- select 'phai = ''nu''' from dual;

CREATE OR REPLACE FUNCTION vaitro_user (
 v_schema IN VARCHAR2, 
 v_objname IN VARCHAR2)
RETURN VARCHAR2
AS 
    con VARCHAR2(30);
    BEGIN
        if SYS_CONTEXT('vaitro_ctx', 'vaitro') = 'Thanh tra' then
            con := 'phai = ''nam''';
        elsif SYS_CONTEXT('vaitro_ctx', 'vaitro') = 'Bac si' THEN
           con := 'phai = ''nu''';
        else con := '';
        end if;
        RETURN con;
    END;

BEGIN
 DBMS_RLS.ADD_POLICY (
  object_schema     => 'qlbv_dba', 
  object_name       => 'nhanvien',
  policy_name       => 'phan_biet_nam_nu', 
  policy_function   => 'vaitro_user',
  sec_relevant_cols => 'phai'
  );
END;

BEGIN
 DBMS_RLS.DROP_POLICY (
  object_schema     => 'qlbv_dba', 
  object_name       => 'nhanvien',
  policy_name       => 'phan_biet_nam_nu');
END;


select * from qlbv_dba.nhanvien;
SELECT SYS_CONTEXT('vaitro_ctx', 'vaitro') vaitro FROM DUAL;