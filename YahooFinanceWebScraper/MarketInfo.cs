using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using static System.Net.WebRequestMethods;

namespace YahooFinanceWebScraper
{
    public class MarketInfo
    {
        HtmlWeb web = new HtmlWeb();
        public static void MarketStatus()
        {

            var html = @"https://finance.yahoo.com/";
            var ticker = @"https://finance.yahoo.com/quote/%5EDJI/";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Loading Stock Market data...");
            Console.ForegroundColor = ConsoleColor.White;
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(ticker);
            var htmlDoc2 = web.Load(html);
            var stock = htmlDoc.DocumentNode.SelectSingleNode("//html/body/div[1]/main/section/section/section/article/section[1]/div[2]/div[1]/section/div/section/div[1]/fin-streamer[1]/span");
            var marketStatus = htmlDoc2.DocumentNode.SelectSingleNode("//html/body/div[1]/main/aside/section/div[1]/div/div[1]/section/div[2]/div/span");
            Console.WriteLine($"The Dow Jones Industrial Average today is: ${stock.InnerText}");
            Console.WriteLine(marketStatus.InnerText);
            Console.WriteLine(" ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Data finished loading.");
            Console.ForegroundColor= ConsoleColor.White;
            Console.WriteLine(" ");
            StockCheck();
        }

        public static void StockCheck()
        {
            Console.WriteLine("If you would like to look at a particular stock, please enter the symbol below and press Enter: ");
            Console.Write("Some good stocks to watch are:");
            Console.ForegroundColor = ConsoleColor.Blue;
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
                HtmlWeb web = new HtmlWeb();
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
                    Console.WriteLine("Type EXIT to end program");
                    Console.WriteLine("Type RETURN to return to main screen.");
                    string userChoice;
                    userChoice = Console.ReadLine().ToUpper();
                    if (userChoice != null)
                        if (userChoice == "EXIT")
                        {
                            Console.Read();
                        }
                        else if (userChoice == "RETURN")
                        {
                            MarketStatus();
                        }
                    else
                        {
                            Console.WriteLine("I'm sorry, what?");
                            StockCheck();
                        }
                }
                else
                {
                    Console.WriteLine("That's not a stock Symbol.");
                    StockCheck();
                }
                    

            }
        }
    }
}
