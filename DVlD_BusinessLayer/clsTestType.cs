using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccessLayer;
using System.Data;

namespace DVLD_BuisnessLayer
{
    public class clsTestType
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public enum enTestType { VisionTest=1,WrittenTest=2,StreetTest=4}
        public enTestType TestTypeID { set; get; }
        public string TestTypeTitle { set; get; }
        public string TestTypeDescription { set; get; }
        public float TestTypeFees { set; get; }


        public clsTestType()
        {
            this.TestTypeID = enTestType.VisionTest;
            this.TestTypeTitle = "";
            this.TestTypeDescription = "";
            this.TestTypeFees = 0;

            Mode = enMode.AddNew;
        }

        private clsTestType(enTestType TestTypeID, string TestTypeTitle ,string TestTypeDescription, float TestTypeFees)
        {

            this.TestTypeID = TestTypeID;
            this.TestTypeTitle = TestTypeTitle;
            this.TestTypeDescription = TestTypeDescription;
            this.TestTypeFees = TestTypeFees;

            Mode = enMode.Update;
        }

        private bool _AddNewTestType()
        {
            //call DataAccess Layer 

            this.TestTypeID =(enTestType) clsTestTypeData.AddNewTestType(this.TestTypeTitle,this.TestTypeDescription, this.TestTypeFees);

            return (this.TestTypeTitle != "");
        }

        private bool _UpdateTestType()
        {
            //call DataAccess Layer 

            return clsTestTypeData.UpdateTestType((int)this.TestTypeID, this.TestTypeTitle,this.TestTypeDescription ,this.TestTypeFees);
        }

        public static clsTestType Find(enTestType TestTypeID)
        {

            string TestTypeTitle = "", TestTypeDescription="";
            float TestTypeFees = 0;

            bool IsFound = clsTestTypeData.GetTestTypeInfoByID
                                ((int)TestTypeID, ref TestTypeTitle,ref TestTypeDescription, ref TestTypeFees);

            if (IsFound)
                //we return new object of that person with the right data
                return new clsTestType(TestTypeID, TestTypeTitle,TestTypeDescription, TestTypeFees);
            else
                return null;
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTestType())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateTestType();

            }

            return false;
        }

        public static DataTable GetAllApplicationsType()
        {
            return clsTestTypeData.GetAllTestTypes();
        }

        public static bool isApplicationsTypeExist(int ID)
        {
            return clsTestTypeData.IsTestTypeExist(ID);
        }

    }
}
