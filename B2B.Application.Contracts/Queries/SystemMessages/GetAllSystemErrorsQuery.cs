using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.Contracts.Queries.SystemMessages;
using B2B.Framework.Contracts.Abstracts;

namespace B2B.Application.Contracts.Queries.SystemMessages
{
    public class GetAllSystemErrorsQuery : Query
    {

    }

    public class GetAllSystemErrorsQueryResponse : QueryResponse
    {
        public GetAllSystemErrorsQueryResponse()
        {
            List = new List<SystemErrorDto>();
        }
        public List<SystemErrorDto> List { get; set; }
    }
}
