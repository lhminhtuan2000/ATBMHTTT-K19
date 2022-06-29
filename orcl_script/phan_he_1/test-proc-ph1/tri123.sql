SELECT * FROM QLBV_DBA.V__TRI123_NHANVIEN;

UPDATE QLBV_DBA.V__TRI123_NHANVIEN
SET cmnd = '3000'
WHERE MANV = 4;

INSERT INTO qlbv_dba.nhanvien VALUES ('5', 'tri', 'nu', TO_DATE('31-12-2007','DD-MM-YYYY'), '020', 'qu', '234', '4', 'Bac si','1');
INSERT INTO qlbv_dba.nhanvien VALUES ('6', 'tri', 'nu', TO_DATE('31-12-2007','DD-MM-YYYY'), '020', 'qu', '234', '4', 'Bac si','1');
INSERT INTO qlbv_dba.nhanvien VALUES ('7', 'tri', 'nu', TO_DATE('31-12-2007','DD-MM-YYYY'), '020', 'qu', '234', '4', 'Bac si','1');
INSERT INTO qlbv_dba.nhanvien VALUES ('8', 'tri', 'nu', TO_DATE('31-12-2007','DD-MM-YYYY'), '020', 'qu', '234', '4', 'Bac si','1');
INSERT INTO qlbv_dba.nhanvien VALUES ('9', 'tri', 'nu', TO_DATE('31-12-2007','DD-MM-YYYY'), '020', 'qu', '234', '4', 'Bac si','1');


DELETE FROM QLBV_DBA.V__TRI123_NHANVIEN WHERE manv = '7';