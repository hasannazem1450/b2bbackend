using B2B.Application.Contracts.Commands.Profile.UserProfile;
using B2B.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.Application.Contracts.Queries.Profile.UserProfile
{

    public class ReadUserProfileQuery : Query
    {
    }

    public class ReadUserProfileQueryResponse : QueryResponse
    {
        public ReadUserProfileQueryResponse()
        {
            List = new List<UserProfileDto>();
        }
        public List<UserProfileDto> List { get; set; }
    }

}
