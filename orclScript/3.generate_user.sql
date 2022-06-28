SET SERVEROUTPUT ON;
--turn on DBMS_SQL.RETURN_RESULT
--login = SYSDBA
ALTER PLUGGABLE DATABASE qlbv_pdb OPEN;

--login = USER ADMIN of PDB
ALTER SESSION SET container = qlbv_pdb;
--ALTER USER qlbv_dba QUOTA UNLIMITED ON SYSTEM;
ALTER SESSION SET current_schema = qlbv_dba;

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
--exec SP_CREATE_ROLE('GIAMDOC');

exec SP_GRANT_ROLE_TO_USER('THANHTRA','tt');
exec SP_GRANT_ROLE_TO_USER('CSYT','nv');
exec SP_GRANT_ROLE_TO_USER('YSBS','bs');
exec SP_GRANT_ROLE_TO_USER('NGHIENCUU','nc');
exec SP_GRANT_ROLE_TO_USER('BENHNHAN','bn');
--exec SP_GRANT_ROLE_TO_USER('GIAMDOC','boss');

CREATE OR REPLACE PROCEDURE sp_login
AUTHID CURRENT_USER
IS 
    cs SYS_REFCURSOR;
BEGIN 
    OPEN cs FOR
    SELECT * FROM SESSION_ROLES;

    dbms_sql.return_result(cs);
END;
/
grant execute on sp_login to THANHTRA;
grant execute on sp_login to CSYT;
grant execute on sp_login to YSBS;
grant execute on sp_login to NGHIENCUU;
grant execute on sp_login to BENHNHAN;
--grant execute on sp_login to GIAMDOC;
--exec sp_login

CREATE OR REPLACE PROCEDURE sp_generate_user
AUTHID CURRENT_USER 
IS 
begin
    --tao user,gan role cho benh nhan
    for i in (select tenDangNhap from qlbv_dba.BENHNHAN)
    loop
        sp_create_user(i.tenDangNhap,'1');
        SP_GRANT_ROLE_TO_USER('BENHNHAN', i.tenDangNhap);
    end loop;
    --tao user,gan role cho nhan vien
    for i in (select tenDangNhap, vaitro from qlbv_dba.NHANVIEN)
    loop
        sp_create_user(i.tenDangNhap,'1');
        if i.vaitro = 'Thanh tra' then
            SP_GRANT_ROLE_TO_USER('THANHTRA', i.tenDangNhap);
        elsif i.vaitro = 'Cơ sở y tế' then
            SP_GRANT_ROLE_TO_USER('CSYT', i.tenDangNhap);
        elsif i.vaitro = 'Nghiên cứu' then
            SP_GRANT_ROLE_TO_USER('NGHIENCUU', i.tenDangNhap);
        else
            SP_GRANT_ROLE_TO_USER('YSBS', i.tenDangNhap);
        end if;
    end loop;
end;
/
exec sp_generate_user;

/* CHECK
 SELECT * FROM USER_SYS_PRIVS;
 SELECT * FROM USER_TAB_PRIVS;
 SELECT * FROM SESSION_ROLES;
 SELECT * FROM USER_ROLE_PRIVS;
 SELECT * FROM KHOA;
 INSERT INTO KHOA VALUES ('2','noi soi','');
SELECT* FROM DBA_SYS_PRIVS WHERE GRANTEE ='DBA' and privilege like 'EXECUTE%';
*/