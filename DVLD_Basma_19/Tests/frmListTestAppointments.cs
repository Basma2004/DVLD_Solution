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
using System.Data;
namespace DVLD_Basma_19
{

    public partial class frmListTestAppointments : Form
    {

        private static DataTable _dtAllTestAppointments ;
        private int _LocalDrivingLicenseApplicationID = -1;

        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;


        public frmListTestAppointments(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestTypeID = TestTypeID;

        }

        private void _LoadTestTypeImageAndTitle()
        {

            switch (_TestTypeID)
            {
                case clsTestType.enTestType.VisionTest:
                    {
                        lblTestType.Text = "Vision Test Appointments";
                        pbTestType.Image = Properties.Resources.Vision_512;
                        break;
                    }
                case clsTestType.enTestType.WrittenTest:
                    {
                        lblTestType.Text = "Written Test Appointments";
                        pbTestType.Image = Properties.Resources.Written_Test_512;
                        break;
                    }
                case clsTestType.enTestType.StreetTest:
                    {
                        lblTestType.Text = "Street Test";
                        pbTestType.Image = Properties.Resources.driving_test_512;
                        break;
                    }


            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmListTestAppointments_Load(object sender, EventArgs e)
        {
            _LoadTestTypeImageAndTitle();

            ctrlDrivingLicenseApplicationInfo1.LoadLocalDrivingLicenseApplicationInfo(_LocalDrivingLicenseApplicationID);

            _dtAllTestAppointments = clsTestAppointment.GetApplicationTestAppointmentsPerTestType(_LocalDrivingLicenseApplicationID, _TestTypeID);
            dgvTestAppointments.DataSource = _dtAllTestAppointments;
            lblRecordsCount.Text = dgvTestAppointments.Rows.Count.ToString();

            if (dgvTestAppointments.Rows.Count > 0)
            {
                dgvTestAppointments.Columns[0].HeaderText = "Appointment ID";
                dgvTestAppointments.Columns[0].Width = 150;

                dgvTestAppointments.Columns[1].HeaderText = "Appointment Date";
                dgvTestAppointments.Columns[1].Width = 200;

               dgvTestAppointments.Columns[2].HeaderText = "Paid Fees";
                dgvTestAppointments.Columns[2].Width = 150;

                dgvTestAppointments.Columns[3].HeaderText = "Is Locked";
                dgvTestAppointments.Columns[3].Width = 100;
            }
        }

        private void btnAddNewAppointments_Click(object sender, EventArgs e)
        {
            clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.Find(_LocalDrivingLicenseApplicationID);

            if(LocalDrivingLicenseApplication.IsThereAnActiveScheduledTest(_TestTypeID))
            {
                MessageBox.Show("Person Already have an active appointment for this test, You cannot add new appointment", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //---
            clsTest LastTest = LocalDrivingLicenseApplication.GetLastTestPerTestType(_TestTypeID);

            if (LastTest == null)
            {
                frmScheduleTest frm1 = new frmScheduleTest(_LocalDrivingLicenseApplicationID, _TestTypeID);
                frm1.ShowDialog();
                frmListTestAppointments_Load(null, null);
                return;
            }

            //if person already passed the test s/he cannot retak it.
            if (LastTest.TestResult == true)
            {
                MessageBox.Show("This person already passed this test before, you can only retake faild test", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmScheduleTest frm2 = new frmScheduleTest
                  (LastTest.TestAppointmentInfo.LocalDrivingLicenseApplicationID, _TestTypeID);
            frm2.ShowDialog();

            frmListTestAppointments_Load(null, null);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmScheduleTest frm = new frmScheduleTest(_LocalDrivingLicenseApplicationID, _TestTypeID, (int)dgvTestAppointments.CurrentRow.Cells[0].Value);

            frm.ShowDialog();
            frmListTestAppointments_Load(null, null);
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmTakeTest frm = new frmTakeTest((int)dgvTestAppointments.CurrentRow.Cells[0].Value, _TestTypeID);

            frm.ShowDialog();
            frmListTestAppointments_Load(null, null);
        }
    }
}
