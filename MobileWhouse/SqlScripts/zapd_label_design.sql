CREATE SEQUENCE "uyumsoft"."zapd_label_design_id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

SELECT setval('"uyumsoft"."zapd_label_design_id_seq"', 9, true);

ALTER SEQUENCE "uyumsoft"."zapd_label_design_id_seq" OWNER TO "uyum";

CREATE TABLE "uyumsoft"."zapd_label_design" (
  "id" int4 NOT NULL,
  "name" varchar(150) COLLATE "pg_catalog"."default",
  "view_name" varchar(100) COLLATE "pg_catalog"."default",
  "design_content" bytea,
  "is_available" int2,
  "create_date" timestamp(6),
  "update_date" timestamp(6),
  CONSTRAINT "zapd_label_design_pkey" PRIMARY KEY ("id")
);

ALTER TABLE "uyumsoft"."zapd_label_design" OWNER TO "uyum";