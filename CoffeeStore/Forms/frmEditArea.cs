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
    public partial class frmEditArea : Form
    {
        private AreaBUS areaBUS = new AreaBUS();
        private AreaDTO _area;
        public frmEditArea()
        {
            InitializeComponent();
        }
        public frmEditArea(AreaDTO area)
        {
            InitializeComponent();
            
            _area = area;
        }
        

        private void frmEditArea_Load(object sender, EventArgs e)
        {
            AcceptButton = btnSave;
            txtAreaName.Focus();
            if (_area != null)
            {
                txtAreaName.Text =
                    _area.AreaName;

                txtDescription.Text =
                    _area.Description;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAreaName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khu vực");
                return;
            }

            AreaDTO area = new AreaDTO();

            area.AreaName = txtAreaName.Text.Trim();
            area.Description = txtDescription.Text.Trim();

            bool result = false;

            if (_area == null)
            {
                result = areaBUS.Insert(area);
            }
            else
            {
                area.AreaID = _area.AreaID;

                result = areaBUS.Update(area);
            }

            if (result)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Lưu thất bại");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
