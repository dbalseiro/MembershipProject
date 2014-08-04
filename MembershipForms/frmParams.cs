using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MembershipForms
{
    public partial class frmParams : Form
    {
        public string[] args { get; set; }
        public string[] values
        {
            get
            {
                if (cancelled) return null;

                var ret = new List<string>();
                foreach (var control in this.Controls)
                {
                    if (control is TextBox)
                    {
                        ret.Add((control as TextBox).Text);
                    }
                }
                return ret.ToArray();
            }            
        }

        private bool cancelled;

        public frmParams()
        {
            InitializeComponent();
        }

        #region EVENTS
        private void frmParams_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                cancelled = true;
                LoadControls();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btn_Click(object sender, EventArgs e)
        {
            cancelled = ((string)(sender as Button).Tag) == "True";
            this.Close();
        }        

        #endregion

        private void LoadControls()
        {
            int i = 0;
            foreach (string s in args)
            {
                Label lbl = new Label();
                lbl.Text = s + ":";
                lbl.Top = (i++ * 25) + 5;
                lbl.Left = 5;
                lbl.AutoEllipsis = false;
                lbl.AutoSize = true;
                this.Controls.Add(lbl);

                TextBox txt = new TextBox();
                txt.Top = lbl.Top;
                txt.Left = lbl.Width + 10;
                this.Controls.Add(txt);

                this.Height = txt.Bottom + 100;
            }
        }                
    }
}
