using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bangazon_financial_reporting.Actions
{
    public class PrintToMenu
    {
        public static void PrintSalesReport(Dictionary<string, int> data)
        {
            if (data.Count == 0)
            {
                Console.WriteLine("There is not enough data avaliable to print results.");
            }
            else
            {
                foreach (KeyValuePair<string, int> entry in data)
                {
                    Console.WriteLine(string.Format("{0} raised ${1}.00 in sales.", entry.Key, entry.Value));
                }
            }

        }

    }
}
