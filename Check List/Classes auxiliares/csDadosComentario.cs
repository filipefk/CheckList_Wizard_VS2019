using System;
using System.Net;
using System.Security.Principal;

namespace Check_List
{
    /// <summary>
    /// Classe que implementa os campos de COMENTÁRIOS.
    /// </summary>
    /// <remarks>
    /// Autor: Filipe Kanitz
    /// Data: 16/08/2015
    /// </remarks>
    [Serializable]
    class csDadosComentario
    {
    #region Campos Privados
        private DateTime _DataHora;
        private string _NomeMaquina = "";
        private IPAddress[] _ListaIPs = null;
        private string _UsuarioLogado = "";
        private string _Comentario = "";
    #endregion

    #region Construtores
        /// <summary>
        /// Construtor Padrão. Já preenche as propriedades automaticamente
        /// </summary>
        public csDadosComentario()
        {
            _DataHora = DateTime.Now;
            _NomeMaquina = Dns.GetHostName();
            _ListaIPs = Dns.GetHostAddresses("localhost");
            _UsuarioLogado = WindowsIdentity.GetCurrent().Name;
            _Comentario = "";
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
        /// Nome da máquina aonde foi feito o comentário.
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
        /// IPs da máquina aonde foi feito o comentário.
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
        /// Usuário logado na máquina aonde foi feito o comentário.
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
        /// Comentário propriamente dito.
        /// </summary>
        public string Comentario
        {
            get
            {
                return _Comentario;
            }
            set
            {
                _Comentario = value;
            }
        }

    #endregion
    }
}
