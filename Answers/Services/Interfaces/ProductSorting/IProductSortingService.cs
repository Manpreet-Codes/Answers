using Answers.Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Answers.Services.Interfaces.ProductSorting
{
    public interface IProductSortingService
    {
        Task<List<Product>> SortProductData(List<Product> products);
    }
}
