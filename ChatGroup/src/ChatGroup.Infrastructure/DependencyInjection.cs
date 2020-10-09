using ChatGroup.Infrastructure.Data;
using GraphQL.Server;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatGroup.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            if (configuration.GetValue<bool>("UseSqlite"))
            {
                services.AddDbContext<ChatGroupDbContext>(options =>
                    options
                    .ConfigureWarnings(b => b.Log(CoreEventId.ManyServiceProvidersCreatedWarning))
                    .UseSqlite(configuration.GetConnectionString("SqliteConnection")));
            }
            else 
            {
                services.AddDbContext<ChatGroupDbContext>(options =>
                    options
                    .ConfigureWarnings(b => b.Log(CoreEventId.ManyServiceProvidersCreatedWarning))
                    .UseNpgsql(GetConnectionString()));
            }

            services.AddGraphQL(options =>
            {
                options.EnableMetrics = true;
            })

            .AddSystemTextJson()
            .AddUserContextBuilder(httpContext => new GraphQLUserContext { User = httpContext.User });

            return services;
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            // add http for Schema at default url /graphql
            app.UseGraphQL<ISchema>();

            // use graphql-playground at default url /ui/playground
            app.UseGraphQLPlayground();

            return app;
        }

        private static string GetConnectionString() {
            var uriString = Environment.GetEnvironmentVariable("POSTGRES_URL", EnvironmentVariableTarget.User);
            var uri = new Uri(uriString);
            var db = uri.AbsolutePath.Trim('/');
            var user = uri.UserInfo.Split(':')[0];
            var passwd = uri.UserInfo.Split(':')[1];
            var port = uri.Port > 0 ? uri.Port : 5432;
            var connStr = $"Server={uri.Host};Database={db};User Id={user};Password={passwd};Port={port}";
            return connStr;
        }
    }
}
