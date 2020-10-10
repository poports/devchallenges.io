using ChatGroup.Domain.Common;
using ChatGroup.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatGroup.Application.Common.Interfaces
{
    public interface IChannelRepository 
    {
        Task<Channel> GetById(int id);
        Task<List<Channel>> ListAll();
    }
}
