using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Answers.Services.Service
{
    public interface IUserService
    {
        JsonResult AuthenticateUser();
    }
}