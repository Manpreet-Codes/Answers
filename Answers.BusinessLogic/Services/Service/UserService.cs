using Microsoft.AspNetCore.Mvc;
using System;

namespace Answers.Services.Service
{
    public class UserService : IUserService
    {
        public IActionResult AuthenticateUser()
        {            
            return new JsonResult(new { name = "Manpreet Singh", token = Guid.NewGuid() });
        }
    }
}