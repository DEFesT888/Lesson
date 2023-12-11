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
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Data Source=DBuser.db");
        //}

    }
}
