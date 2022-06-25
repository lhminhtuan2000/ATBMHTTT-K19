SET SERVEROUTPUT ON; --turn on DBMS_SQL.RETURN_RESULT
--login = SYSDBA
ALTER PLUGGABLE DATABASE pdb1 OPEN;

--login = USER ADMIN of PDB
ALTER SESSION SET container = pdb1;
--ALTER USER pdb1dba QUOTA UNLIMITED ON SYSTEM;
ALTER SESSION SET current_schema = pdb1dba;

--tạo user
--exec SP_CREATE_USER('tt','1');
create user tt IDENTIFIED BY "1";
create user nv IDENTIFIED BY "1";
create user bs IDENTIFIED BY "1";
create user nc IDENTIFIED BY "1";
create user ql IDENTIFIED BY "1";
GRANT CREATE SESSION TO PUBLIC;

create role THANHTRA;
create role CSYT;
create role YSBS;
create role NGHIENCUU;
create role NVQL;

GRANT THANHTRA TO tt;
GRANT CSYT TO nv;
GRANT YSBS TO bs;
GRANT NGHIENCUU TO nc;
GRANT NVQL TO ql;

CREATE OR REPLACE PROCEDURE sp_login (
    user VARCHAR2,
    pass VARCHAR2)
IS
    cs SYS_REFCURSOR;
BEGIN
    open cs for
    SELECT GRANTED_ROLE
    FROM DBA_ROLE_PRIVS
    WHERE GRANTEE IN (SELECT USERNAME 
                        FROM DBA_USERS
                        WHERE account_status = 'OPEN'
                        and USERNAME like upper(user));
                        --and PASSWORD like pass
    DBMS_SQL.RETURN_RESULT(cs);
END;
/
--exec sp_login('bs','1');

/* CHECK
SELECT * FROM USER_SYS_PRIVS;
SELECT * FROM USER_TAB_PRIVS;
SELECT * FROM KHOA;
INSERT INTO KHOA VALUES ('2','noi soi','');
SELECT * FROM SESSION_ROLES;
SELECT * FROM USER_ROLE_PRIVS;
*/

/* XOA'
DROP USER tt;
DROP USER nv;
DROP USER bs;
DROP USER nc;
DROP USER ql;

DROP ROLE THANHTRA;
DROP ROLE CSYT;
DROP ROLE YSBS;
DROP ROLE NGHIENCUU;
DROP ROLE NVQL;
*/
