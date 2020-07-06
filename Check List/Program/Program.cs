using System;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Security.AccessControl;
using System.IO;

namespace Check_List
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //bool Associando = false;
            
            //try
            //{
            //    if (!csUtil.EstaAssociada(".chkl"))
            //    {
            //        csUtil.Associar(".chkl", "Check List Wizard", "Modelo de Check List", null, Application.ExecutablePath);
            //        Associando = true;
            //    }
            //}
            //catch (Exception)
            //{
                
            //}

            //try
            //{
            //    if (!csUtil.EstaAssociada(".chklp"))
            //    {
            //        csUtil.Associar(".chklp", "Check List Wizard", "Check List Preenchido", null, Application.ExecutablePath);
            //        Associando = true;
            //    }
            //}
            //catch (Exception)
            //{
                
            //}

            //try
            //{
            //    if (!csUtil.EstaAssociada(".chklr"))
            //    {
            //        csUtil.Associar(".chklr", "Check List Wizard", "Relatório de Check List", null, Application.ExecutablePath);
            //    }
            //}
            //catch (Exception)
            //{

            //}

            //if (Associando)
            //{
            //    MessageBox.Show("Associação dos arquivos concluída!", "Check List Wizard", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    GC.Collect();
            //    return;
            //}

            if (args.Length > 0)
            {
                string _LihaDeComando = args[0].Trim();
                if (File.Exists(_LihaDeComando))
                {
                    string Extencao = csUtil.ParteNomeArquivo(_LihaDeComando, csUtil.enuParteNomeArquivo.Extencao);
                    switch (Extencao.ToUpper())
                    {
                        case "CHKL": // Lista de Modelo
                            if (args.Length > 1)
                            {
                                if (args[1].Trim().ToUpper() == "EDITAR")
                                {
                                    try
                                    {
                                        Application.Run(new frmEditaModeloCheckList(_LihaDeComando));
                                    }
                                    catch (Exception)
                                    {

                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        Application.Run(new frmPreencheChekList(_LihaDeComando));
                                    }
                                    catch (Exception)
                                    {

                                    }
                                }
                            }
                            else
                            {
                                try
                                {
                                    Application.Run(new frmPreencheChekList(_LihaDeComando));
                                }
                                catch (Exception)
                                {

                                }
                            }
                            break;

                        case "CHKLP": // Lista preenchida
                            if (args.Length > 1)
                            {
                                if (args[1].Trim().ToUpper() == "EDITAR")
                                {
                                    try
                                    {
                                        Application.Run(new frmEditaModeloCheckList(_LihaDeComando));
                                    }
                                    catch (Exception)
                                    {

                                    }
                                }
                                else
                                {
                                    try
                                    {
                                        Application.Run(new frmPreencheChekList(_LihaDeComando));
                                    }
                                    catch (Exception)
                                    {

                                    }
                                }
                            }
                            else
                            {
                                try
                                {
                                    Application.Run(new frmPreencheChekList(_LihaDeComando));
                                }
                                catch (Exception)
                                {

                                }
                            }
                            break;

                        case "CHKLR": // Lista preenchida
                            //Application.Run(new frmPreencheChekList(_LihaDeComando));
                            break;

                        default:
                            MessageBox.Show("Arquivo inconpatível!\n" + _LihaDeComando, "Check List", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            break;
                    }
                }
                else
                {
                    switch (_LihaDeComando)
                    {
                        case "Editor_Modelos":
                            Application.Run(new frmEditaModeloCheckList());
                            break;
                        default:
                            MessageBox.Show("Parâmetro desconhecido!\n" + _LihaDeComando, "Check List", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            break;
                    }
                }
            }
            else
            {
                Application.Run(new frmSelecionarModulo());
            }
            GC.Collect();
        }

    }
}
