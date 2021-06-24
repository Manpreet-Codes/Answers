using Answers.Modal;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Answers.Services.Interfaces.ShoppingProcessor
{
    public class ShoppingHistoryProcessor : IShoppingHistoryProcessor
    {
        public async Task<List<KeyValuePair<string, double>>> ProcessShoppingHistoryForProductOccurance(List<ShoppingHistory> shoppingHistory)
        {
            var names = shoppingHistory.SelectMany(x => x.products?.Select(z => new { z.name, z.quantity })).ToList();

            return names
                .GroupBy(x => x.name)
                .Select(g => new KeyValuePair<string, double>(g.Key, g.Sum(x => x.quantity)))
                .ToList();
        }
    }
}