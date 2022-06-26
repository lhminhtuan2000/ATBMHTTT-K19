
SELECT *
FROM role_tab_privs
WHERE ROLE ='TEST_ROLE'
-- TEST PROC
-- 1/ liệt kê tất cả các user đang open
EXEC qlbv_dba.sp_list_all_user;

-- 2/ show quyền của user
EXEC sp_show_user_sys_privs('TRI123');

-- 3/ Show object privileges
EXEC sp_show_user_obj_privs('QLBV_DBA');
EXEC sp_show_user_obj_privs('TRI123');

-- 4/ Show role của hệ thống
CREATE ROLE test_role;
EXEC sp_show_roles;

-- 5/ Xem system privs của role
GRANT CREATE SESSION TO test_role;
EXEC sp_role_sys_privs('test_role');

-- 6/ Xem object privs của role
GRANT SELECT ON BENHNHAN TO test_role;
EXEC sp_role_obj_privs('test_role');

-- 7/ tạo một user
EXEC qlbv_dba.sp_create_user('tri123', 1);

-- 8/ xoá một user
EXEC sp_delete_user('tri123');

-- 9/ đổi mật khẩu (hiệu chỉnh user)
EXEC qlbv_dba.sp_create_user('tri123', 1);
EXEC sp_change_user_password('tri123', '2');

-- 10/ lock một user (hiệu chỉnh user) //prevent login to database
EXEC sp_lock_user('tri123');

-- 10+/ (proc ngoài lê) unlock một user 
EXEC sp_unlock_user('tri123');

-- 11/ tạo một role
EXEC sp_create_role ('super_role');

-- 12/ xoá role
EXECUTE sp_delete_role('super_role');

select * from dba_users where COMMON = 'NO';