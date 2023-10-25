using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Framework.Contracts.Abstracts;

namespace B2B.Application.Contracts.Commands
{
    public class CreateProjectCommand : Command
    {
        public string ProjectName { get; set; }
        public int Price { get; set; }
    }

    public class CreateProjectCommandResponse : CommandResponse
    {
        public bool IsCreated { get; set; }
    }
}
