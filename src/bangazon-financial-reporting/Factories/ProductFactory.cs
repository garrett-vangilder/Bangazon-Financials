using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bangazon_financial_reporting.Factories
{
    public class ProductFactory
    {
        private static ProductFactory _instance;
        public static ProductFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ProductFactory();
                }
                return _instance;
            }
        }
    }
}
