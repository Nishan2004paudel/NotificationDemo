namespace NotificatioDemo.Models
{
    public class Choice
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        //Navigation Property
        public ICollection<UserChoice> UserChoices { get; set; }
            = new List<UserChoice>();

        public ICollection<Notification> Notifications { get; set; }
            = new List<Notification>();
    }
}
