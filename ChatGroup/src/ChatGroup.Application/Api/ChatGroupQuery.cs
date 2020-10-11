using ChatGroup.Application.Api.Types;
using ChatGroup.Application.Helpers;
using GraphQL;
using GraphQL.Types;
using System.Linq;


namespace ChatGroup.Application.Api
{
    public class ChatGroupQuery : ObjectGraphType
    {
        public ChatGroupQuery(ContextServiceLocator contextServiceLocator)
        {
            Name = "Query";

            FieldAsync<ChannelType>("channel",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: async context =>
                {
                    var id = context.GetArgument<int>("id");
                    var result = await contextServiceLocator.Channels.Filter(x => x.Id == id);
                    return result.First();
                });

            FieldAsync<ListGraphType<ChannelType>>("channels",
                resolve: async context => await contextServiceLocator.Channels.GetAll());
        }

    }
}
