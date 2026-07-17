using CoffeeStore.BUS;
using CoffeeStore.Common;
using CoffeeStore.DTO;
using CoffeeStore.Enum;
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
    public partial class frmOrder : Form
    {
        public frmOrder()
        {
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Dpi;
        }

        #region BUS
        private AreaBUS areaBUS = new AreaBUS();
        private TableBUS tableBUS = new TableBUS();
        private CategoryBUS categoryBUS = new CategoryBUS();
        private FoodBUS foodBUS = new FoodBUS();
        private BillBUS billBUS = new BillBUS();
        private BillDetailBUS billDetailBUS = new BillDetailBUS();
        #endregion
        #region Currrent State

        private TableDTO selectedTable;
        private BillDetailDTO selectedBillDetail ;

        private int selectedAreaID;
        private int selectedCategoryID;
        private int selectedBillDetailID;

        private decimal currentTotal;
        #endregion
        #region LOAD
        private void LoadAreas()
        {
            DataTable dt = areaBUS.GetAll();
            DataRow row = dt.NewRow();
            row["AreaID"] = 0;
            row["AreaName"] = "- Select Area -";
            dt.Rows.InsertAt(row, 0);
            cboArea.DataSource = dt;
            cboArea.DisplayMember = "AreaName";
            cboArea.ValueMember = "AreaID";
            cboArea.SelectedIndex = 0;
        }
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
                if (table.Status == TableStatus.Empty)
                {
                    btn.BackColor = Color.LightGreen;
                }
                else
                {
                    btn.BackColor = Color.LightSalmon;
                }
                flpTable.Controls.Add(btn);
            }
        }
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
        private void LoadFoods(int categoryID)
        {
            flpFood.Controls.Clear();
            DataTable dt = foodBUS.GetByCategory(categoryID);
            foreach (DataRow row in dt.Rows)
            {
                Button btn = new Button();
                btn.Width = 120;
                btn.Height = 60;
                btn.Text = row["FoodName"].ToString() + Environment.NewLine + Convert.ToDecimal(row["Price"]).ToString("N0");
                btn.Tag = row["FoodID"];
                btn.Click += BtnFood_Click;
                flpFood.Controls.Add(btn);
            }
        }
        private void LoadBill(int billID)
        {
            dgvBill.DataSource = billDetailBUS.GetBillDetails(billID);
            LoadTotal(billID);
            ConfigureBillGrid();
        }
        private void LoadTotal(int billID)
        {
            currentTotal = billDetailBUS.GetTotalAmount(billID);
            lblSum.Text = "Tổng tiền: " + currentTotal.ToString("N0") + " VNĐ";
        }
        #endregion
        #region EVENT
        private void BtnTable_Click(object sender, EventArgs e)                 
        {
            Button btn = (Button)sender;
            selectedTable = (TableDTO)btn.Tag;
            groupBox2.Text = "ĐANG CHỌN BÀN: " + selectedTable.TableName;
            BillDTO bill = billBUS.GetOpenBillByTable(selectedTable.TableID);
            if (bill != null)
            {
                LoadBill(bill.BillID);
                LoadTotal(bill.BillID);
            }
            else
            {
                dgvBill.DataSource = null;
                lblSum.Text = "Tổng tiền: 0 VNĐ";
            }
        }
        private void BtnCategory_Click(object sender, EventArgs e)            // Event click Category
        {
            Button btn = (Button)sender;
            selectedCategoryID = Convert.ToInt32(btn.Tag);
            LoadFoods(selectedCategoryID);
        }
        private void BtnFood_Click(object sender, EventArgs e)
        {
            if (selectedTable == null)
            {
                MessageBox.Show("Vui lòng chọn bàn");
                return;
            }
            Button btn = (Button)sender;
            int foodID = Convert.ToInt32(btn.Tag);
            BillDTO billDTO = billBUS.GetOpenBillByTable(selectedTable.TableID);
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
            BillDetailDTO detail = new BillDetailDTO();
            detail.BillID = billID;
            detail.FoodID = foodID;
            detail.Quantity = 1;
            detail.UnitPrice = food.Price;
            detail.Amount = food.Price;

            BillDetailDTO existDetail = billDetailBUS.GetFoodInBill(billID, foodID);
            if (existDetail == null)
            {
                if (billDetailBUS.Insert(detail))
                {
                    tableBUS.UpdateStatus(selectedTable.TableID, TableStatus.Occupied);
                    RefreshTables();
                }
            }
            else
            {
                int quantity = existDetail.Quantity + 1;
                decimal amount = quantity * existDetail.UnitPrice;
                billDetailBUS.UpdateQuantity(existDetail.BillDetailID, quantity, amount);
            }
            LoadBill(billID);
        }
        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            if (selectedBillDetail == null)
            {
                MessageBox.Show("Vui lòng chọn món.");
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa món này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }
            if (!billDetailBUS.Delete(selectedBillDetail.BillDetailID))
            {
                MessageBox.Show("Xóa thất bại.");
                return;
            }
            BillDTO bill = billBUS.GetOpenBillByTable(selectedTable.TableID);

            if (bill != null)
            {
                if (billDetailBUS.CountByBill(bill.BillID) == 0)
                {
                    billBUS.Delete(bill.BillID);

                    tableBUS.UpdateStatus(selectedTable.TableID, TableStatus.Empty);

                    dgvBill.DataSource = null;
                    lblSum.Text = "Tổng tiền: 0 VNĐ";
                }
                else
                {
                    LoadBill(bill.BillID);
                }
            }

            RefreshTables();

            selectedBillDetail = null;

        }

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
            BillDTO bill = billBUS.GetOpenBillByTable(selectedTable.TableID);
            int quantity = selectedBillDetail.Quantity - 1;
            if (quantity <= 0)
            {
                billDetailBUS.Delete(selectedBillDetail.BillDetailID);
                if (bill != null)
                {
                    if (billDetailBUS.CountByBill(bill.BillID) == 0)
                    {
                        billBUS.Delete(bill.BillID);
                        tableBUS.UpdateStatus(selectedTable.TableID, TableStatus.Empty);

                        dgvBill.DataSource = null;
                        lblSum.Text = "Tổng tiền: 0 VNĐ";
                        currentTotal = 0;

                        RefreshTables();

                        selectedBillDetail = null;
                        return;
                    }
                }

                selectedBillDetail = null;
            }
            else
            {
                decimal amount = quantity * selectedBillDetail.UnitPrice;

                billDetailBUS.UpdateQuantity(selectedBillDetail.BillDetailID, quantity, amount);

                selectedBillDetail = billDetailBUS.GetByID(selectedBillDetail.BillDetailID);
            }

            if (bill != null)
            {
                LoadBill(bill.BillID);
            }

            RefreshTables();
        }
        private void btnPayment_Click(object sender, EventArgs e)
        {
            if (selectedTable == null)
            {
                MessageBox.Show("Vui lòng chọn bàn.");
                return;
            }

            BillDTO bill = billBUS.GetOpenBillByTable(selectedTable.TableID);

            if (bill == null)
            {
                MessageBox.Show("Bàn này chưa có hóa đơn.");
                return;
            }
            DialogResult result = MessageBox.Show("Tổng tiền: " + currentTotal.ToString("N0") + " VNĐ\n\nXác nhận thanh toán?", "Thanh toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                return;
            }
            bool success = billBUS.Payment(bill.BillID, currentTotal);

            if (!success)
            {
                MessageBox.Show("Thanh toán thất bại.");
                return;
            }
            tableBUS.UpdateStatus(selectedTable.TableID, TableStatus.Empty);
            ResetOrder();
            RefreshTables();
        }
        #endregion
        #region Reset form
        private void ResetOrder()
        {
            dgvBill.DataSource = null;
            lblSum.Text = "Tổng tiền: 0 VNĐ";
            currentTotal = 0;
            selectedBillDetail = null;
            selectedTable = null;
            flpFood.Controls.Clear();
        }
        private void RefreshTables()
        {
            LoadTables(selectedAreaID);
        }
        private void ConfigureBillGrid()
        {
            dgvBill.Columns["BillDetailID"].HeaderText = "STT";
            dgvBill.Columns["FoodName"].HeaderText = "Tên món";
            dgvBill.Columns["Quantity"].HeaderText = "Số lượng";
            dgvBill.Columns["UnitPrice"].HeaderText = "Đơn Giá";
            dgvBill.Columns["Amount"].HeaderText = "Thành tiền";
            dgvBill.Columns["UnitPrice"].DefaultCellStyle.Format = "N0";
            dgvBill.Columns["Amount"].DefaultCellStyle.Format = "N0";
            dgvBill.Columns["BillDetailID"].Visible = false;
        }
        #endregion
        #region Form Event

        private void frmOrder_Load(object sender, EventArgs e)
        {
            LoadCategories();
            LoadAreas();
            
            cboArea.DropDownStyle = ComboBoxStyle.DropDownList;
            dgvBill.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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
           
                if (!int.TryParse(cboArea.SelectedValue.ToString(),out selectedAreaID))
                {
                    return;
                }
                RefreshTables();
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

        #endregion
    }
}
