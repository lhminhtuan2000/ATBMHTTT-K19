
ALTER SESSION SET CONTAINER = qlbv_pdb;
ALTER SESSION SET CONTAINER = CDB$ROOT;

select * from dba_sys_privs where COMMON = 'NO';
SELECT * FROM USER_TAB_PRIVS;

SELECT * FROM SYS.v_pdb_dba_users 