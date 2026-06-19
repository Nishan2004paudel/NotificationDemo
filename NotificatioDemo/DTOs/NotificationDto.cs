namespace NotificatioDemo.DTOs
{
    public class NotificationDto
    {
        public string Message { get; set; } = string.Empty;
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}