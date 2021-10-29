using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;
using System.Net.Http;

namespace Info_Resovler
{
    class Program
    {
        static void WriteInfo(string Header, string Text, ConsoleColor Color)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"{Header} - ");
            Console.ForegroundColor = Color;
            Console.Write($"{Text}\n");
            Console.ResetColor();
        }

        static void Main(string[] args)
        {
            using (var Client = new WebClient { Proxy = null })
            {
                var Json = JsonConvert.DeserializeObject<JToken>(Client.DownloadString("http://ip-api.com/json/"));

                WriteInfo("Ip Address", Json["query"]?.ToString(), ConsoleColor.Green);
                WriteInfo("Country", Json["country"]?.ToString(), ConsoleColor.Red);
                WriteInfo("Region", Json["regionName"]?.ToString(), ConsoleColor.Yellow);
                WriteInfo("City", Json["city"]?.ToString(), ConsoleColor.Blue);
                WriteInfo("Zip Code", Json["zip"]?.ToString(), ConsoleColor.DarkGreen);
                WriteInfo("ISP", Json["isp"]?.ToString(), ConsoleColor.Red);

                Console.ReadLine();
            }
        }
    }
}
