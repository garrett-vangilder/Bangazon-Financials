using bangazon_financial_reporting.Factories;
using bangazon_financial_reporting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace bangazon_financial_reporting_tests
{
    public class CustomerFactoryTests
    {
        [Fact]
        public void CustomerFactoryCanBeCreated()
        {
           var customerFactory = new CustomerFactory();
            Assert.NotNull(customerFactory);
        }

        [Fact]
        public void CustomerFactoryWillGetMultipleCustomersFromDatabase()
        {
            CustomerFactory factory = new CustomerFactory();
            List<Customer> customers = factory.getAll();
            Assert.NotEmpty(customers);
            Assert.True(customers.Count() > 1);
            foreach (Customer customer in customers)
            {
                Assert.NotNull(customer.CustomerId);
                Assert.NotNull(customer.FirstName);
                Assert.NotNull(customer.LastName);
            }
        }
    }
}
