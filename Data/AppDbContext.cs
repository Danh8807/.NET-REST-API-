using Microsoft.EntityFrameworkCore;
using StudyAbroadApi.Models;

namespace StudyAbroadApi.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{

    public DbSet<Student> Students => Set<Student>();
    public DbSet<University> Universities => Set<University>();

    public DbSet<User> Users => Set<User>(); 

}
