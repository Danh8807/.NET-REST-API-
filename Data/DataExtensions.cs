using Microsoft.EntityFrameworkCore;
using StudyAbroadApi.Models;
namespace StudyAbroadApi.Data;


public static class DataExtensions
{
   public static void MigrateDb(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        dbContext.Database.Migrate();
    }
    public static void AddGameStoreDb(this WebApplicationBuilder builder)
    {
        var connString = builder.Configuration.GetConnectionString("DefaultConnection") ?? "Data Source=studyabroad.db";
            builder.Services.AddSqlite<AppDbContext>(
            connString,
        optionsAction: options => options.UseSeeding((context, _) =>
        {
        if (!context.Set<University>().Any())
        {
            context.Set<University>().AddRange(
                new University { Id = 1, Name = "MIT", State = "Massachusetts", AcceptanceRate = "4%", MinGPA = 3.9, MinSAT = 1500, Major = "Engineering, Computer Science", Tier = "Ivy+" },
                new University { Id = 2, Name = "Stanford University", State = "California", AcceptanceRate = "4%", MinGPA = 3.9, MinSAT = 1500, Major = "Technology, Business", Tier = "Ivy+" },
                new University { Id = 3, Name = "Harvard University", State = "Massachusetts", AcceptanceRate = "5%", MinGPA = 3.9, MinSAT = 1500, Major = "Liberal Arts, Law, Medicine", Tier = "Ivy+" },
                new University { Id = 4, Name = "UC Berkeley", State = "California", AcceptanceRate = "14%", MinGPA = 3.7, MinSAT = 1400, Major = "Engineering, Business", Tier = "Top 20" },
                new University { Id = 5, Name = "University of Michigan", State = "Michigan", AcceptanceRate = "17%", MinGPA = 3.7, MinSAT = 1360, Major = "Engineering, Business", Tier = "Top 20" },
                new University { Id = 6, Name = "NYU", State = "New York", AcceptanceRate = "21%", MinGPA = 3.6, MinSAT = 1350, Major = "Business, Arts, Law", Tier = "Top 30" },
                new University { Id = 7, Name = "University of Texas at Austin", State = "Texas", AcceptanceRate = "31%", MinGPA = 3.5, MinSAT = 1300, Major = "Engineering, Business", Tier = "Top 50" },
                new University { Id = 8, Name = "Purdue University", State = "Indiana", AcceptanceRate = "49%", MinGPA = 3.3, MinSAT = 1250, Major = "Engineering, Agriculture", Tier = "Top 50" },
                new University { Id = 9, Name = "Arizona State University", State = "Arizona", AcceptanceRate = "64%", MinGPA = 3.0, MinSAT = 1150, Major = "Business, Engineering, Journalism", Tier = "Top 100" },
                new University { Id = 10, Name = "University of Central Florida", State = "Florida", AcceptanceRate = "41%", MinGPA = 3.0, MinSAT = 1160, Major = "Engineering, Business, Hospitality", Tier = "Top 100" }
            );
            context.SaveChanges();
            }
            })
        );
    }
}