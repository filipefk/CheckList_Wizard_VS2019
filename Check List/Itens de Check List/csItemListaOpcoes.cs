using System;
using System.Collections;

namespace Check_List
{
    /// <summary>
    /// Classe que implementa um item de Check List que é uma lista de opções para escolher
    /// </summary>
    /// <remarks>
    /// Autor: Filipe Kanitz
    /// Data: 07/09/2011
    /// </remarks>
    [Serializable]
    class csItemListaOpcoes : csItem
    {
    #region Campos Privados
        private bool _MultiplaEscolha = false;
        private ArrayList _Opcoes = new ArrayList();
    #endregion

    #region Propriedades
        /// <summary>
        /// Retorna o nome do tipo de item.
        /// </summary>
        public override string NomeTipo
        {
            get
            {
                return "Lista de Opções";
            }
        }

        /// <summary>
        /// Retorna um texto de relatório sem Nome e descrição do item preenchido.
        /// </summary>
        public override string TextoRelatorioCurto
        {
            get
            {
                string _TextoRelatorio = "";
                bool _TemOpcaoMarcada = false;

                foreach (csOpcao Opcao in _Opcoes)
                {
                    if (Opcao.Marcada)
                    {
                        _TemOpcaoMarcada = true;
                        break;
                    }
                }

                if (_TemOpcaoMarcada)
                {
                    foreach (csOpcao Opcao in _Opcoes)
                    {
                        if (Opcao.Marcada)
                        {
                            if (_TextoRelatorio.Trim().Length == 0)
                            {
                                _TextoRelatorio = _TextoRelatorio + "<font color=blue>";
                            }
                            else
                            {
                                _TextoRelatorio = _TextoRelatorio + "<br/>\n";
                            }
                            _TextoRelatorio = _TextoRelatorio + Opcao.Texto;
                        }
                    }
                    _TextoRelatorio = _TextoRelatorio + "</font>";
                }
                else
                {
                    if (this.Observacao.Trim().Length > 0)
                    {
                        _TextoRelatorio = _TextoRelatorio + "<font color=blue><b>Obs.:</b> " + this.Observacao.Replace("\n", "<br/>\n") +"</font>";
                    }
                }
                
                return _TextoRelatorio;
            }
        }

        /// <summary>
        /// Retorna a lista de opções marcadas.
        /// </summary>
        public ArrayList ListaOpcoesMarcadas
        {
            get
            {
                ArrayList _ListaOpcoesMarcadas = new ArrayList();
                foreach (csOpcao Opcao in _Opcoes)
                {
                    if (Opcao.Marcada)
                    {
                        _ListaOpcoesMarcadas.Add(Opcao.Texto);
                    }
                }

                return _ListaOpcoesMarcadas;
            }
        }

        /// <summary>
        /// Retorna um texto de detalhe da configuração do item.
        /// </summary>
        public override string TextoDetalhe
        {
            get
            {
                string _TextoDetalhe = "";
                if (this.MultiplaEscolha)
                {
                    _TextoDetalhe = "Multipla Escolha";
                }
                else
                {
                    _TextoDetalhe = "Única Escolha";
                }
                foreach (csOpcao item in _Opcoes)
                {
                    _TextoDetalhe = _TextoDetalhe + " | " + item.Texto;
                }
                return _TextoDetalhe;
            }
        }

        /// <summary>
        /// Indica se o item foi preenchido ou não.
        /// </summary>
        public override bool Preenchido
        {
            get
            {
                bool TemOpcaoMarcada = false;
                foreach (csOpcao Opcao in _Opcoes)
                {
                    if (Opcao.Marcada || Opcao.Padrao)
                    {
                        TemOpcaoMarcada = true;
                    }
                }

                if (this.ObservacaoObrigatoria)
                {
                    return ((TemOpcaoMarcada) && (this.Observacao.Length > 0));
                }
                else
                {
                    return (TemOpcaoMarcada) || (this.Observacao.Length > 0);
                }

            }
        }

        /// <summary>
        /// Se pode ter mais de um item selecionado ou não.
        /// </summary>
        public bool MultiplaEscolha
        {
            get
            {
                return _MultiplaEscolha;
            }
            set
            {
                _MultiplaEscolha = value;
            }
        }

        /// <summary>
        /// Retorna o ArrayList com a lista de opções.
        /// </summary>
        public ArrayList Opcoes
        {
            get
            {
                return _Opcoes;
            }
        }

        public int Count
        {
            get
            {
                return _Opcoes.Count;
            }
        }
    #endregion

    #region Sobrecarga de Métodos

        /// <summary>
        /// Remove todas as propriedades Preenchidas.
        /// </summary>
        public override void Limpar()
        {
            _MultiplaEscolha = false;
            _Opcoes = new ArrayList();
            base.Limpar();
        }
    #endregion

    #region Métodos Públicos

        /// <summary>
        /// Remove Só o conteúdo preenchido pelos usuários, mantem o modelo.
        /// </summary>
        public override void LimparConteudo()
        {
            foreach (csOpcao Opcao in _Opcoes)
            {
                Opcao.Marcada = false;
            }
            this.Observacao = "";
        }

        /// <summary>
        /// Retorna o csOpcao de posição Indice.
        /// </summary>
        public csOpcao Item(int Indice)
        {
            return (csOpcao)_Opcoes[Indice];
        }

        /// <summary>
        /// Insere um novo item do tipo csOpcao.
        /// </summary>
        public csOpcao Add(csOpcao Item)
        {
            _Opcoes.Add(Item);
            return Item;
        }

        /// <summary>
        /// Cria um novo csOpcao com os parâmetros e insere na lista.
        /// </summary>
        public csOpcao Add(string p_Texto, bool p_Marcada, bool p_Padrao)
        {
            csOpcao Item = new csOpcao();
            Item.Texto = p_Texto;
            Item.Marcada = p_Marcada;
            Item.Padrao = p_Padrao;
            _Opcoes.Add(Item);
            return Item;
        }

        /// <summary>
        /// Remove o csOpcao de posição Indice.
        /// </summary>
        public void Remove(int Indice)
        {
            _Opcoes.Remove(_Opcoes[Indice]);
            GC.Collect();
        }

        /// <summary>
        /// Limpa toda a lista.
        /// </summary>
        public void Clear()
        {
            while (_Opcoes.Count > 0)
                _Opcoes.Remove(_Opcoes[0]);
            GC.Collect();
        }
    #endregion

    }
}
