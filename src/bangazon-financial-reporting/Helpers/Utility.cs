using bangazon_financial_reporting.Factories;
using bangazon_financial_reporting.Models;
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

        public static List<CustomerOrder> GetOrdersByDate(int numberOfDays)
        {
            CustomerOrderFactory COF = new CustomerOrderFactory();
            DateTime DesiredThreshold = DateTime.Today.AddDays(-numberOfDays);
            List<CustomerOrder> COL = COF.getAll();
            //List<CustomerOrder> COLbyDate = 
            List<CustomerOrder> COLbyDate = (
                from co in COL
                where co.DateCompleted > DesiredThreshold
                select co).ToList();
            return COLbyDate;
        }
    }
}
