namespace Check_List
{
    partial class ucPanItemListaOpcoes
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
            this.panItemOpcoes = new System.Windows.Forms.Panel();
            this.lblItemOpcoes = new System.Windows.Forms.Label();
            this.cboItemOpcoes = new System.Windows.Forms.ComboBox();
            this.lvwItemOpcoes = new System.Windows.Forms.ListView();
            this.colOpcoes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panItemOpcoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // panItemOpcoes
            // 
            this.panItemOpcoes.Controls.Add(this.lblItemOpcoes);
            this.panItemOpcoes.Controls.Add(this.cboItemOpcoes);
            this.panItemOpcoes.Controls.Add(this.lvwItemOpcoes);
            this.panItemOpcoes.Location = new System.Drawing.Point(0, 0);
            this.panItemOpcoes.Name = "panItemOpcoes";
            this.panItemOpcoes.Size = new System.Drawing.Size(601, 196);
            this.panItemOpcoes.TabIndex = 10;
            // 
            // lblItemOpcoes
            // 
            this.lblItemOpcoes.AutoSize = true;
            this.lblItemOpcoes.Location = new System.Drawing.Point(10, 61);
            this.lblItemOpcoes.Name = "lblItemOpcoes";
            this.lblItemOpcoes.Size = new System.Drawing.Size(57, 16);
            this.lblItemOpcoes.TabIndex = 17;
            this.lblItemOpcoes.Text = "Opções:";
            // 
            // cboItemOpcoes
            // 
            this.cboItemOpcoes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboItemOpcoes.FormattingEnabled = true;
            this.cboItemOpcoes.Location = new System.Drawing.Point(73, 58);
            this.cboItemOpcoes.Name = "cboItemOpcoes";
            this.cboItemOpcoes.Size = new System.Drawing.Size(515, 24);
            this.cboItemOpcoes.TabIndex = 16;
            this.cboItemOpcoes.SelectedIndexChanged += new System.EventHandler(this.cboItemOpcoes_SelectedIndexChanged);
            this.cboItemOpcoes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboItemOpcoes_KeyDown);
            // 
            // lvwItemOpcoes
            // 
            this.lvwItemOpcoes.CheckBoxes = true;
            this.lvwItemOpcoes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colOpcoes});
            this.lvwItemOpcoes.FullRowSelect = true;
            this.lvwItemOpcoes.Location = new System.Drawing.Point(6, 3);
            this.lvwItemOpcoes.Name = "lvwItemOpcoes";
            this.lvwItemOpcoes.Size = new System.Drawing.Size(592, 190);
            this.lvwItemOpcoes.TabIndex = 15;
            this.lvwItemOpcoes.UseCompatibleStateImageBehavior = false;
            this.lvwItemOpcoes.View = System.Windows.Forms.View.Details;
            this.lvwItemOpcoes.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvwItemOpcoes_ItemChecked);
            // 
            // colOpcoes
            // 
            this.colOpcoes.Text = "Opções";
            this.colOpcoes.Width = 580;
            // 
            // ucPanItemListaOpcoes
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.panItemOpcoes);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ucPanItemListaOpcoes";
            this.Size = new System.Drawing.Size(601, 196);
            this.Resize += new System.EventHandler(this.ucPanItemListaOpcoes_Resize);
            this.panItemOpcoes.ResumeLayout(false);
            this.panItemOpcoes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panItemOpcoes;
        private System.Windows.Forms.Label lblItemOpcoes;
        private System.Windows.Forms.ComboBox cboItemOpcoes;
        private System.Windows.Forms.ListView lvwItemOpcoes;
        private System.Windows.Forms.ColumnHeader colOpcoes;


    }
}
