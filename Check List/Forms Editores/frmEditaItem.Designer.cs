namespace Check_List
{
    partial class frmEditaItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditaItem));
            this.label1 = new System.Windows.Forms.Label();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAjuda = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkObsObrigatorio = new System.Windows.Forms.CheckBox();
            this.gbxArquivo = new System.Windows.Forms.GroupBox();
            this.btExcluir = new System.Windows.Forms.Button();
            this.btSalvarArquivoSelecionado = new System.Windows.Forms.Button();
            this.btSalvarTodosArquivos = new System.Windows.Forms.Button();
            this.btAbrirArquivo = new System.Windows.Forms.Button();
            this.lvwItemListaArquivos = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTipo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTamanho = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDataCriacao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDataAlteracao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDataInclusao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUsuario = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCaminho = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cboDescricaoTipoArquivo = new System.Windows.Forms.ComboBox();
            this.lvwTiposArquivos = new System.Windows.Forms.ListView();
            this.colDescricao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTipos = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btInserirTipoArquivo = new System.Windows.Forms.Button();
            this.txtTiposArquivos = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gbxOpcoes = new System.Windows.Forms.GroupBox();
            this.chkOpcaoPadrao = new System.Windows.Forms.CheckBox();
            this.lvwOpcoes = new System.Windows.Forms.ListView();
            this.colNome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOpcaoPadrao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btInserirOpcao = new System.Windows.Forms.Button();
            this.txtNomeOpcao = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chkMultiplaEscolha = new System.Windows.Forms.CheckBox();
            this.gbxTexto = new System.Windows.Forms.GroupBox();
            this.chkItemTextoPermitirSalvarPadrao = new System.Windows.Forms.CheckBox();
            this.chkIdentificador = new System.Windows.Forms.CheckBox();
            this.txtTextoPadrao = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btOK = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.gbxDataHora = new System.Windows.Forms.GroupBox();
            this.optSomenteData = new System.Windows.Forms.RadioButton();
            this.optDataEHora = new System.Windows.Forms.RadioButton();
            this.btBuscarListaClipboard = new System.Windows.Forms.Button();
            this.gbxArquivo.SuspendLayout();
            this.gbxOpcoes.SuspendLayout();
            this.gbxTexto.SuspendLayout();
            this.gbxDataHora.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo:";
            // 
            // cboTipo
            // 
            this.cboTipo.BackColor = System.Drawing.Color.White;
            this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Items.AddRange(new object[] {
            "Lista de Arquivos",
            "Lista de Opções",
            "Texto",
            "Data"});
            this.cboTipo.Location = new System.Drawing.Point(88, 12);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(187, 24);
            this.cboTipo.TabIndex = 0;
            this.cboTipo.SelectedIndexChanged += new System.EventHandler(this.cboTipo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nome:";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(88, 42);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(187, 22);
            this.txtNome.TabIndex = 1;
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(88, 70);
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(439, 22);
            this.txtDescricao.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Descrição:";
            // 
            // txtAjuda
            // 
            this.txtAjuda.Location = new System.Drawing.Point(88, 98);
            this.txtAjuda.Multiline = true;
            this.txtAjuda.Name = "txtAjuda";
            this.txtAjuda.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAjuda.Size = new System.Drawing.Size(439, 114);
            this.txtAjuda.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Ajuda:";
            // 
            // chkObsObrigatorio
            // 
            this.chkObsObrigatorio.AutoSize = true;
            this.chkObsObrigatorio.Location = new System.Drawing.Point(286, 14);
            this.chkObsObrigatorio.Name = "chkObsObrigatorio";
            this.chkObsObrigatorio.Size = new System.Drawing.Size(241, 20);
            this.chkObsObrigatorio.TabIndex = 8;
            this.chkObsObrigatorio.Text = "Preencher a observação é obrigatório";
            this.chkObsObrigatorio.UseVisualStyleBackColor = true;
            // 
            // gbxArquivo
            // 
            this.gbxArquivo.Controls.Add(this.btExcluir);
            this.gbxArquivo.Controls.Add(this.btSalvarArquivoSelecionado);
            this.gbxArquivo.Controls.Add(this.btSalvarTodosArquivos);
            this.gbxArquivo.Controls.Add(this.btAbrirArquivo);
            this.gbxArquivo.Controls.Add(this.lvwItemListaArquivos);
            this.gbxArquivo.Controls.Add(this.cboDescricaoTipoArquivo);
            this.gbxArquivo.Controls.Add(this.lvwTiposArquivos);
            this.gbxArquivo.Controls.Add(this.btInserirTipoArquivo);
            this.gbxArquivo.Controls.Add(this.txtTiposArquivos);
            this.gbxArquivo.Controls.Add(this.label6);
            this.gbxArquivo.Controls.Add(this.label5);
            this.gbxArquivo.Location = new System.Drawing.Point(12, 218);
            this.gbxArquivo.Name = "gbxArquivo";
            this.gbxArquivo.Size = new System.Drawing.Size(515, 257);
            this.gbxArquivo.TabIndex = 12;
            this.gbxArquivo.TabStop = false;
            this.gbxArquivo.Text = "Selecione os tipos de arquivos permitidos";
            this.gbxArquivo.Visible = false;
            // 
            // btExcluir
            // 
            this.btExcluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExcluir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btExcluir.Location = new System.Drawing.Point(474, 181);
            this.btExcluir.Name = "btExcluir";
            this.btExcluir.Size = new System.Drawing.Size(35, 20);
            this.btExcluir.TabIndex = 19;
            this.btExcluir.Text = "X";
            this.btExcluir.UseVisualStyleBackColor = true;
            this.btExcluir.Click += new System.EventHandler(this.btExcluir_Click);
            // 
            // btSalvarArquivoSelecionado
            // 
            this.btSalvarArquivoSelecionado.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSalvarArquivoSelecionado.Location = new System.Drawing.Point(474, 207);
            this.btSalvarArquivoSelecionado.Name = "btSalvarArquivoSelecionado";
            this.btSalvarArquivoSelecionado.Size = new System.Drawing.Size(35, 19);
            this.btSalvarArquivoSelecionado.TabIndex = 18;
            this.btSalvarArquivoSelecionado.Text = ">";
            this.btSalvarArquivoSelecionado.UseVisualStyleBackColor = true;
            this.btSalvarArquivoSelecionado.Click += new System.EventHandler(this.btSalvarArquivoSelecionado_Click);
            // 
            // btSalvarTodosArquivos
            // 
            this.btSalvarTodosArquivos.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSalvarTodosArquivos.Location = new System.Drawing.Point(474, 228);
            this.btSalvarTodosArquivos.Name = "btSalvarTodosArquivos";
            this.btSalvarTodosArquivos.Size = new System.Drawing.Size(35, 19);
            this.btSalvarTodosArquivos.TabIndex = 17;
            this.btSalvarTodosArquivos.Text = ">>";
            this.btSalvarTodosArquivos.UseVisualStyleBackColor = true;
            this.btSalvarTodosArquivos.Click += new System.EventHandler(this.btSalvarTodosArquivos_Click);
            // 
            // btAbrirArquivo
            // 
            this.btAbrirArquivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAbrirArquivo.Location = new System.Drawing.Point(474, 161);
            this.btAbrirArquivo.Name = "btAbrirArquivo";
            this.btAbrirArquivo.Size = new System.Drawing.Size(35, 21);
            this.btAbrirArquivo.TabIndex = 16;
            this.btAbrirArquivo.Text = "...";
            this.btAbrirArquivo.UseVisualStyleBackColor = true;
            this.btAbrirArquivo.Click += new System.EventHandler(this.btAbrirArquivo_Click);
            // 
            // lvwItemListaArquivos
            // 
            this.lvwItemListaArquivos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.colTipo,
            this.colTamanho,
            this.colDataCriacao,
            this.colDataAlteracao,
            this.colDataInclusao,
            this.colUsuario,
            this.colCaminho});
            this.lvwItemListaArquivos.FullRowSelect = true;
            this.lvwItemListaArquivos.GridLines = true;
            this.lvwItemListaArquivos.Location = new System.Drawing.Point(6, 161);
            this.lvwItemListaArquivos.Name = "lvwItemListaArquivos";
            this.lvwItemListaArquivos.Size = new System.Drawing.Size(462, 86);
            this.lvwItemListaArquivos.TabIndex = 15;
            this.lvwItemListaArquivos.UseCompatibleStateImageBehavior = false;
            this.lvwItemListaArquivos.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Nome";
            this.columnHeader1.Width = 180;
            // 
            // colTipo
            // 
            this.colTipo.Text = "Tipo";
            this.colTipo.Width = 50;
            // 
            // colTamanho
            // 
            this.colTamanho.Text = "Tamanho (Kb)";
            this.colTamanho.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colTamanho.Width = 100;
            // 
            // colDataCriacao
            // 
            this.colDataCriacao.Text = "Data Criação";
            this.colDataCriacao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colDataCriacao.Width = 120;
            // 
            // colDataAlteracao
            // 
            this.colDataAlteracao.Text = "Data Alteração";
            this.colDataAlteracao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colDataAlteracao.Width = 120;
            // 
            // colDataInclusao
            // 
            this.colDataInclusao.Text = "Data Inclusão";
            this.colDataInclusao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colDataInclusao.Width = 120;
            // 
            // colUsuario
            // 
            this.colUsuario.Text = "Usuário";
            this.colUsuario.Width = 150;
            // 
            // colCaminho
            // 
            this.colCaminho.Text = "Caminho Completo";
            this.colCaminho.Width = 210;
            // 
            // cboDescricaoTipoArquivo
            // 
            this.cboDescricaoTipoArquivo.FormattingEnabled = true;
            this.cboDescricaoTipoArquivo.Location = new System.Drawing.Point(87, 30);
            this.cboDescricaoTipoArquivo.Name = "cboDescricaoTipoArquivo";
            this.cboDescricaoTipoArquivo.Size = new System.Drawing.Size(338, 24);
            this.cboDescricaoTipoArquivo.TabIndex = 8;
            this.cboDescricaoTipoArquivo.SelectedIndexChanged += new System.EventHandler(this.cboDescricaoTipoArquivo_SelectedIndexChanged);
            // 
            // lvwTiposArquivos
            // 
            this.lvwTiposArquivos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDescricao,
            this.colTipos});
            this.lvwTiposArquivos.FullRowSelect = true;
            this.lvwTiposArquivos.Location = new System.Drawing.Point(6, 86);
            this.lvwTiposArquivos.Name = "lvwTiposArquivos";
            this.lvwTiposArquivos.Size = new System.Drawing.Size(503, 69);
            this.lvwTiposArquivos.TabIndex = 7;
            this.lvwTiposArquivos.UseCompatibleStateImageBehavior = false;
            this.lvwTiposArquivos.View = System.Windows.Forms.View.Details;
            this.lvwTiposArquivos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvwTiposArquivos_KeyDown);
            // 
            // colDescricao
            // 
            this.colDescricao.Text = "Descrição";
            this.colDescricao.Width = 200;
            // 
            // colTipos
            // 
            this.colTipos.Text = "Tipos";
            this.colTipos.Width = 295;
            // 
            // btInserirTipoArquivo
            // 
            this.btInserirTipoArquivo.Location = new System.Drawing.Point(432, 56);
            this.btInserirTipoArquivo.Name = "btInserirTipoArquivo";
            this.btInserirTipoArquivo.Size = new System.Drawing.Size(77, 24);
            this.btInserirTipoArquivo.TabIndex = 6;
            this.btInserirTipoArquivo.Text = "Inserir";
            this.btInserirTipoArquivo.UseVisualStyleBackColor = true;
            this.btInserirTipoArquivo.Click += new System.EventHandler(this.btInserirTipoArquivo_Click);
            // 
            // txtTiposArquivos
            // 
            this.txtTiposArquivos.Location = new System.Drawing.Point(87, 58);
            this.txtTiposArquivos.Name = "txtTiposArquivos";
            this.txtTiposArquivos.Size = new System.Drawing.Size(338, 22);
            this.txtTiposArquivos.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 16);
            this.label6.TabIndex = 6;
            this.label6.Text = "Tipos:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Descrição:";
            // 
            // gbxOpcoes
            // 
            this.gbxOpcoes.Controls.Add(this.btBuscarListaClipboard);
            this.gbxOpcoes.Controls.Add(this.chkOpcaoPadrao);
            this.gbxOpcoes.Controls.Add(this.lvwOpcoes);
            this.gbxOpcoes.Controls.Add(this.btInserirOpcao);
            this.gbxOpcoes.Controls.Add(this.txtNomeOpcao);
            this.gbxOpcoes.Controls.Add(this.label7);
            this.gbxOpcoes.Controls.Add(this.chkMultiplaEscolha);
            this.gbxOpcoes.Location = new System.Drawing.Point(558, 278);
            this.gbxOpcoes.Name = "gbxOpcoes";
            this.gbxOpcoes.Size = new System.Drawing.Size(515, 257);
            this.gbxOpcoes.TabIndex = 13;
            this.gbxOpcoes.TabStop = false;
            this.gbxOpcoes.Text = "Insira as opções possíveis";
            this.gbxOpcoes.Visible = false;
            // 
            // chkOpcaoPadrao
            // 
            this.chkOpcaoPadrao.AutoSize = true;
            this.chkOpcaoPadrao.Location = new System.Drawing.Point(293, 53);
            this.chkOpcaoPadrao.Name = "chkOpcaoPadrao";
            this.chkOpcaoPadrao.Size = new System.Drawing.Size(110, 20);
            this.chkOpcaoPadrao.TabIndex = 13;
            this.chkOpcaoPadrao.Text = "Opção Padrão";
            this.chkOpcaoPadrao.UseVisualStyleBackColor = true;
            // 
            // lvwOpcoes
            // 
            this.lvwOpcoes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNome,
            this.colOpcaoPadrao});
            this.lvwOpcoes.FullRowSelect = true;
            this.lvwOpcoes.Location = new System.Drawing.Point(6, 78);
            this.lvwOpcoes.Name = "lvwOpcoes";
            this.lvwOpcoes.Size = new System.Drawing.Size(503, 165);
            this.lvwOpcoes.TabIndex = 12;
            this.lvwOpcoes.UseCompatibleStateImageBehavior = false;
            this.lvwOpcoes.View = System.Windows.Forms.View.Details;
            this.lvwOpcoes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvwOpcoes_KeyDown);
            // 
            // colNome
            // 
            this.colNome.Text = "Nome";
            this.colNome.Width = 400;
            // 
            // colOpcaoPadrao
            // 
            this.colOpcaoPadrao.Text = "Opção Padrão";
            this.colOpcaoPadrao.Width = 95;
            // 
            // btInserirOpcao
            // 
            this.btInserirOpcao.Location = new System.Drawing.Point(432, 48);
            this.btInserirOpcao.Name = "btInserirOpcao";
            this.btInserirOpcao.Size = new System.Drawing.Size(77, 24);
            this.btInserirOpcao.TabIndex = 11;
            this.btInserirOpcao.Text = "Inserir";
            this.btInserirOpcao.UseVisualStyleBackColor = true;
            this.btInserirOpcao.Click += new System.EventHandler(this.cmdInserirOpcao_Click);
            // 
            // txtNomeOpcao
            // 
            this.txtNomeOpcao.Location = new System.Drawing.Point(76, 50);
            this.txtNomeOpcao.Name = "txtNomeOpcao";
            this.txtNomeOpcao.Size = new System.Drawing.Size(211, 22);
            this.txtNomeOpcao.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 16);
            this.label7.TabIndex = 10;
            this.label7.Text = "Nome:";
            // 
            // chkMultiplaEscolha
            // 
            this.chkMultiplaEscolha.AutoSize = true;
            this.chkMultiplaEscolha.Location = new System.Drawing.Point(27, 21);
            this.chkMultiplaEscolha.Name = "chkMultiplaEscolha";
            this.chkMultiplaEscolha.Size = new System.Drawing.Size(123, 20);
            this.chkMultiplaEscolha.TabIndex = 9;
            this.chkMultiplaEscolha.Text = "Múltipla Escolha";
            this.chkMultiplaEscolha.UseVisualStyleBackColor = true;
            // 
            // gbxTexto
            // 
            this.gbxTexto.Controls.Add(this.chkItemTextoPermitirSalvarPadrao);
            this.gbxTexto.Controls.Add(this.chkIdentificador);
            this.gbxTexto.Controls.Add(this.txtTextoPadrao);
            this.gbxTexto.Controls.Add(this.label8);
            this.gbxTexto.Location = new System.Drawing.Point(558, 15);
            this.gbxTexto.Name = "gbxTexto";
            this.gbxTexto.Size = new System.Drawing.Size(515, 257);
            this.gbxTexto.TabIndex = 14;
            this.gbxTexto.TabStop = false;
            this.gbxTexto.Text = "Informe o texto padrão";
            this.gbxTexto.Visible = false;
            // 
            // chkItemTextoPermitirSalvarPadrao
            // 
            this.chkItemTextoPermitirSalvarPadrao.AutoSize = true;
            this.chkItemTextoPermitirSalvarPadrao.Location = new System.Drawing.Point(327, 20);
            this.chkItemTextoPermitirSalvarPadrao.Name = "chkItemTextoPermitirSalvarPadrao";
            this.chkItemTextoPermitirSalvarPadrao.Size = new System.Drawing.Size(182, 20);
            this.chkItemTextoPermitirSalvarPadrao.TabIndex = 15;
            this.chkItemTextoPermitirSalvarPadrao.Text = "Permitir salvar valor padrão";
            this.chkItemTextoPermitirSalvarPadrao.UseVisualStyleBackColor = true;
            // 
            // chkIdentificador
            // 
            this.chkIdentificador.AutoSize = true;
            this.chkIdentificador.Location = new System.Drawing.Point(212, 20);
            this.chkIdentificador.Name = "chkIdentificador";
            this.chkIdentificador.Size = new System.Drawing.Size(96, 20);
            this.chkIdentificador.TabIndex = 14;
            this.chkIdentificador.Text = "Identificador";
            this.chkIdentificador.UseVisualStyleBackColor = true;
            // 
            // txtTextoPadrao
            // 
            this.txtTextoPadrao.Location = new System.Drawing.Point(6, 46);
            this.txtTextoPadrao.Multiline = true;
            this.txtTextoPadrao.Name = "txtTextoPadrao";
            this.txtTextoPadrao.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTextoPadrao.Size = new System.Drawing.Size(503, 205);
            this.txtTextoPadrao.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 16);
            this.label8.TabIndex = 8;
            this.label8.Text = "Texto Padrão:";
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(413, 481);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(114, 38);
            this.btOK.TabIndex = 13;
            this.btOK.Text = "OK";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.Location = new System.Drawing.Point(293, 481);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(114, 38);
            this.btCancelar.TabIndex = 14;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // gbxDataHora
            // 
            this.gbxDataHora.Controls.Add(this.optSomenteData);
            this.gbxDataHora.Controls.Add(this.optDataEHora);
            this.gbxDataHora.Location = new System.Drawing.Point(558, 541);
            this.gbxDataHora.Name = "gbxDataHora";
            this.gbxDataHora.Size = new System.Drawing.Size(515, 257);
            this.gbxDataHora.TabIndex = 15;
            this.gbxDataHora.TabStop = false;
            this.gbxDataHora.Text = "Com hora ou sem hora";
            this.gbxDataHora.Visible = false;
            // 
            // optSomenteData
            // 
            this.optSomenteData.AutoSize = true;
            this.optSomenteData.Location = new System.Drawing.Point(9, 61);
            this.optSomenteData.Name = "optSomenteData";
            this.optSomenteData.Size = new System.Drawing.Size(109, 20);
            this.optSomenteData.TabIndex = 1;
            this.optSomenteData.Text = "Somente Data";
            this.optSomenteData.UseVisualStyleBackColor = true;
            // 
            // optDataEHora
            // 
            this.optDataEHora.AutoSize = true;
            this.optDataEHora.Checked = true;
            this.optDataEHora.Location = new System.Drawing.Point(9, 35);
            this.optDataEHora.Name = "optDataEHora";
            this.optDataEHora.Size = new System.Drawing.Size(95, 20);
            this.optDataEHora.TabIndex = 0;
            this.optDataEHora.TabStop = true;
            this.optDataEHora.Text = "Data e Hora";
            this.optDataEHora.UseVisualStyleBackColor = true;
            // 
            // btBuscarListaClipboard
            // 
            this.btBuscarListaClipboard.Location = new System.Drawing.Point(267, 18);
            this.btBuscarListaClipboard.Name = "btBuscarListaClipboard";
            this.btBuscarListaClipboard.Size = new System.Drawing.Size(242, 24);
            this.btBuscarListaClipboard.TabIndex = 14;
            this.btBuscarListaClipboard.Text = "Buscar lista da Área de Transferência";
            this.btBuscarListaClipboard.UseVisualStyleBackColor = true;
            this.btBuscarListaClipboard.Click += new System.EventHandler(this.btBuscarListaClipboard_Click);
            // 
            // frmEditaItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 750);
            this.Controls.Add(this.gbxDataHora);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.gbxTexto);
            this.Controls.Add(this.gbxOpcoes);
            this.Controls.Add(this.gbxArquivo);
            this.Controls.Add(this.chkObsObrigatorio);
            this.Controls.Add(this.txtAjuda);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboTipo);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "frmEditaItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Check List - Editor de Itens";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmEditaItem_FormClosed);
            this.gbxArquivo.ResumeLayout(false);
            this.gbxArquivo.PerformLayout();
            this.gbxOpcoes.ResumeLayout(false);
            this.gbxOpcoes.PerformLayout();
            this.gbxTexto.ResumeLayout(false);
            this.gbxTexto.PerformLayout();
            this.gbxDataHora.ResumeLayout(false);
            this.gbxDataHora.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAjuda;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkObsObrigatorio;
        private System.Windows.Forms.GroupBox gbxArquivo;
        private System.Windows.Forms.GroupBox gbxOpcoes;
        private System.Windows.Forms.GroupBox gbxTexto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView lvwTiposArquivos;
        private System.Windows.Forms.ColumnHeader colDescricao;
        private System.Windows.Forms.ColumnHeader colTipos;
        private System.Windows.Forms.Button btInserirTipoArquivo;
        private System.Windows.Forms.TextBox txtTiposArquivos;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkMultiplaEscolha;
        private System.Windows.Forms.ListView lvwOpcoes;
        private System.Windows.Forms.ColumnHeader colNome;
        private System.Windows.Forms.Button btInserirOpcao;
        private System.Windows.Forms.TextBox txtNomeOpcao;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTextoPadrao;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.CheckBox chkOpcaoPadrao;
        private System.Windows.Forms.ColumnHeader colOpcaoPadrao;
        private System.Windows.Forms.ComboBox cboDescricaoTipoArquivo;
        private System.Windows.Forms.CheckBox chkIdentificador;
        private System.Windows.Forms.CheckBox chkItemTextoPermitirSalvarPadrao;
        private System.Windows.Forms.ListView lvwItemListaArquivos;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader colTipo;
        private System.Windows.Forms.ColumnHeader colTamanho;
        private System.Windows.Forms.ColumnHeader colDataCriacao;
        private System.Windows.Forms.ColumnHeader colDataAlteracao;
        private System.Windows.Forms.ColumnHeader colDataInclusao;
        private System.Windows.Forms.ColumnHeader colUsuario;
        private System.Windows.Forms.ColumnHeader colCaminho;
        private System.Windows.Forms.Button btExcluir;
        private System.Windows.Forms.Button btSalvarArquivoSelecionado;
        private System.Windows.Forms.Button btSalvarTodosArquivos;
        private System.Windows.Forms.Button btAbrirArquivo;
        private System.Windows.Forms.GroupBox gbxDataHora;
        private System.Windows.Forms.RadioButton optSomenteData;
        private System.Windows.Forms.RadioButton optDataEHora;
        private System.Windows.Forms.Button btBuscarListaClipboard;
    }
}