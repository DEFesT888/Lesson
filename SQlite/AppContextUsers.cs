using Microsoft.EntityFrameworkCore;
using SQlite.Models;

namespace SQlite
{
    public class AppContextUsers : DbContext
    {
        public AppContextUsers(DbContextOptions<AppContextUsers> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<ModelUser> ModelUsers { get; set; } = null!;
<<<<<<< HEAD
        public DbSet<Program> ProgramUsers { get; set; } = null!;
=======

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ModelUser>().ToTable("ModelUser");
        }
>>>>>>> 21b6c7c5915ff5668cc6589df14d6b4a36eb53e5
    }
}