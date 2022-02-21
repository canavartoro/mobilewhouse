CREATE SEQUENCE "uyumsoft"."zz_worder_ac_op_id_seq" 
INCREMENT 1
MINVALUE  1
MAXVALUE 2147483647
START 1
CACHE 1;

SELECT setval('"uyumsoft"."zz_worder_ac_op_id_seq"', 29, true);

ALTER SEQUENCE "uyumsoft"."zz_worder_ac_op_id_seq" OWNER TO "uyum";

CREATE TABLE "uyumsoft"."zz_worder_ac_op" (
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
  "end_date" timestamp(6),
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
  "is_closed" int2 DEFAULT 0,
  "operation_no" int4,
  "is_approved" int2,
  "is_break" int2,
  "worder_break_id" int4,
  CONSTRAINT "zz_worder_ac_op_pkey" PRIMARY KEY ("worder_ac_op_id")
)
;

ALTER TABLE "uyumsoft"."zz_worder_ac_op" 
  OWNER TO "uyum";

CREATE INDEX "ix_wstation" ON "uyumsoft"."zz_worder_ac_op" USING btree (
  "wstation_id" "pg_catalog"."int4_ops" ASC NULLS LAST,
  "is_closed" "pg_catalog"."int2_ops" ASC NULLS LAST
);