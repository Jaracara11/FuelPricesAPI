using System.Collections.Generic;
using System.Text.RegularExpressions;
using FuelPricesAPI.Services;
using FuelPricesAPI.Models;
using System.Text.Json;
using HtmlAgilityPack;
using System.Linq;

namespace FuelPricesAPI.Service
{
    public class JsonService
    {
        public static string ReturnFuelPrices(string responseHtml)
        {
            var htmlDoc = new HtmlDocument();
            var fuelList = new List<string>();
            var rgx = new Regex(RegexService.MatchPrices);

            htmlDoc.LoadHtml(responseHtml);

            HtmlNode[] htmlNode = htmlDoc.DocumentNode.SelectNodes("//tr").ToArray();

            foreach (HtmlNode item in htmlNode)
            {
                MatchCollection matches = rgx.Matches(item.InnerHtml);

                foreach (Match match in matches)
                {
                    fuelList.Add(match.Value);
                }
            }

            var fuelPrices = new Fuel()
            {
                GasolinaPremium = fuelList[0],
                GasolinaRegular = fuelList[1],
                GasoilOptimo = fuelList[2],
                GasoilRegular = fuelList[3],
                Kerosene = fuelList[4],
                GLP = fuelList[5],
                GasNatural = fuelList[6]
            };

            var jsonResponse = JsonSerializer.Serialize(fuelPrices);

            return jsonResponse;
        }
    }
}
