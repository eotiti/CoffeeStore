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
    public partial class frmEditRecipe : Form
    {
        public frmEditRecipe()
        {
            InitializeComponent();
        }
        
        #region VARIABLES
        private int foodID;
        private readonly MaterialBUS materialBUS = new MaterialBUS();
        private readonly FoodRecipeBUS foodRecipeBUS = new FoodRecipeBUS();
        #endregion
        public frmEditRecipe(int foodID)
        {
            InitializeComponent();

            this.foodID = foodID;
        }
        #region LOAD DATA
        private void LoadMaterials()
        {
            cboMaterial.DataSource = materialBUS.GetAll();
            cboMaterial.DisplayMember = "MaterialName";
            cboMaterial.ValueMember = "MaterialID";
            cboMaterial.SelectedIndex = -1;
        }
        #endregion
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cboMaterial.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn nguyên liệu.");
                return;
            }

            if (!decimal.TryParse(txtQuantity.Text, out var quantity))
            {
                MessageBox.Show("Định lượng không hợp lệ.");
                return;
            }

            if (quantity <= 0)
            {
                MessageBox.Show("Định lượng phải lớn hơn 0.");
                return;
            }

            var recipe = new FoodRecipeDTO
            {
                FoodID = foodID,
                Quantity = quantity
            };

            if (cboMaterial.SelectedValue is int materialId)
            {
                recipe.MaterialID = materialId;
            }
            else
            {
                // Fallback for unexpected value types
            recipe.MaterialID = Convert.ToInt32(cboMaterial.SelectedValue);
            }

            if (foodRecipeBUS.Insert(recipe))
            {
                MessageBox.Show("Thêm nguyên liệu vào công thức thành công.");
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Thêm nguyên liệu thất bại.");
            }
        }

        private void frmEditRecipe_Load(object sender, EventArgs e)
        {
            LoadMaterials();
        }
    }
}
