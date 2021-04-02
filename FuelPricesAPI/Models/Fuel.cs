
namespace FuelPricesAPI.Models
{
    public class Fuel
    {
        public static string UrlFuel = "https://www.micm.gob.do/direcciones/combustibles";
        public string GasolinaPremium { get; set; }
        public string GasolinaRegular { get; set; }
        public string GasoilOptimo { get; set; }
        public string GasoilRegular { get; set; }
        public string Kerosene { get; set; }
        public string GLP { get; set; }
        public string GasNatural { get; set; }
    }
}
