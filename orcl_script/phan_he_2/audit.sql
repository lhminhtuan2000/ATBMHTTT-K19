conn qlbv_dba/1
create audit policy aud_HSBA_HSBADV_I_D actions 
insert on qlbv_dba.HSBA, 
delete on qlbv_dba.HSBA, 
insert on qlbv_dba.HSBA_DV, 
delete on qlbv_dba.HSBA_DV;
audit policy aud_HSBA_HSBADV_I_D;

select * from audit_unified_policies where policy_name = upper('aud_HSBA_HSBADV_I_D');

grant insert, delete on qlbv_dba.HSBA to CSYT;
grant insert, delete on qlbv_dba.HSBA_DV to CSYT;

-- TEST
--grant CSYT to un50;
--
--conn un50/1
--insert into qlbv_dba.HSBA values (501, 5574, TO_DATE('25/10/2020', 'DD/MM/YYYY'), 'Đặt sonde dạ dày', 2762, 10, 14,'Đặt sonde dạ dày');
--insert into qlbv_dba.HSBA_DV values (501, 3, TO_DATE('25/7/2020', 'DD/MM/YYYY'), 2645, 'Không thành công');
--conn un50/1
--delete qlbv_dba.HSBA_DV where mahsba = 501;
--delete qlbv_dba.HSBA where mahsba = 501;
--
--conn qlbv_dba/1
--select * from unified_audit_trail where unified_audit_policies = upper('aud_HSBA_HSBADV_I_D');

--noaudit policy aud_HSBA_HSBADV_I_D;
--drop audit policy aud_HSBA_HSBADV_I_D;

