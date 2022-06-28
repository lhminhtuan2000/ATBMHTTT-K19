SELECT
    SYS_CONTEXT('vaitro_ctx', 'vaitro') custnum
FROM
    DUAL;




UPDATE qlbv_dba.v__hoa_nhanvien
SET hoten = 'hoe'
WHERE manv = 2;

SELECT * 

SELECT * FROM qlbv_dba.nhanvien;
SELECT manv FROM qlbv_dba.nhanvien where phai = 'nu';

 UPDATE AS SELECT  qlbv_dba.NHANVIEN
set CMND = 'nu'
where Phai = 'nu'
GRANT SELECT ON qlbv_dba.v__hoa_nhanvien TO TRI;
select null from dual;

GRANT SELECT ANY TABLE TO TRI123;


GRANT SELECT ON qlbv_dba.NHANVIEN TO TRI123;
REVOKE SELECT ON qlbv_dba.BENHNHAN FROM TRI123;