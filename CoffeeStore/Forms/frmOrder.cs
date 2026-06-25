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
        //============================ A R E A ======================================
        private AreaBUS areaBUS = new AreaBUS();
        private void LoadAreas()                                            // Load Area => All
        {
            DataTable dt = areaBUS.GetAll();
            cboArea.DataSource = dt;
            cboArea.DisplayMember = "AreaName";
            cboArea.ValueMember = "AreaID";
        }
        
        //======================== T A B L E ================================
        private int selectedCategoryID = 0;                                 // Bien toan cuc SelectCategoryID
        
        private void LoadTables(int areaID)                                 // Load Table => areaID
        {
            flpTable.Controls.Clear();
            List<TableDTO> tables = tableBUS.GetAllByAreaID(areaID);
            foreach (TableDTO table in tables)
            {
                Button btn = new Button();
                btn.Width = 100;
                btn.Height = 60;
                btn.Text = table.TableName;
                btn.Tag = table;
                btn.Click += BtnTable_Click;
                flpTable.Controls.Add(btn);
            }
        }
        private void BtnTable_Click(object sender, EventArgs e)                 //Event Click Table
        {
            if (selectedTableButton != null)
            {
                selectedTableButton.BackColor = SystemColors.Control;
            }
            Button btn = (Button)sender;
            selectedTableButton = btn;
            selectedTableButton.BackColor = Color.LightBlue;
            selectedTable = (TableDTO)btn.Tag;
            MessageBox.Show("Đã chọn bàn: " + selectedTable.TableName);
        }
        //============================C A T E G O R Y==================================
        CategoryBUS categoryBUS = new CategoryBUS();
        private void LoadCategories()                                           // Load Category => All
        {
            flpCategory.Controls.Clear();
            DataTable dt = categoryBUS.GetAll();
            foreach (DataRow row in dt.Rows)
            {
                bool isActive = Convert.ToBoolean(row["IsActive"]);
                if (!isActive)
                {
                    continue;
                }
                Button btn = new Button();
                btn.Width = 120;
                btn.Height = 60;
                btn.Text = row["CategoryName"].ToString();
                btn.Tag = row["CategoryID"];
                btn.Click += BtnCategory_Click;                                //click = id category
                flpCategory.Controls.Add(btn);
            }
        }
        private void BtnCategory_Click(object sender, EventArgs e)            // Event click Category
        {
            Button btn = (Button)sender;
            selectedCategoryID = Convert.ToInt32(btn.Tag);
            LoadFoods(selectedCategoryID);
        }
        //================================ F O O D =========================================
        FoodBUS foodBUS = new FoodBUS();
        private void LoadFoods(int categoryID)                              // Load Food = ID Category
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
        private void BtnFood_Click(object sender,EventArgs e)               //Event Click Food
        {
            Button btn = (Button)sender;
            int foodID =Convert.ToInt32(btn.Tag);
            MessageBox.Show("FoodID = " + foodID);
        }
        //====================================== Bill=====================================
        private TableBUS tableBUS = new TableBUS();
        private TableDTO selectedTable = null;
        private Button selectedTableButton = null;

        //===========================================================================
        private void frmOrder_Load(object sender, EventArgs e)
        {
            LoadCategories();
            LoadAreas();
            cboArea.SelectedIndex = -1;
        }
        private void cboArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                if (cboArea.SelectedValue == null)
                {
                    return;
                }
                int areaID;
                if (!int.TryParse(cboArea.SelectedValue.ToString(),out areaID))
                {
                    return;
                }
                LoadTables(areaID);
            }
        }
    }
}
