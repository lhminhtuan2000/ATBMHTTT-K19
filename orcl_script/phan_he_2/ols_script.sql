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

select label_TO_CHAR(OLS_COLUMN) from thongbao;