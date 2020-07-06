using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace Check_List
{
    public partial class frmSelecionarModulo : Form
    {
        public frmSelecionarModulo()
        {
            InitializeComponent();
        }

        private void llblEditorModelos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string _Parametro = "Editor_Modelos";
            Process Processo = new Process();
            Processo.StartInfo.FileName = Application.ExecutablePath;
            Processo.StartInfo.Arguments = @"""" + _Parametro + @"""";
            Processo.Start();
        }

        private void llblEditorRelatorio_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string _Parametro = "Editor_Relatorio";
            Process Processo = new Process();
            Processo.StartInfo.FileName = Application.ExecutablePath;
            Processo.StartInfo.Arguments = @"""" + _Parametro + @"""";
            Processo.Start();
        }

        private void llblAbrirCheckList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string _Filtro = "Modelo e Check List Preenchido(*.chkl; *.chklp)|*.chkl;*.chklp";
            DialogResult Resp;
            OpenFileDialog dlgAbrir = new OpenFileDialog();
            dlgAbrir.Title = "Escolha o arquivo";
            dlgAbrir.Filter = _Filtro;
            dlgAbrir.Multiselect = false;
            Resp = dlgAbrir.ShowDialog();
            if (Resp == System.Windows.Forms.DialogResult.OK)
            {
                string _Parametro = dlgAbrir.FileNames[0];
                Process Processo = new Process();
                Processo.StartInfo.FileName = Application.ExecutablePath;
                Processo.StartInfo.Arguments = @"""" + _Parametro + @"""";
                Processo.Start();
            }
        }
    }
}
