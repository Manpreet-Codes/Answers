using Answers.Services.Interfaces;
using Answers.Services.Interfaces.Data;
using System.Threading.Tasks;

namespace Answers.Services.Implementations
{
    public class HttpDataService : IHttpDataService
    {
        private IHttpClientServiceGet _httpClientServiceGet;

        public HttpDataService(IHttpClientServiceGet httpClientServiceGet,
            IHttpClientServicePost httpClientServicePost)
        {
            _httpClientServiceGet = httpClientServiceGet;
        }

        public async Task<string> GetRequest(string uri)
        {
            return await _httpClientServiceGet.GetRequest(uri);
        }

        public Task<string> PostRequest(string uri, string pageLoad)
        {
            throw new System.NotImplementedException();
        }
    }
}