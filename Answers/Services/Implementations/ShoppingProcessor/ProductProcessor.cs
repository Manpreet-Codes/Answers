using Answers.Modal;
using Answers.Services.Interfaces.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Answers.Services.Interfaces.ShoppingProcessors
{
    public class ProductProcessor : IProductProcessor
    {
        private readonly IHttpDataService _httpDataService;

        public ProductProcessor(IHttpDataService httpDataService)
        {
            _httpDataService = httpDataService;
        }

        public async Task<List<Product>> ProcessProducts()
        {
            var result = await _httpDataService.GetRequest("http://dev-wooliesx-recruitment.azurewebsites.net/api/resource/products?token=eb848457-3d00-454f-9270-4490790cea30");

            var arr_res = JsonSerializer.Deserialize<Product[]>(result);

            return arr_res.ToList();
        }
    }
}