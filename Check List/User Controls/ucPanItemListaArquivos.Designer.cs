namespace Check_List
{
    partial class ucPanItemListaArquivos
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panItenListaArquivos = new System.Windows.Forms.Panel();
            this.btExcluir = new System.Windows.Forms.Button();
            this.lvwItemListaArquivos = new System.Windows.Forms.ListView();
            this.colNome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTipo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTamanho = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDataCriacao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDataAlteracao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDataInclusao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUsuario = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCaminho = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btSalvarArquivoSelecionado = new System.Windows.Forms.Button();
            this.btSalvarTodosArquivos = new System.Windows.Forms.Button();
            this.btAbrirArquivo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panItenListaArquivos.SuspendLayout();
            this.SuspendLayout();
            // 
            // panItenListaArquivos
            // 
            this.panItenListaArquivos.Controls.Add(this.btExcluir);
            this.panItenListaArquivos.Controls.Add(this.lvwItemListaArquivos);
            this.panItenListaArquivos.Controls.Add(this.btSalvarArquivoSelecionado);
            this.panItenListaArquivos.Controls.Add(this.btSalvarTodosArquivos);
            this.panItenListaArquivos.Controls.Add(this.btAbrirArquivo);
            this.panItenListaArquivos.Controls.Add(this.label2);
            this.panItenListaArquivos.Location = new System.Drawing.Point(0, 0);
            this.panItenListaArquivos.Name = "panItenListaArquivos";
            this.panItenListaArquivos.Size = new System.Drawing.Size(601, 196);
            this.panItenListaArquivos.TabIndex = 9;
            // 
            // btExcluir
            // 
            this.btExcluir.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExcluir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btExcluir.Location = new System.Drawing.Point(562, 52);
            this.btExcluir.Name = "btExcluir";
            this.btExcluir.Size = new System.Drawing.Size(34, 27);
            this.btExcluir.TabIndex = 15;
            this.btExcluir.Text = "X";
            this.btExcluir.UseVisualStyleBackColor = true;
            this.btExcluir.Click += new System.EventHandler(this.btExcluir_Click);
            this.btExcluir.MouseEnter += new System.EventHandler(this.btExcluir_MouseEnter);
            this.btExcluir.MouseLeave += new System.EventHandler(this.btExcluir_MouseLeave);
            // 
            // lvwItemListaArquivos
            // 
            this.lvwItemListaArquivos.AllowDrop = true;
            this.lvwItemListaArquivos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNome,
            this.colTipo,
            this.colTamanho,
            this.colDataCriacao,
            this.colDataAlteracao,
            this.colDataInclusao,
            this.colUsuario,
            this.colCaminho});
            this.lvwItemListaArquivos.FullRowSelect = true;
            this.lvwItemListaArquivos.GridLines = true;
            this.lvwItemListaArquivos.Location = new System.Drawing.Point(6, 19);
            this.lvwItemListaArquivos.Name = "lvwItemListaArquivos";
            this.lvwItemListaArquivos.Size = new System.Drawing.Size(550, 174);
            this.lvwItemListaArquivos.TabIndex = 14;
            this.lvwItemListaArquivos.UseCompatibleStateImageBehavior = false;
            this.lvwItemListaArquivos.View = System.Windows.Forms.View.Details;
            this.lvwItemListaArquivos.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvwItemListaArquivos_DragDrop);
            this.lvwItemListaArquivos.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvwItemListaArquivos_DragEnter);
            this.lvwItemListaArquivos.DoubleClick += new System.EventHandler(this.lvwItemListaArquivos_DoubleClick);
            this.lvwItemListaArquivos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvwItemListaArquivos_KeyDown);
            // 
            // colNome
            // 
            this.colNome.Text = "Nome";
            this.colNome.Width = 180;
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
            // btSalvarArquivoSelecionado
            // 
            this.btSalvarArquivoSelecionado.Location = new System.Drawing.Point(562, 133);
            this.btSalvarArquivoSelecionado.Name = "btSalvarArquivoSelecionado";
            this.btSalvarArquivoSelecionado.Size = new System.Drawing.Size(34, 27);
            this.btSalvarArquivoSelecionado.TabIndex = 13;
            this.btSalvarArquivoSelecionado.Text = ">";
            this.btSalvarArquivoSelecionado.UseVisualStyleBackColor = true;
            this.btSalvarArquivoSelecionado.Click += new System.EventHandler(this.btSalvarArquivoSelecionado_Click);
            this.btSalvarArquivoSelecionado.MouseEnter += new System.EventHandler(this.btSalvarArquivoSelecionado_MouseEnter);
            this.btSalvarArquivoSelecionado.MouseLeave += new System.EventHandler(this.btSalvarArquivoSelecionado_MouseLeave);
            // 
            // btSalvarTodosArquivos
            // 
            this.btSalvarTodosArquivos.Location = new System.Drawing.Point(562, 166);
            this.btSalvarTodosArquivos.Name = "btSalvarTodosArquivos";
            this.btSalvarTodosArquivos.Size = new System.Drawing.Size(34, 27);
            this.btSalvarTodosArquivos.TabIndex = 12;
            this.btSalvarTodosArquivos.Text = ">>";
            this.btSalvarTodosArquivos.UseVisualStyleBackColor = true;
            this.btSalvarTodosArquivos.Click += new System.EventHandler(this.btSalvarTodosArquivos_Click);
            this.btSalvarTodosArquivos.MouseEnter += new System.EventHandler(this.btSalvarTodosArquivos_MouseEnter);
            this.btSalvarTodosArquivos.MouseLeave += new System.EventHandler(this.btSalvarTodosArquivos_MouseLeave);
            // 
            // btAbrirArquivo
            // 
            this.btAbrirArquivo.Location = new System.Drawing.Point(562, 19);
            this.btAbrirArquivo.Name = "btAbrirArquivo";
            this.btAbrirArquivo.Size = new System.Drawing.Size(34, 27);
            this.btAbrirArquivo.TabIndex = 11;
            this.btAbrirArquivo.Text = "...";
            this.btAbrirArquivo.UseVisualStyleBackColor = true;
            this.btAbrirArquivo.Click += new System.EventHandler(this.btAbrirArquivo_Click);
            this.btAbrirArquivo.MouseEnter += new System.EventHandler(this.btAbrirArquivo_MouseEnter);
            this.btAbrirArquivo.MouseLeave += new System.EventHandler(this.btAbrirArquivo_MouseLeave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Arquivos:";
            // 
            // ucPanItemListaArquivos
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.panItenListaArquivos);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucPanItemListaArquivos";
            this.Size = new System.Drawing.Size(601, 196);
            this.Resize += new System.EventHandler(this.ucPanItemListaArquivos_Resize);
            this.panItenListaArquivos.ResumeLayout(false);
            this.panItenListaArquivos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panItenListaArquivos;
        public System.Windows.Forms.ListView lvwItemListaArquivos;
        public System.Windows.Forms.ColumnHeader colNome;
        public System.Windows.Forms.ColumnHeader colTipo;
        public System.Windows.Forms.ColumnHeader colTamanho;
        public System.Windows.Forms.ColumnHeader colCaminho;
        public System.Windows.Forms.Button btSalvarArquivoSelecionado;
        public System.Windows.Forms.Button btSalvarTodosArquivos;
        public System.Windows.Forms.Button btAbrirArquivo;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Button btExcluir;
        public System.Windows.Forms.ColumnHeader colDataCriacao;
        public System.Windows.Forms.ColumnHeader colDataAlteracao;
        public System.Windows.Forms.ColumnHeader colDataInclusao;
        public System.Windows.Forms.ColumnHeader colUsuario;


    }
}
