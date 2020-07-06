namespace Check_List
{
    partial class ucPanItemArquivo
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
            this.panItemArquivo = new System.Windows.Forms.Panel();
            this.txtItemArquivo = new System.Windows.Forms.TextBox();
            this.btExcluir = new System.Windows.Forms.Button();
            this.lblTamanhoArquivo = new System.Windows.Forms.Label();
            this.btSalvarArquivo = new System.Windows.Forms.Button();
            this.btAbrirArquivo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panItemArquivo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panItemArquivo
            // 
            this.panItemArquivo.Controls.Add(this.txtItemArquivo);
            this.panItemArquivo.Controls.Add(this.btExcluir);
            this.panItemArquivo.Controls.Add(this.lblTamanhoArquivo);
            this.panItemArquivo.Controls.Add(this.btSalvarArquivo);
            this.panItemArquivo.Controls.Add(this.btAbrirArquivo);
            this.panItemArquivo.Controls.Add(this.label1);
            this.panItemArquivo.Location = new System.Drawing.Point(0, 0);
            this.panItemArquivo.Name = "panItemArquivo";
            this.panItemArquivo.Size = new System.Drawing.Size(601, 196);
            this.panItemArquivo.TabIndex = 8;
            // 
            // txtItemArquivo
            // 
            this.txtItemArquivo.BackColor = System.Drawing.Color.White;
            this.txtItemArquivo.Location = new System.Drawing.Point(2, 25);
            this.txtItemArquivo.Multiline = true;
            this.txtItemArquivo.Name = "txtItemArquivo";
            this.txtItemArquivo.ReadOnly = true;
            this.txtItemArquivo.Size = new System.Drawing.Size(550, 147);
            this.txtItemArquivo.TabIndex = 21;
            // 
            // btExcluir
            // 
            this.btExcluir.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExcluir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btExcluir.Location = new System.Drawing.Point(564, 58);
            this.btExcluir.Name = "btExcluir";
            this.btExcluir.Size = new System.Drawing.Size(34, 27);
            this.btExcluir.TabIndex = 20;
            this.btExcluir.Text = "X";
            this.btExcluir.UseVisualStyleBackColor = true;
            // 
            // lblTamanhoArquivo
            // 
            this.lblTamanhoArquivo.AutoSize = true;
            this.lblTamanhoArquivo.Location = new System.Drawing.Point(5, 175);
            this.lblTamanhoArquivo.Name = "lblTamanhoArquivo";
            this.lblTamanhoArquivo.Size = new System.Drawing.Size(64, 16);
            this.lblTamanhoArquivo.TabIndex = 19;
            this.lblTamanhoArquivo.Text = "Tamanho:";
            // 
            // btSalvarArquivo
            // 
            this.btSalvarArquivo.Location = new System.Drawing.Point(564, 145);
            this.btSalvarArquivo.Name = "btSalvarArquivo";
            this.btSalvarArquivo.Size = new System.Drawing.Size(34, 27);
            this.btSalvarArquivo.TabIndex = 18;
            this.btSalvarArquivo.Text = ">";
            this.btSalvarArquivo.UseVisualStyleBackColor = true;
            // 
            // btAbrirArquivo
            // 
            this.btAbrirArquivo.Location = new System.Drawing.Point(564, 25);
            this.btAbrirArquivo.Name = "btAbrirArquivo";
            this.btAbrirArquivo.Size = new System.Drawing.Size(34, 27);
            this.btAbrirArquivo.TabIndex = 17;
            this.btAbrirArquivo.Text = "...";
            this.btAbrirArquivo.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 16);
            this.label1.TabIndex = 16;
            this.label1.Text = "Arquivo:";
            // 
            // ucPanItemArquivo
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.panItemArquivo);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucPanItemArquivo";
            this.Size = new System.Drawing.Size(601, 196);
            this.Resize += new System.EventHandler(this.ucPanItemArquivo_Resize);
            this.panItemArquivo.ResumeLayout(false);
            this.panItemArquivo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panItemArquivo;
        private System.Windows.Forms.TextBox txtItemArquivo;
        private System.Windows.Forms.Button btExcluir;
        private System.Windows.Forms.Label lblTamanhoArquivo;
        private System.Windows.Forms.Button btSalvarArquivo;
        private System.Windows.Forms.Button btAbrirArquivo;
        private System.Windows.Forms.Label label1;

    }
}
