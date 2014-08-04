using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MembershipProject.Actions;
using System.Threading;
using System.Reflection;

namespace MembershipForms
{
    public partial class frmAction : Form
    {
        private Thread t;

        #region EVENTS

        private void frmAction_Load(object sender, EventArgs e)
        {
            try
            {
                CreateExecutor();
                if (CollectParams())
                {
                    if (t == null)
                    {
                        t = new Thread(new ThreadStart(DoAction));
                        t.Start();
                    }                    
                }
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

        #endregion

        private void CreateExecutor()
        {
            executor = ActionFactory.create(item, write);
        }

        private bool CollectParams()
        {
            string[] args = executor.paramList();
            if (args == null || args.Length == 0) return true;

            var f = new frmParams();
            f.args = args;
            f.ShowDialog();

            if (f.values == null)
            {
                this.Close();
                return false;
            }

            executor.initialize(f.values);
            return true;
        }

        private void DoAction()
        {
            try
            {
                SetControlPropertyThreadSafe(txtResult, "Text", "Realizando consulta . . .\r\n");
                executor.doAction();
                SetControlPropertyThreadSafe(txtResult, "Text", txtResult.Text + "OK!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Invoke((MethodInvoker)delegate
                {
                    this.Close();
                });
            }
        }

        IAction executor;
        public ItemAction item { get; set; }

        public frmAction()
        {
            InitializeComponent();
        }

        private delegate void SetControlPropertyThreadSafeDelegate(Control control, string propertyName, object propertyValue);

        public static void SetControlPropertyThreadSafe(Control control, string propertyName, object propertyValue)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new SetControlPropertyThreadSafeDelegate(SetControlPropertyThreadSafe), new object[] { control, propertyName, propertyValue });
            }
            else
            {
                control.GetType().InvokeMember(propertyName, BindingFlags.SetProperty, null, control, new object[] { propertyValue });
            }
        }

        public void write(string s)
        {
            SetControlPropertyThreadSafe(txtResult, "Text", txtResult.Text + s + "\r\n");
        }

        private void txtResult_VisibleChanged(object sender, EventArgs e)
        {
            var t = sender as TextBox;
            t.SelectionStart = t.Text.Length;
            t.ScrollToCaret();
        }

        private void frmAction_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (t != null)
            {
                t.Abort();
            }
        }
    }
}
