using kudapoyti.Service.Common.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kudapoyti.Service.Common.Helpers
{
    public class TimeHelper
    {
        public static DateTime GetCurrentServerTime()
        {
            return DateTime.UtcNow.AddHours(TimeConstants.UTC);
        }
    }
}
