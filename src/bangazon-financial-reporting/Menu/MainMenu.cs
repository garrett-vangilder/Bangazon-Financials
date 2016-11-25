using bangazon_financial_reporting.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bangazon_financial_reporting.Menu
{
    public class MainMenu
    {
        public static void ReadInput()
        {
            string input = null;
            while (input != "X")
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
                        Utility.GetAllLineItems(Utility.GetOrdersByDate(7));
                        break;
                    case "2":
                        Console.WriteLine("Last Month Report");
                        Utility.GetAllLineItems(Utility.GetOrdersByDate(30));
                        break;
                    case "3":
                        Console.WriteLine("Last 3 months Report");
                        Utility.GetAllLineItems(Utility.GetOrdersByDate(90));
                        break;
                    case "4":
                        Console.WriteLine("Revenue by customer");
                        break;
                    case "5":
                        Console.WriteLine("Revenue by product");
                        break;
                    case "X":
                        Console.WriteLine("Goodbye");
                        break;
                    default:
                        Console.WriteLine("This does not match any given option. Try again,");
                        input = Console.ReadLine();
                        break;
                }


            }
        }
    }
}
