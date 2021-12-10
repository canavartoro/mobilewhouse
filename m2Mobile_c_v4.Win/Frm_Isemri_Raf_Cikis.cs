using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using m2Mobile_c_v4.WebReference;
using m2Mobile_c_v4.Classes;

namespace m2Mobile_c_v4
{
    public partial class Frm_Isemri_Raf_Cikis : Form
    {
        public Frm_Isemri_Raf_Cikis()
        {
            InitializeComponent();
        }

        public void getIsEmriMalzemeData(string _find)
        {
            SysDefinitions.CursorState("Wait");
            ServiceRequestOfTrmWorderMInParam trmWorderMinParam = new ServiceRequestOfTrmWorderMInParam()
            {
                Token = new Token(),
                Value = new TrmWorderMInParam()
            };
            trmWorderMinParam.Token = m2Mobile_c_v4.Data._Token.Token;
            trmWorderMinParam.Value.WorderMatrlTrnType = 0;
            trmWorderMinParam.Value.PageSize = 10000;
            ServiceResultOfListOfTrmWorderMOutParam worderMinfo = m2Mobile_c_v4.Data._UService.GetWorderMInfo(trmWorderMinParam);
            if (worderMinfo.Result)
            {
                TrmWorderMOutParam[] array = worderMinfo.Value.OrderBy(x => x.ItemCode).ToArray();
                //(TrmWorderMOutParam[])Enumerable.ToArray<TrmWorderMOutParam>((IEnumerable<M0>)Enumerable.OrderBy<TrmWorderMOutParam, string>((IEnumerable<M0>)worderMinfo.Value, (Func<M0, M1>)(t => t.ItemCode)));
                if (_find == "")
                {
                    foreach (TrmWorderMOutParam trmWorderMoutParam in array)
                    {
                        DataRow row = ((DataTable)this.dS_Is_Emri.Dt_Onaylı_Is_Emri).NewRow();
                        row["IsEmri_Tar"] = (object)trmWorderMoutParam.WoOpenDate.ToString("dd/mm/yyyy");
                        row["IsEmri_No"] = (object)trmWorderMoutParam.WorderNo;
                        row["Stk_Kod"] = (object)trmWorderMoutParam.ItemCode;
                        row["Stk_Adı"] = (object)trmWorderMoutParam.ItemName;
                        row["IsEmri_Tipi"] = (object)trmWorderMoutParam.WoTypeDescription;
                        row["Rota_Op_Adı"] = (object)trmWorderMoutParam.RouteMId;
                        row["Id"] = (object)trmWorderMoutParam.WorderMId;
                        ((DataTable)this.dS_Is_Emri.Dt_Onaylı_Is_Emri).Rows.Add(row);
                    }
                    this.dtOnaylıIsEmriBindingSource.DataSource = (object)this.dS_Is_Emri.Dt_Onaylı_Is_Emri;
                }
                else
                {
                    ((DataTable)this.dS_Is_Emri.Dt_Onaylı_Is_Emri).Clear();
                    foreach (TrmWorderMOutParam trmWorderMoutParam in array)
                    {
                        DateTime woOpenDate = trmWorderMoutParam.WoOpenDate;
                        if (woOpenDate.ToString().Equals(_find) || trmWorderMoutParam.WorderNo == _find || trmWorderMoutParam.ItemCode == _find)
                        {
                            DataRow row = ((DataTable)this.dS_Is_Emri.Dt_Onaylı_Is_Emri).NewRow();
                            DataRow dataRow = row;
                            string index = "IsEmri_Tar";
                            woOpenDate = trmWorderMoutParam.WoOpenDate;
                            string str = woOpenDate.ToString("dd/mm/yyyy");
                            dataRow[index] = (object)str;
                            row["IsEmri_No"] = (object)trmWorderMoutParam.WorderNo;
                            row["Stk_Kod"] = (object)trmWorderMoutParam.ItemCode;
                            row["Stk_Adı"] = (object)trmWorderMoutParam.ItemName;
                            row["IsEmri_Tipi"] = (object)trmWorderMoutParam.WoTypeDescription;
                            row["Rota_Op_Adı"] = (object)trmWorderMoutParam.RouteMId;
                            row["Id"] = (object)trmWorderMoutParam.WorderMId;
                            ((DataTable)this.dS_Is_Emri.Dt_Onaylı_Is_Emri).Rows.Add(row);
                        }
                    }
                    this.dtOnaylıIsEmriBindingSource.DataSource = (object)this.dS_Is_Emri.Dt_Onaylı_Is_Emri;
                }
            }
            else
                this.dataGrid1.DataSource = (object)null;
            this.dataGrid1.Refresh();
            SysDefinitions.CursorState("Default");
        }

        private void btn_vazgec_Click(object sender, EventArgs e)
        {
            base.Dispose();
            base.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.getIsEmriMalzemeData(this.txt_arama.Text);
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            this.SetColumnWidth();
        }

        private void dataGrid1_DoubleClick(object sender, EventArgs e)
        {
            if (this.dataGrid1.CurrentRowIndex >= 0)
            {
                DataRow selected_row = this.dS_Is_Emri.Dt_Onaylı_Is_Emri.Rows[this.dataGrid1.CurrentRowIndex];
                //new Frm_RafIslem_Cikis_Detay(selected_row, this._SourceDepo).Show();
            }
        }

        private void Frm_Isemri_Raf_Cikis_Load(object sender, EventArgs e)
        {
            this.txt_arama.Text = "";
            this.getIsEmriMalzemeData("");
            this._SourceDepo = Data._SelectedWareHouse;
        }

        private int LongestField(DataSet ds, string TableName, string ColumnName)
        {
            int minlength = 0;
            int maxlength = 0;
            int tot = ds.Tables[TableName].Rows.Count;
            string straux = "";
            int intaux = 0;
            Graphics g = this.dataGrid1.CreateGraphics();
            int offset = Convert.ToInt32(Math.Ceiling((double)g.MeasureString(" ", this.dataGrid1.Font).Width));
            for (int i = 0; i < tot; i++)
            {
                straux = ds.Tables[TableName].Rows[i][ColumnName].ToString();
                intaux = Convert.ToInt32(Math.Ceiling((double)g.MeasureString(straux, this.dataGrid1.Font).Width));
                if (intaux > maxlength)
                {
                    maxlength = intaux;
                }
                if (minlength > intaux)
                {
                    minlength = intaux;
                }
            }
            if (this.checkBox1.Checked)
            {
                return ((maxlength + offset) + 20);
            }
            return ((minlength + offset) + 40);
        }
        private void SetColumnWidth()
        {
            try
            {
                int newwidth = this.LongestField(this.dS_Is_Emri, "Dt_Onaylı_Is_Emri", "Stk_Adı");
                DataGridTableStyle ts = new DataGridTableStyle();
                ts.MappingName = "Dt_Onaylı_Is_Emri";
                this.dataGrid1.TableStyles.Clear();
                this.dataGrid1.TableStyles.Add(ts);
                for (int i = 0; i < 5; i++)
                {
                    this.dataGrid1.TableStyles["Dt_Onaylı_Is_Emri"].GridColumnStyles[i].Width = newwidth;
                }
                this.dataGrid1.Refresh();
            }
            catch (SystemException)
            {
                base.ShowDialog();
            }
        }

























    }
}