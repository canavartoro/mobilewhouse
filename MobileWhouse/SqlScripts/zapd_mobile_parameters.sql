CREATE SEQUENCE "uyumsoft"."zapd_mobile_parameters_id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

SELECT setval('"uyumsoft"."zapd_mobile_parameters_id_seq"', 1, true);

ALTER SEQUENCE "uyumsoft"."zapd_mobile_parameters_id_seq" OWNER TO "uyum";

CREATE TABLE "uyumsoft"."zapd_mobile_parameters" (
  "paramater_id" int4 NOT NULL DEFAULT nextval('zapd_mobile_parameters_id_seq'::regclass),
  "bloke_doc_tra_id" int4,
  "bloke_whouse_id" int4,
  CONSTRAINT "zapd_mobile_parameters_pkey" PRIMARY KEY ("paramater_id")
);

ALTER TABLE "uyumsoft"."zapd_mobile_parameters" OWNER TO "uyum";