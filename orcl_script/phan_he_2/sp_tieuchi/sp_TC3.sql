create or replace procedure sp_csyt_them_HSBA (
    p_mahsba NUMBER,
    p_mabn NUMBER,
    p_ngay DATE,
    p_chandoan NVARCHAR2,
    p_mabs NUMBER,
    p_makhoa NUMBER,
    p_macsyt NUMBER,
    p_ketluan NVARCHAR2)
is
    v_count integer;
begin
    select count(*) 
    into v_count
    from qlbv_dba.HSBA
    where mahsba = p_mahsba;
    if v_count = 0 then
        INSERT INTO QLBV_DBA.HSBA (mahsba, mabn, ngay, chandoan, mabs, makhoa, macsyt, ketluan) 
        VALUES (p_mahsba, p_mabn, p_ngay, p_chandoan, p_mabs, p_makhoa, p_macsyt, p_ketluan);
        commit;
    else
        dbms_output.put_line('Ma HSBA ton tai');
    end if;
end;
/
create or replace procedure sp_csyt_them_HSBA_DV (
    p_mahsba NUMBER,
    p_madv NUMBER,
    p_ngay DATE,
    p_maktv NUMBER,
    p_ketqua NVARCHAR2)
is
    v_count integer;
begin
    select count(*) 
    into v_count
    from qlbv_dba.HSBA
    where mahsba = p_mahsba;
    if v_count = 1 then
        INSERT INTO QLBV_DBA.HSBA_DV (mahsba, madv, ngay, maktv, ketqua) 
        VALUES (p_mahsba, p_madv, p_ngay, p_maktv, p_ketqua);
        commit;
    else
        dbms_output.put_line('Ma HSBA khong ton tai');
    end if;
end;
/
create or replace procedure sp_csyt_xoa_HSBA (
    p_mahsba NUMBER)
is
    v_count integer;
begin
    select count(*) 
    into v_count
    from qlbv_dba.HSBA
    where mahsba = p_mahsba;
    if v_count = 1 then
        delete qlbv_dba.HSBA where mahsba = p_mahsba;
        commit;
    else
        dbms_output.put_line('Ma HSBA khong ton tai');
    end if;
end;
/
create or replace procedure sp_csyt_xoa_HSBA_DV (
    p_mahsba NUMBER,
    p_madv NUMBER,
    p_ngay DATE)
is
    v_count integer;
begin
    select count(*) 
    into v_count
    from qlbv_dba.HSBA
    where mahsba = p_mahsba;
    if v_count = 1 then
        delete qlbv_dba.HSBA_DV 
        where mahsba = p_mahsba 
        and madv = p_madv 
        and ngay = p_ngay;
        commit;
    else
        dbms_output.put_line('Ma HSBA khong ton tai');
    end if;
end;
/
--grant select, delete on HSBA to CSYT;
--grant select, delete on HSBA_DV to CSYT;
grant execute on sp_csyt_them_HSBA to CSYT;
grant execute on sp_csyt_them_HSBA_DV to CSYT;
grant execute on sp_csyt_xoa_HSBA to CSYT;
grant execute on sp_csyt_xoa_HSBA_DV to CSYT;

--grant CSYT to un6;



