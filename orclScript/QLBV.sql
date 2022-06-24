--XÓA CẤU TRÚC DỮ LIỆU
/*
drop table HSBA CASCADE CONSTRAINTS;
drop table HSBA_DV CASCADE CONSTRAINTS;
drop table BỆNHNHÂN CASCADE CONSTRAINTS;
drop table CSYT CASCADE CONSTRAINTS;
drop table NHÂNVIÊN CASCADE CONSTRAINTS;
drop table DỊCHVỤ CASCADE CONSTRAINTS;
drop table KHOA CASCADE CONSTRAINTS;

DROP PROCEDURE sp_createPDBfromPDPseed;
*/
--chạy = user sysdba
create or replace procedure sp_createPDBfromPDPseed
	(pdb_name varchar2,
    username varchar2,
    password varchar2,
    roles varchar2)
is
    pdbseed_path varchar2(999);
    pdb_path varchar2(999);
begin
    select name
    into pdbseed_path
    from v$tempfile
    where name like '%PDBSEED%';
    pdbseed_path := SUBSTR(pdbseed_path,
                            0,
                            INSTR(pdbseed_path, '\', -1));
    pdbseed_path := '''' || pdbseed_path || '''';
    pdb_path := pdbseed_path;
    pdb_path := REPLACE(pdb_path, 'PDBSEED', pdb_name );
    execute immediate 'CREATE PLUGGABLE DATABASE ' || pdb_name || 
                        ' ADMIN USER ' || username || 
                        ' IDENTIFIED BY ' || password || 
                        ' ROLES = (' || roles || ')' ||
                        ' FILE_NAME_CONVERT = (' || pdbseed_path ||
                        ',' || pdb_path || ')';
end;
/
exec sp_createPDBfromPDPseed('pdb1','pdb1dba','1','dba');

--chạy = user pdb1dba
ALTER PLUGGABLE DATABASE pdb1 OPEN;
ALTER SESSION SET container = pdb1;
ALTER USER pdb1dba QUOTA UNLIMITED ON SYSTEM;
ALTER SESSION SET current_schema = pdb1dba;

--TẠO BẢNG
create table HSBA (
    MÃHSBA number(5),
    MÃBN number(5),
    NGÀY date,
    CHẨNĐOÁN nvarchar2(100) not null,
    MÃBS number(3),
    MÃKHOA number(2),
    MÃCSYT number(2),
    KẾTLUẬN nvarchar2(100),
    
    constraint PK_HSBA primary key (MÃHSBA)
);

create table HSBA_DV (
    MÃHSBA number(5),
    MÃDV number(3),
    NGÀY date,
    MÃKTV number(3),
    KẾTQUẢ nvarchar2(100),
    
    constraint PK_HSBA_DV primary key (MÃHSBA,MÃDV,NGÀY)
);

create table BỆNHNHÂN (
    MÃBN number(5),
    MÃCSYT number(2),
    TÊNBN nvarchar2(50),
    CMND varchar(12),
    NGÀYSINH date,
    SỐNHÀ varchar(10),
    TÊNĐƯỜNG nvarchar2(50),
    QUẬNHUYỆN nvarchar2(50),
    TỈNHTP nvarchar2(50),
    TIỀNSỬBỆNH nvarchar2(100),
    TIỀNSỬBỆNHGĐ nvarchar2(100),
    DỊỨNGTHUỐC nvarchar2(100),
    
    constraint PK_BỆNHNHÂN primary key (MÃBN)
);

create table CSYT (
    MÃCSYT number(2),
    TÊNCSYT nvarchar2(80),
    ĐCCSYT nvarchar2(100),
    SĐTCSYT char(10),
    
    constraint PK_CSYT primary key (MÃCSYT)
);

create table NHÂNVIÊN (
    MÃNV number(5),
    HỌTÊN nvarchar2(50),
    PHÁI nvarchar2(5),
    NGÀYSINH date,
    CMND varchar(12),
    QUÊQUÁN nvarchar2(50),
    SỐĐT char(10),
    CSYT number(2),
    VAITRÒ nvarchar2(20),
    CHUYÊNKHOA nvarchar2(50),
    constraint PK_NHÂNVIÊN primary key (MÃNV)
);

create table DỊCHVỤ (
    MÃDV number(3),
    TÊNDV nvarchar2(50),
    MÔTẢ nvarchar2(100) DEFAULT '',
    GIÁ number(8),
    
    constraint PK_DỊCHVỤ primary key (MÃDV)
);

create table KHOA (
    MÃKHOA number(2),
    TÊNKHOA nvarchar2(50),
    MÔTẢ nvarchar2(100) DEFAULT '',
    
    constraint PK_KHOA primary key (MÃKHOA)
);

--TẠO KHOÁ NGOẠI
alter table HSBA
    add constraint FK_HSBA_BỆNHNHÂN 
    foreign key (MÃBN) references BỆNHNHÂN (MÃBN);
alter table HSBA
    add constraint FK_HSBA_NHÂNVIÊN 
    foreign key (MÃBS) references NHÂNVIÊN (MÃNV);
alter table HSBA
    add constraint FK_HSBA_CSYT 
    foreign key (MÃCSYT) references CSYT (MÃCSYT);
alter table HSBA
    add constraint FK_HSBA_KHOA 
    foreign key (MÃKHOA) references KHOA (MÃKHOA);

alter table HSBA_DV
    add constraint FK_HSBA_DV_HSBA
    foreign key (MÃHSBA) references HSBA (MÃHSBA);
alter table HSBA_DV
    add constraint FK_HSBA_DV_DỊCHVỤ
    foreign key (MÃDV) references DỊCHVỤ (MÃDV);
/*
 --NHẬP DỮ LIỆU
alter session set NLS_DATE_FORMAT = 'dd-mm-yyyy';

*/