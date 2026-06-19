using Microsoft.AspNetCore.Mvc;
using NotificatioDemo.DTOs;
using NotificatioDemo.Services;

namespace NotificatioDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChoiceController : ControllerBase
    {
        private readonly NotificationService _notificationService;

        public ChoiceController(NotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpPost("select")]
        public IActionResult SelectChoice(SelectChoiceDto dto)
        {
            _notificationService.UserSelectedChoice(dto.UserId, dto.ChoiceId);

            return Ok(new
            {
                Message = "Selection processed"
            }
            );

        }

    }
}
