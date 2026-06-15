using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoffeeStore.DTO;
using CoffeeStore.Common;
using CoffeeStore.BUS;
//Login -> DTO -> currentUser -> 

namespace CoffeeStore.Forms
{
    public partial class frmLogin : Form
    {
        UserBUS userBUS = new UserBUS();

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.AcceptButton=btn_login;
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            UserDTO user = userBUS.Login(txt_username.Text.Trim(), txt_password.Text.Trim());
            if (user != null) 
            {
                //MessageBox.Show("Welcome " + user.RoleName + " " + user.FullName);
                CurrentUser.User = user;
                this.Hide();
                new frmMain().Show();
            }
            else
            {
                MessageBox.Show("Wrong Username or Password");
            }
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txt_password.UseSystemPasswordChar = false;
                checkBox1.Text = "Ẩn";
            }
            else 
            {
                txt_password.UseSystemPasswordChar=true;
                checkBox1.Text = "Hiện";
            }
        }
    }
}
