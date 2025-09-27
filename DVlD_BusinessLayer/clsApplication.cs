using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;
using System.Data;
namespace DVLD_BuisnessLayer
{
    public class clsApplication
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public enum enApplicationType { NewDrivingLicense=1,RenewDrivingLicense=3,ReplaceLostDrivingLicense=4,
            ReplaceDamagedDrivingLicense=5,ReleaseDetainedDrivingLicsense=7,NewInternationalLicense=8,RetakeTest=9};

        public enum enApplicationStatus { New=1,Cancelled=2,Completed=4};

        public string ApplicantFullName
        {
            get
            {
                return PersonInfo.FullName;
            }
        }
        public int ApplicationID { set; get; }
        public int ApplicationPersonID { set; get; }
        public DateTime ApplicationDate { set; get; }
        public int ApplicationTypeID { set; get; }
        public enApplicationStatus ApplicationStatus { set; get; }

        public string StatusText
        {
            get
            {
                switch (ApplicationStatus)
                {
                    case enApplicationStatus.New:
                        return "New";
                    case enApplicationStatus.Cancelled:
                        return "Cancelled";
                    case enApplicationStatus.Completed:
                        return "Completed";
                    default:
                        return "Unknown";
                }
            }
        }
        public DateTime LastStatusDate { set; get; }
        public float PaidFees { set; get; }
        public int CreatedByUserID { set; get; }

        public clsPerson PersonInfo;
        public clsApplicationType ApplicationTypeInfo;
        public clsUser CreatedUserInfo;

        public clsApplication()

        {
            this.ApplicationID = -1;
            this.ApplicationPersonID = -1;
            this.ApplicationDate = DateTime.Now;
            this.ApplicationTypeID = -1;
            this.ApplicationStatus = enApplicationStatus.New;
            this.LastStatusDate = DateTime.Now;
            this.PaidFees = 0;
            this.CreatedByUserID =-1;
    
            Mode = enMode.AddNew;
        }

        private clsApplication(int ApplicationID, int ApplicationPersonID, DateTime ApplicationDate, int ApplicationTypeID, enApplicationStatus ApplicationStatus,
                                 DateTime LastStatusDate, float PaidFees, int CreatedByUserID)

        {
            this.ApplicationID = ApplicationID;
            this.ApplicationPersonID = ApplicationPersonID;
            this.ApplicationDate = ApplicationDate;
            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationStatus = ApplicationStatus;
            this.LastStatusDate = LastStatusDate;
            this.PaidFees = PaidFees;
            this.CreatedByUserID = CreatedByUserID;
           
            this.PersonInfo = clsPerson.Find(ApplicationPersonID);
            this.ApplicationTypeInfo= clsApplicationType.Find(ApplicationTypeID);
            this.CreatedUserInfo = clsUser.FindByUserID(CreatedByUserID);

            Mode = enMode.Update;
        }

        private bool _AddNewApplication()
        {
            //call DataAccess Layer 

            this.ApplicationID = clsApplicationData.AddNewApplication(
                this.ApplicationPersonID, this.ApplicationDate, this.ApplicationTypeID, 
                (byte)this.ApplicationStatus,this.LastStatusDate, this.PaidFees, this.CreatedByUserID);

            return (this.ApplicationID != -1);
        }

        private bool _UpdateApplication()
        {
            //call DataAccess Layer 

            return clsApplicationData.UpdateApplication(
                this.ApplicationID,this.ApplicationPersonID, this.ApplicationDate, this.ApplicationTypeID,
                (byte)this.ApplicationStatus, this.LastStatusDate, this.PaidFees, this.CreatedByUserID);
        }

        public static clsApplication Find(int ApplicationID)
        {

            int ApplicationPersonID = -1;
            DateTime ApplicationDate = DateTime.Now;
            int ApplicationTypeID = -1;
            byte ApplicationStatus = 1;
            DateTime LastStatusDate = DateTime.Now;
            float PaidFees = 0;
            int CreatedByUserID = -1;

            bool IsFound = clsApplicationData.GetApplicationInfoByID
                                (
                                    ApplicationID, ref ApplicationPersonID, ref ApplicationDate,
                                    ref ApplicationTypeID, ref ApplicationStatus, ref LastStatusDate, 
                                    ref PaidFees, ref CreatedByUserID);

            if (IsFound)
                //we return new object of that person with the right data
                return new clsApplication(ApplicationID,ApplicationPersonID,ApplicationDate,
                                    ApplicationTypeID,(enApplicationStatus)ApplicationStatus ,LastStatusDate,
                                    PaidFees,  CreatedByUserID);
            else
                return null;
        }
        public bool Cancel()
        {
            return clsApplicationData.UpdateStatus(ApplicationID, 2);
        }
        public bool SetComplete()
        {
            return clsApplicationData.UpdateStatus(ApplicationID, 3);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewApplication())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateApplication();

            }

            return false;
        }

        public static DataTable GetAllApplications()
        {
            return clsApplicationData.GetAllApplications();
        }

        public  bool Delete()
        {
            return clsApplicationData.DeleteApplication(this.ApplicationID);
        }

        public static bool isApplicationExist(int ID)
        {
            return clsApplicationData.IsApplicationExist(ID);
        }


        public static bool DoesPersonHaveActiveApplication(int PersonID, int ApplicationTypeID)
        {
            return clsApplicationData.DoesPersonHaveActiveApplication(PersonID, ApplicationTypeID);
        }

        public bool DoesPersonHaveActiveApplication(int ApplicationTypeID)
        {
            return DoesPersonHaveActiveApplication(this.ApplicationPersonID, ApplicationTypeID);
        }

        public static int GetActiveApplicationID(int PersonID, clsApplication.enApplicationType ApplicationTypeID)
        {
            return clsApplicationData.GetActiveApplicationID(PersonID, (int)ApplicationTypeID);
        }

        public static int GetActiveApplicationIDForLicenseClass(int PersonID, clsApplication.enApplicationType ApplicationTypeID, int LicenseClassID)
        {
            return clsApplicationData.GetActiveApplicationIDForLicenseClass(PersonID, (int)ApplicationTypeID, LicenseClassID);
        }
        
        public int GetActiveApplicationID(clsApplication.enApplicationType ApplicationTypeID)
        {
            return GetActiveApplicationID(this.ApplicationPersonID, ApplicationTypeID);
        }

    }
}
