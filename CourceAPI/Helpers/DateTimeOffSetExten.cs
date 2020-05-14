using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourceAPI.Helpers
{
    public static class DateTimeOffSetExten
    {

        public static int GetCurrentAge(this DateTimeOffset timeOffset)
        {
            var currentDate = DateTime.UtcNow;
            int age = currentDate.Year - timeOffset.Year;

            return age;
        }
    }
}
