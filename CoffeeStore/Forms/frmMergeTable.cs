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
    public partial class frmMergeTable : Form
    {
        public frmMergeTable()
        {
            InitializeComponent();
        }
        public frmMergeTable(TableDTO table)
        {
            InitializeComponent();

            currentTable = table;
        }
        #region Current
        private TableBUS tableBUS = new TableBUS();
        private TableDTO currentTable;
        public TableDTO SelectedTable { get; private set; }
        #endregion
        #region LOAD
        private void LoadTables()
        {
            List<TableDTO> tables = tableBUS.GetAllByAreaID(currentTable.AreaID);

            tables = tables.Where(x => x.Status == TableStatus.Occupied && x.TableID != currentTable.TableID).ToList();

            cboMergeTable.DataSource = tables;
            cboMergeTable.DisplayMember = "TableName";
            cboMergeTable.ValueMember = "TableID";
        }
        #endregion
        private void frmMergeTable_Load(object sender, EventArgs e)
        {
            lblCurrentTable.Text = currentTable.TableName;

            LoadTables();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (cboMergeTable.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn bàn.");
                return;
            }

            SelectedTable = (TableDTO)cboMergeTable.SelectedItem;

            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

        }
    }
}
