using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BuisnessLayer;
using Microsoft.Win32;
using System.Diagnostics;
namespace DVLD.Classes
{
    internal static class clsGlobal
    {
        public static clsUser CurrentUser;
        public static bool RememberUsernameAndPassword(string Username, string Password)
        {

            string KeyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD_Login";

            string UserNamename = "Username";
            string PasswordName = "Password";

            try
            {
                //Write the value to the Registry
                Registry.SetValue(KeyPath, UserNamename, Username, RegistryValueKind.String);

                Registry.SetValue(KeyPath, PasswordName, Password, RegistryValueKind.String);
            }
            catch (Exception ex)
            {
                string sourceName = "DVLD_Basma";

                //Create the event source if it does not exist 
                if (!EventLog.SourceExists(sourceName))
                {
                    EventLog.CreateEventSource(sourceName, "Application");
                }

                // Log an Error event
                EventLog.WriteEntry(sourceName, ex.ToString(), EventLogEntryType.Error);

                return false;
            }
            return true;
        }

        public static bool GetStoredCredential(ref string Username, ref string Password)
        {
            //this will get the stored username and password and will return true if found and false if not found.
            string KeyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD_Login";


            string UserNamename = "Username";
            string PasswordName = "Password";
            try
            {
                // Read the value from the Registry

                Username = Registry.GetValue(KeyPath, UserNamename, null) as string;
                Password = Registry.GetValue(KeyPath, PasswordName, null) as string;


            }
            catch (Exception ex)
            {
                string sourceName = "DVLD_Basma";

                //Create the event source if it does not exist 
                if (!EventLog.SourceExists(sourceName))
                {
                    EventLog.CreateEventSource(sourceName, "Application");
                }

                // Log an Error event
                EventLog.WriteEntry(sourceName, ex.ToString(), EventLogEntryType.Error);
                return false;
            }

            return true;
        }
    }
}
