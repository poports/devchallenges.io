using ChatGroup.Application.Common.Interfaces;
using ChatGroup.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatGroup.Infrastructure.Data
{
    public sealed class ChannelRepository : IChannelRepository
    {
        private readonly ChatGroupDbContext _dbContext;

        public ChannelRepository(ChatGroupDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public async Task<Channel> GetById(int id)
        {
            return await _dbContext.Set<Channel>().FindAsync(id);
        }

        public async Task<List<Channel>> ListAll()
        {
            return await _dbContext.Set<Channel>().ToListAsync();
        }

    }
}
