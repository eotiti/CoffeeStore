
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoffeeStore.DTO;
using CoffeeStore.BUS;

namespace CoffeeStore.Forms
{
    public partial class frmUser : Form
    {
        public frmUser()
        {
            InitializeComponent();
        }
        private UserBUS userBUS;
        private UserDTO userDTO;
        //===========================================================================================================
        private void loadUser()
        {
            //dgvUser.DataSource=userBUS.GetAll();
        }
        //===========================================================================================================
        private void frmUser_Load(object sender, EventArgs e)
        {
            loadUser();
        }
    }
}
