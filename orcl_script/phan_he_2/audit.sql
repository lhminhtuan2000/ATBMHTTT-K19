conn qlbv_dba/1
CREATE AUDIT POLICY AUD_HSBA_INSERT ACTIONS INSERT ON qlbv_dba.hsba, 
CREATE AUDIT POLICY AUD_HSBA_DELETE ACTIONS DELETE ON qlbv_dba.hsba, 
CREATE AUDIT POLICY AUD_HSBADV_INSERT ACTIONS INSERT ON qlbv_dba.hsba_dv, 
CREATE AUDIT POLICY AUD_HSBADV_DELETE ACTIONS DELETE ON qlbv_dba.hsba_dv;
CREATE AUDIT POLICY AUD_HSBADV_UPDATE ACTIONS UPDATE ON qlbv_dba.hsba_dv;
AUDIT POLICY AUD_HSBA_INSERT;
AUDIT POLICY AUD_HSBA_DELETE;
AUDIT POLICY AUD_HSBADV_INSERT;
AUDIT POLICY AUD_HSBADV_DELETE;
AUDIT POLICY AUD_HSBADV_UPDATE;

select * from audit_unified_policies where policy_name = upper('aud_HSBADV_update');

grant insert, delete on qlbv_dba.HSBA to CSYT;
grant insert, delete on qlbv_dba.HSBA_DV to CSYT;

AUDIT ROLE WHENEVER SUCCESSFUL;



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

--noaudit policy aud_select_benhnhan;
--drop audit policy aud_select_benhnhan;

begin
    dbms_fga.add_policy (
        object_schema   => 'qlbv_dba',
        object_name     => 'HSBA',
        policy_name     => 'fga_update_HSBA',
        audit_column    => 'mabn, chandoan, mabs, ketluan',
        statement_types => 'update'
    );
end;


--select * from DBA_AUDIT_POLICIES where policy_name = upper('fga_update_HSBA');
--
--select * from HSBA where mahsba = 1;
--update HSBA set chandoan = 'Đặt sonde dạ dàyyy' where mahsba = 1;
--
--select * from unified_audit_trail where fga_policy_name = upper('fga_update_HSBA');


