using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SQlite.Models;

namespace NewProject
{
    public class ApplicationContext : DbContext
    {
        //public ApplicationContext() => Database.EnsureCreated();
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
               {
                   //Database.EnsureCreated();
               }
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Purchase> Purchases { get; set; } = null!;

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>()
        //        .HasMany(w => w.Purchases)
        //        .WithOne(p => p.User)
        //        .HasForeingKey(p => p.UserId)
        //        .OnDelete(DeleteBehavior.Cascade);
        //}


    }
}
