using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;
using System.Data;
namespace DVLD_BuisnessLayer
{
    public class clsLicenseClass
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int LicenseClassID { set; get; }
        public string ClassName { set; get; }
        public string ClassDescription { set; get; }
        public short MinimumAllowedAge { set; get; }
        public short DefaultValidityLength { set; get; }
        public float ClassFees { set; get; }

        public clsLicenseClass()
        {
            this.LicenseClassID = -1;
            this.ClassDescription = "";
            this.ClassName = "";
            this.MinimumAllowedAge = 0;
            this.DefaultValidityLength = 0;
            this.ClassFees = 0;

            Mode = enMode.AddNew;
        }

        private clsLicenseClass(int LicenseClassID, string ClassName, string ClassDescription,
                                   short MinimumAllowedAge, short DefaultValidityLength, float ClassFees)
        {

            this.LicenseClassID = LicenseClassID;
            this.ClassName = ClassName;
            this.ClassDescription = ClassDescription;
            this.MinimumAllowedAge = MinimumAllowedAge;
            this.DefaultValidityLength = DefaultValidityLength;
            this.ClassFees = ClassFees;

            Mode = enMode.Update;
        }

        private bool _AddNewLicenseClass()
        {
            //call DataAccess Layer 

            this.LicenseClassID = clsLicenseClassData.AddNewLicenseClass(this.ClassName, this.ClassDescription, this.MinimumAllowedAge, this.DefaultValidityLength, this.ClassFees);

            return (this.LicenseClassID != -1);
        }

        private bool _UpdateLicenseClass()
        {
            //call DataAccess Layer 

            return clsLicenseClassData.UpdateLicenseClass(this.LicenseClassID,this.ClassName, this.ClassDescription, this.MinimumAllowedAge, this.DefaultValidityLength, this.ClassFees);
        }

        public static clsLicenseClass FindByClassName(string ClassName)
        {
          
            int LicenseClassID = -1;
            string ClassDescription = "";
            short MinimumAllowedAge = 0;
            short DefaultValidityLength = 0;
            float ClassFees = 0;

            bool IsFound = clsLicenseClassData.GetLicenseClassInfoByClassName
                                (ClassName,ref LicenseClassID, ref ClassDescription,
                                    ref MinimumAllowedAge, ref DefaultValidityLength,ref ClassFees);

            if (IsFound)
                //we return new object of that person with the right data
                return new clsLicenseClass(LicenseClassID,ClassName,ClassDescription,MinimumAllowedAge,DefaultValidityLength, ClassFees);
            else
                return null;
        }
        public static clsLicenseClass FindByID(int LicenseClassID)
        {
            string ClassName = "";
            string ClassDescription = "";
            short MinimumAllowedAge = 0;
            short DefaultValidityLength = 0;
            float ClassFees = 0;

            bool IsFound = clsLicenseClassData.GetLicenseClassInfoByID
                                (LicenseClassID, ref ClassName, ref ClassDescription,
                                    ref MinimumAllowedAge, ref DefaultValidityLength, ref ClassFees);

            if (IsFound)
                //we return new object of that person with the right data
                return new clsLicenseClass(LicenseClassID, ClassName, ClassDescription, MinimumAllowedAge, DefaultValidityLength, ClassFees);
            else
                return null;
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLicenseClass())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateLicenseClass();

            }

            return false;
        }

        public static DataTable GetAllLicenseClass()
        {
            return clsLicenseClassData.GetAllLicenseClasses();
        }

    }
}
