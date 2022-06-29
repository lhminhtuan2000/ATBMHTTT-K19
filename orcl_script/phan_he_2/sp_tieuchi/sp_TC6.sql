create or replace procedure sp_xemThongTinCaNhan
authid current_user
IS 
    c1 SYS_REFCURSOR;
    v_role varchar(20);
BEGIN 
    SELECT ROLE into v_role FROM SESSION_ROLES;
    if v_role = 'BENHNHAN' then
        OPEN c1 for
        select * from qlbv_dba.BENHNHAN;
    else 
        OPEN c1 for
        select * from qlbv_dba.NHANVIEN;
    end if;
    -- SOS
    DBMS_SQL.RETURN_RESULT(c1);
END;
/
--exec sp_xemThongTinCaNhan;
--exec qlbv_dba.sp_xemThongTinCaNhan;


create or replace procedure sp_capNhatTTBenhNhan (
    p_macsyt NUMBER,
    p_tenbn NVARCHAR2,
    p_cmnd VARCHAR,
    p_ngaysinh DATE,
    p_sonha VARCHAR,
    p_tenduong NVARCHAR2,
    p_quanhuyen NVARCHAR2,
    p_tinhtp NVARCHAR2,
    p_tiensubenh NVARCHAR2,
    p_tiensubenhgd NVARCHAR2,
    p_diungthuoc NVARCHAR2)
IS 
BEGIN 
    update qlbv_dba.BENHNHAN
    set macsyt = p_macsyt,
        tenbn = p_tenbn,
        cmnd = p_cmnd,
        ngaysinh = p_ngaysinh,
        sonha = p_sonha,
        tenduong = p_tenduong,
        quanhuyen = p_quanhuyen,
        tinhtp = p_tinhtp,
        tiensubenh = p_tiensubenh,
        tiensubenhgd = p_tiensubenhgd,
        diungthuoc = p_diungthuoc;
END;
/
--exec qlbv_dba.sp_capNhatTTBenhNhan(23, 'Lê Lộc Lộc', '653892793230', TO_DATE('7/10/2018', 'DD/MM/YYYY'), 'Số 437', 'Đường số 286', 'Quận 7', 'Tỉnh/TP 6', 'A', 'B', 'C');
--select * from qlbv_dba.benhnhan where mabn = 6945;


create or replace procedure sp_capNhatTTNhanVien (
    p_hoten NVARCHAR2,
    p_phai NVARCHAR2,
    p_ngaysinh DATE,
    p_cmnd VARCHAR2,
    p_quequan NVARCHAR2,
    p_sodt CHAR,
    p_csyt NUMBER,
    p_vaitro NVARCHAR2,
    p_chuyenkhoa NUMBER)
IS 
BEGIN 
    update qlbv_dba.NHANVIEN
    set hoten = p_hoten,
        phai = p_phai,
        ngaysinh = p_ngaysinh,
        cmnd = p_cmnd,
        quequan = p_quequan,
        sodt = p_sodt,
        csyt = p_csyt,
        vaitro = p_vaitro,
        chuyenkhoa = p_chuyenkhoa;
END;
/
--exec qlbv_dba.sp_capNhatTTNhanVien('Huỳnh Anh Anh', 'Nam', TO_DATE('28/7/2021', 'DD/MM/YYYY'), '374814512231', 'Tinh 3', '0936728597', null, 'Thanh tra', null);
--select * from qlbv_dba.NHANVIEN where manv = 1;

grant select, update on BENHNHAN to BENHNHAN;
grant execute on sp_xemThongTinCaNhan to BENHNHAN;
grant execute on sp_capNhatTTBenhNhan to BENHNHAN;
grant BENHNHAN to un10000;

grant select, update on NHANVIEN to THANHTRA;
grant execute on sp_xemThongTinCaNhan to THANHTRA;
grant execute on sp_capNhatTTNhanVien to THANHTRA;
grant THANHTRA to un1;


--SELECT * FROM USER_SYS_PRIVS;
--SELECT * FROM USER_TAB_PRIVS;
--SELECT * FROM SESSION_ROLES;
--SELECT * FROM USER_ROLE_PRIVS;

select * from qlbv_dba.BenhNhan;




