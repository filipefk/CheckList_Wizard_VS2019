using System;
using Microsoft.Win32;
using System.Windows.Forms;

namespace Check_List
{
    /// <summary>
    /// Classe que implementa um item de Check List que é um texto simples
    /// </summary>
    /// <remarks>
    /// Autor: Filipe Kanitz
    /// Data: 07/09/2011
    /// </remarks>
    [Serializable]
    class csItemTexto : csItem
    {
    #region Campos Privados
        private string _Texto = "";
        private string _TextoPadrao = "";
        private bool _ItemIdentificador = false;
        private bool _PermitirSalvarValorPadrao = false;
        private string _ValorPadrao = "";
    #endregion

    #region Propriedades
        /// <summary>
        /// Se permite ou não que o usuário salve o valor preenchido como padrão.
        /// </summary>
        public bool PermitirSalvarValorPadrao
        {
            get
            {
                return _PermitirSalvarValorPadrao;
            }
            set
            {
                _PermitirSalvarValorPadrao = value;
            }
        }

        /// <summary>
        /// Retorna o nome do tipo de item.
        /// </summary>
        public override string NomeTipo
        {
            get
            {
                return "Texto";
            }
        }

        /// <summary>
        /// Retorna o valor padrão salvo para este item.
        /// </summary>
        public string ValorPadrao
        {
            get
            {
                string _NomeCampo = this.NomeTipo + "." + this.Nome + "." + this.Descricao;
                _ValorPadrao = (string)csUtil.CarregarPreferencia(_NomeCampo);
                return _ValorPadrao;
            }
        }

        /// <summary>
        /// Retorna um texto de relatório com todas as opções do item
        /// No caso do csItemTexto é o mesmo do TextoRelatorioCurto
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
                
                if (_Texto.Trim().Length > 0)
                {
                    _TextoRelatorio = "<font color=blue>";
                    _TextoRelatorio = _TextoRelatorio + _Texto.Replace("\n", "<br/>\n");
                    _TextoRelatorio = _TextoRelatorio + "</font>";
                }
                else
                {
                    if (this.Observacao.Trim().Length > 0)
                    {
                        _TextoRelatorio = "<font color=blue>";
                        _TextoRelatorio = _TextoRelatorio + this.Observacao.Replace("\n", "<br/>\n");
                        _TextoRelatorio = _TextoRelatorio + "</font>";
                    }
                    else
                    {
                        if (_TextoPadrao.Trim().Length > 0)
                        {
                            _TextoRelatorio = "<font color=blue>";
                            _TextoRelatorio = _TextoRelatorio + _TextoPadrao.Replace("\n", "<br/>\n");
                            _TextoRelatorio = _TextoRelatorio + "</font>";
                        }
                    }
                }

                return _TextoRelatorio;
            }
        }

        /// <summary>
        /// O primeiro ItemIdentificador = true encontrado na lista terá seu Texto usado para sugerir o nome do arquivo ao salvar.
        /// </summary>
        public bool ItemIdentificador
        {
            get
            {
                return _ItemIdentificador;
            }
            set
            {
                _ItemIdentificador = value;
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
                if (this.TextoPadrao.Length > 0)
                {
                    _TextoDetalhe = "Tem Texto Padrão";
                }
                else
                {
                    _TextoDetalhe = "Não tem Texto Padrão";
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
                    return (this.Observacao.Length > 0);
                }
                else
                {
                    return (_Texto.Length > 0) || (this.Observacao.Length > 0);
                }
            }
        }

        /// <summary>
        /// Texto do item.
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
        /// Texto padrão do item.
        /// </summary>
        public string TextoPadrao
        {
            get
            {
                return _TextoPadrao;
            }
            set
            {
                _TextoPadrao = value;
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
            _Texto = "";
            _TextoPadrao = "";
            base.Limpar();
        }
    #endregion

    #region Métodos Públicos
        /// <summary>
        /// Remove Só o conteúdo preenchido pelos usuários, mantem o modelo.
        /// </summary>
        public override void LimparConteudo()
        {
            _Texto = "";
            this.Observacao = "";
        }

        /// <summary>
        /// Carrega o valor salvo no registro em SOFTWARE\CheckListWizard\Preferencias.
        /// </summary>
        public void CarregaValorPadrao()
        {
            if (this.ValorPadrao != null)
            {
                this.Texto = this.ValorPadrao;
            }
            else
            {
                MessageBox.Show("Nenhum valor padrão foi salvo para este item", "Carregar Valor padrão", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public void SalvarValorPadrao()
        {
            if (_Texto.Trim().Length > 0)
            {
                string _NomeCampo = this.NomeTipo + "." + this.Nome + "." + this.Descricao;
                _NomeCampo = _NomeCampo.Replace("\\", "_");
                _NomeCampo = _NomeCampo.Replace("/", "_");
                csUtil.SalvarPreferencia(_NomeCampo, _Texto);
            }
        }



    #endregion

    }
}
