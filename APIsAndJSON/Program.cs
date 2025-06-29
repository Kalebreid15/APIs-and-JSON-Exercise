using System;
using System.Net.Http;

namespace KanyeWest
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            var quoteGen = new QuoteGenerator(client);

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("------------------------");
                Console.WriteLine($"Kanye: {quoteGen.Kanye()}");
                Console.WriteLine($"Ron Swanson: {quoteGen.RonSwanson()}");
            }
        }
    }
}