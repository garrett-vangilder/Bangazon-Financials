using bangazon_financial_reporting.Factories;
using bangazon_financial_reporting.Helpers;
using bangazon_financial_reporting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace bangazon_financial_reporting_tests
{
    public class UtilityTests
    {
        [Fact]
        public void ParseDateMethodReturnsProperlyFormatedStrings()
        {
            string date = "20161005";
            DateTime newDate = Utility.ParseDateMethod(date);
            DateTime oldDate = new DateTime(2016, 10, 05);
            Assert.Equal(newDate, oldDate);
        }

        [Fact]
        public void GetOrdersByCustomerIdReturnsOnlyOrdersCorrespondingToTheCustomerId()
        {
            List<CustomerOrder> desiredOrders = Utility.GetOrdersByCustomer(1);
            Assert.NotEmpty(desiredOrders);
        }
    }
}
