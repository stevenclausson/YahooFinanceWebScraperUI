using HtmlAgilityPack;
using System;
using System.Net.Http;
using static System.Net.WebRequestMethods;
namespace YahooFinanceWebScraper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            var html = @"https://finance.yahoo.com/";
            var ticker = @"https://finance.yahoo.com/quote/%5EDJI/";
 
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
            Console.WriteLine("Loading Stock Market data...");
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(ticker);
            var htmlDoc2 = web.Load(html);
            var stock = htmlDoc.DocumentNode.SelectSingleNode("//html/body/div[1]/main/section/section/section/article/section[1]/div[2]/div[1]/section/div/section/div[1]/fin-streamer[1]/span");
            var marketStatus = htmlDoc2.DocumentNode.SelectSingleNode("//html/body/div[1]/main/aside/section/div[1]/div/div[1]/section/div[2]/div/span");
            Console.WriteLine($"The Dow Jones Industrial Average today is: ${stock.InnerText}");
            Console.WriteLine(marketStatus.InnerText);
            Console.WriteLine(" ");
            Console.WriteLine("Data finished loading.");
            Console.WriteLine(" ");
            Console.WriteLine("If you would like to look at a particular stock, please enter the symbol below and press Enter: ");
            Console.Write("Some good stocks to watch are:");
            Console.ForegroundColor= ConsoleColor.Blue;
            Console.WriteLine(" GOLD, NVDA, DJT");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Enter the symbol you would like to look up.");
            string userTicker;
            userTicker = Console.ReadLine().ToUpper();
            if (userTicker != null)
            {
                Console.Clear();
                Console.WriteLine("Data loading...");
                var userLookup = @"https://finance.yahoo.com/quote/" + userTicker;
                var userHtml = web.Load(userLookup);
                var userDisplayTicker = userHtml.DocumentNode.SelectSingleNode("//html/body/div[1]/main/section/section/section/article/section[1]/div[2]/div[1]/section/div/section[1]/div[1]/fin-streamer[1]/span");
                if (userDisplayTicker != null) 
                {
                    Console.WriteLine(" ");
                    Console.Write($"{userTicker} current price is ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"$ {userDisplayTicker.InnerText}");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" ");
                    Console.WriteLine("Press any key to quit.");
                    Console.ReadLine();
                }
                else 
                    Console.WriteLine("That's not a stock Symbol. Goodbye.");
            }
            else
                Console.WriteLine("That's a terrible stock.");
                Console.ReadLine();
        }
    }
}
