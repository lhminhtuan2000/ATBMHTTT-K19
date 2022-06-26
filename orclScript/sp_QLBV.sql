SET serveroutput ON;

-- turn on dbms_sql.return_result
-- login = sysdba
ALTER PLUGGABLE DATABASE qlbv_pdb OPEN;

-- login = user admin of pdb
ALTER SESSION SET CONTAINER = qlbv_pdb;

-- alter user qlbv_dba quota unlimited on system;
/* check
 select owner, table_name from all_tables;
 select sys_context( 'userenv', 'current_schema' ) from dual;
 select owner,object_name from all_procedures where object_type = 'procedure';
*/



--  PROCEDURE
--  1/ liệt kê tất cả các user đang open 
-- BIG CHANGE
CREATE OR REPLACE VIEW v_pdb_dba_users 
AS
SELECT * 
FROM dba_users
WHERE common = 'NO';

GRANT SELECT ON v_pdb_dba_users TO qlbv_dba;

CREATE OR REPLACE PROCEDURE qlbv_dba.sp_list_all_user 
IS 
    c_user_list SYS_REFCURSOR;
BEGIN 
    OPEN c_user_list FOR
    SELECT 
        username, account_status, created, last_login
    FROM 
        sys.v_pdb_dba_users
    WHERE 
        account_status = 'OPEN';

    -- SOS
    DBMS_SQL.RETURN_RESULT(c_user_list);
END;
/ 


-- 2/ show system privilege của user
CREATE OR REPLACE VIEW v_pdb_dba_sys_privs
AS
SELECT dsp.*
FROM dba_sys_privs dsp, v_pdb_dba_users vpdu
WHERE dsp.grantee = vpdu.username

GRANT SELECT ON v_pdb_dba_sys_privs TO qlbv_dba;

CREATE OR REPLACE PROCEDURE qlbv_dba.sp_show_user_sys_privs (
    user VARCHAR2) 
IS 
    c_privileges SYS_REFCURSOR;
BEGIN 
    OPEN c_privileges FOR
    SELECT
        privilege, grantee, admin_option
    FROM
        sys.v_pdb_dba_sys_privs
    WHERE
        grantee = upper(user);

    -- SOS
    dbms_sql.return_result(c_privileges);
END;
/ 


-- 3/ Show object privilege của user
CREATE OR REPLACE VIEW v_pdb_dba_tab_privs 
AS
SELECT *
FROM dba_tab_privs 
WHERE grantee IN (
        SELECT username
        FROM v_pdb_dba_users);

GRANT SELECT ON v_pdb_dba_tab_privs TO qlbv_dba;

CREATE OR REPLACE PROCEDURE qlbv_dba.sp_show_user_obj_privs (
    user VARCHAR2)
IS
    c_privs SYS_REFCURSOR;
BEGIN 
    OPEN c_privs FOR
    SELECT
        *
    FROM
        sys.v_pdb_dba_tab_privs
    WHERE
        grantee = upper(user);

    -- SOS
    dbms_sql.return_result(c_privs);
END;
/ 


-- 4/ Show role của hệ thống
-- Lấy tất cả các role có common = no
CREATE OR REPLACE VIEW v_pdb_dba_roles
AS
    SELECT * 
    FROM dba_roles 
    WHERE COMMON = 'NO';

GRANT SELECT ON v_pdb_dba_roles TO qlbv_dba;

CREATE OR REPLACE PROCEDURE qlbv_dba.sp_show_roles
IS
    c_roles SYS_REFCURSOR;
BEGIN
    OPEN c_roles FOR
    SELECT
        *
    FROM
        sys.v_pdb_dba_roles;

    DBMS_SQL.RETURN_RESULT(c_roles);
END;
/

-- 5/ Xem system privs của role
CREATE OR REPLACE VIEW v_pdb_role_sys_privs
AS
SELECT *
FROM role_sys_privs
WHERE role in (
    SELECT role 
    FROM v_pdb_dba_roles);

GRANT SELECT ON v_pdb_role_sys_privs TO qlbv_dba;

CREATE OR REPLACE PROCEDURE qlbv_dba.sp_role_sys_privs (
    role_name VARCHAR2)
IS
    c_roles SYS_REFCURSOR;
BEGIN
    OPEN c_roles FOR
    SELECT
        *
    FROM
        sys.v_pdb_role_sys_privs
    WHERE role = UPPER(role_name);

    DBMS_SQL.RETURN_RESULT(c_roles);
END;
/


-- 6/ Show object privs của role
CREATE OR REPLACE VIEW v_pdb_role_tab_privs
AS
SELECT *
FROM role_tab_privs
WHERE role in (
    SELECT role 
    FROM v_pdb_dba_roles);

GRANT SELECT ON v_pdb_role_tab_privs TO qlbv_dba;

CREATE OR REPLACE PROCEDURE qlbv_dba.sp_role_obj_privs (
    role_name VARCHAR2)
IS
    c_roles SYS_REFCURSOR;
BEGIN
    OPEN c_roles FOR
    SELECT
        *
    FROM
        sys.v_pdb_role_tab_privs
    WHERE role = UPPER(role_name);

    DBMS_SQL.RETURN_RESULT(c_roles);
END;
/

/*
-- 3/ liệt kê tất cả các role đang open
DROP PROCEDURE qlbv_dba.sp_list_all_role;
GRANT SELECT ON dba_roles TO qlbv_dba;

CREATE OR REPLACE PROCEDURE qlbv_dba.sp_list_all_role 
IS 
    c_role_list SYS_REFCURSOR;
BEGIN 
    OPEN c_role_list FOR
    SELECT
        ROLE
    FROM
        dba_roles;

    dbms_sql.return_result(c_role_list);
END;
/ 
-- 4/ xem quyền của một role
DROP PROCEDURE qlbv_dba.sp_show_role_privileges;
CREATE OR REPLACE PROCEDURE qlbv_dba.sp_show_role_privileges (
    role_name varchar2) 
IS 
    c_privileges SYS_REFCURSOR;
BEGIN OPEN c_privileges FOR
    SELECT
        privilege,
        admin_option
    FROM
        role_sys_privs
    WHERE
        ROLE = upper(role_name);

    dbms_sql.return_result(c_privileges);
END;
/ 
*/



-- 7/ tạo một user
CREATE OR REPLACE PROCEDURE qlbv_dba.sp_create_user (
    username varchar2, 
    PASSWORD varchar2) 
AUTHID CURRENT_USER 
IS 
BEGIN 
    EXECUTE IMMEDIATE 'CREATE USER ' || username || ' IDENTIFIED BY ' || PASSWORD;
    EXECUTE IMMEDIATE 'grant create session to ' || username;
END;
/ 


-- 8/ xoá một user
CREATE OR REPLACE PROCEDURE qlbv_dba.sp_delete_user (
    username varchar2) 
AUTHID CURRENT_USER 
IS 
BEGIN 
    EXECUTE IMMEDIATE 'DROP USER ' || username || ' CASCADE';
END;
/ 


-- 9/ đổi mật khẩu (hiệu chỉnh user)
CREATE OR REPLACE PROCEDURE qlbv_dba.sp_change_user_password (
    username VARCHAR2,
    new_password VARCHAR2) 
AUTHID CURRENT_USER 
IS 
BEGIN 
    EXECUTE IMMEDIATE 'ALTER USER ' || username || ' IDENTIFIED BY ' || new_password;
END;
/ 


-- 10/ lock một user (hiệu chỉnh user) 
CREATE OR REPLACE PROCEDURE qlbv_dba.sp_lock_user (
    username VARCHAR2) 
AUTHID CURRENT_USER 
IS 
BEGIN 
    EXECUTE IMMEDIATE 'ALTER USER ' || username || ' ACCOUNT LOCK';
END;
/ 


-- 10+/ (proc ngoài lê) unlock một user 
CREATE OR REPLACE PROCEDURE qlbv_dba.sp_unlock_user (
    username VARCHAR2) 
AUTHID CURRENT_USER 
IS 
BEGIN 
    EXECUTE IMMEDIATE 'ALTER USER ' || username || ' ACCOUNT UNLOCK';
END;
/ 


-- 11/ tạo một role
CREATE OR REPLACE PROCEDURE qlbv_dba.sp_create_role (
    role_name VARCHAR2)  
AUTHID CURRENT_USER 
IS 
BEGIN 
    EXECUTE IMMEDIATE 'CREATE ROLE ' || role_name;
END;
/


-- 12/ xoá role
CREATE OR REPLACE PROCEDURE qlbv_dba.sp_delete_role (
    role_name VARCHAR2) 
IS 
BEGIN 
    EXECUTE IMMEDIATE 'DROP ROLE ' || role_name;
END;
/


-- 11/ cấp quyền insert cho user/role trên table_name
CREATE OR REPLACE PROCEDURE qlbv_dba.sp_grant_insert (
    user_or_role VARCHAR2,
    table_name VARCHAR2,
    schema_name VARCHAR2) 
IS 
BEGIN 
    EXECUTE IMMEDIATE 'GRANT INSERT ON ' || schema_name || '.' || table_name || ' TO ' || user_or_role;
END;
/

/*
-- 12/ cấp quyền insert cho user/role trên table_name (with GRANT option)
CREATE OR REPLACE PROCEDURE qlbv_dba.sp_grant_insert_wgo (
    user_or_role varchar2,
    table_name varchar2) 
IS 
BEGIN 
    EXECUTE IMMEDIATE 'GRANT INSERT ON SYS.' || table_name || ' TO ' || user_or_role || ' WITH GRANT OPTION';
END;
/
*/
-- 13/ cấp quyền delete cho user/role trên table_name thông qua view [edit]


CREATE OR REPLACE PROCEDURE qlbv_dba.sp_grant_delete (
    user_or_role VARCHAR2,
    table_name VARCHAR2) 
IS 
BEGIN 
    EXECUTE IMMEDIATE 'GRANT DELETE ON SYS.' || table_name || ' TO ' || user_or_role;
END;
/
-- 14/ cấp quyền delete cho user/role trên table_name thông qua view (with GRANT option) [edit]


CREATE OR REPLACE PROCEDURE sp_grant_delete_wgo (
    user_or_role VARCHAR2,
    table_name VARCHAR2) 
IS 
BEGIN 
    EXECUTE IMMEDIATE 'GRANT DELETE ON SYS.' || table_name || ' TO ' || user_or_role || ' WITH GRANT OPTION';
END;
/
-- 15/ cấp quyền select cho user/role trên column_list thuộc table_name


CREATE OR REPLACE PROCEDURE sp_grant_select (
    user_or_role VARCHAR2,
    table_name VARCHAR2,
    column_list VARCHAR2) 
IS 
BEGIN 
    EXECUTE IMMEDIATE 'CREATE OR REPLACE VIEW V_' || user_or_role || '_' || table_name || ' AS SELECT ' || column_list || ' FROM ' || table_name;
    EXECUTE IMMEDIATE 'GRANT SELECT ON SYS.V_' || user_or_role || '_' || table_name || ' TO ' || user_or_role;
END;
/


-- 16/ cấp quyền select cho user/role trên column_list thuộc table_name (with GRANT option)
CREATE OR REPLACE PROCEDURE qlbv_dba.sp_grant_select_wgo (
    user_or_role VARCHAR2,
    table_name VARCHAR2,
    column_list VARCHAR2) 
IS 
BEGIN 
    EXECUTE IMMEDIATE 'CREATE OR REPLACE VIEW V_' || user_or_role || '_' || table_name || ' AS SELECT ' || column_list || ' FROM ' || table_name;
    EXECUTE IMMEDIATE 'GRANT SELECT ON SYS.V_' || user_or_role || '_' || table_name || ' TO ' || user_or_role || ' WITH GRANT OPTION';
END;
/


-- 17/ cấp quyền update cho user/role trên column_list thuộc table_name
CREATE OR REPLACE PROCEDURE sp_grant_update (
    user_or_role VARCHAR2,
    table_name VARCHAR2,
    column_list VARCHAR2) 
IS 
BEGIN 
    EXECUTE IMMEDIATE 'GRANT UPDATE (' || column_list || ') ON SYS.V_' || user_or_role || '_' || table_name || ' TO ' || user_or_role;
END;
/


-- 18/ cấp quyền update cho user/role trên column_list thuộc table_name (with GRANT option)
CREATE OR REPLACE PROCEDURE qlbv_dba.sp_grant_update_wgo (
    user_or_role VARCHAR2,
    table_name VARCHAR2,
    column_list VARCHAR2) 
IS 
BEGIN
    EXECUTE IMMEDIATE 'GRANT UPDATE (' || column_list || ') ON SYS.V_' || user_or_role || '_' || table_name || ' TO ' || user_or_role || ' WITH GRANT OPTION';
END;
/


-- 19/ thu hồi quyền insert table_name từ user/role
CREATE OR REPLACE PROCEDURE qlbv_dba.sp_revoke_insert (
    user_or_role VARCHAR2,
    table_name VARCHAR2) 
IS 
BEGIN
    EXECUTE IMMEDIATE 'REVOKE INSERT ON SYS.' || table_name || ' FROM ' || user_or_role;
END;
/ 
-- 20/ thu hôi quyền delete table_name từ user/role
CREATE OR REPLACE PROCEDURE qlbv_dba.sp_revoke_delete (
    user_or_role VARCHAR2,
    table_name VARCHAR2) 
IS 
BEGIN
    EXECUTE IMMEDIATE 'REVOKE DELETE ON SYS.V_' || user_or_role || '_' || table_name || ' FROM ' || user_or_role;
END;
/ 
-- 21/ thu hồi quyền select table_name từ user/role
CREATE OR REPLACE PROCEDURE qlbv_dba.sp_revoke_select (
    user_or_role VARCHAR2,
    table_name VARCHAR2,
    column_list VARCHAR2) 
IS 
BEGIN
    EXECUTE IMMEDIATE 'REVOKE SELECT ON SYS.V_' || user_or_role || '_' || table_name || ' FROM ' || user_or_role;
END;
/ 
-- 22/ thu hồi quyền update từ user/role trên table_name
CREATE OR REPLACE PROCEDURE qlbv_dba.sp_revoke_update (
    user_or_role VARCHAR2,
    table_name VARCHAR2) 
IS 
BEGIN
    EXECUTE IMMEDIATE 'REVOKE UPDATE ON SYS.V_' || user_or_role || '_' || table_name || ' FROM ' || user_or_role;

END;
/
-- GRANT test_role to smithj;


-- GRANT execute on find_value to test_role;

-- 23/ gán role cho user
CREATE OR REPLACE PROCEDURE qlbv_dba.sp_grant_role_to_user (
    role_name VARCHAR2,
    user_name VARCHAR2)
IS 
BEGIN 
    EXECUTE IMMEDIATE 'GRANT ' || role_name || ' TO ' || user_name;
END;
/ 

/*
 create or replace procedure sp_drop_all_proc
 is
 cursor cs is select object_name from user_procedures 
 where object_type = 'procedure' 
 and object_name like 'sp_%'
 and object_name not like 'sp_drop_all_proc';
 begin
 for i in cs
 loop
 execute IMMEDIATE 'drop procedure ' || i.object_name;
 end loop;
 end;
 /
 -- drop procedure sp_drop_all_proc;
 */