create or replace procedure sp_nc_xemhsba (
    p_mahsba number)
is
    c1 sys_refcursor;
begin
    open c1 for
    select * from qlbv_dba.hsba where mahsba = p_mahsba;
           
    -- SOS
    dbms_sql.return_result(c1);
end;
/
create or replace procedure sp_nc_xemhsba_dv (
    p_mahsba number)
is
    c1 sys_refcursor;
begin
    open c1 for
    select * from qlbv_dba.hsba_dv where mahsba = p_mahsba;
           
    -- SOS
    dbms_sql.return_result(c1);
end;
/
--grant select on HSBA to NGHIENCUU;
--grant select on HSBA_DV to NGHIENCUU;
grant execute on sp_nc_xemhsba to nghiencuu;
grant execute on sp_nc_xemhsba_dv to nghiencuu;
--grant NGHIENCUU to un56;

--exec qlbv_dba.sp_nc_xemHSBA(1);
--exec qlbv_dba.sp_nc_xemHSBA_DV(1);



