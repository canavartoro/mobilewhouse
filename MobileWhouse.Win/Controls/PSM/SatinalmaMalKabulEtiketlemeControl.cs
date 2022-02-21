using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MobileWhouse.Util;
using MobileWhouse.Models;
using MobileWhouse.Attributes;

namespace MobileWhouse.Controls.PSM
{
    [UyumModule("PSM002", "MobileWhouse.Controls.PSM.SatinalmaMalKabulEtiketlemeControl", "S. MAL KABUL ETİKETLEME")]
    public partial class SatinalmaMalKabulEtiketlemeControl : BaseControl
    {
        public SatinalmaMalKabulEtiketlemeControl()
        {
            InitializeComponent();
        }

        public SatinalmaMalKabulEtiketlemeControl(int id)
        {
            InitializeComponent();
            this._item_m_id = id;
            IrsaliyeDetay();
        }

        private int _item_m_id = 0;
        private List<invt_item_d> details = null;

        private void IrsaliyeDetay()
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.AppendFormat(@"SELECT d.item_d_id,d.item_id,it.item_code,it.item_name,d.unit_id,un.unit_code,d.line_no,d.lot_id,lt.lot_code,d.qty,d.whouse_id,wh.whouse_code,d.source_d_id,d.source_m_id 
FROM invt_item_d d INNER JOIN invd_item it ON d.item_id = it.item_id INNER JOIN 
invd_unit un ON d.unit_id = un.unit_id LEFT JOIN invd_lot lt ON d.lot_id = lt.lot_id LEFT JOIN
invd_whouse wh ON d.whouse_id = wh.whouse_id
WHERE d.item_m_id = {0}
ORDER BY d.line_no", _item_m_id);

                UyumConnector.ServiceRequestOfString paramSql = new MobileWhouse.UyumConnector.ServiceRequestOfString();
                paramSql.Token = ClientApplication.Instance.Token;
                paramSql.Value = sql.ToString();
                MobileWhouse.UyumConnector.ServiceResultOfDataTable rs = ClientApplication.Instance.Service.ExecuteSQL(paramSql);
                if (rs != null && rs.Value != null && rs.Value.Rows.Count > 0)
                {
                    listView1.BeginUpdate();
                    listView1.Items.Clear();

                    details = Data.DataProvider.TableToList(rs.Value, typeof(invt_item_d)) as List<invt_item_d>;
                    if (details != null && details.Count > 0)
                    {
                        for (int i = 0; i < details.Count; i++)
                        {
                            ListViewItem item = new ListViewItem();
                            item.Tag = details[i];
                            item.Text = details[i].item_code;
                            item.SubItems.Add(details[i].item_name);
                            item.SubItems.Add(details[i].unit_code);
                            item.SubItems.Add(details[i].qty.ToString(Statics.DECIMAL_STRING_FORMAT));
                            item.SubItems.Add(details[i].lot_code);
                            listView1.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                Screens.Error(exc);
            }
            finally
            {
                Screens.HideWait();
                listView1.EndUpdate();
            }
        }
    }
}
