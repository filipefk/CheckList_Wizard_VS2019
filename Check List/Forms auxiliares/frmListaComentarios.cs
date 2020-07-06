using System;
using System.Windows.Forms;
using System.Collections;

namespace Check_List
{
    public partial class frmListaComentarios : Form
    {

    #region Campos Privados

        private ArrayList _ListaComentarios = null;
        private bool _AlterouAlgo = false;

    #endregion

    #region Propriedades Públicas
        /// <summary>
        /// Se Alterou alguma coisa nos comentários
        /// </summary>
        public bool AlterouAlgo
        {
            get
            {
                return _AlterouAlgo;
            }
        }

    #endregion
    
    #region Construtores

        public frmListaComentarios(ArrayList p_ListaComentarios)
        {
            InitializeComponent();
            _ListaComentarios = p_ListaComentarios;

            this.AtualizaLista();
            
            this.ShowDialog();
        }

    #endregion

    #region Métodos Privados

        /// <summary>
        /// Atualiza a lista de comentários
        /// </summary>
        private void AtualizaLista()
        {
            ListViewItem lvwItem;
            lvwListaComentarios.Items.Clear();
            foreach (csDadosComentario DadosComentario in _ListaComentarios)
            {
                lvwItem = lvwListaComentarios.Items.Add(DadosComentario.Comentario);
                lvwItem.SubItems.Add(DadosComentario.DataHora.ToShortDateString() + " " + DadosComentario.DataHora.ToLongTimeString());
                lvwItem.SubItems.Add(DadosComentario.NomeMaquina);
                string ListaDeIPs = "";
                for (int i = 0; i < DadosComentario.ListaIPs.Length; i++)
                {
                    if (DadosComentario.ListaIPs[i].ToString().Substring(0, 1) != ":")
                    {
                        if (ListaDeIPs.Length > 0)
                        {
                            ListaDeIPs = ListaDeIPs + ", ";
                        }
                        ListaDeIPs = ListaDeIPs + DadosComentario.ListaIPs[i];
                    }
                }
                lvwItem.SubItems.Add(ListaDeIPs);
                lvwItem.SubItems.Add(DadosComentario.UsuarioLogado);
            }
        }

        /// <summary>
        /// Adiciona um novo comentário.
        /// </summary>
        private void AdicionarComentario()
        {
            string _Comentario = "";
            DialogResult _Resultado;
            _Resultado = csUtil.InputBox("Novo Comentário", "Informe o novo comentário", ref _Comentario);
            if ((_Resultado == DialogResult.OK) && (_Comentario.Trim().Length > 0))
            {
                csDadosComentario DadosComentario = new csDadosComentario();
                DadosComentario.Comentario = _Comentario;
                _ListaComentarios.Add(DadosComentario);
                _AlterouAlgo = true;
                this.AtualizaLista();
            }
            
        }

        /// <summary>
        /// Remove um comentário de posição Indice.
        /// </summary>
        private void RemoverComentario(int Indice)
        {
            _ListaComentarios.Remove(_ListaComentarios[Indice]);
            GC.Collect();
        }

        /// <summary>
        /// Limpa a lista de comentários.
        /// </summary>
        private void LimparComentarios()
        {
            while (_ListaComentarios.Count > 0)
                _ListaComentarios.Remove(_ListaComentarios[0]);
            GC.Collect();
        }

    #endregion

        private void btNovo_Click(object sender, EventArgs e)
        {
            this.AdicionarComentario();
        }
    }
}
