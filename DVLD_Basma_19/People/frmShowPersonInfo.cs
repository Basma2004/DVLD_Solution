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
    public partial class frmShowPersonInfo : Form
    {


        // Declare a delegate
        public delegate void DataBackEventHandler(object sender, int PersonID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;

        public frmShowPersonInfo(int personID)
        {
            InitializeComponent();

            ctrlPersonCard1.LoadPersonInfo(personID);
        }

        private void frmShowPersonInfo_Load(object sender, EventArgs e)
        {
            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Trigger the event to send data back to the caller form.
            DataBack?.Invoke(this, ctrlPersonCard1.PersonID);
            this.Close();
        }

        private void ctrlPersonCard1_Load(object sender, EventArgs e)
        {

        }
    }
}
