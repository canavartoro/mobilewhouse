<%@ Page Language="C#" AutoEventWireup="true" %>

<!DOCTYPE html>
<%@ Import Namespace="System.IO" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script runat="server">

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Response.Cache.SetCacheability(HttpCacheability.NoCache);

                // Is this required for FireFox? Would be good to do this without magic strings.
                // Won't it overwrite the previous setting
                Response.Headers.Add("Cache-Control", "no-cache, no-store");

                // Why is it necessary to explicitly call SetExpires. Presume it is still better than calling
                // Response.Headers.Add( directly
                Response.Cache.SetExpires(DateTime.UtcNow.AddYears(-1));

                PopulateTree();

                txtversion.Text = GetCurrentVersion();
            }
        }

        private void PopulateTree()
        {
            try
            {
                //Populate the tree based on the subfolders of the specified VirtualImageRoot
                var rootFolder = new DirectoryInfo(HttpContext.Current.Server.MapPath($"~/Log/"));
                var root = AddNodeAndDescendents(rootFolder, null);

                //Add the root to the TreeView
                treelogs.Nodes.Add(root);
                treelogs.CollapseAll();
            }
            catch (Exception exc)
            {
                lblerror.Text = string.Concat("Loglar yüklenemedi! Hata: ", exc.Message, ", Detay:", exc.StackTrace);
            }
        }

        private TreeNode AddNodeAndDescendents(DirectoryInfo folder, TreeNode parentNode)
        {
            //Add the TreeNode, displaying the folder's name and storing the full path to the folder as the value...
            string virtualFolderPath;
            bool root = false;
            if (parentNode == null)
            {
                virtualFolderPath = HttpContext.Current.Server.MapPath($"~/Log/");
                root = true;
            }
            else
            {
                virtualFolderPath = parentNode.Value + folder.Name + "/";
            }

            var node = new TreeNode(folder.Name, virtualFolderPath);
            if (root)
            {

                DirectoryInfo logDir = new DirectoryInfo(virtualFolderPath);
                foreach (FileInfo file in logDir.GetFiles())
                {
                    var index = file.FullName.LastIndexOf(@"\", StringComparison.Ordinal);
                    var strname = file.FullName.Substring(index + 1);
                    var name = strname.Split('.');

                    var tn = new TreeNode();
                    if (name.Length > 1 && name[1].ToLower() == "bch")
                    {
                        tn = new TreeNode(name[0], file.FullName);
                    }
                    else
                    {
                        tn = new TreeNode(name[0], file.FullName);
                    }
                    node.ChildNodes.Add(tn);
                }
            }

            //Recurse through this folder's subfolders
            var subFolders = folder.GetDirectories();

            foreach (DirectoryInfo subFolder in subFolders)
            {
                if (subFolder.Name == ".svn") continue;
                var child = AddNodeAndDescendents(subFolder, node);
                foreach (FileInfo file in subFolder.GetFiles())
                {

                    var index = file.FullName.LastIndexOf(@"\", StringComparison.Ordinal);
                    var strname = file.FullName.Substring(index + 1);
                    var name = strname.Split('.');

                    var tn = new TreeNode();
                    if (name.Length > 1 && name[1].ToLower() == "bch")
                    {
                        tn = new TreeNode(name[0], file.FullName);
                    }
                    else
                    {
                        tn = new TreeNode(name[0], file.FullName);
                    }
                    child.ChildNodes.Add(tn);
                }
                node.ChildNodes.Add(child);

            }
            //Return the new TreeNode
            return node;
        }


        protected void treelogs_SelectedNodeChanged(object sender, EventArgs e)
        {
            try
            {
                if (treelogs.SelectedNode != null && treelogs.SelectedNode.Value != null)
                {
                    if (File.Exists(treelogs.SelectedNode.Value.ToString()))
                    {
                        lblerror.Text = File.ReadAllText(treelogs.SelectedNode.Value.ToString());
                    }
                }
            }
            catch (Exception exc)
            {
                lblerror.Text = string.Concat("Log dosyası okunamadı! Hata: ", exc.Message, ", Detay:", exc.StackTrace);
            }
        }

        protected void btnsil_Click(object sender, EventArgs e)
        {
            try
            {
                if (treelogs.SelectedNode != null && treelogs.SelectedNode.Value != null)
                {
                    if (File.Exists(treelogs.SelectedNode.Value.ToString()))
                    {
                        File.Delete(treelogs.SelectedNode.Value.ToString());
                    }
                }
            }
            catch (Exception exc)
            {
                lblerror.Text = string.Concat("Log dosyası silinemedi! Hata: ", exc.Message, ", Detay:", exc.StackTrace);
            }
        }

        protected void btnupload_Click(object sender, EventArgs e)
        {
            if (fileapk.HasFile)
            {
                try
                {
                    if (fileapk.PostedFile.ContentType == "application/octet-stream" ||
                        fileapk.PostedFile.ContentType == "application/vnd.android.package-archive" ||
                        fileapk.PostedFile.ContentType == "application/x-zip-compressed")
                    {
                        if (fileapk.PostedFile.ContentLength < 30000000)
                        {
                            if (File.Exists(HttpContext.Current.Server.MapPath($"~/uyumsoft.zip")))
                            {
                                File.Copy(HttpContext.Current.Server.MapPath($"~/uyumsoft.zip"), HttpContext.Current.Server.MapPath($"~/uyumsoft_{DateTime.Now.ToString("yyyyMMddHHmmss")}.zip"));
                                //File.Delete(HttpContext.Current.Server.MapPath($"~/uyumsoft.apk"));
                            }

                            fileapk.SaveAs(Server.MapPath("~/uyumsoft.zip")); //+ fileapk.FileName);
                            StringBuilder sb = new StringBuilder();
                            sb.Append("Dosya yüklendi.").Append("Dosya Adı: ")
                                .Append(fileapk.PostedFile.FileName).Append("<br />Dosya Boyutu: ")
                                .Append(fileapk.PostedFile.ContentLength).Append("<br />Dosya Türü: ")
                                .Append(fileapk.PostedFile.ContentType);
                            lblerror.Text = sb.ToString();
                        }
                        else
                        {
                            lblerror.Text = "Maksimum boyut 30 MB olmalı.";
                        }
                    }
                    else
                    {
                        lblerror.Text = "Apk dosyası seçin.";
                    }

                }
                catch (Exception ex)
                {
                    lblerror.Text = "Hata Oluştu: " + ex.Message.ToString();
                }
            }
            else
            {
                lblerror.Text = "Dosya Seçin ve Dosya Yükle Butonuna Tıklayın.";
            }
        }

        protected void btnversion_Click(object sender, EventArgs e)
        {
            var revinifile = HttpContext.Current.Server.MapPath($"~/MobileWhouse.ini");
            UstunWebService.Helpers.SarfCikisHelper.WritePrivateProfileString("APPLICATION", "VERSION", txtversion.Text, revinifile);
        }

        private string GetCurrentVersion()
        {
            var revinifile = HttpContext.Current.Server.MapPath($"~/MobileWhouse.ini");
            StringBuilder temp = new StringBuilder(255);
            int i = UstunWebService.Helpers.SarfCikisHelper.GetPrivateProfileString("APPLICATION", "VERSION", "2.0.0.0", temp, 255, revinifile);
            if (i == 0)
            {
                UstunWebService.Helpers.SarfCikisHelper.WritePrivateProfileString("APPLICATION", "VERSION", "2.0.0.0", revinifile);
            }
            return temp.ToString();
        }
    </script>
</head>
<body style="padding:0px;margin:0px;">
    <form id="form1" runat="server" style="padding:0px;margin:0px;">
        <div>
            <div style="width: 98%; margin-top: 5px;  height: 40px; background: #cccccc; text-align: center; color: black; padding: 8px;">
                Hata Log Kayıtları
            </div>
            <div style="width: 100%; display: flex; margin-top: 5px; ">
                <div id="sol" style="border: 1px solid #cccccc; overflow: auto;">
                    <asp:TreeView runat="server" ID="treelogs" style="width:400px;"
                        OnSelectedNodeChanged="treelogs_SelectedNodeChanged" 
                        EnableClientScript="true" ShowExpandCollapse="true">
                        <Nodes>
                        </Nodes>
                    </asp:TreeView>
                    <div id="sag" style="padding:8px;">
                        <p>Program kurulumu için önce <strong>MWS.CAB</strong> dosyasını indirin ve cihaza kurun</p>
                        <ol type="1">
                            <li><a href="MWS.CAB">Kurulum Dosyası İndir</a></li>
                            <li><a href="uyumsoft.zip">Güncelleme Dosyası İndir</a></li>
                            <li><a href="NETCFv1.WM.ARMV4I.CAB">NETCF for Windows Mobile indir</a></li>
                            <li><a href="NETCFv2.wce5.armv4i.cab">Windows CE ARM indir</a></li>
                            <li><a href="sql.wce5.armv4i.CAB">Windows CE.NET Framework (ARM) indir</a></li>
                            <li ><a href="System_SR_ENU.cab">Windows CE.NET Frame Work indir</a></li>
                        </ol>
                    </div>
                </div>
                <div style="width: 83%; border: 1px solid #cccccc; margin-left: 2px;">
                    <asp:Label runat="server" ID="lblerror"></asp:Label>
                </div>
            </div>
            <div style="width: 98%; margin-top: 10px; height: 20px; background: #f3f1f1; text-align: right; color: black; padding: 2px;">
                <asp:TextBox runat="server" ID="txtversion" Width="50px" />
                <asp:Button runat="server" ID="btnversion" Text="Versiyon Güncelle" OnClick="btnversion_Click"  Width="150px" />
                <asp:FileUpload runat="server" ID="fileapk" Width="200" />
                <asp:Button runat="server" ID="btnupload" Text="Dosya Yükle" OnClick="btnupload_Click" />
                <asp:Button runat="server" ID="btnsil" Text="Seçilen Dosyayı Sil" OnClick="btnsil_Click" />
            </div>
        </div>
    </form>
<script>
if(window.innerWidth>300)
{
	var tut = document.getElementById('sol');
	tut.style.width = '15%';
	tut = document.getElementById('sag');
	tut.style.width = '85%';
}else{
	var tut = document.getElementById('sol');
	tut.style.width = '99%';
	tut = document.getElementById('sag');
	tut.style.width = '1%';
}

</script>
</body>
</html>
