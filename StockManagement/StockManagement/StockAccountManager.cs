using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using Json.Net;
using System.Runtime.Serialization.Json;

namespace StockManagement
{
    class StockAccountManager
    {
        public static string file = @"C:\Users\ADVANCED\Desktop\Day 11 & 12 Assignment\StockManagement\StockManagement\stocks.json";
        public int userOption;
        static List<StocksInput> stocksAccount = new List<StocksInput>();
        public static void AddingStocks()
        {
            Console.WriteLine("Enter The Stock Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("\n");
            Console.WriteLine("Enter The Number Of Stock: ");
            int numberOfShares = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n");
            Console.WriteLine("Enter The Price Of Stock: ");
            double priceOfShares = double.Parse(Console.ReadLine());
            Console.WriteLine("\n");
            string data = File.ReadAllText(file);
            var returndata = JsonConvert.DeserializeObject<List<StocksInput>>(data);
            StocksInput stocks = new StocksInput { Name = name, NumberOfShares = numberOfShares, PriceOfShares = priceOfShares, totalPriceofShares = (priceOfShares * numberOfShares) };
            stocksAccount.Add(stocks);
            if(returndata != null)
            {
                foreach(var item in returndata)
                {
                    StocksInput stocks1 = new StocksInput
                    {
                        Name = item.Name,
                        NumberOfShares = item.NumberOfShares,
                        PriceOfShares = item.PriceOfShares,
                        totalPriceofShares = (item.PriceOfShares * item.NumberOfShares)
                    };
                    stocksAccount.Add(stocks1);
                }
            }
            string jsonFile = JsonConvert.SerializeObject(stocksAccount);
            File.WriteAllText(file, jsonFile);
            Console.WriteLine(name +" Added Successfully.");
        }

        public static void DisplayStocks()
        {
            int start = 1;
            double totalInvestedStocks = 0;

            string data = File.ReadAllText(file);
            List<StocksInput> returndata = JsonConvert.DeserializeObject<List<StocksInput>>(data);
            Console.WriteLine("STOCKS: ");
            foreach(var item in returndata)
            {
                Console.WriteLine("Stock {0}",start);
                Console.WriteLine("#######################################");
                Console.WriteLine("Stock Name: {0}",item.Name);
                Console.WriteLine("Stock Prize: {0}",item.PriceOfShares);
                Console.WriteLine("Stock Quantity: {0}",item.NumberOfShares);
                Console.WriteLine("Total Price Of Stock: {0}",item.totalPriceofShares);
                Console.WriteLine("#######################################");
                totalInvestedStocks += item.totalPriceofShares;
                start++;
            }
            Console.WriteLine("##################################");
            Console.WriteLine("Total Investment In Stocks: {0}",totalInvestedStocks);
            Console.WriteLine("##################################");
        }
        public StockAccountManager()
        {
            Console.WriteLine("Enter Your Option:");
            Console.WriteLine("\n1. Add Stock\n2. Display Stock\n3. Exit");
            userOption = Convert.ToInt32(Console.ReadLine());
            switch(userOption)
            {
                case 1:
                    AddingStocks();
                    Console.WriteLine("To Enter More Stocks Select Option: \n1. Add More.\n2. You Are Ok With Adding Only One Stock.\n3. Exit");
                    int option = int.Parse(Console.ReadLine());
                    switch(option)
                    {
                        case 1:
                            Console.WriteLine("You Selected To Add More.");
                            Console.WriteLine("Enter The Number Of Stocks You Want To Add More: ");
                            AddingStocks();
                            break;
                        case 2:
                            Console.WriteLine("Thank You!");
                            Console.WriteLine("\nYou Are Ok With Adding Only One Stock");
                            StockAccountManager stockAccountManager = new StockAccountManager();
                            break;
                        case 3:
                            Console.WriteLine("Exit");
                            StockAccountManager stockAccountManager1 = new StockAccountManager();
                            break;
                        default:
                            Console.WriteLine("Invalid Input");
                            break;
                    }
                    break;

                case 2:
                    DisplayStocks();
                    break;
                case 3:
                    Console.WriteLine("Exit");
                    break;
                default:
                    Console.WriteLine("Invalid Input. Try Again");
                    StockAccountManager stockAccountManager2 = new StockAccountManager();
                    break;
            }
        }
    }
}
