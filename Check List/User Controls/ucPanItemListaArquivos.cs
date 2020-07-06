using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Collections;

namespace Check_List
{
    public delegate void AlterouAlgoItemListaArquivosEventHandler(ucPanItemListaArquivos sender, EventArgs e);

    public partial class ucPanItemListaArquivos : UserControl
    {
        ToolTip _ToolTipText = new ToolTip();

        public event AlterouAlgoItemListaArquivosEventHandler AlterouAlgo;

        private ArrayList ProcessosAbertos = new ArrayList();

        protected virtual void OnAlterouAlgo(EventArgs e)
        {
            if (AlterouAlgo != null)
                AlterouAlgo(this, e);
        }

        private csItemListaArquivos _ItemListaArquivos = null;

        public ucPanItemListaArquivos()
        {
            InitializeComponent();
        }

        public virtual object RetornaCheckItem()
        {
            return _ItemListaArquivos;
        }

        public virtual void SetaCheckItem(object p_ItemListaArquivos)
        {
            _ItemListaArquivos = (csItemListaArquivos)p_ItemListaArquivos;
            this.Atualizar();
        }

        public virtual void Atualizar()
        {
            lvwItemListaArquivos.Items.Clear();
            if (_ItemListaArquivos != null)
            {
                lvwItemListaArquivos.Items.Clear();
                ListViewItem lvwItem = null;
                csItemArquivo ItemArquivoDaLista = null;
                string NomeArquivo = "";
                string ExtencaoArquivo = "";
                float TamanhoKB = 0;
                for (int i = 0; i < _ItemListaArquivos.Count; i++)
                {
                    ItemArquivoDaLista = (csItemArquivo)_ItemListaArquivos.ItensArquivo[i];
                    NomeArquivo = csUtil.ParteNomeArquivo(ItemArquivoDaLista.CaminhoCompletoOrigem, csUtil.enuParteNomeArquivo.Nome);
                    ExtencaoArquivo = csUtil.ParteNomeArquivo(ItemArquivoDaLista.CaminhoCompletoOrigem, csUtil.enuParteNomeArquivo.Extencao);
                    TamanhoKB = (ItemArquivoDaLista.TamanhoArquivo / 1024);
                    
                    lvwItem = lvwItemListaArquivos.Items.Add(NomeArquivo);
                    lvwItem.SubItems.Add(ExtencaoArquivo);
                    lvwItem.SubItems.Add(string.Format("{0:#,0.00}", TamanhoKB));
                    if (ItemArquivoDaLista.DataCriacao.ToString("dd/MM/yyyy") == "01/01/0001")
                    {
                        lvwItem.SubItems.Add("");
                    }
                    else
                    {
                        lvwItem.SubItems.Add(ItemArquivoDaLista.DataCriacao.ToString("dd/MM/yy HH:mm:ss"));
                    }
                    if (ItemArquivoDaLista.DataUltimaAlteracao.ToString("dd/MM/yyyy") == "01/01/0001")
                    {
                        lvwItem.SubItems.Add("");
                    }
                    else
                    {
                        lvwItem.SubItems.Add(ItemArquivoDaLista.DataUltimaAlteracao.ToString("dd/MM/yy HH:mm:ss"));
                    }
                    if (ItemArquivoDaLista.DataInclusao.ToString("dd/MM/yyyy") == "01/01/0001")
                    {
                        lvwItem.SubItems.Add("");
                    }
                    else
                    {
                        lvwItem.SubItems.Add(ItemArquivoDaLista.DataInclusao.ToString("dd/MM/yy HH:mm:ss"));
                    }
                    lvwItem.SubItems.Add(ItemArquivoDaLista.UsuarioIncluiu);
                    lvwItem.SubItems.Add(ItemArquivoDaLista.CaminhoCompletoOrigem);
                    
                }
            }
            
        }

        private void SalvarArquivoSelecionado()
        {
            if (lvwItemListaArquivos.SelectedItems.Count == 0)
            {
                if (lvwItemListaArquivos.Items.Count > 0)
                {
                    MessageBox.Show("Selecione um arquivo para salvar!", "Salvar arquivo selecionado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("Nenhum arquivo na lista para salvar!", "Salvar arquivo selecionado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                csItemArquivo ItemArquivo = (csItemArquivo)_ItemListaArquivos.ItensArquivo[lvwItemListaArquivos.SelectedIndices[0]];
                ItemArquivo.EscolherDestinoESalvar();
            }
        }

        private void SalvarTodosArquivos()
        {
            if (_ItemListaArquivos.ItensArquivo.Count > 0)
            {
                string PastaEscolhida = "";
                int QuantArquivosSalvos = _ItemListaArquivos.EscolherCaminhoESalvarArquivos(ref PastaEscolhida);
                if (QuantArquivosSalvos > 0)
                {
                    MessageBox.Show(string.Format("{0} Arquivos salvos na pasta {1}", QuantArquivosSalvos, PastaEscolhida), "Salvar Todos Arquivos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Nenhum arquivo na lista para salvar!", "Salvar Todos Arquivos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        private void AbrirArquivo()
        {
            if (_ItemListaArquivos.EscolherArquivoECarregar())
            {
                this.Atualizar();
                this.OnAlterouAlgo(new EventArgs());
            }
        }

        private void ExcluirArquivoSelecionado()
        {
            if (lvwItemListaArquivos.SelectedItems.Count > 0)
            {
                int[] _Indices = new int[lvwItemListaArquivos.SelectedItems.Count];
                for (int i = 0; i < lvwItemListaArquivos.SelectedItems.Count; i++)
                {
                    _Indices[i] = lvwItemListaArquivos.SelectedIndices[i];
                }
                _ItemListaArquivos.Remove(_Indices);
                this.Atualizar();
                this.OnAlterouAlgo(new EventArgs());
                GC.Collect();
            }
        }

        private void ExcluirArquivo(int pIndice)
        {
            _ItemListaArquivos.Remove(pIndice);
            this.Atualizar();
            this.OnAlterouAlgo(new EventArgs());
            GC.Collect();
        }
        

        private void ucPanItemListaArquivos_Resize(object sender, EventArgs e)
        {
            this.Size = new Size(601, 196);
        }

        private void btAbrirArquivo_Click(object sender, EventArgs e)
        {
            this.AbrirArquivo();            
        }

        private void btSalvarArquivoSelecionado_Click(object sender, EventArgs e)
        {
            this.SalvarArquivoSelecionado();
        }

        private void btSalvarTodosArquivos_Click(object sender, EventArgs e)
        {
            this.SalvarTodosArquivos();
        }

        private void lvwItemListaArquivos_KeyDown(object sender, KeyEventArgs e)
        {
            // Se a tecla pressionada foi o "delete", remove os arquivos selecionados
            if (e.KeyCode == Keys.Delete)
            {
                if (lvwItemListaArquivos.SelectedItems.Count > 0)
                {
                    DialogResult Resp;
                    Resp = MessageBox.Show("Excluir o arquivo selecionado?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (Resp == DialogResult.Yes)
                    {
                        this.ExcluirArquivoSelecionado();
                    }
                }
            }
            else
            {
                // Se pressionou CTLR + C, copia as informações do ListView para a área de transferência
                if (e.KeyCode == Keys.C)
                {
                    if (e.Control)
                    {
                        if (lvwItemListaArquivos.SelectedItems.Count > 0)
                        {
                            string _ClipBoard = "";
                            ListViewItem lvwItem = null;
                            for (int i = 0; i < lvwItemListaArquivos.Columns.Count; i++)
                            {
                                _ClipBoard = _ClipBoard + lvwItemListaArquivos.Columns[i].Text + "\t";
                            }
                            _ClipBoard = _ClipBoard + "\r\n";

                            for (int i = 0; i < lvwItemListaArquivos.SelectedItems.Count; i++)
                            {
                                lvwItem = lvwItemListaArquivos.Items[lvwItemListaArquivos.SelectedIndices[i]];
                                for (int j = 0; j < lvwItem.SubItems.Count; j++)
                                {
                                    _ClipBoard = _ClipBoard + lvwItem.SubItems[j].Text + "\t";
                                }
                                _ClipBoard = _ClipBoard + "\r\n";
                            }
                            Clipboard.SetText(_ClipBoard);
                        }
                    }
                }
            }
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            if (lvwItemListaArquivos.SelectedItems.Count > 0)
            {
                DialogResult Resp;
                Resp = MessageBox.Show("Excluir o(s) arquivo(s) selecionado(s)?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Resp == DialogResult.Yes)
                {
                    //this.ExcluirArquivo(lvwItemListaArquivos.SelectedIndices[0]);
                    this.ExcluirArquivoSelecionado();
                }
            }
            else
            {
                if (lvwItemListaArquivos.Items.Count == 0)
                {
                    MessageBox.Show("Nenhum arquivo na lista para excluir!", "Excluir Arquivo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("Selecione um dos arquivos da lista para excluir!", "Excluir Arquivo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            
        }

        private void lvwItemListaArquivos_DoubleClick(object sender, EventArgs e)
        {
            if (lvwItemListaArquivos.SelectedItems.Count > 0)
            {
                csItemArquivo ItemArquivo = (csItemArquivo)_ItemListaArquivos.ItensArquivo[lvwItemListaArquivos.SelectedIndices[0]];
                csArquivoAberto ArquivoAberto = new csArquivoAberto();
                ArquivoAberto.ItemArquivo = ItemArquivo;
                ArquivoAberto.NomeArquivo = Path.GetTempPath() + ItemArquivo.NomeArquivo;
                ItemArquivo.SalvarArquivo(ArquivoAberto.NomeArquivo);
                ArquivoAberto.DataHora = File.GetLastWriteTime(ArquivoAberto.NomeArquivo);
                Process Processo = new Process();
                Processo.StartInfo.FileName = ArquivoAberto.NomeArquivo;
                Processo.EnableRaisingEvents = true;
                Processo.Exited += new EventHandler(Arquivo_Exited);
                Processo.Start();
                ArquivoAberto.Processo = Processo;
                ProcessosAbertos.Add(ArquivoAberto);
            }
            
        }

        private void Arquivo_Exited(object sender, System.EventArgs e)
        {
            csArquivoAberto RemoverArquivoAberto = null;

            foreach (csArquivoAberto ArquivoAberto in ProcessosAbertos)
            {
                if (ArquivoAberto.Processo.Equals(sender))
                {
                    bool AindaEstaNaLista = false;
                    RemoverArquivoAberto = ArquivoAberto;
                    foreach (csItemArquivo ItemArquivo in _ItemListaArquivos.ItensArquivo)
                    {
                        if (ItemArquivo.Equals(ArquivoAberto.ItemArquivo))
                        {
                            AindaEstaNaLista = true;
                        }
                    }
                    if (AindaEstaNaLista)
                    {
                        DateTime DataHoraAlteracao = File.GetLastWriteTime(ArquivoAberto.NomeArquivo);
                        if (DataHoraAlteracao != ArquivoAberto.DataHora)
                        {
                            DialogResult Resp;
                            Resp = MessageBox.Show("O Arquivo " + csUtil.ParteNomeArquivo(ArquivoAberto.NomeArquivo, csUtil.enuParteNomeArquivo.NomeExtencao) + " foi alterado. Deseja salvar a alteração no Check List?\n", "Atualizar arquivo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (Resp == DialogResult.Yes)
                            {
                                ArquivoAberto.ItemArquivo.CarregarArquivo(ArquivoAberto.NomeArquivo);
                                this.Atualizar();
                                this.OnAlterouAlgo(new EventArgs());
                            }
                        }
                    }
                }
            }

            if (RemoverArquivoAberto != null)
            {
                ProcessosAbertos.Remove(RemoverArquivoAberto);
                GC.Collect();
            }

            //try
            //{
            //    File.Delete(RemoverArquivoAberto.NomeArquivo);
            //}
            //catch (Exception)
            //{

            //}

        }

        private void lvwItemListaArquivos_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void lvwItemListaArquivos_DragDrop(object sender, DragEventArgs e)
        {
            if ((e.AllowedEffect & DragDropEffects.Copy) == DragDropEffects.Copy)
            {
                Array data = ((IDataObject)e.Data).GetData("FileName") as Array;
                if (data != null)
                {
                    if ((data.Length == 1) && (data.GetValue(0) is String))
                    {
                        string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                        foreach (string file in files)
                        {
                            _ItemListaArquivos.CarregarArquivo(file);
                        }
                        this.Atualizar();
                        this.OnAlterouAlgo(new EventArgs());
                    }
                }
            }
        }

        private void btAbrirArquivo_MouseEnter(object sender, EventArgs e)
        {
            _ToolTipText.IsBalloon = true;
            _ToolTipText.UseAnimation = true;
            _ToolTipText.UseFading = true;
            _ToolTipText.Show(string.Empty, this, 0, 0);
            _ToolTipText.Show("Localizar arquivos para adicionar", btAbrirArquivo, 0, -45, 2000);
        }

        private void btExcluir_MouseEnter(object sender, EventArgs e)
        {
            _ToolTipText.IsBalloon = true;
            _ToolTipText.UseAnimation = true;
            _ToolTipText.UseFading = true;
            _ToolTipText.Show(string.Empty, this, 0, 0);
            _ToolTipText.Show("Excluir arquivos selecionados", btExcluir, 0, -45, 2000);
        }

        private void btSalvarArquivoSelecionado_MouseEnter(object sender, EventArgs e)
        {
            _ToolTipText.IsBalloon = true;
            _ToolTipText.UseAnimation = true;
            _ToolTipText.UseFading = true;
            _ToolTipText.Show(string.Empty, this, 0, 0);
            _ToolTipText.Show("Salvar arquivo selecionado no disco", btSalvarArquivoSelecionado, 0, -45, 2000);
        }

        private void btSalvarTodosArquivos_MouseEnter(object sender, EventArgs e)
        {
            _ToolTipText.IsBalloon = true;
            _ToolTipText.UseAnimation = true;
            _ToolTipText.UseFading = true;
            _ToolTipText.Show(string.Empty, this, 0, 0);
            _ToolTipText.Show("Salvar todos os arquivos no disco", btSalvarTodosArquivos, 0, -45, 2000);
        }

        private void btAbrirArquivo_MouseLeave(object sender, EventArgs e)
        {
            _ToolTipText.Hide(btAbrirArquivo);
        }

        private void btExcluir_MouseLeave(object sender, EventArgs e)
        {
            _ToolTipText.Hide(btExcluir);
        }

        private void btSalvarArquivoSelecionado_MouseLeave(object sender, EventArgs e)
        {
            _ToolTipText.Hide(btSalvarArquivoSelecionado);
        }

        private void btSalvarTodosArquivos_MouseLeave(object sender, EventArgs e)
        {
            _ToolTipText.Hide(btSalvarTodosArquivos);
        }

        /*
        private void lvwItemListaArquivos_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (lvwItemListaArquivos.SelectedItems.Count > 0)
            {
                
                // Proceed with the drag-and-drop, passing the selected items for 
                string[] filepaths = new string[lvwItemListaArquivos.SelectedItems.Count];
                
                string _TempPath = System.IO.Path.GetTempPath();
                
                if (_TempPath.Substring(_TempPath.Length,1) != "\\")
	            {
		            _TempPath = _TempPath + "\\";
	            }
                
                int i = 0;
                csItemArquivo[] _ListaItensArquivo = new csItemArquivo[lvwItemListaArquivos.SelectedItems.Count];
                
                foreach (ListViewItem item in lvwItemListaArquivos.SelectedItems)
                {
                    _ListaItensArquivo[i] = (csItemArquivo)_ItemListaArquivos.ItensArquivo[item.Index];
                    _ListaItensArquivo[i].SalvarArquivo(_TempPath + _ListaItensArquivo[i].NomeArquivo);
                    filepaths[i] = _TempPath + _ListaItensArquivo[i].NomeArquivo;
                    i++;
                }
                
                DataObject data = new DataObject(DataFormats.FileDrop, filepaths);
                data.SetData(DataFormats.StringFormat, filepaths);
                DoDragDrop(data, DragDropEffects.Copy);
                
            }
            
        }
        */
    }
}
