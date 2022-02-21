CREATE SEQUENCE "uyumsoft"."zz_package_m_package_id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

SELECT setval('"uyumsoft"."zz_package_m_package_id_seq"', 547, true);

ALTER SEQUENCE "uyumsoft"."zz_package_m_package_id_seq" OWNER TO "uyum";


CREATE SEQUENCE "uyumsoft"."zz_package_m_package_no_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

SELECT setval('"uyumsoft"."zz_package_m_package_no_seq"', 547, true);

ALTER SEQUENCE "uyumsoft"."zz_package_m_package_no_seq" OWNER TO "uyum";


CREATE TABLE "uyumsoft"."zz_package_m" (
  "package_id" int4 NOT NULL DEFAULT nextval('zz_package_m_package_id_seq'::regclass),
  "create_user_id" int4,
  "update_user_id" int4,
  "create_date" timestamp(6),
  "update_date" timestamp(6),
  "worder_ac_op_id" int4,
  "bwh_location_id" int4,
  "color_id" int4,
  "description" varchar(50) COLLATE "pg_catalog"."default",
  "expration_date" timestamp(6),
  "gross_weight" numeric(18,2),
  "has_detail" int2,
  "input_output" int4,
  "item_attribute1_id" int4,
  "item_attribute2_id" int4,
  "item_attribute3_id" int4,
  "item_id" int4,
  "lot_id" int4,
  "net_weight" numeric(18,2),
  "package_no" varchar(20) COLLATE "pg_catalog"."default" DEFAULT concat('KL', lpad(((nextval('zz_package_m_package_no_seq'::regclass))::character varying)::text, 12, '0'::text)),
  "package_type_id" int4,
  "qty" numeric(18,5),
  "quality_id" int4,
  "source_app" int4,
  "whouse_id" int4 NOT NULL,
  "unit_id" int4,
  "qty_free_prm" numeric(18,5),
  "qty_free_sec" numeric(18,5),
  "qty_prm" numeric(18,5),
  "cat_code1_id" int4,
  "cat_code2_id" int4,
  "dcard_id" int4,
  "package_detail_type" int4,
  "worder_m_id" int4,
  "source_m_id" int4,
  "revort" int2,
  "tare" numeric(18,6),
  "source_d_id" int4 DEFAULT 0,
  "free_sec_m_id" int4,
  "free_prm_m_id" int4,
  "serial_m_id" int4,
  "is_reserved" int2 DEFAULT 0,
  "is_closed" int2 DEFAULT 0,
  "package_m_id" int4,
  "package_tra_m_id" int4,
  "package_tra_d_id" int4,
  "worder_op_d_id" int4,
  "operation_id" int4,
  "operation_no" int4,
  "is_created" int2 DEFAULT 0,
  "palette_no" varchar(16) COLLATE "pg_catalog"."default",
  "is_scrapt" int2,
  "is_real" int2,
  "worder_ac_bom_d_id" int4,
  "scrap_result_type" int4,
  "scrap_reason_id" int4,
  "diff_item_id" int4,
  "diff_unit_id" int4,
  "erp_worder_ac_op_id" int4,
  "worder_ac_bom_m_id" int4,
  "user_code" varchar(60) COLLATE "pg_catalog"."default",
  "worder_ac_bom_d_line_no" int4,
  CONSTRAINT "zz_package_m_pkey" PRIMARY KEY ("package_id")
)
;

ALTER TABLE "uyumsoft"."zz_package_m" 
  OWNER TO "uyum";

CREATE UNIQUE INDEX "ix_barcode" ON "uyumsoft"."zz_package_m" USING btree (
  "package_no" COLLATE "pg_catalog"."default" "pg_catalog"."text_ops" ASC NULLS LAST
);