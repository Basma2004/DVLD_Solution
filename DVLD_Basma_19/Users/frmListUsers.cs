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
    public partial class frmListUsers : Form
    {

        private static DataTable _dtAllUsers;
        public frmListUsers()
        {
            InitializeComponent();
        }

        private void frmListUsers_Load(object sender, EventArgs e)
        {
            _dtAllUsers=clsUser.GetAllUsers();
            dgvUsersList.DataSource = _dtAllUsers;
            cbFilterBy.SelectedIndex = 0;
            lblRecordsCount.Text = dgvUsersList.Rows.Count.ToString();

            if (dgvUsersList.Rows.Count > 0)
            {
                dgvUsersList.Columns[0].HeaderText = "User ID";
                dgvUsersList.Columns[0].Width = 110;

                dgvUsersList.Columns[1].HeaderText = "Person ID";
                dgvUsersList.Columns[1].Width = 120;

                dgvUsersList.Columns[2].HeaderText = "Full Name";
                dgvUsersList.Columns[2].Width = 350;

                dgvUsersList.Columns[3].HeaderText = "UserName";
                dgvUsersList.Columns[3].Width = 120;

                dgvUsersList.Columns[4].HeaderText = "Is Active";
                dgvUsersList.Columns[4].Width = 120;

            }
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 

            switch (cbFilterBy.Text)
            {
                case "User ID":
                    FilterColumn = "UserID";
                    break;

                case "Person ID":
                    FilterColumn = "PersonID";
                    break;
                case "Full Name":
                    FilterColumn = "FullName";
                    break;
                case "User Name":
                    FilterColumn = "UserName";
                    break;
                case "Is Active":
                    FilterColumn = "IsActive";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtAllUsers.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvUsersList.Rows.Count.ToString();
                return;
            }

            if (FilterColumn != "FullName" && FilterColumn != "UserName" )
            {
                //in this case we deal with integer not string.
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            }
            else
            {
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());
            }

           
            lblRecordsCount.Text = dgvUsersList.Rows.Count.ToString();

        }
        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsActive";
            string FilterValue = cbIsActive.Text;

            switch(FilterValue)
            {
                case "All":
                    break;
                case "Yes":
                    FilterValue = "1";
                    break;
                case "No":
                    FilterValue = "0";
                    break;
            }

            if(FilterValue == "All")
            {
                _dtAllUsers.DefaultView.RowFilter = "";
            }
            else
            {
                //in this case we deal with numbers not string.
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);
            }

            lblRecordsCount.Text = _dtAllUsers.Rows.Count.ToString();
        }
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbFilterBy.Text == "Is Active")
            {
                cbIsActive.Visible = true;
                txtFilterValue.Visible = false;
                cbIsActive.Focus();
                cbIsActive.SelectedIndex = 0;
            }
            else
            {
                cbIsActive.Visible = false;
                txtFilterValue.Visible = (cbFilterBy.Text != "None");

                if (cbFilterBy.Text == "None")
                {
                    txtFilterValue.Enabled = false;
                }
                else
                    txtFilterValue.Enabled = true;


                if (txtFilterValue.Visible)
                {
                    txtFilterValue.Text = "";
                    txtFilterValue.Focus();
                }

            }
        
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo frm = new frmUserInfo((int)dgvUsersList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser();
            frm.ShowDialog();

           frmListUsers_Load(null, null);  
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser((int)dgvUsersList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

           frmListUsers_Load(null, null);  
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete User [" + dgvUsersList.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {

                if (clsUser.DeleteUser((int)dgvUsersList.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("User Deleted Successfully.");
                   frmListUsers_Load(null, null);  
                }
                else
                {
                    MessageBox.Show("User is not deleted.");
                }
            }
            lblRecordsCount.Text = dgvUsersList.Rows.Count.ToString();
        }

        private void ChangePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword((int)dgvUsersList.CurrentRow.Cells[0].Value);

            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvUsersList_DoubleClick(object sender, EventArgs e)
        {
            frmUserInfo frm = new frmUserInfo((int)dgvUsersList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            //we allow number incase person id is selected.
            if (cbFilterBy.Text == "User ID" ||cbFilterBy.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser();
            frm.ShowDialog();

           frmListUsers_Load(null, null);  
        }

        
    }
}
