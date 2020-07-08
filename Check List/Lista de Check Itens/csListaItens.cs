using System;
using System.Collections;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Check_List
{
    /// <summary>
    /// Classe que implementa uma lista de itens de Check List. Esta classe é que será serializada ao salvar a lista em arquivo.
    /// </summary>
    /// <remarks>
    /// Autor: Filipe Kanitz
    /// Data: 07/09/2011
    /// </remarks>
    [Serializable]
    class csListaItens : ISerializable
    {
    #region Campos Privados
        private ArrayList _Itens = new ArrayList();
        private string _Nome = "";
        private string _Descricao = "";
        private string _Ajuda = "";
        private bool _SalvarLog = true;
        private bool _AlertarAoReutilizarCheckList = true;
        private ArrayList _ListaLog = new ArrayList();
        private ArrayList _ListaComentarios = new ArrayList();
        private ArrayList _ListaRelatorios = new ArrayList();
        private Stream _stream = null;
    #endregion

    #region Enumerações
        public enum enuTipoCheckList
        {
            tcTodos = -1,
            tclModelo = 0,
            tclPreenchido = 1
        }

        public enum enuTipoCheckIten
        {
            Indefinido,
            Arquivo,
            ListaDeArquivos,
            ListaDeOpcoes,
            Texto,
            Data
        }
    #endregion

    #region Construtores
        /// <summary>
        /// Construtor Padrão. Pra usar na hora de preencher uma lista nova
        /// </summary>
        public csListaItens()
        {
            
        }

        ~csListaItens()
        {
            try
            {
                _stream.Close();
            }
            catch (Exception)
            {
                
            }
            
        }

        /// <summary>
        /// Construtor a partir de um arquivo serializado.
        /// </summary>
        public csListaItens(string p_CaminhoCompleto, ref bool CarregouArquivo)
        {
            CarregouArquivo = false;
            try
            {
                csListaItens ListaItensDeserializada = null;

                _stream = File.Open(p_CaminhoCompleto, FileMode.Open, FileAccess.ReadWrite, FileShare.Read);
                BinaryFormatter bformatter = new BinaryFormatter();

                frmAbrindo _FormAbrindo = new frmAbrindo();
                Application.DoEvents();

                ListaItensDeserializada = (csListaItens)bformatter.Deserialize(_stream);

                try
                {
                    _FormAbrindo.Close();
                    _FormAbrindo.Dispose();
                }
                catch (Exception)
                {

                }

                string Extencao = csUtil.ParteNomeArquivo(p_CaminhoCompleto, csUtil.enuParteNomeArquivo.Extencao);
                if (Extencao.ToUpper() != "CHKLP")
                {
                    _stream.Close();
                }

                this._Nome = ListaItensDeserializada.Nome;
                this._Descricao = ListaItensDeserializada.Descricao;
                this._Ajuda = ListaItensDeserializada.Ajuda;
                this._Itens = ListaItensDeserializada.Itens;
                this._SalvarLog = ListaItensDeserializada.SalvarLog;
                this._AlertarAoReutilizarCheckList = ListaItensDeserializada.AlertarAoReutilizarCheckList;
                this._ListaLog = ListaItensDeserializada.ListaLog;
                this._ListaComentarios = ListaItensDeserializada.ListaComentarios;
                this._ListaRelatorios = ListaItensDeserializada.ListaRelatorios;
                GC.Collect();
                CarregouArquivo = true;
            }

            catch (Exception _Exception)
            {
                // Erro
                MessageBox.Show("Erro ao carregar o arquivo: " + _Exception.Message, "Deserializar Arquivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Construtor de Deserialização.
        /// </summary>
        /// <remarks>Necessário para implementar a interface ISerializable</remarks>
        public csListaItens(SerializationInfo info, StreamingContext ctxt)
        {
            this._Nome = (String)info.GetValue("csListaItens_Nome", typeof(string));
            this._Descricao = (String)info.GetValue("csListaItens_Descricao", typeof(string));
            this._Ajuda = (String)info.GetValue("csListaItens_Ajuda", typeof(string));
            this._Itens = (ArrayList)info.GetValue("csListaItens_Itens", typeof(ArrayList));
            
            // Estas propriedades criei depois de já existirem arquivos serializados, por isso coloquei
            // o try catch, para manter a compatibilidade com os que não tinham as propriedades novas
            try
            {
                this._SalvarLog = (Boolean)info.GetValue("csListaItens_SalvarLog", typeof(Boolean));
            }
            catch (Exception)
            {
                this._SalvarLog = false;
            }

            try
            {
                this._AlertarAoReutilizarCheckList = (Boolean)info.GetValue("csListaItens_AlertarAoReutilizarCheckList", typeof(Boolean));
            }
            catch (Exception)
            {
                // Aqui estou setando a propriedade para true, para os CheckLists que não tinham esta opção carregarem já como default
                this._AlertarAoReutilizarCheckList = true;
            }

            try
            {
                this._ListaLog = (ArrayList)info.GetValue("csListaItens_ListaLog", typeof(ArrayList));
            }
            catch (Exception)
            {
                this._ListaLog.Clear();
            }

            try
            {
                this._ListaComentarios = (ArrayList)info.GetValue("csListaItens_ListaComentarios", typeof(ArrayList));
            }
            catch (Exception)
            {
                this._ListaComentarios.Clear();
            }

            try
            {
                this._ListaRelatorios = (ArrayList)info.GetValue("csListaItens_ListaRelatorios", typeof(ArrayList));
            }
            catch (Exception)
            {
                this._ListaRelatorios.Clear();
            }

        }

    #endregion

    #region Propriedades Públicas
        /// <summary>
        /// Retorna a propriedade Texto do primeiro csItemTexto com ItemIdentificador = true.
        /// </summary>
        public string TextoItemIdentificador
        {
            get
            {
                csItemTexto ItemTexto = null;
                for (int i = 0; i < _Itens.Count; i++)
                {
                    Type Tipo = _Itens[i].GetType();
                    if (Tipo.ToString() == "Check_List.csItemTexto")
	                {
                        ItemTexto = (csItemTexto)_Itens[i];
                        if (ItemTexto.ItemIdentificador)
                        {
                            return ItemTexto.Texto;
                        }
	                }
                }

                return "";
            }
        }

        /// <summary>
        /// Se deve ou não salvar o log de alterações.
        /// </summary>
        public bool SalvarLog
        {
            get
            {
                return _SalvarLog;
            }
            set
            {
                _SalvarLog = value;
            }
        }

        /// <summary>
        /// Se deve ou alertar caso o CheckList esteja sendo reutilizado.
        /// Esta opção só funciona se a opção de salvar log estiver ativa também.
        /// </summary>
        public bool AlertarAoReutilizarCheckList
        {
            get
            {
                return _AlertarAoReutilizarCheckList;
            }
            set
            {
                _AlertarAoReutilizarCheckList = value;
            }
        }

        /// <summary>
        /// Nome do CheckList.
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
        /// Descrição do CheckList.
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
        /// Ajuda do Check List.
        /// </summary>
        /// <value>Explicação super detalhada de porque deve ser preenchido, aonde será utilizado, etc.</value>
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
        /// Retorna o ArrayList com os itens adicionados.
        /// </summary>
        public ArrayList Itens
        {
            get
            {
                return _Itens;
            }
        }

        /// <summary>
        /// Retorna o ArrayList com a lista de relatórios.
        /// </summary>
        public ArrayList ListaRelatorios
        {
            get
            {
                return _ListaRelatorios;
            }
        }

        /// <summary>
        /// Retorna o ArrayList com a lista de LOG.
        /// </summary>
        public ArrayList ListaLog
        {
            get
            {
                return _ListaLog;
            }
        }

        /// <summary>
        /// Retorna o ArrayList com a lista de comentários.
        /// </summary>
        public ArrayList ListaComentarios
        {
            get
            {
                return _ListaComentarios;
            }
        }

        /// <summary>
        /// Retorna a quantidade de itens da lista
        /// </summary>
        public int Count
        {
            get
            {
                return _Itens.Count;
            }
        }

        /// <summary>
        /// Verifica o LOG e retorna TRUE ou FALSE se houver suspeita de o CheckList estar sendo reutilizado
        /// </summary>
        public bool EstaReutilizandoCheckList
        {
            get
            {
                bool _Retorno = false;
                if (_ListaLog.Count > 0)
                {
                    DateTime _MenorData = DateTime.MinValue;
                    DateTime _MaiorData = DateTime.MaxValue;
                    string _NomeArqMenorData = "";
                    string _NomeArqMaiorData = "";
                    csDadosLog DoadosLog = null;
                    for (int i = 0; i < _ListaLog.Count; i++)
                    {
                        DoadosLog = (csDadosLog)_ListaLog[i];
                        if (_MenorData == DateTime.MinValue)
                        {
                            _MenorData = DoadosLog.DataHora;
                            if (DoadosLog.CaminhoCompletoArquivo != null)
                            {
                                _NomeArqMenorData = csUtil.ParteNomeArquivo(DoadosLog.CaminhoCompletoArquivo, csUtil.enuParteNomeArquivo.Nome);
                            }
                        }
                        else
                        {
                            if (_MenorData > DoadosLog.DataHora)
                            {
                                _MenorData = DoadosLog.DataHora;
                                if (DoadosLog.CaminhoCompletoArquivo != null)
                                {
                                    _NomeArqMenorData = csUtil.ParteNomeArquivo(DoadosLog.CaminhoCompletoArquivo, csUtil.enuParteNomeArquivo.Nome);
                                }
                            }
                        }
                        if (_MaiorData == DateTime.MaxValue)
                        {
                            _MaiorData = DoadosLog.DataHora;
                            if (DoadosLog.CaminhoCompletoArquivo != null)
                            {
                                _NomeArqMaiorData = csUtil.ParteNomeArquivo(DoadosLog.CaminhoCompletoArquivo, csUtil.enuParteNomeArquivo.Nome);
                            }
                        }
                        else
                        {
                            if (_MaiorData < DoadosLog.DataHora)
                            {
                                _MaiorData = DoadosLog.DataHora;
                                if (DoadosLog.CaminhoCompletoArquivo != null)
                                {
                                    _NomeArqMaiorData = csUtil.ParteNomeArquivo(DoadosLog.CaminhoCompletoArquivo, csUtil.enuParteNomeArquivo.Nome);
                                }
                            }
                        }
                    }

                    if ((_MenorData > DateTime.MinValue) && (_MaiorData < DateTime.MaxValue))
                    {
                        if (_MenorData != _MaiorData)
                        {
                            int _DifDias = 0;
                            _DifDias = (_MaiorData - _MenorData).Days;
                            if (_DifDias > 60)
                            {
                                if (_NomeArqMenorData != "" || _NomeArqMaiorData != "")
                                {
                                    if (_NomeArqMenorData != _NomeArqMaiorData)
                                    {
                                        _Retorno = true;
                                    }
                                }
                                else
                                {
                                    _Retorno = true;
                                }
                            }
                        }
                    }
                }
                return _Retorno;
            }
        }

    #endregion

    #region Métodos Públicos
        /// <summary>
        /// Limpa a lista de relatórios
        /// </summary>
        public void LimparListaRelatorios()
        {
            _ListaRelatorios.Clear();
        }

        /// <summary>
        /// Novo relatórios personalizado
        /// </summary>
        public string NovoRelatorio(string p_NomeModelo, string p_TextoModelo)
        {
            csRelatorio Relatorio = new csRelatorio();
            Relatorio.Nome = this.TestaNomeRelatorio(p_NomeModelo);
            if (Relatorio.Nome != p_NomeModelo)
            {
                DialogResult Resp = MessageBox.Show("Já existe um relatório com nome " + p_NomeModelo + " na lista\n" +
                                                    "Gostaria de salvar como\n" + Relatorio.Nome + " ?", "Inserir Relatorio", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Resp == DialogResult.No)
                {
                    return null;
                }
            }
            Relatorio.Texto = p_TextoModelo;
            _ListaRelatorios.Add(Relatorio);
            GC.Collect();
            return Relatorio.Nome;
        }

        /// <summary>
        /// Insere um relatório na lista de relatórios personalizados
        /// </summary>
        public string InserirRelatorio(string p_ArquivoModelo)
        {
            csRelatorio Relatorio = new csRelatorio();
            string NomeRelatorio = csUtil.ParteNomeArquivo(p_ArquivoModelo, csUtil.enuParteNomeArquivo.Nome);
            Relatorio.Nome = this.TestaNomeRelatorio(NomeRelatorio);
            if (Relatorio.Nome != NomeRelatorio)
            {
                DialogResult Resp = MessageBox.Show("Já existe um relatório com nome " + NomeRelatorio + " na lista\n" +
                                                    "Gostaria de salvar como\n" + Relatorio.Nome + " ?", "Inserir Relatorio", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Resp == DialogResult.No)
                {
                    return null;
                }
            }
            StreamReader Leitor = new StreamReader(p_ArquivoModelo, Encoding.Default);
            Relatorio.Texto = Leitor.ReadToEnd();
            _ListaRelatorios.Add(Relatorio);
            Leitor.Close();
            Leitor.Dispose();
            GC.Collect();
            return Relatorio.Nome;
        }

        /// <summary>
        /// Monta o relatório que lista todas as opções do CheckList
        /// </summary>
        public string TextoRelatorioTodasOpcoes()
        {
            string NomeFonte = "Arial";
            string _TextoRelatorio = "";
            _TextoRelatorio = "<font face=\"" + NomeFonte + "\"><br/>\n" + "<font size = 5><b>" + this.Nome + "<br/>\n" +
                            this.Descricao + "</b></font><br/>\n<br/>\n";
            csItem item = null;
            for (int i = 0; i < _Itens.Count; i++)
            {
                item = (csItem)_Itens[i];
                _TextoRelatorio = _TextoRelatorio + item.TextoRelatorioTodasOpcoes + "<br/>\n<br/>\n";
            }
            _TextoRelatorio = _TextoRelatorio + "</font><br/>";

            return _TextoRelatorio;
        }

        /// <summary>
        /// Retorna texto do relatório padrão
        /// </summary>
        public string TextoRelatorio()
        {
            string NomeFonte = "Arial";
            string _TextoRelatorio = "";
            _TextoRelatorio = "<font face=\"" + NomeFonte + "\"><br/>\n" + "<font size = 5><b>" + this.Nome + "<br/>\n" +
                            this.Descricao + "</b></font><br/>\n<br/>\n";
            csItem item = null;
            for (int i = 0; i < _Itens.Count; i++)
            {
                item = (csItem)_Itens[i];
                _TextoRelatorio = _TextoRelatorio + item.TextoRelatorio + "<br/>\n<br/>\n";
            }
            _TextoRelatorio = _TextoRelatorio + "</font><br/>";

            csDadosLog DoadosLog = null;

            if (_ListaLog.Count > 0)
            {
                _TextoRelatorio = _TextoRelatorio + "<font face=\"" + NomeFonte + "\"><br/>\n";
                _TextoRelatorio = _TextoRelatorio + "<b>Log de salvamento:</b><br/>";
                _TextoRelatorio = _TextoRelatorio + "<table border=\"1\">\r\n";
                _TextoRelatorio = _TextoRelatorio + "<tr><th><b>Data e Hora</b></th>";
                _TextoRelatorio = _TextoRelatorio + "<th><b>Nome da máquina</b></th>";
                _TextoRelatorio = _TextoRelatorio + "<th><b>Usuário</b></th>";
                _TextoRelatorio = _TextoRelatorio + "<th><b>Caminho completo</b></th></tr>\n";
            }

            for (int i = 0; i < _ListaLog.Count; i++)
            {
                DoadosLog = (csDadosLog)_ListaLog[i];
                _TextoRelatorio = _TextoRelatorio + "<tr><th>" + DoadosLog.DataHora.ToString("dd/MM/yy HH:mm") + "</th>";
                _TextoRelatorio = _TextoRelatorio + "<th>" + DoadosLog.NomeMaquina + "</th>";
                _TextoRelatorio = _TextoRelatorio + "<th>" + DoadosLog.UsuarioLogado + "</th>";
                _TextoRelatorio = _TextoRelatorio + "<th>" + DoadosLog.CaminhoCompletoArquivo + "</th></tr>\n";
            }

            if (_ListaLog.Count > 0)
            {
                _TextoRelatorio = _TextoRelatorio + "</table></font><br/><br/>";
            }

            ///////////////////////////

            csDadosComentario DoadosComentario = null;

            if (_ListaComentarios.Count > 0)
            {
                _TextoRelatorio = _TextoRelatorio + "<font face=\"" + NomeFonte + "\"><br/>\n";
                _TextoRelatorio = _TextoRelatorio + "<b>Comentários:</b><br/>";
                _TextoRelatorio = _TextoRelatorio + "<table border=\"1\">\r\n";
                _TextoRelatorio = _TextoRelatorio + "<tr><th><b>Data e Hora</b></th>";
                _TextoRelatorio = _TextoRelatorio + "<th><b>Nome da máquina</b></th>";
                _TextoRelatorio = _TextoRelatorio + "<th><b>Usuário</b></th>";
                _TextoRelatorio = _TextoRelatorio + "<th><b>Comentário</b></th></tr>\n";
            }

            for (int i = 0; i < _ListaComentarios.Count; i++)
            {
                DoadosComentario = (csDadosComentario)_ListaComentarios[i];
                _TextoRelatorio = _TextoRelatorio + "<tr><th>" + DoadosComentario.DataHora.ToString("dd/MM/yy HH:mm") + "</th>";
                _TextoRelatorio = _TextoRelatorio + "<th>" + DoadosComentario.NomeMaquina + "</th>";
                _TextoRelatorio = _TextoRelatorio + "<th>" + DoadosComentario.UsuarioLogado + "</th>";
                _TextoRelatorio = _TextoRelatorio + "<th>" + DoadosComentario.Comentario + "</th></tr>\n";
            }

            if (_ListaComentarios.Count > 0)
            {
                _TextoRelatorio = _TextoRelatorio + "</table></font>";
            }

            return _TextoRelatorio;
        }

        /// <summary>
        /// Retorna texto do relatório personalizado
        /// </summary>
        public string TextoRelatorio(string p_TextoModelo, bool p_Editando)
        {
            string NomeFonte = "Arial";
            string _TextoRelatorio = "";
            int _IniPosVariavel = -1;
            int _FimPosVariavel = -1;
            string _TextoVariavel = "";
            string _TextoPerguntaVariavel = "";
            string _TextoInformado = "";
            DialogResult _Resp = DialogResult.None;
            _TextoRelatorio = "<font face=\"" + NomeFonte + "\"><br/>\n";
            _TextoRelatorio = _TextoRelatorio + p_TextoModelo;
            csItem item = null;
            for (int i = 0; i < _Itens.Count; i++)
            {
                item = (csItem)_Itens[i];
                string _TextoSubstituir = "{" + item.Nome + "." + item.Descricao + "}";
                _TextoRelatorio = _TextoRelatorio.Replace(_TextoSubstituir, item.TextoRelatorioCurto);
            }
            if (!p_Editando)
            {
                _TextoRelatorio = _TextoRelatorio.Replace("{variavel=", "{VARIAVEL=");
                _TextoRelatorio = _TextoRelatorio.Replace("{Variavel=", "{VARIAVEL=");
                while (_TextoRelatorio.IndexOf("{VARIAVEL=") > -1)
                {
                    _IniPosVariavel = _TextoRelatorio.IndexOf("{VARIAVEL=");
                    _FimPosVariavel = _TextoRelatorio.IndexOf("}", _IniPosVariavel);
                    if (_FimPosVariavel == -1)
                    {
                        _TextoRelatorio = _TextoRelatorio.Substring(0, _IniPosVariavel - 1) + _TextoRelatorio.Substring(_IniPosVariavel + "{VARIAVEL=".Length);
                    }
                    else
                    {
                        _TextoVariavel = _TextoRelatorio.Substring(_IniPosVariavel, _FimPosVariavel - _IniPosVariavel + 1);
                        _TextoPerguntaVariavel = _TextoVariavel.Substring("{VARIAVEL=".Length);
                        _TextoPerguntaVariavel = _TextoPerguntaVariavel.Replace("}", "");
                        _TextoInformado = "";
                        _Resp = csUtil.InputBox("Variáveis Informadas Manualmente", _TextoPerguntaVariavel, ref _TextoInformado);
                        if (_Resp == DialogResult.OK)
                        {
                            _TextoRelatorio = _TextoRelatorio.Replace(_TextoVariavel, _TextoInformado);
                        }
                        else
                        {
                            _TextoRelatorio = _TextoRelatorio.Replace(_TextoVariavel, "");
                        }
                    }

                }
            }
            
            _TextoRelatorio = _TextoRelatorio + "</font><br/>";

            return _TextoRelatorio;
        }

        /// <summary>
        /// Monta o relatório padrão
        /// </summary>
        public void MostrarRelatorio()
        {
            string _TextoRelatorio = this.TextoRelatorio();
            string _NomeArquivo = this.SalvaArquivoRelatorio(_TextoRelatorio);
            System.Diagnostics.Process.Start(_NomeArquivo);

        }

        /// <summary>
        /// Monta o relatório que lista todas as opções do CheckList
        /// </summary>
        public void MostrarRelatorioTodasOpcoes()
        {
            string _TextoRelatorio = this.TextoRelatorioTodasOpcoes();
            string _NomeArquivo = this.SalvaArquivoRelatorio(_TextoRelatorio);
            System.Diagnostics.Process.Start(_NomeArquivo);
        }

        /// <summary>
        /// Monta relatório a partir do modelo
        /// </summary>
        /// <typeparam name="p_Modelo">Pode ser o nome do arquivo ou o texto do modelo</typeparam>
        public void MostrarRelatorio(string p_Modelo)
        {
            string _TextoArquivo = "";
            string _TextoRelatorio = "";
            if (File.Exists(p_Modelo))
            {
                try
                {
                    StreamReader Leitor = new StreamReader(p_Modelo, Encoding.Default);
                    _TextoArquivo = Leitor.ReadToEnd();
                    Leitor.Close();
                    Leitor.Dispose();
                    GC.Collect();
                    _TextoRelatorio = this.TextoRelatorio(_TextoArquivo, false);
                }
                catch (Exception _Exception)
                {
                    MessageBox.Show("Erro ao carregar o arquivo\n" + p_Modelo + "\n" + _Exception.ToString(), "Mostrar Relatorio", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                _TextoRelatorio = this.TextoRelatorio(p_Modelo, false);
            }

            string _NomeArquivo = this.SalvaArquivoRelatorio(_TextoRelatorio);
            System.Diagnostics.Process.Start(_NomeArquivo);

        }

        /// <summary>
        /// Desmembra os itens da lista em modelos com só um item
        /// </summary>
        /// <remarks>
        /// Isso permite reutilizar os itens de uma lista, para quando for montar uma nova, 
        /// vai adicionando os modelos com um só item.
        /// Retorna a quantidade de itens desmembrados.
        /// </remarks>
        public int Desmembrar(string p_Pasta)
        {
            int _ItensDesmembrados = 0;

            csListaItens ListaUnitaria = null;
            string _NomeArquivo = "";

            for (int i = 0; i < _Itens.Count; i++)
			{
			    GC.Collect();
                csItem item = (csItem)_Itens[i];
                ListaUnitaria = new csListaItens();
                ListaUnitaria.Add(item);
                if (p_Pasta.Substring(p_Pasta.Length -1) != "\\")
                {
                    p_Pasta = p_Pasta + "\\";
                }
                csUtil.SalvarPreferencia("Pasta padrao desmembrar", p_Pasta);
                _NomeArquivo = string.Format("{0:00}", i + 1) + "_" + item.NomeTipo + "_" + item.Nome + "_" + item.Descricao;
                _NomeArquivo = _NomeArquivo.Replace("\\", "_");
                _NomeArquivo = _NomeArquivo.Replace("/", "_");
                foreach (char Caractere in Path.GetInvalidFileNameChars())
                {
                    _NomeArquivo = _NomeArquivo.Replace(Caractere, '_');
                }

                foreach (char Caractere in Path.GetInvalidPathChars())
                {
                    _NomeArquivo = _NomeArquivo.Replace(Caractere, '_');
                }

                _NomeArquivo = p_Pasta + _NomeArquivo + ".chkl";
                ListaUnitaria.SalvarArquivo(_NomeArquivo);

                _ItensDesmembrados++;
			}

            return _ItensDesmembrados;
        }

        /// <summary>
        /// Escolhe uma pasta e chama a rotina que desmembra o modelo na pasta escolhida
        /// </summary>
        public string EscolherPastaEDesmembrar()
        {
            string _PastaEscolhida = "";

            if (_Itens.Count > 0)
            {
                _PastaEscolhida = this.EscolherPasta();
                if (_PastaEscolhida.Trim().Length > 0)
                {
                    int _ItensDesmembrados = this.Desmembrar(_PastaEscolhida);
                    if (_ItensDesmembrados > 0)
                    {
                        MessageBox.Show("Foram salvos " + _ItensDesmembrados.ToString() + " itens na pasta:\n" + _PastaEscolhida, "Desmembrar modelo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        MessageBox.Show("Nenhum item foi salvo", "Desmembrar modelo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            else
            {
                MessageBox.Show("Não há itens no modelo para desmembrar!", "Desmembrar modelo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return _PastaEscolhida;
        }

        /// <summary>
        /// Adiciona um modelo na lista já existente
        /// </summary>
        public bool AcoplouModelo()
        {
            bool _Retorno = false;
            string[] _NomeArquivos = this.EscolherArquivo(enuTipoCheckList.tclModelo, true);
            if (_NomeArquivos != null)
            {
                for (int i = 0; i < _NomeArquivos.Length; i++)
                {
                    this.AdicionarLista(_NomeArquivos[i]);
                    _Retorno = true;
                }
            }
            return _Retorno;
        }

        /// <summary>
        /// Adiciona um modelo na lista já existente
        /// </summary>
        public bool AcoplouModelo(string[] p_ListaArquivos)
        {
            bool _Retorno = false;
            if (p_ListaArquivos != null)
            {
                for (int i = 0; i < p_ListaArquivos.Length; i++)
                {
                    this.AdicionarLista(p_ListaArquivos[i]);
                    _Retorno = true;
                }
            }
            return _Retorno;
        }

        /// <summary>
        /// Adiciona uma lista já preenchida na lista já existente
        /// </summary>
        public bool AcoplouListaPreenchida()
        {
            bool _Retorno = false;
            string[] _NomeArquivos = this.EscolherArquivo(enuTipoCheckList.tclPreenchido, true);
            if (_NomeArquivos != null)
            {
                for (int i = 0; i < _NomeArquivos.Length; i++)
                {
                    this.AdicionarLista(_NomeArquivos[i]);
                    _Retorno = true;
                }
            }
            return _Retorno;
        }

        /// <summary>
        /// Acrescenta os itens de outra lista de Check Itens
        /// </summary>
        public void AdicionarLista(string p_CaminhoCompleto)
        {
            csListaItens ListaItensDeserializada = null;

            Stream stream = File.Open(p_CaminhoCompleto, FileMode.Open);
            BinaryFormatter bformatter = new BinaryFormatter();

            ListaItensDeserializada = (csListaItens)bformatter.Deserialize(stream);
            stream.Close();

            for (int i = 0; i < ListaItensDeserializada.Itens.Count; i++)
            {
                this._Itens.Add(ListaItensDeserializada.Itens[i]);
            }

            for (int i = 0; i < ListaItensDeserializada._ListaRelatorios.Count; i++)
            {
                this._ListaRelatorios.Add(ListaItensDeserializada._ListaRelatorios[i]);
            }
            
        }

        /// <summary>
        /// Dialog de abrir arquivo
        /// </summary>
        private string[] EscolherArquivo(enuTipoCheckList p_TipoCheckItem, bool p_MultiplaEscolha)
        {
            string[] _Retorno = null;
            string _Filtro = "";
            string _PastaPadrao = null;
            switch (p_TipoCheckItem)
            {
                case enuTipoCheckList.tcTodos:
                    _Filtro = "Modelo e Check List Preenchido(*.chkl; *.chklp)|*.chkl;*.chklp";
                    break;

                case enuTipoCheckList.tclModelo:
                    _Filtro = "Modelo de Check List (*.chkl)|*.chkl";
                    _PastaPadrao = (string)csUtil.CarregarPreferencia("Pasta padrao abrir modelo");
                    break;

                case enuTipoCheckList.tclPreenchido:
                    _Filtro = "Check List Preenchido (*.chklp)|*.chklp";
                    _PastaPadrao = (string)csUtil.CarregarPreferencia("Pasta padrao editar lista preenchida");
                    break;
            }
            DialogResult Resp;
            OpenFileDialog dlgAbrir = new OpenFileDialog();
            dlgAbrir.Title = "Escolha o arquivo";
            dlgAbrir.Filter = _Filtro;
            dlgAbrir.Multiselect = p_MultiplaEscolha;
            if (_PastaPadrao != null)
            {
                dlgAbrir.InitialDirectory = _PastaPadrao;
            }
            Resp = dlgAbrir.ShowDialog();
            if (Resp == System.Windows.Forms.DialogResult.OK)
            {
                _Retorno = dlgAbrir.FileNames;
            }

            return _Retorno;
        }


        /// <summary>
        /// Dialog para escolher uma pasta
        /// </summary>
        private string EscolherPasta()
        {
            string _PastaEscolhida = "";
            FolderBrowserDialog dlgCaminho = new FolderBrowserDialog();
            DialogResult Resp;
            string _PastaPadraoDesmembrar = (string)csUtil.CarregarPreferencia("Pasta padrao desmembrar");
            if (_PastaPadraoDesmembrar != null)
            {
                dlgCaminho.SelectedPath = _PastaPadraoDesmembrar;
            }
            Resp = dlgCaminho.ShowDialog();
            if (Resp == System.Windows.Forms.DialogResult.OK)
            {
                _PastaEscolhida = dlgCaminho.SelectedPath;
            }
            else
            {
                _PastaEscolhida = "";
            }

            return _PastaEscolhida;
        }

        /// <summary>
        /// Retorna o tipo do CheckItem de posição p_Indice
        /// </summary>
        public enuTipoCheckIten TipoCheckItem(int p_Indice)
        {
            object CheckItem = _Itens[p_Indice];
            Type Tipo = CheckItem.GetType();
            enuTipoCheckIten Retorno = enuTipoCheckIten.Indefinido;
            switch (Tipo.ToString())
            {
                case "Check_List.csItemArquivo":
                    Retorno = enuTipoCheckIten.Arquivo;
                    break;

                case "Check_List.csItemListaArquivos":
                    Retorno = enuTipoCheckIten.ListaDeArquivos;
                    break;

                case "Check_List.csItemListaOpcoes":
                    Retorno = enuTipoCheckIten.ListaDeOpcoes;
                    break;

                case "Check_List.csItemTexto":
                    Retorno = enuTipoCheckIten.Texto;
                    break;

                case "Check_List.csItemData":
                    Retorno = enuTipoCheckIten.Data;
                    break;
            }
            return Retorno;
        }

        /// <summary>
        /// Retorna o tipo do CheckItem p_CheckItem
        /// </summary>
        public enuTipoCheckIten TipoCheckItem(object p_CheckItem)
        {
            Type Tipo = p_CheckItem.GetType();
            enuTipoCheckIten Retorno = enuTipoCheckIten.Indefinido;
            switch (Tipo.ToString())
            {
                case "Check_List.csItemArquivo":
                    Retorno = enuTipoCheckIten.Arquivo;
                    break;

                case "Check_List.csItemListaArquivos":
                    Retorno = enuTipoCheckIten.ListaDeArquivos;
                    break;

                case "Check_List.csItemListaOpcoes":
                    Retorno = enuTipoCheckIten.ListaDeOpcoes;
                    break;

                case "Check_List.csItemTexto":
                    Retorno = enuTipoCheckIten.Texto;
                    break;

                case "Check_List.csItemData":
                    Retorno = enuTipoCheckIten.Data;
                    break;
            }
            return Retorno;
        }

        /// <summary>
        /// Função de Serialização.
        /// </summary>
        /// <remarks>Necessário para implementar a interface ISerializable</remarks>
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("csListaItens_Nome", _Nome);
            info.AddValue("csListaItens_Descricao", _Descricao);
            info.AddValue("csListaItens_Ajuda", _Ajuda);
            info.AddValue("csListaItens_Itens", _Itens);
            info.AddValue("csListaItens_SalvarLog", _SalvarLog);
            info.AddValue("csListaItens_AlertarAoReutilizarCheckList", _AlertarAoReutilizarCheckList);
            info.AddValue("csListaItens_ListaLog", _ListaLog);
            info.AddValue("csListaItens_ListaComentarios", _ListaComentarios);
            info.AddValue("csListaItens_ListaRelatorios", _ListaRelatorios);
        }

        /// <summary>
        /// Item da lista
        /// </summary>
        /// <returns>Retorna um item de Check List de posição Indice.</returns>
        public object Item(int Indice)
        {
            return _Itens[Indice];
        }

        /// <summary>
        /// Adiciona um item de Check List.
        /// </summary>
        /// <remarks>Devem ser adicionados somente objetos derivados de csItem ou listas de objetos derivados de csItem</remarks>
        public void Add(object Item)
        {
            _Itens.Add(Item);
        }

        /// <summary>
        /// Remove o item de Check List de posição Indice.
        /// </summary>
        public void Remove(int Indice)
        {
            _Itens.Remove(_Itens[Indice]);
            GC.Collect();
        }

        /// <summary>
        /// Limpa a lista de Check List.
        /// </summary>
        public void Clear()
        {
            while (_Itens.Count > 0)
                _Itens.Remove(_Itens[0]);
            GC.Collect();
        }

        /// <summary>
        /// Salva o arquivo no caminho indicado.
        /// </summary>
        /// <returns>Retorna Se foi salvo ou não.</returns>
        public bool SalvarArquivo(string p_CaminhoCompleto)
        {

            if (p_CaminhoCompleto.Length == 0)
            {
                MessageBox.Show("Informe o caminho do arquivo!", "Salvar Arquivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                bool HeUmModelo = (csUtil.ParteNomeArquivo(p_CaminhoCompleto, csUtil.enuParteNomeArquivo.Extencao).ToUpper() == "CHKL");
                if (HeUmModelo)
                {
                    _ListaLog.Clear();
                }
                else
                {
                    if (_SalvarLog)
                    {
                        csDadosLog DadosLog = new csDadosLog();
                        DadosLog.CaminhoCompletoArquivo = p_CaminhoCompleto;
                        _ListaLog.Add(DadosLog);
                    }
                }
                
                try
                {
                    _stream.Close();
                }
                catch (Exception)
                {

                }
                // Abre o arquivo para escrita
                _stream = File.Open(p_CaminhoCompleto, FileMode.Create, FileAccess.Write);
                
                BinaryFormatter BFormater = new BinaryFormatter();
                BFormater.Serialize(_stream, this);
                _stream.Close();
                if (!HeUmModelo)
                {
                    _stream = File.Open(p_CaminhoCompleto, FileMode.Open, FileAccess.ReadWrite, FileShare.Read);
                }
                return true;
            }

            catch (Exception _Exception)
            {
                // Erro
                MessageBox.Show("Erro ao salvar o arquivo: " + _Exception.ToString(), "Salvar Arquivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Mostra a dialog para escolher o destino do arquivo e chama a função SalvarArquivo.
        /// </summary>
        /// <returns>Retorna se foi salvo ou não e o caminho escolhido.</returns>
        public bool EscolherDestinoESalvar(ref string p_CaminhoEscolhido, enuTipoCheckList p_Tipo)
        {
            SaveFileDialog dlgSalvar = new SaveFileDialog();
            DialogResult Resp;
            bool Retorno = false;

            p_CaminhoEscolhido = "";
            dlgSalvar.FileName = this.Nome;

            switch (p_Tipo)
            {
                case enuTipoCheckList.tclModelo:
                    dlgSalvar.Title = "Escolha aonde salvar o modelo de Check List";
                    dlgSalvar.Filter = "Modelo de Check List (*.chkl)|*.chkl";
                    break;
                case enuTipoCheckList.tclPreenchido:
                    dlgSalvar.Title = "Escolha aonde salvar o Check List Preenchido";
                    dlgSalvar.Filter = "Check List Preenchido (*.chklp)|*.chklp";
                    break;
            }
            dlgSalvar.CheckPathExists = true;
            dlgSalvar.CheckFileExists = false;
            dlgSalvar.CreatePrompt = false;
            dlgSalvar.OverwritePrompt = true;
            dlgSalvar.ShowHelp = false;
            dlgSalvar.ValidateNames = true;
            Resp = dlgSalvar.ShowDialog();

            if (Resp == System.Windows.Forms.DialogResult.OK)
            {
                Retorno = this.SalvarArquivo(dlgSalvar.FileName);
                p_CaminhoEscolhido = dlgSalvar.FileName;
            }

            return Retorno;
        }

        /// <summary>
        /// Para saber se tem algum arquivo na lista
        /// </summary>
        /// <returns>Retorna TRUE se existe pelo menos um arquivo com tamanho maior que zero na lista.</returns>
        public bool TemArquivosNaLista()
        {
            csItemArquivo ItemArquivo = null;
            csItemListaArquivos ListaArquivos = null;

            // Varrendo a lista de Check Itens
            foreach (object itemCheckList in _Itens)
            {
                switch (this.TipoCheckItem(itemCheckList))
                {
                    // Se o tipo do item é csItemArquivo, verifica se o tamanho do arquivo é maior que zero
                    case enuTipoCheckIten.Arquivo:
                        ItemArquivo = (csItemArquivo)itemCheckList;
                        if (ItemArquivo.TamanhoArquivo > 0)
                        {
                            return true;
                        }
                        break;

                    // Se o tipo do item é csItemListaArquivos, verifica cada um dos arquivos da lista se tem um com tamanho maior que zero
                    case enuTipoCheckIten.ListaDeArquivos:
                        ListaArquivos = (csItemListaArquivos)itemCheckList;
                        foreach (csItemArquivo itemListaArquivos in ListaArquivos.ItensArquivo)
                        {
                            if (itemListaArquivos.TamanhoArquivo > 0)
                            {
                                return true;
                            }
                        }
                        break;

                    case enuTipoCheckIten.ListaDeOpcoes:
                        break;

                    case enuTipoCheckIten.Texto:
                        break;
                }
                
            }

            return false;
        }

        /// <summary>
        /// Salva todos os arquivos da lista em uma pasta especificada.
        /// </summary>
        /// <returns>Retorna a quantidade de arquivos salvos.</returns>
        public int SalvarTodosArquivos(string p_Caminho)
        {

            int QuantArquivosSalvos = 0;
            string p_CaminhoAuxiliar = "";

            if (!this.TemArquivosNaLista())
            {
                MessageBox.Show("Não existem arquivos na lista para salvar!", "Salvar Todos Arquivo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return QuantArquivosSalvos;
            }

            if (File.Exists(p_Caminho))
            {
                MessageBox.Show("Informe um caminho e não um arquivo!", "Salvar Todos Arquivo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return QuantArquivosSalvos;
            }

            if (!Directory.Exists(p_Caminho))
            {
                MessageBox.Show("O caminho informado não existe!", "Salvar Todos Arquivo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return QuantArquivosSalvos;
            }

            if (p_Caminho[p_Caminho.Length - 1].ToString() != "\\")
            {
                p_Caminho = p_Caminho + "\\";
            }

            char[] invalidPathChars = Path.GetInvalidPathChars();
            int _Cont = 0;
            // Varrendo a lista de Check Itens
            foreach (object itemCheckList in this._Itens)
            {
                _Cont++;
                switch (this.TipoCheckItem(itemCheckList))
                {
                    // Se o tipo do item é csItemArquivo, verifica se o tamanho do arquivo é maior que zero, se for, salva
                    case enuTipoCheckIten.Arquivo:
                        csItemArquivo ItemArquivo = (csItemArquivo)itemCheckList;
                        if (ItemArquivo.TamanhoArquivo > 0)
                        {
                            p_CaminhoAuxiliar = p_Caminho + _Cont.ToString("00") + "_" + ItemArquivo.Nome + "\\";
                            for (int i = 0; i < invalidPathChars.Length; i++)
                            {
                                p_CaminhoAuxiliar = p_CaminhoAuxiliar.Replace(invalidPathChars[i].ToString(), "_");
                            }
                            if (!Directory.Exists(p_CaminhoAuxiliar))
                            {
                                Directory.CreateDirectory(p_CaminhoAuxiliar);
                            }
                            ItemArquivo.SalvarArquivo(p_CaminhoAuxiliar + ItemArquivo.NomeArquivo);
                            QuantArquivosSalvos++;
                        }
                        break;

                    // Se o tipo do item é csItemListaArquivos, verifica cada um dos arquivos da lista se tem um com tamanho maior que zero, se for, salva
                    case enuTipoCheckIten.ListaDeArquivos:
                        csItemListaArquivos ListaArquivos = (csItemListaArquivos)itemCheckList;
                        foreach (csItemArquivo itemListaArquivos in ListaArquivos.ItensArquivo)
                        {
                            if (itemListaArquivos.TamanhoArquivo > 0)
                            {
                                p_CaminhoAuxiliar = p_Caminho + _Cont.ToString("00") + "_" + itemListaArquivos.Nome + "\\";
                                for (int i = 0; i < invalidPathChars.Length; i++)
                                {
                                    p_CaminhoAuxiliar = p_CaminhoAuxiliar.Replace(invalidPathChars[i].ToString(), "_");
                                }
                                if (!Directory.Exists(p_CaminhoAuxiliar))
                                {
                                    Directory.CreateDirectory(p_CaminhoAuxiliar);
                                }
                                itemListaArquivos.SalvarArquivo(p_CaminhoAuxiliar + itemListaArquivos.NomeArquivo);
                                QuantArquivosSalvos++;
                            }
                        }
                        break;
                }

            }

            return QuantArquivosSalvos;
        }

        /// <summary>
        /// Mostra a dialog para escolher o caminho e chama a função SalvarTodosArquivos.
        /// </summary>
        /// <returns>Retorna a quantidade de arquivos salvos e o caminho que foi escolhido.</returns>
        public int EscolherCaminhoESalvarArquivos(ref string PastaEscolhida)
        {
            FolderBrowserDialog dlgCaminho = new FolderBrowserDialog();
            DialogResult Resp;
            //PastaEscolhida = "";

            if (!this.TemArquivosNaLista())
            {
                MessageBox.Show("Não existem arquivos na lista para salvar!", "Salvar Todos Arquivo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }
            //string _PastaPadraoSalvar = (string)csUtil.CarregarPreferencia("Pasta padrao salvar arquivos");
            //if (_PastaPadraoSalvar != null)
            //{
            //    dlgCaminho.SelectedPath = _PastaPadraoSalvar;
            //}
            if (PastaEscolhida.Length > 0)
	        {
                dlgCaminho.SelectedPath = PastaEscolhida;
	        }
            Resp = dlgCaminho.ShowDialog();
            if (Resp == System.Windows.Forms.DialogResult.OK)
            {
                PastaEscolhida = dlgCaminho.SelectedPath;
                //csUtil.SalvarPreferencia("Pasta padrao salvar arquivos", PastaEscolhida);

                //if (NomeArquivoCheckList.Trim().Length > 0)
                //{
                //    if (PastaEscolhida[PastaEscolhida.Length - 1].ToString() != "\\")
                //    {
                //        PastaEscolhida = PastaEscolhida + "\\";
                //    }
                //    PastaEscolhida = PastaEscolhida + csUtil.ParteNomeArquivo(NomeArquivoCheckList, csUtil.enuParteNomeArquivo.Nome);
                //}

                char[] invalidPathChars = Path.GetInvalidPathChars();
                for (int i = 0; i < invalidPathChars.Length; i++)
                {
                    PastaEscolhida = PastaEscolhida.Replace(invalidPathChars[i].ToString(), "_");
                }

                if (!Directory.Exists(PastaEscolhida))
                {
                    Directory.CreateDirectory(PastaEscolhida);
                }

                return this.SalvarTodosArquivos(PastaEscolhida);
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Limpa o conteúdo de todos os itens caso estejam preenchidos.
        /// </summary>
        public void LimparConteudo()
        {
            // Varrendo a lista de Check Itens
            foreach (csItem itemCheckList in this._Itens)
            {
                itemCheckList.LimparConteudo();
            }
        }

        /// <summary>
        /// Retira um modelo na lista já existente
        /// </summary>
        public bool DesacoplouModelo()
        {
            bool _Retorno = false;
            string[] _NomeArquivos = this.EscolherArquivo(enuTipoCheckList.tclModelo, true);
            if (_NomeArquivos != null)
            {
                for (int i = 0; i < _NomeArquivos.Length; i++)
                {
                    this.ExcluirLista(_NomeArquivos[i]);
                    _Retorno = true;
                }
            }
            return _Retorno;
        }

        /// <summary>
        /// Escolhe um arquivo e salva a lista de itens em uma tabela formato HTML
        /// </summary>
        /// <remarks>
        /// Retorna TRUE se salvou ou FALSE se não salvou.
        /// </remarks>
        public bool EscolherArquivoESalvarListaItensHTML()
        {
            bool _SalvouArquivo = false;
            if (_Itens.Count > 0)
            {
                SaveFileDialog dlgSalvar = new SaveFileDialog();
                DialogResult Resp;
                dlgSalvar.Title = "Escolha o arquivo para salvar a listagem";
                dlgSalvar.Filter = "Check List Preenchido (*.html)|*.html";
                if (this.Nome.Trim().Length > 0)
                {
                    dlgSalvar.FileName = this.Nome + "_Listagem.html";
                }
                else
                {
                    dlgSalvar.FileName = "Listagem.html";
                }
                Resp = dlgSalvar.ShowDialog();
                if (Resp == System.Windows.Forms.DialogResult.OK)
                {
                    _SalvouArquivo = this.SalvarListaItensHTML(dlgSalvar.FileName);
                }
            }
            else
            {
                MessageBox.Show("Não há itens no modelo para gerar a lista!", "Listar Itens", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return _SalvouArquivo;
        }

        /// <summary>
        /// Salva a lista de itens em uma tabela formato html
        /// </summary>
        /// <remarks>
        /// Retorna TRUE se salvou ou FALSE se não salvou.
        /// </remarks>
        public bool SalvarListaItensHTML(string p_CaminhoCompletoArquivo)
        {
            bool _SalvouArquivo = false;

            if (_Itens.Count > 0)
            {
                try
                {
                    string _Texto = "<table border=\"1\">\n";
                    _Texto = _Texto + "<caption><th>Tipo</th><th>Nome</th><th>Descrição</th><th>Ajuda</th><th>Detalhe</th></caption>\n";
                    for (int i = 0; i < _Itens.Count; i++)
                    {
                        GC.Collect();
                        csItem item = (csItem)_Itens[i];
                        _Texto = _Texto + "<tr><th align=\"left\">" + item.NomeTipo + "</th><th align=\"left\">" + item.Nome + "</th><th align=\"left\">" + item.Descricao + "</th><th align=\"left\">" + item.Ajuda + "</th><th align=\"left\">" + item.TextoDetalhe + "</th></tr>\n";
                    }
                    _Texto = _Texto + "</table>";

                    File.WriteAllText(p_CaminhoCompletoArquivo, _Texto, Encoding.Default);
                    _SalvouArquivo = true;

                }
                catch (Exception _Exception)
                {
                    MessageBox.Show("Erro ao salvar o arquivo\n" + p_CaminhoCompletoArquivo + "\n" + _Exception.ToString(), "Salvar Lista de Itens", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Não há itens no modelo para gerar a lista!", "Listar Itens", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return _SalvouArquivo;
        }

    #endregion

    #region Métodos Privados


        /// <summary>
        /// Verifica se já tem um relatório com o nome p_NomeRelatorio e se tiver, retorna sugestão de nome.
        /// </summary>
        private string TestaNomeRelatorio(string p_NomeRelatorio)
        {
            string Retorno = "";
            Retorno = p_NomeRelatorio;

            if (this.JaTemRelatorio(Retorno))
            {
                int Cont = 1;
                Retorno = p_NomeRelatorio + " " + Cont.ToString();
                while (this.JaTemRelatorio(Retorno))
                {
                    Cont++;
                    Retorno = p_NomeRelatorio + " " + Cont.ToString();
                }

            }

            return Retorno;
        }

        /// <summary>
        /// Retorna se um relatório já existe na lista de relatórios personalizados
        /// </summary>
        private bool JaTemRelatorio(string p_Nome)
        {
            foreach (csRelatorio RelatorioExistente in _ListaRelatorios)
            {
                if (RelatorioExistente.Nome == p_Nome)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Salva um relatório em um arquivo .chklr
        /// </summary>
        private string SalvaArquivoRelatorio(string p_Texto)
        {
            string _NomeArquivo = Path.GetTempPath() + "RelatorioCheckListWizard.htm";
            StreamWriter Escritor = new StreamWriter(_NomeArquivo, false, Encoding.Default);
            Escritor.Write(p_Texto);
            Escritor.Close();
            Escritor.Dispose();
            GC.Collect();
            return _NomeArquivo;
        }

        /// <summary>
        /// Exclui os itens de outra lista de Check Itens
        /// </summary>
        private void ExcluirLista(string p_CaminhoCompleto)
        {
            csListaItens ListaItensDeserializada = null;

            Stream stream = File.Open(p_CaminhoCompleto, FileMode.Open);
            BinaryFormatter bformatter = new BinaryFormatter();

            ListaItensDeserializada = (csListaItens)bformatter.Deserialize(stream);
            stream.Close();

            foreach (csItem item in ListaItensDeserializada.Itens)
            {
                bool encontrou = false;
                foreach (csItem item1 in _Itens)
                {
                    if (item.Nome == item1.Nome)
                    {
                        this._Itens.Remove(item1);
                        GC.Collect();
                        encontrou = true;
                    }
                    if (encontrou) break;
                }
            }

            foreach (csRelatorio relatorio in ListaItensDeserializada._ListaRelatorios)
            {
                bool encontrou = false;
                foreach (csRelatorio relatorio1 in _ListaRelatorios)
                {
                    if (relatorio.Nome == relatorio1.Nome)
                    {
                        this._ListaRelatorios.Remove(relatorio1);
                        GC.Collect();
                        encontrou = true;
                    }
                    if (encontrou) break;
                }
            }
        }

    #endregion
    }
}
