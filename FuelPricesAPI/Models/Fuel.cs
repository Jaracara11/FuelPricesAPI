using System.ComponentModel.DataAnnotations;

namespace FuelPricesAPI.Models
{
    public class Fuel
    {
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
