using Microsoft.AspNetCore.Mvc;

namespace Answers.Services.Service
{
    public interface IUserService
    {
        IActionResult AuthenticateUser();
    }
}