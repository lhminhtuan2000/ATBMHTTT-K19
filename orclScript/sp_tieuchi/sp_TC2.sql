grant select on NHANVIEN to THANHTRA;
grant select on BENHNHAN to THANHTRA;
grant select on HSBA to THANHTRA;
grant select on HSBA_DV to THANHTRA;
grant select on CSYT to THANHTRA;

--select * from qlbv_dba.NHANVIEN;
--select * from qlbv_dba.BENHNHAN;
--select * from qlbv_dba.HSBA;
--select * from qlbv_dba.HSBA_DV;
--select * from qlbv_dba.CSYT;

create or replace procedure sp_xemThongTinQuanHe (
    tenBang varchar2)
is
    c1 SYS_REFCURSOR;
begin
    if tenBang = 'BENHNHAN' then
        OPEN c1 for
            select * from qlbv_dba.BENHNHAN;
    elsif tenBang = 'NHANVIEN' then
        OPEN c1 for
            select * from qlbv_dba.NHANVIEN;
    elsif tenBang = 'HSBA' then
        OPEN c1 for
            select * from qlbv_dba.HSBA;
    elsif tenBang = 'HSBA_DV' then
        OPEN c1 for
            select * from qlbv_dba.HSBA_DV;
    elsif tenBang = 'CSYT' then
        OPEN c1 for
            select * from qlbv_dba.CSYT;
    end if;
    DBMS_SQL.RETURN_RESULT(c1);
end;
/

grant execute on sp_xemThongTinQuanHe to THANHTRA;

--exec qlbv_dba.sp_xemThongTinQuanHe('NHANVIEN');
--exec qlbv_dba.sp_xemThongTinQuanHe('BENHNHAN');
--exec qlbv_dba.sp_xemThongTinQuanHe('HSBA');
--exec qlbv_dba.sp_xemThongTinQuanHe('HSBA_DV');
--exec qlbv_dba.sp_xemThongTinQuanHe('CSYT');

