using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentService.Dtos;
using PaymentService.Services;

namespace PaymentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            this.paymentService = paymentService;
        }

        [HttpPost]
        public async Task<IActionResult> MakePayment([FromBody] PaymentCreateDto dto)
        {
            var result = await paymentService.MakePaymentAsync(dto);
            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result);
        }
    }
}
