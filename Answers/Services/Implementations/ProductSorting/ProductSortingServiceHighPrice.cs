using Answers.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Answers.Services.Interfaces.ProductSorting
{
    public class ProductSortingServiceHighPrice : IProductSortingServiceHighPrice
    {
        public async Task<List<Product>> SortProductData(List<Product> products)
        {
            return products.OrderByDescending(x => x.price).ToList();
        }
    }
}