namespace Check_List
{
    partial class frmEditaModeloCheckList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditaModeloCheckList));
            this.txtAjuda = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.mnuMenu = new System.Windows.Forms.MenuStrip();
            this.mnuArquivo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuArquivoNovoModelo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuArquivoAbrir = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuArquivoAbrirModelo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuArquivoAbrirExtrair = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuArquivoAbrirIncluirItens = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuArquivoAbrirAcoplarModelo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuArquivoAbrirAcoplarLista = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuArquivoSalvar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuArquivoSalvarComo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuArquivoTestarPreenchimento = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuArquivoDesmembrarModelo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuArquivoExportarListaItens = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuArquivoRelatorio = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuArquivoRelatorioImportar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuArquivoRelatorioLimpar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuArquivoRelatorioNovoModelo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuArquivoSair = new System.Windows.Forms.ToolStripMenuItem();
            this.btNovoItem = new System.Windows.Forms.Button();
            this.btAlterarItem = new System.Windows.Forms.Button();
            this.mnuContexto = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuContextoMoverParaCima = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuContextoMoverParaBaixo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuContextoExcluir = new System.Windows.Forms.ToolStripMenuItem();
            this.btExcluirItem = new System.Windows.Forms.Button();
            this.ilsImagens = new System.Windows.Forms.ImageList(this.components);
            this.chkSalvarLog = new System.Windows.Forms.CheckBox();
            this.chkAlertarAoReutilizar = new System.Windows.Forms.CheckBox();
            this.lvwCheckItens = new Check_List.ucLvwCheckItens();
            this.mnuMenu.SuspendLayout();
            this.mnuContexto.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtAjuda
            // 
            this.txtAjuda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAjuda.Location = new System.Drawing.Point(88, 85);
            this.txtAjuda.Multiline = true;
            this.txtAjuda.Name = "txtAjuda";
            this.txtAjuda.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAjuda.Size = new System.Drawing.Size(684, 114);
            this.txtAjuda.TabIndex = 2;
            this.txtAjuda.TextChanged += new System.EventHandler(this.Textos_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Ajuda:";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescricao.Location = new System.Drawing.Point(88, 57);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(684, 22);
            this.txtDescricao.TabIndex = 1;
            this.txtDescricao.TextChanged += new System.EventHandler(this.Textos_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Descrição:";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(88, 29);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(187, 22);
            this.txtNome.TabIndex = 0;
            this.txtNome.TextChanged += new System.EventHandler(this.Textos_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Nome:";
            // 
            // mnuMenu
            // 
            this.mnuMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuArquivo});
            this.mnuMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMenu.Name = "mnuMenu";
            this.mnuMenu.Size = new System.Drawing.Size(784, 24);
            this.mnuMenu.TabIndex = 14;
            this.mnuMenu.Text = "menuStrip1";
            // 
            // mnuArquivo
            // 
            this.mnuArquivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuArquivoNovoModelo,
            this.mnuArquivoAbrir,
            this.mnuArquivoSalvar,
            this.mnuArquivoSalvarComo,
            this.mnuArquivoTestarPreenchimento,
            this.mnuArquivoDesmembrarModelo,
            this.mnuArquivoExportarListaItens,
            this.mnuArquivoRelatorio,
            this.toolStripMenuItem1,
            this.mnuArquivoSair});
            this.mnuArquivo.Name = "mnuArquivo";
            this.mnuArquivo.Size = new System.Drawing.Size(61, 20);
            this.mnuArquivo.Text = "Arquivo";
            // 
            // mnuArquivoNovoModelo
            // 
            this.mnuArquivoNovoModelo.Name = "mnuArquivoNovoModelo";
            this.mnuArquivoNovoModelo.Size = new System.Drawing.Size(190, 22);
            this.mnuArquivoNovoModelo.Text = "Novo Modelo";
            this.mnuArquivoNovoModelo.Click += new System.EventHandler(this.mnuArquivoNovoModelo_Click);
            // 
            // mnuArquivoAbrir
            // 
            this.mnuArquivoAbrir.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuArquivoAbrirModelo,
            this.mnuArquivoAbrirExtrair,
            this.mnuArquivoAbrirIncluirItens,
            this.mnuArquivoAbrirAcoplarModelo,
            this.mnuArquivoAbrirAcoplarLista});
            this.mnuArquivoAbrir.Name = "mnuArquivoAbrir";
            this.mnuArquivoAbrir.Size = new System.Drawing.Size(190, 22);
            this.mnuArquivoAbrir.Text = "Abrir";
            // 
            // mnuArquivoAbrirModelo
            // 
            this.mnuArquivoAbrirModelo.Name = "mnuArquivoAbrirModelo";
            this.mnuArquivoAbrirModelo.Size = new System.Drawing.Size(282, 22);
            this.mnuArquivoAbrirModelo.Text = "Modelo";
            this.mnuArquivoAbrirModelo.Click += new System.EventHandler(this.mnuArquivoAbrirModelo_Click);
            // 
            // mnuArquivoAbrirExtrair
            // 
            this.mnuArquivoAbrirExtrair.Name = "mnuArquivoAbrirExtrair";
            this.mnuArquivoAbrirExtrair.Size = new System.Drawing.Size(282, 22);
            this.mnuArquivoAbrirExtrair.Text = "Extrair Modelo de uma Lista Preenchida";
            this.mnuArquivoAbrirExtrair.Click += new System.EventHandler(this.mnuArquivoExtrairModelo_Click);
            // 
            // mnuArquivoAbrirIncluirItens
            // 
            this.mnuArquivoAbrirIncluirItens.Name = "mnuArquivoAbrirIncluirItens";
            this.mnuArquivoAbrirIncluirItens.Size = new System.Drawing.Size(282, 22);
            this.mnuArquivoAbrirIncluirItens.Text = "Incluir Itens em uma Lista Preenchida";
            this.mnuArquivoAbrirIncluirItens.Click += new System.EventHandler(this.mnuArquivoAbrirIncluirItens_Click);
            // 
            // mnuArquivoAbrirAcoplarModelo
            // 
            this.mnuArquivoAbrirAcoplarModelo.Name = "mnuArquivoAbrirAcoplarModelo";
            this.mnuArquivoAbrirAcoplarModelo.Size = new System.Drawing.Size(282, 22);
            this.mnuArquivoAbrirAcoplarModelo.Text = "Acoplar Modelo";
            this.mnuArquivoAbrirAcoplarModelo.Click += new System.EventHandler(this.mnuArquivoAbrirAcoplarModelo_Click);
            // 
            // mnuArquivoAbrirAcoplarLista
            // 
            this.mnuArquivoAbrirAcoplarLista.Name = "mnuArquivoAbrirAcoplarLista";
            this.mnuArquivoAbrirAcoplarLista.Size = new System.Drawing.Size(282, 22);
            this.mnuArquivoAbrirAcoplarLista.Text = "Acoplar Lista Preenchida";
            this.mnuArquivoAbrirAcoplarLista.Click += new System.EventHandler(this.mnuArquivoAbrirAcoplarLista_Click);
            // 
            // mnuArquivoSalvar
            // 
            this.mnuArquivoSalvar.Name = "mnuArquivoSalvar";
            this.mnuArquivoSalvar.Size = new System.Drawing.Size(190, 22);
            this.mnuArquivoSalvar.Text = "Salvar";
            this.mnuArquivoSalvar.Click += new System.EventHandler(this.mnuArquivoSalvar_Click);
            // 
            // mnuArquivoSalvarComo
            // 
            this.mnuArquivoSalvarComo.Name = "mnuArquivoSalvarComo";
            this.mnuArquivoSalvarComo.Size = new System.Drawing.Size(190, 22);
            this.mnuArquivoSalvarComo.Text = "Salvar Como";
            this.mnuArquivoSalvarComo.Click += new System.EventHandler(this.mnuArquivoSalvarComo_Click);
            // 
            // mnuArquivoTestarPreenchimento
            // 
            this.mnuArquivoTestarPreenchimento.Name = "mnuArquivoTestarPreenchimento";
            this.mnuArquivoTestarPreenchimento.Size = new System.Drawing.Size(190, 22);
            this.mnuArquivoTestarPreenchimento.Text = "Testar Preenchimento";
            this.mnuArquivoTestarPreenchimento.Click += new System.EventHandler(this.mnuArquivoTestarPreenchimento_Click);
            // 
            // mnuArquivoDesmembrarModelo
            // 
            this.mnuArquivoDesmembrarModelo.Name = "mnuArquivoDesmembrarModelo";
            this.mnuArquivoDesmembrarModelo.Size = new System.Drawing.Size(190, 22);
            this.mnuArquivoDesmembrarModelo.Text = "Desmembrar Modelo";
            this.mnuArquivoDesmembrarModelo.Click += new System.EventHandler(this.mnuArquivoDesmembrarModelo_Click);
            // 
            // mnuArquivoExportarListaItens
            // 
            this.mnuArquivoExportarListaItens.Name = "mnuArquivoExportarListaItens";
            this.mnuArquivoExportarListaItens.Size = new System.Drawing.Size(190, 22);
            this.mnuArquivoExportarListaItens.Text = "Exportar Lista de Itens";
            this.mnuArquivoExportarListaItens.Click += new System.EventHandler(this.mnuArquivoExportarListaItens_Click);
            // 
            // mnuArquivoRelatorio
            // 
            this.mnuArquivoRelatorio.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuArquivoRelatorioImportar,
            this.mnuArquivoRelatorioLimpar,
            this.mnuArquivoRelatorioNovoModelo,
            this.toolStripMenuItem3});
            this.mnuArquivoRelatorio.Name = "mnuArquivoRelatorio";
            this.mnuArquivoRelatorio.Size = new System.Drawing.Size(190, 22);
            this.mnuArquivoRelatorio.Text = "Relatório";
            // 
            // mnuArquivoRelatorioImportar
            // 
            this.mnuArquivoRelatorioImportar.Name = "mnuArquivoRelatorioImportar";
            this.mnuArquivoRelatorioImportar.Size = new System.Drawing.Size(203, 22);
            this.mnuArquivoRelatorioImportar.Text = "Importar Modelo";
            this.mnuArquivoRelatorioImportar.Click += new System.EventHandler(this.mnuArquivoRelatorioImportar_Click);
            // 
            // mnuArquivoRelatorioLimpar
            // 
            this.mnuArquivoRelatorioLimpar.Name = "mnuArquivoRelatorioLimpar";
            this.mnuArquivoRelatorioLimpar.Size = new System.Drawing.Size(203, 22);
            this.mnuArquivoRelatorioLimpar.Text = "Limpar Lista de Modelos";
            this.mnuArquivoRelatorioLimpar.Click += new System.EventHandler(this.mnuArquivoRelatorioLimpar_Click);
            // 
            // mnuArquivoRelatorioNovoModelo
            // 
            this.mnuArquivoRelatorioNovoModelo.Name = "mnuArquivoRelatorioNovoModelo";
            this.mnuArquivoRelatorioNovoModelo.Size = new System.Drawing.Size(203, 22);
            this.mnuArquivoRelatorioNovoModelo.Text = "Novo Modelo";
            this.mnuArquivoRelatorioNovoModelo.Click += new System.EventHandler(this.mnuArquivoRelatorioNovoModelo_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(200, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(187, 6);
            // 
            // mnuArquivoSair
            // 
            this.mnuArquivoSair.Name = "mnuArquivoSair";
            this.mnuArquivoSair.Size = new System.Drawing.Size(190, 22);
            this.mnuArquivoSair.Text = "Sair";
            this.mnuArquivoSair.Click += new System.EventHandler(this.mnuArquivoSair_Click);
            // 
            // btNovoItem
            // 
            this.btNovoItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btNovoItem.Location = new System.Drawing.Point(610, 502);
            this.btNovoItem.Name = "btNovoItem";
            this.btNovoItem.Size = new System.Drawing.Size(162, 37);
            this.btNovoItem.TabIndex = 4;
            this.btNovoItem.Text = "Inserir Novo Item";
            this.btNovoItem.UseVisualStyleBackColor = true;
            this.btNovoItem.Click += new System.EventHandler(this.btNovoItem_Click);
            // 
            // btAlterarItem
            // 
            this.btAlterarItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btAlterarItem.Location = new System.Drawing.Point(183, 502);
            this.btAlterarItem.Name = "btAlterarItem";
            this.btAlterarItem.Size = new System.Drawing.Size(162, 37);
            this.btAlterarItem.TabIndex = 5;
            this.btAlterarItem.Text = "Alterar Item Selecionado";
            this.btAlterarItem.UseVisualStyleBackColor = true;
            this.btAlterarItem.Click += new System.EventHandler(this.btAlterarItem_Click);
            // 
            // mnuContexto
            // 
            this.mnuContexto.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuContextoMoverParaCima,
            this.mnuContextoMoverParaBaixo,
            this.toolStripMenuItem2,
            this.mnuContextoExcluir});
            this.mnuContexto.Name = "mnuContexto";
            this.mnuContexto.Size = new System.Drawing.Size(166, 76);
            // 
            // mnuContextoMoverParaCima
            // 
            this.mnuContextoMoverParaCima.Name = "mnuContextoMoverParaCima";
            this.mnuContextoMoverParaCima.Size = new System.Drawing.Size(165, 22);
            this.mnuContextoMoverParaCima.Text = "Mover para cima";
            this.mnuContextoMoverParaCima.Click += new System.EventHandler(this.mnuContextoMoverParaCima_Click);
            // 
            // mnuContextoMoverParaBaixo
            // 
            this.mnuContextoMoverParaBaixo.Name = "mnuContextoMoverParaBaixo";
            this.mnuContextoMoverParaBaixo.Size = new System.Drawing.Size(165, 22);
            this.mnuContextoMoverParaBaixo.Text = "Mover para baixo";
            this.mnuContextoMoverParaBaixo.Click += new System.EventHandler(this.mnuContextoMoverParaBaixo_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(162, 6);
            // 
            // mnuContextoExcluir
            // 
            this.mnuContextoExcluir.Name = "mnuContextoExcluir";
            this.mnuContextoExcluir.Size = new System.Drawing.Size(165, 22);
            this.mnuContextoExcluir.Text = "Excluir";
            this.mnuContextoExcluir.Click += new System.EventHandler(this.mnuContextoExcluir_Click);
            // 
            // btExcluirItem
            // 
            this.btExcluirItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btExcluirItem.Location = new System.Drawing.Point(15, 502);
            this.btExcluirItem.Name = "btExcluirItem";
            this.btExcluirItem.Size = new System.Drawing.Size(162, 37);
            this.btExcluirItem.TabIndex = 16;
            this.btExcluirItem.Text = "Excluir Item Selecionado";
            this.btExcluirItem.UseVisualStyleBackColor = true;
            this.btExcluirItem.Click += new System.EventHandler(this.btExcluirItem_Click);
            // 
            // ilsImagens
            // 
            this.ilsImagens.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilsImagens.ImageStream")));
            this.ilsImagens.TransparentColor = System.Drawing.Color.Transparent;
            this.ilsImagens.Images.SetKeyName(0, "Checado");
            // 
            // chkSalvarLog
            // 
            this.chkSalvarLog.AutoSize = true;
            this.chkSalvarLog.Location = new System.Drawing.Point(295, 31);
            this.chkSalvarLog.Name = "chkSalvarLog";
            this.chkSalvarLog.Size = new System.Drawing.Size(169, 20);
            this.chkSalvarLog.TabIndex = 17;
            this.chkSalvarLog.Text = "Salvar Log de alterações";
            this.chkSalvarLog.UseVisualStyleBackColor = true;
            this.chkSalvarLog.CheckedChanged += new System.EventHandler(this.Textos_TextChanged);
            // 
            // chkAlertarAoReutilizar
            // 
            this.chkAlertarAoReutilizar.AutoSize = true;
            this.chkAlertarAoReutilizar.Location = new System.Drawing.Point(470, 32);
            this.chkAlertarAoReutilizar.Name = "chkAlertarAoReutilizar";
            this.chkAlertarAoReutilizar.Size = new System.Drawing.Size(261, 20);
            this.chkAlertarAoReutilizar.TabIndex = 18;
            this.chkAlertarAoReutilizar.Text = "Alertar caso o CheckList seja reutilizado";
            this.chkAlertarAoReutilizar.UseVisualStyleBackColor = true;
            this.chkAlertarAoReutilizar.CheckedChanged += new System.EventHandler(this.Textos_TextChanged);
            // 
            // lvwCheckItens
            // 
            this.lvwCheckItens.AllowDrop = true;
            this.lvwCheckItens.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwCheckItens.FullRowSelect = true;
            this.lvwCheckItens.GridLines = true;
            this.lvwCheckItens.HideSelection = false;
            this.lvwCheckItens.ListaItens = null;
            this.lvwCheckItens.Location = new System.Drawing.Point(15, 205);
            this.lvwCheckItens.MultiSelect = false;
            this.lvwCheckItens.Name = "lvwCheckItens";
            this.lvwCheckItens.Size = new System.Drawing.Size(757, 291);
            this.lvwCheckItens.SmallImageList = this.ilsImagens;
            this.lvwCheckItens.TabIndex = 3;
            this.lvwCheckItens.TipoLista = Check_List.ucLvwCheckItens.enuTipoLista.tlDetalhada;
            this.lvwCheckItens.UseCompatibleStateImageBehavior = false;
            this.lvwCheckItens.View = System.Windows.Forms.View.Details;
            this.lvwCheckItens.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvwCheckItens_DragDrop);
            this.lvwCheckItens.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvwCheckItens_DragEnter);
            this.lvwCheckItens.DoubleClick += new System.EventHandler(this.lvwCheckItens_DoubleClick);
            this.lvwCheckItens.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvwCheckItens_KeyDown);
            this.lvwCheckItens.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvwCheckItens_MouseDown);
            // 
            // frmEditaModeloCheckList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 546);
            this.Controls.Add(this.chkAlertarAoReutilizar);
            this.Controls.Add(this.chkSalvarLog);
            this.Controls.Add(this.btExcluirItem);
            this.Controls.Add(this.btAlterarItem);
            this.Controls.Add(this.lvwCheckItens);
            this.Controls.Add(this.txtAjuda);
            this.Controls.Add(this.btNovoItem);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mnuMenu);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuMenu;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmEditaModeloCheckList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Check List - Editor de Check List";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEditaModeloCheckList_FormClosing);
            this.mnuMenu.ResumeLayout(false);
            this.mnuMenu.PerformLayout();
            this.mnuContexto.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAjuda;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip mnuMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuArquivo;
        private System.Windows.Forms.ToolStripMenuItem mnuArquivoAbrir;
        private System.Windows.Forms.ToolStripMenuItem mnuArquivoSalvar;
        private System.Windows.Forms.ToolStripMenuItem mnuArquivoSalvarComo;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuArquivoSair;
        private System.Windows.Forms.Button btNovoItem;
        private ucLvwCheckItens lvwCheckItens;
        private System.Windows.Forms.Button btAlterarItem;
        private System.Windows.Forms.ToolStripMenuItem mnuArquivoNovoModelo;
        private System.Windows.Forms.ContextMenuStrip mnuContexto;
        private System.Windows.Forms.ToolStripMenuItem mnuContextoMoverParaCima;
        private System.Windows.Forms.ToolStripMenuItem mnuContextoMoverParaBaixo;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuContextoExcluir;
        private System.Windows.Forms.Button btExcluirItem;
        private System.Windows.Forms.ToolStripMenuItem mnuArquivoAbrirModelo;
        private System.Windows.Forms.ToolStripMenuItem mnuArquivoAbrirExtrair;
        private System.Windows.Forms.ToolStripMenuItem mnuArquivoAbrirIncluirItens;
        private System.Windows.Forms.ImageList ilsImagens;
        private System.Windows.Forms.CheckBox chkSalvarLog;
        private System.Windows.Forms.ToolStripMenuItem mnuArquivoAbrirAcoplarModelo;
        private System.Windows.Forms.ToolStripMenuItem mnuArquivoAbrirAcoplarLista;
        private System.Windows.Forms.ToolStripMenuItem mnuArquivoTestarPreenchimento;
        private System.Windows.Forms.ToolStripMenuItem mnuArquivoDesmembrarModelo;
        private System.Windows.Forms.ToolStripMenuItem mnuArquivoRelatorio;
        private System.Windows.Forms.ToolStripMenuItem mnuArquivoRelatorioImportar;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem mnuArquivoRelatorioLimpar;
        private System.Windows.Forms.ToolStripMenuItem mnuArquivoRelatorioNovoModelo;
        private System.Windows.Forms.CheckBox chkAlertarAoReutilizar;
        private System.Windows.Forms.ToolStripMenuItem mnuArquivoExportarListaItens;

    }
}