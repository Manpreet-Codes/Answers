using Answers.Modal;
using Answers.Services.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Answers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class SortController : ControllerBase
    {
        private readonly ISortService _sortService;
        public SortController(ISortService sortService)
        {
            _sortService = sortService;
        }
        [HttpGet]
        public IActionResult Get(string sortoption)
        {
            try
            {
                var arr_res = Task.Run(async () => await _sortService.PerformSort(sortoption)).ConfigureAwait(false).GetAwaiter().GetResult(); ;

                //var result = Task.Run(async () => await GetAsync("http://dev-wooliesx-recruitment.azurewebsites.net/api/resource/products?token=eb848457-3d00-454f-9270-4490790cea30")).ConfigureAwait(false).GetAwaiter().GetResult();

                //var arr_res = JsonSerializer.Deserialize<Product[]>(result);

                //var res = Task.Run(async () => await GetSorted(sortoption, arr_res.ToList())).GetAwaiter().GetResult();

               
                return Ok(arr_res);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        public async Task<string> GetAsync(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return await reader.ReadToEndAsync();
            }
        }

        public async Task<List<Product>> GetSorted(string sortOption, List<Product> products)
        {
            switch (sortOption)
            {
                case "Low":
                    return await GetLow(products);

                case "High":
                    return await GetHigh(products);

                case "Ascending":
                    return await GetAscending(products);

                case "Descending":
                    return await GetDescending(products);

                case "Recommended":
                    return await GetRecommended(products);

                default:
                    return await GetLow(products);
            }
        }

        public async Task<List<Product>> GetLow(List<Product> products)
        {
            return products.OrderBy(x => x.price).ToList();
        }

        public async Task<List<Product>> GetHigh(List<Product> products)
        {
            return products.OrderByDescending(x => x.price).ToList();
        }

        public async Task<List<Product>> GetAscending(List<Product> products)
        {
            return products.OrderBy(x => x.name).ToList();
        }

        public async Task<List<Product>> GetDescending(List<Product> products)
        {
            return products.OrderByDescending(x => x.name).ToList();
        }

        public async Task<List<Product>> GetRecommended(List<Product> products)
        {
            List<Product> SortedProducts = new List<Product>();
            var result = await GetAsync("http://dev-wooliesx-recruitment.azurewebsites.net/api/resource/shopperHistory?token=eb848457-3d00-454f-9270-4490790cea30");
            var arr_res = JsonSerializer.Deserialize<ShoppingHistory[]>(result);

            var res = await GetCustomerProductsFromShoppingHistory(arr_res.ToList());

            //  var grp = res.GroupBy(x => x).ToDictionary(group => group.Key, group => group.ToList().Count);

            var grp2 = res.OrderByDescending(x => x.Value).Select(x => x.Key).ToList();

            grp2.ForEach(x => SortedProducts.Add(products.First(z => z.name == x)));

            SortedProducts.AddRange(products.Except(SortedProducts));

            return SortedProducts.ToList();
        }

       

        private async Task<List<KeyValuePair<string, double>>> GetCustomerProductsFromShoppingHistory(List<ShoppingHistory> shoppingHistory)
        {
            var names = shoppingHistory.SelectMany(x => x.products?.Select(z => new { z.name, z.quantity })).ToList();

            return names
                .GroupBy(x => x.name)
                .Select(g => new KeyValuePair<string, double>(g.Key, g.Sum(x => x.quantity)))
                .ToList();
        }
    }
}