using FuelPricesAPI.Models;
using FuelPricesAPI.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;
namespace FuelPricesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetFuelPrices()
        {
            var client = new HttpClient();
            
            try
            {
                var response = await client.GetStringAsync(Fuel.UrlFuel);

                return Ok(JsonService.ReturnFuelPrices(response));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
