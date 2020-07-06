using System;
using System.Windows.Forms;

namespace Check_List
{
    /// <summary>
    /// Controle que mostra visualmente o conteúdo de uma csListaItens
    /// </summary>
    /// <remarks>
    /// Autor: Filipe Kanitz
    /// Data: 10/09/2011
    /// </remarks>
    partial class ucLvwCheckItens : ListView
    {
        
    #region Campos Privados
        private csListaItens _ListaItens = null;
        private enuTipoLista _TipoLista = enuTipoLista.tlResumida;
    #endregion

    #region Enumerações
        /// <summary>
        /// Para o tipo da lista. Resumida: Nome, Detalhada: Nome, Tipo, Descriçao e Detalhe
        /// </summary>
        public enum enuTipoLista
        {
            tlResumida,
            tlDetalhada
        }
    #endregion

    #region Construtores
        /// <summary>
        /// Construtor Padrão.
        /// </summary>
        public ucLvwCheckItens()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.GridLines = true;
            this.HideSelection = false;
            this.FullRowSelect = true;
            this.MultiSelect = false;
            this.CheckBoxes = false;
            this.View = System.Windows.Forms.View.Details;
            this.Atualizar();
        }
    #endregion

    #region Sobrecarga de eventos
        /// <summary>
        /// Sobrecarga do OnPaint
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            this.Atualizar();
            
        }
    #endregion
        
    #region Propriedades


        /// <summary>
        /// Classe csListaItens mostrada por este controle
        /// </summary>
        public object ListaItens
        {
            get
            {
                return _ListaItens;
            }
            set
            {
                _ListaItens = (csListaItens)value;
                this.Atualizar();
            }
        }

        /// <summary>
        /// Tipo da lista. Resumida: Nome, Detalhada: Nome, Tipo, Descriçao e Detalhe
        /// </summary>
        public enuTipoLista TipoLista
        {
            get
            {
                return _TipoLista;
            }
            set
            {
                _TipoLista = value;
                this.Atualizar();
            }
        }

    #endregion

    #region Métodos Privados
        /// <summary>
        /// Insere os cabeçalhos na ImageList
        /// </summary>
        private void InsereCabecalhos()
        {
            if ((base.Columns.Count == 0) || (this.TipoLista == enuTipoLista.tlDetalhada && base.Columns.Count == 1))
            {
                ColumnHeader Coluna;
                bool InseriuColunas = false;
                //base.Columns.Clear();

                if (base.Columns.Count == 0)
                {
                    Coluna = base.Columns.Add("Nome");
                    InseriuColunas = true;
                }

                if (this.TipoLista == enuTipoLista.tlDetalhada)
                {
                    Coluna = base.Columns.Add("Tipo");
                    Coluna = base.Columns.Add("Descrição");
                    Coluna = base.Columns.Add("Detalhe");
                    InseriuColunas = true;
                }
                if (InseriuColunas)
                {
                    foreach (ColumnHeader itemColuna in base.Columns)
                    {
                        itemColuna.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                    }
                }
            }
            
        }

    #endregion

    #region Métodos Públicos
        /// <summary>
        /// Atualiza os itens da csListaItens mostrada por este controle
        /// </summary>
        public void Atualizar()
        {
            ListViewItem lvwItem;
            bool AlterouItens = false;

            //base.Items.Clear();
            this.InsereCabecalhos();
            if (_ListaItens != null)
            {
                // Varrendo a lista de Check Itens
                // Usando for ao invés de foreach pra garantir que a posição do item na 
                // lista seja a mesma da posição do ArrayList
                for (int i = 0; i < _ListaItens.Itens.Count; i++)
                {
                    csItem itemCheckList = (csItem)_ListaItens.Itens[i];

                    if (base.Items.Count <= i)
                    {
                        lvwItem = base.Items.Add(itemCheckList.Nome);
                        if (this.TipoLista == enuTipoLista.tlDetalhada)
                        {
                            lvwItem.SubItems.Add(itemCheckList.NomeTipo);
                            lvwItem.SubItems.Add(itemCheckList.Descricao);
                            lvwItem.SubItems.Add(itemCheckList.TextoDetalhe);
                        }
                        AlterouItens = true;
                    }
                    else
                    {
                        lvwItem = base.Items[i];
                        if (lvwItem.Text != itemCheckList.Nome)
                        {
                            lvwItem.Text = itemCheckList.Nome;
                            AlterouItens = true;
                        }
                        if (this.TipoLista == enuTipoLista.tlDetalhada)
                        {
                            if (lvwItem.SubItems[1].Text != itemCheckList.NomeTipo)
                            {
                                lvwItem.SubItems[1].Text = itemCheckList.NomeTipo;
                                AlterouItens = true;
                            }
                            if (lvwItem.SubItems[2].Text != itemCheckList.Descricao)
                            {
                                lvwItem.SubItems[2].Text = itemCheckList.Descricao;
                                AlterouItens = true;
                            }
                            if (lvwItem.SubItems[3].Text != itemCheckList.TextoDetalhe)
                            {
                                lvwItem.SubItems[3].Text = itemCheckList.TextoDetalhe;
                                AlterouItens = true;
                            }
                        }
                    }
                    if ((itemCheckList.Preenchido) && (base.SmallImageList != null))
                    {
                        if (lvwItem.ImageKey != "Checado")
                        {
                            lvwItem.ImageKey = "Checado";
                        }
                    }
                    else
                    {
                        if (lvwItem.ImageKey != "")
                        {
                            lvwItem.ImageKey = null;
                        }
                    }

                }

                while (_ListaItens.Itens.Count < base.Items.Count)
                {
                    base.Items.Remove(base.Items[base.Items.Count - 1]);
                }

            }
            if (AlterouItens)
            {
                if (base.Items.Count > 0)
                {
                    foreach (ColumnHeader itemColuna in base.Columns)
                    {
                        itemColuna.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                    }
                }
                else
                {
                    foreach (ColumnHeader itemColuna in base.Columns)
                    {
                        itemColuna.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                    }
                }
            }
            
        }
    #endregion
    }
}
