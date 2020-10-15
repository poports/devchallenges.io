using ChatGroup.Application.Api;
using ChatGroup.Application.Api.Types;
using ChatGroup.Application.Extensions;
using ChatGroup.Application.Helpers;
using GraphQL.Types;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;

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

            services.AddGraphQLAuth((_, s) =>
            {

                _.AddPolicy("UserPolicy", p => 
                {
                    p.RequireAuthenticatedUser();
                    p.RequireClaim("scope", "chat.api");
                    p.RequireClaim(ClaimTypes.Role, "User");
                });

            });

            return services;
        }
    }
}