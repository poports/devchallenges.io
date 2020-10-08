using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatGroup.Infrastructure.Data
{
    public class ChatGroupDbContext : DbContext
    {
        public ChatGroupDbContext(DbContextOptions<ChatGroupDbContext> options) : base(options) { }


    }
}
