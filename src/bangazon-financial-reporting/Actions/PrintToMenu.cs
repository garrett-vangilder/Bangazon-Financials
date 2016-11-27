using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bangazon_financial_reporting.Actions
{
    public class PrintToMenu
    {
        public static void PrintReport(Dictionary<string, int> data, string type)
        {
            if (data.Count == 0)
            {
                Console.WriteLine("There is not enough data avaliable to print results.");
            }
            else
            {
                foreach (KeyValuePair<string, int> entry in data)
                {
                    if (type == "Sales")
                    {
                        Console.WriteLine(string.Format("{0} raised ${1}.00 in sales.", entry.Key, entry.Value));
                    }
                    if (type == "Revenue")
                    {
                        Console.WriteLine(string.Format("{0} raised ${1}.00 in revenue.", entry.Key, entry.Value));
                    }
                }
            }

        }

    }
}
