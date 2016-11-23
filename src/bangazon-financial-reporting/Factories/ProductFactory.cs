using bangazon_financial_reporting.Data;
using bangazon_financial_reporting.Models;
using Microsoft.Data.Sqlite;
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
        public List<Product> getAll()
        {
            DatabaseConnection conn = new DatabaseConnection();
            List<Product> list = new List<Product>();

            conn.execute(@"SELECT 
                ProductId,
                Name, 
                Price,
                Revenue
                FROM Product",
                (SqliteDataReader reader) =>
                {
                    while (reader.Read())
                    {
                        list.Add(new Product
                        {
                            ProductId = reader.GetInt32(0),
                            Name = reader[1].ToString(),
                            Price = reader.GetInt32(2),
                            Revenue = reader.GetInt32(3)
                        });
                    }
                });
            return list;
        }
    }
}
