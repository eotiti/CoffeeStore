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
    public partial class frmEditTable : Form
    {
        public frmEditTable()
        {
            InitializeComponent();
        }
        //truyen data Area
        private int _areaID = 0;
        public frmEditTable(int areaID)
        {
            InitializeComponent();

            _areaID = areaID;
        }
        //truyen data Table
        private TableDTO _table = null;
        public frmEditTable(TableDTO table)
        {
            InitializeComponent();

            _table = table;
        }
        //=============LOAD DS khu vực vao ComboBox=================
        private AreaBUS areaBUS = new AreaBUS();
        private void LoadAreas()
        {
            DataTable dt = areaBUS.GetAll();
            cboAreaName.DataSource = dt;
            cboAreaName.DisplayMember = "AreaName";
            cboAreaName.ValueMember = "AreaID";
            cboAreaName.SelectedValue=_areaID;
        }

        private void frmEditTable_Load(object sender, EventArgs e)
        {
            LoadAreas();

            cboStatus.Items.Add("Empty");               //Empty: status = 0 ;   Occupied: status = 1
            cboStatus.Items.Add("Occupied");
            
            cboStatus.SelectedIndex = 0;

            if (_table == null)
            {
                cboAreaName.SelectedValue = _areaID;
            }
            else
            {
                txtTableName.Text = _table.TableName;
                cboAreaName.SelectedValue = _table.AreaID;
                cboStatus.SelectedIndex = _table.Status;
            }

        }
        TableBUS tableBUS = new TableBUS();
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTableName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên bàn");
                txtTableName.Focus();
                return;
            }
            if (_table == null)
            {
                TableDTO table = new TableDTO();
                table.TableName = txtTableName.Text.Trim();
                table.AreaID = Convert.ToInt32(cboAreaName.SelectedValue);
                table.Status = cboStatus.SelectedIndex;
                if (tableBUS.Insert(table))
                {
                    MessageBox.Show("Thêm bàn thành công");
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            else
            {
                _table.TableName = txtTableName.Text.Trim();
                _table.AreaID = Convert.ToInt32(cboAreaName.SelectedValue);
                _table.Status = cboStatus.SelectedIndex;
                if (tableBUS.Update(_table))
                {
                    MessageBox.Show("Cập nhật thành công");
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void cboAreaName_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
