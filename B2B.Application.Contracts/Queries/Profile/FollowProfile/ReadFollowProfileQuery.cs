using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.Contracts.Commands.Profile.FollowProfile;
using B2B.Application.Contracts.Commands.Profile.SmeMember;
using B2B.Framework.Contracts.Abstracts;

namespace B2B.Application.Contracts.Queries.Profile.FollowProfile
{
    public class ReadFollowProfileQuery : Query
    {
        public int? Id { get; set; }
    }

    public class ReadFollowProfileQueryResponse : QueryResponse
    {
        public ReadFollowProfileQueryResponse()
        {
            List = new List<FollowProfileDto>();
        }
        public List<FollowProfileDto> List { get; set; }
    }
}
