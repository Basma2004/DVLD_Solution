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
    public partial class frmListApplicationTypes : Form
    {
        private static DataTable _dtAllApplicationTypes;
        public frmListApplicationTypes()
        {
            InitializeComponent();
        }

        private void frmListApplicationTypes_Load(object sender, EventArgs e)
        {
            _dtAllApplicationTypes = clsApplicationType.GetAllApplicationsType();
            dgvApplicationTypeList.DataSource = _dtAllApplicationTypes;

            lblRecordsCount.Text = dgvApplicationTypeList.Rows.Count.ToString();

            if (dgvApplicationTypeList.Rows.Count > 0)
            {
                dgvApplicationTypeList.Columns[0].HeaderText = "ID";
                dgvApplicationTypeList.Columns[0].Width = 110;

                dgvApplicationTypeList.Columns[1].HeaderText = "Title";
                dgvApplicationTypeList.Columns[1].Width = 400;

                dgvApplicationTypeList.Columns[2].HeaderText = "Fees";
                dgvApplicationTypeList.Columns[2].Width = 100;

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditApplicationType frm = new frmEditApplicationType((int)dgvApplicationTypeList.CurrentRow.Cells[0].Value);

            frm.ShowDialog();

            frmListApplicationTypes_Load(null, null);
        }
    }
}
