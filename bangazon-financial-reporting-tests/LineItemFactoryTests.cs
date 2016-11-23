using bangazon_financial_reporting.Factories;
using bangazon_financial_reporting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace bangazon_financial_reporting_tests
{
    public class LineItemFactoryTests
    {
        [Fact]
        public void LineItemFactoryCanBeCreated()
        {
            var lineItemFactory = new LineItemFactory();
            Assert.NotNull(lineItemFactory);
        }

        [Fact]
        public void LineItemFactoryCanGetSeveralLineItemsFromDatabase()
        {
            LineItemFactory factory = new LineItemFactory();
            List<LineItem> lineItems = factory.getAll();
            Assert.NotEmpty(lineItems);
            Assert.True(lineItems.Count() > 1);
            foreach (LineItem lineItem in lineItems)
            {
                Assert.NotNull(lineItem.CustomerOderId);
                Assert.NotNull(lineItem.ProductId);
            }
        }
    }
}
