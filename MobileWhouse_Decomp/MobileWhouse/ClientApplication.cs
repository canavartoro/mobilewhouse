namespace MobileWhouse
{
    using MobileWhouse.Properties;
    using UyumConnector;
    using System;
    using System.Globalization;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    internal class ClientApplication
    {
        private LoginResult _ClientToken;
        private CultureInfo _Culture;
        private static ClientApplication _Instance;
        private FormMain _MainForm;
        private Depot _SelectedDepot;
        private MobileWhouse _Service;
        private Token _Token;

        public event EventHandler SelectedDepotChanged;

        public ClientApplication()
        {
            _Instance = this;
        }

        public void Run()
        {
            Settings settings = new Settings();
            settings.Load();
            this._Service = new MobileWhouse();
            this._Service.Url = settings.WebServiceUrl;
            this._Culture = new CultureInfo(0x41f);
            FormLogin login = new FormLogin();
            DialogResult result = login.ShowDialog();
            login.Dispose();
            if ((result == DialogResult.OK) && (this._ClientToken != null))
            {
                try
                {
                    using (this._MainForm = new FormMain())
                    {
                        this._MainForm.Text = Instance.Token.BranchDesc;
                        this._MainForm.ShowDialog();
                    }
                }
                catch (Exception exception)
                {
                    ShowError(exception);
                }
            }
        }

        public static void ShowError(Exception ex)
        {
            MessageBox.Show(string.Format(Resources.Err_GenericException, ex.Message), Resources.Err_Error);
        }

        public static void ShowError(string message)
        {
            MessageBox.Show(message, Resources.Err_Error);
        }

        public LoginResult ClientToken
        {
            get
            {
                return this._ClientToken;
            }
            set
            {
                this._ClientToken = value;
            }
        }

        public CultureInfo Culture
        {
            get
            {
                return this._Culture;
            }
        }

        public static ClientApplication Instance
        {
            get
            {
                return _Instance;
            }
        }

        public FormMain MainForm
        {
            get
            {
                return this._MainForm;
            }
        }

        public Depot SelectedDepot
        {
            get
            {
                return this._SelectedDepot;
            }
            set
            {
                this._SelectedDepot = value;
                if (this.SelectedDepotChanged != null)
                {
                    this.SelectedDepotChanged(this, EventArgs.Empty);
                }
            }
        }

        public MobileWhouse Service
        {
            get
            {
                return this._Service;
            }
        }

        public Token Token
        {
            get
            {
                return this._Token;
            }
            set
            {
                this._Token = value;
            }
        }
    }
}

