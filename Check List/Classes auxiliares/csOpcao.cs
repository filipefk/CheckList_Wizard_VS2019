using System;

namespace Check_List
{
    /// <summary>
    /// Classe que implementa as opções que serão inseridas em csItemListaOpcoes.
    /// </summary>
    /// <remarks>
    /// Autor: Filipe Kanitz
    /// Data: 07/09/2011
    /// </remarks>
    [Serializable]
    class csOpcao
    {
    #region Campos Privados
        private string _Texto = "";
        private bool _Marcada = false;
        private bool _Padrao = false;
    #endregion

    #region Propriedades
        /// <summary>
        /// Texto da opção.
        /// </summary>
        public string Texto
        {
            get
            {
                return _Texto;
            }
            set
            {
                _Texto = value;
            }
        }

        /// <summary>
        /// Indica se a opção está selecionada.
        /// </summary>
        public bool Marcada
        {
            get
            {
                return _Marcada;
            }
            set
            {
                _Marcada = value;
            }
        }

        /// <summary>
        /// Indica se esta é a opção padrão da lista.
        /// </summary>
        public bool Padrao
        {
            get
            {
                return _Padrao;
            }
            set
            {
                _Padrao = value;
            }
        }
    #endregion

    #region Sobrecarga de Métodos
        public override string ToString()
        {
            return this._Texto;
        }
    #endregion
    }
}
