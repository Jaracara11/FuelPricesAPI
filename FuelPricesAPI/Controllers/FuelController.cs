using FuelPricesAPI.Models;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
namespace FuelPricesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelController : ControllerBase
    {
        [HttpGet]
        public async Task<List<string>> GetFuelPrices()
        {
            var client = new HttpClient();
            var response = await client.GetStringAsync(Fuel.UrlFuel);
            var htmlDoc = new HtmlDocument();
            var resultHtml = new List<string>();

            htmlDoc.LoadHtml(response);

            HtmlNode[] htmlNode = htmlDoc.DocumentNode.SelectNodes("//tbody").ToArray();

            foreach (HtmlNode item in htmlNode)
            {
                resultHtml.Add(item.InnerHtml);
            }

            return resultHtml;
        }
    }
}
