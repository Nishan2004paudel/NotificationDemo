using System.Xml.Serialization;

namespace NotificatioDemo.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TriggeredByUserId { get; set; }
        public int ChoiceId { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public User User { get; set; } = null!;
        public User TriggeredByUser { get; set; } = null!;

        public Choice Choice { get; set; } = null!;
    }
}
