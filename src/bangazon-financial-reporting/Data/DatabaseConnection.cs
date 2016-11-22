using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bangazon_financial_reporting.Data
{
    /**
     * Class: DatabaseConnection
     * Purpose: Connects App with DB allows for reading SQL commands
     * Author: Garrett Vangilder
     * Methods:
     *     
     *     void execute(string query, Action<SqliteDataReader> handler) - This method opens the database, executes a given command(handler) and then closes the connection
     */
    public class DatabaseConnection
    {
        private string _path = "Data Source=" + System.Environment.GetEnvironmentVariable("REPORTING_DB_PATH");

        public void execute(string query, Action<SqliteDataReader> handler)
        {
            SqliteConnection dbconn = new SqliteConnection(_path);

            dbconn.Open();
            SqliteCommand dbcmd = dbconn.CreateCommand();
            dbcmd.CommandText = query;

            using (var reader = dbcmd.ExecuteReader())
            {
                handler(reader);
            }

            dbcmd.Dispose();
            dbconn.Close();
        }
    }
}
