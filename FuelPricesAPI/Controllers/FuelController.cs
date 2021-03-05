using FuelPricesAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FuelPricesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelController : ControllerBase
    {
        ScrapPage sp = new ScrapPage();

        [HttpGet]
        public async Task<string> GetFuelPrice()
        {
            var urlFuel = "https://www.micm.gob.do/direcciones/combustibles";

            HttpClient client = new HttpClient();

            var response = await client.GetStringAsync(urlFuel);

            sp.PriceFuel(response);

            return sp.ScrapResult;
        }
    }
}
