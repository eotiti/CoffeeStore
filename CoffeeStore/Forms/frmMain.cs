using CoffeeStore.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeStore.Forms
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();            
        }
        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void SetPermission()
        {
            switch (CurrentUser.User.RoleName)
            {
                case "Admin":
                    break;
                case "User":
                    toolManager.Visible = false;
                    toolReport.Visible = false;
                    break;
                case "Customer":
                    menuAccount.Visible = false;
                    menuWarehouse.Visible = false;
                    break;
            }
        }
        private Form currentForm;
        private void OpenForm(Form childForm)
        {
            if (currentForm != null)
            {
                currentForm.Close();
            }
            currentForm = childForm;

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(childForm);

            childForm.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            toolAccount.Text= "Xin chào:" + CurrentUser.User.FullName;            
            SetPermission();
            if (CurrentUser.User == null)
            {
                MessageBox.Show("Phiên đăng nhập không hợp lệ");
                this.Close();
                return;
            }
        }
        private void menuArea_Click(object sender, EventArgs e)
        {
            OpenForm(new frmArea());
        }
        private void menuCategory_Click(object sender, EventArgs e)
        {
            OpenForm(new frmCategory());
        }
        private void menuFood_Click(object sender, EventArgs e)
        {
            OpenForm(new frmFood());
        }
        private void menuOrder_Click(object sender, EventArgs e)
        {
            OpenForm(new frmOrder());
        }
        private void menuAccount_Click(object sender, EventArgs e)
        {
            OpenForm (new frmAccount());
        }
        
        private void menuUser_Click(object sender, EventArgs e)
        {
            OpenForm(new frmUser()) ;
        }
        private void menuLogout_Click(object sender, EventArgs e)
        {
            CurrentUser.User = null;
            frmLogin frm = new frmLogin();
            frm.Show();
            this.Hide();
        }
    }
}
