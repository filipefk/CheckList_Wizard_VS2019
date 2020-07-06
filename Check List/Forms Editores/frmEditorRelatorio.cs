using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using System.IO;
using System.Text;

namespace Check_List
{
    public partial class frmEditorRelatorio : Form
    {
        private DialogResult _Retorno = DialogResult.Cancel;
        private csListaItens _ListaCheckItens = null;
        int _ScrollLeft = 0;
        int _ScrollTop = 0;

        public frmEditorRelatorio()
        {
            InitializeComponent();
        }

        public DialogResult EditaRelatorio(object p_ListaCheckItens, string p_NomeRelatorio)
        {
            _ListaCheckItens = (csListaItens)p_ListaCheckItens;
            _Retorno = DialogResult.Cancel;
            foreach (csRelatorio Relatorio in _ListaCheckItens.ListaRelatorios)
            {
                if (Relatorio.Nome == p_NomeRelatorio)
                {
                    // Propriedades principais
                    ListViewItem lvwItem = null;
                    this.Text = Relatorio.Nome;
                    txtTexto.Text = Relatorio.Texto;
                    txtTexto.SelectionStart = 0;
                    txtTexto.SelectionLength = 0;
                    
                    // Lista de campos
                    csItem ItemCheckList = null;
                    lvwCampos.Items.Clear();
                    lvwItem = lvwCampos.Items.Add("VARIÁVEL MANUAL");
                    lvwItem.Tag = "{variavel=@}";
                    for (int i = 0; i < _ListaCheckItens.Count; i++)
                    {
                        ItemCheckList = (csItem)_ListaCheckItens.Itens[i];
                        lvwItem = lvwCampos.Items.Add(ItemCheckList.Nome);
                        lvwItem.Tag = "{" + ItemCheckList.Nome + "." + ItemCheckList.Descricao + "}";
                    }
                    this.ShowDialog();

                    if (_Retorno == DialogResult.OK)
                    {
                        Relatorio.Texto = txtTexto.Text;
                    }
                    return _Retorno;
                }
            }
            return _Retorno;
        }

        /// <summary>
        /// Salva um relatório em um arquivo temporário
        /// </summary>
        private string SalvaArquivoRelatorio(string p_Texto)
        {
            string _NomeArquivo = Path.GetTempPath() + "PreviewRelatorioCheckListWizard.htm";
            StreamWriter Escritor = new StreamWriter(_NomeArquivo, false, Encoding.Default);
            Escritor.Write(p_Texto);
            Escritor.Close();
            Escritor.Dispose();
            GC.Collect();
            return _NomeArquivo;
        }

        private void Preview(bool p_TelaCheia)
        {
            string _TextoPreview = _ListaCheckItens.TextoRelatorio(txtTexto.Text, !p_TelaCheia);
            string _NomeArquivo = this.SalvaArquivoRelatorio(_TextoPreview);
            
            try
            {
                _ScrollLeft = wbPreview.Document.Body.ScrollLeft;
            }
            catch (Exception)
            {
                _ScrollLeft = 0;
            }
            try
            {
                _ScrollTop = wbPreview.Document.Body.ScrollTop;
            }
            catch (Exception)
            {
                _ScrollTop = 0;
            }
            wbPreview.Navigate(_NomeArquivo);
            if (p_TelaCheia)
            {
                _ListaCheckItens.MostrarRelatorio(_NomeArquivo);
            }
            
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            _Retorno = DialogResult.OK;
            this.Close();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            _Retorno = DialogResult.Cancel;
            this.Close();
        }

        private void lvwCampos_DoubleClick(object sender, EventArgs e)
        {
            if (lvwCampos.SelectedIndices.Count > 0)
            {
                if (lvwCampos.SelectedItems[0].Tag.ToString() == "{variavel=@}")
                {
                    string _PerguntaVariavel = "";
                    DialogResult _Resp = DialogResult.None;
                    _Resp = csUtil.InputBox("Pergunta da variável Manual", "Qual pergunta deve ser feita para preencher esta variável?", ref _PerguntaVariavel);
                    if (_Resp == DialogResult.OK)
                    {
                        txtTexto.SelectedText = "{variavel=" + _PerguntaVariavel + "}";
                    }
                }
                else
                {
                    txtTexto.SelectedText = lvwCampos.SelectedItems[0].Tag.ToString();
                }
                txtTexto.Focus();
            }
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            if (chkPreviewOnLine.Checked)
            {
                this.Preview(false);
            }
        }

        private void wbPreview_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                wbPreview.Document.Body.ScrollLeft = _ScrollLeft;
            }
            catch (Exception)
            {

            }

            try
            {
                wbPreview.Document.Body.ScrollTop = _ScrollTop;
            }
            catch (Exception)
            {

            }
        }

        private void chkPreviewOnLine_CheckedChanged(object sender, EventArgs e)
        {
            this.Preview(false);
        }

        private void btPreview_Click(object sender, EventArgs e)
        {
            this.Preview(false);
        }

        private void btPreviewTelaCheia_Click(object sender, EventArgs e)
        {
            this.Preview(true);
        }

        private void txtTexto_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A: // Ctrl + A = Selecionar tudo
                    if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                    {
                        txtTexto.SelectAll();
                        e.SuppressKeyPress = true;
                    }
                    break;
            }
        }

    }
}
