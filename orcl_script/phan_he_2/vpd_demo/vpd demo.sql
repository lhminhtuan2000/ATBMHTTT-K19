SELECT PDB_NAME FROM DBA_PDBS;



ALTER SESSION SET container = qlbv_pdb;
ALTER SESSION SET container = cdb$root;

GRANT EXECUTE ON DBMS_RLS TO qlbv_dba WITH GRANT OPTION;
GRANT EXECUTE ON DBMS_SESSION TO qlbv_dba with GRANT OPTION;

--them nhan vien
SELECT * FROM qlbv_dba.nhanvien;
INSERT INTO qlbv_dba.nhanvien VALUES ('1', 'HOA', 'nam', TO_DATE('31-12-2007','DD-MM-YYYY'), '020', 'qu', '234', '4', 'Thanh tra','1');
INSERT INTO qlbv_dba.nhanvien VALUES ('2', 'HUE', 'nam', TO_DATE('31-12-2007','DD-MM-YYYY'), '020', 'qu', '234', '4', 'Bac si','1');
INSERT INTO qlbv_dba.nhanvien VALUES ('3', 'HOE', 'nu', TO_DATE('31-12-2007','DD-MM-YYYY'), '020', 'qu', '234', '4', 'Bac si','1');
INSERT INTO qlbv_dba.nhanvien VALUES ('4', 'tri', 'nu', TO_DATE('31-12-2007','DD-MM-YYYY'), '020', 'qu', '234', '4', 'Bac si','1');

CREATE USER hoa IDENTIFIED BY "1";
GRANT CREATE SESSION TO hoa;

GRANT SELECT ON qlbv_dba.nhanvien TO hoa;
REVOKE SELECT ON qlbv_dba.nhanvien FROM hoa;

SELECT USERNAME, ACCOUNT_STATUS FROM DBA_USERS WHERE USERNAME = 'HOA';


CREATE or replace CONTEXT VaiTro_ctx USING set_VaiTro_ctx_pkg;

CREATE OR REPLACE PACKAGE qlbv_dba.set_VaiTro_ctx_pkg
IS 
   PROCEDURE set_VaiTro; 
END; 
/

CREATE OR REPLACE PACKAGE BODY qlbv_dba.set_VaiTro_ctx_pkg 
IS
    PROCEDURE set_VaiTro
    AS 
        Vai_Tro NVARCHAR2(20);
    BEGIN 
        SELECT vaitro 
        INTO Vai_Tro 
        FROM qlbv_dba.NhanVien 
        WHERE UPPER(hoten) = SYS_CONTEXT('USERENV', 'SESSION_USER');
        
        DBMS_SESSION.SET_CONTEXT('VaiTro_ctx', 'VaiTro', Vai_Tro);
        EXCEPTION  
            WHEN NO_DATA_FOUND THEN NULL;
    END;
END;
/

GRANT EXECUTE ON qlbv_dba.set_VaiTro_ctx_pkg TO hoa;

CREATE OR REPLACE TRIGGER set_vaitro_ctx_trig 
    AFTER LOGON ON DATABASE
BEGIN
    qlbv_dba.set_vaitro_ctx_pkg.set_VaiTro;
END;


CREATE OR REPLACE FUNCTION vaitro_user (
    v_schema IN VARCHAR2, 
    v_objname IN VARCHAR2)
    RETURN VARCHAR2
AS 
    con VARCHAR2(30);
BEGIN
    IF SYS_CONTEXT('vaitro_ctx', 'vaitro') = 'Thanh tra' THEN
        con := 'phai = ''nam''';
    ELSIF SYS_CONTEXT('vaitro_ctx', 'vaitro') = 'Bac si' THEN
        con := 'phai = ''nu''';
    ELSE con := '';
    END IF;
    RETURN '1 = 2';
END;
/

SELECT table_name, column_name, data_type, data_length
FROM USER_TAB_COLUMNS
WHERE table_name = 'NHANVIEN';

BEGIN
    DBMS_RLS.ADD_POLICY (
    object_schema     => 'qlbv_dba', 
    object_name       => 'nhanvien',
    policy_name       => 'phan_biet_nam_nu', 
    policy_function   => 'vaitro_user',
    sec_relevant_cols => 'phai'
    -- sec_relevant_cols_opt => dbms_rls.ALL_ROWS
    );
END;
/

BEGIN
    DBMS_RLS.DROP_POLICY (
        OBJECT_SCHEMA     => 'qlbv_dba', 
        OBJECT_NAME       => 'nhanvien',
        POLICY_NAME       => 'phan_biet_nam_nu'
    );
END;


CREATE OR REPLACE PROCEDURE ABC
AUTHID CURRENT_USER 
AS
BEGIN
    EXECUTE IMMEDIATE 'CREATE TABLE A (ID NUMBER)';
END;

EXECUTE ABC;

GRANT UPDATE (CMND) ON nhanvien  TO hoa;
revoke UPDATE  ON nhanvien  from hoa;

SELECT * FROM qlbv_dba.nhanvien;

revoke select on qlbv_dba.nhanvien from hoa;
GRANT select on qlbv_dba.nhanvien TO hoa;