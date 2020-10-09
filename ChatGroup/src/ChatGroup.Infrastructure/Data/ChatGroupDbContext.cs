using CharGroup.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatGroup.Infrastructure.Data
{
    public class ChatGroupDbContext : DbContext
    {
        public DbSet<Channel> Channels { get; set; }
        public ChatGroupDbContext(DbContextOptions<ChatGroupDbContext> options) : base(options) { }


    }
}
