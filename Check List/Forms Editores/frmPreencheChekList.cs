using System;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Configuration;
using System.Collections;
using System.Text;

namespace Check_List
{
	public partial class frmPreencheChekList : Form
    {

    #region Campos Privados
        private csListaItens _ListaCheckItens = null;
        private string _NomeArquivo = "";
        private int _Indice = -1;
        private bool _AjustandoSelecaoLista = false;
        private bool _ArquivoEstaSalvo = false;
        private ArrayList _MenusRelatorios = new ArrayList();
        //private int _ContAviso = 0;
    #endregion

    #region Construtores
        public frmPreencheChekList(string p_NomeArquivo)
        {
            InitializeComponent();
            panItem.AlterouAlgo += new AlterouAlgoItemEventHandler(this.OnAlterouItem);
            panItemArquivo.AlterouAlgo += new AlterouAlgoItemArquivoEventHandler(this.OnAlterouItemArquivo);
            panItenListaArquivos.AlterouAlgo += new AlterouAlgoItemListaArquivosEventHandler(this.OnAlterouItemListaArquivos);
            panItemOpcoes.AlterouAlgo += new AlterouAlgoItemListaOpcoesEventHandler(this.OnAlterouItemListaOpcoes);
            panItemTexto.AlterouAlgo += new AlterouAlgoItemTextoEventHandler(this.OnAlterouItemTexto);
            panItemData.AlterouAlgo += new AlterouAlgoItemDataEventHandler(this.OnAlterouItemData);
            this.Size = new Size(800, 620);
            this.CarregaLogoWizard();

            _ListaCheckItens = new csListaItens();
            if (this.CarregouArquivo(p_NomeArquivo))
            {
                this.AjustaPanels();
                _Indice = -1;
                this.MostraPanel();

                this.AtualizarMenuRelatorios();
            }
            else
            {
                this.Close();
            }

        }

        public frmPreencheChekList(string p_NomeArquivo, string p_NomeRelatorio)
        {
            InitializeComponent();
            this.Visible = false;
            _ListaCheckItens = new csListaItens();
            if (this.CarregouArquivo(p_NomeArquivo))
            {
                _ListaCheckItens.MostrarRelatorio(p_NomeArquivo);
            }
            this.Close();
        }
    #endregion

    #region Eventos dos panItem
        void OnAlterouItemTexto(ucPanItemTexto sender, EventArgs e)
        {
            _ArquivoEstaSalvo = false;
        }

        void OnAlterouItemListaOpcoes(ucPanItemListaOpcoes sender, EventArgs e)
        {
            _ArquivoEstaSalvo = false;
        }

        void OnAlterouItemListaArquivos(ucPanItemListaArquivos sender, EventArgs e)
        {
            _ArquivoEstaSalvo = false;
        }

        protected virtual void OnAlterouItem(ucPanItem sender, EventArgs e)
        {
            _ArquivoEstaSalvo = false;
        }

        protected virtual void OnAlterouItemArquivo(ucPanItemArquivo sender, EventArgs e)
        {
            _ArquivoEstaSalvo = false;
        }

        protected virtual void OnAlterouItemData(ucPanItemData sender, EventArgs e)
        {
            _ArquivoEstaSalvo = false;
        }
        

    #endregion

    #region Propriedades Privadas
		public bool TemArquivoCarregado
		{
			get
			{
				return (File.Exists(_NomeArquivo));
			}
		}
    #endregion

    #region Métodos privados

        private void mnuRelatorioPersonalizadoExpotar_Click(object sender, EventArgs e)
        {
            ToolStripItem _Menu = (ToolStripItem)sender;
            foreach (csRelatorio Relatorio in _ListaCheckItens.ListaRelatorios)
            {
                if (Relatorio.Nome == _Menu.Tag.ToString())
                {
                    SaveFileDialog dlgSalvar = new SaveFileDialog();
                    DialogResult Resp;
                    string _NomeArquivo = "";
                    dlgSalvar.Title = "Escolha o nome do relatório para exportar";
                    dlgSalvar.Filter = "Check List Preenchido (*.chklr)|*.chklr";
                    dlgSalvar.FileName = Relatorio.Nome;
                    Resp = dlgSalvar.ShowDialog();
                    if (Resp == System.Windows.Forms.DialogResult.OK)
                    {
                        _NomeArquivo = dlgSalvar.FileName;
                        StreamWriter Escritor = new StreamWriter(_NomeArquivo, false, Encoding.Default);
                        Escritor.Write(Relatorio.Texto);
                        Escritor.Close();
                        Escritor.Dispose();
                        GC.Collect();
                    }
                    return;
                }
            }
        }

        private void mnuRelatorioPersonalizadoExcluir_Click(object sender, EventArgs e)
        {
            DialogResult Resp;
            csRelatorio Relatorio = null;
            ToolStripItem _Menu = (ToolStripItem)sender;
            for (int i = 0; i < _ListaCheckItens.ListaRelatorios.Count; i++)
            {
                Relatorio = (csRelatorio)_ListaCheckItens.ListaRelatorios[i];
                if (Relatorio.Nome == _Menu.Tag.ToString())
                {
                    Resp = MessageBox.Show("Excluir o relatório " + Relatorio.Nome + "?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (Resp == DialogResult.Yes)
                    {
                        _ListaCheckItens.ListaRelatorios.Remove(Relatorio);
                        this.AtualizarMenuRelatorios();
                        _ArquivoEstaSalvo = false;
                    }
                    return;
                }
            }

        }

        private void mnuRelatorioPersonalizadoEditar_Click(object sender, EventArgs e)
        {
            frmEditorRelatorio _FormEditorRelatorio = new frmEditorRelatorio();
            ToolStripItem _Menu = (ToolStripItem)sender;
            DialogResult Resp = DialogResult.Cancel;
            Resp = _FormEditorRelatorio.EditaRelatorio(_ListaCheckItens, _Menu.Tag.ToString());
            if (Resp == DialogResult.OK)
            {
                _ArquivoEstaSalvo = false;
            }
        }

        private void AtualizarMenuRelatorios()
        {
            foreach (ToolStripItem _Menu in _MenusRelatorios)
            {
                mnuFerramentasRelatorio.DropDownItems.Remove(_Menu);
            }
            _MenusRelatorios.Clear();
            ToolStripMenuItem NovoMenu = null;
            ToolStripItem SubMenu = null;
            foreach (csRelatorio Relatorio in _ListaCheckItens.ListaRelatorios)
            {
                NovoMenu = (ToolStripMenuItem)mnuFerramentasRelatorio.DropDownItems.Add(Relatorio.Nome);
                _MenusRelatorios.Add(NovoMenu);
                NovoMenu.Click += new System.EventHandler(this.mnuRelatorioPersonalizado_Click);

                SubMenu = NovoMenu.DropDownItems.Add("Visualizar");
                SubMenu.Font = new Font(SubMenu.Font.FontFamily, SubMenu.Font.Size, FontStyle.Bold);
                SubMenu.Click += new System.EventHandler(this.mnuRelatorioPersonalizado_Click);
                SubMenu.Tag = Relatorio.Nome;

                SubMenu = NovoMenu.DropDownItems.Add("Exportar");
                SubMenu.Click += new System.EventHandler(this.mnuRelatorioPersonalizadoExpotar_Click);
                SubMenu.Tag = Relatorio.Nome;

                SubMenu = NovoMenu.DropDownItems.Add("Editar");
                SubMenu.Click += new System.EventHandler(this.mnuRelatorioPersonalizadoEditar_Click);
                SubMenu.Tag = Relatorio.Nome;

                SubMenu = NovoMenu.DropDownItems.Add("Excluir");
                SubMenu.Click += new System.EventHandler(this.mnuRelatorioPersonalizadoExcluir_Click);
                SubMenu.Tag = Relatorio.Nome;
            }
        }

        private void mnuRelatorioPersonalizado_Click(object sender, EventArgs e)
        {
            ToolStripItem _Menu = (ToolStripItem)sender;
            foreach (csRelatorio Relatorio in _ListaCheckItens.ListaRelatorios)
            {
                if (_Menu.Text == "Visualizar")
                {
                    if (Relatorio.Nome == _Menu.Tag.ToString())
                    {
                        _ListaCheckItens.MostrarRelatorio(Relatorio.Texto);
                        return;
                    }
                }
                else
	            {
                    if (Relatorio.Nome == _Menu.Text)
                    {
                        _ListaCheckItens.MostrarRelatorio(Relatorio.Texto);
                        return;
                    }
	            }
            }
        }

        private bool CarregouArquivo(string p_NomeArquivo)
        {
            try
            {
                string Extencao = csUtil.ParteNomeArquivo(p_NomeArquivo, csUtil.enuParteNomeArquivo.Extencao);
                bool _CarregouArquivo = false;
                _ListaCheckItens = new csListaItens(p_NomeArquivo, ref _CarregouArquivo);
                if (!_CarregouArquivo)
                {
                    _ListaCheckItens = null;
                    return false;
                }
                panInicial.SetaListaItens(_ListaCheckItens);
                if (Extencao.ToUpper() == "CHKLP")
                {
                    _NomeArquivo = p_NomeArquivo;
                    this.Text = "Check List - " + _ListaCheckItens.Nome + " (" + csUtil.ParteNomeArquivo(p_NomeArquivo, csUtil.enuParteNomeArquivo.Nome) + ")";
                }
                else
                {
                    _NomeArquivo = "";
                    this.Text = "Check List - " + _ListaCheckItens.Nome;
                }
                lvwCheckItens.ListaItens = _ListaCheckItens;
                this.Atualizar();
                _ArquivoEstaSalvo = true;
                return true;
            }
            catch (Exception _Exception)
            {
                MessageBox.Show("Erro ao carregar o arquivo\n" + p_NomeArquivo + "\n" + _Exception.ToString(), "Editar Modelo de Check List", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void CarregaLogoWizard()
        {
            string CaminhoExe = csUtil.ParteNomeArquivo(Application.ExecutablePath, csUtil.enuParteNomeArquivo.Pasta);
            string CaminhoLogo = CaminhoExe + "LogoWizard.png";
            try
            {
                if (File.Exists(CaminhoLogo))
                {
                    Bitmap PNG = new Bitmap(CaminhoLogo);
                    panImagem.BackgroundImage = PNG;

                }


            }
            catch (Exception _Exception)
            {
                MessageBox.Show("Erro ao carregar o arquivo\n" + CaminhoLogo + "\n" + _Exception.ToString(), "CrregaLogoWizard", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostraPanel()
        {
            panInicial.Visible = false;
            panItem.Visible = false;
            panItemArquivo.Visible = false;
            panItenListaArquivos.Visible = false;
            panItemOpcoes.Visible = false;
            panItemTexto.Visible = false;
            panItemData.Visible = false;

            btAnterior.Enabled = true;
            btProximo.Enabled = true;

            lvwCheckItens.SelectedItems.Clear();
            if (_Indice <= -1)
            {
                _Indice = -1;
                panInicial.Visible = true;
                btAnterior.Enabled = false;
                return;
            }

            if (_Indice >= _ListaCheckItens.Itens.Count - 1)
            {
                _Indice = _ListaCheckItens.Itens.Count - 1;
                btProximo.Enabled = false;
            }

            _AjustandoSelecaoLista = true;
            lvwCheckItens.SelectedIndices.Clear();
            if (_Indice >= 0)
            {
                lvwCheckItens.SelectedIndices.Add(_Indice);
            }
            _AjustandoSelecaoLista = false;

            object CheckItem = _ListaCheckItens.Itens[_Indice];

            panItem.SetaCheckItem(CheckItem);

            switch (_ListaCheckItens.TipoCheckItem(CheckItem))
            {
                case csListaItens.enuTipoCheckIten.Arquivo:
                    panItemArquivo.SetaCheckItem(CheckItem);
                    panItem.Visible = true;
                    panItemArquivo.Visible = true;
                    break;

                case csListaItens.enuTipoCheckIten.ListaDeArquivos:
                    panItenListaArquivos.SetaCheckItem(CheckItem);
                    panItem.Visible = true;
                    panItenListaArquivos.Visible = true;

                    break;

                case csListaItens.enuTipoCheckIten.ListaDeOpcoes:
                    panItemOpcoes.SetaCheckItem(CheckItem);
                    panItem.Visible = true;
                    panItemOpcoes.Enabled = false;
                    panItemOpcoes.Visible = true;
                    panItemOpcoes.Enabled = true;
                    break;

                case csListaItens.enuTipoCheckIten.Texto:
                    panItemTexto.SetaCheckItem(CheckItem);
                    panItem.Visible = true;
                    panItemTexto.Visible = true;
                    break;

                case csListaItens.enuTipoCheckIten.Data:
                    panItemData.SetaCheckItem(CheckItem);
                    panItem.Visible = true;
                    panItemData.Visible = true;
                    break;
            }

        }

        private void AjustaPanels()
        {
            panInicial.Location = new Point(192, 104);
            panInicial.Visible = false;
            panItem.Location = new Point(192, 104);

            panItemArquivo.Location = new Point(192, 280);
            panItemArquivo.Visible = false;

            panItenListaArquivos.Location = new Point(192, 280);
            panItenListaArquivos.Visible = false;

            panItemOpcoes.Location = new Point(192, 280);
            panItemOpcoes.Visible = false;

            panItemTexto.Location = new Point(192, 280);
            panItemTexto.Visible = false;

            panItemData.Location = new Point(192, 280);
            panItemData.Visible = false;
        }


        private bool SalvouArquivo()
        {
            //if ((_ArquivoEstaSalvo) && (this.TemArquivoCarregado))
            //{
            //    return false;
            //}
            if (this.VerificarReutilizacao())
            {
                MessageBox.Show("Este CheckList parece estar sendo reutilizado.\nUm CheckList não deve ser reutilizado, crie um novo CheckList a partir do modelo.\nSuas alterações não serão salvas!", "CheckList sendo reutilizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
            {
                string NomeArquivo = "";
                try
                {
                    if (this.TemArquivoCarregado)
                    {
                        NomeArquivo = _NomeArquivo;
                        _ListaCheckItens.SalvarArquivo(NomeArquivo);
                        this.Atualizar();
                        _ArquivoEstaSalvo = true;
                        return true;
                    }
                    else
                    {
                        SaveFileDialog dlgSalvar = new SaveFileDialog();
                        DialogResult Resp;
                        AppSettingsReader AppConfig = new AppSettingsReader();
                        string SugestaoNomeArquivo = "";
                        string PastaPadrao = "";

                        dlgSalvar.Title = "Escolha o nome do Check List para salvar";
                        dlgSalvar.Filter = "Check List Preenchido (*.chklp)|*.chklp";
                        try
                        {
                            PastaPadrao = AppConfig.GetValue("PastaPadrao", typeof(string)).ToString();
                            dlgSalvar.InitialDirectory = PastaPadrao;
                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        SugestaoNomeArquivo = _ListaCheckItens.TextoItemIdentificador;
                        if (SugestaoNomeArquivo.Trim().Length > 0)
                        {
                            dlgSalvar.FileName = SugestaoNomeArquivo.Trim();
                        }
                        else
                        {
                            dlgSalvar.FileName = _ListaCheckItens.Nome;
                        }

                        Resp = dlgSalvar.ShowDialog();
                        if (Resp == System.Windows.Forms.DialogResult.OK)
                        {
                            NomeArquivo = dlgSalvar.FileName;
                            _ListaCheckItens.SalvarArquivo(NomeArquivo);
                            this.Atualizar();
                            _NomeArquivo = NomeArquivo;
                            this.Text = "Check List - " + _ListaCheckItens.Nome + " (" + _NomeArquivo + ")";
                            _ArquivoEstaSalvo = true;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                catch (Exception _Exception)
                {
                    MessageBox.Show("Erro ao salvar o arquivo\n" + NomeArquivo + "\n" + _Exception.ToString(), "Salvar Modelo de Check List", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        private bool Sair()
        {
            DialogResult Resp;
            if (!_ArquivoEstaSalvo)
            {
                Resp = MessageBox.Show("Deseja salvar as alterações antes de sair?", "Sair", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (Resp == DialogResult.Cancel)
                {
                    return false;
                }
                if (Resp == DialogResult.Yes)
                {
                    if (!this.SalvouArquivo())
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else // Escolheu Não
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }

        private void Atualizar()
        {
            _AjustandoSelecaoLista = true;
            lvwCheckItens.Atualizar();
            this.AtualizarMenuRelatorios();
            _AjustandoSelecaoLista = false;
            this.MostraPanel();
            this.VerificarReutilizacao();
        }

        private bool VerificarReutilizacao()
        {
            bool _Retorno = false;
            lblCheckListReutilizado.Visible = false;
            tmrCheckListReutilizado.Enabled = false;
            if (_ListaCheckItens.SalvarLog)
            {
                if (_ListaCheckItens.AlertarAoReutilizarCheckList)
                {
                    if (_ListaCheckItens.EstaReutilizandoCheckList)
                    {
                        lblCheckListReutilizado.Visible = true;
                        tmrCheckListReutilizado.Enabled = true;
                        _Retorno = true;
                    }
                }
            }
            return _Retorno;
        }


    #endregion Métodos privados

    #region Eventos dos controles
        private void btProximo_Click(object sender, EventArgs e)
        {
            _Indice++;
            this.Atualizar();
            if (_Indice <= lvwCheckItens.Items.Count - 1)
            {
                lvwCheckItens.Items[_Indice].EnsureVisible();
            }
        }

        private void btAnterior_Click(object sender, EventArgs e)
        {
            _Indice--;
            this.Atualizar();
            if (_Indice >= 0)
            {
                lvwCheckItens.Items[_Indice].EnsureVisible();
            }
        }

        private void lvwCheckItens_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_AjustandoSelecaoLista && lvwCheckItens.SelectedIndices.Count > 0)
            {
                if (_Indice != lvwCheckItens.SelectedIndices[0])
                {
                    _Indice = lvwCheckItens.SelectedIndices[0];
                    this.Atualizar();
                }
            }
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            this.SalvouArquivo();
        }

        private void mnuFerramentasVerLog_Click(object sender, EventArgs e)
        {
            frmListaLog ListaLog = new frmListaLog(_ListaCheckItens.ListaLog);
            ListaLog = null;
            GC.Collect();
        }

        private void mnuArquivoSair_Click(object sender, EventArgs e)
        {
            if (this.Sair())
            {
                Application.Exit();
            }
        }

        private void frmPreencheChekList_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.ApplicationExitCall)
            {
                if (!this.Sair())
                {
                    e.Cancel = true;
                }
            }
        }

        private void mnuFerramentasAcoplarModelo_Click(object sender, EventArgs e)
        {
            if (_ListaCheckItens.AcoplouModelo())
            {
                this.Atualizar();
                _ArquivoEstaSalvo = false;
            }
        }

        private void mnuFerramentasRelatorioCompleto_Click(object sender, EventArgs e)
        {
            if (_ListaCheckItens != null)
            {
                _ListaCheckItens.MostrarRelatorio();
            }
        }

        private void mnuFerramentasRelatorioLista_Click(object sender, EventArgs e)
        {
            if (_ListaCheckItens != null)
            {
                _ListaCheckItens.MostrarRelatorioTodasOpcoes();
            }
        }

        private void mnuFerramentasRelatorioModelo_Click(object sender, EventArgs e)
        {
            if (_ListaCheckItens != null)
            {
                DialogResult Resp;
                OpenFileDialog dlgAbrir = new OpenFileDialog();
                dlgAbrir.Title = "Escolha o modelo de relatório";
                dlgAbrir.Filter = "Check List Preenchido (*.chklr)|*.chklr";
                Resp = dlgAbrir.ShowDialog();
                if (Resp == System.Windows.Forms.DialogResult.OK)
                {
                    _ListaCheckItens.MostrarRelatorio(dlgAbrir.FileName);
                }
            }
        }

        private void mnuFerramentasRelatorioImportar_Click(object sender, EventArgs e)
        {
            DialogResult Resp;
            OpenFileDialog dlgAbrir = new OpenFileDialog();
            dlgAbrir.Title = "Escolha o modelo de relatório";
            dlgAbrir.Filter = "Check List Preenchido (*.chklr)|*.chklr";
            Resp = dlgAbrir.ShowDialog();
            if (Resp == System.Windows.Forms.DialogResult.OK)
            {
                _ListaCheckItens.InserirRelatorio(dlgAbrir.FileName);
                this.AtualizarMenuRelatorios();
                _ListaCheckItens.MostrarRelatorio(dlgAbrir.FileName);
                _ArquivoEstaSalvo = false;
            }
        }

        private void mnuFerramentasRelatorioLimpar_Click(object sender, EventArgs e)
        {
            _ListaCheckItens.LimparListaRelatorios();
            this.AtualizarMenuRelatorios();
            _ArquivoEstaSalvo = false;
        }

        private void mnuFerramentasExtrairArquivos_Click(object sender, EventArgs e)
        {
            string PastaEscolhida = csUtil.ParteNomeArquivo(_NomeArquivo, csUtil.enuParteNomeArquivo.Pasta);
            //string NomeArquivoCheckList = "";
            //if (this.TemArquivoCarregado)
            //{
            //    NomeArquivoCheckList = _NomeArquivo;
            //}
            int QuantArquivosSalvos = _ListaCheckItens.EscolherCaminhoESalvarArquivos(ref PastaEscolhida);
            if (QuantArquivosSalvos > 0)
            {
                MessageBox.Show(string.Format("{0} Arquivos salvos na pasta {1}", QuantArquivosSalvos, PastaEscolhida), "Extrair Todos Arquivos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void mnuFerramentasAdicionarComentario_Click(object sender, EventArgs e)
        {
            frmListaComentarios ListaComentarios = new frmListaComentarios(_ListaCheckItens.ListaComentarios);
            if (ListaComentarios.AlterouAlgo)
            {
                _ArquivoEstaSalvo = false;
            }
            ListaComentarios = null;
            GC.Collect();
        }

        private void mnuFerramentasDesacoplarModelo_Click(object sender, EventArgs e)
        {
            if (_ListaCheckItens.DesacoplouModelo())
            {
                this.Atualizar();
                _ArquivoEstaSalvo = false;
            }
        }

        private void tmrCheckListReutilizado_Tick(object sender, EventArgs e)
        {
            //_ContAviso++;
            if (lblCheckListReutilizado.BackColor == System.Drawing.Color.Yellow)
            {
                lblCheckListReutilizado.BackColor = System.Drawing.Color.Red;
                lblCheckListReutilizado.ForeColor = System.Drawing.Color.Yellow;
            }
            else
            {
                lblCheckListReutilizado.BackColor = System.Drawing.Color.Yellow;
                lblCheckListReutilizado.ForeColor = System.Drawing.Color.Red;
            }
            //if (_ContAviso >= 10)
            //{
            //    _ContAviso = 0;
            //    MessageBox.Show("Este CheckList parece estar sendo reutilizado\nUm CheckList não deve ser reutilizado, crie um novo CheckList a partir do modelo.", "CheckList sendo reutilizado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
        }

        private void lblCheckListReutilizado_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Este CheckList parece estar sendo reutilizado\nUm CheckList não deve ser reutilizado, crie um novo CheckList a partir do modelo.","CheckList sendo reutilizado",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        }

        #endregion Eventos dos controle

    }
}
