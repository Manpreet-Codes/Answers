using Answers.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Answers.Services.Interfaces.ProductSorting
{
    public class ProductSortingServiceNameAscending : IProductSortingServiceNameAscending
    {
        public async Task<List<Product>> SortProductData(List<Product> products)
        {
            return products.OrderBy(x => x.name).ToList();
        }
    }
}