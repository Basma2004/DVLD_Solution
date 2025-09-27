using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;
using System.Data;

namespace DVLD_BuisnessLayer
{
    public  class clsApplicationType
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int ApplicationTypeID { set; get; }
        public string ApplicationTypeTitle { set; get; }
        public float ApplicationTypeFees { set; get; }


        public clsApplicationType()
        {
            this.ApplicationTypeID = -1;
            this.ApplicationTypeTitle = "";
            this.ApplicationTypeFees = 0;
            
            Mode = enMode.AddNew;
        }

        private clsApplicationType(int ApplicationTypeID, string ApplicationTypeTitle, float ApplicationTypeFees)
        {

            this.ApplicationTypeID = ApplicationTypeID;
            this.ApplicationTypeTitle = ApplicationTypeTitle;
            this.ApplicationTypeFees = ApplicationTypeFees;

            Mode = enMode.Update;
        }

        private bool _AddNewApplicationType()
        {
            //call DataAccess Layer 

            this.ApplicationTypeID = clsApplicationTypeData.AddNewApplicationType(this.ApplicationTypeTitle, this.ApplicationTypeFees);

            return (this.ApplicationTypeID != -1);
        }

        private bool _UpdateApplicationType()
        {
            //call DataAccess Layer 

            return clsApplicationTypeData.UpdateApplicationType(this.ApplicationTypeID, this.ApplicationTypeTitle, this.ApplicationTypeFees);
        }

        public static clsApplicationType Find(int ApplicationTypeID)
        {

            string ApplicationTypeTitle = "";
            float ApplicationTypeFees = 0;

            bool IsFound = clsApplicationTypeData.GetApplicationTypeInfoByID
                                (ApplicationTypeID, ref ApplicationTypeTitle, ref ApplicationTypeFees);

            if (IsFound)
                //we return new object of that person with the right data
                return new clsApplicationType(ApplicationTypeID, ApplicationTypeTitle, ApplicationTypeFees);
            else
                return null;
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewApplicationType())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateApplicationType();

            }

            return false;
        }

        public static DataTable GetAllApplicationsType()
        {
            return clsApplicationTypeData.GetAllApplicationTypes();
        }

        public static bool isApplicationsTypeExist(int ID)
        {
            return clsApplicationTypeData.IsApplicationTypeExist(ID);
        }

    }
}
