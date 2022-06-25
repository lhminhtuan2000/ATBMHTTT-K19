/*

*** XOA CAU TRUC DU LIEU

ALTER SESSION SET container = cdb$root;
ALTER PLUGGABLE DATABASE qlbv_pdb CLOSE IMMEDIATE;
DROP PLUGGABLE DATABASE qlbv_pdb INCLUDING DATAFILES;

*/

CREATE PLUGGABLE DATABASE qlbv_pdb 
ADMIN USER qlbv_dba IDENTIFIED BY 1 ROLES = (dba) 
FILE_NAME_CONVERT = ('pdbseed', 'qlbv_pdb');

ALTER PLUGGABLE DATABASE qlbv_pdb OPEN;
ALTER SESSION SET container = qlbv_pdb;

ALTER USER qlbv_dba QUOTA UNLIMITED ON SYSTEM;

-- TAO BANG
CREATE TABLE qlbv_dba.HSBA (
    mahsba NUMBER(5),
    mabn NUMBER(5),
    ngay DATE,
    chandoan NVARCHAR2(100) NOT NULL,
    mabs NUMBER(3),
    makhoa NUMBER(2),
    macsyt NUMBER(2),
    ketluan NVARCHAR2(100),
    CONSTRAINT pk_hsba PRIMARY KEY (mahsba)
);

CREATE TABLE qlbv_dba.HSBA_DV (
    mahsba NUMBER(5),
    madv NUMBER(3),
    ngay DATE,
    maktv NUMBER(3),
    ketqua NVARCHAR2(100),
    CONSTRAINT pk_hsba_dv PRIMARY KEY (mahsba, madv, ngay)
);

CREATE TABLE qlbv_dba.BENHNHAN (
    mabn NUMBER(5),
    macsyt NUMBER(2),
    tenbn NVARCHAR2(50),
    cmnd VARCHAR(12),
    ngaysinh DATE,
    sonha VARCHAR(10),
    tenduong NVARCHAR2(50),
    quanhuyen NVARCHAR2(50),
    tinhtp NVARCHAR2(50),
    tiensubenh NVARCHAR2(100),
    tiensubenhgd NVARCHAR2(100),
    diungthuoc NVARCHAR2(100),
    CONSTRAINT pk_benhnhan PRIMARY KEY (mabn)
);

CREATE TABLE qlbv_dba.CSYT (
    macsyt number(2),
    tencsyt NVARCHAR2(80),
    dccsyt NVARCHAR2(100),
    sdtcsyt CHAR(10),
    CONSTRAINT pk_csyt PRIMARY KEY (macsyt)
);

CREATE TABLE qlbv_dba.NHANVIEN (
    manv number(5),
    hoten NVARCHAR2(50),
    phai NVARCHAR2(5),
    ngaysinh DATE,
    cmnd VARCHAR2(12),
    quequan NVARCHAR2(50),
    sodt CHAR(10),
    csyt NUMBER(2),
    vaitro NVARCHAR2(20),
    chuyenkhoa NVARCHAR2(50),
    CONSTRAINT pk_nhanvien PRIMARY KEY (MANV)
);

CREATE TABLE qlbv_dba.DICHVU (
    madv number(3),
    tendv NVARCHAR2(50),
    mota NVARCHAR2(100) DEFAULT '',
    gia number(8),
    CONSTRAINT PK_DICHVU PRIMARY KEY (madv)
);

CREATE TABLE qlbv_dba.KHOA (
    makhoa number(2),
    tenkhoa NVARCHAR2(50),
    mota NVARCHAR2(100) DEFAULT '',
    CONSTRAINT pk_khoa PRIMARY KEY (makhoa)
);

--TAO KHOA NGOAI
ALTER TABLE qlbv_dba.HSBA ADD
    CONSTRAINT fk_hsba_benhnhan FOREIGN KEY (mabn) REFERENCES qlbv_dba.BENHNHAN (mabn);

ALTER TABLE qlbv_dba.HSBA ADD
    CONSTRAINT fk_hsba_nhanvien FOREIGN KEY (mabs) REFERENCES qlbv_dba.NHANVIEN (manv);

ALTER TABLE qlbv_dba.HSBA ADD
    CONSTRAINT fk_hsba_csyt FOREIGN KEY (macsyt) REFERENCES qlbv_dba.CSYT (macsyt);

ALTER TABLE qlbv_dba.HSBA ADD
    CONSTRAINT fk_hsba_khoa FOREIGN KEY (makhoa) REFERENCES qlbv_dba.KHOA (makhoa);

ALTER TABLE qlbv_dba.HSBA_DV ADD
    CONSTRAINT fk_hsba_dv_hsba FOREIGN KEY (mahsba) REFERENCES qlbv_dba.HSBA (mahsba);

ALTER TABLE qlbv_dba.HSBA_DV ADD
    CONSTRAINT fk_hsba_dv_dichvu FOREIGN KEY (madv) REFERENCES qlbv_dba.DICHVU (madv);