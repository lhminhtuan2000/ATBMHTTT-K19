SELECT
    SYS_CONTEXT('vaitro_ctx', 'vaitro') custnum
FROM
    DUAL;

SELECT
    SYS_CONTEXT('USERENV', 'SESSION_USER')
FROM
    DUAL;