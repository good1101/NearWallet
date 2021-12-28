using NearClient.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NearWallet.Utilites
{
    class Utility
    {
        public static double FormatNearDouble(UInt128 amount)
        {
            UInt128 a = 1000000000000000;
            double bl = (double)(amount / a);
            double nom = 1000000000d;
            double res = bl / nom;
            return res;
        }

        public static string FormatNearString(string amount)
        {
            UInt128 num = UInt128.Parse(amount);
            return FormatNearString(num);
        }

        public static string FormatNearString(UInt128 amount)
        {
            return FormatNearDouble(amount).ToString("0.#####", CultureInfo.InvariantCulture);
        }


        public static UInt128 GetNearFormat(double amount)
        {
            UInt128 p = new UInt128(amount * 1000000000);
            UInt128.Create(out var lp, 1000000000000000);
            var res = p * lp;
            return res;
        }
    }
}
