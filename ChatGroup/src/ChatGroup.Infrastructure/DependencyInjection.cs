using ChatGroup.Application;
using ChatGroup.Application.Common.Interfaces;
using ChatGroup.Infrastructure.Data;
using GraphQL.Server;
using GraphQL.Types;
using GraphQL.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System;
using GraphQL.Server.Transports.AspNetCore;

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
                options.UnhandledExceptionDelegate = ctx =>
                {
                    if (ctx.Exception.InnerException is SqliteException || ctx.Exception.InnerException is NpgsqlException)
                        ctx.ErrorMessage = $"A database error has occurred.";
                };
            })
            .AddSystemTextJson()
            .AddUserContextBuilder(httpContext => new GraphQLUserContext { User = httpContext.User });

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddHttpContextAccessor();
            return services;
        }

        public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
        {
            //var validationRules = app.ApplicationServices.GetServices<IValidationRule>();

            app.ApplicationServices.GetServices<IValidationRule>();
            app.UseGraphQL<ISchema>();
            app.UseGraphQLPlayground();

           

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<ChatGroupDbContext>();
                context.Seed();
            }

            return app;
        }

        private static string GetConnectionString() {
            var uriString = Environment.GetEnvironmentVariable("POSTGRES_URL");
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
