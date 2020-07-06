using System;

namespace Check_List
{
    /// <summary>
    /// Classe que implementa filtros de arquivos pra facilitar na hora de preencher a propriedade Filter das Dialogs.
    /// </summary>
    /// <remarks>
    /// Autor: Filipe Kanitz
    /// Data: 07/09/2011
    /// </remarks>
    [Serializable]
    class csFiltroArquivo
    {
    #region Campos Privados
        private string _Descricao = "Todos os arquivos (*.*)";
        private string _Tipos = "*.*";
    #endregion

    #region Propriedades
        /// <summary>
        /// Descrição do filtro.
        /// </summary>
        /// <remarks>
        /// Exemplo: "Arquivo do Windows Media"
        /// </remarks>
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
        /// Tipos da descrição.
        /// </summary>
        /// <remarks>
        /// Exemplo: "*.asf;*.wm;*.wma;*.wmv;*.wmd"
        /// </remarks>
        public string Tipos
        {
            get
            {
                return _Tipos;
            }
            set
            {
                _Tipos = value;
            }
        }
    #endregion

    #region Sobrecarga de Métodos
        public override string ToString()
        {
            return this.Descricao;
        }
    #endregion

    #region Métodos Públicos
            /// <summary>
            /// Retorna o filtro já formatado. 
            /// </summary>
            /// <remarks>
            /// Pronto para atribuir à propriedade Filter de uma Dialog.
            /// Ex.: "Arquivo do Windows Media|*.asf;*.wm;*.wma;*.wmv;*.wmd"
            /// </remarks>
            public string Filtro
            {
                get
                {
                    return _Descricao + "|" + _Tipos;
                }
            }


        #endregion
    }
}
