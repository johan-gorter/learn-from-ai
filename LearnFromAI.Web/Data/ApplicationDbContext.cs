using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LearnFromAI.Models;

namespace LearnFromAI.Data
{
  public class ApplicationDbContext : IdentityDbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Course> Courses { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<AuditLog> AuditLogs { get; set; }

    // Add your DbSet properties for your entities here
  }
}
