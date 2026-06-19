namespace NotificatioDemo.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public ICollection<Notification> NotificationsReceived { get; set; }
            = new List<Notification>();

        public ICollection<Notification> NotificationsTriggered { get; set; }
            = new List<Notification>();
    }
}
