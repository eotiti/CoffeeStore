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
using CoffeeStore.DAL;
using CoffeeStore.BUS;

namespace CoffeeStore.Forms
{
    public partial class frmOrder : Form
    {
        public frmOrder()
        {
            InitializeComponent();
        }
        //===========================================================================
        CategoryBUS categoryBUS=new CategoryBUS();
        private void LoadCategories()// load len toan bo danh muc Category
        {
            flpCategory.Controls.Clear();

            DataTable dt = categoryBUS.GetAll();

            foreach (DataRow row in dt.Rows)
            {
                bool isActive = Convert.ToBoolean(row["IsActive"]);

                if (!isActive)
                    continue;

                Button btn = new Button();

                btn.Width = 120;

                btn.Height = 60;

                btn.Text = row["CategoryName"].ToString();

                btn.Tag = row["CategoryID"];

                btn.Click += BtnCategory_Click;//click vao se hien Food cua Category

                flpCategory.Controls.Add(btn);
            }
        }
        private void LoadFoods(int categoryID)//BtnCategory_click ==> Load Food cua Category tuong ung
        {
            flpFood.Controls.Clear();

            DataTable dt =foodBUS.GetByCategory(categoryID);

            foreach (DataRow row in dt.Rows)
            {
                Button btn = new Button();

                btn.Width = 120;

                btn.Height = 60;

                btn.Text =row["FoodName"].ToString() + Environment.NewLine + Convert.ToDecimal(row["Price"]).ToString("N0");

                btn.Tag = row["FoodID"];

                btn.Click += BtnFood_Click;

                flpFood.Controls.Add(btn);
            }
        }
        private int selectedCategoryID = 0;
        FoodBUS foodBUS = new FoodBUS();
        private void BtnCategory_Click(object sender,EventArgs e)// su kien khi click Category bat ky
        {
            Button btn = (Button)sender;

            selectedCategoryID = Convert.ToInt32(btn.Tag);

            LoadFoods(selectedCategoryID);
        }
        private void BtnFood_Click(object sender,EventArgs e)//su kien click Food bat ky
        {
            Button btn = (Button)sender;

            int foodID =Convert.ToInt32(btn.Tag);

            MessageBox.Show("FoodID = " + foodID);
        }
        //===========================================================================
        private void frmOrder_Load(object sender, EventArgs e)
        {
            LoadCategories();
        }
    }
}
