SET SERVEROUTPUT ON;
--turn on DBMS_SQL.RETURN_RESULT
--login = SYSDBA
ALTER PLUGGABLE DATABASE qlbv_pdb OPEN;

--login = USER ADMIN of PDB
ALTER SESSION
SET
    container = qlbv_pdb;

--ALTER USER qlbv_dba QUOTA UNLIMITED ON SYSTEM;
ALTER SESSION
SET
    current_schema = qlbv_dba;

--tạo user
exec SP_CREATE_USER('tt','1');
exec SP_CREATE_USER('nv','1');
exec SP_CREATE_USER('bs','1');
exec SP_CREATE_USER('nc','1');
exec SP_CREATE_USER('bn','1');
exec SP_CREATE_USER('boss','1');

exec SP_CREATE_ROLE('THANHTRA');
exec SP_CREATE_ROLE('CSYT');
exec SP_CREATE_ROLE('YSBS');
exec SP_CREATE_ROLE('NGHIENCUU');
exec SP_CREATE_ROLE('BENHNHAN');
exec SP_CREATE_ROLE('GIAMDOC');

exec SP_GRANT_ROLE_TO_USER('THANHTRA','tt');
exec SP_GRANT_ROLE_TO_USER('CSYT','nv');
exec SP_GRANT_ROLE_TO_USER('YSBS','bs');
exec SP_GRANT_ROLE_TO_USER('NGHIENCUU','nc');
exec SP_GRANT_ROLE_TO_USER('BENHNHAN','bn');
exec SP_GRANT_ROLE_TO_USER('GIAMDOC','boss');

CREATE OR REPLACE PROCEDURE sp_login
AUTHID current_user
IS 
    cs SYS_REFCURSOR;
BEGIN 
    OPEN cs FOR
    SELECT GRANTED_ROLE FROM USER_ROLE_PRIVS;

    dbms_sql.return_result(cs);
END;
/
--exec sp_login
/* CHECK
 SELECT * FROM USER_SYS_PRIVS;
 SELECT * FROM USER_TAB_PRIVS;
 SELECT * FROM KHOA;
 INSERT INTO KHOA VALUES ('2','noi soi','');
 SELECT * FROM SESSION_ROLES;
 SELECT * FROM USER_ROLE_PRIVS;
SELECT* FROM DBA_SYS_PRIVS WHERE GRANTEE ='DBA' and privilege like 'EXECUTE%';
*/
/* XOA'
 exec sp_delete_user('nvql')
 exec sp_delete_role('QUANLY')
 */