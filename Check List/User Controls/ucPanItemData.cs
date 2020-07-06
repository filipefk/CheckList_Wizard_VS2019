using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Check_List
{
	public delegate void AlterouAlgoItemDataEventHandler(ucPanItemData sender, EventArgs e);

	public partial class ucPanItemData : UserControl
	{
        private bool _PreenchendoData = false;

        public event AlterouAlgoItemDataEventHandler AlterouAlgo;

		protected virtual void OnAlterouAlgo(EventArgs e)
		{
			if (AlterouAlgo != null)
				AlterouAlgo(this, e);
		}

		private csItemData _ItemData = null;

		public ucPanItemData()
		{
			InitializeComponent();
		}

		public object RetornaCheckItem()
		{
			return _ItemData;
		}

		public void SetaCheckItem(object p_ItemData)
		{
			_ItemData = (csItemData)p_ItemData;
            _PreenchendoData = true;
			this.Atualizar();
            _PreenchendoData = false;
		}

		public void Atualizar()
		{
			DateTime? _DataHora = null;
            dthDataHora.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            
            txtDataHora.Visible = false;
			if (_ItemData != null)
			{
                if (_ItemData.SoDataSemHora)
                {
                    dthDataHora.CustomFormat = "dd/MM/yyyy";
                    txtDataHora.Size = new Size(81, 22);
                    dthDataHora.Size = new Size(115, 22);
                    lblNome.Text = "Data";
                }
                else
                {
                    dthDataHora.CustomFormat = "dd/MM/yyyy HH:mm:ss";
                    txtDataHora.Size = new Size(147, 22);
                    dthDataHora.Size = new Size(182, 22);
                    lblNome.Text = "Data e Hora";
                }
				_DataHora = (DateTime?)_ItemData.DataHora;
				if (_DataHora != null)
				{
					dthDataHora.Value = (DateTime)_DataHora;
				}
                else
                {
                    txtDataHora.Visible = true;
                }
			}
            else
            {
                txtDataHora.Visible = true;
            }
			
		}
		private void ucPanItemData_Resize(object sender, EventArgs e)
		{
			this.Size = new Size(601, 196);
		}
        
        private void dthDataHora_ValueChanged(object sender, EventArgs e)
        {
            if (!_PreenchendoData)
            {
                this.OnAlterouAlgo(new EventArgs());
                _ItemData.DataHora = dthDataHora.Value;
                txtDataHora.Visible = false;
            }
        }

        private void dthDataHora_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    _ItemData.DataHora = null;
                    txtDataHora.Visible = true;
                    break;
            }
        }

        private void txtDataHora_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete:
                    _ItemData.DataHora = null;
                    txtDataHora.Visible = true;
                    break;
            }
        }

        private void dthDataHora_CloseUp(object sender, EventArgs e)
        {
            this.OnAlterouAlgo(new EventArgs());
            _ItemData.DataHora = dthDataHora.Value;
            txtDataHora.Visible = false;
        }
        
	}
}
