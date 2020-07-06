namespace Check_List
{
    partial class frmEditorRelatorio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditorRelatorio));
            this.txtTexto = new System.Windows.Forms.TextBox();
            this.btOK = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.lvwCampos = new System.Windows.Forms.ListView();
            this.colNome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.wbPreview = new System.Windows.Forms.WebBrowser();
            this.chkPreviewOnLine = new System.Windows.Forms.CheckBox();
            this.btPreview = new System.Windows.Forms.Button();
            this.btPreviewTelaCheia = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtTexto
            // 
            this.txtTexto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTexto.Location = new System.Drawing.Point(159, 0);
            this.txtTexto.Multiline = true;
            this.txtTexto.Name = "txtTexto";
            this.txtTexto.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtTexto.Size = new System.Drawing.Size(486, 288);
            this.txtTexto.TabIndex = 0;
            this.txtTexto.TextChanged += new System.EventHandler(this.txtTexto_TextChanged);
            this.txtTexto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTexto_KeyDown);
            // 
            // btOK
            // 
            this.btOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btOK.Location = new System.Drawing.Point(559, 519);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(74, 31);
            this.btOK.TabIndex = 1;
            this.btOK.Text = "OK";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancelar.Location = new System.Drawing.Point(469, 519);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(74, 31);
            this.btCancelar.TabIndex = 2;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // lvwCampos
            // 
            this.lvwCampos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvwCampos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colNome});
            this.lvwCampos.FullRowSelect = true;
            this.lvwCampos.Location = new System.Drawing.Point(0, 0);
            this.lvwCampos.Name = "lvwCampos";
            this.lvwCampos.Size = new System.Drawing.Size(159, 288);
            this.lvwCampos.TabIndex = 3;
            this.lvwCampos.UseCompatibleStateImageBehavior = false;
            this.lvwCampos.View = System.Windows.Forms.View.Details;
            this.lvwCampos.DoubleClick += new System.EventHandler(this.lvwCampos_DoubleClick);
            // 
            // colNome
            // 
            this.colNome.Text = "Nome";
            this.colNome.Width = 150;
            // 
            // wbPreview
            // 
            this.wbPreview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wbPreview.Location = new System.Drawing.Point(0, 290);
            this.wbPreview.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbPreview.Name = "wbPreview";
            this.wbPreview.Size = new System.Drawing.Size(645, 223);
            this.wbPreview.TabIndex = 4;
            this.wbPreview.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wbPreview_DocumentCompleted);
            // 
            // chkPreviewOnLine
            // 
            this.chkPreviewOnLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkPreviewOnLine.AutoSize = true;
            this.chkPreviewOnLine.Checked = true;
            this.chkPreviewOnLine.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPreviewOnLine.Location = new System.Drawing.Point(12, 525);
            this.chkPreviewOnLine.Name = "chkPreviewOnLine";
            this.chkPreviewOnLine.Size = new System.Drawing.Size(120, 20);
            this.chkPreviewOnLine.TabIndex = 5;
            this.chkPreviewOnLine.Text = "Preview On Line";
            this.chkPreviewOnLine.UseVisualStyleBackColor = true;
            this.chkPreviewOnLine.CheckedChanged += new System.EventHandler(this.chkPreviewOnLine_CheckedChanged);
            // 
            // btPreview
            // 
            this.btPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btPreview.Location = new System.Drawing.Point(138, 519);
            this.btPreview.Name = "btPreview";
            this.btPreview.Size = new System.Drawing.Size(74, 31);
            this.btPreview.TabIndex = 6;
            this.btPreview.Text = "Preview";
            this.btPreview.UseVisualStyleBackColor = true;
            this.btPreview.Click += new System.EventHandler(this.btPreview_Click);
            // 
            // btPreviewTelaCheia
            // 
            this.btPreviewTelaCheia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btPreviewTelaCheia.Location = new System.Drawing.Point(218, 519);
            this.btPreviewTelaCheia.Name = "btPreviewTelaCheia";
            this.btPreviewTelaCheia.Size = new System.Drawing.Size(128, 31);
            this.btPreviewTelaCheia.TabIndex = 7;
            this.btPreviewTelaCheia.Text = "Preview Tela Cheia";
            this.btPreviewTelaCheia.UseVisualStyleBackColor = true;
            this.btPreviewTelaCheia.Click += new System.EventHandler(this.btPreviewTelaCheia_Click);
            // 
            // frmEditorRelatorio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 553);
            this.Controls.Add(this.btPreviewTelaCheia);
            this.Controls.Add(this.btPreview);
            this.Controls.Add(this.chkPreviewOnLine);
            this.Controls.Add(this.wbPreview);
            this.Controls.Add(this.lvwCampos);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.btOK);
            this.Controls.Add(this.txtTexto);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmEditorRelatorio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Texto";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTexto;
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.ListView lvwCampos;
        private System.Windows.Forms.ColumnHeader colNome;
        private System.Windows.Forms.WebBrowser wbPreview;
        private System.Windows.Forms.CheckBox chkPreviewOnLine;
        private System.Windows.Forms.Button btPreview;
        private System.Windows.Forms.Button btPreviewTelaCheia;

    }
}