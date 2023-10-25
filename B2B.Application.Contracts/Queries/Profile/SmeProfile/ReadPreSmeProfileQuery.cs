using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.Contracts.Commands.Profile.SmeProfile;
using B2B.Framework.Contracts.Abstracts;

namespace B2B.Application.Contracts.Queries.Profile.SmeProfile
{
    public class ReadPreSmeProfileQuery : Query
    {

    }

    public class ReadPreSmeProfileQueryResponse : QueryResponse
    {
        public List<PreSmeProfileDto> List { get; set; }
    }
}
