using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MobileWhouse.Log;
using MobileWhouse.Util;
using System.Threading;
using MobileWhouse.Attributes;

namespace MobileWhouse.Controls.Package
{
    [UyumModule("PKG004", "MobileWhouse.Controls.Package.EtiketlemeControl", "Etiketleme")]
    public partial class EtiketlemeControl : BaseControl
    {
        public EtiketlemeControl()
        {
            InitializeComponent();
        }

        private string ViewName = "";

        private void GetViewName()
        {
            try
            {
                if (string.IsNullOrEmpty(printetiketleme.DesignName)) return;

                Cursor.Current = Cursors.WaitCursor;

                MobileWhouse.UyumConnector.ServiceRequestOfString param = new MobileWhouse.UyumConnector.ServiceRequestOfString();
                param.Token = ClientApplication.Instance.Token;
                param.Value = string.Concat("SELECT view_name FROM zapd_label_design WHERE name = '", printetiketleme.DesignName, "'");
                Logger.I(param.Value);

                MobileWhouse.UyumConnector.ServiceResultOfDataTable res = ClientApplication.Instance.Service.ExecuteSQL(param);
                if (res != null)
                {
                    if (res.Result == false)
                    {
                        MobileWhouse.Util.Screens.Error(string.Concat("Sunucu hatası:", res.Message));
                    }
                    else
                    {
                        if (res.Value != null && res.Value.Rows.Count > 0)
                        {
                            ViewName = res.Value.Rows[0][0].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Screens.Error(ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
                GetData();

            }
        }

        private void GetData()
        {
            try
            {
                if (string.IsNullOrEmpty(ViewName)) return;

                Cursor.Current = Cursors.WaitCursor;

                StringBuilder sql = new StringBuilder();
                sql.Append("SELECT * FROM ").Append(ViewName);
                if (!string.IsNullOrEmpty(textarama.Text) && !string.IsNullOrEmpty(comboField.Text))
                {
                    sql.Append(" WHERE ").Append(comboField.Text).Append(" LIKE '%").Append(textarama.Text).Append("%' ");
                }
                sql.Append(" ORDER BY 1 DESC LIMIT 500");

                MobileWhouse.UyumConnector.ServiceRequestOfString param = new MobileWhouse.UyumConnector.ServiceRequestOfString();
                param.Token = ClientApplication.Instance.Token;
                //param.Value = string.Concat("SELECT * FROM ", ViewName, " ORDER BY 1 DESC LIMIT 500");
                param.Value = sql.ToString();
                Logger.I(param.Value);

                MobileWhouse.UyumConnector.ServiceResultOfDataTable res = ClientApplication.Instance.Service.ExecuteSQL(param);
                if (res != null)
                {
                    if (res.Result == false)
                    {
                        MobileWhouse.Util.Screens.Error(string.Concat("Sunucu hatası:", res.Message));
                    }
                    else
                    {
                        listView1.BeginUpdate();
                        listView1.Items.Clear();
                        comboField.Items.Clear();
                        if (res.Value != null && res.Value.Rows.Count > 0)
                        {
                            DataTable dt = res.Value;
                            int columncount = dt.Columns.Count;

                            for (int i = 0; i < columncount; i++)
                            {
                                comboField.Items.Add(dt.Columns[i].Caption);
                                ColumnHeader header = new ColumnHeader();
                                header.Text = dt.Columns[i].Caption;
                                if (dt.Columns[i].DataType == typeof(int) || dt.Columns[i].DataType == typeof(decimal) || dt.Columns[i].DataType == typeof(double))
                                    header.TextAlign = HorizontalAlignment.Right;
                                else
                                    header.TextAlign = HorizontalAlignment.Left;
                                header.Width = 60;
                                listView1.Columns.Add(header);
                            }

                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                ListViewItem item = new ListViewItem();
                                item.Text = dt.Rows[i][0].ToString();
                                for (int c = 1; c < columncount; c++)
                                {
                                    item.SubItems.Add(dt.Rows[i][c].ToString());
                                }
                                if (i % 2 == 0) item.BackColor = Color.Gainsboro;
                                listView1.Items.Add(item);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Screens.Error(ex);
            }
            finally
            {
                listView1.EndUpdate();
                Cursor.Current = Cursors.Default;
            }
        }

        private void printetiketleme_SelectedChanged(object sender, EventArgs e)
        {
            GetViewName();
        }

        private void brnkapat_Click(object sender, EventArgs e)
        {
            MainForm.ShowControl(new AmbalajMenuControl());
        }

        private void t1_Click(object sender, EventArgs e)
        {
            Screens.Klavye(textarama);
        }

        private void btnara_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void btnyazdir_Click(object sender, EventArgs e)
        {
            try
            {
                if (!printetiketleme.IsSelectPrinter)
                {
                    Screens.Warning("Yazıcı ve tasarım seçilmedi!");
                    return;
                }
                if (listView1.Items.Count == 0)
                {
                    Screens.Warning("Liste boş! Yazdırılacak kayıtlar seçilmelidir.");
                    return;
                }
                string filter = "";
                if(comboField.Items.Count > 0)filter = comboField.Items[0].ToString();
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (listView1.Items[i].Checked)
                    {
                        printetiketleme.Print(string.Concat(" ", filter, " = '", listView1.Items[i].Text, "' "));
                        Thread.Sleep(100);
                    }
                }
            }
            catch (Exception exc)
            {
                Screens.Error(exc);
            }
        }
    }
}
