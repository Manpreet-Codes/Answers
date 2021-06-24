using System.Threading.Tasks;

namespace Answers.Services.Interfaces
{
    public interface IHttpClientServiceGet
    {
        Task<string> GetRequest(string Url);    
    }
}