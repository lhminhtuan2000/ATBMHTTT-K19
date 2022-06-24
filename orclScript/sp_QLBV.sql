--login = USER ADMIN of PDB
SET SERVEROUTPUT ON; --turn on DBMS_SQL.RETURN_RESULT

ALTER PLUGGABLE DATABASE pdb1 OPEN;
ALTER SESSION SET container = pdb1;
ALTER USER pdb1dba QUOTA UNLIMITED ON SYSTEM;
ALTER SESSION SET current_schema = pdb1dba;

-- PROCEDURE
-- Liệt kê tất cả các user đang open
CREATE OR REPLACE NONEDITIONABLE PROCEDURE sp_list_all_user
IS
    c_user_list SYS_REFCURSOR;
BEGIN
    open c_user_list for
    SELECT username,ACCOUNT_STATUS,default_tablespace,CREATED
    FROM dba_users
    WHERE account_status = 'OPEN';
    
    DBMS_SQL.RETURN_RESULT(c_user_list);
END;
/
--exec sp_list_all_user;

-- Show quyền của user
create or replace NONEDITIONABLE procedure sp_show_user_privileges (
    username varchar2
)
is
    c_privileges SYS_REFCURSOR;
begin
    open c_privileges for
    SELECT privilege,GRANTEE,ADMIN_OPTION,USERNAME
    FROM DBA_SYS_PRIVS
    where grantee = UPPER(username);
        
    DBMS_SQL.RETURN_RESULT(c_privileges);
end;
/
--exec sp_show_user_privileges('c##pmtri2')

-- Liệt kê tất cả các role đang open
create or replace NONEDITIONABLE PROCEDURE sp_list_all_role
IS
    c_role_list SYS_REFCURSOR;
BEGIN
    OPEN c_role_list FOR
    SELECT * FROM DBA_ROLES;

    DBMS_SQL.RETURN_RESULT(c_role_list);
END;
/
--exec sp_list_all_role;

-- Xem quyền của một role
create or replace NONEDITIONABLE procedure sp_show_role_privileges (
    role_name varchar2 
)
is
    c_privileges SYS_REFCURSOR;
begin
    open c_privileges for
    select privilege,ADMIN_OPTION
    from role_sys_privs
    where role = UPPER(role_name);
    
    DBMS_SQL.RETURN_RESULT(c_privileges);
end;
/
--exec sp_show_role_privileges('c##abc')

-- Tạo một user
create or replace NONEDITIONABLE procedure sp_create_user (
    username varchar2,
    password varchar2
)
is
begin 
    execute immediate 'alter session set "_ORACLE_SCRIPT" = true'; --non-prefix username
    execute immediate 'create user ' || username || ' IDENTIFIED BY '|| password;
    execute immediate 'grant create session to ' || username;
    execute immediate 'alter session set "_ORACLE_SCRIPT" = false';
end;
/
--exec sp_create_user('c##abc', 1)

-- Xoá một user //can set env truoc khi xoa
create or replace NONEDITIONABLE procedure sp_delete_user (
    username varchar2
)
is
begin 
    execute immediate 'drop user ' || username;
end;
/
--exec sp_delete_user('c##abc3')

-- Đổi mật khẩu (hiệu chỉnh user)
create or replace NONEDITIONABLE procedure sp_change_user_password(
    username varchar2,
    new_password varchar2
)
is
begin
    execute immediate 'alter user ' || username || ' identified by ' || new_password;
end;
/
--exec sp_change_user_password('c##abc', '2')

-- Lock một user (hiệu chỉnh user) //prevent login to database
create or replace NONEDITIONABLE procedure sp_lock_user(
    username varchar2
)
is
begin
    execute immediate 'alter user ' || username || ' ACCOUNT LOCK';
end;
/
--exec sp_lock_user('c##abc')

-- Tạo một role
create or replace NONEDITIONABLE procedure sp_create_role (
    role_name varchar2
)
is
begin
    execute immediate 'alter session set "_ORACLE_SCRIPT" = true'; --non-prefix username
    execute immediate 'create role ' || role_name;
    execute immediate 'grant create session to ' || role_name;
end;
/
--exec sp_create_role ('c##role')

-- Xoá role
create or replace NONEDITIONABLE procedure sp_delete_role (
    role_name varchar2
)
is
begin
    execute immediate 'DROP ROLE ' || role_name;
end;
/
--exec sp_delete_role ('c##role')

-- Cấp quyền insert cho user/role trên table_name
create or replace procedure sp_grant_insert (
    user_or_role varchar2,
    table_name varchar2
)
is
begin
    execute immediate 'grant insert on sys.'||table_name||' to '||user_or_role;
end;
/

-- Cấp quyền insert cho user/role trên table_name (with grant option)
create or replace procedure sp_grant_insert_wgo (
    user_or_role varchar2,
    table_name varchar2
)
is
begin
    execute immediate 'grant insert on sys.'||table_name||' to '||user_or_role||' with grant option';
end;
/

-- Cấp quyền delete cho user/role trên table_name thông qua view [edit]
create or replace procedure sp_grant_delete (
    user_or_role varchar2,
    table_name varchar2
)
is
begin
    execute immediate 'grant delete on sys.'||table_name||' to '||user_or_role;
end;
/

-- Cấp quyền delete cho user/role trên table_name thông qua view (with grant option) [edit]
create or replace procedure sp_grant_delete_wgo (
    user_or_role varchar2,
    table_name varchar2
)
is
begin
    execute immediate 'grant delete on sys.'||table_name||' to '||user_or_role||' with grant option';
end;
/

-- Cấp quyền select cho user/role trên column_list thuộc table_name
create or replace procedure sp_grant_select (
    user_or_role varchar2,
    table_name varchar2,
    column_list varchar2
)
is
begin
    execute immediate 'create or replace view v_' || user_or_role || '_' || table_name || ' as select ' || column_list || ' from ' || table_name;
    execute immediate 'grant select on sys.v_' || user_or_role || '_' || table_name || ' to ' || user_or_role;
end;
/
--exec sp_grant_select('c##pmtri2', 'a_test2', 'id, content')

-- Cấp quyền select cho user/role trên column_list thuộc table_name (with grant option)
create or replace procedure sp_grant_select_wgo (
    user_or_role varchar2,
    table_name varchar2,
    column_list varchar2
)
is
begin
    execute immediate 'create or replace view v_' || user_or_role || '_' || table_name || ' as select ' || column_list || ' from ' || table_name;
    execute immediate 'grant select on sys.v_' || user_or_role || '_' || table_name || ' to ' || user_or_role || ' with grant option';
end;
/

-- Cấp quyền update cho user/role trên column_list thuộc table_name
create or replace procedure sp_grant_update (
    user_or_role varchar2,
    table_name varchar2,
    column_list varchar2
)
is
begin
    execute immediate 'grant update ('||column_list||') on sys.v_'||user_or_role||'_'||table_name||' to '||user_or_role;
end;
/
--exec sp_grant_update('c##pmtri2', 'a_test2', 'content');

-- Cấp quyền update cho user/role trên column_list thuộc table_name (with grant option)
create or replace procedure sp_grant_update_wgo (
    user_or_role varchar2,
    table_name varchar2,
    column_list varchar2
)
is
begin
    execute immediate 'grant update ('||column_list||') on sys.v_'||user_or_role||'_'||table_name||' to '||user_or_role||' with grant option';
end;
/
--exec sp_grant_update_to_user_wgo ('c##pmtri2', 'a_test2', 'content');

-- Thu hồi quyền insert table_name từ user/role
create or replace procedure sp_revoke_insert (
    user_or_role varchar2,
    table_name varchar2
)
is
begin
    execute immediate 'revoke insert on sys.'||table_name||' from '||user_or_role;
end;
/

-- Thu hôi quyền delete table_name từ user/role
create or replace procedure sp_revoke_delete (
    user_or_role varchar2,
    table_name varchar2
)
is
begin
    execute immediate 'revoke delete on sys.v_'||user_or_role||'_'||table_name||' from '||user_or_role;
end;
/

-- Thu hồi quyền select table_name từ user/role
create or replace procedure sp_revoke_select (
    user_or_role varchar2,
    table_name varchar2,
    column_list varchar2
)
is
begin
    execute immediate 'revoke select on sys.v_' || user_or_role || '_' || table_name || ' from ' || user_or_role;
end;
/

-- Thu hồi quyền update từ user/role trên table_name
create or replace procedure sp_revoke_update (
    user_or_role varchar2,
    table_name varchar2
)
is
begin
    execute immediate 'revoke update on sys.v_'||user_or_role||'_'||table_name||' from '||user_or_role;
end;
/
--GRANT test_role TO smithj;
--GRANT execute ON Find_Value TO test_role;

/*
create or replace procedure sp_drop_all_proc
is
    CURSOR cs IS SELECT object_name FROM user_procedures 
        WHERE object_type = 'PROCEDURE' 
        and object_name like 'SP_%'
        and object_name not like 'SP_DROP_ALL_PROC';
begin
    for i in cs
    loop
        execute immediate 'drop procedure ' || i.object_name;
    end loop;
end;
/
--exec sp_drop_all_proc;

drop procedure sp_drop_all_proc;
*/