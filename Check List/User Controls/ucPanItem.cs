using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Check_List
{
    public delegate void AlterouAlgoItemEventHandler(ucPanItem sender, EventArgs e);

    public partial class ucPanItem : UserControl
    {
        public event AlterouAlgoItemEventHandler AlterouAlgo;

        protected virtual void OnAlterouAlgo(EventArgs e)
        {
            if (AlterouAlgo != null)
                AlterouAlgo(this, e);
        }

        private csItem _CheckItem = null;

        public ucPanItem()
        {
            InitializeComponent();
        }

        public object RetornaCheckItem()
        {
            return _CheckItem;
        }

        public void SetaCheckItem(object p_CheckItem)
        {
            _CheckItem = (csItem)p_CheckItem;
            //lblTipoItem.Text = _CheckItem.NomeTipo;
            lblNomeItem.Text = _CheckItem.Nome;
            lblDescricaoItem.Text = _CheckItem.Descricao;
            txtAjudaItem.Text = _CheckItem.Ajuda;
            txtObservacaoItem.Text = _CheckItem.Observacao;

            if (txtAjudaItem.Text.Trim().Length > 0)
            {
                while (txtAjudaItem.Lines.Length < 6)
                {
                    txtAjudaItem.Text = txtAjudaItem.Text + "\r\n";
                    if (txtAjudaItem.Lines.Length < 6)
                    {
                        txtAjudaItem.Text = "\r\n" + txtAjudaItem.Text;
                    }
                }
                while (txtAjudaItem.Text.Substring(txtAjudaItem.Text.Length - 1) == "\n" || txtAjudaItem.Text.Substring(txtAjudaItem.Text.Length - 1) == "\r")
                {
                    txtAjudaItem.Text = txtAjudaItem.Text.Substring(0, txtAjudaItem.Text.Length - 1);
                }
                
            }
            GC.Collect();
        }

        private void ucPanItem_Resize(object sender, EventArgs e)
        {
            this.Size = new Size(601, 432);
        }

        private void txtObservacaoItem_TextChanged(object sender, EventArgs e)
        {
            if (_CheckItem != null)
            {

                if (txtObservacaoItem.Text != _CheckItem.Observacao)
                {
                    _CheckItem.Observacao = txtObservacaoItem.Text;
                    this.OnAlterouAlgo(new EventArgs());
                }
            }
            GC.Collect();
        }

        private void txtAjudaItem_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(e.LinkText);
            }
            catch (Exception _Exception)
            {
                MessageBox.Show("Erro ao seguir link " + e.LinkText + "\n" + _Exception.ToString(), "Seguir Link", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
