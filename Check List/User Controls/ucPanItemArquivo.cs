using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Check_List
{
    public delegate void AlterouAlgoItemArquivoEventHandler(ucPanItemArquivo sender, EventArgs e);

    public partial class ucPanItemArquivo : UserControl
    {
        public event AlterouAlgoItemArquivoEventHandler AlterouAlgo;

        protected virtual void OnAlterouAlgo(EventArgs e)
        {
            if (AlterouAlgo != null)
                AlterouAlgo(this, e);
        }

        private csItemArquivo _ItemArquivo = null;

        public ucPanItemArquivo()
        {
            InitializeComponent();
        }

        public object RetornaCheckItem()
        {
            return _ItemArquivo;
        }

        public void SetaCheckItem(object p_ItemArquivo)
        {
            _ItemArquivo = (csItemArquivo)p_ItemArquivo;
            this.Atualizar();
        }

        public void Atualizar()
        {
            txtItemArquivo.Text = "";
            lblTamanhoArquivo.Text = "Tamanho: 0,00Kb";
            if (_ItemArquivo != null)
            {
                float TamanhoKB = 0;
                txtItemArquivo.Text = _ItemArquivo.CaminhoCompletoOrigem;
                TamanhoKB = (_ItemArquivo.TamanhoArquivo / 1024);
                lblTamanhoArquivo.Text = string.Format("Tamanho: {0:#,0.00}Kb", TamanhoKB);
            }
            
        }
        private void ucPanItemArquivo_Resize(object sender, EventArgs e)
        {
            this.Size = new Size(601, 196);
        }

        private void btAbrirArquivo_Click(object sender, EventArgs e)
        {
            _ItemArquivo.EscolherArquivoECarregar();
            this.Atualizar();
            this.OnAlterouAlgo(new EventArgs());
        }

        private void btSalvarArquivo_Click(object sender, EventArgs e)
        {
            if (_ItemArquivo.TamanhoArquivo > 0)
            {
                _ItemArquivo.EscolherDestinoESalvar();
            }
            else
            {
                MessageBox.Show("Nenhum arquivo carregado para salvar!", "Salvar arquivo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            if (_ItemArquivo.TamanhoArquivo > 0)
            {
                DialogResult Resp;
                Resp = MessageBox.Show("Excluir o arquivo?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Resp == DialogResult.Yes)
                {
                    _ItemArquivo.ExcluirArquivo();
                    this.OnAlterouAlgo(new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Nenhum arquivo carregado para salvar!", "Salvar arquivo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
