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
using CoffeeStore.DTO;

namespace CoffeeStore.Forms
{
    public partial class frmCategory : Form
    {
        public frmCategory()
        {
            InitializeComponent();
            AutoScaleMode=AutoScaleMode.Dpi;
        }
        private int selectedCategoryID = 0;
        private CategoryBUS categoryBUS = new CategoryBUS();
        private void LoadCategories()
        {
            dgvCategory.DataSource =  categoryBUS. GetAll();
            dgvCategory.Columns["CategoryID"].HeaderText = "STT";

            dgvCategory.Columns["CategoryName"].HeaderText = "Tên danh mục";

            dgvCategory.Columns["IsActive"].HeaderText = "Hoạt động";
            dgvCategory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void ClearForm()
        {
            selectedCategoryID = 0;

            txtCategoryName.Clear();

            chkActive.Checked = true;

            txtCategoryName.Focus();
        }
        private void Category_Load(object sender, EventArgs e)
        {
            LoadCategories();
            chkActive.Checked = true;
            //MessageBox.Show( chkActive.Checked.ToString().Trim());
        }

        private void dgvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dgvCategory.Rows[e.RowIndex];
            selectedCategoryID = Convert.ToInt32(row.Cells["CategoryID"].Value);
            txtCategoryName.Text = row.Cells["CategoryName"].Value.ToString();

            chkActive.Checked = Convert.ToBoolean(row.Cells["IsActive"].Value);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên danh mục");

                txtCategoryName.Focus();

                return;
            }

            if (selectedCategoryID == 0)
            {
                CategoryDTO category = new CategoryDTO();

                category.CategoryName = txtCategoryName.Text.Trim();

                category.IsActive = chkActive.Checked;

                if (categoryBUS.Insert(category))
                {
                    MessageBox.Show("Thêm thành công");

                    LoadCategories();

                    ClearForm();
                }
            }
            else
            {
                CategoryDTO category = categoryBUS.GetByID(selectedCategoryID);

                category.CategoryName = txtCategoryName.Text.Trim();

                category.IsActive = chkActive.Checked;

                if (categoryBUS.Update(category))
                {
                    MessageBox.Show("Cập nhật thành công");

                    LoadCategories();

                    ClearForm();
                }
            }
        }
    }
}
