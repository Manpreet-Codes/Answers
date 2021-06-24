using Answers.Services.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Answers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class SortController : ControllerBase
    {
        private readonly ISortService _sortService;

        public SortController(ISortService sortService)
        {
            _sortService = sortService;
        }

        [HttpGet]
        public IActionResult Get(string sortoption)
        {
            try
            {
                var arr_res = Task.Run(async () => await _sortService.PerformSort(sortoption)).ConfigureAwait(false).GetAwaiter().GetResult(); ;

                return Ok(arr_res);
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
    }
}