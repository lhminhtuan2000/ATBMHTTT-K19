
SELECT *
FROM role_tab_privs
WHERE ROLE ='TEST_ROLE'
-- TEST PROC
-- 1/ LIỆT KÊ TẤT CẢ CÁC USER ĐANG OPEN
EXEC qlbv_dba.sp_list_all_user;
-- TESTED


-- 2/ SHOW SYSTEM PRIVILEGE CỦA USER
GRANT DELETE ANY TABLE TO HOA;
GRANT DELETE ANY TABLE TO tri123;
EXEC sp_show_user_sys_privs('tri123');
EXEC sp_show_user_sys_privs('hoa');
REVOKE DELETE ANY TABLE FROM HOA;
REVOKE DELETE ANY TABLE FROM tri123;
-- TESTED


-- 3/ SHOW OBJECT PRIVILEGES CỦA USER
GRANT DELETE ON NHANVIEN TO HOA;
GRANT DELETE ON NHANVIEN TO TRI123;
EXEC sp_show_user_obj_privs('hoa');
EXEC sp_show_user_obj_privs('tri123');
REVOKE DELETE ON NHANVIEN FROM HOA;
REVOKE DELETE ON NHANVIEN FROM TRI123;
-- TESTED


-- 4/ SHOW ROLE CỦA HỆ THỐNG
CREATE ROLE test_role;
CREATE ROLE test_role2;
CREATE ROLE test_role3;
CREATE ROLE test_role4;
EXEC sp_show_roles; 
-- TESTED


-- 5/ XEM SYSTEM PRIVS CỦA ROLE
GRANT CREATE SESSION TO super_role2;
GRANT SELECT ANY TABLE TO test_role;
EXEC sp_role_sys_privs('super_role2');
-- TESTED


-- 6/ XEM OBJECT PRIVS CỦA ROLE
GRANT SELECT ON BENHNHAN TO super_role2;
GRANT DELETE ON NHANVIEN TO TEST_ROLE;
GRANT DELETE ON NHANVIEN TO TEST_ROLE2;
GRANT DELETE ON NHANVIEN TO TEST_ROLE3;
EXEC sp_role_obj_privs('super_role2');
-- TESTED


-- 7/ TẠO MỘT USER
EXEC qlbv_dba.sp_create_user('tri123', 1); 
EXEC qlbv_dba.sp_create_user('tri1', 1); 
EXEC qlbv_dba.sp_create_user('tri2', 1); 
EXEC qlbv_dba.sp_create_user('tri3', 1); 
EXEC qlbv_dba.sp_list_all_user;
-- TESTED


-- 8/ XOÁ MỘT USER
EXEC qlbv_dba.sp_delete_user('tri1'); 
EXEC qlbv_dba.sp_delete_user('tri2'); 
EXEC qlbv_dba.sp_delete_user('tri3'); 
EXEC qlbv_dba.sp_list_all_user;
-- TESTED


-- 9/ ĐỔI MẬT KHẨU (HIỆU CHỈNH USER)
EXEC qlbv_dba.sp_create_user('tri123', 1);
EXEC sp_change_user_password('tri123', '21');
GRANT CREATE SESSION TO tri123;
-- TESTED


-- 10/ LOCK MỘT USER (HIỆU CHỈNH USER)
-- Lock thì user đó sẽ có status là close
EXEC sp_lock_user('tri123');
EXEC qlbv_dba.sp_list_all_user;
-- TESTED


-- 10+/ (PROC NGOÀI LÊ) UNLOCK MỘT USER 
EXEC sp_unlock_user('tri123');
EXEC qlbv_dba.sp_list_all_user;
-- TESTED


-- 11/ TẠO MỘT ROLE
EXEC sp_create_role ('super_role2'); 
EXEC sp_show_roles; 
-- TESTED


-- 12/ XOÁ ROLE
EXECUTE sp_delete_role('super_role2'); 
EXEC sp_show_roles; 
-- TESTED


-- 13/ GRANT OBJECT PRIVILEGE CHO USER/ROLE
EXECUTE qlbv_dba.sp_grant_obj_priv('tri123', 'select', 'QLBV_DBA', 'NHANVIEN', TRUE);
EXECUTE qlbv_dba.sp_grant_obj_priv('tri123', 'delete', 'QLBV_DBA', 'NHANVIEN', FALSE);
EXEC sp_show_user_obj_privs('tri123');
-- TESTED


-- 14/ REVOKE OBJECT PRIVILEGE TỪ USER/ROLE
EXECUTE sp_revoke_obj_priv('tri123', 'select', 'QLBV_DBA', 'nhanvien');
EXECUTE sp_revoke_obj_priv('tri123', 'delete', 'QLBV_DBA', 'nhanvien');
EXEC sp_show_user_obj_privs('tri123');
-- TESTED


-- 15/ GRANT SYSTEM PRIVILEGE CHO USER/ROLE
EXECUTE sp_grant_sys_priv('tri123', 'CREATE SESSION', TRUE);
EXECUTE sp_grant_sys_priv('tri123', 'select any table', TRUE);
EXECUTE sp_grant_sys_priv('tri123', 'DELETE any table', FALSE);
EXEC sp_show_user_sys_privs('tri123');
-- TESTED


-- 16/ REVOKE SYSTEM PRIVILEGE TỪ USER/ROLE
EXECUTE sp_revoke_sys_priv('tri123', 'select any table');
EXECUTE sp_revoke_sys_priv('tri123', 'DELETE any table');
EXEC sp_show_user_sys_privs('tri123');
-- TESTED


-- 17/ CẤP QUYỀN INSERT CHO USER/ROLE TRÊN TABLE_NAME
EXECUTE sp_grant_insert_table('tri123', 'qlbv_dba', 'nhanvien', 'manv', TRUE);
EXECUTE sp_grant_insert_table('hoa', 'qlbv_dba', 'nhanvien', 'manv', TRUE);
EXECUTE sp_grant_insert_table('super_role2', 'qlbv_dba', 'nhanvien', 'manv', FALSE);

EXECUTE sp_grant_insert_table('tri123', 'qlbv_dba', 'nhanvien', 'HOTEN', TRUE);
EXECUTE sp_grant_insert_table('hoa', 'qlbv_dba', 'nhanvien', 'CMND', TRUE);
EXECUTE sp_grant_insert_table('hoa', 'qlbv_dba', 'nhanvien', 'hoten', TRUE);


EXEC sp_show_user_obj_privs('hoa');
EXEC sp_show_user_obj_privs('tri123');
EXEC sp_role_obj_privs('super_role2');

SELECT * FROM V__SUPER_ROLE2_NHANVIEN;
GRANT SELECT ON V__SUPER_ROLE2_NHANVIEN TO SUPER_ROLE2;
REVOKE SELECT ON V__SUPER_ROLE2_NHANVIEN FROM SUPER_ROLE2;
DROP VIEW V__SUPER_ROLE2_NHANVIEN;
-- TESTED


-- 18/ REVOKE SELECT TRÊN MỘT BẢNG
EXECUTE sp_revoke_insert_table('tri123','nhanvien');
EXECUTE sp_revoke_insert_table('hoa','nhanvien');
EXECUTE sp_revoke_insert_table('super_role2','nhanvien');
-- TESTED


-- 19.4/ GRANT UPDATE ON CLUMN
EXECUTE sp_grant_insert_table('tri123', 'qlbv_dba', 'nhanvien', 'manv', TRUE);
EXECUTE sp_grant_insert_table('tri123', 'qlbv_dba', 'nhanvien', 'hoten', TRUE);
EXECUTE sp_grant_insert_table('tri123', 'qlbv_dba', 'nhanvien', 'cmnd', TRUE);
EXECUTE sp_grant_insert_table('tri123', 'qlbv_dba', 'nhanvien', 'phai', TRUE);

EXECUTE sp_grant_update_on_table('tri123', 'qlbv_dba', 'nhanvien', 'hoten', FALSE);
EXECUTE sp_grant_update_on_table('tri123', 'qlbv_dba', 'nhanvien', 'cmnd', FALSE);
-- TESTED


-- 20/ REVOKE UPDATE TRÊN MỘT BẢNG
EXECUTE sp_revoke_update_table('tri123', 'nhanvien');
-- TESTED


-- 21/ GRANT INSERT LÊN MỘT BẢNG
EXECUTE sp_grant_insert_table('tri123', 'qlbv_dba', 'nhanvien', TRUE);
-- TESTED


-- 22/ REVOKE INSERT TỪ MỘT USER/ROLE
EXECUTE sp_revoke_insert_table('tri123', 'qlbv_dba', 'nhanvien');
-- TESTED


-- 23/ GRANT DELETE LÊN MỘT TABLE
EXECUTE sp_grant_delete_table('tri123', 'qlbv_dba', 'nhanvien', TRUE);
-- TESTED


-- 24/ REVOKE DELETE ON TABLE
EXECUTE sp_revoke_delete_table('tri123', 'qlbv_dba', 'nhanvien');
-- TESTED 