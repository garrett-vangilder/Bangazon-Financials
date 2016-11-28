using bangazon_financial_reporting.Actions;
using bangazon_financial_reporting.Helpers;
using bangazon_financial_reporting.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bangazon_financial_reporting.Menu
{
    /**
     * Class: MainMenu
     * Purpose: Physically prints the MainMenu to the console depending on the switch statement
     * Notes: Switch statement 1) - Last Week Report
     * 2.) - Last Month Report
     * 3.) - Last 3 Month Report
     * 4.) - Revenue by Customer 
     * 5.) - Revenue by Product
     * X.) - Ends program
     * Author: Garrett Vangilder
     */
    public class MainMenu
    {
        public static void ReadInput()
        {
            string input = null;
            while (input != "X" || input != "x")
            {
                Console.WriteLine("==========================" + "\n" +"BANGAZON FINANCIAL REPORTS" + "\n" + "========================== ");
                Console.WriteLine(); // Empty line.
                Console.WriteLine(); // Empty line.
                Console.WriteLine("1 - Last Week Report");
                Console.WriteLine("2 - Last Month Report");
                Console.WriteLine("3 - Last 3 months Report");
                Console.WriteLine("4 - Revenue by customer");
                Console.WriteLine("5 - Revenue by product");
                Console.WriteLine("X - close");
                Console.WriteLine(); // Empty line.
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.WriteLine("Last Week Report");
                        Console.WriteLine("=============================================");
                        Console.WriteLine(string.Format("{0, -25}  {1, 10}", "Product", "Value"));
                        Console.WriteLine("=============================================");
                        Dictionary<string, int> LWR = Utility.TurnLineItemsToSalesProducts(Utility.GetAllLineItems(Utility.GetOrdersByDate(7)));
                        PrintToMenu.PrintReport(LWR, "Sales");
                        Console.WriteLine(); // Empty line.
                        break;

                    case "2":
                        Console.WriteLine("Last Month Report");
                        Console.WriteLine("=============================================");
                        Console.WriteLine(string.Format("{0, -25}  {1, 10}", "Product", "Value"));
                        Console.WriteLine("=============================================");
                        Dictionary<string, int> LMR = Utility.TurnLineItemsToSalesProducts(Utility.GetAllLineItems(Utility.GetOrdersByDate(30)));
                        PrintToMenu.PrintReport(LMR, "Sales");
                        Console.WriteLine(); // Empty line.
                        break;

                    case "3":
                        Console.WriteLine("Last 3 months Report");
                        Console.WriteLine("=============================================");
                        Console.WriteLine(string.Format("{0, -25}  {1, 10}", "Product", "Value"));
                        Console.WriteLine("=============================================");
                        Dictionary<string, int> L3MR = Utility.TurnLineItemsToSalesProducts(Utility.GetAllLineItems(Utility.GetOrdersByDate(90)));
                        PrintToMenu.PrintReport(L3MR, "Sales");
                        Console.WriteLine(); // Empty line.
                        break;

                    case "4":
                        Console.WriteLine("Revenue by customer");
                        Console.WriteLine("=============================================");
                        Console.WriteLine(string.Format("{0, -25}  {1, 10}", "Customer", "Revenue"));
                        Console.WriteLine("=============================================");
                        PrintToMenu.PrintRevenueByCustomerReport();
                        Console.WriteLine(); // Empty line.
                        break;

                    case "5":
                        Console.WriteLine("Revenue by product");
                        Console.WriteLine("=============================================");
                        Console.WriteLine(string.Format("{0, -25}  {1, 10}", "Product", "Revenue"));
                        Console.WriteLine("============================================="); Dictionary<string, int> RP= Utility.TurnLineItemsToRevenueProducts(Utility.GetAllLineItems(Utility.GetOrdersByDate(3650)));
                        PrintToMenu.PrintReport(RP, "Revenue");
                        Console.WriteLine(); // Empty line.
                        break;

                    case "x":
                    case "X":
                        Console.WriteLine("Goodbye");
                        return;

                    default:
                        Console.WriteLine("This does not match any given option. Press any key to continue.");
                        input = Console.ReadLine();
                        Console.WriteLine(); // Empty line.
                        break;

                }
            }
        }
    }
}
