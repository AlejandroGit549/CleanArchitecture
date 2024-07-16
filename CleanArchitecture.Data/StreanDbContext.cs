using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Data
{
    public class StreanDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=Localhost\SQLEXPRESS; Initial Catalog=Streamer;Integrated Security= True")
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name },LogLevel.Information )
                .EnableSensitiveDataLogging();
        }
        public DbSet<Streamer>? Streamers { get; set; }
        public DbSet<Video>? Videos { get; set; }
    }
}
 