using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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
