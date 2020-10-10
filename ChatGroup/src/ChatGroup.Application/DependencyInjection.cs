using ChatGroup.Application.Api;
using ChatGroup.Application.Api.Types;
using ChatGroup.Application.Helpers;
using GraphQL.Types;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChatGroup.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ContextServiceLocator>();
            services.AddSingleton<ChannelType>();
            services.AddSingleton<ChannelInputType>();
            services.AddSingleton<ChatGroupQuery>();
            services.AddSingleton<ChatGroupMutation>();
            services.AddSingleton<ISchema, ChatGroupSchema>();

            return services;
        }
    }
}
