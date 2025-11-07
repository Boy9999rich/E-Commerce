using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotificationService.Dtos;
using NotificationService.Services;

namespace NotificationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService notificationService;

        public NotificationController(INotificationService notificationService)
        {
            this.notificationService = notificationService;
        }

        [HttpPost("send")]

        public async Task<IActionResult> SendNotification([FromBody] NotificationCreateDto dto)
        {
            await notificationService.SendNotificationAsync(dto);
            return Ok(new { Message = "Xabar yuborildi" });
        }
    }
}
