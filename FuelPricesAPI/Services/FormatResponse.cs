using System.Collections.Generic;
using System.Text.RegularExpressions;
using FuelPricesAPI.Services;
using Newtonsoft.Json;
using FuelPricesAPI.Models;

namespace FuelPricesAPI.Service
{
    public class FormatResponse
    {
        public static string ReturnFuelPrices(List<string> htmlResult)
        {
            Fuel jsonPrices = new Fuel();

            var fuelList = new List<string>();
            var rgx = new Regex(RegexPattern.MatchPrices);

            foreach (var item in htmlResult)
            {
                MatchCollection matches = rgx.Matches(item);

                foreach (Match match in matches)
                {
                    fuelList.Add(match.Value);
                }
            }

            jsonPrices.GasolinaPremium = fuelList[0];
            jsonPrices.GasolinaRegular = fuelList[1];
            jsonPrices.GasoilOptimo = fuelList[2];
            jsonPrices.GasoilRegular = fuelList[3];
            jsonPrices.Kerosene = fuelList[4];
            jsonPrices.GLP = fuelList[5];
            jsonPrices.GasNatural = fuelList[6];

            var jsonResponse = JsonConvert.SerializeObject(jsonPrices);

            return jsonResponse;
        }
    }
}
