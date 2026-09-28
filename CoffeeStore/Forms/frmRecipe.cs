using CoffeeStore.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeStore.Forms
{
    public partial class frmRecipe : Form
    {
        public frmRecipe()
        {
            InitializeComponent();
        }
        #region VARIABLES
        private FoodBUS foodBUS = new FoodBUS();
        private FoodRecipeBUS foodRecipeBUS = new FoodRecipeBUS();
        #endregion
        #region  LOAD DATA
        private void LoadFoodList()
        {
            DataTable dt = foodBUS.GetAll();
            cboFood.DataSource = dt;
            cboFood.DisplayMember = "FoodName";
            cboFood.ValueMember = "FoodID";
            cboFood.SelectedIndex = -1;
        }
        private void LoadRecipe()
        {
            if (cboFood.SelectedValue == null)
                return;

            int foodID = Convert.ToInt32(cboFood.SelectedValue);
            dgvRecipe.DataSource = foodRecipeBUS.GetByFood(foodID);

            dgvRecipe.Columns["RecipeID"].Visible = false;
            dgvRecipe.Columns["FoodID"].Visible = false;
            dgvRecipe.Columns["MaterialID"].Visible = false;

            dgvRecipe.Columns["MaterialName"].HeaderText = "Nguyên liệu";
            dgvRecipe.Columns["Quantity"].HeaderText = "Định lượng";
            dgvRecipe.Columns["Unit"].HeaderText = "Đơn vị";
          
            dgvRecipe.AllowUserToAddRows = false;
            dgvRecipe.ReadOnly = true;
            dgvRecipe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRecipe.MultiSelect = false;
        }
        #endregion
        private void frmRecipe_Load(object sender, EventArgs e)
        {
            LoadFoodList();
        }

        private void cboFood_SelectedIndexChanged(object sender, EventArgs e)
        {
             
            if (cboFood.SelectedIndex == -1)
                return;

            if (cboFood.SelectedValue == null)
                return;

            if (!(cboFood.SelectedValue is int))
                return;
            LoadRecipe();
       
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cboFood.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn món.");
                return;
            }

            int foodID = Convert.ToInt32(cboFood.SelectedValue);

            frmEditRecipe frm = new frmEditRecipe(foodID);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadRecipe();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }
    }
}
