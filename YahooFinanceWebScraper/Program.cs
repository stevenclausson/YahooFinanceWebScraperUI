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
            Console.WriteLine("Welcome to the Dow Jones Industrial Average watcher.");
            Console.WriteLine("This app was created by Steven Clausson.");
            Console.WriteLine(" ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("version: 1.0.0");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();
            Console.Clear();
            var ticker = @"https://finance.yahoo.com/quote/%5EDJI/";
            var html = @"https://finance.yahoo.com/";
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(ticker);
            var htmlDoc2 = web.Load(html);
            var stock = htmlDoc.DocumentNode.SelectSingleNode("//html/body/div[1]/main/section/section/section/article/section[1]/div[2]/div[1]/section/div/section/div[1]/fin-streamer[1]/span");
            var marketStatus = htmlDoc2.DocumentNode.SelectSingleNode("//html/body/div[1]/main/aside/section/div[1]/div/div[1]/section/div[2]/div/span");
            Console.WriteLine($"The Dow Jones Industrial Average today is: ${stock.InnerText}");
            Console.WriteLine(marketStatus.InnerText);
            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }
    }
}
