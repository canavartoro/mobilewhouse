using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MobileWhouse.Util;
using MobileWhouse.Net;
using MobileWhouse.Models;
using MobileWhouse.Log;
using System.Threading;

namespace MobileWhouse.GUI
{
    public partial class UPrintControl : UserControl
    {
        public UPrintControl()
        {
            InitializeComponent();
        }

        public event EventHandler SelectedChanged;

        private string printerName = null;
        private string designName = null;

        private void LoadArguments()
        {
            try
            {
                Screens.ShowWait();
                if (Statics.Designs == null || Statics.Printers == null)
                {
                    using (TcpPrinterClient tcpprinter = new TcpPrinterClient())
                    {
                        PrintersDesigns prints = tcpprinter.GetPrintersDesigns();
                        if (prints != null && prints.Result)
                        {
                            Statics.Designs = prints.Designs;
                            LoadComboSource(cmbDesign, prints.Designs);
                            Statics.Printers = prints.Printers;
                            LoadComboSource(cmbPrinter, prints.Printers);
                        }
                    }
                }
                else
                {
                    LoadComboSource(cmbDesign, Statics.Designs);
                    LoadComboSource(cmbPrinter, Statics.Printers);
                }
            }
            catch (Exception exc)
            {
                Logger.E(exc);
            }
            finally
            {
                Screens.HideWait();
            }
        }

        private void LoadComboSource(Control cmb, List<string> items)
        {
            if (cmb.InvokeRequired)
            {
                LoadComboBoxDataSource p = new LoadComboBoxDataSource(LoadComboSource);
                this.Invoke(p, new object[] { cmb, items });
            }
            else
            {
                ComboBox combobox = cmb as ComboBox;
                if (combobox != null)
                {
                    string dval = "";
                    if (!string.IsNullOrEmpty(cmb.Name))
                    {
                        dval = AppCache.ReadCache(string.Concat(this.Name, cmb.Name), "");
                    }
                    int index = -1;
                    combobox.BeginUpdate();
                    combobox.Items.Clear();
                    for (int i = 0; i < items.Count; i++)
                    {
                        combobox.Items.Add(items[i]);
                        if (items[i] == dval)
                        {
                            index = i;
                            if (cmb.Name == "cmbDesign")
                            {
                                designName = dval;
                            }
                            else
                            {
                                printerName = dval;
                            }
                        }
                    }
                    combobox.SelectedIndex = index;
                    combobox.SelectedIndexChanged += new EventHandler(combobox_SelectedIndexChanged);
                    combobox.EndUpdate();
                }
            }
        }

        void combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ComboBox cmb = sender as ComboBox;
                if (!string.IsNullOrEmpty(cmb.Name))
                {
                    AppCache.WriteCache(string.Concat(this.Name, cmb.Name), cmb.Text);
                    if (cmb.Name == "cmbDesign")
                    {
                        designName = cmb.Text;
                    }
                    else
                    {
                        printerName = cmb.Text;
                    }
                    if (SelectedChanged != null) SelectedChanged(this, e);
                }
            }
            catch (Exception exc)
            {
                Logger.E(exc);
            }
        }

        private object _criteria = null;
        public void PrintAsync(string criteria)
        {
            _criteria = new string[] { cmbPrinter.Text, cmbDesign.Text, criteria };
            new Thread(new ThreadStart(Print)).Start();
        }

        public void Print()
        {
            lock (_criteria)
            {
                try
                {
                    string[] arguments = _criteria as string[];
                    using (TcpPrinterClient tcpprinter = new TcpPrinterClient())
                    {
                        PrintersDesigns print = tcpprinter.PrintServer("", arguments[0], arguments[1], arguments[2]);
                        if (print == null)
                        {
                            Screens.Error("Yazdırma işleminde bilinmeyen hata!");
                        }
                        if (print.Result)
                        {
                            //Screens.Error("Yazdırma işleminde başarılı");
                        }
                        else
                        {
                            Screens.Error(string.Concat("Yazdırma işleminde hata:", print.Massage));
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
                }
            }
        }

        public void Print(string criteria)
        {
            //_criteria = new string[] { cmbPrinter.Text, cmbDesign.Text, criteria };
            //new Thread(new ThreadStart(Print)).Start();
            try
            {
                if (string.IsNullOrEmpty(cmbDesign.Text))
                {
                    Screens.Error("Tasarım adı seçmediniz!");
                    cmbDesign.SelectAll();
                    cmbDesign.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(cmbPrinter.Text))
                {
                    Screens.Error("Yazıcı adı seçmediniz!");
                    cmbPrinter.SelectAll();
                    cmbPrinter.Focus();
                    return;
                }
                Screens.ShowWait();

                using (TcpPrinterClient tcpprinter = new TcpPrinterClient())
                {
                    PrintersDesigns print = tcpprinter.PrintServer("", cmbPrinter.Text, cmbDesign.Text, criteria);
                    if (print == null)
                    {
                        Screens.Error("Yazdırma işleminde bilinmeyen hata!");
                    }
                    if (print.Result)
                    {
                        //Screens.Error("Yazdırma işleminde başarılı");
                    }
                    else
                    {
                        Screens.Error(string.Concat("Yazdırma işleminde hata:", print.Massage));
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
            }
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(LoadArguments)).Start();
        }

        void UPrintControl_ParentChanged(object sender, System.EventArgs e)
        {
            if (!Utility.IsDesignMode)
            {
                new Thread(new ThreadStart(LoadArguments)).Start();
            }

        }

        public string PrinterName
        {
            get { return printerName; }
        }

        public string DesignName
        {
            get { return designName; }
        }

        public bool IsSelectPrinter
        {
            get { return !string.IsNullOrEmpty(printerName); }
        }

    }
}
