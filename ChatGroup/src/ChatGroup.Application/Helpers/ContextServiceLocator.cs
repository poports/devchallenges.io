using ChatGroup.Application.Common.Interfaces;
using GraphQL.Utilities;
using Microsoft.AspNetCore.Http;


namespace ChatGroup.Application.Helpers
{
    // https://github.com/graphql-dotnet/graphql-dotnet/issues/648#issuecomment-431489339
    public class ContextServiceLocator
    {
        public IChannelRepository ChannelRepository => _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<IChannelRepository>();

        //public IHumanizer Humanizer => _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<IHumanizer>();

        private readonly IHttpContextAccessor _httpContextAccessor;

        public ContextServiceLocator(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
    }
}
