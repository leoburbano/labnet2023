using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace Practica3.EF.MVC.Models
{
    public class BreakingBadService
    {
        private readonly WebClient _webClient;

        public BreakingBadService()
        {
            _webClient = new WebClient();
            _webClient.BaseAddress = "https://api.breakingbadquotes.xyz/v1/";
        }


        public List<BreakingBadQuoteModel> GetRandomQuotes(int count)
        {
            List<BreakingBadQuoteModel> quotes = new List<BreakingBadQuoteModel>();

            for (int i = 0; i < count; i++)
            {
                string responseContent = _webClient.DownloadString("quotes");
                BreakingBadQuoteModel quote = JsonConvert.DeserializeObject<List<BreakingBadQuoteModel>>(responseContent)[0];

                quotes.Add(quote);
            }

            return quotes;
        }
    }
}