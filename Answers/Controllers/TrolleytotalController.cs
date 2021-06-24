using Microsoft.AspNetCore.Mvc;

namespace Answers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrolleytotalController : ControllerBase
    {
        [HttpPost]
        public IActionResult CalculateTotal(string sortoption)
        {
            return Ok();
        }

        private void CalculateTotalAmount()
        {
        }

        private void GetAllSpecialsForProducts()
        {
        }

        private void SortAllSpecialsAccordingToHighPrice()
        {
        }

        private void ApplySpecialsToPurchase()
        {
            //Resuresive apply one
            //minus the quantity
            //minus the full purchase price
            //add reduced total
            //then move to next
        }
    }
}