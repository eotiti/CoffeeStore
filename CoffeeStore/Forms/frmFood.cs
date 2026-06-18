using CoffeeStore.BUS;
using CoffeeStore.DTO;
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
    public partial class frmFood : Form
    {
        public frmFood()
        {
            InitializeComponent();
        }
        //============================================================
        private FoodBUS foodBUS = new FoodBUS();

        private CategoryBUS categoryBUS = new CategoryBUS();

        private int selectedFoodID = 0;
        private void LoadCategories()
        {
            DataTable dt = categoryBUS.GetAll();

            DataView dv = dt.DefaultView;

            dv.RowFilter = "IsActive = true";

            cboCategory.DataSource = dv;

            cboCategory.DisplayMember = "CategoryName";

            cboCategory.ValueMember = "CategoryID";
        }
        private void LoadFoods()
        {
            dgvFood.DataSource = foodBUS.GetAll();
            

            dgvFood.Columns["FoodID"].HeaderText = "STT";

            dgvFood.Columns["FoodName"].HeaderText = "Tên món";

            dgvFood.Columns["Price"].HeaderText = "Giá";

            dgvFood.Columns["FoodID"].Width = 60;
            dgvFood.Columns["FoodName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvFood.Columns["Price"].DefaultCellStyle.Format = "N0";

            dgvFood.Columns["CategoryID"].Visible = false;

            dgvFood.Columns["CategoryName"].Visible = false;

            dgvFood.Columns["IsActive"].Visible = false;
            dgvFood.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void ClearForm()
        {
            selectedFoodID = 0;

            txtFoodName.Clear();

            txtPrice.Clear();

            chkActive.Checked = true;

            if (cboCategory.Items.Count > 0)
            {
                cboCategory.SelectedIndex = 0;
            }

            txtFoodName.Focus();
        }
        //============================================================
        private void frmFood_Load(object sender, EventArgs e)
        {
            LoadCategories();

            LoadFoods();

            chkActive.Checked = true;
        }

        private void dgvFood_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvFood.Rows[e.RowIndex];

            selectedFoodID = Convert.ToInt32(row.Cells["FoodID"].Value);

            txtFoodName.Text = row.Cells["FoodName"].Value.ToString();

            txtPrice.Text = row.Cells["Price"].Value.ToString();

            cboCategory.SelectedValue = Convert.ToInt32(row.Cells["CategoryID"].Value);

            chkActive.Checked = Convert.ToBoolean(row.Cells["IsActive"].Value);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFoodName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên món");

                txtFoodName.Focus();

                return;
            }

            if (!decimal.TryParse(txtPrice.Text, out decimal price))
            {
                MessageBox.Show("Giá không hợp lệ");

                txtPrice.Focus();

                return;
            }

            if (selectedFoodID == 0)
            {
                FoodDTO food = new FoodDTO();

                food.FoodName = txtFoodName.Text.Trim();

                food.CategoryID = Convert.ToInt32(cboCategory.SelectedValue);

                food.Price = price;

                food.IsActive = chkActive.Checked;

                if (foodBUS.Insert(food))
                {
                    MessageBox.Show("Thêm món thành công");

                    LoadFoods();

                    ClearForm();
                }
            }
            else
            {
                FoodDTO food =
                    foodBUS.GetByID(selectedFoodID);

                food.FoodName = txtFoodName.Text.Trim();

                food.CategoryID =
                    Convert.ToInt32(cboCategory.SelectedValue);

                food.Price = price;

                food.IsActive = chkActive.Checked;

                if (foodBUS.Update(food))
                {
                    MessageBox.Show("Cập nhật thành công");

                    LoadFoods();

                    ClearForm();
                }
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
    }
}
