using ChatGroup.Application.Api.Types;
using ChatGroup.Application.Helpers;
using GraphQL;
using GraphQL.Types;

namespace ChatGroup.Application.Api
{
    public class ChatGroupQuery : ObjectGraphType
    {
        public ChatGroupQuery(ContextServiceLocator contextServiceLocator)
        {
            Name = "Query";

            FieldAsync<ChannelType>("channel",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: async context => await contextServiceLocator.ChannelRepository.GetById(context.GetArgument<int>("id")));

            FieldAsync<ListGraphType<ChannelType>>("channels",
                resolve: async context => await contextServiceLocator.ChannelRepository.ListAll());
        }

    }
}
