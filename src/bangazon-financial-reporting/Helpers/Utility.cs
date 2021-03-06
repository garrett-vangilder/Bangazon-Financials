﻿using bangazon_financial_reporting.Factories;
using bangazon_financial_reporting.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace bangazon_financial_reporting.Helpers
{
    /**
     * Class: Utility
     * Purpose: Used to organize utility based methods
     * Notes: 
     * Methods: 
     *  DateTime ParseDateMethod(string date) - Parses date from DB to console
     *  List<CustomerOrder> GetOrdersByDate(int numberOfDays) - Used within option 1,2,3 is used to eliminate unneeded orders pending on given date.
     *  List<CustomerOrder> GetOrdersByCustomer(int customerId) - Accepts a customerId and returns all orders designated to that customer. Is used in tandem with the GetOrdersByDate method
     *  Dictionary<string, int> GetsRevenuePerCustomer(int customerId, List<LineItem> LIByCustomer) - Signature accepts a customerId, then uses this id to post it to a the returned dictionary. Loops over lineItems and adds them to a revenue total.
     *  List<LineItem> GetAllLineItems(List<CustomerOrder> COL) - Gets all lineItems per list of orders.
     *  Dictionary<string, int> TurnLineItemsToSalesProducts(List<LineItem> LI) - Loops over list of LineItems and collects the information to find the sale total per product.
     *  string GetCustomerNameById(int customerId) - Querries the DB using LINQ statements to find the customers first and last name.
     *  
     * Author: Garrett Vangilder
     */
    public class Utility
    {
        public static DateTime ParseDateMethod(string date)
        {
            var array = new int[3];
            array[0] = Int32.Parse(date.Substring(0, 4));
            array[1] = Int32.Parse(date.Substring(4, 2));
            array[2] = Int32.Parse(date.Substring(6, 2));
            return new DateTime(array[0], array[1], array[2]);
        }

        public static List<CustomerOrder> GetOrdersByDate(int numberOfDays)
        {
            CustomerOrderFactory COF = new CustomerOrderFactory();
            DateTime DesiredThreshold = DateTime.Today.AddDays(-numberOfDays);
            List<CustomerOrder> COL = COF.getAll();
            List<CustomerOrder> COLbyDate = (
                from co in COL
                where co.DateCompleted > DesiredThreshold
                select co).ToList();
            return COLbyDate;
        }

        public static List<CustomerOrder> GetOrdersByCustomer(int customerId)
        {
            CustomerOrderFactory COF = new CustomerOrderFactory();
            List<CustomerOrder> COL = COF.getAll();
            List<CustomerOrder> DesiredCustomerOrders = (
                from co in COL
                where co.CustomerId == customerId
                select co).ToList();
            return DesiredCustomerOrders;
        }

        public static Dictionary<string, int> GetsRevenuePerCustomer(int customerId, List<LineItem> LIByCustomer)
        {
            int totalRevenue = 0;
            string nameOfCustomer = GetCustomerNameById(customerId);
            Dictionary<string, int> d = new Dictionary<string, int>();

            foreach (LineItem li in LIByCustomer)
            {
                ProductFactory pf = new ProductFactory();
                Product chosenProduct = pf.get(li.ProductId);
                totalRevenue = totalRevenue + chosenProduct.Price;
            };

            d.Add(nameOfCustomer, totalRevenue);
            return d;
        }

        public static List<LineItem> GetAllLineItems(List<CustomerOrder> COL)
        {
            List<LineItem> LIL = new List<LineItem>();
            LineItemFactory LIF = new LineItemFactory();
            List<LineItem> AllLineItems = LIF.getAll();

            foreach (CustomerOrder co in COL)
            {
                List<LineItem> lineItemsInOrder = (
                    from li in AllLineItems
                    where li.CustomerOderId == co.CustomerOrderId
                    select li
                    ).ToList();
                if (lineItemsInOrder.Count > 0)
                {
                    LIL.AddRange(lineItemsInOrder);
                }
            }
            return LIL;
        }

        public static Dictionary<string, int> TurnLineItemsToSalesProducts(List<LineItem> LI)
        {
            Dictionary<int, int> d = new Dictionary<int, int>();
            Dictionary<string, int> e = new Dictionary<string, int>();

            ProductFactory pf = new ProductFactory();
            List<Product> allProducts = pf.getAll();

            foreach (LineItem li in LI)
            {
                Product product =
                    (from p in allProducts
                     where p.ProductId == li.ProductId
                     select p).FirstOrDefault();

                if (!d.ContainsKey(li.ProductId))
                {
                    d.Add(li.ProductId, 0);
                    e.Add(product.Name, product.Price);
                }
                else
                {
                    foreach (KeyValuePair<string, int> pair in e)
                    {
                        if (pair.Key == product.Name)
                        {
                            e[product.Name] = pair.Value + product.Price;
                            break;
                        }
                    }
                }
            }
            return e;
        }

        public static Dictionary<string, int> TurnLineItemsToRevenueProducts(List<LineItem> LI)
        {
            Dictionary<int, int> d = new Dictionary<int, int>();
            Dictionary<string, int> e = new Dictionary<string, int>();

            ProductFactory pf = new ProductFactory();
            List<Product> allProducts = pf.getAll();

            foreach (LineItem li in LI)
            {
                Product product =
                    (from p in allProducts
                     where p.ProductId == li.ProductId
                     select p).FirstOrDefault();

                if (!d.ContainsKey(li.ProductId))
                {
                    d.Add(li.ProductId, 0);
                    e.Add(product.Name, product.Revenue);
                }
                else
                {
                    foreach (KeyValuePair<string, int> pair in e)
                    {
                        if (pair.Key == product.Name)
                        {
                            e[product.Name] = pair.Value + product.Revenue;
                            break;
                        }
                    }
                }
            }
            return e;
        }

        public static string GetCustomerNameById(int customerId)
        {
            CustomerFactory cf = new CustomerFactory();
            List<Customer> allCustomers = cf.getAll();

            Customer customer =
                (from c in allCustomers
                 where c.CustomerId == customerId
                 select c).FirstOrDefault();

            return $"{customer.FirstName} {customer.LastName}";
        }
    }
}
