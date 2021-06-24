using Microsoft.AspNetCore.Mvc;

namespace Answers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            return new JsonResult(new { name = "Manpreet Singh", token = "C10B5BBF-2394-466F-B258-14D2A15421FE" });
        }
    }
}