namespace Check_List
{
    partial class frmPreencheChekList
    {
        private System.ComponentModel.IContainer components;

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPreencheChekList));
            this.btSalvar = new System.Windows.Forms.Button();
            this.btProximo = new System.Windows.Forms.Button();
            this.btAnterior = new System.Windows.Forms.Button();
            this.panImagem = new System.Windows.Forms.Panel();
            this.ilsImagens = new System.Windows.Forms.ImageList(this.components);
            this.mnuMenu = new System.Windows.Forms.MenuStrip();
            this.mnuArquivo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuArquivoSair = new System.Windows.Forms.ToolStripMenuItem();
            this.ferramentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFerramentasAcoplarModelo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFerramentasDesacoplarModelo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFerramentasRelatorio = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFerramentasRelatorioCompleto = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFerramentasRelatorioModelo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFerramentasRelatorioImportar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFerramentasRelatorioLimpar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFerramentasExtrairArquivos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFerramentasVerLog = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFerramentasAdicionarComentario = new System.Windows.Forms.ToolStripMenuItem();
            this.lblCheckListReutilizado = new System.Windows.Forms.Label();
            this.tmrCheckListReutilizado = new System.Windows.Forms.Timer(this.components);
            this.panItemData = new Check_List.ucPanItemData();
            this.panInicial = new Check_List.ucPanListaItens();
            this.panItemTexto = new Check_List.ucPanItemTexto();
            this.panItemOpcoes = new Check_List.ucPanItemListaOpcoes();
            this.panItenListaArquivos = new Check_List.ucPanItemListaArquivos();
            this.panItemArquivo = new Check_List.ucPanItemArquivo();
            this.lvwCheckItens = new Check_List.ucLvwCheckItens();
            this.panItem = new Check_List.ucPanItem();
            this.ucLvwCheckItens1 = new Check_List.ucLvwCheckItens();
            this.mnuMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btSalvar
            // 
            this.btSalvar.Location = new System.Drawing.Point(652, 542);
            this.btSalvar.Name = "btSalvar";
            this.btSalvar.Size = new System.Drawing.Size(129, 42);
            this.btSalvar.TabIndex = 2;
            this.btSalvar.Text = "Salvar";
            this.btSalvar.UseVisualStyleBackColor = true;
            this.btSalvar.Click += new System.EventHandler(this.btSalvar_Click);
            // 
            // btProximo
            // 
            this.btProximo.Location = new System.Drawing.Point(343, 542);
            this.btProximo.Name = "btProximo";
            this.btProximo.Size = new System.Drawing.Size(129, 42);
            this.btProximo.TabIndex = 3;
            this.btProximo.Text = "Próximo >";
            this.btProximo.UseVisualStyleBackColor = true;
            this.btProximo.Click += new System.EventHandler(this.btProximo_Click);
            // 
            // btAnterior
            // 
            this.btAnterior.Location = new System.Drawing.Point(201, 542);
            this.btAnterior.Name = "btAnterior";
            this.btAnterior.Size = new System.Drawing.Size(129, 42);
            this.btAnterior.TabIndex = 4;
            this.btAnterior.Text = "< Anterior";
            this.btAnterior.UseVisualStyleBackColor = true;
            this.btAnterior.Click += new System.EventHandler(this.btAnterior_Click);
            // 
            // panImagem
            // 
            this.panImagem.BackColor = System.Drawing.Color.White;
            this.panImagem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panImagem.Location = new System.Drawing.Point(186, 24);
            this.panImagem.Name = "panImagem";
            this.panImagem.Size = new System.Drawing.Size(609, 77);
            this.panImagem.TabIndex = 5;
            // 
            // ilsImagens
            // 
            this.ilsImagens.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilsImagens.ImageStream")));
            this.ilsImagens.TransparentColor = System.Drawing.Color.Transparent;
            this.ilsImagens.Images.SetKeyName(0, "Checado");
            // 
            // mnuMenu
            // 
            this.mnuMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuArquivo,
            this.ferramentasToolStripMenuItem});
            this.mnuMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMenu.Name = "mnuMenu";
            this.mnuMenu.Size = new System.Drawing.Size(1370, 24);
            this.mnuMenu.TabIndex = 18;
            this.mnuMenu.Text = "menuStrip1";
            // 
            // mnuArquivo
            // 
            this.mnuArquivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuArquivoSair});
            this.mnuArquivo.Name = "mnuArquivo";
            this.mnuArquivo.Size = new System.Drawing.Size(61, 20);
            this.mnuArquivo.Text = "Arquivo";
            // 
            // mnuArquivoSair
            // 
            this.mnuArquivoSair.Name = "mnuArquivoSair";
            this.mnuArquivoSair.Size = new System.Drawing.Size(93, 22);
            this.mnuArquivoSair.Text = "Sair";
            this.mnuArquivoSair.Click += new System.EventHandler(this.mnuArquivoSair_Click);
            // 
            // ferramentasToolStripMenuItem
            // 
            this.ferramentasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFerramentasAcoplarModelo,
            this.mnuFerramentasDesacoplarModelo,
            this.mnuFerramentasRelatorio,
            this.mnuFerramentasExtrairArquivos,
            this.mnuFerramentasVerLog,
            this.mnuFerramentasAdicionarComentario});
            this.ferramentasToolStripMenuItem.Name = "ferramentasToolStripMenuItem";
            this.ferramentasToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.ferramentasToolStripMenuItem.Text = "Ferramentas";
            // 
            // mnuFerramentasAcoplarModelo
            // 
            this.mnuFerramentasAcoplarModelo.Name = "mnuFerramentasAcoplarModelo";
            this.mnuFerramentasAcoplarModelo.Size = new System.Drawing.Size(239, 22);
            this.mnuFerramentasAcoplarModelo.Text = "Adicionar Modelo";
            this.mnuFerramentasAcoplarModelo.Click += new System.EventHandler(this.mnuFerramentasAcoplarModelo_Click);
            // 
            // mnuFerramentasDesacoplarModelo
            // 
            this.mnuFerramentasDesacoplarModelo.Name = "mnuFerramentasDesacoplarModelo";
            this.mnuFerramentasDesacoplarModelo.Size = new System.Drawing.Size(239, 22);
            this.mnuFerramentasDesacoplarModelo.Text = "Remover Modelo";
            this.mnuFerramentasDesacoplarModelo.Click += new System.EventHandler(this.mnuFerramentasDesacoplarModelo_Click);
            // 
            // mnuFerramentasRelatorio
            // 
            this.mnuFerramentasRelatorio.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFerramentasRelatorioCompleto,
            this.mnuFerramentasRelatorioModelo,
            this.mnuFerramentasRelatorioImportar,
            this.mnuFerramentasRelatorioLimpar,
            this.toolStripMenuItem2});
            this.mnuFerramentasRelatorio.Name = "mnuFerramentasRelatorio";
            this.mnuFerramentasRelatorio.Size = new System.Drawing.Size(239, 22);
            this.mnuFerramentasRelatorio.Text = "Relatório";
            // 
            // mnuFerramentasRelatorioCompleto
            // 
            this.mnuFerramentasRelatorioCompleto.Name = "mnuFerramentasRelatorioCompleto";
            this.mnuFerramentasRelatorioCompleto.Size = new System.Drawing.Size(209, 22);
            this.mnuFerramentasRelatorioCompleto.Text = "Completo";
            this.mnuFerramentasRelatorioCompleto.Click += new System.EventHandler(this.mnuFerramentasRelatorioCompleto_Click);
            // 
            // mnuFerramentasRelatorioModelo
            // 
            this.mnuFerramentasRelatorioModelo.Name = "mnuFerramentasRelatorioModelo";
            this.mnuFerramentasRelatorioModelo.Size = new System.Drawing.Size(209, 22);
            this.mnuFerramentasRelatorioModelo.Text = "A partir do modelo...";
            this.mnuFerramentasRelatorioModelo.Click += new System.EventHandler(this.mnuFerramentasRelatorioModelo_Click);
            // 
            // mnuFerramentasRelatorioImportar
            // 
            this.mnuFerramentasRelatorioImportar.Name = "mnuFerramentasRelatorioImportar";
            this.mnuFerramentasRelatorioImportar.Size = new System.Drawing.Size(209, 22);
            this.mnuFerramentasRelatorioImportar.Text = "Importar Modelo";
            this.mnuFerramentasRelatorioImportar.Click += new System.EventHandler(this.mnuFerramentasRelatorioImportar_Click);
            // 
            // mnuFerramentasRelatorioLimpar
            // 
            this.mnuFerramentasRelatorioLimpar.Name = "mnuFerramentasRelatorioLimpar";
            this.mnuFerramentasRelatorioLimpar.Size = new System.Drawing.Size(209, 22);
            this.mnuFerramentasRelatorioLimpar.Text = "Limpar Lista de Relatórios";
            this.mnuFerramentasRelatorioLimpar.Click += new System.EventHandler(this.mnuFerramentasRelatorioLimpar_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(206, 6);
            // 
            // mnuFerramentasExtrairArquivos
            // 
            this.mnuFerramentasExtrairArquivos.Name = "mnuFerramentasExtrairArquivos";
            this.mnuFerramentasExtrairArquivos.Size = new System.Drawing.Size(239, 22);
            this.mnuFerramentasExtrairArquivos.Text = "Extrair todos arquivos anexados";
            this.mnuFerramentasExtrairArquivos.Click += new System.EventHandler(this.mnuFerramentasExtrairArquivos_Click);
            // 
            // mnuFerramentasVerLog
            // 
            this.mnuFerramentasVerLog.Name = "mnuFerramentasVerLog";
            this.mnuFerramentasVerLog.Size = new System.Drawing.Size(239, 22);
            this.mnuFerramentasVerLog.Text = "Ver Log";
            this.mnuFerramentasVerLog.Click += new System.EventHandler(this.mnuFerramentasVerLog_Click);
            // 
            // mnuFerramentasAdicionarComentario
            // 
            this.mnuFerramentasAdicionarComentario.Name = "mnuFerramentasAdicionarComentario";
            this.mnuFerramentasAdicionarComentario.Size = new System.Drawing.Size(239, 22);
            this.mnuFerramentasAdicionarComentario.Text = "Adicionar Comentário";
            this.mnuFerramentasAdicionarComentario.Visible = false;
            this.mnuFerramentasAdicionarComentario.Click += new System.EventHandler(this.mnuFerramentasAdicionarComentario_Click);
            // 
            // lblCheckListReutilizado
            // 
            this.lblCheckListReutilizado.AutoSize = true;
            this.lblCheckListReutilizado.BackColor = System.Drawing.Color.Yellow;
            this.lblCheckListReutilizado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCheckListReutilizado.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckListReutilizado.ForeColor = System.Drawing.Color.Red;
            this.lblCheckListReutilizado.Location = new System.Drawing.Point(188, 2);
            this.lblCheckListReutilizado.Name = "lblCheckListReutilizado";
            this.lblCheckListReutilizado.Size = new System.Drawing.Size(606, 21);
            this.lblCheckListReutilizado.TabIndex = 20;
            this.lblCheckListReutilizado.Text = "                                      Este CheckList está sendo reutilizado      " +
                "                                 ";
            this.lblCheckListReutilizado.Visible = false;
            this.lblCheckListReutilizado.Click += new System.EventHandler(this.lblCheckListReutilizado_Click);
            // 
            // tmrCheckListReutilizado
            // 
            this.tmrCheckListReutilizado.Interval = 1000;
            this.tmrCheckListReutilizado.Tick += new System.EventHandler(this.tmrCheckListReutilizado_Tick);
            // 
            // panItemData
            // 
            this.panItemData.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panItemData.Location = new System.Drawing.Point(2013, 0);
            this.panItemData.Name = "panItemData";
            this.panItemData.Size = new System.Drawing.Size(601, 196);
            this.panItemData.TabIndex = 19;
            // 
            // panInicial
            // 
            this.panInicial.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panInicial.Location = new System.Drawing.Point(192, 104);
            this.panInicial.Name = "panInicial";
            this.panInicial.Size = new System.Drawing.Size(601, 432);
            this.panInicial.TabIndex = 16;
            // 
            // panItemTexto
            // 
            this.panItemTexto.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panItemTexto.Location = new System.Drawing.Point(1406, 0);
            this.panItemTexto.Name = "panItemTexto";
            this.panItemTexto.Size = new System.Drawing.Size(601, 196);
            this.panItemTexto.TabIndex = 15;
            // 
            // panItemOpcoes
            // 
            this.panItemOpcoes.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panItemOpcoes.Location = new System.Drawing.Point(799, 0);
            this.panItemOpcoes.Name = "panItemOpcoes";
            this.panItemOpcoes.Size = new System.Drawing.Size(601, 196);
            this.panItemOpcoes.TabIndex = 14;
            // 
            // panItenListaArquivos
            // 
            this.panItenListaArquivos.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panItenListaArquivos.Location = new System.Drawing.Point(799, 202);
            this.panItenListaArquivos.Name = "panItenListaArquivos";
            this.panItenListaArquivos.Size = new System.Drawing.Size(601, 196);
            this.panItenListaArquivos.TabIndex = 13;
            // 
            // panItemArquivo
            // 
            this.panItemArquivo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panItemArquivo.Location = new System.Drawing.Point(799, 404);
            this.panItemArquivo.Name = "panItemArquivo";
            this.panItemArquivo.Size = new System.Drawing.Size(601, 196);
            this.panItemArquivo.TabIndex = 12;
            // 
            // lvwCheckItens
            // 
            this.lvwCheckItens.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwCheckItens.FullRowSelect = true;
            this.lvwCheckItens.GridLines = true;
            this.lvwCheckItens.HideSelection = false;
            this.lvwCheckItens.ListaItens = null;
            this.lvwCheckItens.Location = new System.Drawing.Point(0, 24);
            this.lvwCheckItens.MultiSelect = false;
            this.lvwCheckItens.Name = "lvwCheckItens";
            this.lvwCheckItens.Size = new System.Drawing.Size(186, 570);
            this.lvwCheckItens.SmallImageList = this.ilsImagens;
            this.lvwCheckItens.TabIndex = 0;
            this.lvwCheckItens.TipoLista = Check_List.ucLvwCheckItens.enuTipoLista.tlResumida;
            this.lvwCheckItens.UseCompatibleStateImageBehavior = false;
            this.lvwCheckItens.View = System.Windows.Forms.View.Details;
            this.lvwCheckItens.SelectedIndexChanged += new System.EventHandler(this.lvwCheckItens_SelectedIndexChanged);
            // 
            // panItem
            // 
            this.panItem.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panItem.Location = new System.Drawing.Point(1406, 202);
            this.panItem.Name = "panItem";
            this.panItem.Size = new System.Drawing.Size(601, 432);
            this.panItem.TabIndex = 11;
            // 
            // ucLvwCheckItens1
            // 
            this.ucLvwCheckItens1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucLvwCheckItens1.FullRowSelect = true;
            this.ucLvwCheckItens1.GridLines = true;
            this.ucLvwCheckItens1.HideSelection = false;
            this.ucLvwCheckItens1.ListaItens = null;
            this.ucLvwCheckItens1.Location = new System.Drawing.Point(0, 0);
            this.ucLvwCheckItens1.MultiSelect = false;
            this.ucLvwCheckItens1.Name = "ucLvwCheckItens1";
            this.ucLvwCheckItens1.Size = new System.Drawing.Size(160, 574);
            this.ucLvwCheckItens1.TabIndex = 0;
            this.ucLvwCheckItens1.TipoLista = Check_List.ucLvwCheckItens.enuTipoLista.tlResumida;
            this.ucLvwCheckItens1.UseCompatibleStateImageBehavior = false;
            this.ucLvwCheckItens1.View = System.Windows.Forms.View.Details;
            // 
            // frmPreencheChekList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 592);
            this.Controls.Add(this.lblCheckListReutilizado);
            this.Controls.Add(this.panImagem);
            this.Controls.Add(this.panItemData);
            this.Controls.Add(this.panInicial);
            this.Controls.Add(this.panItemTexto);
            this.Controls.Add(this.panItemOpcoes);
            this.Controls.Add(this.panItenListaArquivos);
            this.Controls.Add(this.panItemArquivo);
            this.Controls.Add(this.btAnterior);
            this.Controls.Add(this.btProximo);
            this.Controls.Add(this.btSalvar);
            this.Controls.Add(this.lvwCheckItens);
            this.Controls.Add(this.panItem);
            this.Controls.Add(this.mnuMenu);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuMenu;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "frmPreencheChekList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Check List - Nome do Check List";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPreencheChekList_FormClosing);
            this.mnuMenu.ResumeLayout(false);
            this.mnuMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ucLvwCheckItens lvwCheckItens;
        private System.Windows.Forms.Button btSalvar;
        private System.Windows.Forms.Button btProximo;
        private System.Windows.Forms.Button btAnterior;
        private System.Windows.Forms.Panel panImagem;
        private ucLvwCheckItens ucLvwCheckItens1;
        private System.Windows.Forms.ImageList ilsImagens;
        private ucPanItem panItem;
        private ucPanItemArquivo panItemArquivo;
        private ucPanItemListaArquivos panItenListaArquivos;
        private ucPanItemListaOpcoes panItemOpcoes;
        private ucPanItemTexto panItemTexto;
        private ucPanListaItens panInicial;
        private System.Windows.Forms.MenuStrip mnuMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuArquivo;
        private System.Windows.Forms.ToolStripMenuItem mnuArquivoSair;
        private ucPanItemData panItemData;
        private System.Windows.Forms.ToolStripMenuItem ferramentasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuFerramentasRelatorio;
        private System.Windows.Forms.ToolStripMenuItem mnuFerramentasRelatorioCompleto;
        private System.Windows.Forms.ToolStripMenuItem mnuFerramentasRelatorioModelo;
        private System.Windows.Forms.ToolStripMenuItem mnuFerramentasRelatorioImportar;
        private System.Windows.Forms.ToolStripMenuItem mnuFerramentasRelatorioLimpar;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuFerramentasVerLog;
        private System.Windows.Forms.ToolStripMenuItem mnuFerramentasAcoplarModelo;
        private System.Windows.Forms.ToolStripMenuItem mnuFerramentasExtrairArquivos;
        private System.Windows.Forms.ToolStripMenuItem mnuFerramentasAdicionarComentario;
        private System.Windows.Forms.ToolStripMenuItem mnuFerramentasDesacoplarModelo;
        private System.Windows.Forms.Label lblCheckListReutilizado;
        private System.Windows.Forms.Timer tmrCheckListReutilizado;
    }
}