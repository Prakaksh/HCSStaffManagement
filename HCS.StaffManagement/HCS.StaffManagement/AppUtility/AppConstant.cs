using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HCS.StaffManagement.AppUtility
{
    public static class AppConstant
    {
        public static string MonthNameGet(int monthNo) {
            try
            {
                MonthNameFull wdEnum;
                Enum.TryParse<MonthNameFull>(monthNo.ToString(), out wdEnum);
                return wdEnum.ToString();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

    }

    public enum MonthNameFull
    {
        January=1, February, March, April, May, June, July, August, September, October, November, December
    }

    public enum MonthName
    {
        Jan=1, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec
    }

    public enum DayNameFull
    {
        Sunday=1, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday
    }

    public enum DayName
    {
        Sun=1, Mon, Tue, Wed, Thu, Fri, Sat
    }
}