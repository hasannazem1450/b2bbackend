using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.Contracts.Queries.SystemMessages;
using B2B.Framework.Contracts.Abstracts;

namespace B2B.Application.Contracts.Queries.RoleManager
{
    public class ReadRoleQuery : Query
    {

    }

    public class ReadRoleQueryResponse : QueryResponse
    {
        public ReadRoleQueryResponse()
        {
            List = new List<RoleDto>();
        }
        public List<RoleDto> List { get; set; }
    }
}
