using FuelPricesAPI.Models;
using FuelPricesAPI.Services;
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

        [Route("{fuel}")]
        [HttpPost]
        public async Task<string> GetFuelPrice(string fuel)
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
