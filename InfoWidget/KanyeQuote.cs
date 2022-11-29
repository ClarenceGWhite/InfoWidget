using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace InfoWidget
{
    public class KanyeQuote
    {
        public static string Quote() 
        {
            var client = new HttpClient();

            var kanyeURL = "https://api.kanye.rest/";
            var kanyeResponse = client.GetStringAsync(kanyeURL).Result;
            var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();
            return kanyeQuote;


        }

    }
}
