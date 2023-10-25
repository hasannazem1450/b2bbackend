using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Framework.Contracts.Abstracts;

namespace B2B.Application.Contracts.Commands.RoleManager
{
    public class UpdateRoleCommand : Command
    {
        public UpdateRoleCommand(string oldRoleName , string newRoleName)
        {
            OldRoleName = oldRoleName;
            NewRoleName = newRoleName;
        }

        public string OldRoleName { get; set; }
        public string NewRoleName { get; set; }
    }

    public class UpdateRoleCommandResponse : CommandResponse
    {
        public string Message { get; set; }
        public string Prefix { get; set; }
        public int Code { get; set; }
    }
}
