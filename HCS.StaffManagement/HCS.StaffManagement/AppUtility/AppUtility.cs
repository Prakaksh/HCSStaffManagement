using HCS.StaffManagement.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
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


        public static string ReturnDecimalPoint(float flVal, int precession)
        {
            try
            {
                return flVal.ToString("n" + precession.ToString("n" + precession.ToString()));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static UserInfo UserInfoGet(dynamic objSession)
        {
            try
            {
                UserInfo obj = new UserInfo();
                if (objSession != null)
                {
                    obj.UserID = (string)objSession["UserID"];
                    obj.OrganizationID = (string)objSession["OrganizationID"];
                    obj.UserName = (string)objSession["UserName"];
                    obj.RoleName = (string)objSession["RoleName"];
                    obj.RoleTypeID = (string)objSession["RoleTypeID"];
                }
                return obj;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GuidGet(Guid objVal)
        {
            return (objVal.ToString() != "00000000-0000-0000-0000-000000000000" ? objVal.ToString() : null);
        }

        public static string getSqlDate(string inputDate, string inputDateFormat)
        {
            DateTime date = DateTime.ParseExact(inputDate, (!string.IsNullOrEmpty(inputDateFormat) ? inputDateFormat : "dd/MM/yyyy"), CultureInfo.InvariantCulture);
            return date.ToString("yyyy/MM/dd");
        }
    }
}