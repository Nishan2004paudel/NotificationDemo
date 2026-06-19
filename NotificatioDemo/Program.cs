using Azure.Identity;
using Microsoft.EntityFrameworkCore;
using NotificatioDemo.Data;
using System.ComponentModel.DataAnnotations;
using NotificatioDemo.Models;
using NotificatioDemo.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<NotificationService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();



    if (!context.Users.Any())
    {
        var users = new List<User>
        {
            new User {Username = "Ram", Email = "ram@test.com", PasswordHash = "x"},
            new User {Username = "Hari", Email="hari@test.com", PasswordHash = "x"},
            new User {Username = "Sita", Email="sita@test.com",PasswordHash="x"},
            new User {Username="Gita",Email="gita@test.com",PasswordHash="x"},
            new User {Username= "Nishan",Email="nishan@test.com",PasswordHash="x"}
        };

        context.Users.AddRange(users);
        context.SaveChanges();
    }

    if (!context.Choices.Any())
    {
        var choices = new List<Choice>
        {
            new Choice {Name  = "Pizza", Description ="Chessy food"},
            new Choice {Name = "Burger", Description= "Fast food"},
            new Choice {Name = "Cricket", Description= "Outdoor sport"}
        };

        context.Choices.AddRange(choices);
        context.SaveChanges();
    }

}



app.Run();