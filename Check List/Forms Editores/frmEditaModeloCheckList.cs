using System;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Collections;
using System.Text;
using System.Drawing;

namespace Check_List
{
    public partial class frmEditaModeloCheckList : Form
    {
    #region Campos Privados
        private csListaItens _ListaCheckItens = null;
        private string _NomeArquivo = "";
        private bool _ArquivoEstaSalvo = false;
        private bool _PreenchendoCampos = false;
        private ArrayList _MenusRelatorios = new ArrayList();
    #endregion
        
    #region Construtores
        public frmEditaModeloCheckList()
        {
            InitializeComponent();
            _ListaCheckItens = new csListaItens();
            lvwCheckItens.ListaItens = _ListaCheckItens;
            _ArquivoEstaSalvo = true;
            this.Atualizar();
        }

        public frmEditaModeloCheckList(string p_NomeArquivo)
        {
            InitializeComponent();
            _ListaCheckItens = new csListaItens();
            this.CarregouArquivo(p_NomeArquivo);
            _ArquivoEstaSalvo = true;
        }
    #endregion

    #region Propriedades Privadas
        public bool TemArquivoCarregado { 
            get
            {
                return (File.Exists(_NomeArquivo));
            }
        }
    #endregion

    #region Métodos Privados

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

        private void mnuRelatorioPersonalizadoClonar_Click(object sender, EventArgs e)
        {
            DialogResult Resp;
            csRelatorio Relatorio = null;
            ToolStripItem _Menu = (ToolStripItem)sender;
            for (int i = 0; i < _ListaCheckItens.ListaRelatorios.Count; i++)
            {
                Relatorio = (csRelatorio)_ListaCheckItens.ListaRelatorios[i];
                if (Relatorio.Nome == _Menu.Tag.ToString())
                {
                    string _NomeModelo = null;
                    Resp = csUtil.InputBox("Nome do modelo", "Informe o nome do modelo", ref _NomeModelo);
                    if (Resp == DialogResult.OK)
                    {
                        _NomeModelo = _ListaCheckItens.NovoRelatorio(_NomeModelo, Relatorio.Texto);
                        if (_NomeModelo != null)
                        {
                            this.AtualizarMenuRelatorios();
                            _ArquivoEstaSalvo = false;
                            this.EditaRelatorio(_NomeModelo);
                        }
                    }
                    return;
                }
            }

        }

        private void AtualizarMenuRelatorios()
        {
            foreach (ToolStripItem _Menu in _MenusRelatorios)
            {
                mnuArquivoRelatorio.DropDownItems.Remove(_Menu);
            }
            _MenusRelatorios.Clear();
            ToolStripMenuItem NovoMenu = null;
            ToolStripItem SubMenu = null;
            foreach (csRelatorio Relatorio in _ListaCheckItens.ListaRelatorios)
            {
                NovoMenu = (ToolStripMenuItem)mnuArquivoRelatorio.DropDownItems.Add(Relatorio.Nome);
                _MenusRelatorios.Add(NovoMenu);
                NovoMenu.Click += new System.EventHandler(this.mnuRelatorioPersonalizado_Click);

                SubMenu = NovoMenu.DropDownItems.Add("Editar");
                SubMenu.Font = new Font(SubMenu.Font.FontFamily, SubMenu.Font.Size, FontStyle.Bold);
                SubMenu.Click += new System.EventHandler(this.mnuRelatorioPersonalizado_Click);
                SubMenu.Tag = Relatorio.Nome;

                SubMenu = NovoMenu.DropDownItems.Add("Exportar");
                SubMenu.Click += new System.EventHandler(this.mnuRelatorioPersonalizadoExpotar_Click);
                SubMenu.Tag = Relatorio.Nome;

                SubMenu = NovoMenu.DropDownItems.Add("Clonar");
                SubMenu.Click += new System.EventHandler(this.mnuRelatorioPersonalizadoClonar_Click);
                SubMenu.Tag = Relatorio.Nome;

                SubMenu = NovoMenu.DropDownItems.Add("Excluir");
                SubMenu.Click += new System.EventHandler(this.mnuRelatorioPersonalizadoExcluir_Click);
                SubMenu.Tag = Relatorio.Nome;
            }
        }

        private bool CarregouArquivo(string p_NomeArquivo)
        {
            try
            {
                bool _CarregouArquivo = false;
                _ListaCheckItens = new csListaItens(p_NomeArquivo, ref _CarregouArquivo);
                if (!_CarregouArquivo)
                {
                    _ListaCheckItens = null;
                    return false;
                }
                lvwCheckItens.ListaItens = _ListaCheckItens;
                this.Atualizar();
                _NomeArquivo = p_NomeArquivo;
                _ArquivoEstaSalvo = true;
                this.Text = "Check List - Editor de Check List - " + csUtil.ParteNomeArquivo(p_NomeArquivo, csUtil.enuParteNomeArquivo.NomeExtencao);
                return true;
            }
            catch (Exception _Exception)
            {
                MessageBox.Show("Erro ao carregar o arquivo\n" + p_NomeArquivo + "\n" + _Exception.ToString(), "Editar Modelo de Check List", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void Atualizar()
        {
            if (_ListaCheckItens != null)
            {
                _PreenchendoCampos = true;
                txtNome.Text = _ListaCheckItens.Nome;
                txtDescricao.Text = _ListaCheckItens.Descricao;
                txtAjuda.Text = _ListaCheckItens.Ajuda;
                chkSalvarLog.Checked = _ListaCheckItens.SalvarLog;
                chkAlertarAoReutilizar.Checked = _ListaCheckItens.AlertarAoReutilizarCheckList;
                _PreenchendoCampos = false;
                this.AtualizarMenuRelatorios();
            }
            else
            {
                txtNome.Text = "";
                txtDescricao.Text = "";
                txtAjuda.Text = "";
                chkSalvarLog.Checked = false;
                chkAlertarAoReutilizar.Checked = false;
            }
            lvwCheckItens.Atualizar();
        }

        private void NovoItem()
        {
            frmEditaItem EditorDeItens = new frmEditaItem();
            object NovoCheckListItem = EditorDeItens.InserirNovoCheckItem();
            if (NovoCheckListItem != null)
            {
                _ListaCheckItens.Add(NovoCheckListItem);
                this.Atualizar();
                _ArquivoEstaSalvo = false;
            }
            EditorDeItens.Dispose();
            EditorDeItens = null;
            GC.Collect();
        }

        private void ExcluirItem(int p_Indice)
        {
            DialogResult Resp;
            Resp = MessageBox.Show("Excluir o item selecionado?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Resp == DialogResult.Yes)
            {
                _ListaCheckItens.Remove(p_Indice);
                this.Atualizar();
                _ArquivoEstaSalvo = false;
            }
            
        }

        private void MoverParaCima(int p_Indice)
        {
            if (_ListaCheckItens != null)
            {
                // (p_Indice > 0) previne que não seja o primeiro item, que não tem como subir mais
                if ((p_Indice > 0) && (_ListaCheckItens.Itens.Count >= (p_Indice + 1)))
                {
                    object CheckItem = _ListaCheckItens.Itens[p_Indice];
                    int NovoIndice = p_Indice - 1;
                    _ListaCheckItens.Itens.Remove(_ListaCheckItens.Itens[p_Indice]);
                    _ListaCheckItens.Itens.Insert(NovoIndice, CheckItem);
                    this.Atualizar();
                    lvwCheckItens.SelectedIndices.Clear();
                    lvwCheckItens.SelectedIndices.Add(NovoIndice);
                    _ArquivoEstaSalvo = false;
                }
            }
        }

        private void MoverParaBaixo(int p_Indice)
        {
            if (_ListaCheckItens != null)
            {
                // (_ListaCheckItens.Itens.Count >= (p_Indice + 2)) previne que não seja o último item, 
                // que não tem como descer mais
                if ((p_Indice >= 0) && (_ListaCheckItens.Itens.Count >= (p_Indice + 2)))
                {
                    object CheckItem = _ListaCheckItens.Itens[p_Indice];
                    int NovoIndice = p_Indice + 1;
                    _ListaCheckItens.Itens.Remove(_ListaCheckItens.Itens[p_Indice]);
                    _ListaCheckItens.Itens.Insert(NovoIndice, CheckItem);
                    this.Atualizar();
                    lvwCheckItens.SelectedIndices.Clear();
                    Application.DoEvents();
                    lvwCheckItens.SelectedIndices.Add(NovoIndice);
                    Application.DoEvents();
                    _ArquivoEstaSalvo = false;
                }
            }
        }

        private void AlterarItem(int p_Indice)
        {
            frmEditaItem EditorDeItens = new frmEditaItem();
            object CheckListItemAlterado = EditorDeItens.EditarCheckItem(_ListaCheckItens.Itens[p_Indice]);
            if (CheckListItemAlterado != null)
            {
                _ListaCheckItens.Itens[p_Indice] = CheckListItemAlterado;
                this.Atualizar();
                _ArquivoEstaSalvo = false;
            }
            EditorDeItens.Dispose();
            EditorDeItens = null;
            GC.Collect();
        }

        private void AbrirModelo()
        {
            DialogResult Resp;
            if (!_ArquivoEstaSalvo)
            {
                Resp = MessageBox.Show("Deseja salvar as alterações antes de abrir um novo modelo?", "Abrir Modelo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (Resp == DialogResult.Cancel)
                {
                    return;
                }
                if (Resp == DialogResult.Yes)
	            {
                    if (!this.SalvouArquivo())
                    {
                        return;
                    }
	            }
            }
            OpenFileDialog dlgAbrir = new OpenFileDialog();
            dlgAbrir.Title = "Escolha o modelo";
            dlgAbrir.Filter = "Check List Preenchido (*.chkl)|*.chkl";
            string _PastaPadraoModelo = (string)csUtil.CarregarPreferencia("Pasta padrao abrir modelo");
            if (_PastaPadraoModelo != null)
            {
                dlgAbrir.InitialDirectory = _PastaPadraoModelo;
            }
            Resp = dlgAbrir.ShowDialog();
            if (Resp == System.Windows.Forms.DialogResult.OK)
            {
                csUtil.SalvarPreferencia("Pasta padrao abrir modelo", csUtil.ParteNomeArquivo(dlgAbrir.FileName, csUtil.enuParteNomeArquivo.Pasta));
                this.CarregouArquivo(dlgAbrir.FileName);
            }
        }

        private void AtualizarDadosLista()
        {
            _ListaCheckItens.Nome = txtNome.Text;
            _ListaCheckItens.Descricao = txtDescricao.Text;
            _ListaCheckItens.Ajuda = txtAjuda.Text;
        }

        private bool SalvouArquivo()
        {
            string NomeArquivo = "";
            try
            {
                if (this.TemArquivoCarregado)
                {
                    NomeArquivo = _NomeArquivo;
                    this.AtualizarDadosLista();
                    _ListaCheckItens.SalvarArquivo(NomeArquivo);
                    _ArquivoEstaSalvo = true;
                    return true;
                }
                else
                {
                    SaveFileDialog dlgSalvar = new SaveFileDialog();
                    DialogResult Resp;
                    dlgSalvar.Title = "Escolha o nome do modelo de Check List para salvar";
                    dlgSalvar.Filter = "Check List Preenchido (*.chkl)|*.chkl";
                    Resp = dlgSalvar.ShowDialog();
                    if (Resp == System.Windows.Forms.DialogResult.OK)
                    {
                        NomeArquivo = dlgSalvar.FileName;
                        this.AtualizarDadosLista();
                        _ListaCheckItens.SalvarArquivo(NomeArquivo);
                        _NomeArquivo = NomeArquivo;
                        this.Text = "Check List - Editor de Check List - " + csUtil.ParteNomeArquivo(_NomeArquivo, csUtil.enuParteNomeArquivo.NomeExtencao);
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

        private bool SalvouArquivoComo()
        {
            string NomeArquivo = "";
            try
            {
                SaveFileDialog dlgSalvar = new SaveFileDialog();
                DialogResult Resp;
                dlgSalvar.Title = "Escolha o nome do modelo de Check List para salvar";
                dlgSalvar.Filter = "Check List Preenchido (*.chkl)|*.chkl";
                Resp = dlgSalvar.ShowDialog();
                if (Resp == System.Windows.Forms.DialogResult.OK)
                {
                    NomeArquivo = dlgSalvar.FileName;
                    this.AtualizarDadosLista();
                    _ListaCheckItens.SalvarArquivo(NomeArquivo);
                    _NomeArquivo = NomeArquivo;
                    this.Text = "Check List - Editor de Check List - " + csUtil.ParteNomeArquivo(_NomeArquivo, csUtil.enuParteNomeArquivo.NomeExtencao);
                    _ArquivoEstaSalvo = true;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception _Exception)
            {
                MessageBox.Show("Erro ao salvar o arquivo\n" + NomeArquivo + "\n" + _Exception.ToString(), "Salvar Modelo de Check List", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        private void IncluirItens()
        {
            DialogResult Resp;
            if (!_ArquivoEstaSalvo)
            {
                Resp = MessageBox.Show("Deseja salvar as alterações antes de incluir Itens em uma Lista Preenchida?", "Incluir Itens", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (Resp == DialogResult.Cancel)
                {
                    return;
                }
                if (Resp == DialogResult.Yes)
                {
                    if (!this.SalvouArquivo())
                    {
                        return;
                    }
                }
            }
            OpenFileDialog dlgAbrir = new OpenFileDialog();
            dlgAbrir.Title = "Escolha o Check List Preenchido para incluir itens";
            dlgAbrir.Filter = "Check List Preenchido (*.chklp)|*.chklp";
            string _PastaPadraoEditarLista = (string)csUtil.CarregarPreferencia("Pasta padrao editar lista preenchida");
            if (_PastaPadraoEditarLista != null)
            {
                dlgAbrir.InitialDirectory = _PastaPadraoEditarLista;
            }
            Resp = dlgAbrir.ShowDialog();
            if (Resp == System.Windows.Forms.DialogResult.OK)
            {
                csUtil.SalvarPreferencia("Pasta padrao editar lista preenchida", csUtil.ParteNomeArquivo(dlgAbrir.FileName, csUtil.enuParteNomeArquivo.Pasta));
                if (this.CarregouArquivo(dlgAbrir.FileName))
                {
                    _NomeArquivo = dlgAbrir.FileName;
                    this.Text = "Check List - Editor de Check List - " + csUtil.ParteNomeArquivo(_NomeArquivo, csUtil.enuParteNomeArquivo.NomeExtencao);
                    _ArquivoEstaSalvo = true;
                    this.Atualizar();
                }
            }
        }

        private void ExtrairModelo()
        {
            DialogResult Resp;
            if (!_ArquivoEstaSalvo)
            {
                Resp = MessageBox.Show("Deseja salvar as alterações antes de extrair um modelo?", "Extrair Modelo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (Resp == DialogResult.Cancel)
                {
                    return;
                }
                if (Resp == DialogResult.Yes)
                {
                    if (!this.SalvouArquivo())
                    {
                        return;
                    }
                }
            }
            OpenFileDialog dlgAbrir = new OpenFileDialog();
            dlgAbrir.Title = "Escolha o Check List Preenchido para extrair o modelo";
            dlgAbrir.Filter = "Check List Preenchido (*.chklp)|*.chklp";
            string _PastaPadraoExtrairModelo = (string)csUtil.CarregarPreferencia("Pasta padrao extrair modelo");
            if (_PastaPadraoExtrairModelo != null)
            {
                dlgAbrir.InitialDirectory = _PastaPadraoExtrairModelo;
            }
            Resp = dlgAbrir.ShowDialog();
            if (Resp == System.Windows.Forms.DialogResult.OK)
            {
                csUtil.SalvarPreferencia("Pasta padrao extrair modelo", csUtil.ParteNomeArquivo(dlgAbrir.FileName, csUtil.enuParteNomeArquivo.Pasta));
                if (this.CarregouArquivo(dlgAbrir.FileName))
                {
                    _ListaCheckItens.LimparConteudo();
                    _NomeArquivo = "";
                    this.Text = "Check List - Editor de Check List";
                    _ArquivoEstaSalvo = false;
                    this.Atualizar();
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
                        Application.Exit();
                        return true;
                    }
                }
                else // Escolheu Não
                {
                    Application.Exit();
                    return true;
                }
            }
            else
            {
                Application.Exit();
                return true;
            }
        }

        private void NovoModelo()
        {
            DialogResult Resp;
            if (!_ArquivoEstaSalvo)
            {
                Resp = MessageBox.Show("Deseja salvar as alterações antes de criar um novo modelo?", "Novo Modelo", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (Resp == DialogResult.Cancel)
                {
                    return;
                }
                if (Resp == DialogResult.Yes)
                {
                    if (!this.SalvouArquivo())
                    {
                        return;
                    }
                    else
                    {
                        _ListaCheckItens = new csListaItens();
                        lvwCheckItens.ListaItens = _ListaCheckItens;
                        _ArquivoEstaSalvo = true;
                        this.Atualizar();
                        this.Text = "Check List - Editor de Check List";
                        _NomeArquivo = "";
                        GC.Collect();
                    }
                }
                else // Escolheu Não
                {
                    _ListaCheckItens = new csListaItens();
                    lvwCheckItens.ListaItens = _ListaCheckItens;
                    _ArquivoEstaSalvo = true;
                    this.Atualizar();
                    this.Text = "Check List - Editor de Check List";
                    _NomeArquivo = "";
                    GC.Collect();
                }
            }
            else
            {
                _ListaCheckItens = new csListaItens();
                lvwCheckItens.ListaItens = _ListaCheckItens;
                _ArquivoEstaSalvo = true;
                this.Atualizar();
                this.Text = "Check List - Editor de Check List";
                _NomeArquivo = "";
                GC.Collect();
            }
        }

        private void TestarPreenchimento()
        {
            Process Processo = new Process();
            Processo.StartInfo.FileName = Application.ExecutablePath;
            Processo.StartInfo.Arguments = @"""" + _NomeArquivo + @"""";
            Processo.Start();
        }

    #endregion

    #region Eventos de Controles
        private void btNovoItem_Click(object sender, EventArgs e)
        {
            this.NovoItem();
        }

        private void lvwCheckItens_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    if (lvwCheckItens.SelectedItems.Count > 0)
                    {
                        this.ExcluirItem(lvwCheckItens.SelectedIndices[0]);
                    }
                    break;

                case Keys.Up:
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (lvwCheckItens.SelectedItems.Count > 0))
                    {
                        this.MoverParaCima(lvwCheckItens.SelectedIndices[0]);
                    }
                    break;

                case Keys.Down:
                    if (((Control.ModifierKeys & Keys.Control) == Keys.Control) && (lvwCheckItens.SelectedItems.Count > 0))
                    {
                        this.MoverParaBaixo(lvwCheckItens.SelectedIndices[0]);
                    }
                    break;
            }

        }
        
        private void btAlterarItem_Click(object sender, EventArgs e)
        {
            if (lvwCheckItens.SelectedItems.Count > 0)
            {
                this.AlterarItem(lvwCheckItens.SelectedIndices[0]);
            }
            else
            {
                if (lvwCheckItens.Items.Count == 0)
                {
                    MessageBox.Show("Nenhum item na lista para alterar", "Alterar Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Selecione um dos itens para alterar", "Alterar Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void lvwCheckItens_DoubleClick(object sender, EventArgs e)
        {
            if (lvwCheckItens.SelectedItems.Count > 0)
            {
                this.AlterarItem(lvwCheckItens.SelectedIndices[0]);
            }
        }

        private void mnuArquivoSalvar_Click(object sender, EventArgs e)
        {
            this.SalvouArquivo();
        }

        private void mnuArquivoSalvarComo_Click(object sender, EventArgs e)
        {
            this.SalvouArquivoComo();
        }

        private void mnuArquivoSair_Click(object sender, EventArgs e)
        {
            this.Sair();
        }

        private void mnuArquivoNovoModelo_Click(object sender, EventArgs e)
        {
            this.NovoModelo();
        }

        private void btExcluirItem_Click(object sender, EventArgs e)
        {
            if (lvwCheckItens.SelectedItems.Count > 0)
            {
                this.ExcluirItem(lvwCheckItens.SelectedIndices[0]);
            }
        }

        private void mnuContextoExcluir_Click(object sender, EventArgs e)
        {
            if (lvwCheckItens.SelectedItems.Count > 0)
            {
                this.ExcluirItem(lvwCheckItens.SelectedIndices[0]);
            }
        }

        private void mnuContextoMoverParaCima_Click(object sender, EventArgs e)
        {
            if (lvwCheckItens.SelectedItems.Count > 0)
            {
                this.MoverParaCima(lvwCheckItens.SelectedIndices[0]);
            }
        }

        private void mnuContextoMoverParaBaixo_Click(object sender, EventArgs e)
        {
            if (lvwCheckItens.SelectedItems.Count > 0)
            {
                this.MoverParaBaixo(lvwCheckItens.SelectedIndices[0]);
            }
        }

        private void lvwCheckItens_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                mnuContexto.Show(lvwCheckItens, e.Location);
            }
        }

        private void Textos_TextChanged(object sender, EventArgs e)
        {
            if (!_PreenchendoCampos)
            {
                _ArquivoEstaSalvo = false;
                _ListaCheckItens.Nome = txtNome.Text;
                _ListaCheckItens.Descricao = txtDescricao.Text;
                _ListaCheckItens.Ajuda = txtAjuda.Text;
                _ListaCheckItens.SalvarLog = chkSalvarLog.Checked;
                _ListaCheckItens.AlertarAoReutilizarCheckList = chkAlertarAoReutilizar.Checked;
            }
        }

        private void mnuArquivoAbrirModelo_Click(object sender, EventArgs e)
        {
            this.AbrirModelo();
        }

        private void mnuArquivoExtrairModelo_Click(object sender, EventArgs e)
        {
            this.ExtrairModelo();
        }

        private void mnuArquivoAbrirIncluirItens_Click(object sender, EventArgs e)
        {
            this.IncluirItens();
        }

        private void frmEditaModeloCheckList_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.ApplicationExitCall)
            {
                if (!this.Sair())
                {
                    e.Cancel = true;
                }
            }
        }

        private void mnuArquivoAbrirAcoplarModelo_Click(object sender, EventArgs e)
        {
            if (_ListaCheckItens == null)
            {
                this.NovoModelo();
            }
            if (_ListaCheckItens.AcoplouModelo())
            {
                _ArquivoEstaSalvo = false;
                this.Atualizar();
            }
        }

        private void mnuArquivoAbrirAcoplarLista_Click(object sender, EventArgs e)
        {
            if (_ListaCheckItens == null)
            {
                this.NovoModelo();
            }
            if (_ListaCheckItens.AcoplouListaPreenchida())
            {
                _ArquivoEstaSalvo = false;
                this.Atualizar();
            }
        }

        private void mnuArquivoTestarPreenchimento_Click(object sender, EventArgs e)
        {
            if (!_ArquivoEstaSalvo || _NomeArquivo.Trim().Length == 0)
            {
                DialogResult Resp;
                Resp = MessageBox.Show("Para testar o preenchimento você deve salvar o arquivo.\nDeseja salvar agora?", "Testar Preenchimento", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (Resp == DialogResult.Yes)
                {
                    if (this.SalvouArquivo())
                    {
                        this.TestarPreenchimento();
                    }
                }
            }
            else
            {
                this.TestarPreenchimento();
            }
        }

        private void mnuArquivoDesmembrarModelo_Click(object sender, EventArgs e)
        {
            _ListaCheckItens.EscolherPastaEDesmembrar();
        }

        private void mnuArquivoRelatorioImportar_Click(object sender, EventArgs e)
        {
            DialogResult Resp;
            OpenFileDialog dlgAbrir = new OpenFileDialog();
            dlgAbrir.Title = "Escolha o modelo de relatório";
            dlgAbrir.Filter = "Check List Preenchido (*.chklr)|*.chklr";
            string _PastaPadraoModeloRelatorio = (string)csUtil.CarregarPreferencia("Pasta padrao modelo relatorio");
            if (_PastaPadraoModeloRelatorio != null)
            {
                dlgAbrir.InitialDirectory = _PastaPadraoModeloRelatorio;
            }
            Resp = dlgAbrir.ShowDialog();
            if (Resp == DialogResult.OK)
            {
                string _NomeModelo = null;
                csUtil.SalvarPreferencia("Pasta padrao modelo relatorio", csUtil.ParteNomeArquivo(dlgAbrir.FileName, csUtil.enuParteNomeArquivo.Pasta));
                _NomeModelo = _ListaCheckItens.InserirRelatorio(dlgAbrir.FileName);
                if (_NomeModelo != null)
                {
                    this.AtualizarMenuRelatorios();
                    _ArquivoEstaSalvo = false;
                    Resp = MessageBox.Show("Deseja abrir o relatório " + _NomeModelo + " para edição?", "Editar Relatorio", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (Resp == DialogResult.Yes)
                    {
                        this.EditaRelatorio(_NomeModelo);
                    }
                }
            }
        }

        private void mnuArquivoRelatorioLimpar_Click(object sender, EventArgs e)
        {
            _ListaCheckItens.LimparListaRelatorios();
            this.AtualizarMenuRelatorios();
            _ArquivoEstaSalvo = false;
        }

        private void mnuRelatorioPersonalizado_Click(object sender, EventArgs e)
        {
            ToolStripItem _Menu = (ToolStripItem)sender;

            if (_Menu.Text == "Editar")
            {
                this.EditaRelatorio(_Menu.Tag.ToString());
            }
            else
            {
                this.EditaRelatorio(_Menu.Text);
            }

            
        }

        private void EditaRelatorio(string p_NomeRelatorio)
        {
            frmEditorRelatorio _FormEditorRelatorio = new frmEditorRelatorio();
            DialogResult Resp = DialogResult.Cancel;
            Resp = _FormEditorRelatorio.EditaRelatorio(_ListaCheckItens, p_NomeRelatorio);
            if (Resp == DialogResult.OK)
            {
                _ArquivoEstaSalvo = false;
            }
        }

        private void mnuArquivoRelatorioNovoModelo_Click(object sender, EventArgs e)
        {
            string _NomeModelo = "";
            DialogResult Resp = csUtil.InputBox("Nome do modelo", "Informe o nome do modelo", ref _NomeModelo);
            if (Resp == DialogResult.OK)
            {
                _NomeModelo = _ListaCheckItens.NovoRelatorio(_NomeModelo, "");
                if (_NomeModelo != null)
                {
                    this.AtualizarMenuRelatorios();
                    _ArquivoEstaSalvo = false;
                    this.EditaRelatorio(_NomeModelo);
                }
            }
        }

        private void mnuArquivoExportarListaItens_Click(object sender, EventArgs e)
        {
            _ListaCheckItens.EscolherArquivoESalvarListaItensHTML();
        }

        private void lvwCheckItens_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void lvwCheckItens_DragDrop(object sender, DragEventArgs e)
        {
            if ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {
                Array data = ((IDataObject)e.Data).GetData("FileName") as Array;
                if (data != null)
                {
                    if ((data.Length == 1) && (data.GetValue(0) is String))
                    {
                        string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                        if (_ListaCheckItens.AcoplouModelo(files))
                        {
                            _ArquivoEstaSalvo = false;
                            this.Atualizar();
                        }
                    }
                }
            }
        }

    #endregion

        
    }
}
