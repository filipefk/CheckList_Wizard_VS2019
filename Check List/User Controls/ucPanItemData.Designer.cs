namespace Check_List
{
    partial class ucPanItemData
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
            this.txtDataHora = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.dthDataHora = new System.Windows.Forms.DateTimePicker();
            this.panItemArquivo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panItemArquivo
            // 
            this.panItemArquivo.Controls.Add(this.txtDataHora);
            this.panItemArquivo.Controls.Add(this.lblNome);
            this.panItemArquivo.Controls.Add(this.dthDataHora);
            this.panItemArquivo.Location = new System.Drawing.Point(0, 0);
            this.panItemArquivo.Name = "panItemArquivo";
            this.panItemArquivo.Size = new System.Drawing.Size(601, 196);
            this.panItemArquivo.TabIndex = 8;
            // 
            // txtDataHora
            // 
            this.txtDataHora.Location = new System.Drawing.Point(68, 79);
            this.txtDataHora.Name = "txtDataHora";
            this.txtDataHora.Size = new System.Drawing.Size(147, 22);
            this.txtDataHora.TabIndex = 18;
            this.txtDataHora.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDataHora_KeyDown);
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(3, 0);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(77, 16);
            this.lblNome.TabIndex = 17;
            this.lblNome.Text = "Data e Hora";
            // 
            // dthDataHora
            // 
            this.dthDataHora.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            this.dthDataHora.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dthDataHora.Location = new System.Drawing.Point(68, 79);
            this.dthDataHora.Name = "dthDataHora";
            this.dthDataHora.Size = new System.Drawing.Size(182, 22);
            this.dthDataHora.TabIndex = 0;
            this.dthDataHora.Value = new System.DateTime(2012, 11, 15, 20, 54, 29, 0);
            this.dthDataHora.CloseUp += new System.EventHandler(this.dthDataHora_CloseUp);
            this.dthDataHora.ValueChanged += new System.EventHandler(this.dthDataHora_ValueChanged);
            this.dthDataHora.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dthDataHora_KeyDown);
            // 
            // ucPanItemData
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.panItemArquivo);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucPanItemData";
            this.Size = new System.Drawing.Size(601, 196);
            this.panItemArquivo.ResumeLayout(false);
            this.panItemArquivo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panItemArquivo;
        private System.Windows.Forms.DateTimePicker dthDataHora;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtDataHora;

    }
}
