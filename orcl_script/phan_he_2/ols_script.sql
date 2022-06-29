--select value from V$OPTION where parameter = 'Oracle Label Security';

--conn sys/admin as sysdba;
--alter session set container = qlbv_pdb;
--EXEC LBACSYS.CONFIGURE_OLS;
--EXEC LBACSYS.OLS_ENFORCEMENT.ENABLE_OLS;
--ALTER USER lbacsys IDENTIFIED BY lbacsys ACCOUNT UNLOCK;

--conn qlbv_dba
create table THONGBAO (
    mathongbao number,
    noidung nvarchar2(200),
    ngaygio date,
    diadiem nvarchar2(100),
    constraint pk_ThongBao primary key (mathongbao)
);

-- thêm vài dữ liệu...

--
GRANT select, insert, update ON THONGBAO TO lbacsys;

--conn sys
--alter session set container = qlbv_pdb;
--GRANT EXEMPT ACCESS POLICY TO qlbv_dba;

--conn qlbv_dba
--insert into NHANVIEN (manv, vaitro, tendangnhap) values (5000, 'Giám đốc sở', 'GDSO');
--insert into NHANVIEN (manv, vaitro, tendangnhap) values (5001, 'Giám đốc sở', 'GDCSYT216');
--insert into NHANVIEN (manv, vaitro, tendangnhap) values (5002, 'Giám đốc sở', 'GDCSYT224');
--insert into NHANVIEN (manv, vaitro, tendangnhap) values (5003, 'Giám đốc sở', 'GDCSYT234');
--insert into NHANVIEN (manv, vaitro, tendangnhap) values (5004, 'Giám đốc sở', 'GDCSYT214');
--insert into NHANVIEN (manv, vaitro, tendangnhap) values (5005, 'Giám đốc sở', 'GDCSYT215');
--insert into NHANVIEN (manv, vaitro, tendangnhap) values (5006, 'Giám đốc sở', 'GDCSYT226');



--select * from QLBV_DBA.THONGBAO;
--
--select label_TO_CHAR(OLS_COLUMN) from QLBV_DBA.thongbao;
--
--select * from dba_sa_users;