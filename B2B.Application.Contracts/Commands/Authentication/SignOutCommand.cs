using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using B2B.Framework.Contracts.Abstracts;

namespace B2B.Application.Contracts.Commands.Authentication
{
    public class SignOutCommand : Command
    {
        public SignOutCommand()
        {
        }

        public ClaimsPrincipal User { get; set; }
    }

    public class SignOutCommandResponse : CommandResponse
    {
        public string Message { get; set; }
        public string Perfix { get; set; }
        public int Code { get; set; }
       
    }
}
