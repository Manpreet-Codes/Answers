using Answers.Modal;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Answers.Services.Interfaces.ShoppingProcessors
{
    public interface IProductProcessor
    {
        Task<List<Product>> ProcessProducts();
    }
}