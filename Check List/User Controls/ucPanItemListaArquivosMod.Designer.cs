namespace Check_List.User_Controls
{
    partial class ucPanItemListaArquivosMod
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
            this.lklUsarModelo = new System.Windows.Forms.LinkLabel();
            this.panItenListaArquivos.SuspendLayout();
            this.SuspendLayout();
            // 
            // panItenListaArquivos
            // 
            this.panItenListaArquivos.Controls.Add(this.lklUsarModelo);
            this.panItenListaArquivos.Controls.SetChildIndex(this.lklUsarModelo, 0);
            this.panItenListaArquivos.Controls.SetChildIndex(this.btAbrirArquivo, 0);
            this.panItenListaArquivos.Controls.SetChildIndex(this.btExcluir, 0);
            this.panItenListaArquivos.Controls.SetChildIndex(this.label2, 0);
            this.panItenListaArquivos.Controls.SetChildIndex(this.btSalvarTodosArquivos, 0);
            this.panItenListaArquivos.Controls.SetChildIndex(this.btSalvarArquivoSelecionado, 0);
            this.panItenListaArquivos.Controls.SetChildIndex(this.lvwItemListaArquivos, 0);
            // 
            // lklUsarModelo
            // 
            this.lklUsarModelo.AutoSize = true;
            this.lklUsarModelo.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lklUsarModelo.Location = new System.Drawing.Point(562, 90);
            this.lklUsarModelo.Name = "lklUsarModelo";
            this.lklUsarModelo.Size = new System.Drawing.Size(34, 29);
            this.lklUsarModelo.TabIndex = 16;
            this.lklUsarModelo.TabStop = true;
            this.lklUsarModelo.Text = "M";
            this.lklUsarModelo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lklUsarModelo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lklUsarModelo_LinkClicked);
            // 
            // ucPanItemListaArquivosMod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "ucPanItemListaArquivosMod";
            this.panItenListaArquivos.ResumeLayout(false);
            this.panItenListaArquivos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.LinkLabel lklUsarModelo;
    }
}
