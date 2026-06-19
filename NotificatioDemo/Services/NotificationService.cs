using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotificatioDemo.Data;
using NotificatioDemo.Models;
using NotificatioDemo.DTOs;

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

        public List<NotificationDto> GetNotifications(int userId)
        {
            var result = _context.Notifications
                .Include(n => n.TriggeredByUser)
                .Include(n => n.Choice)
                .Where(n => n.UserId == userId)
                .Select(n => new NotificationDto
                {
                    Message = $"{n.TriggeredByUser.Username} selected {n.Choice.Name}",
                    IsRead = n.IsRead,
                    CreatedAt = n.CreatedAt
                })
                .ToList();

            return result;
        }

        public void MarkAsRead(int notificationId)
        {
            var notification = _context.Notifications
                .FirstOrDefault(n => n.Id == notificationId);

            if (notification == null)
                return;

            notification.IsRead = true;

            _context.SaveChanges();
        }

        public List<NotificationDto> GetUnreadNotifications(int userId)
        {
            var result = _context.Notifications
                .Include(n => n.TriggeredByUser)
                .Include(n => n.Choice)
                .Where(n => n.UserId == userId && n.IsRead == false)
                .Select(n => new NotificationDto
                {
                    Message = $"{n.TriggeredByUser.Username} selected {n.Choice.Name}",
                    IsRead = n.IsRead,
                    CreatedAt = n.CreatedAt
                })
                .ToList();

            return result;
        }


    }
}
