/*

*** XOA CAU TRUC DU LIEU

ALTER SESSION SET container = cdb$root;
ALTER PLUGGABLE DATABASE qlbv_pdb CLOSE IMMEDIATE;
DROP PLUGGABLE DATABASE qlbv_pdb INCLUDING DATAFILES;

*/

CREATE PLUGGABLE DATABASE qlbv_pdb                                                                                        
ADMIN USER qlbv_dba IDENTIFIED BY "1" ROLES = (dba) 
FILE_NAME_CONVERT = ('pdbseed', 'qlbv_pdb');

ALTER PLUGGABLE DATABASE qlbv_pdb OPEN;
ALTER SESSION SET container = qlbv_pdb;

ALTER USER qlbv_dba QUOTA UNLIMITED ON SYSTEM;

-- TAO BANG
CREATE TABLE qlbv_dba.HSBA (
    mahsba NUMBER,
    mabn NUMBER,
    ngay DATE,
    chandoan NVARCHAR2(100) NOT NULL,
    mabs NUMBER,
    makhoa NUMBER,
    macsyt NUMBER,
    ketluan NVARCHAR2(100),
    CONSTRAINT pk_hsba PRIMARY KEY (mahsba)
);

CREATE TABLE qlbv_dba.HSBA_DV (
    mahsba NUMBER,
    madv NUMBER,
    ngay DATE,
    maktv NUMBER,
    ketqua NVARCHAR2(100),
    CONSTRAINT pk_hsba_dv PRIMARY KEY (mahsba, madv, ngay)
);

CREATE TABLE qlbv_dba.BENHNHAN (
    mabn NUMBER,
    macsyt NUMBER,
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
    tenDangNhap VARCHAR2(50) NOT NULL,
    CONSTRAINT pk_benhnhan PRIMARY KEY (mabn),
    CONSTRAINT unique_benhnhan UNIQUE (tenDangNhap)
);

CREATE TABLE qlbv_dba.CSYT (
    macsyt NUMBER,
    tencsyt NVARCHAR2(80),
    dccsyt NVARCHAR2(100),
    sdtcsyt CHAR(10),
    CONSTRAINT pk_csyt PRIMARY KEY (macsyt)
);

CREATE TABLE qlbv_dba.NHANVIEN (
    manv NUMBER,
    hoten NVARCHAR2(50),
    phai NVARCHAR2(5),
    ngaysinh DATE,
    cmnd VARCHAR2(12),
    quequan NVARCHAR2(50),
    sodt CHAR(10),
    csyt NUMBER,
    vaitro NVARCHAR2(20),
    chuyenkhoa NUMBER,
    tenDangNhap VARCHAR2(50) NOT NULL,
    CONSTRAINT pk_nhanvien PRIMARY KEY (MANV),
    CONSTRAINT unique_nhanien UNIQUE (tenDangNhap)
);

CREATE TABLE qlbv_dba.DICHVU (
    madv NUMBER,
    tendv NVARCHAR2(100),
    mota NVARCHAR2(100) DEFAULT '',
    gia NUMBER,
    CONSTRAINT PK_DICHVU PRIMARY KEY (madv)
);

CREATE TABLE qlbv_dba.KHOA (
    makhoa NUMBER,
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

-- ENCRYPT (SYS)
ADMINISTER KEY MANAGEMENT SET KEYSTORE OPEN IDENTIFIED BY "1";
ADMINISTER KEY MANAGEMENT SET ENCRYPTION KEY IDENTIFIED BY "1" WITH BACKUP USING 'KEY_BACKUP';

ALTER TABLE QLBV_DBA.BENHNHAN MODIFY (cmnd ENCRYPT);
ALTER TABLE QLBV_DBA.BENHNHAN MODIFY (tiensubenh ENCRYPT);
ALTER TABLE QLBV_DBA.NHANVIEN MODIFY (cmnd ENCRYPT);
ALTER TABLE QLBV_DBA.HSBA MODIFY (CHANDOAN ENCRYPT);

