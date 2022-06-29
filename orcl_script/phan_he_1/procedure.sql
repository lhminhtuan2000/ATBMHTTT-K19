
-- RUN BY SYS, CONTAINER = QLBV_PDB
ALTER SESSION SET CONTAINER = qlbv_pdb;

--  PROCEDURE
--  1/ LIỆT KÊ TẤT CẢ CÁC USER ĐANG OPEN 
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


-- 2/ SHOW SYSTEM PRIVILEGE CỦA USER
CREATE OR REPLACE VIEW v_pdb_dba_sys_privs
AS
SELECT dsp.*
FROM dba_sys_privs dsp, v_pdb_dba_users vpdu
WHERE dsp.grantee = vpdu.username;

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


-- 3/ SHOW OBJECT PRIVILEGE CỦA USER
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


-- 4/ SHOW ROLE CỦA HỆ THỐNG
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

-- 5/ XEM SYSTEM PRIVS CỦA ROLE
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


-- 6/ SHOW OBJECT PRIVS CỦA ROLE
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



-- 7/ TẠO MỘT USER
CREATE OR REPLACE PROCEDURE qlbv_dba.sp_create_user (
    username VARCHAR2, 
    password VARCHAR2) 
AUTHID CURRENT_USER 
IS 
BEGIN 
    EXECUTE IMMEDIATE 'CREATE USER ' || username || ' IDENTIFIED BY ' || PASSWORD;
END;
/ 


-- 8/ XOÁ MỘT USER
CREATE OR REPLACE PROCEDURE qlbv_dba.sp_delete_user (
    username VARCHAR2) 
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


-- 10+/ (proc ngoài lề) unlock một user 
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


-- 12/ XOÁ ROLE
CREATE OR REPLACE PROCEDURE qlbv_dba.sp_delete_role (
    role_name VARCHAR2) 
IS 
BEGIN 
    EXECUTE IMMEDIATE 'DROP ROLE ' || role_name;
END;
/


-- 13/ GRANT OBJECT PRIVILEGE CHO USER/ROLE
CREATE OR REPLACE PROCEDURE qlbv_dba.sp_grant_obj_priv (
    user_or_role VARCHAR2,
    privilege VARCHAR2,
    schema_name VARCHAR2,
    obj_name VARCHAR2,
    with_grant_option VARCHAR2)
AUTHID CURRENT_USER
IS
BEGIN
    IF with_grant_option = '1'
    THEN
        EXECUTE IMMEDIATE '
            GRANT ' || privilege || ' ON ' || 
            schema_name || '.' || obj_name || ' TO ' || 
            user_or_role || ' WITH GRANT OPTION';
    ELSE
        EXECUTE IMMEDIATE '
            GRANT ' || privilege || ' ON ' || 
            schema_name || '.' || obj_name || ' TO ' || 
            user_or_role;
    END IF;
END;
/


-- 14/ REVOKE OBJECT PRIVILEGE TỪ USER/ROLE
CREATE OR REPLACE PROCEDURE qlbv_dba.sp_revoke_obj_priv (
    user_or_role VARCHAR2,
    privilege VARCHAR2,
    schema_name VARCHAR2,
    obj_name VARCHAR2)
AUTHID CURRENT_USER
IS
BEGIN
    EXECUTE IMMEDIATE '
        REVOKE ' || privilege || ' ON ' || 
        schema_name || '.' || obj_name || ' FROM ' || 
        user_or_role;
END;
/


-- 15/ GRANT SYSTEM PRIVILEGE CHO USER/ROLE
CREATE OR REPLACE PROCEDURE qlbv_dba.sp_grant_sys_priv (
    user_or_role VARCHAR2,
    privilege VARCHAR2,
    with_admin_option VARCHAR2)
AUTHID CURRENT_USER
IS
BEGIN
    IF with_admin_option = '1'
    THEN
        EXECUTE IMMEDIATE '
            GRANT ' || privilege || ' TO ' || user_or_role || ' WITH ADMIN OPTION';
    ELSE
        EXECUTE IMMEDIATE '
            GRANT ' || privilege || ' TO ' || user_or_role;
    END IF;
END;
/


-- 16/ REVOKE SYSTEM PRIVILEGE TỪ USER/ROLE
CREATE OR REPLACE PROCEDURE qlbv_dba.sp_revoke_sys_priv (
    user_or_role VARCHAR2,
    privilege VARCHAR2)
AUTHID CURRENT_USER
IS
BEGIN
    EXECUTE IMMEDIATE '
        REVOKE ' || privilege || ' FROM ' || user_or_role;
END;
/


-- 17/ CẤP QUYỀN SELECT CHO USER/ROLE TRÊN TABLE_NAME
CREATE OR REPLACE PROCEDURE qlbv_dba.sp_grant_select_table (
    user_or_role VARCHAR2,
    schema_name VARCHAR2,
    table_name VARCHAR2,
    col_name VARCHAR2,
    with_grant_option VARCHAR2) 
AUTHID CURRENT_USER
IS 
    view_name VARCHAR(100);
    col_names_str VARCHAR2(50);
    flag NUMBER;
BEGIN 
    -- Lấy tên của view
    view_name := UPPER('v__' || user_or_role || '_' || table_name); 
    -- Kiểm tra xem column đã đươc cấp quyền chưa 
    -- (column được cấp quyền sẽ nằm trong view)
    SELECT COUNT(*) 
    INTO flag
    FROM all_tab_columns 
    WHERE table_name = view_name AND column_name = UPPER(col_name);
    
    -- Nếu có rồi thì kết thúc proc
    IF flag > 0
    THEN
        RETURN;
    END IF;

    -- Tạo chuỗi column
    col_names_str := col_name;
    -- Lấy các column đã được grant trước đó (Các colum đó nằm trong view)
    FOR v IN (
        SELECT column_name 
        FROM all_tab_columns 
        WHERE table_name = view_name)
    LOOP
        col_names_str := col_names_str || ', ' || v.column_name;
    END LOOP;
    
    -- Tạo view với các column tương ứng
    EXECUTE IMMEDIATE '
        CREATE OR REPLACE VIEW qlbv_dba.' || view_name || '
        AS
        SELECT ' || col_names_str || '
        FROM ' || schema_name || '.' || table_name; 
    -- Cấp view
    IF with_grant_option = '1'
    THEN
        EXECUTE IMMEDIATE '
            GRANT SELECT ON ' || schema_name || '.' || view_name || ' TO ' || user_or_role || ' 
            WITH GRANT OPTION';
    ELSE
        EXECUTE IMMEDIATE '
            GRANT SELECT ON ' || schema_name || '.' || view_name || ' TO ' || user_or_role;
    END IF;     
END;
/


-- 18/ REVOKE SELECT TRÊN MỘT BẢNG
CREATE OR REPLACE PROCEDURE qlbv_dba.sp_revoke_select_table (
    user_or_role VARCHAR2,
    table_name VARCHAR2)
IS
    view_name VARCHAR(100);
BEGIN
    view_name := UPPER('v__' || user_or_role || '_' || table_name);  
    EXECUTE IMMEDIATE '
        DROP VIEW qlbv_dba.' || view_name;
END;
/

-- 19/ GRANT UPDATE

-- 19.1/ Tạo kiếu dữ liệu mảng với các element là chuỗi
CREATE OR REPLACE TYPE qlbv_dba.str_list IS TABLE OF VARCHAR2(50);
/

-- 19.2/ Tạo procedure lấy danh sách primary key của table
CREATE OR REPLACE PROCEDURE qlbv_dba.get_primary_keys (
    schema_name VARCHAR2,
    table_name_ VARCHAR2,
    primary_keys OUT str_list)
IS
BEGIN
    primary_keys := str_list();
    FOR i IN (
        SELECT cols.column_name as column_name
        FROM all_constraints cons, all_cons_columns cols
        WHERE 
            cons.owner = UPPER(schema_name) AND
            cols.table_name = UPPER(table_name_) AND 
            cons.constraint_type = 'P' AND 
            cons.constraint_name = cols.constraint_name AND 
            cons.owner = cols.owner
        ORDER BY cols.table_name, cols.position)
    LOOP
        primary_keys.extend;
        primary_keys(primary_keys.LAST) := i.column_name;
    END LOOP;
END;
/

-- Dùng sys để grant
GRANT SELECT ON DBA_COL_PRIVS TO QLBV_DBA;
-- 19.3/ Proc để lấy danh sách column đã được grant 
CREATE OR REPLACE PROCEDURE qlbv_dba.get_granted_colums (
    schema_name VARCHAR2,
    table_name_ VARCHAR2,
    user_name VARCHAR2, 
    granted_cols OUT str_list)
IS
BEGIN
    granted_cols := str_list();
    FOR i IN (
        SELECT COLUMN_NAME
        FROM DBA_COL_PRIVS 
        WHERE 
            GRANTEE = UPPER(user_name) AND
            OWNER = UPPER(schema_name) AND
            TABLE_NAME = UPPER(table_name_) AND
            PRIVILEGE = 'UPDATE')
    LOOP
        granted_cols.extend;
        granted_cols(granted_cols.LAST) := i.COLUMN_NAME;
    END LOOP;
END;
/

SELECT * FROM DBA_COL_PRIVS;

-- 19.4/ GRANT UPDATE ON CLUMN
CREATE OR REPLACE PROCEDURE qlbv_dba.sp_grant_update_on_table (
    user_or_role VARCHAR2,
    schema_name VARCHAR2,
    table_name VARCHAR2,
    col_name VARCHAR2,
    with_grant_option VARCHAR2) 
AUTHID CURRENT_USER
IS 
    primary_keys str_list := str_list();
    granted_cols str_list := str_list();
    view_name VARCHAR2(100);
    create_strg_str VARCHAR2(1000) := ''; -- Chuỗi dùng để tạo instead of trigger
    grant_str VARCHAR2(500) := ''; -- Chuỗi để grant update
BEGIN 
    -- View name ứng với tên user và tên table
    view_name := UPPER('v__' || user_or_role || '_' || table_name);

    -- Lấy danh sách colum đã được cấp từ trước
    qlbv_dba.get_granted_colums(schema_name, view_name, user_or_role, granted_cols);
    
    -- Nếu column được cấp đã được cấp thì kết thúc proc
    IF UPPER(col_name) MEMBER OF granted_cols THEN
        RETURN;
    ELSE
        granted_cols.extend;
        granted_cols(granted_cols.LAST) := col_name;
    END IF;

    -- Lấy danh sách primary 
    qlbv_dba.get_primary_keys(schema_name, table_name, primary_keys);


    
    create_strg_str := '
    CREATE OR REPLACE TRIGGER qlbv_dba.iotrg_update_' || user_or_role || '_' || table_name || '
        INSTEAD OF UPDATE ON qlbv_dba.' || view_name || '
        FOR EACH ROW
    BEGIN
        UPDATE ' || schema_name || '.' || table_name || '
        SET ';

    grant_str := 'GRANT UPDATE (';
    
    FOR i IN 1..(granted_cols.LAST - 1)
    LOOP
        -- Set column trong lệnh update
        create_strg_str := create_strg_str || granted_cols(i) || ' = :new.' || granted_cols(i) || ',
        ';
        
        -- Column trong câu lệnh grant update
        grant_str := grant_str || granted_cols(i) || ', ';
    END LOOP;

    create_strg_str := create_strg_str || granted_cols(granted_cols.LAST) || ' = :NEW.' || granted_cols(granted_cols.LAST) || '
    WHERE ';
    
    grant_str := grant_str || granted_cols(granted_cols.LAST) || ') ON ' || view_name || ' TO ' || user_or_role;
    
    -- Các clause trong mệnh đề where trong update statement
    create_strg_str := create_strg_str || primary_keys(1) || ' = :OLD.' || primary_keys(1);
    
    FOR i IN 2..primary_keys.COUNT 
    LOOP
        create_strg_str := create_strg_str || ' AND 
        ' || primary_keys(i) || ' = :OLD.' || primary_keys(i);
    END LOOP;

    -- END trigger
    create_strg_str := create_strg_str || ';
    END;';

    EXECUTE IMMEDIATE grant_str;
    EXECUTE IMMEDIATE create_strg_str;
END;
/

-- 20/ REVOKE UPDATE TRÊN MỘT BẢNG
CREATE OR REPLACE PROCEDURE qlbv_dba.sp_revoke_update_table (
    user_or_role VARCHAR2,
    table_name VARCHAR2)
IS
    view_name VARCHAR(100);
BEGIN
    view_name := UPPER('v__' || user_or_role || '_' || table_name);  
    EXECUTE IMMEDIATE '
        REVOKE UPDATE ON qlbv_dba.' || view_name || ' FROM ' || user_or_role;
END;
/


-- 21/ GRANT INSERT LÊN MỘT BẢNG
CREATE OR REPLACE PROCEDURE qlbv_dba.sp_grant_insert_table (
    user_or_role VARCHAR2,
    schema_name VARCHAR2,
    table_name VARCHAR2,
    with_grant_option VARCHAR2)
IS
BEGIN
    IF with_grant_option = '1'
    THEN
        EXECUTE IMMEDIATE 'GRANT INSERT ON ' || 
            schema_name || '.' || table_name || ' TO ' || user_or_role || ' WITH GRANT OPTION';
    ELSE
        EXECUTE IMMEDIATE 'GRANT INSERT ON ' || 
            schema_name || '.' || table_name || ' TO ' || user_or_role;
    END IF;
END;
/


-- 22/ REVOKE INSERT TỪ MỘT USER/ROLE
CREATE OR REPLACE PROCEDURE qlbv_dba.sp_revoke_insert_table (
    user_or_role VARCHAR2,
    schema_name VARCHAR2,
    table_name VARCHAR2)
IS 
BEGIN
    EXECUTE IMMEDIATE 'REVOKE INSERT ON ' || 
        schema_name || '.' || table_name || ' FROM ' || user_or_role;
END;
/


-- 23/ GRANT DELETE LÊN MỘT TABLE
CREATE OR REPLACE PROCEDURE qlbv_dba.sp_grant_delete_table (
    user_or_role VARCHAR2,
    schema_name VARCHAR2,
    table_name VARCHAR2,
    with_grant_option VARCHAR2)
AUTHID CURRENT_USER
IS
    primary_keys str_list := str_list();
    create_strg_str VARCHAR2(1000) := ''; -- Chuỗi dùng để tạo instead of trigger
    view_name VARCHAR(100);
BEGIN
    view_name := UPPER('v__' || user_or_role || '_' || table_name);
    IF with_grant_option = '1'
    THEN
        EXECUTE IMMEDIATE '
            GRANT DELETE ON qlbv_dba.' || view_name || ' TO ' || user_or_role ||
             ' WITH GRANT OPTION';
    ELSE
        EXECUTE IMMEDIATE '
            GRANT DELETE ON qlbv_dba.' || view_name || ' TO ' || user_or_role;
    END IF;  
    
    qlbv_dba.get_primary_keys(schema_name, table_name, primary_keys);

    create_strg_str := '
        CREATE OR REPLACE TRIGGER qlbv_dba.iotrg_delete_' || user_or_role || '_' || table_name || '
            INSTEAD OF DELETE ON qlbv_dba.' || view_name || '
            FOR EACH ROW
        BEGIN
            DELETE 
            FROM ' || schema_name || '.' || table_name || '
            WHERE ';
    create_strg_str := create_strg_str || primary_keys(1) || ' = :OLD.' || primary_keys(1);
    FOR i IN 2..primary_keys.COUNT 
    LOOP
        create_strg_str := create_strg_str || ' AND 
        ' || primary_keys(i) || ' = :OLD.' || primary_keys(i);
    END LOOP;

    create_strg_str := create_strg_str || '; END;';
    
    EXECUTE IMMEDIATE create_strg_str;
END;
/


-- 24/ REVOKE DELETE ON TABLE
CREATE OR REPLACE PROCEDURE qlbv_dba.sp_revoke_delete_table (
    user_or_role VARCHAR2,
    schema_name VARCHAR2,
    table_name VARCHAR2)
IS 
    view_name VARCHAR(100);
BEGIN
    view_name := UPPER('v__' || user_or_role || '_' || table_name);  
    EXECUTE IMMEDIATE '
        REVOKE DELETE ON qlbv_dba.' || view_name || ' FROM ' || user_or_role;
END;
/