CREATE OR REPLACE PROCEDURE sp_themCSYT (
    p_macsyt NUMBER,
    p_tencsyt NVARCHAR2,
    p_dccsyt NVARCHAR2,
    p_sdtcsyt CHAR)
IS
    v_csyt_count INTEGER;
BEGIN
    SELECT count(*) 
    INTO v_csyt_count
    FROM qlbv_dba.CSYT
    WHERE macsyt = p_macsyt;
    IF v_csyt_count = 0 then
        INSERT INTO qlbv_dba.CSYT (macsyt, tencsyt, dccsyt, sdtcsyt) VALUES (p_macsyt, p_tencsyt, p_dccsyt, p_sdtcsyt);
        COMMIT;
    ELSE
        dbms_output.put_line('Ma CSYT ton tai');
    END IF;
END;
/
--exec sp_themCSYT(1, 'CSYT Tỉnh 10', 'Địa chỉ 1', '0955030054');
--exec sp_themCSYT(51, 'CSYT Tỉnh 51', 'Địa chỉ 51', '0955030051');
--SELECT * FROM CSYT;

create or replace procedure sp_capNhatCSYT (
    p_macsyt NUMBER,
    p_tencsyt NVARCHAR2,
    p_dccsyt NVARCHAR2,
    p_sdtcsyt CHAR)
is
    v_csyt_count integer;
BEGIN
    SELECT count(*) 
    INTO v_csyt_count
    FROM qlbv_dba.CSYT
    WHERE macsyt = p_macsyt;
    IF v_csyt_count = 1 then
        update qlbv_dba.CSYT 
        set tencsyt = p_tencsyt, 
            dccsyt = p_dccsyt, 
            sdtcsyt = p_sdtcsyt
        WHERE macsyt = p_macsyt;
        commit;
    else
        dbms_output.put_line('Ma CSYT khong ton tai');
    end IF;
end;
/
--exec sp_capNhatCSYT(1, 'CSYT Tỉnh 1', 'Địa chỉ 1', '0955030054');
--SELECT * FROM CSYT;

create or replace procedure sp_themNhanVien (
    p_manv NUMBER,
    p_hoten NVARCHAR2,
    p_phai NVARCHAR2,
    p_ngaysinh DATE,
    p_cmnd VARCHAR2,
    p_quequan NVARCHAR2,
    p_sodt CHAR,
    p_csyt NUMBER,
    p_vaitro NVARCHAR2,
    p_chuyenkhoa NUMBER,
    p_tenDangNhap VARCHAR2)
is
    v_nhanvien_count integer;
BEGIN
    SELECT count(*) 
    INTO v_nhanvien_count
    FROM qlbv_dba.NHANVIEN
    WHERE manv = p_manv or tenDangNhap = p_tenDangNhap;
    IF v_nhanvien_count = 0 then
        insert INTO qlbv_dba.NHANVIEN (manv, hoten, phai, ngaysinh, cmnd, quequan, sodt, csyt, vaitro, chuyenkhoa, tendangnhap) 
        values (p_manv, p_hoten, p_phai, p_ngaysinh, p_cmnd, p_quequan, p_sodt, p_csyt, p_vaitro, p_chuyenkhoa, p_tenDangNhap);
        commit;
    else
        dbms_output.put_line('Ma Nhan vien, ten dang nhap cua nhan vien ton tai');
    end IF;
end;
/
--exec sp_themNhanVien(3056, 'Huỳnh Anh Nga', 'Nam', TO_DATE('28/7/2021', 'DD/MM/YYYY'), '374814512231', 'Tinh 3', '0936728597', null, 'Thanh tra', null, 'UN13056');
--SELECT * FROM NhanVien WHERE manv = 3056;
