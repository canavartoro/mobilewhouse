using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MobileWhouse.Util;
using MobileWhouse.Models;

namespace MobileWhouse.Dilogs
{
    public partial class FormSelectAlisIrsaliye : Form
    {
        public FormSelectAlisIrsaliye()
        {
            InitializeComponent();
        }

        private invt_item_m _invt_item_m = null;
        public invt_item_m Selected
        {
            get { return _invt_item_m; }
            set { _invt_item_m = value; }
        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count > 0)
            {
                this._invt_item_m = listView1.Items[listView1.SelectedIndices[0]].Tag as invt_item_m;
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(@"SELECT m.item_m_id,TO_CHAR(m.doc_date, 'DD-MM-YYYY') doc_date,m.doc_no,tr.doc_tra_code,m.gnl_note1,en.entity_code,en.entity_name,
(SELECT COUNT(*) FROM invt_item_d d WHERE d.item_m_id = m.item_m_id) lines,m.entity_id
FROM invt_item_m m INNER JOIN gnld_doc_tra tr ON m.doc_tra_id = tr.doc_tra_id INNER JOIN find_entity en ON m.entity_id = en.entity_id
WHERE m.purchase_sales = 1 AND m.invoice_status = 1 ");
                if (!string.IsNullOrEmpty(txtdocno.Text))
                {
                    sql.AppendFormat(" AND m.doc_no LIKE '%{0}%' ", txtdocno.Text);
                }
                if (!string.IsNullOrEmpty(txtentity.Text))
                {
                    sql.AppendFormat(" AND (en.entity_code LIKE '%{0}%' OR en.entity_name LIKE '%{0}%') ", txtentity.Text);
                }

                sql.AppendFormat(" AND m.doc_date = TO_DATE('{0}', 'YYYY-MM-DD') ", datedoc.Value.ToString("yyyy-MM-dd"));

                sql.Append(" ORDER BY m.item_m_id DESC LIMIT 200");

                UyumConnector.ServiceRequestOfString paramSql = new MobileWhouse.UyumConnector.ServiceRequestOfString();
                paramSql.Token = ClientApplication.Instance.Token;
                paramSql.Value = sql.ToString();
                MobileWhouse.UyumConnector.ServiceResultOfDataTable rs = ClientApplication.Instance.Service.ExecuteSQL(paramSql);
                if (rs != null && rs.Value != null && rs.Value.Rows.Count > 0)
                {
                    listView1.BeginUpdate();
                    listView1.Items.Clear();

                    for (int i = 0; i < rs.Value.Rows.Count; i++)
                    {
                        invt_item_m m = new invt_item_m();
                        m.item_m_id = Convert.ToInt32(rs.Value.Rows[i][0]);
                        m.doc_date = rs.Value.Rows[i][1].ToString();
                        m.doc_no = rs.Value.Rows[i][2].ToString();
                        m.doc_tra_code = rs.Value.Rows[i][3].ToString();
                        m.gnl_note1 = rs.Value.Rows[i][4].ToString();
                        m.entity_code = rs.Value.Rows[i][5].ToString();
                        m.entity_name = rs.Value.Rows[i][6].ToString();
                        m.lines = Convert.ToInt32(rs.Value.Rows[i][7]);
                        m.entity_id = Convert.ToInt32(rs.Value.Rows[i][8]); 

                        ListViewItem item = new ListViewItem();
                        item.Tag = m;
                        item.Text = rs.Value.Rows[i][1].ToString();
                        item.SubItems.Add(rs.Value.Rows[i][2].ToString());
                        item.SubItems.Add(rs.Value.Rows[i][3].ToString());
                        item.SubItems.Add(rs.Value.Rows[i][4].ToString());
                        item.SubItems.Add(rs.Value.Rows[i][5].ToString());
                        item.SubItems.Add(rs.Value.Rows[i][6].ToString());
                        item.SubItems.Add(rs.Value.Rows[i][7].ToString());
                        listView1.Items.Add(item);
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

        private void t1_Click(object sender, EventArgs e)
        {
            Screens.Klavye(txtdocno);
        }

        private void t2_Click(object sender, EventArgs e)
        {
            Screens.Klavye(txtentity);
        }
    }
}