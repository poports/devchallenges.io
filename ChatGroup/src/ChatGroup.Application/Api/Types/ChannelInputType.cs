using ChatGroup.Domain.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatGroup.Application.Api.Types
{
    public class ChannelInputType :  InputObjectGraphType<Channel>
    {
        public ChannelInputType()
        {
            Field(t => t.Name);
            Field(t => t.Description);
        }
    }
}
