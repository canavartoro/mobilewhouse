using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using MobileWhouse.UTermConnector;
using MobileWhouse.Util;

namespace MobileWhouse
{
    public partial class FrmAramaFirma : Form, IDisposable
    {
        string pEntityName = string.Empty;
        string pEntitySearchKeyword = string.Empty;


        string Pkey = "";
        string Pkey2 = "";
        string Pkey3 = "";
        string Pkey4 = "";

        string _Type = "";
        int _id = 0;
        int _id2 = 0;
        ServiceRequestOfTrmCoEntityInParam _Coep = new ServiceRequestOfTrmCoEntityInParam();
        ServiceResultOfListOfTrmCoEntityOutParam _CoParam = new ServiceResultOfListOfTrmCoEntityOutParam();
        public FrmAramaFirma(string _Ptype,int _Pid, int _Pid2)
        {
            
            InitializeComponent();
            _Type = _Ptype;
            _id = _Pid;
            _id2 = _Pid2;
            GetData();
        }
        public string RetKey
        {
            get { return Pkey; }
        }

        public string RetKey2
        {
            get { return Pkey2; }
        }

        public string RetKey3
        {
            get { return Pkey3; }
        }

        public string RetKey4
        {
            get { return Pkey4; }
        }

        void GetData()
        {
            
            
            if (_Type == "Entity")
            {

                GetCoEntity();
            }
 
           
//Son:
                
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pkey = GridSearch[GridSearch.CurrentCell.RowNumber, 0].ToString();
            try
            {
                Pkey2 = GridSearch[GridSearch.CurrentCell.RowNumber, 1].ToString();
                Pkey3 = GridSearch[GridSearch.CurrentCell.RowNumber, 2].ToString();
            }
            catch (SystemException)
            {
            }

            try
            {
                Pkey3 = GridSearch[GridSearch.CurrentCell.RowNumber, 2].ToString();
            }
            catch (SystemException)
            {
            }
            try
            {
                Pkey4 = GridSearch[GridSearch.CurrentCell.RowNumber, 3].ToString();
            }
            catch (SystemException)
            {
            }
            


            this.Close(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Pkey = "";
            this.Close();
        }

        private void GridSearch_DoubleClick(object sender, EventArgs e)
        {
            button1_Click(null, null);

            //this.Close(); 
        }

        private void FrmArama_Load(object sender, EventArgs e)
        {
            string _Gelen = "";
            //foreach (Control Ctrl in this.Controls)
            //{
            //    _Gelen = "";
            //    _Gelen = Classes.SysDefinitions.ResMan.GetString(Ctrl.Name.ToString());
            //    if (_Gelen == null) continue;
            //    Ctrl.Text = Classes.SysDefinitions.ResMan.GetString(Ctrl.Name.ToString());
            //}
            //_Gelen = "";
            //foreach (Control Ctrl in this.panel1.Controls)
            //{
            //    _Gelen = "";
            //    _Gelen = Classes.SysDefinitions.ResMan.GetString(Ctrl.Name.ToString());
            //    if (_Gelen == null) continue;
            //    Ctrl.Text = Classes.SysDefinitions.ResMan.GetString(Ctrl.Name.ToString());
            //}
            //_Gelen = "";
            //foreach (Control Ctrl in this.panel2.Controls)
            //{
            //    _Gelen = "";
            //    _Gelen = Classes.SysDefinitions.ResMan.GetString(Ctrl.Name.ToString());
            //    if (_Gelen == null) continue;
            //    Ctrl.Text = Classes.SysDefinitions.ResMan.GetString(Ctrl.Name.ToString());
            //}
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            GetCoEntity();

            /*
             * Db'de çok fazla kayıt olunca bu mantık çöküyor.
             * CultureInfo culture = new CultureInfo("tr-TR"); //Büyük Küçük harf ayrımı yapmasın.

            if (Tx_FirmaAd.Text.StartsWith("%"))
            {
                string pSearchText = Tx_FirmaAd.Text.Substring(1);
                var query = _CoParam.Value.Where(p => p.EntityName.ToLower(culture).Contains(pSearchText.ToString().ToLower(culture)));
                GridSearch.DataSource = query.ToList();
            }
            else
            {
                var query = _CoParam.Value.Where(p => p.EntityName.ToLower(culture).StartsWith(Tx_FirmaAd.Text.ToString().ToLower(culture)));
                GridSearch.DataSource = query.ToList();
            }* */
        }

        /// <summary>
        /// Firma / Cari Kart Getir
        /// </summary>
        private void GetCoEntity()
        {
            try
            {
                Screens.ShowWait();
                //Start With İle Ara
                pEntityName = Tx_FirmaAd.Text;
                pEntitySearchKeyword = string.Empty;
                if (Tx_FirmaAd.Text.StartsWith("%")) //Contains' ile ara
                {
                    pEntityName = Tx_FirmaAd.Text.Substring(1);
                    pEntitySearchKeyword = "%";
                }

                _Coep.Token = new Token();
                _Coep.Value = new TrmCoEntityInParam();
                _Coep.Token = ClientApplication.Instance.UTermToken;

                _Coep.Value.EntityName = pEntityName;
                _Coep.Value.EntitySearchKeyword = pEntitySearchKeyword;
                _Coep.Value.PageSize = 1000;
                _CoParam = ClientApplication.Instance.UTermService.GetOutCoEntityInfo(_Coep);

                labelCount.Text = "";
                if (_CoParam.Result == true)
                {
                    labelCount.Text = _CoParam.Value.Length.ToString();
                    GridSearch.DataSource = _CoParam.Value;
                }


                #region Column Style
                GridSearch.TableStyles.Clear();
                DataGridTableStyle tableStyle = new DataGridTableStyle();
                //ts.MappingName = "TableD";
                tableStyle.MappingName = _CoParam.Value.GetType().Name;
                tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "EntityName", HeaderText = "EntityName", Width = 300 });
                tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "EntityCode", HeaderText = "EntityCode", Width = 200 });
                tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "EntityId", HeaderText = "EntityId", Width = -1 });
                tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "CoEntityId", HeaderText = "CoEntityId", Width = -1 });
                tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "Address1", HeaderText = "Address1", Width = 200 });
                tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "Address2", HeaderText = "Address1", Width = 200 });
                tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "Address3", HeaderText = "Address3", Width = 200 });
                tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "Tel1", HeaderText = "Tel1", Width = 200 });
                tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "Tel2", HeaderText = "Tel2", Width = 200 });
                tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "TownName", HeaderText = "TownName", Width = 200 });
                tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "CityName", HeaderText = "CityName", Width = 200 });
                tableStyle.GridColumnStyles.Add(new DataGridTextBoxColumn { MappingName = "CountryName", HeaderText = "CountryName", Width = 200 });
                GridSearch.TableStyles.Clear();
                GridSearch.TableStyles.Add(tableStyle);
                #endregion Column Style


                GridSearch.Refresh();
                Screens.HideWait();
            }
            catch (Exception exception)
            {
                Screens.Error(string.Concat("Cari bilgileri yuklenirken hata:", exception.Message));
            }
            finally
            {
                Screens.HideWait();
            }
        }

        private void cbMultiSelect_CheckStateChanged(object sender, EventArgs e)
        {

        }
        
    }
}