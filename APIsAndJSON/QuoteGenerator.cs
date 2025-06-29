using System;
using System.Net.Http;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace KanyeWest
{
    public class QuoteGenerator
    {
        private readonly HttpClient _client;
        private readonly HashSet<string> _seenQuotes;

        public QuoteGenerator(HttpClient client)
        {
            _client = client;
            _seenQuotes = new HashSet<string>();
        }

        public string Kanye()
        {
            string quote;
            do
            {
                var response = _client.GetStringAsync("https://api.kanye.rest").Result;
                quote = JObject.Parse(response)["quote"]?.ToString();
            }
            while (!_seenQuotes.Add($"Kanye: {quote}"));

            return quote;
        }

        public string RonSwanson()
        {
            string quote;
            do
            {
                var response = _client.GetStringAsync("https://ron-swanson-quotes.herokuapp.com/v2/quotes").Result;
                var parsed = JArray.Parse(response);
                quote = parsed[0]?.ToString();
            }
            while (!_seenQuotes.Add($"Ron: {quote}"));

            return quote;
        }
    }
}