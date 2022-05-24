using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Client.ClassLib;
using Client.ViewModel;
using Sunny.UI;

namespace Client.Forms.Wedgit
{
    public partial class KeySuggest : UIForm
    {
        GuaHao _mf;
        public KeySuggest( GuaHao mf)
        {
            InitializeComponent();
            _mf = mf;
        }

        private void KeySuggest_Load(object sender, EventArgs e)
        {
        }

        private void txtKeySearch_TextChanged(object sender, EventArgs e)
        {
            var py_code = txtKeySearch.Text.Trim().ToUpper();
           var list = SessionHelper.units.Where(p => p.py_code.StartsWith(py_code)).ToList();

            lstunits.Items.Clear();

            foreach (var key in _mf.requestDic.Keys)
            {
                if (list.Where(p => p.name == key).Count()>0)
                {
                    lstunits.Items.Add(key);
                }
            }
            
            
        }

        private void lstunits_ItemClick(object sender, EventArgs e)
        {
            _mf.request_key = lstunits.SelectedItem.ToString();
            this.Close();
        }

        private void txtKeySearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.lstunits.Focus();
                if (lstunits.Items.Count > 0)
                {
                    lstunits.SelectedIndex = 0;
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                if (lstunits.Items.Count>0)
                { 
                    _mf.request_key = lstunits.Items[0].ToString();
                }
                this.Close();
            }
        }

        private void lstunits_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (lstunits.Items.Count > 0)
                {
                    if (lstunits.SelectedIndex==-1)
                    {
                        _mf.request_key = lstunits.Items[0].ToString();
                    }
                    else
                    {
                        _mf.request_key = lstunits.SelectedItem.ToString(); 
                    }
                }
                this.Close();
            }
        }
    }
}
