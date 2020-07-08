using System;
using System.Collections;
using System.Windows.Forms;
using System.IO;

namespace Check_List
{
    /// <summary>
    /// Classe que implementa uma lista de csItemArquivo
    /// </summary>
    /// <remarks>
    /// Autor: Filipe Kanitz
    /// Data: 07/09/2011
    /// </remarks>
    [Serializable]
    class csItemListaArquivos : csItem
    {
    #region Campos Privados
        private ArrayList _ItensArquivo = new ArrayList();
        private csFiltrosArquivos _FiltrosArquivos = new csFiltrosArquivos();
    #endregion

    #region Propriedades

        /// <summary>
        /// Retorna o nome do tipo de item.
        /// </summary>
        public override string NomeTipo
        {
            get
            {
                return "Lista de Arquivos";
            }
        }

        /// <summary>
        /// Retorna um texto de relatório com todas as opções do item
        /// No caso do csItemListaArquivos é o mesmo do TextoRelatorioCurto
        /// </summary>
        public override string TextoTodasOpcoes
        {
            get
            {
                string _TextoRelatorio = "";
                _TextoRelatorio = "<font color=gray>" + this.Ajuda + "</font><br>\n" + this.TextoRelatorioCurto;
                return _TextoRelatorio;
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

                if (_ItensArquivo.Count > 0)
                {
                    foreach (csItemArquivo ItemArquivo in _ItensArquivo)
                    {
                        if (_TextoRelatorio.Trim().Length == 0)
                        {
                            _TextoRelatorio = _TextoRelatorio + "<font color=blue>";
                        }
                        else
                        {
                            _TextoRelatorio = _TextoRelatorio + "<br/>\n";
                        }
                        _TextoRelatorio = _TextoRelatorio + csUtil.ParteNomeArquivo(ItemArquivo.CaminhoCompletoOrigem, csUtil.enuParteNomeArquivo.NomeExtencao);
                    }
                    _TextoRelatorio = _TextoRelatorio + "</font>";
                }
                else
                {
                    if (this.Observacao.Trim().Length > 0)
                    {
                        _TextoRelatorio = _TextoRelatorio + "<font color=blue><b>Obs.:</b> " + this.Observacao.Replace("\n", "<br/>\n") + "</font>";
                    }
                }

                return _TextoRelatorio;
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
                foreach (csFiltroArquivo item in _FiltrosArquivos.ListaFiltros)
                {
                    if (_TextoDetalhe.Length > 0)
                    {
                        _TextoDetalhe = _TextoDetalhe + ",";
                    }
                    _TextoDetalhe = _TextoDetalhe + item.Tipos;
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
                if (this.ObservacaoObrigatoria)
                {
                    return ((this.Count > 0) && (this.Observacao.Length > 0));
                }
                else
                {
                    return (this.Count > 0) || (this.Observacao.Length > 0);
                }
            }
        }

        /// <summary>
        /// Para informar quais os filtros de arquivo devem ser aplicados em todos os itens da lista. O padrão é "Todos os arquivos (*.*)".
        /// </summary>
        public virtual csFiltrosArquivos FiltrosArquivos
        {
            get
            {
                return _FiltrosArquivos;
            }
            set
            {
                _FiltrosArquivos = value;
            }
        }

        /// <summary>
        /// Retorna o ArrayList com a lista de csItemArquivo.
        /// </summary>
        public virtual ArrayList ItensArquivo
        {
            get
            {
                return _ItensArquivo;
            }
        }

        /// <summary>
        /// Retorna o csItemArquivo de posição Indice.
        /// </summary>
        public virtual csItemArquivo Item(int Indice)
        {
            return (csItemArquivo)_ItensArquivo[Indice];
        }

        public virtual int Count
        {
            get
            {
                return _ItensArquivo.Count;
            }
        }
    #endregion

    #region Sobrecarga de Métodos

        /// <summary>
        /// Remove todas as propriedades Preenchidas.
        /// </summary>
        public override void Limpar()
        {
            _ItensArquivo = new ArrayList();
            _FiltrosArquivos = new csFiltrosArquivos();
            base.Limpar();
        }
    #endregion

    #region Métodos Públicos

        /// <summary>
        /// Mostra a dialog para escolher multiplos arquivos e chama a função CarregarArquivo.
        /// Retorna se carregou ou não algum arquivo
        /// </summary>
        public virtual bool EscolherArquivoECarregar()
        {
            OpenFileDialog dlgAbrir = new OpenFileDialog();
            DialogResult Resp;
            string[] _Arquivos = null;

            if (this.Descricao.Length > 0)
            {
                dlgAbrir.Title = this.Descricao;
            }
            else
            {
                dlgAbrir.Title = "Escolha o(s) arquivo(s)";
            }
            dlgAbrir.Filter = _FiltrosArquivos.Filtros;
            dlgAbrir.Multiselect = true;
            Resp = dlgAbrir.ShowDialog();
            if (Resp == System.Windows.Forms.DialogResult.OK)
            {
                _Arquivos = dlgAbrir.FileNames;
                for (int i = 0; i < _Arquivos.Length; i++)
                {
                    this.CarregarArquivo(_Arquivos[i]);
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Carrega o arquivo pra memoria.
        /// </summary>
        public virtual void CarregarArquivo(string p_CaminhoCompleto)
        {

            csItemArquivo ItemArquivo = new csItemArquivo();
            ItemArquivo.Nome = this.Nome;
            ItemArquivo.Descricao = this.Descricao;
            if (this.FiltrosArquivos.Count > 0)
            {
                ItemArquivo.FiltrosArquivos = this.FiltrosArquivos;
            }
            ItemArquivo.CarregarArquivo(p_CaminhoCompleto);
            if (ItemArquivo.TamanhoArquivo > 0)
            {
                this.Add(ItemArquivo);
            }
            else
            {
                MessageBox.Show("Não é possível carregar um arquivo vazio!\n" + p_CaminhoCompleto, "Carregar Arquivo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

        }

        /// <summary>
        /// Salva todos os arquivos da lista em uma pasta especificada.
        /// </summary>
        /// <returns>Retorna a quantidade de arquivos salvos.</returns>
        public virtual int SalvarTodosArquivos(string p_Caminho)
        {

            int QuantArquivosSalvos = 0;

            if (_ItensArquivo.Count == 0)
            {
                MessageBox.Show("Não existem arquivos na lista para salvar!", "Salvar Todos Arquivo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return QuantArquivosSalvos;
            }

            if (File.Exists(p_Caminho))
            {
                MessageBox.Show("Informe um caminho e não um arquivo!", "Salvar Todos Arquivo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return QuantArquivosSalvos;
            }

            if (!Directory.Exists(p_Caminho))
            {
                MessageBox.Show("O caminho informado não existe!", "Salvar Todos Arquivo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return QuantArquivosSalvos;
            }

            if (p_Caminho[p_Caminho.Length - 1].ToString() != "\\")
            {
                p_Caminho = p_Caminho + "\\";
            }

            // Varrendo a lista 
            foreach (csItemArquivo ItemArquivo in _ItensArquivo)
            {
                if (ItemArquivo.TamanhoArquivo > 0)
                {
                    ItemArquivo.SalvarArquivo(p_Caminho + ItemArquivo.NomeArquivo);
                    QuantArquivosSalvos++;
                }

            }

            return QuantArquivosSalvos;
        }

        /// <summary>
        /// Mostra a dialog para escolher o caminho e chama a função SalvarTodosArquivos.
        /// </summary>
        /// <returns>Retorna a quantidade de arquivos salvos e o caminho que foi escolhido.</returns>
        public virtual int EscolherCaminhoESalvarArquivos(ref string PastaEscolhida)
        {
            FolderBrowserDialog dlgCaminho = new FolderBrowserDialog();
            DialogResult Resp;
            PastaEscolhida = "";
            if (_ItensArquivo.Count == 0)
            {
                MessageBox.Show("Não existem arquivos na lista para salvar!", "Salvar Todos Arquivo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            string _PastaPadraoSalvar = (string)csUtil.CarregarPreferencia("Pasta padrao salvar arquivos");
            //string _PastaPadraoSalvar = ;
            if (_PastaPadraoSalvar != null)
            {
                if (Directory.Exists(_PastaPadraoSalvar))
                {
                    dlgCaminho.SelectedPath = _PastaPadraoSalvar;
                }
                else
                {
                    dlgCaminho.SelectedPath = Directory.GetCurrentDirectory();
                }
            }
            else
            {
                dlgCaminho.SelectedPath = Directory.GetCurrentDirectory();
            }
            Resp = dlgCaminho.ShowDialog();
            if (Resp == System.Windows.Forms.DialogResult.OK)
            {
                PastaEscolhida = dlgCaminho.SelectedPath;
                csUtil.SalvarPreferencia("Pasta padrao salvar arquivos", PastaEscolhida);
                return this.SalvarTodosArquivos(dlgCaminho.SelectedPath);
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Remove Só o conteúdo preenchido pelos usuários, mantem o modelo.
        /// </summary>
        public override void LimparConteudo()
        {
            _ItensArquivo = new ArrayList();
            this.Observacao = "";
            GC.Collect();
        }

        /// <summary>
        /// Insere um novo item do tipo csItemArquivo.
        /// </summary>
        public virtual csItemArquivo Add(csItemArquivo Item)
        {
            _ItensArquivo.Add(Item);
            return Item;
        }

        /// <summary>
        /// Remove o csItemArquivo de posição Indice.
        /// </summary>
        public virtual void Remove(int Indice)
        {
            _ItensArquivo.Remove(_ItensArquivo[Indice]);
            GC.Collect();
        }

        /// <summary>
        /// Remove os csItemArquivo de posições Indice[].
        /// </summary>
        public virtual void Remove(int[] pIndice)
        {
            csItemArquivo[] _ListaItensArquivo = new csItemArquivo[pIndice.Length];
            for (int i = 0; i < pIndice.Length; i++)
            {
                _ListaItensArquivo[i] = (csItemArquivo)_ItensArquivo[pIndice[i]];
            }
            for (int i = 0; i < _ListaItensArquivo.Length; i++)
            {
                _ItensArquivo.Remove(_ListaItensArquivo[i]);
            }
            GC.Collect();
        }

        /// <summary>
        /// Limpa toda a lista.
        /// </summary>
        public virtual void Clear()
        {
            while (_ItensArquivo.Count > 0)
                _ItensArquivo.Remove(_ItensArquivo[0]);
            GC.Collect();
        }
    #endregion

    }
}
