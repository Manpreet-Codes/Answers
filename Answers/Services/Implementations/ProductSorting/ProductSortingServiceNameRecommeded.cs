﻿using Answers.Modal;
using Answers.Services.Interfaces.Data;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Answers.Modal;
using Answers.Services.Interfaces.ShoppingProcessor;
using System.Linq;

namespace Answers.Services.Interfaces.ProductSorting
{
    
    public class ProductSortingServiceNameRecommeded : IProductSortingServiceNameRecommeded
    {
        private readonly IHttpDataService _httpDataService;
        private readonly IShoppingHistoryProcessor _shoppingHistoryProcessor;
        public ProductSortingServiceNameRecommeded(IHttpDataService httpDataService,
            IShoppingHistoryProcessor shoppingHistoryProcessor)
        {
            _httpDataService = httpDataService;
            _shoppingHistoryProcessor = shoppingHistoryProcessor;
        }

        public async Task<List<Product>> SortProductData(List<Product> products)
        {
            List<Product> SortedProducts = new List<Product>();

            var shopppingHistory =  await _httpDataService.GetRequest("http://dev-wooliesx-recruitment.azurewebsites.net/api/resource/shopperHistory?token=eb848457-3d00-454f-9270-4490790cea30");

            var arr_shphistory = JsonSerializer.Deserialize<ShoppingHistory[]>(shopppingHistory);

            var res_prods = await _shoppingHistoryProcessor.ProcessShoppingHistoryForProductOccurance(arr_shphistory.ToList());

            var grp2 = res_prods.OrderByDescending(x => x.Value).Select(x => x.Key).ToList();

            grp2.ForEach(x => SortedProducts.Add(products.First(z => z.name == x)));

            SortedProducts.AddRange(products.Except(SortedProducts));

            return SortedProducts.ToList();


        }
    }
}