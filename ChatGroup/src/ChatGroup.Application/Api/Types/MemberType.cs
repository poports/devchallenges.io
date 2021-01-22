using ChatGroup.Domain.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatGroup.Application.Api.Types
{
    public class MemberType : ObjectGraphType<Member>
    {
        public MemberType()
        {
            Field(t => t.Id);
            Field(t => t.Name);
        }
    }
}
