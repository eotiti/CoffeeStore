using CoffeeStore.BUS;
using CoffeeStore.DAL;
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
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CoffeeStore.Forms
{
    public partial class frmArea : Form
    {
        public frmArea()
        {
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Dpi;
        }

        //=====================LOAD KHU VỰC=================
        private AreaBUS areaBUS = new AreaBUS();
        private int selectedAreaID = 0;
        private Button selectedButton = null;
        private void LoadArea()
        {
            DataTable dt = areaBUS.GetAll();

            flpArea.Controls.Clear();

            foreach (DataRow row in dt.Rows)
            {
                Button btn = new Button();

                btn.Width = 180;
                btn.Height = 100;

                btn.Margin = new Padding(10);

                btn.FlatStyle = FlatStyle.Flat;

                btn.Font = new Font("Segoe UI", 12, FontStyle.Bold);

                btn.Text = row["AreaName"].ToString();
                toolTip1.SetToolTip(btn, row["Description"].ToString());

                btn.Tag = row["AreaID"];

                btn.Click += Area_Click;

                flpArea.Controls.Add(btn);
            }
        }
        private void Area_Click(object sender, EventArgs e)//su kien click Ô khu vực
        {

            if (selectedButton != null)
            {
                selectedButton.BackColor = SystemColors.Control;
            }

            selectedButton = (Button)sender;

            selectedButton.BackColor = Color.LightBlue;

            selectedAreaID = Convert.ToInt32(selectedButton.Tag);
            groupBox2.Visible = true;
            LoadTables(selectedAreaID);
            
        }
        //====================LOAD BÀN CỦA 1 KHU VỰC======================
        private TableBUS tableBUS = new TableBUS();
        private int selectedTableID = 0;
        private TableDTO selectedTable = null;
        private void LoadTables(int areaID)
        {
            flpTable.Controls.Clear();

            List<TableDTO> tables = tableBUS.GetAllByAreaID(areaID);

            foreach (TableDTO table in tables)
            {
                Button btn = new Button();

                btn.Width = 120;
                btn.Height = 80;

                btn.Text = table.TableName+"\n"+table.AreaID+"\n"+table.Status;

                btn.Tag = table;
                if (table.Status == 0)
                {
                    btn.BackColor = Color.LightGreen;
                }
                else if (table.Status == 1)
                {

                    btn.BackColor = Color.OrangeRed;
                }
                else if (table.Status == 2)
                {
                    btn.BackColor=Color.Red;
                }

                btn.Click += BtnTable_Click;

                flpTable.Controls.Add(btn);
            }
        }
        private void BtnTable_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            TableDTO table = (TableDTO)btn.Tag;
            selectedTable = (TableDTO)btn.Tag;
            selectedTableID = table.TableID;
      
        }
        
        private void frmArea_Load(object sender, EventArgs e)
        {
            LoadArea();
        }

        private void btnAddArea_Click(object sender, EventArgs e)
        {
            frmEditArea frm = new frmEditArea();
            if (frm.ShowDialog() == DialogResult.OK)// Đóng form sẽ load lại danh sách 
            {
                LoadArea();
            }
        }

        private void btnUpdateArea_Click(object sender, EventArgs e)
        {
            if (selectedAreaID == 0)
            {
                MessageBox.Show( "Vui lòng chọn khu vực");
                return;
            }
            AreaDTO area = areaBUS.GetByID(selectedAreaID);
            frmEditArea frm = new frmEditArea(area);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadArea();
            }
        }

        private void btnAddTable_Click(object sender, EventArgs e)
        {
            frmEditTable frm = new frmEditTable(selectedAreaID);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadTables(selectedAreaID);
            }
            //MessageBox.Show("Bạn đang thêm bàn cho: Khu vực "+selectedAreaID+" ");

        }

        private void btnEditTable_Click(object sender, EventArgs e)
        {
            if (selectedTableID == 0)
            {
                MessageBox.Show("Vui lòng chọn bàn");
                return;
            }

            TableDTO table = tableBUS.GetByID(selectedTableID);

            frmEditTable frm = new frmEditTable(table);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadTables(selectedAreaID);
            }
        }
    }
}
