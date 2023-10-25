using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Framework.Contracts.Abstracts;

namespace B2B.Application.Contracts.Commands.Profile.SmeMember
{
    public class UpdateSmeMemberCommand : Command
    {
        public string Name { get; set; }
        public string ProfilePhoto { get; set; }
        public int SmeProfileId { get; set; }
        public int PositionId { get; set; }
    }

    public class UpdateSmeMemberCommandResponse : CommandResponse
    {
    }
}
