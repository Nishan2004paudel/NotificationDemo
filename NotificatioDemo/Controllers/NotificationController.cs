using Microsoft.AspNetCore.Mvc;
using NotificatioDemo.Services;


namespace NotificatioDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly NotificationService _notificationService;

        public NotificationController(NotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet("{userId}")]
        public IActionResult GetNotifications(int userId)
        {
            var notifications = _notificationService.GetNotifications(userId);

            return Ok(notifications);
        }

        [HttpPut("read/{id}")]
        public IActionResult MarkAsRead(int id)
        {
            _notificationService.MarkAsRead(id);


            return Ok(new
            {
                Message = "Notification marked as read"
            });
        }

        [HttpGet("unread/{userId}")]
        public IActionResult GetUnreadNotifications(int userId)
        {
            var notifications = _notificationService.GetUnreadNotifications(userId);

            return Ok(notifications);
        }
    }
}