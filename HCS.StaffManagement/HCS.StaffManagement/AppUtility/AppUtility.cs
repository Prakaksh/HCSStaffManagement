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
    }
}