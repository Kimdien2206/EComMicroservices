using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECom.Services.Reports.Utility
{
    public static class TimeTruncate
    {
        public static DateTime TruncateToYearStart(DateOnly dt)
        {
            return new DateTime(dt.Year, 1, 1);
        }
        public static DateTime TruncateToMonthStart(DateOnly dt)
        {
            return new DateTime(dt.Year, dt.Month, 1);
        }
    }
}
