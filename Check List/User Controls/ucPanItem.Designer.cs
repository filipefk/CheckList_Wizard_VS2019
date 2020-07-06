namespace Check_List
{
    partial class ucPanItem
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
            this.panItem = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtObservacaoItem = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDescricaoItem = new System.Windows.Forms.Label();
            this.lblNomeItem = new System.Windows.Forms.Label();
            this.txtAjudaItem = new System.Windows.Forms.RichTextBox();
            this.panItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // panItem
            // 
            this.panItem.Controls.Add(this.label1);
            this.panItem.Controls.Add(this.txtObservacaoItem);
            this.panItem.Controls.Add(this.panel1);
            this.panItem.Controls.Add(this.lblDescricaoItem);
            this.panItem.Controls.Add(this.lblNomeItem);
            this.panItem.Controls.Add(this.txtAjudaItem);
            this.panItem.Location = new System.Drawing.Point(0, 0);
            this.panItem.Name = "panItem";
            this.panItem.Size = new System.Drawing.Size(601, 432);
            this.panItem.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 374);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Observação:";
            // 
            // txtObservacaoItem
            // 
            this.txtObservacaoItem.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservacaoItem.Location = new System.Drawing.Point(3, 393);
            this.txtObservacaoItem.Multiline = true;
            this.txtObservacaoItem.Name = "txtObservacaoItem";
            this.txtObservacaoItem.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservacaoItem.Size = new System.Drawing.Size(594, 39);
            this.txtObservacaoItem.TabIndex = 5;
            this.txtObservacaoItem.Text = "O\r\nO";
            this.txtObservacaoItem.TextChanged += new System.EventHandler(this.txtObservacaoItem_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 173);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(601, 196);
            this.panel1.TabIndex = 4;
            // 
            // lblDescricaoItem
            // 
            this.lblDescricaoItem.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescricaoItem.Location = new System.Drawing.Point(-1, 41);
            this.lblDescricaoItem.Name = "lblDescricaoItem";
            this.lblDescricaoItem.Size = new System.Drawing.Size(598, 21);
            this.lblDescricaoItem.TabIndex = 2;
            this.lblDescricaoItem.Text = "Descrição do Item";
            this.lblDescricaoItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNomeItem
            // 
            this.lblNomeItem.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomeItem.ForeColor = System.Drawing.Color.Black;
            this.lblNomeItem.Location = new System.Drawing.Point(0, 0);
            this.lblNomeItem.Name = "lblNomeItem";
            this.lblNomeItem.Size = new System.Drawing.Size(598, 32);
            this.lblNomeItem.TabIndex = 1;
            this.lblNomeItem.Text = "Nome do Item";
            this.lblNomeItem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtAjudaItem
            // 
            this.txtAjudaItem.BackColor = System.Drawing.SystemColors.Control;
            this.txtAjudaItem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAjudaItem.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAjudaItem.Location = new System.Drawing.Point(3, 65);
            this.txtAjudaItem.Name = "txtAjudaItem";
            this.txtAjudaItem.Size = new System.Drawing.Size(595, 108);
            this.txtAjudaItem.TabIndex = 8;
            this.txtAjudaItem.Text = "O\nO\nO\nO\nO\nO\nO";
            this.txtAjudaItem.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.txtAjudaItem_LinkClicked);
            // 
            // ucPanItem
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.panItem);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucPanItem";
            this.Size = new System.Drawing.Size(601, 432);
            this.Resize += new System.EventHandler(this.ucPanItem_Resize);
            this.panItem.ResumeLayout(false);
            this.panItem.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panItem;
        private System.Windows.Forms.Label lblNomeItem;
        private System.Windows.Forms.Label lblDescricaoItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtObservacaoItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txtAjudaItem;
    }
}
