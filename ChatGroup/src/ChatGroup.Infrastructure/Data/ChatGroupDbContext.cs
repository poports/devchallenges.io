using ChatGroup.Domain.Entities;
using ChatGroup.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ChatGroup.Infrastructure.Data
{
    public class ChatGroupDbContext : DbContext
    {
        private readonly ILoggerFactory _loggerFactory;

        public DbSet<Channel> Channels { get; set; }
        public ChatGroupDbContext(DbContextOptions<ChatGroupDbContext> options, ILoggerFactory loggerFactory) 
            : base(options) 
        {
            _loggerFactory = loggerFactory;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(_loggerFactory);
        }


    }
}
