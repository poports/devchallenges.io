using ChatGroup.Application.Common.Interfaces;
using ChatGroup.Domain.Entities;
using GraphQL.Utilities;
using Microsoft.AspNetCore.Http;


namespace ChatGroup.Application.Helpers
{
    // https://github.com/graphql-dotnet/graphql-dotnet/issues/648#issuecomment-431489339
    public class ContextServiceLocator
    {
        public IRepository<Channel> Channels => _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<IRepository<Channel>>();

        //public IHumanizer Humanizer => _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<IHumanizer>();

        private readonly IHttpContextAccessor _httpContextAccessor;

        public ContextServiceLocator(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
    }
}
