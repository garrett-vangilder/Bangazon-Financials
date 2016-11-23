using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bangazon_financial_reporting.Helpers
{
    public class Utility
    {
        public static DateTime ParseDateMethod(string date)
        {
            var array = new int[3];
            array[0] = Int32.Parse(date.Substring(0, 4));
            array[1] = Int32.Parse(date.Substring(4, 2));
            array[2] = Int32.Parse(date.Substring(6, 2));
            return new DateTime(array[0], array[1], array[2]);
        }
    }
}
