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
GRANT SELECT ANY TABLE TO qlbv_dba;

CREATE OR REPLACE PROCEDURE qlbv_dba.sp_list_all_user 
IS 
    c_user_list SYS_REFCURSOR;
BEGIN 
    OPEN c_user_list FOR
    SELECT
        username,
        account_status,
        created,
        last_login
    FROM
        dba_users
    WHERE
        account_status = 'OPEN';

    -- **************** coi lại
    dbms_sql.return_result(c_user_list);
END;
/ 
-- exec qlbv_dba.sp_list_all_user;


-- 2/ show quyền của user
GRANT SELECT ON dba_sys_privs TO qlbv_dba;

CREATE OR REPLACE PROCEDURE qlbv_dba.sp_show_user_privileges (user varchar2) 
IS 
    c_privileges SYS_REFCURSOR;
BEGIN 
    OPEN c_privileges FOR
    SELECT
        privilege,
        grantee,
        admin_option
    FROM
        dba_sys_privs
    WHERE
        grantee = upper(user);

    dbms_sql.return_result(c_privileges);
END;

/ -- 3/ exec sp_show_user_privileges('c##pmtri2')
--  liệt kê tất cả các role đang open
GRANT SELECT ON dba_roles TO qlbv_dba;

CREATE OR REPLACE PROCEDURE qlbv_dba.sp_list_all_role 
IS 
    c_role_list SYS_REFCURSOR;
BEGIN 
    OPEN c_role_list FOR
    SELECT
        *
    FROM
        dba_roles;

    dbms_sql.return_result(c_role_list);
END;

/ -- exec sp_list_all_role;
-- 4/ xem quyền của một role
CREATE OR REPLACE PROCEDURE qlbv_dba.sp_show_role_privileges (role_name varchar2) 
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

/ -- exec sp_show_role_privileges('c##abc')
-- 5/ tạo một user
CREATE OR REPLACE PROCEDURE qlbv_dba.sp_create_user (
    username varchar2, 
    PASSWORD varchar2) 
AUTHID current_user 
IS 
BEGIN 
    EXECUTE IMMEDIATE 'CREATE USER ' || username || ' IDENTIFIED BY ' || PASSWORD;
    EXECUTE IMMEDIATE 'grant create session to ' || username;
END;

/ -- exec qlbv_dba.sp_create_user('tri123', 1)
-- 6/ xoá một user //can set env truoc khi xoa
CREATE OR REPLACE PROCEDURE qlbv_dba.sp_delete_user (
    username varchar2) 
IS 
BEGIN 
    EXECUTE IMMEDIATE 'DROP USER ' || username;
END;

/ -- exec sp_delete_user('c##abc3')
-- 7/ đổi mật khẩu (hiệu chỉnh user)
CREATE OR REPLACE PROCEDURE qlbv_dba.sp_change_user_password (
    username VARCHAR2,
    new_password VARCHAR2) 
IS 
BEGIN 
    EXECUTE IMMEDIATE 'alter user ' || username || ' identified by ' || new_password;
END;

/ -- exec sp_change_user_password('c##abc', '2')
-- 8/ lock một user (hiệu chỉnh user) //prevent login to database
CREATE OR REPLACE PROCEDURE qlbv_dba.sp_lock_user (
    username VARCHAR2) 
IS 
BEGIN 
    EXECUTE IMMEDIATE 'alter user ' || username || ' account lock';
END;

/ -- exec sp_lock_user('c##abc')
-- 9/ tạo một role
CREATE OR REPLACE PROCEDURE qlbv_dba.sp_create_role (
    role_name VARCHAR2) 
IS 
BEGIN 
    EXECUTE IMMEDIATE 'create role ' || role_name;
    EXECUTE IMMEDIATE 'GRANT create session to ' || role_name;
END;

/ -- exec sp_create_role ('c##role')
-- 10/ xoá role
CREATE OR REPLACE PROCEDURE qlbv_dba.sp_delete_role (
    role_name VARCHAR2) 
IS 
BEGIN 
    EXECUTE IMMEDIATE 'DROP ROLE ' || role_name;
END;

/ -- exec sp_delete_role ('c##role')
-- 11/ cấp quyền insert cho user/role trên table_name
CREATE OR REPLACE PROCEDURE qlbv_dba.sp_grant_insert (
    user_or_role VARCHAR2,
    table_name VARCHAR2) 
IS 
BEGIN 
    EXECUTE IMMEDIATE 'GRANT INSERT ON SYS.' || table_name || ' TO ' || user_or_role;
END;

/ -- 12/ cấp quyền insert cho user/role trên table_name (with GRANT option)
CREATE OR REPLACE PROCEDURE qlbv_dba.sp_grant_insert_wgo (
    user_or_role varchar2,
    table_name varchar2) 
IS 
BEGIN 
    EXECUTE IMMEDIATE 'GRANT INSERT ON SYS.' || table_name || ' TO ' || user_or_role || ' WITH GRANT OPTION';
END;

/ -- 13/ cấp quyền delete cho user/role trên table_name thông qua view [edit]
CREATE OR REPLACE PROCEDURE qlbv_dba.sp_grant_delete (
    user_or_role VARCHAR2,
    table_name VARCHAR2) 
IS 
BEGIN 
    EXECUTE IMMEDIATE 'GRANT DELETE ON SYS.' || table_name || ' TO ' || user_or_role;
END;

/ -- 14/ cấp quyền delete cho user/role trên table_name thông qua view (with GRANT option) [edit]
CREATE OR REPLACE PROCEDURE sp_grant_delete_wgo (
    user_or_role VARCHAR2,
    table_name VARCHAR2) 
IS 
BEGIN 
    EXECUTE IMMEDIATE 'GRANT DELETE ON SYS.' || table_name || ' TO ' || user_or_role || ' WITH GRANT OPTION';
END;

/ -- 15/ cấp quyền select cho user/role trên column_list thuộc table_name
CREATE OR REPLACE PROCEDURE sp_grant_select (
    user_or_role VARCHAR2,
    table_name VARCHAR2,
    column_list VARCHAR2) 
IS 
BEGIN 
    EXECUTE IMMEDIATE 'CREATE OR REPLACE VIEW V_' || user_or_role || '_' || table_name || ' AS SELECT ' || column_list || ' FROM ' || table_name;
    EXECUTE IMMEDIATE 'GRANT SELECT ON SYS.V_' || user_or_role || '_' || table_name || ' TO ' || user_or_role;
END;

/ -- exec sp_grant_select('c##pmtri2', 'a_test2', 'id, content')
-- 16/ cấp quyền select cho user/role trên column_list thuộc table_name (with GRANT option)
CREATE OR REPLACE PROCEDURE sp_grant_select_wgo (
    user_or_role VARCHAR2,
    table_name VARCHAR2,
    column_list VARCHAR2) 
IS 
BEGIN 
    EXECUTE IMMEDIATE 'CREATE OR REPLACE VIEW V_' || user_or_role || '_' || table_name || ' AS SELECT ' || column_list || ' FROM ' || table_name;
    EXECUTE IMMEDIATE 'GRANT SELECT ON SYS.V_' || user_or_role || '_' || table_name || ' TO ' || user_or_role || ' WITH GRANT OPTION';
END;

/ -- 17/ cấp quyền update cho user/role trên column_list thuộc table_name
CREATE OR REPLACE PROCEDURE sp_grant_update (
    user_or_role VARCHAR2,
    table_name VARCHAR2,
    column_list VARCHAR2) 
IS 
BEGIN 
    EXECUTE IMMEDIATE 'GRANT UPDATE (' || column_list || ') ON SYS.V_' || user_or_role || '_' || table_name || ' TO ' || user_or_role;
END;

/ -- exec sp_grant_update('c##pmtri2', 'a_test2', 'content');
-- 18/ cấp quyền update cho user/role trên column_list thuộc table_name (with GRANT option)
CREATE OR REPLACE PROCEDURE sp_grant_update_wgo (
    user_or_role VARCHAR2,
    table_name VARCHAR2,
    column_list VARCHAR2) 
IS 
BEGIN
    EXECUTE IMMEDIATE 'GRANT UPDATE (' || column_list || ') ON SYS.V_' || user_or_role || '_' || table_name || ' TO ' || user_or_role || ' WITH GRANT OPTION';
END;

/ -- exec sp_grant_update_to_user_wgo ('c##pmtri2', 'a_test2', 'content');
-- 19/ thu hồi quyền insert table_name từ user/role
CREATE OR REPLACE PROCEDURE sp_revoke_insert (
    user_or_role VARCHAR2,
    table_name VARCHAR2) 
IS 
BEGIN
    EXECUTE IMMEDIATE 'REVOKE INSERT ON SYS.' || table_name || ' FROM ' || user_or_role;
END;

/ -- 20/ thu hôi quyền delete table_name từ user/role
CREATE OR REPLACE PROCEDURE sp_revoke_delete (
    user_or_role VARCHAR2,
    table_name VARCHAR2) 
IS 
BEGIN
    EXECUTE IMMEDIATE 'REVOKE DELETE ON SYS.V_' || user_or_role || '_' || table_name || ' FROM ' || user_or_role;
END;

/ -- 21/ thu hồi quyền select table_name từ user/role
CREATE OR REPLACE PROCEDURE sp_revoke_select (
    user_or_role VARCHAR2,
    table_name VARCHAR2,
    column_list VARCHAR2) 
IS 
BEGIN
    EXECUTE IMMEDIATE 'REVOKE SELECT ON SYS.V_' || user_or_role || '_' || table_name || ' FROM ' || user_or_role;
END;

/ -- 22/ thu hồi quyền update từ user/role trên table_name
CREATE OR REPLACE PROCEDURE sp_revoke_update (
    user_or_role VARCHAR2,
    table_name VARCHAR2) 
IS 
BEGIN
    EXECUTE IMMEDIATE 'REVOKE UPDATE ON SYS.V_' || user_or_role || '_' || table_name || ' FROM ' || user_or_role;

END;

/ -- GRANT test_role to smithj;
-- GRANT execute on find_value to test_role;
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
 -- exec sp_drop_all_proc;
 -- drop procedure sp_drop_all_proc;
 */