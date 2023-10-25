using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.Contracts.Commands.UserManager;
using B2B.Framework.Contracts.Abstracts;

namespace B2B.Application.Contracts.Queries.UserManager
{
    public class ReadUserRoleQuery : Query
    {
        public string? UserName { get; set; }
        public string? RoleName { get; set; }
    }

    public class ReadUserRoleQueryResponse : QueryResponse
    {
        public ReadUserRoleQueryResponse()
        {
            List = new List<AspNetUserRolesDto>();
        }
        public List<AspNetUserRolesDto> List { get; set; }
    }
}
