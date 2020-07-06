using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace Check_List
{
    /// <summary>
    /// Classe que herda csItemArquivo e inclui a funcionalidade de carregar modelos de arquivos
    /// Útil quando um formulário do word ou excel deve ser preenchido e tem um modelo padrão
    /// </summary>
    /// <remarks>
    /// Autor: Filipe Kanitz
    /// Data: 01/02/2013
    /// </remarks>
    [Serializable]
    class csItemListaArquivosMod : csItemListaArquivos
    {
    #region Campos Privados
        private csItemArquivo _ItemArquivoMod;
    #endregion

    #region Propriedades

        /// <summary>
        /// Retorna o csItemArquivo de modelo.
        /// </summary>
        public csItemArquivo ArquivoModelo
        {
            get
            {
                return _ItemArquivoMod;
            }
        }
        
    #endregion

    #region Sobrecarga de Métodos

        /// <summary>
        /// Remove todas as propriedades Preenchidas.
        /// </summary>
        public override void Limpar()
        {
            _ItemArquivoMod = null;
            base.Limpar();
        }

        /// <summary>
        /// Retorna o nome do tipo de item.
        /// </summary>
        public override string NomeTipo
        {
            get
            {
                return "Lista de Arquivos M";
            }
        }

    #endregion

    #region Expondo propriedades da Base

        /// <summary>
        /// Retorna um texto de relatório sem Nome e descrição do item preenchido.
        /// </summary>
        public override string TextoRelatorioCurto
        {
            get
            {
                return base.TextoRelatorioCurto;
            }
        }

        /// <summary>
        /// Retorna um texto de detalhe da configuração do item.
        /// </summary>
        public override string TextoDetalhe
        {
            get
            {
                return base.TextoDetalhe;
            }
        }

        /// <summary>
        /// Indica se o item foi preenchido ou não.
        /// </summary>
        public override bool Preenchido
        {
            get
            {
                return base.Preenchido;
            }
        }

        /// <summary>
        /// Para informar quais os filtros de arquivo devem ser aplicados em todos os itens da lista. O padrão é "Todos os arquivos (*.*)".
        /// </summary>
        public override csFiltrosArquivos FiltrosArquivos
        {
            get
            {
                return base.FiltrosArquivos;
            }
            set
            {
                base.FiltrosArquivos = value;
            }
        }

        /// <summary>
        /// Retorna o ArrayList com a lista de csItemArquivo.
        /// </summary>
        public override ArrayList ItensArquivo
        {
            get
            {
                return base.ItensArquivo;
            }
        }

        /// <summary>
        /// Retorna o csItemArquivo de posição Indice.
        /// </summary>
        public override csItemArquivo Item(int Indice)
        {
            return base.Item(Indice);
        }

        public override int Count
        {
            get
            {
                return base.Count;
            }
        }


    #endregion


    #region Expondo métodos da Base

        /// <summary>
        /// Mostra a dialog para escolher multiplos arquivos e chama a função CarregarArquivo.
        /// Retorna se carregou ou não algum arquivo
        /// </summary>
        public override bool EscolherArquivoECarregar()
        {
            return base.EscolherArquivoECarregar();
        }

        /// <summary>
        /// Carrega o arquivo pra memoria.
        /// </summary>
        public override void CarregarArquivo(string p_CaminhoCompleto)
        {
            base.CarregarArquivo(p_CaminhoCompleto);
        }

        /// <summary>
        /// Salva todos os arquivos da lista em uma pasta especificada.
        /// </summary>
        /// <returns>Retorna a quantidade de arquivos salvos.</returns>
        public override int SalvarTodosArquivos(string p_Caminho)
        {
            return base.SalvarTodosArquivos(p_Caminho);
        }

        /// <summary>
        /// Mostra a dialog para escolher o caminho e chama a função SalvarTodosArquivos.
        /// </summary>
        /// <returns>Retorna a quantidade de arquivos salvos e o caminho que foi escolhido.</returns>
        public override int EscolherCaminhoESalvarArquivos(ref string PastaEscolhida)
        {
            return base.EscolherCaminhoESalvarArquivos(ref PastaEscolhida);
        }

        /// <summary>
        /// Remove Só o conteúdo preenchido pelos usuários, mantem o modelo.
        /// </summary>
        public override void LimparConteudo()
        {
            base.LimparConteudo();
        }

        /// <summary>
        /// Insere um novo item do tipo csItemArquivo.
        /// </summary>
        public override csItemArquivo Add(csItemArquivo Item)
        {
            return base.Add(Item);
        }

        /// <summary>
        /// Remove o csItemArquivo de posição Indice.
        /// </summary>
        public override void Remove(int Indice)
        {
            base.Remove(Indice);
        }

        /// <summary>
        /// Limpa toda a lista.
        /// </summary>
        public override void Clear()
        {
            base.Clear();
        }

    #endregion

    #region Métodos Públicos

        /// <summary>
        /// Mostra a dialog para escolher um arquivo e chama a função CarregarArquivo.
        /// Retorna se carregou ou não algum arquivo
        /// </summary>
        public bool EscolherModeloECarregar()
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
                dlgAbrir.Title = "Escolha o arquivo";
            }
            //dlgAbrir.Filter = _FiltrosArquivos.Filtros;
            dlgAbrir.Multiselect = false;
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
        /// Carrega o arquivo de modelo pra memoria.
        /// </summary>
        public void CarregarModelo(string p_CaminhoCompleto)
        {
            if (_ItemArquivoMod != null)
            {
                DialogResult Resp;
                Resp = MessageBox.Show("Sobrescrever o arquivo já existente?", "Sobrescrever Modelo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Resp != DialogResult.Yes)
                {
                    return;
                }

            }
            _ItemArquivoMod = null;
            GC.Collect();
            _ItemArquivoMod = new csItemArquivo();
            _ItemArquivoMod.Nome = this.Nome;
            _ItemArquivoMod.Descricao = this.Descricao;
            _ItemArquivoMod.FiltrosArquivos.Add("Todos os arquivos (*.*)", "*.*");
            _ItemArquivoMod.CarregarArquivo(p_CaminhoCompleto);
            
        }

        /// <summary>
        /// Exclui o arquivo de modelo.
        /// </summary>
        public void ExcluirModelo()
        {
            if (_ItemArquivoMod != null)
            {
                DialogResult Resp;
                Resp = MessageBox.Show("Excluir o modelo existente?", "Excluir Modelo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Resp != DialogResult.Yes)
                {
                    _ItemArquivoMod = null;
                    GC.Collect();
                }
                else
                {
                    MessageBox.Show("Não existe modelo para excluir?", "Excluir Modelo");
                }

            }

        }
        
    #endregion
    }
}
