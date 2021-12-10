
CREATE SEQUENCE "uyumsoft"."zz_ermas_sevk_id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 9223372036854775807
START 1
CACHE 1;

CREATE TABLE "uyumsoft"."zz_ermas_sevk" (
	"id" int4 NOT NULL DEFAULT nextval('zz_ermas_sevk_id_seq'::regclass),
	"item_m_id" int4,
	"doc_date" timestamp,
	"doc_no" varchar(20),
	"entity_id" int4,
	"entity_code" varchar(100),
	"license_plate" varchar(20),
	"driver_name" varchar(150),
	"package_no" varchar(100),
	"description" varchar(150),
	"description2" varchar(150),
	"create_date" timestamp DEFAULT CURRENT_TIMESTAMP,
	"creator" varchar(20),
	"create_user_id" int4,
	"status" int4,
  PRIMARY KEY ("id")
);

DROP TABLE "uyumsoft"."zz_ermas_sevk";
DROP SEQUENCE "uyumsoft"."zz_ermas_sevk_id_seq"; 