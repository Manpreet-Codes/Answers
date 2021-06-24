using Microsoft.AspNetCore.Mvc;
using System;

namespace Answers.Services.Service
{
    public class UserService : IUserService
    {
        public JsonResult AuthenticateUser()
        {
            return new JsonResult(new { name = "Manpreet Singh", token = new Guid().ToString() });
        }
    }
}