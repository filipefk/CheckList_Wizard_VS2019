using System;
using Microsoft.Win32;
using System.Windows.Forms;

namespace Check_List
{
    /// <summary>
    /// Classe que implementa um item de Check List que é uma data e hora
    /// </summary>
    /// <remarks>
    /// Autor: Filipe Kanitz
    /// Data: 15/11/2012
    /// </remarks>
    [Serializable]
    class csItemData : csItem
    {
    #region Campos Privados
        private DateTime? _DataHora = null;
        private bool _SoDataSemHora = false;
    #endregion

    #region Propriedades
        /// <summary>
        /// Retorna o nome do tipo de item.
        /// </summary>
        public override string NomeTipo
        {
            get
            {
                return "Data";
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
                if (_DataHora != null)
                {
                    DateTime _DataHoraTemp = (DateTime)_DataHora;
                    if (_SoDataSemHora)
                    {
                        _TextoRelatorio = "<font color=blue>" + _DataHoraTemp.ToString("dd/MM/yyyy") + "</font>";
                    }
                    else
                    {
                        _TextoRelatorio = "<font color=blue>" + _DataHoraTemp.ToString("dd/MM/yyyy HH:mm:ss") + "</font>";
                    }
                }
                else
                {
                    if (this.Observacao.Trim().Length > 0)
                    {
                        _TextoRelatorio = _TextoRelatorio + "<font color=blue><b>Obs.:</b>" + this.Observacao.Replace("\n", "<br/>\n") + "</font>";
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
                if (_SoDataSemHora)
                {
                    return "Data";
                }
                else
                {
                    return "Data Hora";
                }
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
                    return (this.Observacao.Length > 0);
                }
                else
                {
                    return (_DataHora != null) || (this.Observacao.Length > 0);
                }
            }
        }

        /// <summary>
        /// Data Hora do item.
        /// </summary>
        public DateTime? DataHora
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
        /// Retorna se tem hora também ou se é só data
        /// </summary>
        public bool SoDataSemHora
        {
            get
            {
                return _SoDataSemHora;
            }
            set
            {
                _SoDataSemHora = value;
            }
        }
        
        /// <summary>
        /// Retorna se tem valor salvo no registro em SOFTWARE\CheckListWizard\Preferencias.
        /// </summary>
        public bool TemValorPadrao
        {
            get
            {
                try
                {
                    RegistryKey PreferenciasUsuario = Registry.CurrentUser.OpenSubKey("SOFTWARE\\CheckListWizard\\Preferencias", true);

                    if (PreferenciasUsuario != null)
                    {
                        string TextoPreferencia = "";
                        TextoPreferencia = PreferenciasUsuario.GetValue(this.NomeTipo + "." + this.Nome + "." + this.Descricao).ToString();
                        if (TextoPreferencia.Trim().Length == 0)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

    #endregion

    #region Sobrecarga de Métodos
        
        /// <summary>
        /// Remove todas as propriedades Preenchidas.
        /// </summary>
        public override void Limpar()
        {
            _DataHora = null;
            base.Limpar();
        }
    #endregion

    #region Métodos Públicos
        /// <summary>
        /// Remove Só o conteúdo preenchido pelos usuários, mantem o modelo.
        /// </summary>
        public override void LimparConteudo()
        {
            _DataHora = null;
            this.Observacao = "";
        }
        
    #endregion

    }
}
