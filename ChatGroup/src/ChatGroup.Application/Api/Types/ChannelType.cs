using ChatGroup.Domain.Entities;
using GraphQL.Types;

namespace ChatGroup.Application.Api.Types
{
    public class ChannelType : ObjectGraphType<Channel>
    {
        public ChannelType()
        {
            Field( t=> t.Id);
            Field(t => t.Name);
            Field(t => t.Description);

            //Field<ListGraphType<ChannelMemberType>>("members", resolve: context => context.Source.ChannelMembers);
        }
    }
}
