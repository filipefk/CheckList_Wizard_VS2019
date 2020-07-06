namespace Check_List
{
    partial class ucPanListaItens
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
            this.panListaItens = new System.Windows.Forms.Panel();
            this.lblAjudaCheckList = new System.Windows.Forms.Label();
            this.lblDescricaoCheckList = new System.Windows.Forms.Label();
            this.lblNomeCheckList = new System.Windows.Forms.Label();
            this.panListaItens.SuspendLayout();
            this.SuspendLayout();
            // 
            // panListaItens
            // 
            this.panListaItens.Controls.Add(this.lblAjudaCheckList);
            this.panListaItens.Controls.Add(this.lblDescricaoCheckList);
            this.panListaItens.Controls.Add(this.lblNomeCheckList);
            this.panListaItens.Location = new System.Drawing.Point(0, 0);
            this.panListaItens.Name = "panListaItens";
            this.panListaItens.Size = new System.Drawing.Size(601, 432);
            this.panListaItens.TabIndex = 2;
            // 
            // lblAjudaCheckList
            // 
            this.lblAjudaCheckList.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAjudaCheckList.Location = new System.Drawing.Point(3, 154);
            this.lblAjudaCheckList.Name = "lblAjudaCheckList";
            this.lblAjudaCheckList.Size = new System.Drawing.Size(598, 261);
            this.lblAjudaCheckList.TabIndex = 2;
            this.lblAjudaCheckList.Text = "Ajuda do Check List";
            this.lblAjudaCheckList.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblDescricaoCheckList
            // 
            this.lblDescricaoCheckList.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescricaoCheckList.Location = new System.Drawing.Point(3, 67);
            this.lblDescricaoCheckList.Name = "lblDescricaoCheckList";
            this.lblDescricaoCheckList.Size = new System.Drawing.Size(598, 73);
            this.lblDescricaoCheckList.TabIndex = 1;
            this.lblDescricaoCheckList.Text = "Descrição do Check List";
            this.lblDescricaoCheckList.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblNomeCheckList
            // 
            this.lblNomeCheckList.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomeCheckList.Location = new System.Drawing.Point(3, 9);
            this.lblNomeCheckList.Name = "lblNomeCheckList";
            this.lblNomeCheckList.Size = new System.Drawing.Size(598, 37);
            this.lblNomeCheckList.TabIndex = 0;
            this.lblNomeCheckList.Text = "Nome do Check List";
            this.lblNomeCheckList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ucPanListaItens
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.panListaItens);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucPanListaItens";
            this.Size = new System.Drawing.Size(601, 432);
            this.Resize += new System.EventHandler(this.ucPanItem_Resize);
            this.panListaItens.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panListaItens;
        private System.Windows.Forms.Label lblAjudaCheckList;
        private System.Windows.Forms.Label lblDescricaoCheckList;
        private System.Windows.Forms.Label lblNomeCheckList;

    }
}
