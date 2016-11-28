using bangazon_financial_reporting.Data;
using bangazon_financial_reporting.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bangazon_financial_reporting.Factories
{
    /**
     * Class: LineItemFactory
     * Purpose: Connects App with DB allows for SQL querries to grab lineitems
     * Author: Garrett Vangilder
     * Methods:
     *     
     *     List<LineItem> getAll() - grabs all lineitems from DB using SQL statement 
     */
    public class LineItemFactory
    {
        private static LineItemFactory _instance;
        public static LineItemFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LineItemFactory();
                }
                return _instance;
            }
        }

        public List<LineItem> getAll()
        {
            DatabaseConnection conn = new DatabaseConnection();
            List<LineItem> list = new List<LineItem>();

            conn.execute(@"SELECT 
                LineItemId,
                CustomerOrderId,
                ProductId
                FROM LineItem",
                (SqliteDataReader reader) =>
                {
                    while (reader.Read())
                    {
                        list.Add(new LineItem
                        {
                            LineItemId = reader.GetInt32(0),
                            CustomerOderId = reader.GetInt32(1),
                            ProductId = reader.GetInt32(2)
                        });
                    }
                });
            return list;
        }

    }
}