using Microsoft.AspNetCore.Mvc;

namespace Answers.Services.Service
{
    public interface IUserService
    {
        JsonResult AuthenticateUser();
    }
}