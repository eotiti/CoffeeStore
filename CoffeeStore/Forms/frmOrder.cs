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
using CoffeeStore.Common;


namespace CoffeeStore.Forms
{
    public partial class frmOrder : Form
    {
        public frmOrder()
        {
            InitializeComponent();
        }
        
        
        private AreaBUS areaBUS = new AreaBUS();

        private TableBUS tableBUS = new TableBUS();
        private TableDTO selectedTable = null;
        private Button selectedTableButton = null;

        private CategoryBUS categoryBUS = new CategoryBUS();
        private int selectedCategoryID = 0;

        private FoodBUS foodBUS = new FoodBUS();

        private BillBUS billBUS = new BillBUS();
        private BillDetailBUS billDetailBUS = new BillDetailBUS();
        private int selectedBillDetailID = 0;
        
        //============================ A R E A ======================================

        private void LoadAreas()                                            // Load Area => All
        {
            DataTable dt = areaBUS.GetAll();
            
            DataRow row = dt.NewRow();
            row["AreaID"] = 0;
            row["AreaName"] = "- Select Area -";
            dt.Rows.InsertAt(row, 0);
            cboArea.DataSource = dt;
            cboArea.DisplayMember = "AreaName";
            cboArea.ValueMember = "AreaID";
            cboArea.SelectedIndex=0;
        }
       
        //======================== T A B L E ================================
        
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
            BillDTO bill =billBUS.GetOpenBillByTable(selectedTable.TableID);
            if (bill != null)
            {
                groupBox2.Text = "Hoá đơn: "+ selectedTable.TableName.ToString();
                LoadBill(bill.BillID);
            }
            else
            {
                groupBox2.Text = "Hoá đơn";
                dgvBill.DataSource = null;
                lblSum.Text ="Tổng tiền: 0 VNĐ";
            }


        }
        //============================C A T E G O R Y==================================
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
        //================================ F O O D  + B I L L =========================================
        
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
        
        private void BtnFood_Click(object sender,EventArgs e)               //Event Click Food = > Create Bill
        {
            if (selectedTable == null)
            {
                MessageBox.Show("Vui lòng chọn bàn");
                return;
            }

            Button btn = (Button)sender;

            int foodID = Convert.ToInt32(btn.Tag);

            BillDTO billDTO =billBUS.GetOpenBillByTable(selectedTable.TableID);

            int billID;

            if (billDTO == null)
            {
                BillDTO newBill = new BillDTO();
                newBill.TableID = selectedTable.TableID;
                newBill.UserID = CurrentUser.User.UserID;
                billID = billBUS.CreateBill(newBill);
            }
            else
            {
                billID = billDTO.BillID;
            }

            FoodDTO food = foodBUS.GetByID(foodID);
            BillDetailDTO detail = new BillDetailDTO();                    // tao cái DTO bill detail 
            detail.BillID = billID;                                        // set các tham số
            detail.FoodID = foodID;
            detail.Quantity = 1;
            detail.UnitPrice = food.Price;
            detail.Amount = food.Price;

            BillDetailDTO existDetail =billDetailBUS.GetFoodInBill(billID,foodID);        // them bill Detail theo cái Bill ID
            if (existDetail == null)
            {
                billDetailBUS.Insert(detail);
            }
            else
            {
                int quantity =existDetail.Quantity + 1;
                decimal amount =quantity * existDetail.UnitPrice;
                billDetailBUS.UpdateQuantity(existDetail.BillDetailID,quantity,amount);
            }                                
            LoadBill(billID);
        }
        //====================================== Bill=====================================
        private void LoadBill(int billID)
        {
            dgvBill.DataSource = billDetailBUS.GetBillDetails(billID);
            dgvBill.Columns["BillDetailID"].HeaderText = "STT";
            dgvBill.Columns["FoodName"].HeaderText = "Tên món";
            dgvBill.Columns["Quantity"].HeaderText = "Số lượng";
            dgvBill.Columns["UnitPrice"].HeaderText = "Đơn Giá";
            dgvBill.Columns["Amount"].HeaderText = "Thành tiền";
            dgvBill.Columns["UnitPrice"].DefaultCellStyle.Format = "N0";
            dgvBill.Columns["Amount"].DefaultCellStyle.Format = "N0";
            dgvBill.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBill.Columns["BillDetailID"].Visible = false;
            LoadTotal(billID);
            
        }
        private void LoadTotal(int billID)
        {
            decimal total =billDetailBUS.GetTotalAmount(billID);
            lblSum.Text = "Tổng tiền: "+ total.ToString("N0")+" VNĐ";
        }

        //===========================================================================
        private void frmOrder_Load(object sender, EventArgs e)
        {
            LoadCategories();
            LoadAreas();
            cboArea.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void cboArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            {
                if (cboArea.SelectedValue == null)
                {
                    flpTable.Visible=false;
                    return;
                }
                else
                {
                    flpTable.Visible = true;
                }
                int areaID;
                if (!int.TryParse(cboArea.SelectedValue.ToString(),out areaID))
                {
                    return;
                }
                LoadTables(areaID);
            }
        }

        private void dgvBill_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            selectedBillDetailID =Convert.ToInt32(dgvBill.Rows[e.RowIndex].Cells["BillDetailID"].Value);
            selectedBillDetail = billDetailBUS.GetByID(selectedBillDetailID);

        }

        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            if (selectedBillDetailID == 0)
            {
                MessageBox.Show("Vui lòng chọn món");
                return;
            }

            if (billDetailBUS.Delete(selectedBillDetailID))
            {
                BillDTO bill = billBUS.GetOpenBillByTable( selectedTable.TableID);
                LoadBill(bill.BillID);
                selectedBillDetailID = 0;
            }
        }
        private BillDetailDTO selectedBillDetail = null;
        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (selectedBillDetail == null)
            {
                MessageBox.Show("Vui lòng chọn món.");
                return;
            }
            int quantity = selectedBillDetail.Quantity + 1;
            decimal amount = quantity * selectedBillDetail.UnitPrice;
            billDetailBUS.UpdateQuantity(selectedBillDetail.BillDetailID, quantity, amount);
            LoadBill(selectedBillDetail.BillID);
            selectedBillDetail = billDetailBUS.GetByID(selectedBillDetail.BillDetailID);
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (selectedBillDetail == null)
            {
                MessageBox.Show("Vui lòng chọn món.");
                return;
            }
            int quantity = selectedBillDetail.Quantity - 1;
            if (quantity <= 0)
            {
                billDetailBUS.Delete(selectedBillDetail.BillDetailID);

                selectedBillDetail = null;
            }
            else
            {
                decimal amount = quantity * selectedBillDetail.UnitPrice;

                billDetailBUS.UpdateQuantity(selectedBillDetail.BillDetailID, quantity, amount);

                selectedBillDetail = billDetailBUS.GetByID(selectedBillDetail.BillDetailID);
            }
            LoadBill(selectedBillDetail?.BillID ?? billBUS.GetOpenBillByTable(selectedTable.TableID).BillID);
        }
    }
}
