using System;
using System.Collections;

namespace Check_List
{
    /// <summary>
    /// Classe base para todas as classes que serão um item de um Check List.
    /// </summary>
    /// <remarks>
    /// Autor: Filipe Kanitz
    /// Data: 07/09/2011
    /// </remarks>
    [Serializable]
    class csItem
    {
    #region Campos Privados
        private string _Nome = "";
        private string _Descricao = "";
        private string _Ajuda = "";
        private string _Observacao = "";
        private bool _ObservacaoObrigatoria = false;
    #endregion

    #region Propriedades
        /// <summary>
        /// Retorna o nome do tipo de item.
        /// </summary>
        public virtual string NomeTipo
        {
            get
            {
                return "Item";
            }
        }

        

        /// <summary>
        /// Retorna um texto de relatório do item preenchido.
        /// </summary>
        public virtual string TextoRelatorio
        {
            get
            {
                string _TextoRelatorio = "";
                _TextoRelatorio = "<font size=3><b>" + this.Nome + "</b> - <i>" + this.Descricao + "</i></font><br/>\n";
                _TextoRelatorio = _TextoRelatorio + this.TextoRelatorioCurto;
                return _TextoRelatorio;
            }
        }

        /// <summary>
        /// Retorna um texto de relatório sem Nome e descrição do item preenchido.
        /// </summary>
        public virtual string TextoRelatorioCurto
        {
            get
            {
                string _TextoRelatorio = "";
                return _TextoRelatorio;
            }
        }

        /// <summary>
        /// Retorna um texto de detalhe da configuração do item.
        /// </summary>
        public virtual string TextoDetalhe
        {
            get
            {
                string _TextoDetalhe = "";
                return _TextoDetalhe;
            }
        }

        /// <summary>
        /// Indica se o item foi preenchido ou não.
        /// </summary>
        public virtual bool Preenchido
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Nome do item.
        /// </summary>
        public string Nome
        {
            get
            {
                return _Nome;
            }
            set
            {
                _Nome = value;
            }
        }

        /// <summary>
        /// Descrição do item. Explicação de para que ele vai servir.
        /// </summary>
        public string Descricao
        {
            get
            {
                return _Descricao;
            }
            set
            {
                _Descricao = value;
            }
        }

        /// <summary>
        /// Ajuda do item. Explicação super detalhada de porque deve ser preenchido, aonde será utilizado, etc.
        /// </summary>
        public string Ajuda
        {
            get
            {
                return _Ajuda;
            }
            set
            {
                _Ajuda = value;
            }
        }

        /// <summary>
        /// Campo de observação a ser preenchido pelo usuário ao preencher o Check List.
        /// </summary>
        public string Observacao
        {
            get
            {
                return _Observacao;
            }
            set
            {
                _Observacao = value;
            }
        }

        /// <summary>
        /// Define se o campo observação é obrigatório ou não.
        /// </summary>
        public bool ObservacaoObrigatoria
        {
            get
            {
                return _ObservacaoObrigatoria;
            }
            set
            {
                _ObservacaoObrigatoria = value;
            }
        }

    #endregion

    #region Métodos Públicos

        /// <summary>
        /// Remove Só o conteúdo preenchido pelos usuários, mantem o modelo.
        /// </summary>
        public virtual void LimparConteudo()
        {
            
        }

        /// <summary>
        /// Remove todas as propriedades Preenchidas.
        /// </summary>
        public virtual void Limpar()
        {
            _Nome = "";
            _Descricao = "";
            _Ajuda = "";
            _Observacao = "";
            _ObservacaoObrigatoria = false;
            GC.Collect();
        }
    #endregion
    }
}
