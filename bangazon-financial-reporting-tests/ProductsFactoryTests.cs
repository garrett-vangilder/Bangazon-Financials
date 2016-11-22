using bangazon_financial_reporting.Factories;
using bangazon_financial_reporting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace bangazon_financial_reporting_tests
{
    public class ProductsFactoryTests
    {
        [Fact]
        public void ProductFactoryCanBeCreated()
        {
            var productFactory = new ProductFactory();
            Assert.NotNull(productFactory);
        }

        [Fact]
        public void ProductFactoryWillGetMultipleCustomersFromDatabase()
        {
            ProductFactory factory = new ProductFactory();
            List<Product> products = factory.getAll();
            Assert.NotEmpty(products);
            Assert.True(products.Count() > 1);
            foreach (Product product in products)
            {
                Assert.NotNull(product.ProductId);
                Assert.NotNull(product.Price);
                Assert.NotNull(product.Revenue);
            }
        }
    }
}
