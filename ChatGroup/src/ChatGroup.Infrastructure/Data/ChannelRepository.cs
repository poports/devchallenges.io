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

        public async Task<Channel> Add(Channel channel)
        {
            await _dbContext.Channels.AddAsync(channel);
            await _dbContext.SaveChangesAsync();
            return channel;
        }

        public async Task<Channel> GetById(int id)
        {
            return await _dbContext.Channels.FindAsync(id);
        }

        public async Task<List<Channel>> ListAll()
        {
            return await _dbContext.Channels.ToListAsync();
        }

        

    }
}
