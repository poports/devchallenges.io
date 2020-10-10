using ChatGroup.Domain.Entities;
using Microsoft.VisualBasic;
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
                    Description = "Front-end Developers channel",
                    CreatedBy = "System",
                    Created = DateAndTime.Now
                });

                dbContext.Channels.Add(new Channel
                {
                    Name = "Random",
                    Description = "Random channel",
                    CreatedBy = "System",
                    Created = DateAndTime.Now
                });

                dbContext.Channels.Add(new Channel
                {
                    Name = "Back-end",
                    Description = "Back-end channel",
                    CreatedBy = "System",
                    Created = DateAndTime.Now
                });

                dbContext.Channels.Add(new Channel
                {
                    Name = "Cats and Dogs",
                    Description = "Cats and Dogs channel",
                    CreatedBy = "System",
                    Created = DateAndTime.Now
                });

                dbContext.Channels.Add(new Channel
                {
                    Name = "Welcome",
                    Description = "Default channel",
                    CreatedBy = "System",
                    Created = DateAndTime.Now
                });

                dbContext.SaveChanges();

            }
        }
    }
}
