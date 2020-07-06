using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Check_List.User_Controls
{

    public partial class ucPanItemListaArquivosMod : ucPanItemListaArquivos
    {
        private csItemListaArquivosMod _ItemListaArquivosMod = null;

        public ucPanItemListaArquivosMod()
        {
            InitializeComponent();
        }

        public override object RetornaCheckItem()
        {
            return _ItemListaArquivosMod;
        }

        public override void SetaCheckItem(object p_ItemListaArquivosMod)
        {
            _ItemListaArquivosMod = (csItemListaArquivosMod)p_ItemListaArquivosMod;
            this.Atualizar();
        }

        public override void Atualizar()
        {

            base.Atualizar();
        }

        private void lklUsarModelo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_ItemListaArquivosMod.ArquivoModelo != null)
            {
                MessageBox.Show("Não existe modelo definido?", "Usar Modelo");
            }
            else
            {
                MessageBox.Show("Usar Modelo?", "Usar Modelo");
            }
        }
        
    }
}
