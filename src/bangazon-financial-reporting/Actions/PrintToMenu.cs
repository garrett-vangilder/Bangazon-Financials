using bangazon_financial_reporting.Factories;
using bangazon_financial_reporting.Helpers;
using bangazon_financial_reporting.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bangazon_financial_reporting.Actions
{
    /**
     * Class: PrintToMenu
     * Purpose: Combines needed methods for display
     * Author: Garrett Vangilder
     * Methods:
     *     
     *     void PrintReport(Dictionary<string, int> data, string type) - Data is information passed in through utility methods, string type decided the type of string to be presented, theres only two options "Sales" or "Revenue"
     *     void PrintRevenueByCustomerReport() - Performs several utility methods to create the revenue by customer report
     */
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
                        Console.WriteLine(string.Format("{0, -25}  {1, 10}.00", entry.Key, entry.Value));
                    }
                    if (type == "Revenue")
                    {
                        Console.WriteLine(string.Format("{0, -25}  {1, 10}.00", entry.Key, entry.Value));
                    }
                }
            }

        }

        public static void PrintRevenueByCustomerReport()
        {
            CustomerFactory cf = new CustomerFactory();
            List<Customer> customerList = cf.getAll();

            foreach (Customer c in customerList)
            {
                List<CustomerOrder> co = Utility.GetOrdersByCustomer(c.CustomerId);
                List<LineItem> li = Utility.GetAllLineItems(co);
                Dictionary<string, int> d = Utility.GetsRevenuePerCustomer(c.CustomerId, li);
                foreach (KeyValuePair<string, int> entry in d)
                {
                    Console.WriteLine(string.Format("{0, -25}  {1, 10}.00", entry.Key, entry.Value));
                }
            }

        }

    }
}
