--XOA CAU TRUC DU LIEU
/*

drop table qlbv_dba.HSBA CASCADE CONSTRAINTS;
drop table qlbv_dba.HSBA_DV CASCADE CONSTRAINTS;
drop table qlbv_dba.BENHNHAN CASCADE CONSTRAINTS;
drop table qlbv_dba.CSYT CASCADE CONSTRAINTS;
drop table qlbv_dba.NHANVIEN CASCADE CONSTRAINTS;
drop table qlbv_dba.DICHVU CASCADE CONSTRAINTS;
drop table qlbv_dba.KHOA CASCADE CONSTRAINTS;

*/
--chAy = user sysdba
CREATE PLUGGABLE DATABASE qlbv_pdb 
    ADMIN USER qlbv_dba IDENTIFIED BY 1 ROLES = ( dba )
    FILE_NAME_CONVERT = ( 
    'pdbseed', 
    'qlbv_pdb' );


ALTER PLUGGABLE DATABASE qlbv_pdb OPEN;
ALTER SESSION SET container = qlbv_pdb;
ALTER USER qlbv_dba QUOTA UNLIMITED ON SYSTEM;

--TAO BANG
create table qlbv_dba.HSBA (
    MAHSBA number(5),
    MABN number(5),
    NGAY date,
    CHANDOAN nvarchar2(100) not null,
    MABS number(3),
    MAKHOA number(2),
    MACSYT number(2),
    KETLUAN nvarchar2(100),
    
    constraint PK_HSBA primary key (MAHSBA)
);

create table qlbv_dba.HSBA_DV (
    MAHSBA number(5),
    MADV number(3),
    NGAY date,
    MAKTV number(3),
    KETQUA nvarchar2(100),
    
    constraint PK_HSBA_DV primary key (MAHSBA,MADV,NGAY)
);

create table qlbv_dba.BENHNHAN (
    MABN number(5),
    MACSYT number(2),
    TENBN nvarchar2(50),
    CMND varchar(12),
    NGAYSINH date,
    SONHA varchar(10),
    TENDUONG nvarchar2(50),
    QUANHUYEN nvarchar2(50),
    TINHTP nvarchar2(50),
    TIENSUBENH nvarchar2(100),
    TIENSUBENHGD nvarchar2(100),
    DIUNGTHUOC nvarchar2(100),
    
    constraint PK_BENHNHAN primary key (MABN)
);

create table qlbv_dba.CSYT (
    MACSYT number(2),
    TENCSYT nvarchar2(80),
    DCCSYT nvarchar2(100),
    SDTCSYT char(10),
    
    constraint PK_CSYT primary key (MACSYT)
);

create table qlbv_dba.NHANVIEN (
    MANV number(5),
    HOTEN nvarchar2(50),
    PHAI nvarchar2(5),
    NGAYSINH date,
    CMND varchar(12),
    QUEQUAN nvarchar2(50),
    SODT char(10),
    CSYT number(2),
    VAITRO nvarchar2(20),
    CHUYENKHOA nvarchar2(50),
    constraint PK_NHANVIEN primary key (MANV)
);

create table qlbv_dba.DICHVU (
    MADV number(3),
    TENDV nvarchar2(50),
    MOTA nvarchar2(100) DEFAULT '',
    GIA number(8),
    
    constraint PK_DICHVU primary key (MADV)
);

create table qlbv_dba.KHOA (
    MAKHOA number(2),
    TENKHOA nvarchar2(50),
    MOTA nvarchar2(100) DEFAULT '',
    
    constraint PK_KHOA primary key (MAKHOA)
);

--TAO KHOA NGOAI
alter table qlbv_dba.HSBA
    add constraint FK_HSBA_BENHNHAN 
    foreign key (MABN) references qlbv_dba.BENHNHAN (MABN);
alter table qlbv_dba.HSBA
    add constraint FK_HSBA_NHANVIEN 
    foreign key (MABS) references qlbv_dba.NHANVIEN (MANV);
alter table qlbv_dba.HSBA
    add constraint FK_HSBA_CSYT 
    foreign key (MACSYT) references qlbv_dba.CSYT (MACSYT);
alter table qlbv_dba.HSBA
    add constraint FK_HSBA_KHOA 
    foreign key (MAKHOA) references qlbv_dba.KHOA (MAKHOA);

alter table qlbv_dba.HSBA_DV
    add constraint FK_HSBA_DV_HSBA
    foreign key (MAHSBA) references qlbv_dba.HSBA (MAHSBA);
alter table qlbv_dba.HSBA_DV
    add constraint FK_HSBA_DV_DICHVU
    foreign key (MADV) references qlbv_dba.DICHVU (MADV);
