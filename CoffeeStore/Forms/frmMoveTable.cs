using CoffeeStore.BUS;
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
    public partial class frmMoveTable : Form
    {
        public frmMoveTable()
        {
            InitializeComponent();          
        }
        public frmMoveTable(TableDTO table)
        {
            InitializeComponent();
            currentTable = table;
        }

        #region Current State
        private TableDTO currentTable;
        private TableBUS tableBUS = new TableBUS();
        public TableDTO SelectedTable { get; private set; }

        private List<TableDTO> tableList;
        #endregion

        #region Load
        private void LoadTables()
        {
            tableList = tableBUS.GetAllByAreaID(currentTable.AreaID);
            tableList= tableList.Where(x => x.Status == TableStatus.Empty &&x.TableID != currentTable.TableID).ToList();
            cboTable.DataSource = tableList;
            cboTable.DisplayMember = "TableName";
            cboTable.ValueMember = "TableID";
        }
        #endregion
        private void frmMoveTable_Load(object sender, EventArgs e)
        {
            lblTable.Text =currentTable.TableName;
            LoadTables();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (cboTable.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn bàn.");
                return;
            }

            SelectedTable = (TableDTO)cboTable.SelectedItem;

            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
