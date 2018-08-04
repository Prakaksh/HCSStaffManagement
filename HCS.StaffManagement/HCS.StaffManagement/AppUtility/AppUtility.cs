using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace HCS.StaffManagement.AppUtility
{
    public static class AppUtility
    {
        public static string AppSettingsGet(string appKey)
        {
            try
            {
                return ConfigurationManager.AppSettings[appKey].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string ConnectionStringsGet(string name)
        {
            try
            {
                return ConfigurationManager.ConnectionStrings[name].ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string getStatus(int val)
        {
            string str = "";
            switch (val)
            {
                case 0:
                    str = "failure";
                    break;
                case 1:
                    str = "success";
                    break;
                case 2:
                    str = "exist";
                    break;
                case 3:
                    str = "update";
                    break;
                default:
                    str = "failure";
                    break;
            }
            return str;
        }

    }
}