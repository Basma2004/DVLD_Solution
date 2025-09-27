using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BuisnessLayer;
namespace DVLD_Basma_19
{
    public partial class frmListTestTypes : Form
    {
        private static DataTable _dtAllTestTypes;
        public frmListTestTypes()
        {
            InitializeComponent();
        }

        private void frmListTestTypes_Load(object sender, EventArgs e)
        {
            
            _dtAllTestTypes = clsTestType.GetAllApplicationsType();
            dgvTestTypeList.DataSource = _dtAllTestTypes;

            lblRecordsCount.Text = dgvTestTypeList.Rows.Count.ToString();

            if (dgvTestTypeList.Rows.Count > 0)
            {
                dgvTestTypeList.Columns[0].HeaderText = "ID";
                dgvTestTypeList.Columns[0].Width = 120;

                dgvTestTypeList.Columns[1].HeaderText = "Title";
                dgvTestTypeList.Columns[1].Width = 200;

                dgvTestTypeList.Columns[2].HeaderText = "Description";
                dgvTestTypeList.Columns[2].Width = 400;

                dgvTestTypeList.Columns[3].HeaderText = "Fees";
                dgvTestTypeList.Columns[3].Width = 100;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditTestType frm = new frmEditTestType((clsTestType.enTestType)dgvTestTypeList.CurrentRow.Cells[0].Value);

            frm.ShowDialog();

            frmListTestTypes_Load(null, null);
        }
    }
}
