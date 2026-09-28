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
    public partial class frmMaterial : Form
    {
        public frmMaterial()
        {
            InitializeComponent();
        }
        #region Variables
        private MaterialBUS materialBUS = new MaterialBUS();
        private MaterialDTO selectedMaterial = null;
        #endregion
        #region Load 
        private void LoadMaterials()
        {
            dgvMaterial.DataSource = materialBUS.GetAll();

            dgvMaterial.Columns["MaterialID"].Visible = false;
            dgvMaterial.Columns["IsActive"].Visible = false;
            dgvMaterial.Columns["CreatedDate"].Visible = false;
            dgvMaterial.Columns["UpdatedDate"].Visible = false;

            dgvMaterial.Columns["MaterialName"].HeaderText = "Tên nguyên liệu";
            dgvMaterial.Columns["Unit"].HeaderText = "Đơn vị";
            dgvMaterial.Columns["Quantity"].HeaderText = "Tồn kho";
            dgvMaterial.Columns["MinQuantity"].HeaderText = "Tồn tối thiểu";

            dgvMaterial.Columns["Quantity"].DefaultCellStyle.Format = "N2";
            dgvMaterial.Columns["MinQuantity"].DefaultCellStyle.Format = "N2";
        }

        private void ClearForm()
        {
            txtMaterialName.Clear();
            cboUnit.SelectedIndex = -1;
            txtQuantity.Text = "0";
            txtQuantity.ReadOnly = true;
            txtMinQuantity.Text = "0";
            dgvMaterial.ClearSelection();
        }
        private void loadUnits()
        {
            cboUnit.Items.Add("Gram");
            cboUnit.Items.Add("Kg");
            cboUnit.Items.Add("ml");
            cboUnit.Items.Add("Lít");
            cboUnit.Items.Add("Lon");
            cboUnit.Items.Add("Chai");
            cboUnit.Items.Add("Gói");

            cboUnit.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void frmMaterial_Load(object sender, EventArgs e)
        {
            loadUnits();
            LoadMaterials();
            ClearForm();
        }
        #endregion

        private void dgvMaterial_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            int materialID = Convert.ToInt32(dgvMaterial.Rows[e.RowIndex].Cells["MaterialID"].Value);
            selectedMaterial = materialBUS.GetByID(materialID);
            txtMaterialName.Text = selectedMaterial.MaterialName;
            cboUnit.Text = selectedMaterial.Unit;
            txtQuantity.Text = selectedMaterial.Quantity.ToString();
            txtMinQuantity.Text = selectedMaterial.MinQuantity.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            decimal quantity;
            decimal minQuantity;
            if (string.IsNullOrWhiteSpace(txtMaterialName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên nguyên liệu.");
                return;
            }
            if (cboUnit.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn đơn vị.");
                return;
            }
            if (!decimal.TryParse(txtQuantity.Text, out quantity))
            {
                MessageBox.Show("Số lượng không hợp lệ.");
                return;
            }

            if (!decimal.TryParse(txtMinQuantity.Text, out minQuantity))
            {
                MessageBox.Show("Tồn tối thiểu không hợp lệ.");
                return;
            }
            MaterialDTO material = new MaterialDTO();
            material.MaterialName = txtMaterialName.Text.Trim();
            material.Unit = cboUnit.Text;
            material.Quantity = quantity;
            material.MinQuantity = minQuantity;
            material.IsActive = true;
            if (materialBUS.Insert(material))
            {
                MessageBox.Show("Thêm thành công.");
                LoadMaterials();
                ClearForm();
                txtMaterialName.Focus();    
            }
            else
            {
                MessageBox.Show("Thêm thất bại.");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            decimal quantity;
            decimal minQuantity;
            if (string.IsNullOrWhiteSpace(txtMaterialName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên nguyên liệu.");
                return;
            }
            if (cboUnit.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn đơn vị.");
                return;
            }
            if (!decimal.TryParse(txtQuantity.Text, out quantity))
            {
                MessageBox.Show("Số lượng không hợp lệ.");
                return;
            }

            if (!decimal.TryParse(txtMinQuantity.Text, out minQuantity))
            {
                MessageBox.Show("Tồn tối thiểu không hợp lệ.");
                return;
            }
            selectedMaterial.MaterialName = txtMaterialName.Text.Trim();
            selectedMaterial.Unit = cboUnit.Text;
            selectedMaterial.MinQuantity = minQuantity;
            if (materialBUS.Update(selectedMaterial))
            {
                MessageBox.Show("Cập nhật thành công.");
                LoadMaterials();
                ClearForm();
                selectedMaterial = null;
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại.");
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedMaterial == null)
            {
                MessageBox.Show("Vui lòng chọn nguyên liệu.");
                return;
            }
            if (MessageBox.Show("Xóa nguyên liệu này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            materialBUS.Delete(selectedMaterial.MaterialID);
            LoadMaterials();
            ClearForm();
            selectedMaterial = null;
        }
    }
}
