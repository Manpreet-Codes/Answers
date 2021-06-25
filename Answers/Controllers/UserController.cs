using Answers.Services.Service;
using Microsoft.AspNetCore.Mvc;

namespace Answers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return _userService.AuthenticateUser();
        }
    }
}