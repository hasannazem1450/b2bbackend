using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.Contracts.Commands.Event;
using B2B.Application.Contracts.Commands.News;
using B2B.Application.Contracts.Commands.Profile.Position;
using B2B.Framework.Contracts.Abstracts;

namespace B2B.Application.Contracts.Queries.News
{
    public class ReadSmeProfileNewsQuery : Query
    {
        public int SmeProfileId { get; set; }
    }

    public class ReadNewsQueryResponse : QueryResponse
    {
        public ReadNewsQueryResponse()
        {
            List = new List<NewsDto>();
        }
        public List<NewsDto> List { get; set; }
    }

}
