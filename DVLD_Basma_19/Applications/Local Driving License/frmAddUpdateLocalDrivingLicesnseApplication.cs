using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.Classes;
using DVLD_BuisnessLayer ;

namespace DVLD_Basma_19
{
    public partial class frmAddUpdateLocalDrivingLicesnseApplication : Form
    {
        public enum enMode { AddNew = 0, Update = 1 }

        private enMode _Mode;
        private int _LocalDrivingLicesnseApplicationID = -1;
        private int _SelectedPersonID = -1;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicesnseApplication;

        public frmAddUpdateLocalDrivingLicesnseApplication()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public frmAddUpdateLocalDrivingLicesnseApplication(int ID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _LocalDrivingLicesnseApplicationID = ID;
        }
        private void _FillLicenseClassInComboBox()
        {
            DataTable dtLicenseClass = clsLicenseClass.GetAllLicenseClass();
            foreach (DataRow row in dtLicenseClass.Rows)
            {
                cbLicenseClass.Items.Add(row["ClassName"]);
            }
        }
        private void _ResetDefaultValues()
        {
            _FillLicenseClassInComboBox();

            if (_Mode == enMode.AddNew)
            {
                lblAddEdit.Text = "New Local Driving Licesnse Application";
                this.Text = "New Local Driving Licesnse Application";

                _LocalDrivingLicesnseApplication = new  clsLocalDrivingLicenseApplication();
                tpApplicatioInfo.Enabled = false;
                ctrlPersonCardWithFilter1.FilterFocus();

                cbLicenseClass.SelectedIndex = 2;
                lblFees.Text =clsApplicationType.Find((int)clsApplication.enApplicationType.NewDrivingLicense).ApplicationTypeFees.ToString();
                lblApplicationDate.Text = DateTime.Now.ToShortDateString();
                lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;
            }
            else
            {
                lblAddEdit.Text = "Update Local Driving Licesnse Application";
                this.Text = "Update Local Driving Licesnse Application";

                tpApplicatioInfo.Enabled = true;
                btnSave.Enabled = true;
            }

        }
        private void _LoadData()
        {
            _LocalDrivingLicesnseApplication = clsLocalDrivingLicenseApplication.Find(_LocalDrivingLicesnseApplicationID);
            ctrlPersonCardWithFilter1.FilterEnabled = false;

            if (_LocalDrivingLicesnseApplication == null)
            {
                MessageBox.Show("No Local Driving Licesnse Application With ID = " + _LocalDrivingLicesnseApplicationID, "User Not Found ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            //the following code will not be executed if the person was not found

            ctrlPersonCardWithFilter1.LoadPersonInfo(_LocalDrivingLicesnseApplication.ApplicationPersonID);

            lblLocalDrivingLicebseApplicationID.Text = _LocalDrivingLicesnseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblApplicationDate.Text = clsFormat.DateToShort(_LocalDrivingLicesnseApplication.ApplicationDate);
            cbLicenseClass.SelectedIndex = cbLicenseClass.FindString(_LocalDrivingLicesnseApplication.LicenseClassInfo.ClassName);
            lblFees.Text = _LocalDrivingLicesnseApplication.PaidFees.ToString() ;
            lblCreatedByUser.Text =clsUser.FindByUserID(_LocalDrivingLicesnseApplication.CreatedByUserID).UserName;
        }
        private void frmAddUpdateLocalDrivingLicesnseApplication_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (_Mode == enMode.Update)
                _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            int LicenseClassID = clsLicenseClass.FindByClassName(cbLicenseClass.Text).LicenseClassID;

            int ActiveApplicationID = clsApplication.GetActiveApplicationIDForLicenseClass(_SelectedPersonID,clsApplication.enApplicationType.NewDrivingLicense,LicenseClassID);
            
         
            if(ActiveApplicationID !=-1)
            {
                MessageBox.Show("Choose another License Class, the selected Person Already have an active application for the selected class with id=" + ActiveApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbLicenseClass.Focus();
                return;
            }

            //check if user already have issued license of the same driving  class.
            //if (clsLicense.IsLicenseExistByPersonID(ctrlPersonCardWithFilter1.PersonID, LicenseClassID))
            //{

            //    MessageBox.Show("Person already have a license with the same applied driving class, Choose diffrent driving class", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            _LocalDrivingLicesnseApplication.ApplicationPersonID = ctrlPersonCardWithFilter1.PersonID;
            _LocalDrivingLicesnseApplication.ApplicationDate = DateTime.Now;
            _LocalDrivingLicesnseApplication.ApplicationTypeID = clsApplicationType.Find((int)clsApplication.enApplicationType.NewDrivingLicense).ApplicationTypeID;
            _LocalDrivingLicesnseApplication.ApplicationStatus = clsApplication.enApplicationStatus.New;
            _LocalDrivingLicesnseApplication.ApplicationDate = DateTime.Now;
            _LocalDrivingLicesnseApplication.PaidFees = Convert.ToSingle(lblFees.Text);
            _LocalDrivingLicesnseApplication.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            _LocalDrivingLicesnseApplication.LicenseClassID = LicenseClassID;


            if (_LocalDrivingLicesnseApplication.Save())
                {
                    lblLocalDrivingLicebseApplicationID.Text = _LocalDrivingLicesnseApplication.LocalDrivingLicenseApplicationID.ToString();

                    //change form mode to update.
                    _Mode = enMode.Update;
                    lblAddEdit.Text = "Update Local Driving Licesnse Application";
                    this.Text = "Update Local Driving Licesnse Application";
                    MessageBox.Show("Data Saved Successfully .", "Saved ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                    MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tpApplicatioInfo.Enabled = true;
                tbcAddEditLocalDrivingLicenseApplication.SelectedTab = tbcAddEditLocalDrivingLicenseApplication.TabPages["tpApplicatioInfo"];
                return;
            }

            //incase of add new mode.
            if (ctrlPersonCardWithFilter1.PersonID != -1)
            {
                btnSave.Enabled = true;
                tpApplicatioInfo.Enabled = true;
                tbcAddEditLocalDrivingLicenseApplication.SelectedTab = tbcAddEditLocalDrivingLicenseApplication.TabPages["tpApplicatioInfo"];

            }
            else
            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonCardWithFilter1.FilterFocus();

            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrlPersonCardWithFilter1_OnPersonSelected(int obj)
        {
            _SelectedPersonID = obj;
        }

        private void frmAddUpdateLocalDrivingLicesnseApplication_Activated(object sender, EventArgs e)
        {
            ctrlPersonCardWithFilter1.FilterFocus();
        }
    }
}
