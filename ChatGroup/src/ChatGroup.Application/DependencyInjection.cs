using System;
using System.Collections.Generic;
using System.Text;
using ChatGroup.Application.Api;
using ChatGroup.Application.Api.Types;
using ChatGroup.Application.Helpers;
using GraphQL.Types;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StarWars;
using StarWars.Types;

namespace ChatGroup.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddSingleton<StarWarsData>();
            //services.AddSingleton<StarWarsQuery>();
            //services.AddSingleton<StarWarsMutation>();
            //services.AddSingleton<HumanType>();
            //services.AddSingleton<HumanInputType>();
            //services.AddSingleton<DroidType>();
            //services.AddSingleton<CharacterInterface>();
            //services.AddSingleton<EpisodeEnum>();
            //services.AddSingleton<ISchema, StarWarsSchema>();

            services.AddSingleton<ContextServiceLocator>();
            services.AddSingleton<ChannelType>();
            services.AddSingleton<ChatGroupQuery>();
            services.AddSingleton<ISchema, ChatGroupSchema>();


            return services;
        }
    }
}
