using Answers.Modal;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Answers.Services.Service
{
    public interface ISortService
    {
        Task<List<Product>> PerformSort(string SortType);
    }
}