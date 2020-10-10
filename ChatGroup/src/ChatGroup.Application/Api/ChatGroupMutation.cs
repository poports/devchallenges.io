using ChatGroup.Application.Api.Types;
using ChatGroup.Application.Helpers;
using ChatGroup.Domain.Entities;
using GraphQL;
using GraphQL.Types;

namespace ChatGroup.Application.Api
{
    public class ChatGroupMutation : ObjectGraphType<object>
    {
        public ChatGroupMutation(ContextServiceLocator contextServiceLocator)
        {
            Name = "Mutation";

            FieldAsync<ChannelType>(
                "addChannel",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<ChannelInputType>> { Name = "input" }),
                resolve: async context =>
                {
                    var input = context.GetArgument<Channel>("input");
                    return await contextServiceLocator.ChannelRepository.Add(input);
                });

        }
    }
}
