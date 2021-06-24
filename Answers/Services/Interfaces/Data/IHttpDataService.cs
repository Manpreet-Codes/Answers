using System.Threading.Tasks;

namespace Answers.Services.Interfaces.Data
{
    public interface IHttpDataService
    {
        Task<string> GetRequest(string uri);

        Task<string> PostRequest(string uri, string pageLoad);
    }
}