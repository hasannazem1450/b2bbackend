using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.Contracts.Commands.Profile.SmeMember;
using B2B.Framework.Contracts.Abstracts;

namespace B2B.Application.Contracts.Queries.Profile.SmeMember
{
    public class ReadSmeMemberQuery : Query
    {

    }

    public class ReadSmeMemberQueryResponse : QueryResponse
    {
        public ReadSmeMemberQueryResponse()
        {
            List = new List<SmeMemberDto>();
        }
        public List<SmeMemberDto> List { get; set; }
    }
}
