using System.ComponentModel.DataAnnotations;

namespace FuelPricesAPI.Models
{
    public class Fuel
    {
        public static string UrlFuel = "https://www.micm.gob.do/direcciones/combustibles";

        public TypeFuel Type { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,0}")]
        public decimal Price { get; set; }
    }

    public enum TypeFuel
    {
        Regular,
        Premium
    }
}
