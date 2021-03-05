using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FuelPricesAPI.Services
{
    public class ScrapPage
    {
        public string ScrapResult { get; set; }

        public string PriceFuel(string html)
        {
            var htmlDoc = new HtmlDocument();

            htmlDoc.LoadHtml(html);

            HtmlNode[] htmlNode = htmlDoc.DocumentNode.SelectNodes("//tbody").ToArray();

            List<string> resultHtml = new List<string>();

            foreach (HtmlNode item in htmlNode)
            {
                resultHtml.Add(item.InnerHtml);    
            }

            return ScrapResult = resultHtml.ToString();
        }
    }
}
