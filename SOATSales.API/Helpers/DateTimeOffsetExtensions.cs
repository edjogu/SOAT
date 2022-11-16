using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOATSales.API.Helpers
{
    public static class DateTimeOffsetExtensions
    {
        public static int GetCurrentDateForExpitation(this DateTimeOffset dateTimeOffset)
        {
            var currentDate = DateTime.UtcNow;
            int period = currentDate.Year - dateTimeOffset.Year;

            if (currentDate < dateTimeOffset.AddYears(period))
            {
                period--;
            }

            return period;
        }
    }
}
