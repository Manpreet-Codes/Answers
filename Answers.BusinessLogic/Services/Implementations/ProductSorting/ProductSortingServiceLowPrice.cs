using Answers.Modal;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Answers.Services.Interfaces.ProductSorting
{
    public class ProductSortingServiceLowPrice : IProductSortingServiceLowPrice
    {
        public async Task<List<Product>> SortProductData(List<Product> products)
        {
            return products.OrderBy(x => x.price).ToList();
        }
    }
}