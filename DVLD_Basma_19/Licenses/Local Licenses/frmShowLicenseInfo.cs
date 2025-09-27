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
    public partial class frmShowLicenseInfo : Form
    {
    

        private int _LicenseID;
        public frmShowLicenseInfo(int LicenseID)
        {
            InitializeComponent();


            _LicenseID = LicenseID;
        }

        private void frmShowLicenseInfo_Load(object sender, EventArgs e)
        {

            ctrlDriverLicenseInfo1.LoadInfo(_LicenseID);

        }
    }
}
