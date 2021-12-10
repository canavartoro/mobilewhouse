
CREATE SEQUENCE IF NOT EXISTS "uyumsoft"."zz_worder_ac_op_id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

SELECT setval('"uyumsoft"."zz_worder_ac_op_id_seq"', 1, false);


CREATE TABLE IF NOT EXISTS "uyumsoft"."zz_worder_ac_op" (
  "worder_ac_op_id" int4 NOT NULL DEFAULT nextval('zz_worder_ac_op_id_seq'::regclass),
	"create_user_id" int4,
	"update_user_id" int4,
	"create_date" timestamp(6),
  "update_date" timestamp(6),
	"worder_m_id" int4 NOT NULL,
	"item_id" int4 NOT NULL,
	"qty" numeric(18,5) NOT NULL,
  "qty_net" numeric(18,5) NOT NULL,
  "qty_prm" numeric(18,5),
	"unit_id" int4 NOT NULL,
  "worder_op_d_id" int4 NOT NULL,
  "operation_id" int4 NOT NULL,
  "wstation_id" int4 NOT NULL,
  "start_date" timestamp(6) NOT NULL,
  "end_date" timestamp(6) NULL,
	"lot_id" int4,
  "color_id" int4,
  "package_type_id" int4,
  "quality_id" int4,
  "item_attribute1_id" int4,
  "item_attribute2_id" int4,
  "item_attribute3_id" int4,
  "item_gnl_attribute1_id" int4,
  "item_gnl_attribute2_id" int4,
  "item_gnl_attribute3_id" int4,
	"prd_source_app" int4,
  "ac_op_number" int4,
	"shifts_id" int4,
	"note_large" varchar(1000) COLLATE "pg_catalog"."default",
  "note_large2" varchar(1000) COLLATE "pg_catalog"."default",
	"is_acop_entry" int2,
	"is_closed" int2 NULL DEFAULT 0,
	CONSTRAINT "zz_worder_ac_op_pkey" PRIMARY KEY ("worder_ac_op_id")
);

DROP SEQUENCE IF EXISTS "uyumsoft"."zz_worder_ac_op_id_seq";

DROP TABLE IF EXISTS "uyumsoft"."zz_worder_ac_op";

SELECT op."worder_ac_op_id",op."create_user_id",op."create_date",op."worder_m_id",m."worder_no",
op."item_id",it."item_code",it."item_name",op."qty",op."qty_net",op."unit_id",op."worder_op_d_id",op."operation_id",op."wstation_id",op."start_date",op."shifts_id"
FROM "uyumsoft"."zz_worder_ac_op" op LEFT JOIN 
uyumsoft."prdt_worder_m" m ON op."worder_m_id" = m."worder_m_id" LEFT JOIN 
uyumsoft."invd_item" it ON op."item_id" = it."item_id" 
WHERE op."wstation_id" = '327' AND op."is_closed" = 0 


