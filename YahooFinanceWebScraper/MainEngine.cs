using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahooFinanceWebScraper
{
    public class MainEngine
    {
        public static void Initialize()
        {
            Console.WriteLine("Welcome to the Stock Market scraper.");
            Console.WriteLine("This app scrapes Yahoo Finance for relevant data.");
            Console.WriteLine("Created by Steven Clausson.");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("version: 0.0.5");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ");
            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();
            Console.Clear();
            MarketInfo.MarketStatus();
        }
    }
}
