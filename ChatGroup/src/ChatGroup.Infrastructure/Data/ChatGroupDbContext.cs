using ChatGroup.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChatGroup.Infrastructure.Data
{
    public class ChatGroupDbContext : DbContext
    {
        public DbSet<Channel> Channels { get; set; }
        public ChatGroupDbContext(DbContextOptions<ChatGroupDbContext> options)
                    : base(options) 
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Channel>(entity => {
                entity.HasIndex(e => e.Name).IsUnique();
            });
        }
    }
}
