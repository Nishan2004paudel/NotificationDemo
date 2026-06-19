using Microsoft.EntityFrameworkCore;
using NotificatioDemo.Models;

namespace NotificatioDemo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Notification>()
                .HasOne(n => n.User)
                .WithMany(u => u.NotificationsReceived)
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Notification>()
                .HasOne(n => n.TriggeredByUser)
                .WithMany(u => u.NotificationsTriggered)
                .HasForeignKey(n => n.TriggeredByUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<UserChoice> UserChoices { get; set; }
        public DbSet<Notification> Notifications { get; set; }

    }
}
