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
CREATE PLUGGABLE DATABASE qlbv_pdb ADMIN USER qlbv_dba IDENTIFIED BY 1 ROLES = (dba) FILE_NAME_CONVERT = ('pdbseed', 'qlbv_pdb');

ALTER PLUGGABLE DATABASE qlbv_pdb OPEN;

ALTER SESSION
SET
    container = qlbv_pdb;

ALTER USER qlbv_dba QUOTA UNLIMITED ON SYSTEM;

--TAO BANG
CREATE TABLE qlbv_dba.HSBA (
    MAHSBA number(5),
    MABN number(5),
    NGAY date,
    CHANDOAN nvarchar2(100) NOT NULL,
    MABS number(3),
    MAKHOA number(2),
    MACSYT number(2),
    KETLUAN nvarchar2(100),
    CONSTRAINT PK_HSBA PRIMARY KEY (MAHSBA)
);

CREATE TABLE qlbv_dba.HSBA_DV (
    MAHSBA number(5),
    MADV number(3),
    NGAY date,
    MAKTV number(3),
    KETQUA nvarchar2(100),
    CONSTRAINT PK_HSBA_DV PRIMARY KEY (MAHSBA, MADV, NGAY)
);

CREATE TABLE qlbv_dba.BENHNHAN (
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
    CONSTRAINT PK_BENHNHAN PRIMARY KEY (MABN)
);

CREATE TABLE qlbv_dba.CSYT (
    MACSYT number(2),
    TENCSYT nvarchar2(80),
    DCCSYT nvarchar2(100),
    SDTCSYT char(10),
    CONSTRAINT PK_CSYT PRIMARY KEY (MACSYT)
);

CREATE TABLE qlbv_dba.NHANVIEN (
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
    CONSTRAINT PK_NHANVIEN PRIMARY KEY (MANV)
);

CREATE TABLE qlbv_dba.DICHVU (
    MADV number(3),
    TENDV nvarchar2(50),
    MOTA nvarchar2(100) DEFAULT '',
    GIA number(8),
    CONSTRAINT PK_DICHVU PRIMARY KEY (MADV)
);

CREATE TABLE qlbv_dba.KHOA (
    MAKHOA number(2),
    TENKHOA nvarchar2(50),
    MOTA nvarchar2(100) DEFAULT '',
    CONSTRAINT PK_KHOA PRIMARY KEY (MAKHOA)
);

--TAO KHOA NGOAI
ALTER TABLE
    qlbv_dba.HSBA
ADD
    CONSTRAINT FK_HSBA_BENHNHAN FOREIGN KEY (MABN) REFERENCES qlbv_dba.BENHNHAN (MABN);

ALTER TABLE
    qlbv_dba.HSBA
ADD
    CONSTRAINT FK_HSBA_NHANVIEN FOREIGN KEY (MABS) REFERENCES qlbv_dba.NHANVIEN (MANV);

ALTER TABLE
    qlbv_dba.HSBA
ADD
    CONSTRAINT FK_HSBA_CSYT FOREIGN KEY (MACSYT) REFERENCES qlbv_dba.CSYT (MACSYT);

ALTER TABLE
    qlbv_dba.HSBA
ADD
    CONSTRAINT FK_HSBA_KHOA FOREIGN KEY (MAKHOA) REFERENCES qlbv_dba.KHOA (MAKHOA);

ALTER TABLE
    qlbv_dba.HSBA_DV
ADD
    CONSTRAINT FK_HSBA_DV_HSBA FOREIGN KEY (MAHSBA) REFERENCES qlbv_dba.HSBA (MAHSBA);

ALTER TABLE
    qlbv_dba.HSBA_DV
ADD
    CONSTRAINT FK_HSBA_DV_DICHVU FOREIGN KEY (MADV) REFERENCES qlbv_dba.DICHVU (MADV);