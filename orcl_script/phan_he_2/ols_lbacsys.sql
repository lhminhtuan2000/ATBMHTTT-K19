BEGIN
    SA_SYSDBA.CREATE_POLICY (
        policy_name => 'TRUY_CAP_THONG_BAO',
        column_name => 'OLS_COLUMN'
    );
END;
/


BEGIN
    sa_components.create_level (
        policy_name => 'TRUY_CAP_THONG_BAO',
        long_name   => 'PUBLIC',
        short_name  => 'PUB',
        level_num   => 1000
    );
END;
/

BEGIN
    sa_components.create_level (
        policy_name => 'TRUY_CAP_THONG_BAO',
        long_name   => 'CONFIDENTIAL',
        short_name  => 'CONF',
        level_num   => 2000
    );
END;
/

BEGIN
    sa_components.create_level (
        policy_name => 'TRUY_CAP_THONG_BAO',
        long_name   => 'SENSITIVE',
        short_name  => 'SEN',
        level_num   => 3000
    );
END;
/

BEGIN
     sa_components.create_compartment (
        policy_name => 'TRUY_CAP_THONG_BAO',
        long_name =>'NOITRU',
        short_name => 'NOTR',
        comp_num => 1000
    );
END;
/

BEGIN
     sa_components.create_compartment (
        policy_name => 'TRUY_CAP_THONG_BAO',
        long_name =>'NGOAITRU',
        short_name => 'NGTR',
        comp_num => 2000
    );
END;
/

BEGIN
     sa_components.create_compartment (
        policy_name => 'TRUY_CAP_THONG_BAO',
        long_name =>'CHUYENSAU',
        short_name => 'CHSA',
        comp_num => 3000
    );
END;
/

BEGIN
     sa_components.create_compartment (
        policy_name => 'TRUY_CAP_THONG_BAO',
        long_name =>'TRUNGTAM',
        short_name => 'TRTA',
        comp_num => 4000
    );
END;
/

BEGIN
     sa_components.create_compartment (
        policy_name => 'TRUY_CAP_THONG_BAO',
        long_name =>'CANTRUNGTAM',
        short_name => 'CATRTA',
        comp_num => 5000
    );
END;
/

BEGIN
     sa_components.create_compartment (
        policy_name => 'TRUY_CAP_THONG_BAO',
        long_name =>'NGOAITHANH',
        short_name => 'NGTH',
        comp_num => 6000
    );
END;
/

--conn qlbv_dba
--create user GDSO identified by 1;
--grant select any table to GDSO;
--
---- level 2000 + comp 1000 & 6000
--grant select any table to GDCSYT216 identified by 1;
--
--grant select any table to GDCSYT224 identified by 1;
--grant select any table to GDCSYT234 identified by 1;
--grant select any table to GDCSYT214 identified by 1;
--grant select any table to GDCSYT215 identified by 1;
--grant select any table to GDCSYT226 identified by 1;
--grant connect to GDSO, GDCSYT216,GDCSYT224,GDCSYT234,GDCSYT214,GDCSYT215,GDCSYT226;


BEGIN
    sa_user_admin.set_user_labels (
        policy_name     => 'TRUY_CAP_THONG_BAO',
        user_name       => 'GDSO',
        max_read_label  => 'SEN:NOTR,NGTR,CHSA,TRTA,CATRTA,NGTH',
        min_write_label => 'PUB'
--       def_label       => 'PUB'
--        row_label       => 'SEN'
    );
END;
/

BEGIN
    sa_user_admin.set_user_labels (
        policy_name     => 'TRUY_CAP_THONG_BAO',
        user_name       => 'GDCSYT216',
        max_read_label  => 'CONF:NOTR,NGTH',
        min_write_label => 'PUB',
        row_label       => 'CONF:NOTR,NGTH'
    );
END;
/

BEGIN
    sa_user_admin.set_user_labels (
        policy_name     => 'TRUY_CAP_THONG_BAO',
        user_name       => 'GDCSYT224',
        max_read_label  => 'CONF:NGTR,TRTA',
        min_write_label => 'PUB',
        row_label       => 'CONF:NGTR,TRTA'
    );
END;
/

BEGIN
    sa_user_admin.set_user_labels (
        policy_name     => 'TRUY_CAP_THONG_BAO',
        user_name       => 'GDCSYT234',
        max_read_label  => 'CONF:CHSA,TRTA',
        min_write_label => 'PUB',
        row_label       => 'CONF:CHSA,TRTA'
    );
END;
/

BEGIN
    sa_user_admin.set_user_labels (
        policy_name     => 'TRUY_CAP_THONG_BAO',
        user_name       => 'GDCSYT214',
        max_read_label  => 'CONF:NOTR,TRTA',
        min_write_label => 'PUB',
        row_label       => 'CONF:NOTR,TRTA'
    );
END;
/

BEGIN
    sa_user_admin.set_user_labels (
        policy_name     => 'TRUY_CAP_THONG_BAO',
        user_name       => 'GDCSYT215',
        max_read_label  => 'CONF:NOTR,CATRTA',
        min_write_label => 'PUB',
        row_label       => 'CONF:NOTR,CATRTA'
    );
END;
/

BEGIN
    sa_user_admin.set_user_labels (
        policy_name     => 'TRUY_CAP_THONG_BAO',
        user_name       => 'GDCSYT226',
        max_read_label  => 'CONF:NGTR,NGTH',
        min_write_label => 'PUB',
        row_label       => 'CONF:NGTR,NGTH'
    );
END;
/

-- after create table QLBV_DBA.THONGBAO
BEGIN
    sa_policy_admin.apply_table_policy (
        policy_name =>'TRUY_CAP_THONG_BAO',
        schema_name => 'QLBV_DBA',
        table_name => 'THONGBAO',
        table_options => 'NO_CONTROL'
    );
END;
/

-- thực hiện update 
UPDATE QLBV_DBA.THONGBAO SET OLS_COLUMN = CHAR_TO_LABEL 
('TRUY_CAP_THONG_BAO', 'CONF:NOTR')
WHERE mathongbao = 1;

UPDATE QLBV_DBA.THONGBAO SET OLS_COLUMN = CHAR_TO_LABEL 
('TRUY_CAP_THONG_BAO', 'SEN')
WHERE mathongbao = 2;

UPDATE QLBV_DBA.THONGBAO SET OLS_COLUMN = CHAR_TO_LABEL 
('TRUY_CAP_THONG_BAO', 'CONF:NGTR,TRTA')
WHERE mathongbao = 3;

UPDATE QLBV_DBA.THONGBAO SET OLS_COLUMN = CHAR_TO_LABEL 
('TRUY_CAP_THONG_BAO', 'PUB')
WHERE mathongbao = 4;

UPDATE QLBV_DBA.THONGBAO SET OLS_COLUMN = CHAR_TO_LABEL 
('TRUY_CAP_THONG_BAO', 'PUB:CHSA,TRTA')
WHERE mathongbao = 5;


-- after update set ols_col on THONGBAO
BEGIN
    sa_policy_admin.remove_table_policy (
        policy_name     => 'TRUY_CAP_THONG_BAO',
        schema_name     => 'QLBV_DBA',
        table_name      => 'THONGBAO'
    );
END;
/
BEGIN
    sa_policy_admin.apply_table_policy (
        policy_name     => 'TRUY_CAP_THONG_BAO',
        schema_name     => 'QLBV_DBA',
        table_name      => 'THONGBAO',
        table_options   => 'READ_CONTROL'
    );
END;
/

 




