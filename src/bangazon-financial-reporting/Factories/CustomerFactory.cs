using bangazon_financial_reporting.Data;
using bangazon_financial_reporting.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bangazon_financial_reporting.Factories
{
    public class CustomerFactory
    {
        private static CustomerFactory _instance;
        public static CustomerFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CustomerFactory();
                }
                return _instance;
            }
        }

        public List<Customer> getAll()
        {
            DatabaseConnection conn = new DatabaseConnection();
            List<Customer> list = new List<Customer>();

            conn.execute(@"SELECT 
                CustomerId,
                FirstName, 
                LastName,
                StreetNumber,
                StreetName,
                ZipCode,
                State
                FROM Customer",
                (SqliteDataReader reader) =>
                {
                    while (reader.Read())
                    {
                        list.Add(new Customer
                        {
                            CustomerId = reader.GetInt32(0),
                            FirstName = reader[1].ToString(),
                            LastName = reader[2].ToString(),
                            StreetNumber = reader[3].ToString(),
                            StreetName = reader[4].ToString(),
                            ZipCode = reader.GetInt32(5),
                            State = reader[6].ToString(),
                        });
                    }
                });
            return list;
        }

    }
}
