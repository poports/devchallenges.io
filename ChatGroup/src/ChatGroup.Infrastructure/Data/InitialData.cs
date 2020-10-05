using ChatGroup.Domain.Entities;
using Microsoft.VisualBasic;
using System;
using System.Linq;

namespace ChatGroup.Infrastructure.Data
{
    public static class InitialData
    {
        public static void Seed(this ChatGroupDbContext dbContext)
        {
            if (!dbContext.Channels.Any())
            {
                dbContext.Channels.Add(new Channel
                {
                    Name = "Front-end Developers",
                    Description = "Front-end Developers channel"
                });

                dbContext.Channels.Add(new Channel
                {
                    Name = "Random",
                    Description = "Random channel"
                });

                dbContext.Channels.Add(new Channel
                {
                    Name = "Back-end",
                    Description = "Back-end channel"
                });

                dbContext.Channels.Add(new Channel
                {
                    Name = "Cats and Dogs",
                    Description = "Cats and Dogs channel"
                });

                dbContext.Channels.Add(new Channel
                {
                    Name = "Welcome",
                    Description = "Default channel"
                });

                dbContext.SaveChanges();
            }
        }
    }
}
