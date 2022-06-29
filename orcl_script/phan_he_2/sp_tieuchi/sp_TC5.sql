create or replace procedure sp_nc_xemHSBA (
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
create or replace procedure sp_nc_xemHSBA_DV (
    p_mahsba number)
is
    c1 SYS_REFCURSOR;
begin
    OPEN c1 for
    select * from qlbv_dba.HSBA_DV where mahsba = p_mahsba;
           
    -- SOS
    DBMS_SQL.RETURN_RESULT(c1);
end;

grant select on HSBA to NGHIENCUU;
grant select on HSBA_DV to NGHIENCUU;
grant execute on sp_nc_xemHSBA to NGHIENCUU;
grant execute on sp_nc_xemHSBA_DV to NGHIENCUU;
grant NGHIENCUU to un56;

--exec qlbv_dba.sp_nc_xemHSBA(1);
--exec qlbv_dba.sp_nc_xemHSBA_DV(1);



