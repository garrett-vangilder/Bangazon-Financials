using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.Sqlite;
using bangazon_financial_reporting.Menu;

namespace BangazonProductRevenueReports
{
    /**
     * Class: Program
     * Purpose: Allows user to execute application
     * Author: Garrett Vangilder
     * Methods:
     *     
     *     void Main(string[] args) - prints main menu to user
     */
    public class Program
    {
        public static void Main(string[] args)
        {
            MainMenu.ReadInput();
        }
    }
}