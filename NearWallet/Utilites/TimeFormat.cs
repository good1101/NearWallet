using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NearWallet.Utilites
{
    class TimeFormat
    {
        const float COUNT_DAY = 365.2425f;
        public static string GetViewTime(DateTime eventTime)
        {
            TimeSpan span = DateTime.UtcNow - eventTime;
            string result = "";
            if ((int)(span.TotalDays / COUNT_DAY) > 0)
                result = $"{(int)(span.TotalDays / COUNT_DAY)}yer";
            else if ((int)(span.TotalDays / 30) > 0)
                result = $"{(int)(span.TotalDays / 30)}mth";
            else if ((int)span.TotalDays > 0)
                result = $"{(int)span.TotalDays}d";
            else if ((int)span.TotalHours > 0)
                result = $"{(int)span.TotalHours}hr";
            else if ((int)span.TotalMinutes > 0)
                result = $"{(int)span.TotalMinutes}m";
            else
                result = $"{(int)span.TotalSeconds}s";
            result += " ago";
            return result;
        }
    }
}
