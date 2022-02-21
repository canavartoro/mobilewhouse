using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MobileWhouse.UyumConnector;

namespace MobileWhouse.Dilogs
{
    public partial class FormSelectRaf: Form
    {
        public NameIdItem Selected
        {
            get
            {
                if (DialogResult == DialogResult.OK
                    && trvRaflar.SelectedNode != null)
                {
                    return trvRaflar.SelectedNode.Tag as NameIdItem;
                }
                return null;
            }
        }

        private Depot _Depot;

        public FormSelectRaf()
        {
            InitializeComponent();
        }

        public FormSelectRaf(Depot depot)
        {
            InitializeComponent();
            _Depot = depot;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (_Depot == null)
                {
                    throw new Exception("Depo secmediniz");
                }

                ServiceRequestOfSelectParam param = new ServiceRequestOfSelectParam();
                param.Token = ClientApplication.Instance.Token;
                param.Value = new SelectParam();
                param.Value.Filter = txtName.Text;
                param.Value.DepotId = _Depot.Id;

                ServiceResultOfListOfNameIdItem raflar = ClientApplication.Instance.Service.GetRaflar(param);
                if (!raflar.Result)
                {
                    throw new Exception(raflar.Message);
                }

                trvRaflar.BeginUpdate();
                trvRaflar.Nodes.Clear();
                TreeNodeCollection nodes = trvRaflar.Nodes;
                for (int i = 0; i < raflar.Value.Length; i++)
                {
                    _AddToNodes(nodes, raflar.Value[i].Name, raflar.Value[i]);
                }
            }
            catch (Exception ex)
            {
                MobileWhouse.Util.Screens.Error(ex);
            }
            finally
            {
                trvRaflar.EndUpdate();
                Cursor.Current = Cursors.Default;
            }
        }

        private void _AddToNodes(TreeNodeCollection nodes, string text, NameIdItem raf)
        {
            int index = text.IndexOf("-");
            if (index < 0)
            {
                TreeNode node = new TreeNode(text);
                node.Tag = raf;
                nodes.Add(node);
            }
            else {
                string part1 = text.Substring(0, index);
                TreeNode node = _SearchNode(nodes, part1);
                string part2 = text.Substring(index + 1, text.Length - index - 1);
                if (node == null)
                {
                    node = new TreeNode(part1);
                    _AddToNodes(node.Nodes, part2, raf);
                    nodes.Add(node);
                }
                else
                {
                    _AddToNodes(node.Nodes, part2, raf);
                }
            }
        }

        private TreeNode _SearchNode(TreeNodeCollection nodes, string part1)
        {
            for (int i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].Text.Equals(part1))
                {
                    return nodes[i];
                }
            }
            return null;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnTre_Click(object sender, EventArgs e)
        {
            txtName.Text += "-";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}