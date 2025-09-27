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
    
    public partial class frmScheduleTest : Form
    {
        private int _LocalDrivingLicenseApplicationID=-1;
        private int _AppointmentID=-1;
        private clsTestType.enTestType _TestTypeID=clsTestType.enTestType.VisionTest;

        public frmScheduleTest(int LocalDrivingLicenseApplicationID, clsTestType.enTestType TestTypeID, int AppointmentID = -1)
        {                     
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _AppointmentID = AppointmentID;
            _TestTypeID = TestTypeID;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmScheduleTest_Load(object sender, EventArgs e)
        {
            ctrlSecheduledTest1.TestTypeID = _TestTypeID;
            ctrlSecheduledTest1.LoadInfo(_LocalDrivingLicenseApplicationID, _AppointmentID);
        }
    }
}
