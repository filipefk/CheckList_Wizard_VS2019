using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Check_List
{
    public partial class ucPanListaItens : UserControl
    {
        private csListaItens _ListaItens = null;

        public ucPanListaItens()
        {
            InitializeComponent();
        }

        public object RetornaListaItens()
        {
            return _ListaItens;
        }

        public void SetaListaItens(object p_ListaItens)
        {
            _ListaItens = (csListaItens)p_ListaItens;
            lblNomeCheckList.Text = _ListaItens.Nome;
            lblDescricaoCheckList.Text = _ListaItens.Descricao;
            lblAjudaCheckList.Text = _ListaItens.Ajuda;
        }

        private void ucPanItem_Resize(object sender, EventArgs e)
        {
            this.Size = new Size(601, 432);
        }
    }
}
