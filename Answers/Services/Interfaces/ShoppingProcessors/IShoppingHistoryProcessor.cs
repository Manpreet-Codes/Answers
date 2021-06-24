using Answers.Modal;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Answers.Services.Interfaces.ShoppingProcessor
{
    public interface IShoppingHistoryProcessor
    {
        Task<List<KeyValuePair<string, double>>> ProcessShoppingHistoryForProductOccurance(List<ShoppingHistory> shoppingHistory);
    }
}