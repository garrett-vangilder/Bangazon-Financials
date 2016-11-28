using bangazon_financial_reporting.Data;
using bangazon_financial_reporting.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bangazon_financial_reporting.Helpers;

namespace bangazon_financial_reporting.Factories
{
    /**
     * Class: CustomerOrderFactory
     * Purpose: Connects App with DB allows for SQL querries to grab orders
     * Author: Garrett Vangilder
     * Methods:
     *     
     *     List<CustomerOrder> getAll() - grabs all orders from DB using SQL statement 
     */
    public class CustomerOrderFactory
    {
        private static CustomerOrderFactory _instance;
        public static CustomerOrderFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CustomerOrderFactory();
                }
                return _instance;
            }
        }

        public List<CustomerOrder> getAll()
        {
            DatabaseConnection conn = new DatabaseConnection();
            List<CustomerOrder> list = new List<CustomerOrder>();

            conn.execute(@"SELECT 
                CustomerOrderId,
                CustomerId,
                DateCompleted 
                FROM CustomerOrder",
                (SqliteDataReader reader) =>
                {
                    while (reader.Read())
                    {
                        list.Add(new CustomerOrder
                        {
                            CustomerOrderId = reader.GetInt32(0),
                            CustomerId =reader.GetInt32(1),
                            DateCompleted = Utility.ParseDateMethod(reader[2].ToString())
                        });
                    }
                });
            return list;
        }

    }
}