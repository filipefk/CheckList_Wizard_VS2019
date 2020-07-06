using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Check_List
{
    public delegate void AlterouAlgoItemListaOpcoesEventHandler(ucPanItemListaOpcoes sender, EventArgs e);

    public partial class ucPanItemListaOpcoes : UserControl
    {
        public event AlterouAlgoItemListaOpcoesEventHandler AlterouAlgo;

        protected virtual void OnAlterouAlgo(EventArgs e)
        {
            if (AlterouAlgo != null)
                AlterouAlgo(this, e);
        }

        private bool _PreenchendoLista = false;
        private csItemListaOpcoes _ItemListaOpcoes = null;

        public ucPanItemListaOpcoes()
        {
            InitializeComponent();
        }

        public object RetornaCheckItem()
        {
            return _ItemListaOpcoes;
        }

        public void SetaCheckItem(object p_ItemListaOpcoes)
        {
            _ItemListaOpcoes = (csItemListaOpcoes)p_ItemListaOpcoes;
            this.Atualizar();
        }

        public void Atualizar()
        {
            lvwItemOpcoes.Items.Clear();
            cboItemOpcoes.Items.Clear();
            lvwItemOpcoes.Items.Clear();
            cboItemOpcoes.Items.Clear();

            lvwItemOpcoes.Visible = false;
            lblItemOpcoes.Visible = false;
            cboItemOpcoes.Visible = false;

            if (_ItemListaOpcoes != null)
            {
                csOpcao Opcao = null;
                if (_ItemListaOpcoes.MultiplaEscolha)
                {
                    ListViewItem lvwItem = null;
                    lvwItemOpcoes.Visible = true;
                    _PreenchendoLista = true;
                    for (int i = 0; i < _ItemListaOpcoes.Opcoes.Count; i++)
                    {
                        Opcao = (csOpcao)_ItemListaOpcoes.Opcoes[i];
                        lvwItem = lvwItemOpcoes.Items.Add(Opcao.Texto);
                        lvwItem.Checked = Opcao.Marcada;
                    }
                    _PreenchendoLista = false;
                }
                else
                {
                    lblItemOpcoes.Visible = true;
                    cboItemOpcoes.Visible = true;
                    int OpcaoMarcada = -1;
                    int OpcaoPadrao = -1;

                    for (int i = 0; i < _ItemListaOpcoes.Opcoes.Count; i++)
                    {
                        Opcao = (csOpcao)_ItemListaOpcoes.Opcoes[i];
                        cboItemOpcoes.Items.Add(Opcao);
                        if (Opcao.Marcada)
                        {
                            OpcaoMarcada = i;
                        }
                        if (Opcao.Padrao)
                        {
                            OpcaoPadrao = i;
                        }
                    }

                    _PreenchendoLista = true;
                    if (OpcaoMarcada > -1)
                    {
                        cboItemOpcoes.SelectedIndex = OpcaoMarcada;
                    }
                    else
                    {
                        if (OpcaoPadrao > -1)
                        {
                            cboItemOpcoes.SelectedIndex = OpcaoPadrao;
                        }
                        else
                        {
                            cboItemOpcoes.SelectedIndex = -1;
                        }
                    }
                    _PreenchendoLista = false;
                }
            }
            
        }

        public void DesmarcaTodosItens()
        {
            foreach (csOpcao Opcao in _ItemListaOpcoes.Opcoes)
            {
                Opcao.Marcada = false;
            }
            this.OnAlterouAlgo(new EventArgs());
        }

        private void ucPanItemListaOpcoes_Resize(object sender, EventArgs e)
        {
            this.Size = new Size(601, 196);
        }

        private void SalvaOpcoes()
        {
            csOpcao Opcao = null;
            if (_ItemListaOpcoes.MultiplaEscolha)
            {
                ListViewItem lvwItem = null;
                for (int i = 0; i < _ItemListaOpcoes.Opcoes.Count; i++)
                {
                    Opcao = (csOpcao)_ItemListaOpcoes.Opcoes[i];
                    lvwItem = lvwItemOpcoes.Items[i];
                    if (Opcao.Marcada != lvwItem.Checked)
                    {
                        Opcao.Marcada = lvwItem.Checked;
                        this.OnAlterouAlgo(new EventArgs());
                    }
                }
            }
            else
            {
                for (int i = 0; i < _ItemListaOpcoes.Opcoes.Count; i++)
                {
                    Opcao = (csOpcao)_ItemListaOpcoes.Opcoes[i];
                    if (Opcao.Marcada != (cboItemOpcoes.SelectedIndex == i))
                    {
                        Opcao.Marcada = (cboItemOpcoes.SelectedIndex == i);
                        this.OnAlterouAlgo(new EventArgs());
                    }
                }
            }
            
        }

        private void cboItemOpcoes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_PreenchendoLista)
            {
                this.SalvaOpcoes();
            }
        }

        private void lvwItemOpcoes_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (!_PreenchendoLista && this.Enabled)
            {
                this.SalvaOpcoes();
            }
        }

        private void cboItemOpcoes_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    cboItemOpcoes.SelectedIndex = -1;
                    this.DesmarcaTodosItens();
                    break;
            }
        }
    }
}
