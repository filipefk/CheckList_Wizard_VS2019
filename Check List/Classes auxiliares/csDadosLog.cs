using System;
using System.Net;
using System.Security.Principal;

namespace Check_List
{
    /// <summary>
    /// Classe que implementa os campos de LOG.
    /// </summary>
    /// <remarks>
    /// Autor: Filipe Kanitz
    /// Data: 18/09/2011
    /// </remarks>
    [Serializable]
    class csDadosLog
    {

    #region Campos Privados
        private DateTime _DataHora;
        private string _NomeMaquina = "";
        private IPAddress[] _ListaIPs = null;
        private string _UsuarioLogado = "";
        private string _CaminhoCompletoArquivo = "";
    #endregion

    #region Construtores
        /// <summary>
        /// Construtor Padrão. Já preenche as propriedades automaticamente
        /// </summary>
        public csDadosLog()
        {
            _DataHora = DateTime.Now;
            _NomeMaquina = Dns.GetHostName();
            _ListaIPs = Dns.GetHostAddresses("localhost");
            _UsuarioLogado = WindowsIdentity.GetCurrent().Name;
        }
    #endregion

    #region Propriedades
        /// <summary>
        /// Data e hora da alteração.
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
        /// Nome da máquina aonde foi alterado.
        /// </summary>
        public string NomeMaquina
        {
            get
            {
                return _NomeMaquina;
            }
            set
            {
                _NomeMaquina = value;
            }
        }

        /// <summary>
        /// IPs da máquina aonde foi alterado.
        /// </summary>
        public IPAddress[] ListaIPs
        {
            get
            {
                return _ListaIPs;
            }
            set
            {
                _ListaIPs = value;
            }
        }

        /// <summary>
        /// Usuário logado na máquina aonde foi alterado.
        /// </summary>
        public string UsuarioLogado
        {
            get
            {
                return _UsuarioLogado;
            }
            set
            {
                _UsuarioLogado = value;
            }
        }

        /// <summary>
        /// Caminho completo do arquivo salvo.
        /// </summary>
        public string CaminhoCompletoArquivo
        {
            get
            {
                return _CaminhoCompletoArquivo;
            }
            set
            {
                _CaminhoCompletoArquivo = value;
            }
        }

    #endregion

    }
}
