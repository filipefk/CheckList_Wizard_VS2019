namespace Check_List
{
    partial class frmListaComentarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListaComentarios));
            this.lvwListaComentarios = new System.Windows.Forms.ListView();
            this.colDataHora = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNomeMaquina = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIPs = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUsuario = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colComentario = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btNovo = new System.Windows.Forms.Button();
            this.btExcluir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvwListaComentarios
            // 
            this.lvwListaComentarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwListaComentarios.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colComentario,
            this.colDataHora,
            this.colNomeMaquina,
            this.colIPs,
            this.colUsuario});
            this.lvwListaComentarios.FullRowSelect = true;
            this.lvwListaComentarios.GridLines = true;
            this.lvwListaComentarios.Location = new System.Drawing.Point(0, 0);
            this.lvwListaComentarios.Name = "lvwListaComentarios";
            this.lvwListaComentarios.Size = new System.Drawing.Size(1104, 459);
            this.lvwListaComentarios.TabIndex = 15;
            this.lvwListaComentarios.UseCompatibleStateImageBehavior = false;
            this.lvwListaComentarios.View = System.Windows.Forms.View.Details;
            // 
            // colDataHora
            // 
            this.colDataHora.Text = "Data e Hora";
            this.colDataHora.Width = 130;
            // 
            // colNomeMaquina
            // 
            this.colNomeMaquina.Text = "Nome da Máquina";
            this.colNomeMaquina.Width = 160;
            // 
            // colIPs
            // 
            this.colIPs.Text = "Lista de IPs";
            this.colIPs.Width = 0;
            // 
            // colUsuario
            // 
            this.colUsuario.Text = "Usuário";
            this.colUsuario.Width = 209;
            // 
            // colComentario
            // 
            this.colComentario.Text = "Comentário";
            this.colComentario.Width = 600;
            // 
            // btNovo
            // 
            this.btNovo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btNovo.Location = new System.Drawing.Point(12, 465);
            this.btNovo.Name = "btNovo";
            this.btNovo.Size = new System.Drawing.Size(152, 50);
            this.btNovo.TabIndex = 16;
            this.btNovo.Text = "Novo";
            this.btNovo.UseVisualStyleBackColor = true;
            this.btNovo.Click += new System.EventHandler(this.btNovo_Click);
            // 
            // btExcluir
            // 
            this.btExcluir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btExcluir.Location = new System.Drawing.Point(941, 465);
            this.btExcluir.Name = "btExcluir";
            this.btExcluir.Size = new System.Drawing.Size(152, 50);
            this.btExcluir.TabIndex = 17;
            this.btExcluir.Text = "Excluir";
            this.btExcluir.UseVisualStyleBackColor = true;
            // 
            // frmListaComentarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 527);
            this.Controls.Add(this.btExcluir);
            this.Controls.Add(this.btNovo);
            this.Controls.Add(this.lvwListaComentarios);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmListaComentarios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de Comentários";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwListaComentarios;
        private System.Windows.Forms.ColumnHeader colDataHora;
        private System.Windows.Forms.ColumnHeader colNomeMaquina;
        private System.Windows.Forms.ColumnHeader colIPs;
        private System.Windows.Forms.ColumnHeader colUsuario;
        private System.Windows.Forms.ColumnHeader colComentario;
        private System.Windows.Forms.Button btNovo;
        private System.Windows.Forms.Button btExcluir;


    }
}