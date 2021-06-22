using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;
using System.Web;
using Answers.Modal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Answers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SortController : ControllerBase
    {
        [HttpGet]
        public string Get(string sortoption)
        {
            try
            {
               

                var result = Task.Run(async () => await GetAsync("http://dev-wooliesx-recruitment.azurewebsites.net/api/resource/products?token=eb848457-3d00-454f-9270-4490790cea30")).ConfigureAwait(false).GetAwaiter().GetResult();

                return result;
                var arr_res = JsonSerializer.Deserialize<Product[]>(result);

                var res = Task.Run(async () => await GetSorted(sortoption, arr_res.ToList())).GetAwaiter().GetResult();

                res = res.Replace("\"quantity\":0", "\"quantity\":0.0");
                return res;

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

        public async Task<string> GetSorted(string sortOption, List<Product> products)
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

        public async Task<string> GetLow(List<Product> products)
        {
            

           
            return JsonSerializer.Serialize(products.OrderBy(x => x.price));
        }
        public async Task<string> GetHigh(List<Product> products)
        {
            return JsonSerializer.Serialize(products.OrderByDescending(x => x.price));
        }
        public async Task<string> GetAscending(List<Product> products)
        {
            return JsonSerializer.Serialize(products.OrderBy(x => x.name));
        }
        public async Task<string> GetDescending(List<Product> products)
        {
            return JsonSerializer.Serialize(products.OrderByDescending(x => x.name));
        }
        public async Task<string> GetRecommended(List<Product> products)
        {
            List<Product> SortedProducts = new List<Product>();
            var result =  await GetAsync("http://dev-wooliesx-recruitment.azurewebsites.net/api/resource/shopperHistory?token=eb848457-3d00-454f-9270-4490790cea30");
            var arr_res = JsonSerializer.Deserialize<ShoppingHistory[]>(result);

            var res = await GetCustomerProductsFromShoppingHistory(23, arr_res.ToList());

            var grp = res.GroupBy(x => x).ToDictionary(group => group.Key, group => group.ToList().Count);

            var grp2 = grp.OrderByDescending(x => x.Value).Select(x => x.Key).ToList();

            grp2.ForEach(x => SortedProducts.Add(products.First(z => z.name == x)));

            return JsonSerializer.Serialize(SortedProducts); 
        }

        async Task<List<string>> GetCustomerProductsFromShoppingHistory(int custId, List<ShoppingHistory> shoppingHistory)
        {
            //shoppingHistory.Where(x => x.customerId == custId).SelectMany(y => y.products.Select(z => z.name).Distinct().ToList());
            return shoppingHistory.Where(c => c.customerId == custId).SelectMany(x => x.products?.Select(z => z.name)).ToList();
        }

     




    }
}