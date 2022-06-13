using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace ReportQA.Utils
{
    public class Utils
    {
        public static DateTime? ConvertDateFromString(string inputDate, string format = "yyyy-MM-dd")
        {
            DateTime? result = (DateTime?)null;

            try
            {
                DateTime tempdate;
                if (DateTime.TryParseExact(inputDate, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out tempdate))
                {
                    result = tempdate;
                }
            }
            catch (Exception e)
            {
                return result;
            }
            return result;
        }
    }
}