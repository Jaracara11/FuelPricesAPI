using System.Collections.Generic;
using FuelPricesAPI.Models;
using Newtonsoft.Json;

namespace FuelPricesAPI.Services
{
    public class FormatResult
    {
        public string JsonPricesGasoline(List<string> fuelPrices)
        {
            var removeChars = new string[] { "<td>", "</td>", "Gasolina Premium", "Gasolina Regular" };

            for (var i = 0; i < fuelPrices.Count; i++)
            {
                for (var x = 0; x < removeChars.Length; x++)
                {
                    fuelPrices[i] = fuelPrices[i].Replace(removeChars[x], "");
                }
            }

            return JsonConvert.SerializeObject(new
            {
                FuelPrices = new
                {
                    GasolinaPremium = $"{fuelPrices[0]}",
                    GasolinaRegular = $"{fuelPrices[1]}"
                }
            });
        }
    }
}
