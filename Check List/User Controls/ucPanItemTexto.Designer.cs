namespace Check_List
{
    partial class ucPanItemTexto
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
            this.panItemTexto = new System.Windows.Forms.Panel();
            this.btTextoPadrao = new System.Windows.Forms.Button();
            this.btTelaCheia = new System.Windows.Forms.Button();
            this.btBuscarValorPadrao = new System.Windows.Forms.Button();
            this.btSalvarValorPadrao = new System.Windows.Forms.Button();
            this.txtItemTexto = new System.Windows.Forms.TextBox();
            this.panItemTexto.SuspendLayout();
            this.SuspendLayout();
            // 
            // panItemTexto
            // 
            this.panItemTexto.Controls.Add(this.btTextoPadrao);
            this.panItemTexto.Controls.Add(this.btTelaCheia);
            this.panItemTexto.Controls.Add(this.btBuscarValorPadrao);
            this.panItemTexto.Controls.Add(this.btSalvarValorPadrao);
            this.panItemTexto.Controls.Add(this.txtItemTexto);
            this.panItemTexto.Location = new System.Drawing.Point(0, 0);
            this.panItemTexto.Name = "panItemTexto";
            this.panItemTexto.Size = new System.Drawing.Size(601, 196);
            this.panItemTexto.TabIndex = 11;
            // 
            // btTextoPadrao
            // 
            this.btTextoPadrao.Image = global::Check_List.Properties.Resources.undo1;
            this.btTextoPadrao.Location = new System.Drawing.Point(566, 42);
            this.btTextoPadrao.Name = "btTextoPadrao";
            this.btTextoPadrao.Size = new System.Drawing.Size(32, 33);
            this.btTextoPadrao.TabIndex = 13;
            this.btTextoPadrao.UseVisualStyleBackColor = true;
            this.btTextoPadrao.Click += new System.EventHandler(this.btTextoPadrao_Click);
            // 
            // btTelaCheia
            // 
            this.btTelaCheia.Image = global::Check_List.Properties.Resources.view_fullscreen;
            this.btTelaCheia.Location = new System.Drawing.Point(566, 3);
            this.btTelaCheia.Name = "btTelaCheia";
            this.btTelaCheia.Size = new System.Drawing.Size(32, 33);
            this.btTelaCheia.TabIndex = 12;
            this.btTelaCheia.UseVisualStyleBackColor = true;
            this.btTelaCheia.Click += new System.EventHandler(this.btTelaCheia_Click);
            // 
            // btBuscarValorPadrao
            // 
            this.btBuscarValorPadrao.Location = new System.Drawing.Point(280, 168);
            this.btBuscarValorPadrao.Name = "btBuscarValorPadrao";
            this.btBuscarValorPadrao.Size = new System.Drawing.Size(137, 25);
            this.btBuscarValorPadrao.TabIndex = 11;
            this.btBuscarValorPadrao.Text = "Buscar texto padrão";
            this.btBuscarValorPadrao.UseVisualStyleBackColor = true;
            this.btBuscarValorPadrao.Click += new System.EventHandler(this.btBuscarValorPadrao_Click);
            this.btBuscarValorPadrao.MouseEnter += new System.EventHandler(this.btBuscarValorPadrao_MouseEnter);
            this.btBuscarValorPadrao.MouseLeave += new System.EventHandler(this.btBuscarValorPadrao_MouseLeave);
            // 
            // btSalvarValorPadrao
            // 
            this.btSalvarValorPadrao.Location = new System.Drawing.Point(423, 168);
            this.btSalvarValorPadrao.Name = "btSalvarValorPadrao";
            this.btSalvarValorPadrao.Size = new System.Drawing.Size(137, 25);
            this.btSalvarValorPadrao.TabIndex = 10;
            this.btSalvarValorPadrao.Text = "Salvar texto padrão";
            this.btSalvarValorPadrao.UseVisualStyleBackColor = true;
            this.btSalvarValorPadrao.Click += new System.EventHandler(this.btSalvarValorPadrao_Click);
            this.btSalvarValorPadrao.MouseEnter += new System.EventHandler(this.btSalvarValorPadrao_MouseEnter);
            this.btSalvarValorPadrao.MouseLeave += new System.EventHandler(this.btSalvarValorPadrao_MouseLeave);
            // 
            // txtItemTexto
            // 
            this.txtItemTexto.Location = new System.Drawing.Point(3, 3);
            this.txtItemTexto.Multiline = true;
            this.txtItemTexto.Name = "txtItemTexto";
            this.txtItemTexto.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtItemTexto.Size = new System.Drawing.Size(559, 161);
            this.txtItemTexto.TabIndex = 9;
            this.txtItemTexto.TextChanged += new System.EventHandler(this.txtItemTexto_TextChanged);
            this.txtItemTexto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItemTexto_KeyDown);
            // 
            // ucPanItemTexto
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.panItemTexto);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucPanItemTexto";
            this.Size = new System.Drawing.Size(601, 196);
            this.Resize += new System.EventHandler(this.ucPanItemTexto_Resize);
            this.panItemTexto.ResumeLayout(false);
            this.panItemTexto.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panItemTexto;
        private System.Windows.Forms.TextBox txtItemTexto;
        private System.Windows.Forms.Button btBuscarValorPadrao;
        private System.Windows.Forms.Button btSalvarValorPadrao;
        private System.Windows.Forms.Button btTelaCheia;
        private System.Windows.Forms.Button btTextoPadrao;



    }
}
