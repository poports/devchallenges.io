using ChatGroup.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChatGroup.Infrastructure.Data
{
    public class ChatGroupDbContext : DbContext
    {
        public DbSet<Channel> Channels { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<ChannelMember> ChannelMembers { get; set; }
        public DbSet<ChannelChat> ChannelChats { get; set; }

        public ChatGroupDbContext(DbContextOptions<ChatGroupDbContext> options)
                    : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Channel>()
                .HasIndex(e => e.Name).IsUnique();

            builder.Entity<ChannelChat>()
                 .HasOne(c => c.Channel)
                 .WithMany();

            builder.Entity<ChannelChat>()
                .HasOne(m => m.Member)
                .WithMany();

            builder.Entity<ChannelMember>()
                .HasOne(m => m.Member)
                .WithMany();

            builder.Entity<Channel>()
                .HasMany(cm => cm.ChannelMembers)
                .WithOne();
        }
    }
}
