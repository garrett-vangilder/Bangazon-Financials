using bangazon_financial_reporting.Factories;
using bangazon_financial_reporting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace bangazon_financial_reporting_tests
{
    public class CustomerOrderFactoryTests
    {
        [Fact]
        public void OrderFactoryCanBeCreated()
        {
            var orderFactory = new CustomerOrderFactory();
            Assert.NotNull(orderFactory);
        }

        [Fact]
        public void OrderFactoryWillGetMultipleOrdersFromDatabase()
        {
            CustomerOrderFactory factory = new CustomerOrderFactory();
            List<CustomerOrder> orders = factory.getAll();
            Assert.NotEmpty(orders);
            Assert.True(orders.Count() > 1);
            foreach (CustomerOrder order in orders)
            {
                Assert.NotNull(order.CustomerOrderId);
                Assert.NotNull(order.DateCompleted);
            }
        }
    }
}
