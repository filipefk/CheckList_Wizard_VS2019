namespace Check_List
{
    partial class frmSelecionarModulo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelecionarModulo));
            this.llblEditorModelos = new System.Windows.Forms.LinkLabel();
            this.llblAbrirCheckList = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // llblEditorModelos
            // 
            this.llblEditorModelos.AutoSize = true;
            this.llblEditorModelos.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblEditorModelos.Location = new System.Drawing.Point(21, 22);
            this.llblEditorModelos.Name = "llblEditorModelos";
            this.llblEditorModelos.Size = new System.Drawing.Size(305, 22);
            this.llblEditorModelos.TabIndex = 0;
            this.llblEditorModelos.TabStop = true;
            this.llblEditorModelos.Text = "Editor de Modelos de CheckList";
            this.llblEditorModelos.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblEditorModelos_LinkClicked);
            // 
            // llblAbrirCheckList
            // 
            this.llblAbrirCheckList.AutoSize = true;
            this.llblAbrirCheckList.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblAbrirCheckList.Location = new System.Drawing.Point(21, 65);
            this.llblAbrirCheckList.Name = "llblAbrirCheckList";
            this.llblAbrirCheckList.Size = new System.Drawing.Size(154, 22);
            this.llblAbrirCheckList.TabIndex = 2;
            this.llblAbrirCheckList.TabStop = true;
            this.llblAbrirCheckList.Text = "Abrir CheckList";
            this.llblAbrirCheckList.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblAbrirCheckList_LinkClicked);
            // 
            // frmSelecionarModulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 112);
            this.Controls.Add(this.llblAbrirCheckList);
            this.Controls.Add(this.llblEditorModelos);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmSelecionarModulo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selecionar Móodulo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel llblEditorModelos;
        private System.Windows.Forms.LinkLabel llblAbrirCheckList;

    }
}