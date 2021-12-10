using UstunWebService.Data;
using UstunWebService.Helpers;
using UstunWebService.Process.Objects;
using UstunWebService.Process.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace UstunWebService.Process.Action
{
    public class GetBarcodeMethod : BaseMethod<Params.SelectParam>
    {
        public GetBarcodeMethod(HttpContext context) : base(context) { }

        public override string Execute()
        {
            try
            {
                var valid = IsValidate();
                if (valid != null)
                {
                    return valid.ToString();
                }

                JsonObject<KmkTransferDInfo> jsonObject = new JsonObject<KmkTransferDInfo>();

                using (DataClient db = new DataClient())
                {
                    if (!db.Connect())
                    {
                        return new JsonObject<KmkTransferDInfo>()
                        {
                            Status = false,
                            Message = $"Db sunucusuna bağlanılamadı! {db.Message}"
                        }.ToString();
                    }


                    using (var table = db.FillTable($@"SELECT INVD_ITEM_BARCODE.ITEM_BARCODE_ID, INVD_ITEM_BARCODE.BRAND_ID, INVD_ITEM_GNL_ATTRIBUTE1.ATTRIBUTE_GRP AS ATTRIBUTE_GRP1, INVD_ITEM_GNL_ATTRIBUTE2.ATTRIBUTE_GRP AS ATTRIBUTE_GRP2, INVD_ITEM_GNL_ATTRIBUTE3.ATTRIBUTE_GRP AS ATTRIBUTE_GRP3, INVD_ITEM_BARCODE.BARCODE, INVD_COLOR.COLOR_CODE AS COLOR_CODE, INVD_ITEM_BARCODE.COLOR_ID, GNLD_CURRENCY.CUR_CODE AS CUR_CODE, INVD_ITEM_BARCODE.CUR_ID, INVD_ITEM_GNL_ATTRIBUTE1.DESCRIPTION AS ATTRGR_DESCRIPTION1, INVD_ITEM_GNL_ATTRIBUTE2.DESCRIPTION AS ATTRGR_DESCRIPTION2, INVD_ITEM_GNL_ATTRIBUTE3.DESCRIPTION AS ATTRGR_DESCRIPTION3, INVD_ITEM_ATTRIBUTE1.DESCRIPTION AS ATTR_DESCRIPTION1, INVD_ITEM_ATTRIBUTE2.DESCRIPTION AS ATTR_DESCRIPTION2, INVD_ITEM_ATTRIBUTE3.DESCRIPTION AS ATTR_DESCRIPTION3, INVD_COLOR.DESCRIPTION AS COLOR_DESCRIPTION, GNLD_CURRENCY.DESCRIPTION AS CUR_DESCRIPTION, INVD_LOT.DESCRIPTION AS LOT_DESCRIPTION, INVD_PACKAGE_TYPE.DESCRIPTION AS PACK_DESCRIPTION, INVD_QUALITY.DESCRIPTION AS QLTY_DESCRIPTION, INVD_UNIT.DESCRIPTION AS UNIT_DESCRIPTION, INVD_ITEM_BARCODE.DESCRIPTION, INVD_ITEM_BARCODE.ITEM_ATTRIBUTE1_ID, INVD_ITEM_BARCODE.ITEM_ATTRIBUTE2_ID, INVD_ITEM_BARCODE.ITEM_ATTRIBUTE3_ID, INVD_ITEM_ATTRIBUTE1.ITEM_ATTRIBUTE_CODE AS ITEM_ATTRIBUTE_CODE1, INVD_ITEM_ATTRIBUTE2.ITEM_ATTRIBUTE_CODE AS ITEM_ATTRIBUTE_CODE2, INVD_ITEM_ATTRIBUTE3.ITEM_ATTRIBUTE_CODE AS ITEM_ATTRIBUTE_CODE3, INVD_ITEM_ATTRIBUTE1.DESCRIPTION AS ITEM_ATTRIBUTE_NAME1, INVD_ITEM_ATTRIBUTE2.DESCRIPTION AS ITEM_ATTRIBUTE_NAME2, INVD_ITEM_ATTRIBUTE3.DESCRIPTION AS ITEM_ATTRIBUTE_NAME3, INVD_ITEM.ITEM_CODE AS ITEM_CODE, INVD_ITEM_BARCODE.ITEM_GNL_ATTRIBUTE1_ID, INVD_ITEM_GNL_ATTRIBUTE1.ITEM_ATTRIBUTE_CODE AS GNL_ATTR1_CODE, INVD_ITEM_GNL_ATTRIBUTE2.ITEM_ATTRIBUTE_CODE AS GNL_ATTR2_CODE, INVD_ITEM_GNL_ATTRIBUTE3.ITEM_ATTRIBUTE_CODE AS GNL_ATTR3_CODE, INVD_ITEM_BARCODE.ITEM_GNL_ATTRIBUTE2_ID, INVD_ITEM_BARCODE.ITEM_GNL_ATTRIBUTE3_ID, INVD_ITEM_BARCODE.ITEM_ID, INVD_ITEM.ITEM_NAME AS ITEM_NAME, INVD_ITEM_BARCODE.LINE_NO, INVD_LOT.LOT_CODE AS LOT_CODE, INVD_ITEM_BARCODE.LOT_ID, INVD_PACKAGE_TYPE.PACKAGE_TYPE_CODE AS PACKAGE_TYPE_CODE, INVD_ITEM_BARCODE.PACKAGE_TYPE_ID, INVD_ITEM_BARCODE.QTY, INVD_QUALITY.QUALITY_CODE AS QUALITY_CODE, INVD_ITEM_BARCODE.QUALITY_ID, INVD_UNIT.UNIT_CODE AS UNIT_CODE, INVD_ITEM_BARCODE.UNIT_ID, INVD_ITEM_BARCODE.INV_BARCODE_TYPE_ID, INVD_BARCODE_TYPE.INV_BARCODE_TYPE_CODE, INVD_BARCODE_TYPE.BARCODE_TYPE, INVD_BARCODE_TYPE.BARCODE_COUNTRY_CODE, INVD_BARCODE_TYPE.BARCODE_COMPANY_CODE, INVD_BRAND.BRAND_CODE, INVD_ITEM.DEFAULT_ASORT_MODE, INVD_ITEM.OLD_ITEM_CODE, INVD_ITEM_BARCODE.PRODUCT_BARCODE_CODE, INVD_ITEM_BARCODE.QTY_FREE_PRM, INVD_ITEM_BARCODE.QTY_FREE_SEC, INVD_ITEM_BARCODE.ITEM_ATTRIBUTE4_ID, INVD_ITEM_ATTRIBUTE4.ITEM_ATTRIBUTE_CODE AS ITEM_ATTRIBUTE_CODE4, INVD_ITEM_BARCODE.SOURCE_APP, INVD_ITEM_BARCODE.SOURCE_M_ID, INVD_ITEM_BARCODE.SOURCE_D_ID FROM INVD_ITEM_BARCODE  LEFT OUTER JOIN  UYUMSOFT.INVD_ITEM ON INVD_ITEM_BARCODE.ITEM_ID = INVD_ITEM.ITEM_ID  LEFT OUTER JOIN  UYUMSOFT.INVD_UNIT ON INVD_ITEM_BARCODE.UNIT_ID = INVD_UNIT.UNIT_ID  LEFT OUTER JOIN  UYUMSOFT.GNLD_CURRENCY ON INVD_ITEM_BARCODE.CUR_ID = GNLD_CURRENCY.CUR_ID  LEFT OUTER JOIN  UYUMSOFT.INVD_COLOR ON INVD_ITEM_BARCODE.COLOR_ID = INVD_COLOR.COLOR_ID  LEFT OUTER JOIN  UYUMSOFT.INVD_ITEM_ATTRIBUTE INVD_ITEM_ATTRIBUTE1 ON INVD_ITEM_BARCODE.ITEM_ATTRIBUTE1_ID = INVD_ITEM_ATTRIBUTE1.ITEM_ATTRIBUTE_ID  LEFT OUTER JOIN  UYUMSOFT.INVD_ITEM_ATTRIBUTE INVD_ITEM_ATTRIBUTE2 ON INVD_ITEM_BARCODE.ITEM_ATTRIBUTE2_ID = INVD_ITEM_ATTRIBUTE2.ITEM_ATTRIBUTE_ID  LEFT OUTER JOIN  UYUMSOFT.INVD_ITEM_ATTRIBUTE INVD_ITEM_ATTRIBUTE3 ON INVD_ITEM_BARCODE.ITEM_ATTRIBUTE3_ID = INVD_ITEM_ATTRIBUTE3.ITEM_ATTRIBUTE_ID  LEFT OUTER JOIN  UYUMSOFT.INVD_ITEM_GNL_ATTRIBUTE INVD_ITEM_GNL_ATTRIBUTE1 ON INVD_ITEM_BARCODE.ITEM_GNL_ATTRIBUTE1_ID = INVD_ITEM_GNL_ATTRIBUTE1.ITEM_GNL_ATTRIBUTE_ID  LEFT OUTER JOIN  UYUMSOFT.INVD_ITEM_GNL_ATTRIBUTE INVD_ITEM_GNL_ATTRIBUTE2 ON INVD_ITEM_BARCODE.ITEM_GNL_ATTRIBUTE2_ID = INVD_ITEM_GNL_ATTRIBUTE2.ITEM_GNL_ATTRIBUTE_ID  LEFT OUTER JOIN  UYUMSOFT.INVD_ITEM_GNL_ATTRIBUTE INVD_ITEM_GNL_ATTRIBUTE3 ON INVD_ITEM_BARCODE.ITEM_GNL_ATTRIBUTE3_ID = INVD_ITEM_GNL_ATTRIBUTE3.ITEM_GNL_ATTRIBUTE_ID  LEFT OUTER JOIN  UYUMSOFT.INVD_QUALITY ON INVD_ITEM_BARCODE.QUALITY_ID = INVD_QUALITY.QUALITY_ID  LEFT OUTER JOIN  UYUMSOFT.INVD_LOT ON INVD_ITEM_BARCODE.LOT_ID = INVD_LOT.LOT_ID  LEFT OUTER JOIN  UYUMSOFT.INVD_PACKAGE_TYPE ON INVD_ITEM_BARCODE.PACKAGE_TYPE_ID = INVD_PACKAGE_TYPE.PACKAGE_TYPE_ID  LEFT OUTER JOIN  UYUMSOFT.INVD_BARCODE_TYPE ON INVD_ITEM_BARCODE.INV_BARCODE_TYPE_ID = INVD_BARCODE_TYPE.INV_BARCODE_TYPE_ID  LEFT OUTER JOIN  UYUMSOFT.INVD_BRAND ON INVD_ITEM_BARCODE.BRAND_ID = INVD_BRAND.BRAND_ID LEFT OUTER JOIN  UYUMSOFT.INVD_ITEM_ATTRIBUTE INVD_ITEM_ATTRIBUTE4 ON INVD_ITEM_BARCODE.ITEM_ATTRIBUTE4_ID = INVD_ITEM_ATTRIBUTE4.ITEM_ATTRIBUTE_ID  
WHERE INVD_ITEM_BARCODE.BARCODE = '{serviceparam.SearchEntity}'"))
                    {
                        if (table != null && table.Rows.Count > 0)
                        {
                            jsonObject.Status = true;
                            jsonObject.Values = new KmkTransferDInfo();
                            jsonObject.Values.ItemId = Convert.ToInt32(table.Rows[0]["ITEM_ID"]);
                            jsonObject.Values.ItemCode = table.Rows[0]["ITEM_CODE"].ToString();
                            jsonObject.Values.ItemName = table.Rows[0]["ITEM_NAME"].ToString();
                            jsonObject.Values.LotId = Convert.ToInt32(table.Rows[0]["LOT_ID"]);
                            jsonObject.Values.LotCode = table.Rows[0]["LOT_CODE"].ToString();
                            jsonObject.Values.ItemAttribute1Id = Convert.ToInt32(table.Rows[0]["ITEM_ATTRIBUTE1_ID"]);
                            jsonObject.Values.ItemAttributeCode1 = table.Rows[0]["ITEM_ATTRIBUTE_CODE1"].ToString();
                            jsonObject.Values.ItemAttribute2Id = Convert.ToInt32(table.Rows[0]["ITEM_ATTRIBUTE2_ID"]);
                            jsonObject.Values.ItemAttributeCode2 = table.Rows[0]["ITEM_ATTRIBUTE_CODE2"].ToString();
                            jsonObject.Values.ItemAttribute3Id = Convert.ToInt32(table.Rows[0]["ITEM_ATTRIBUTE3_ID"]);
                            jsonObject.Values.ItemAttributeCode3 = table.Rows[0]["ITEM_ATTRIBUTE_CODE3"].ToString();
                            jsonObject.Values.QualityId = Convert.ToInt32(table.Rows[0]["QUALITY_ID"]);
                            jsonObject.Values.QualityCode = table.Rows[0]["QUALITY_CODE"].ToString();
                            jsonObject.Values.ColorId = Convert.ToInt32(table.Rows[0]["COLOR_ID"]);
                            jsonObject.Values.ColorCode = table.Rows[0]["COLOR_CODE"].ToString();
                            jsonObject.Values.PackageTypeId = Convert.ToInt32(table.Rows[0]["PACKAGE_TYPE_ID"]);
                            jsonObject.Values.PackageTypeCode = table.Rows[0]["PACKAGE_TYPE_CODE"].ToString();
                            decimal qty = Convert.ToDecimal(table.Rows[0]["QTY"]);
                            jsonObject.Values.Qty = qty > 0 ? qty : 1;
                            jsonObject.Values.UnitId = Convert.ToInt32(table.Rows[0]["UNIT_ID"]);
                            jsonObject.Values.UnitCode = table.Rows[0]["UNIT_CODE"].ToString();

                        }
                        else
                        {
                            jsonObject.Status = false;
                            jsonObject.Message = $"Barkod bulunamadı! {serviceparam.SearchEntity}";
                        }
                    }
                }
                return jsonObject.ToString();
            }
            catch (Exception exc)
            {
                Logger.WriteFileLog(new StringBuilder().Append("Genel hata:").Append(exc.Message).Append("Detay:").Append(exc.StackTrace).ToString());
                return new JsonObject<KmkTransferDInfo>()
                {
                    Status = false,
                    Message = exc.Message
                }.ToString();
            }
        }
    }
}