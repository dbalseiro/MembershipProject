using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MembershipProject.Actions;

namespace MembershipForms
{
    public partial class frmPrincipal : Form
    {
        #region EVENTS
        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                LoadMenu();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        void menu_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                ItemAction action = (ItemAction)(sender as Button).Tag;
                if (action == ItemAction.EXIT) Application.Exit();

                frmAction f = new frmAction();
                f.Text = action.nombreMenu();
                f.item = action;
                f.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        #endregion

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void LoadMenu()
        {
            int i = 0;
            this.Width = 1;
            foreach (ItemAction item in ItemAction.Actions)
            {
                Button button = CreateButton(item.nombreMenu(), i++);
                AddButton(button);
                AddAction(button, item);
            }
        }

        private void AddAction(Button button, ItemAction item)
        {
            button.Tag = item;
            button.Click += new EventHandler(menu_Click);
        }

        private Button CreateButton(string nombre, int position)
        {
            Button btn = new Button();
            btn.Left = 5;
            btn.Top = (position * 25) + 5;
            btn.AutoEllipsis = false;
            btn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn.Text = nombre;
            btn.AutoSize = true;
            return btn;
        }

        private void AddButton(Button btn)
        {
            this.Controls.Add(btn);
            this.Height = btn.Bottom + 45;
            int w = btn.Width + 25;
            if (this.Width < w) this.Width = w;
        }
    }
}
