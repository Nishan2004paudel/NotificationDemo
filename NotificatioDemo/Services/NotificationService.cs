using NotificatioDemo.Data;
using NotificatioDemo.Models;

namespace NotificatioDemo.Services
{
    public class NotificationService
    {
        private readonly ApplicationDbContext _context;

        public NotificationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void UserSelectedChoice(int userId, int choiceId)
        {
            //save userchoice
            var userChoice = new UserChoice
            {
                UserId = userId,
                ChoiceId = choiceId,
                SelectedAt = DateTime.UtcNow
            };

            _context.UserChoices.Add(userChoice);


            //get actor who triggered event

            var users = _context.Users.Where(u => u.Id != userId).ToList();


            //create notifications for others
            foreach (var user in users)
            {
                var notification = new Notification
                {
                    UserId = user.Id,
                    TriggeredByUserId = userId,
                    ChoiceId = choiceId,
                    CreatedAt = DateTime.UtcNow,
                    IsRead = false
                };

                _context.Notifications.Add(notification);
            }

            _context.SaveChanges();

        }
    }
}
