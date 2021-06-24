using Answers.Modal;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Answers.Services.Interfaces.ProductSorting
{
    public interface IProductSortingService
    {
        Task<List<Product>> SortProductData(List<Product> products);
    }
}