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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ModelUser>().ToTable("ModelUser");
        }
    }
}