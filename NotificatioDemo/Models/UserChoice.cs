namespace NotificatioDemo.Models
{
    public class UserChoice
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ChoiceId { get; set; }
        public DateTime SelectedAt { get; set; } = DateTime.UtcNow;

        public User User { get; set; } = null;
        public Choice Choice { get; set; } = null;

    }
}
