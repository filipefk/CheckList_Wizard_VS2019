using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;

namespace Check_List
{
    public partial class frmTextoGrande : Form
    {
        private DialogResult _Retorno = DialogResult.Cancel;

        public frmTextoGrande()
        {
            InitializeComponent();
        }

        public DialogResult EditaTexto(ref string p_Texto, string p_Titulo)
        {
            this.Text = p_Titulo;
            txtTexto.Text = p_Texto;
            txtTexto.SelectionStart = 0;
            txtTexto.SelectionLength = 0;
            txtTexto.Location = new Point(0, 0);
            txtTexto.Size = new Size(this.ClientRectangle.Size.Width, txtTexto.Size.Height);
            lvwCampos.Visible = false;
            this.ShowDialog();
            p_Texto = txtTexto.Text;
            return _Retorno;
        }

        public DialogResult EditaTexto(ref string p_Texto, string p_Titulo, ArrayList p_Campos)
        {
            ListViewItem lvwItem = null;
            this.Text = p_Titulo;
            txtTexto.Text = p_Texto;
            txtTexto.SelectionStart = 0;
            txtTexto.SelectionLength = 0;
            txtTexto.Location = new Point(167, 0);
            lvwCampos.Visible = true;
            lvwCampos.Items.Clear();
            foreach (csRelatorio CampoRelatorio in p_Campos)
            {
                lvwItem = lvwCampos.Items.Add(CampoRelatorio.Nome);
                lvwItem.Tag = CampoRelatorio.Texto;
            }
            this.ShowDialog();
            p_Texto = txtTexto.Text;
            return _Retorno;
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            _Retorno = DialogResult.OK;
            this.Close();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            _Retorno = DialogResult.Cancel;
            this.Close();
        }

        private void lvwCampos_DoubleClick(object sender, EventArgs e)
        {
            if (lvwCampos.SelectedIndices.Count > 0)
            {
                txtTexto.SelectedText = lvwCampos.SelectedItems[0].Tag.ToString();
                txtTexto.Focus();
            }
        }

        private void txtTexto_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A: // Ctrl + A = Selecionar tudo
                    if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
                    {
                        txtTexto.SelectAll();
                    }
                    break;
            }
        }

    }
}
