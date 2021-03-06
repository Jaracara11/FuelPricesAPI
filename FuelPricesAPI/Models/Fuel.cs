using System.ComponentModel.DataAnnotations;

namespace FuelPricesAPI.Models
{
    public class Fuel
    {
        public static string UrlFuel = "https://www.micm.gob.do/direcciones/combustibles";

        public string FuelPremium { get; set; }

        public string FuelRegular { get; set; }

    }

}
