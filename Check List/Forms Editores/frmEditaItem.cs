using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Check_List
{
    /// <summary>
    /// Formulário para criação e edição de itens individuais.
    /// </summary>
    /// <remarks>
    /// Autor: Filipe Kanitz
    /// Data: 10/09/2011
    /// </remarks>
    public partial class frmEditaItem : Form
    {
    #region Campos Privados
        private object _CheckListItem = null;
    #endregion

    #region Construtores
        public frmEditaItem()
        {
            InitializeComponent();

            this.Size = new Size(540, 554);

            gbxArquivo.Size = new Size(515, 257);
            gbxTexto.Size = new Size(515, 257);
            gbxOpcoes.Size = new Size(515, 257);
            gbxDataHora.Size = new Size(515, 257);

            gbxArquivo.Location = new Point(12, 218);
            gbxTexto.Location = new Point(12, 218);
            gbxOpcoes.Location = new Point(12, 218);
            gbxDataHora.Location = new Point(12, 218);

            cboTipo.SelectedIndex = 0;
            this.LimpaCampos();
            this.PreencheOpcoesTiposArquivos();
        }
    #endregion

    #region Métodos Privados
        /// <summary>
        /// Remove o conteúdo de todos os campos da tela
        /// </summary>
        private void LimpaCampos()
        {
            cboTipo.SelectedIndex = 0;
            txtNome.Text = "";
            txtDescricao.Text = "";
            txtAjuda.Text = "";
            lvwTiposArquivos.Items.Clear();
            lvwOpcoes.Items.Clear();
            chkMultiplaEscolha.Checked = false;
            chkObsObrigatorio.Checked = false;
            txtTextoPadrao.Text = "";
            cboDescricaoTipoArquivo.Text = "";
            txtTiposArquivos.Text = "";
            txtNomeOpcao.Text = "";
            chkOpcaoPadrao.Checked = false;
        }

        /// <summary>
        /// Preenche a combo com as opções padrão de tipos de arquivos fornecidas por csFiltrosArquivos
        /// </summary>
        /// <remarks>
        /// O método estático de csFiltrosArquivos.ListaDeFiltrosPadrao busca a lista de arquivos padrão
        /// da pasta do EXE arquivo ListaDeFiltrosPadrao.txt
        /// </remarks>
        private void PreencheOpcoesTiposArquivos()
        {
            cboDescricaoTipoArquivo.Items.Clear();
            ArrayList Filtros = csFiltrosArquivos.ListaDeFiltrosPadrao;
            foreach (csFiltroArquivo Filtro in Filtros)
            {
                cboDescricaoTipoArquivo.Items.Add(Filtro);
            }
        }
    #endregion

    #region Métodos Públicos
        /// <summary>
        /// Mostra a tela com campos vazius, pronta para um novo item
        /// </summary>
        public object InserirNovoCheckItem()
        {
            this.LimpaCampos();
            cboTipo.Enabled = true;
            _CheckListItem = null;
            cboTipo.SelectedIndex = 0;
            //this.TopMost = true;
            this.ShowDialog();


            return _CheckListItem;
        }

        /// <summary>
        /// Mostra a tela com campos preenchidos com os dados de P_CheckItem
        /// </summary>
        public object EditarCheckItem(object p_CheckItem)
        {
            ListViewItem lvwItem;
            this.LimpaCampos();
            cboTipo.Enabled = false;

            _CheckListItem = p_CheckItem;

            csListaItens _ListaItens = new csListaItens();

            switch (_ListaItens.TipoCheckItem(_CheckListItem))
            {
                //case csListaItens.enuTipoCheckIten.Arquivo:
                //    csItemArquivo ItemArquivo = (csItemArquivo)_CheckListItem;
                //    cboTipo.SelectedIndex = 0;
                //    txtNome.Text = ItemArquivo.Nome;
                //    txtDescricao.Text = ItemArquivo.Descricao;
                //    txtAjuda.Text = ItemArquivo.Ajuda;
                //    chkObsObrigatorio.Checked = ItemArquivo.ObservacaoObrigatoria;
                //    foreach (csFiltroArquivo Filtro in ItemArquivo.FiltrosArquivos.ListaFiltros)
                //    {
                //        lvwItem = lvwTiposArquivos.Items.Add(Filtro.Descricao);
                //        lvwItem.SubItems.Add(Filtro.Tipos);
                //    }
                //    break;

                case csListaItens.enuTipoCheckIten.ListaDeArquivos:
                    csItemListaArquivos ItemListaArquivos = (csItemListaArquivos)_CheckListItem;
                    cboTipo.SelectedIndex = 0;
                    txtNome.Text = ItemListaArquivos.Nome;
                    txtDescricao.Text = ItemListaArquivos.Descricao;
                    txtAjuda.Text = ItemListaArquivos.Ajuda;
                    chkObsObrigatorio.Checked = ItemListaArquivos.ObservacaoObrigatoria;
                    foreach (csFiltroArquivo Filtro in ItemListaArquivos.FiltrosArquivos.ListaFiltros)
                    {
                        lvwItem = lvwTiposArquivos.Items.Add(Filtro.Descricao);
                        lvwItem.SubItems.Add(Filtro.Tipos);
                    }
                    this.AtualizarListaArquivos();
                    break;

                case csListaItens.enuTipoCheckIten.ListaDeOpcoes:
                    csItemListaOpcoes ItemListaOpcoes = (csItemListaOpcoes)_CheckListItem;
                    cboTipo.SelectedIndex = 1;
                    txtNome.Text = ItemListaOpcoes.Nome;
                    txtDescricao.Text = ItemListaOpcoes.Descricao;
                    txtAjuda.Text = ItemListaOpcoes.Ajuda;
                    chkObsObrigatorio.Checked = ItemListaOpcoes.ObservacaoObrigatoria;
                    chkMultiplaEscolha.Checked = ItemListaOpcoes.MultiplaEscolha;
                    string OpcaoPadrao;
                    foreach (csOpcao Opcao in ItemListaOpcoes.Opcoes)
                    {
                        lvwItem = lvwOpcoes.Items.Add(Opcao.Texto);
                        if (Opcao.Padrao)
                        {
                            OpcaoPadrao = "Sim";
                        }
                        else
                        {
                            OpcaoPadrao = "Não";
                        }
                        lvwItem.SubItems.Add(OpcaoPadrao);
                    }
                    break;

                case csListaItens.enuTipoCheckIten.Texto:
                    csItemTexto ItemTexto = (csItemTexto)_CheckListItem;
                    cboTipo.SelectedIndex = 2;
                    txtNome.Text = ItemTexto.Nome;
                    txtDescricao.Text = ItemTexto.Descricao;
                    txtAjuda.Text = ItemTexto.Ajuda;
                    chkObsObrigatorio.Checked = ItemTexto.ObservacaoObrigatoria;
                    txtTextoPadrao.Text = ItemTexto.TextoPadrao;
                    chkIdentificador.Checked = ItemTexto.ItemIdentificador;
                    chkItemTextoPermitirSalvarPadrao.Checked = ItemTexto.PermitirSalvarValorPadrao;
                    break;

                case csListaItens.enuTipoCheckIten.Data:
                    csItemData ItemData = (csItemData)_CheckListItem;
                    cboTipo.SelectedIndex = 3;
                    txtNome.Text = ItemData.Nome;
                    txtDescricao.Text = ItemData.Descricao;
                    txtAjuda.Text = ItemData.Ajuda;
                    if (ItemData.SoDataSemHora)
                    {
                        optSomenteData.Checked = true;
                    }
                    else
                    {
                        optDataEHora.Checked = true;
                    }
                    chkObsObrigatorio.Checked = ItemData.ObservacaoObrigatoria;
                    break;
            }

            //this.TopMost = true;
            this.ShowDialog();

            return _CheckListItem;
        }

        /// <summary>
        /// Método para adicionar arquivos em um item csItemListaArquivos
        /// </summary>
        private void AbrirArquivo()
        {
            csItemListaArquivos ItemListaArquivos;
            if (_CheckListItem == null)
            {
                ItemListaArquivos = new csItemListaArquivos();
                _CheckListItem = ItemListaArquivos;
            }
            else
            {
                ItemListaArquivos = (csItemListaArquivos)_CheckListItem;
            }
            if (ItemListaArquivos.EscolherArquivoECarregar())
            {
                this.AtualizarListaArquivos();
            }
        }

        /// <summary>
        /// Método que atualiza a lista de arquivos carregados para o item csItemListaArquivos
        /// </summary>
        private void AtualizarListaArquivos()
        {
            csItemListaArquivos ItemListaArquivos;
            if (_CheckListItem == null)
            {
                ItemListaArquivos = new csItemListaArquivos();
                _CheckListItem = ItemListaArquivos;
            }
            else
            {
                ItemListaArquivos = (csItemListaArquivos)_CheckListItem;
            }
            lvwItemListaArquivos.Items.Clear();
            if (ItemListaArquivos != null)
            {
                lvwItemListaArquivos.Items.Clear();
                ListViewItem lvwItem = null;
                csItemArquivo ItemArquivoDaLista = null;
                string NomeArquivo = "";
                string ExtencaoArquivo = "";
                float TamanhoKB = 0;
                for (int i = 0; i < ItemListaArquivos.Count; i++)
                {
                    ItemArquivoDaLista = (csItemArquivo)ItemListaArquivos.ItensArquivo[i];
                    NomeArquivo = csUtil.ParteNomeArquivo(ItemArquivoDaLista.CaminhoCompletoOrigem, csUtil.enuParteNomeArquivo.Nome);
                    ExtencaoArquivo = csUtil.ParteNomeArquivo(ItemArquivoDaLista.CaminhoCompletoOrigem, csUtil.enuParteNomeArquivo.Extencao);
                    TamanhoKB = (ItemArquivoDaLista.TamanhoArquivo / 1024);

                    lvwItem = lvwItemListaArquivos.Items.Add(NomeArquivo);
                    lvwItem.SubItems.Add(ExtencaoArquivo);
                    lvwItem.SubItems.Add(string.Format("{0:#,0.00}", TamanhoKB));
                    if (ItemArquivoDaLista.DataCriacao.ToString("dd/MM/yyyy") == "01/01/0001")
                    {
                        lvwItem.SubItems.Add("");
                    }
                    else
                    {
                        lvwItem.SubItems.Add(ItemArquivoDaLista.DataCriacao.ToString("dd/MM/yy HH:mm:ss"));
                    }
                    if (ItemArquivoDaLista.DataUltimaAlteracao.ToString("dd/MM/yyyy") == "01/01/0001")
                    {
                        lvwItem.SubItems.Add("");
                    }
                    else
                    {
                        lvwItem.SubItems.Add(ItemArquivoDaLista.DataUltimaAlteracao.ToString("dd/MM/yy HH:mm:ss"));
                    }
                    if (ItemArquivoDaLista.DataInclusao.ToString("dd/MM/yyyy") == "01/01/0001")
                    {
                        lvwItem.SubItems.Add("");
                    }
                    else
                    {
                        lvwItem.SubItems.Add(ItemArquivoDaLista.DataInclusao.ToString("dd/MM/yy HH:mm:ss"));
                    }
                    lvwItem.SubItems.Add(ItemArquivoDaLista.UsuarioIncluiu);
                    lvwItem.SubItems.Add(ItemArquivoDaLista.CaminhoCompletoOrigem);

                }
            }

        }

    #endregion

    #region Eventos de controles
        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboTipo.SelectedIndex)
            {
                //case 0: // Arquivo
                //    gbxArquivo.Visible = true;
                //    gbxTexto.Visible = false;
                //    gbxOpcoes.Visible = false;
                //    break;

                case 0: // Lista de Arquivos
                    gbxArquivo.Visible = true;
                    gbxTexto.Visible = false;
                    gbxOpcoes.Visible = false;
                    gbxDataHora.Visible = false;
                    break;

                case 1: // Lista de Oções
                    gbxArquivo.Visible = false;
                    gbxTexto.Visible = false;
                    gbxOpcoes.Visible = true;
                    gbxDataHora.Visible = false;
                    break;

                case 2: // Texto
                    gbxArquivo.Visible = false;
                    gbxTexto.Visible = true;
                    gbxOpcoes.Visible = false;
                    gbxDataHora.Visible = false;
                    break;

                case 3: // Data
                    gbxArquivo.Visible = false;
                    gbxTexto.Visible = false;
                    gbxOpcoes.Visible = false;
                    gbxDataHora.Visible = true;
                    break;
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            _CheckListItem = null;
            this.Close();
        }

        private void btInserirTipoArquivo_Click(object sender, EventArgs e)
        {
            ListViewItem lvwItem;

            lvwItem = lvwTiposArquivos.Items.Add(cboDescricaoTipoArquivo.Text);
            lvwItem.SubItems.Add(txtTiposArquivos.Text);

            cboDescricaoTipoArquivo.Text = "";
            txtTiposArquivos.Text = "";
            cboDescricaoTipoArquivo.Focus();
        }

        private void lvwTiposArquivos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (lvwTiposArquivos.SelectedItems.Count > 0)
                {
                    lvwTiposArquivos.Items.Remove(lvwTiposArquivos.SelectedItems[0]);
                }
            }
        }

        private void btBuscarListaClipboard_Click(object sender, EventArgs e)
        {
            try
            {
                string _TextoClipboard = Clipboard.GetText();
                _TextoClipboard = _TextoClipboard.Replace("\r", "");
                string[] _Split = _TextoClipboard.Split("\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                ListViewItem lvwItem;

                for (int i = 0; i < _Split.Length; i++)
                {
                    lvwItem = lvwOpcoes.Items.Add(_Split[i]);
                    lvwItem.SubItems.Add("Não");
                }
            }
            catch (Exception _Exception)
            {
                MessageBox.Show(_Exception.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmdInserirOpcao_Click(object sender, EventArgs e)
        {
            ListViewItem lvwItem;
            string OpcaoPadrao;

            lvwItem = lvwOpcoes.Items.Add(txtNomeOpcao.Text);
            if (chkOpcaoPadrao.Checked)
            {
                OpcaoPadrao = "Sim";
            }
            else
            {
                OpcaoPadrao = "Não";
            }
            lvwItem.SubItems.Add(OpcaoPadrao);

            txtNomeOpcao.Text = "";
            chkOpcaoPadrao.Checked = false;
            txtNomeOpcao.Focus();
        }

        private void lvwOpcoes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (e.Control)
                {
                    DialogResult _Resp = MessageBox.Show("Apagar todos os itens da lista?", "Apagar toda Lista", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (_Resp == DialogResult.Yes)
                    {
                        lvwOpcoes.Items.Clear();
                    }
                }
                else if (lvwOpcoes.SelectedItems.Count > 0)
                {
                    lvwOpcoes.Items.Remove(lvwOpcoes.SelectedItems[0]);
                }
            }
        }

        private void btOK_Click(object sender, EventArgs e)
        {

            switch (cboTipo.SelectedIndex)
            {
                //case 0: // Arquivo
                //    csItemArquivo ItemArquivo;
                //    if (_CheckListItem == null)
                //    {
                //        ItemArquivo = new csItemArquivo();
                //    }
                //    else
                //    {
                //        ItemArquivo = (csItemArquivo)_CheckListItem;
                //    }
                //    ItemArquivo.Nome = txtNome.Text;
                //    ItemArquivo.Descricao = txtDescricao.Text;
                //    ItemArquivo.Ajuda = txtAjuda.Text;
                //    ItemArquivo.ObservacaoObrigatoria = chkObsObrigatorio.Checked;
                //    ItemArquivo.FiltrosArquivos.Clear();
                //    foreach (ListViewItem lvwItem in lvwTiposArquivos.Items)
                //    {
                //        ItemArquivo.FiltrosArquivos.Add(lvwItem.Text, lvwItem.SubItems[1].Text);
                //    }
                //    _CheckListItem = ItemArquivo;
                //    break;

                case 0: // Lista de Arquivos
                    csItemListaArquivos ItemListaArquivos;
                    if (_CheckListItem == null)
                    {
                        ItemListaArquivos = new csItemListaArquivos();
                        _CheckListItem = ItemListaArquivos;
                    }
                    else
                    {
                        ItemListaArquivos = (csItemListaArquivos)_CheckListItem;
                    }
                    ItemListaArquivos.Nome = txtNome.Text;
                    ItemListaArquivos.Descricao = txtDescricao.Text;
                    ItemListaArquivos.Ajuda = txtAjuda.Text;
                    ItemListaArquivos.ObservacaoObrigatoria = chkObsObrigatorio.Checked;
                    ItemListaArquivos.FiltrosArquivos.Clear();
                    foreach (ListViewItem lvwItem in lvwTiposArquivos.Items)
                    {
                        ItemListaArquivos.FiltrosArquivos.Add(lvwItem.Text, lvwItem.SubItems[1].Text);
                    }
                    _CheckListItem = ItemListaArquivos;
                    break;

                case 1: // Lista de Oções
                    csItemListaOpcoes ItemListaOpcoes;
                    if (_CheckListItem == null)
                    {
                        ItemListaOpcoes = new csItemListaOpcoes();
                    }
                    else
                    {
                        ItemListaOpcoes = (csItemListaOpcoes)_CheckListItem;
                    }
                    csOpcao Opcao;
                    ItemListaOpcoes.MultiplaEscolha = chkMultiplaEscolha.Checked;
                    ItemListaOpcoes.Nome = txtNome.Text;
                    ItemListaOpcoes.Descricao = txtDescricao.Text;
                    ItemListaOpcoes.Ajuda = txtAjuda.Text;
                    ItemListaOpcoes.ObservacaoObrigatoria = chkObsObrigatorio.Checked;
                    ItemListaOpcoes.Opcoes.Clear();
                    foreach (ListViewItem lvwItem in lvwOpcoes.Items)
                    {
                        Opcao = new csOpcao();
                        Opcao.Texto = lvwItem.Text;
                        Opcao.Padrao = (lvwItem.SubItems[1].Text == "Sim");
                        ItemListaOpcoes.Opcoes.Add(Opcao);
                    }
                    _CheckListItem = ItemListaOpcoes;
                    break;

                case 2: // Texto
                    csItemTexto ItemTexto;
                    if (_CheckListItem == null)
                    {
                        ItemTexto = new csItemTexto();
                    }
                    else
                    {
                        ItemTexto = (csItemTexto)_CheckListItem;
                    }
                    ItemTexto.Nome = txtNome.Text;
                    ItemTexto.Descricao = txtDescricao.Text;
                    ItemTexto.Ajuda = txtAjuda.Text;
                    ItemTexto.ObservacaoObrigatoria = chkObsObrigatorio.Checked;
                    ItemTexto.TextoPadrao = txtTextoPadrao.Text;
                    ItemTexto.ItemIdentificador = chkIdentificador.Checked;
                    ItemTexto.PermitirSalvarValorPadrao = chkItemTextoPermitirSalvarPadrao.Checked;
                    _CheckListItem = ItemTexto;
                    break;

                case 3: // Data
                    csItemData ItemData;
                    if (_CheckListItem == null)
                    {
                        ItemData = new csItemData();
                    }
                    else
                    {
                        ItemData = (csItemData)_CheckListItem;
                    }
                    ItemData.Nome = txtNome.Text;
                    ItemData.Descricao = txtDescricao.Text;
                    ItemData.Ajuda = txtAjuda.Text;
                    ItemData.SoDataSemHora = optSomenteData.Checked;
                    ItemData.ObservacaoObrigatoria = chkObsObrigatorio.Checked;
                    _CheckListItem = ItemData;
                    break;
            }
            this.Close();
        }

        private void cboDescricaoTipoArquivo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDescricaoTipoArquivo.SelectedIndex >= 0)
            {
                csFiltroArquivo Filtro = (csFiltroArquivo)cboDescricaoTipoArquivo.SelectedItem;
                txtTiposArquivos.Text = Filtro.Tipos;
            }
        }

        private void frmEditaItem_FormClosed(object sender, FormClosedEventArgs e)
        {
            if ((e.CloseReason != CloseReason.ApplicationExitCall) && (e.CloseReason != CloseReason.UserClosing))
            {
                _CheckListItem = null;
                this.Close();
            }
            
        }
        #endregion

        private void btExcluir_Click(object sender, EventArgs e)
        {
            if (lvwItemListaArquivos.SelectedItems.Count > 0)
            {
                DialogResult Resp;
                Resp = MessageBox.Show("Excluir o arquivo selecionado?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Resp == DialogResult.Yes)
                {
                    if (lvwItemListaArquivos.SelectedItems.Count > 0)
                    {
                        csItemListaArquivos ItemListaArquivos = (csItemListaArquivos)_CheckListItem;
                        ItemListaArquivos.Remove(lvwItemListaArquivos.SelectedIndices[0]);
                        this.AtualizarListaArquivos();
                    }
                }
            }
            else
            {
                if (lvwItemListaArquivos.Items.Count == 0)
                {
                    MessageBox.Show("Nenhum arquivo na lista para excluir!", "Excluir Arquivo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("Selecione um dos arquivos da lista para excluir!", "Excluir Arquivo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btAbrirArquivo_Click(object sender, EventArgs e)
        {
            this.AbrirArquivo();
        }

        private void btSalvarArquivoSelecionado_Click(object sender, EventArgs e)
        {
            if (lvwItemListaArquivos.SelectedItems.Count == 0)
            {
                if (lvwItemListaArquivos.Items.Count > 0)
                {
                    MessageBox.Show("Selecione um arquivo para salvar!", "Salvar arquivo selecionado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("Nenhum arquivo na lista para salvar!", "Salvar arquivo selecionado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                csItemListaArquivos ItemListaArquivos = (csItemListaArquivos)_CheckListItem;
                csItemArquivo ItemArquivo = (csItemArquivo)ItemListaArquivos.ItensArquivo[lvwItemListaArquivos.SelectedIndices[0]];
                ItemArquivo.EscolherDestinoESalvar();
            }
        }

        private void btSalvarTodosArquivos_Click(object sender, EventArgs e)
        {
            if (lvwItemListaArquivos.SelectedItems.Count > 0)
            {
                csItemListaArquivos ItemListaArquivos = (csItemListaArquivos)_CheckListItem;
                string PastaEscolhida = "";
                int QuantArquivosSalvos = ItemListaArquivos.EscolherCaminhoESalvarArquivos(ref PastaEscolhida);
                if (QuantArquivosSalvos > 0)
                {
                    MessageBox.Show(string.Format("{0} Arquivos salvos na pasta {1}", QuantArquivosSalvos, PastaEscolhida), "Salvar Todos Arquivos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Nenhum arquivo na lista para salvar!", "Salvar Todos Arquivos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        
                
    }
}
