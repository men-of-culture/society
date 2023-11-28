using Microsoft.EntityFrameworkCore;
using Society.Api.Models;

namespace Society.Api
{
    public class DatabaseContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DatabaseContext(DbContextOptions<DatabaseContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("SqlDbConnection"));
            }
        }
    }
}
