using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MobileWhouse.Controls;
using MobileWhouse.UyumConnector;
using MobileWhouse.Util;

namespace MobileWhouse
{
    public partial class FormMain : Form
    {
        private MainScreen _ButtonPanel;
        private BaseControl _SelectedPage;

        public BaseControl SelectedPage
        {
            get
            {
                return _SelectedPage;
            }
            set
            {
                try
                {
                    if (_SelectedPage != null)
                    {
                        _SelectedPage.Parent = null;
                        _SelectedPage.Dispose();
                    }
                    _SelectedPage = value;
                    if (_SelectedPage != null)
                    {
                        _ButtonPanel.Visible = false;
                        _SelectedPage.Dock = DockStyle.Fill;
                        _SelectedPage.MainForm = this;
                        _SelectedPage.Parent = pnlContainer;
                    }
                    else
                    {
                        _ButtonPanel.Visible = true;
                        _ButtonPanel.Focus();
                    }
                }
                catch (Exception exc)
                {
                    MobileWhouse.Util.Screens.Error(exc);
                }
            }
        }

        public FormMain()
        {
            InitializeComponent();

            _ButtonPanel = new MainScreen();
            _ButtonPanel.MainForm = this;
            _ButtonPanel.Dock = DockStyle.Fill;
            _ButtonPanel.Parent = pnlContainer;
            if (Utility.IsWindowsCE)
            {
                _ButtonPanel.KeyUp += new KeyEventHandler(_ButtonPanel.BaseControl_KeyUp);
                foreach (Control c in _ButtonPanel.Controls)
                {
                    if (c.GetType().ToString().Equals("System.Windows.Forms.Button"))
                    {
                        c.KeyUp += new KeyEventHandler(_ButtonPanel.BaseControl_KeyUp);
                    }
                }
            }
            _ButtonPanel.Focus();
        }

        public void ShowControl(BaseControl control)
        {
            if (!object.ReferenceEquals(control, null))
            {
                object[] attr = control.GetType().GetCustomAttributes(typeof(MobileWhouse.Attributes.UyumModuleAttribute), false);
                if (attr != null && attr.Length > 0)
                {
                    MobileWhouse.Attributes.UyumModuleAttribute mod = attr[0] as MobileWhouse.Attributes.UyumModuleAttribute;
                    this.Text = string.Concat(mod.ModuleCaption, " [", mod.ModuleName, "]");
                }
            }
            else
            {
                this.Text = ClientApplication.Instance.ClientToken.BranchDesc;
            }
            SelectedPage = control;
        }

        public void ProcessBarkod(BarkodTextBox textBox, string barkod)
        {
            if (string.IsNullOrEmpty(barkod))
            {
                return;
            }
            if (SelectedPage == null)
            {
                return;
            }


            if ((barkod.StartsWith(ClientApplication.Instance.ClientToken.RafPrefix)) || (textBox.IsRaf == 1))
            {
                ServiceRequestOfItemSelectParam req = new ServiceRequestOfItemSelectParam();
                req.Token = ClientApplication.Instance.Token;
                if (barkod.StartsWith(ClientApplication.Instance.ClientToken.RafPrefix))
                {
                    barkod = barkod.Substring(ClientApplication.Instance.ClientToken.RafPrefix.Length);
                }
                req.Value = new ItemSelectParam();
                req.Value.DepotId = textBox.DepoId;
                req.Value.Barkod = barkod;

                ServiceResultOfNameIdItem result = ClientApplication.Instance.Service.GetRafInfo(req);
                if (!result.Result)
                    throw new Exception(result.Message);
                SelectedPage.OnRafBarkod(result.Value);
            }
            else
            {
                ServiceRequestOfItemSelectParam req = new ServiceRequestOfItemSelectParam();
                req.Token = ClientApplication.Instance.Token;
                req.Value = new ItemSelectParam();
                req.Value.Barkod = barkod;
                if (ClientApplication.Instance.SelectedDepot != null)
                    req.Value.DepotId = ClientApplication.Instance.SelectedDepot.Id;
                ServiceResultOfItemInfo result = ClientApplication.Instance.Service.GetItemInfo(req);
                if (!result.Result)
                    throw new Exception(result.Message);
                SelectedPage.OnItemBarkod(result.Value);
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            try
            {
                AutoScaleMode = AutoScaleMode.Dpi;
                WindowState = FormWindowState.Normal;
                Location = new Point(0, 0);

                if (Screens.BuyukEkran)
                    Size = new Size(800, 480);

                /*MobileWhouse.ProdConnector.ServiceRequestOfTransferMInfo param = new MobileWhouse.ProdConnector.ServiceRequestOfTransferMInfo();
                param.Token = new MobileWhouse.ProdConnector.Token();
                param.Token.UserName = "terminal";
                param.Token.Password = "1";
                param.Token.BranchId = 6749;
                param.Token.CoId = 2715;
                param.Token.BranchCode = "100";
                param.Value = new MobileWhouse.ProdConnector.TransferMInfo();
                param.Value.Id = 285;
                param.Value.DocDate = new DateTime(2021, 10, 21);
                param.Value.TransferWhouseId = 3680;
                param.Value.WhouseId = 3683;
                param.Value.WoTypeId = 9;
                param.Value.IsChangeMatrlTrnType = false;
                param.Value.IsOut = false;
                param.Value.IsTransferDCreate = true;
                param.Value.MaterielDistributedType = 1;
                param.Value.WorderMatrlTrnTraceType = 1;
                param.Value.WorderMatrlTrnType = 2;
                //param.Value.DocTraId = 1332;
                param.Value.TransferWorderList = new MobileWhouse.ProdConnector.TransferWorderInfo[1];
                param.Value.TransferWorderList[0] = new MobileWhouse.ProdConnector.TransferWorderInfo();
                param.Value.TransferWorderList[0].TransferDId = 531;
                param.Value.TransferWorderList[0].ItemId = 124589;
                param.Value.TransferWorderList[0].LineNo = 10;
                param.Value.TransferWorderList[0].Qty = 10;
                param.Value.TransferWorderList[0].QtyTrailing = 10;
                param.Value.TransferWorderList[0].UnitId = 165;
                param.Value.TransferWorderList[0].WorderItemId = 131513;
                param.Value.TransferWorderList[0].WorderMId = 4092;
                param.Value.TransferWorderList[0].WorderMQty = 10;
                param.Value.TransferWorderList[0].WorderUnitId = 166;
                param.Value.TransferWorderList[0].BwhLocationOutId = 163;

                MobileWhouse.ProdConnector.ServiceResultOfTransferMInfo result = ClientApplication.Instance.ProdService.PrdTransfer(param);
                if (result != null)
                {
                }*/
                string selectedDepot = FileHelper.ReadFile("selectedDepot.xml");
                if (!string.IsNullOrEmpty(selectedDepot))
                {
                    ClientApplication.Instance.SelectedDepot = FileHelper.FromXml(selectedDepot, typeof(Depot)) as Depot;
                    if (ClientApplication.Instance.SelectedDepot == null)
                    {
                        FileHelper.DeleteFile("selectedDepot.xml");
                    }
                }
            }
            catch
            {
                FileHelper.DeleteFile("selectedDepot.xml");
            }
        }
    }
}