using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;
using System.Configuration;

namespace Check_List
{
    /// <summary>
    /// Classe que implementa uma lista de filtros de arquivos pra facilitar na hora de preencher a propriedade Filter das Dialogs.
    /// </summary>
    /// <remarks>
    /// Autor: Filipe Kanitz
    /// Data: 07/09/2011
    /// </remarks>
    [Serializable]
    class csFiltrosArquivos
    {
        #region Campos Privados
            private ArrayList _ListaFiltros = new ArrayList();
        #endregion

        #region Propriedades
            /// <summary>
            /// Retorna o ArrayList com os filtros adicionados.
            /// </summary>
            public static ArrayList ListaDeFiltrosPadrao
            {
                get
                {
                    ArrayList _ListaDeFiltrosPadrao = new ArrayList();
                    try
                    {
                        AppSettingsReader AppConfig = new AppSettingsReader();
                        csFiltroArquivo _FiltroArquivo;
                        string[] FiltrosPadrao = AppConfig.GetValue("ListaDeFiltrosPadrao", typeof(string)).ToString().Split(new Char[] { '\n' });
                        for (int i = 0; i < FiltrosPadrao.Length; i++)
                        {
                            FiltrosPadrao[i] = FiltrosPadrao[i].Trim();
                            _FiltroArquivo = new csFiltroArquivo();
                            string[] Partes = FiltrosPadrao[i].Split(new Char[] { '|' });
                            _FiltroArquivo.Descricao = Partes[0];
                            _FiltroArquivo.Tipos = Partes[1];
                            _ListaDeFiltrosPadrao.Add(_FiltroArquivo);
                        }
                    }
                    catch (Exception _Exception)
                    {
                        MessageBox.Show("Erro ao carregar Filtros Padrão\n" + _Exception.ToString(), "ListaDeFiltrosPadrao", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return _ListaDeFiltrosPadrao;
                    }

                    return _ListaDeFiltrosPadrao;
                }
            }

            /// <summary>
            /// Retorna o ArrayList com os filtros adicionados.
            /// </summary>
            public ArrayList ListaFiltros
            {
                get
                {
                    return _ListaFiltros;
                }
            }

            /// <summary>
            /// Retorna a quantidade de filtros da lista.
            /// </summary>
            public int Count
            {
                get
                {
                    return _ListaFiltros.Count;
                }
            }

            /// <summary>
            /// Retorna a lista de filtros já formatada para atribuir à propriedade Filter de uma Dialog.
            /// </summary>
            public string Filtros
            {
                get
                {
                    if (this.Count == 0)
                    {
                        csFiltroArquivo FiltroPadrao = new csFiltroArquivo();
                        this.Add(FiltroPadrao);
                    }
                    string TodosFiltros = "";
                    for (int i = 0; i < this.Count; i++)
                    {
                        if (TodosFiltros.Length > 0)
                        {
                            TodosFiltros = TodosFiltros + "|";
                        }
                        TodosFiltros = TodosFiltros + this.Item(i).Filtro;
                    }

                    return TodosFiltros;
                }
            }
        #endregion

        #region Métodos
            /// <summary>
            /// Retorna um csFiltroArquivo de posição Indice.
            /// </summary>
            public csFiltroArquivo Item(int Indice)
            {
                return (csFiltroArquivo)_ListaFiltros[Indice];
            }

            /// <summary>
            /// Adiciona um csFiltroArquivo já preenchido.
            /// </summary>
            public csFiltroArquivo Add(csFiltroArquivo Item)
            {
                _ListaFiltros.Add(Item);
                return Item;
            }

            /// <summary>
            /// Cria um csFiltroArquivo com os parâmetros e adiciona.
            /// </summary>
            public csFiltroArquivo Add(string p_Descricao, string p_Tipos)
            {
                csFiltroArquivo Item = new csFiltroArquivo();
                Item.Descricao = p_Descricao;
                Item.Tipos = p_Tipos;
                _ListaFiltros.Add(Item);
                return Item;
            }

            /// <summary>
            /// Remove o csFiltroArquivo de posição Indice.
            /// </summary>
            public void Remove(int Indice)
            {
                _ListaFiltros.Remove(_ListaFiltros[Indice]);
                GC.Collect();
            }

            /// <summary>
            /// Limpa a lista de filtros.
            /// </summary>
            public void Clear()
            {
                while (_ListaFiltros.Count > 0)
                    _ListaFiltros.Remove(_ListaFiltros[0]);
                GC.Collect();
            }
        #endregion
        
    }
}
