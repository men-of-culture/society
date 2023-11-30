using Microsoft.EntityFrameworkCore;
using Society.Api.Models;

namespace Society.Api
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<User> User { get; set; }

        public DbSet<Friend> Friend { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Friend>().HasKey(f => new { f.UserId, f.FriendId });

            modelBuilder.Entity<Friend>().HasOne(f => f.User).WithMany(u => u.Friends).HasForeignKey(f => f.UserId).OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Friend>().HasOne(f => f.UserFriend).WithMany().HasForeignKey(f => f.FriendId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
