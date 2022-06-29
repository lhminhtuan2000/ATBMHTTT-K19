create or replace procedure sp_ybs_xemHSBA (
    p_mahsba number)
is
    c1 SYS_REFCURSOR;
begin
    OPEN c1 for
    select * from qlbv_dba.HSBA where mahsba = p_mahsba;
           
    -- SOS
    DBMS_SQL.RETURN_RESULT(c1);
end;
/
create or replace procedure sp_ybs_xemHSBA_DV (
    p_mahsba number)
is
    c1 SYS_REFCURSOR;
begin
    OPEN c1 for
    select mahsba, madv, ketqua 
    from qlbv_dba.HSBA_DV 
    where mahsba = p_mahsba;
           
    -- SOS
    DBMS_SQL.RETURN_RESULT(c1);
end;
/
create or replace procedure sp_ybs_xemThongTinBenhNhan (
    p_key varchar2)
is
    c1 SYS_REFCURSOR;
begin
    OPEN c1 for
    select * 
    from qlbv_dba.BENHNHAN 
    where mabn = cast( p_key as number) 
    or cmnd = p_key;
           
    -- SOS
    DBMS_SQL.RETURN_RESULT(c1);
end;
/

--grant select on HSBA to YSBS;
--grant select on HSBA_DV to YSBS;
--grant select on BENHNHAN to YSBS;
grant execute on sp_ybs_xemHSBA to YSBS;
grant execute on sp_ybs_xemHSBA_DV to YSBS;
grant execute on sp_ybs_xemThongTinBenhNhan to YSBS;

--grant YSBS to UN2556;

--exec qlbv_dba.sp_ybs_xemHSBA(1);
--exec qlbv_dba.sp_ybs_xemHSBA_DV(1);
--exec qlbv_dba.sp_ybs_xemThongTinBenhNhan('719840750896');



