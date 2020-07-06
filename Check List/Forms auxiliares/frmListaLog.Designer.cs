namespace Check_List
{
    partial class frmListaLog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListaLog));
            this.lvwListaLog = new System.Windows.Forms.ListView();
            this.colDataHora = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNomeMaquina = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIPs = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUsuario = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCaminhoCompletoArquivo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lvwListaLog
            // 
            this.lvwListaLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwListaLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDataHora,
            this.colNomeMaquina,
            this.colIPs,
            this.colUsuario,
            this.colCaminhoCompletoArquivo});
            this.lvwListaLog.FullRowSelect = true;
            this.lvwListaLog.GridLines = true;
            this.lvwListaLog.Location = new System.Drawing.Point(0, 0);
            this.lvwListaLog.Name = "lvwListaLog";
            this.lvwListaLog.Size = new System.Drawing.Size(983, 546);
            this.lvwListaLog.TabIndex = 15;
            this.lvwListaLog.UseCompatibleStateImageBehavior = false;
            this.lvwListaLog.View = System.Windows.Forms.View.Details;
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
            // colCaminhoCompletoArquivo
            // 
            this.colCaminhoCompletoArquivo.Text = "Caminho completo do arquivo";
            this.colCaminhoCompletoArquivo.Width = 459;
            // 
            // frmListaLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 546);
            this.Controls.Add(this.lvwListaLog);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmListaLog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Log de salvamento";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwListaLog;
        private System.Windows.Forms.ColumnHeader colDataHora;
        private System.Windows.Forms.ColumnHeader colNomeMaquina;
        private System.Windows.Forms.ColumnHeader colIPs;
        private System.Windows.Forms.ColumnHeader colUsuario;
        private System.Windows.Forms.ColumnHeader colCaminhoCompletoArquivo;


    }
}