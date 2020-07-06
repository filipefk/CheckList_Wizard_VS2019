using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Check_List
{
    public delegate void AlterouAlgoItemTextoEventHandler(ucPanItemTexto sender, EventArgs e);

    public partial class ucPanItemTexto : UserControl
    {
        ToolTip _ToolTipText = new ToolTip();

        public event AlterouAlgoItemTextoEventHandler AlterouAlgo;

        protected virtual void OnAlterouAlgo(EventArgs e)
        {
            if (AlterouAlgo != null)
                AlterouAlgo(this, e);
        }

        private csItemTexto _ItemTexto = null;

        public ucPanItemTexto()
        {
            InitializeComponent();
        }

        public object RetornaCheckItem()
        {
            return _ItemTexto;
        }

        public void SetaCheckItem(object p_ItemTexto)
        {
            _ItemTexto = (csItemTexto)p_ItemTexto;
            this.Atualizar();
        }

        public void Atualizar()
        {
            
            if (_ItemTexto != null)
            {
                if (_ItemTexto.Texto.Length > 0)
                {
                    txtItemTexto.Text = _ItemTexto.Texto;
                }
                else
                {
                    txtItemTexto.Text = _ItemTexto.TextoPadrao;
                }

                if (_ItemTexto.PermitirSalvarValorPadrao)
                {
                    btBuscarValorPadrao.Visible = true;
                    btSalvarValorPadrao.Visible = true;
                    txtItemTexto.Size = new Size(559, 161);
                    btBuscarValorPadrao.Enabled = _ItemTexto.TemValorPadrao;

                    
                }
                else
                {
                    btBuscarValorPadrao.Visible = false;
                    btSalvarValorPadrao.Visible = false;
                    txtItemTexto.Size = new Size(559, 190);
                }

            }
            else
            {
                txtItemTexto.Text = "";
            }
            
        }

        private void BuscarValorPadrao()
        {
            _ItemTexto.CarregaValorPadrao();
            if (_ItemTexto.Texto.Trim().Length > 0)
            {
                txtItemTexto.Text = _ItemTexto.Texto;
                this.OnAlterouAlgo(new EventArgs());
            }
            else
            {
                txtItemTexto.Text = _ItemTexto.TextoPadrao;
            }
        }

        private void ucPanItemTexto_Resize(object sender, EventArgs e)
        {
            this.Size = new Size(601, 196);
        }

        private void txtItemTexto_TextChanged(object sender, EventArgs e)
        {
            if (txtItemTexto.Text == _ItemTexto.TextoPadrao)
	        {
                if (_ItemTexto.Texto != "")
                {
                    this.OnAlterouAlgo(new EventArgs());
                }
                _ItemTexto.Texto = "";
	        }
            else
            {
                if (_ItemTexto.Texto != txtItemTexto.Text)
                {
                    this.OnAlterouAlgo(new EventArgs());
                }
                _ItemTexto.Texto = txtItemTexto.Text;
            }
            
        }

        private void txtItemTexto_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Back: // Ctrl + Backspace = Retornar texto padrão
                    if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                    {
                        btTextoPadrao_Click(sender, e);
                    }
                    break;
                case Keys.A: // Ctrl + A = Selecionar tudo
                    if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                    {
                        txtItemTexto.SelectAll();
                        e.SuppressKeyPress = true;
                    }
                    break;
            }
        }

        private void btSalvarValorPadrao_Click(object sender, EventArgs e)
        {
            _ItemTexto.SalvarValorPadrao();
            btBuscarValorPadrao.Enabled = _ItemTexto.TemValorPadrao;
        }

        private void btBuscarValorPadrao_Click(object sender, EventArgs e)
        {
            this.BuscarValorPadrao();
        }

        private void btTelaCheia_Click(object sender, EventArgs e)
        {
            frmTextoGrande _FormTextoGrande = new frmTextoGrande();
            string _Texto = txtItemTexto.Text;
            DialogResult _Retorno;
            _Retorno = _FormTextoGrande.EditaTexto(ref _Texto, _ItemTexto.Descricao);
            if (_Retorno == DialogResult.OK)
            {
                txtItemTexto.Text = _Texto;
            }
        }

        private void btTextoPadrao_Click(object sender, EventArgs e)
        {
            if (txtItemTexto.Text == _ItemTexto.TextoPadrao)
            {
                MessageBox.Show("O texto atual é igual ao texto padrão!", "Texto Padrão", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            DialogResult _Resp;
            if (_ItemTexto.TextoPadrao.Trim().Length == 0)
            {
                _Resp = MessageBox.Show("O texto padrão é em branco. Deseja limpar o texto?", "Texto Padrão", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (_Resp == DialogResult.Yes)
                {
                    txtItemTexto.Text = _ItemTexto.TextoPadrao;
                }
                return;
            }
            _Resp = MessageBox.Show("Deseja retornar o texto padrão?", "Texto Padrão", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (_Resp == DialogResult.Yes)
            {
                txtItemTexto.Text = _ItemTexto.TextoPadrao;
                return;
            }
        }
        
        private void btBuscarValorPadrao_MouseEnter(object sender, EventArgs e)
        {
            if (_ItemTexto.TemValorPadrao && !_ItemTexto.Preenchido)
            {
                _ToolTipText.IsBalloon = true;
                _ToolTipText.UseAnimation = true;
                _ToolTipText.UseFading = true;
                _ToolTipText.Show(string.Empty, this, 0, 0);
                _ToolTipText.Show("Clique aqui para adicionar o texto padrão:\n" + _ItemTexto.ValorPadrao, btBuscarValorPadrao, 0, -60, 2000);
            }
        }

        private void btSalvarValorPadrao_MouseEnter(object sender, EventArgs e)
        {
            if (!_ItemTexto.TemValorPadrao && !_ItemTexto.Preenchido)
            {
                _ToolTipText.IsBalloon = true;
                _ToolTipText.UseAnimation = true;
                _ToolTipText.UseFading = true;
                _ToolTipText.Show(string.Empty, this, 0, 0);
                _ToolTipText.Show("Digite um texto e clique aqui para salvar como texto padrão", btSalvarValorPadrao, 0, -45, 2000);
            }
        }

        private void btSalvarValorPadrao_MouseLeave(object sender, EventArgs e)
        {
            _ToolTipText.Hide(btSalvarValorPadrao);
        }

        private void btBuscarValorPadrao_MouseLeave(object sender, EventArgs e)
        {
            _ToolTipText.Hide(btBuscarValorPadrao);
        }
    }
}
