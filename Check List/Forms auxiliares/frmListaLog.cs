using System;
using System.Windows.Forms;
using System.Collections;

namespace Check_List
{
    public partial class frmListaLog : Form
    {
        
    #region Construtores
        public frmListaLog(ArrayList p_ListaLog)
        {
            InitializeComponent();
            ListViewItem lvwItem;
            lvwListaLog.Items.Clear();
            foreach (csDadosLog DadosLog in p_ListaLog)
            {
                lvwItem = lvwListaLog.Items.Add(DadosLog.DataHora.ToShortDateString() + " " + DadosLog.DataHora.ToLongTimeString());
                lvwItem.SubItems.Add(DadosLog.NomeMaquina);
                string ListaDeIPs = "";
                for (int i = 0; i < DadosLog.ListaIPs.Length; i++)
                {
                    if (DadosLog.ListaIPs[i].ToString().Substring(0, 1) != ":")
                    {
                        if (ListaDeIPs.Length > 0)
                        {
                            ListaDeIPs = ListaDeIPs + ", ";
                        }
                        ListaDeIPs = ListaDeIPs + DadosLog.ListaIPs[i];
                    }
                }
                lvwItem.SubItems.Add(ListaDeIPs);
                lvwItem.SubItems.Add(DadosLog.UsuarioLogado);
                lvwItem.SubItems.Add(DadosLog.CaminhoCompletoArquivo);
            }
            //this.TopMost = true;
            this.ShowDialog();
        }

    #endregion


    }
}
