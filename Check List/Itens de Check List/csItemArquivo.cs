using System;
using System.Windows.Forms;
using System.IO;
using System.Security.Principal;

namespace Check_List
{
    /// <summary>
    /// Classe que implementa um item de Check List que é um arquivo a ser carregado
    /// </summary>
    /// <remarks>
    /// Autor: Filipe Kanitz
    /// Data: 07/09/2011
    /// </remarks>
    [Serializable]
    class csItemArquivo : csItem
    {
    #region Campos Privados
        private byte[] _Arquivo = null;
        private string _CaminhoCompletoOrigem = "";
        private csFiltrosArquivos _FiltrosArquivos = new csFiltrosArquivos();
        private DateTime _DataCriacao;
        private DateTime _DataUltimaAlteracao;
        private DateTime _DataInclusao;
        private string _UsuarioIncluiu = "";
    #endregion

    #region Propriedades

        /// <summary>
        /// Nome do usuario que incluiu o arquivo na lista.
        /// </summary>
        public string UsuarioIncluiu
        {
            get
            {
                return _UsuarioIncluiu;
            }
        }

        /// <summary>
        /// Data e hora que o arquivo foi criado.
        /// </summary>
        public DateTime DataCriacao
        {
            get
            {
                return _DataCriacao;
            }
            set
            {
                _DataCriacao = value;
            }
        }

        /// <summary>
        /// Data e hora que o arquivo foi alterdado.
        /// </summary>
        public DateTime DataUltimaAlteracao
        {
            get
            {
                return _DataUltimaAlteracao;
            }
            set
            {
                _DataUltimaAlteracao = value;
            }
        }

        /// <summary>
        /// Data e hora que o arquivo foi incluído na lista.
        /// </summary>
        public DateTime DataInclusao
        {
            get
            {
                return _DataInclusao;
            }
            set
            {
                _DataInclusao = value;
            }
        }

        /// <summary>
        /// Retorna o nome do tipo de item.
        /// </summary>
        public override string NomeTipo
        {
            get
            {
                return "Arquivo";
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

                _TextoRelatorio = csUtil.ParteNomeArquivo(_CaminhoCompletoOrigem, csUtil.enuParteNomeArquivo.NomeExtencao);

                if (_TextoRelatorio.Trim().Length > 0)
                {
                    _TextoRelatorio = _TextoRelatorio + "<font color=blue>" + _TextoRelatorio + "</font>";
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
                    return ((this.TamanhoArquivo > 0) && (this.Observacao.Length > 0));
                }
                else
                {
                    return (this.TamanhoArquivo > 0) || (this.Observacao.Length > 0);
                }
            }
        }

        /// <summary>
        /// Nome do arquivo, sem o caminho.
        /// </summary>
        public string NomeArquivo
        {
            get
            {
                if (_CaminhoCompletoOrigem.Length > 0)
                {
                    string[] vetSplit = _CaminhoCompletoOrigem.Split(new Char[] { '\\' });
                    return vetSplit[vetSplit.Length - 1];
                }
                else
                {
                    return "";
                }
            }
        }

        /// <summary>
        /// Para informar quais os filtros de arquivo devem ser aplicados neste item. O padrão é "Todos os arquivos (*.*)".
        /// </summary>
        public csFiltrosArquivos FiltrosArquivos
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
        /// Tamanho do arquivo em Bytes.
        /// </summary>
        public float TamanhoArquivo
        {
            get
            {
                if (_Arquivo == null)
                {
                    return 0;
                }
                else
                {
                    return _Arquivo.Length;
                }
            }
        }

        /// <summary>
        /// Caminho completo do arquivo de origem.
        /// </summary>
        public string CaminhoCompletoOrigem
        {
            get
            {
                return _CaminhoCompletoOrigem;
            }
        }

    #endregion

    #region Sobrecarga de Métodos

        /// <summary>
        /// Remove todas as propriedades Preenchidas.
        /// </summary>
        public override void Limpar()
        {
            _Arquivo = null;
            _CaminhoCompletoOrigem = "";
            _FiltrosArquivos = new csFiltrosArquivos();
            base.Limpar();
        }
    #endregion

    #region Métodos Públicos

        /// <summary>
        /// Remove Só o conteúdo preenchido pelos usuários, mantem o modelo.
        /// </summary>
        public override void LimparConteudo()
        {
            _Arquivo = null;
            _CaminhoCompletoOrigem = "";
            this.Observacao = "";
            GC.Collect();
        }

        /// <summary>
        /// Exclui o arquivo caso exista.
        /// </summary>
        public void ExcluirArquivo()
        {
            _Arquivo = null;
            _CaminhoCompletoOrigem = "";
            GC.Collect();
        }

        /// <summary>
        /// Carrega o arquivo pra memoria.
        /// </summary>
        public void CarregarArquivo(string p_CaminhoCompleto)
        {
            try
            {
                // Abre o arquivo para leitura
                FileStream _FileStream = new FileStream(p_CaminhoCompleto, FileMode.Open, FileAccess.Read);
                BinaryReader _BinaryReader = new BinaryReader(_FileStream);

                // Pega o tamanho em bytes
                long _TotalBytes = new FileInfo(p_CaminhoCompleto).Length;

                // Le o arquivo e joga no buffer
                _Arquivo = _BinaryReader.ReadBytes((Int32)_TotalBytes);

                // Fecha o arquivo
                _FileStream.Close();
                _FileStream.Dispose();
                _BinaryReader.Close();

                // Guarda o caminho completo de origem
                _CaminhoCompletoOrigem = p_CaminhoCompleto;

                _DataCriacao = File.GetCreationTime(p_CaminhoCompleto);
                _DataUltimaAlteracao = File.GetLastWriteTime(p_CaminhoCompleto);
                _DataInclusao = DateTime.Now;
                _UsuarioIncluiu = WindowsIdentity.GetCurrent().Name;
            }

            catch (Exception _Exception)
            {
                // Erro
                MessageBox.Show("Erro na leitura do arquivo: " + _Exception.ToString(), "Carregar Arquivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Salva o arquivo no caminho indicado.
        /// </summary>
        public void SalvarArquivo(string p_CaminhoCompleto)
        {
            if (_CaminhoCompletoOrigem.Length == 0)
            {
                MessageBox.Show("Não existe arquivo para ser salvo!", "Salvar Arquivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (p_CaminhoCompleto.Length == 0)
            {
                MessageBox.Show("Informe o caminho do arquivo!", "Salvar Arquivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Abre o arquivo para escrita
                FileStream _FileStream = new FileStream(p_CaminhoCompleto, FileMode.Create, FileAccess.Write);

                // Escreve o conteúdo do bytearray no arquivo.
                _FileStream.Write(_Arquivo, 0, _Arquivo.Length);

                // Fecha o arquivo
                _FileStream.Close();
            }

            catch (Exception _Exception)
            {
                // Erro
                MessageBox.Show("Erro ao salvar o arquivo: " + _Exception.ToString(), "Salvar Arquivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Mostra a dialog para escolher o arquivo e chama a função CarregarArquivo.
        /// </summary>
        public void EscolherArquivoECarregar()
        {
            OpenFileDialog dlgAbrir = new OpenFileDialog();
            DialogResult Resp;

            if (this.Descricao.Length > 0)
            {
                dlgAbrir.Title = this.Descricao;
            }
            else
            {
                dlgAbrir.Title = "Escolha o arquivo";
            }
            dlgAbrir.Filter = _FiltrosArquivos.Filtros;
            Resp = dlgAbrir.ShowDialog();
            if (Resp == System.Windows.Forms.DialogResult.OK)
            {
                this.CarregarArquivo(dlgAbrir.FileName);
            }

        }

        /// <summary>
        /// Mostra a dialog para escolher o destino do arquivo e chama a função SalvarArquivo.
        /// </summary>
        public void EscolherDestinoESalvar()
        {
            if (this.TamanhoArquivo == 0)
            {
                MessageBox.Show("Nenhum arquivo carregado para salvar!", "Escolher destino e Salvar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SaveFileDialog dlgSalvar = new SaveFileDialog();
            DialogResult Resp;
            dlgSalvar.Title = "Escolha aonde salvar o arquivo";
            dlgSalvar.FileName = this.NomeArquivo;
            dlgSalvar.CheckPathExists = true;
            dlgSalvar.CheckFileExists = false;
            dlgSalvar.CreatePrompt = false;
            dlgSalvar.OverwritePrompt = true;
            dlgSalvar.ShowHelp = false;
            dlgSalvar.ValidateNames = true;
            Resp = dlgSalvar.ShowDialog();

            if (Resp == System.Windows.Forms.DialogResult.OK)
            {
                this.SalvarArquivo(dlgSalvar.FileName);
            }

        }
    #endregion

    }
}
