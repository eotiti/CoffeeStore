using CoffeeStore.BUS;
using CoffeeStore.DTO;
using System;
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

            decimal quantity;

            if (!decimal.TryParse(txtQuantity.Text, out quantity))
            {
                MessageBox.Show("Định lượng không hợp lệ.");
                return;
            }

            if (quantity <= 0)
            {
                MessageBox.Show("Định lượng phải lớn hơn 0.");
                return;
            }

            int materialID = Convert.ToInt32(cboMaterial.SelectedValue);

            // Kiểm tra nguyên liệu đã có trong công thức chưa
            if (foodRecipeBUS.Exists(foodID, materialID))
            {
                MessageBox.Show("Nguyên liệu này đã có trong công thức.");
                return;
            }

            FoodRecipeDTO recipe = new FoodRecipeDTO();

            recipe.FoodID = foodID;
            recipe.MaterialID = materialID;
            recipe.Quantity = quantity;

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
