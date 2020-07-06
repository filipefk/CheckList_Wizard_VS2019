using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Check_List
{
    /// <summary>
    /// Classe que implementa os dados de um arquivo aberto (Process.Start()).
    /// </summary>
    /// <remarks>
    /// Autor: Filipe Kanitz
    /// Data: 22/10/2011
    /// </remarks>
    [Serializable]
    class csArquivoAberto
    {

    #region Campos Privados
        private DateTime _DataHora = DateTime.Now;
        private string _NomeArquivo = "";
        private Process _Processo = null;
        private csItemArquivo _ItemArquivo = null;
    #endregion

    #region Propriedades
        /// <summary>
        /// Item arquivo "dono" do arquivo.
        /// </summary>
        public csItemArquivo ItemArquivo
        {
            get
            {
                return _ItemArquivo;
            }
            set
            {
                _ItemArquivo = value;
            }
        }

        /// <summary>
        /// Data e hora que o arquivo foi gerado.
        /// </summary>
        public DateTime DataHora
        {
            get
            {
                return _DataHora;
            }
            set
            {
                _DataHora = value;
            }
        }

        /// <summary>
        /// Nome do arquivo.
        /// </summary>
        public string NomeArquivo
        {
            get
            {
                return _NomeArquivo;
            }
            set
            {
                _NomeArquivo = value;
            }
        }

        /// <summary>
        /// Processo aberto.
        /// </summary>
        public Process Processo
        {
            get
            {
                return _Processo;
            }
            set
            {
                _Processo = value;
            }
        }

    #endregion

    }
}
