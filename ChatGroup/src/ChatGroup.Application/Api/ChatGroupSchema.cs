using GraphQL;
using GraphQL.Types;
using GraphQL.Utilities;
using System;

namespace ChatGroup.Application.Api
{
    public class ChatGroupSchema : Schema
    {
        public ChatGroupSchema(IServiceProvider provider) 
            : base(provider)
        {
            Query = provider.GetRequiredService<ChatGroupQuery>().As<IObjectGraphType>();
            Mutation = provider.GetRequiredService<ChatGroupMutation>().As<IObjectGraphType>();
        }
    }
}
