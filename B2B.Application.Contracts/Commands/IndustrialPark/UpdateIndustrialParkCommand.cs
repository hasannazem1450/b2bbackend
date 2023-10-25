using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Framework.Contracts.Abstracts;

namespace B2B.Application.Contracts.Commands.IndustrialPark
{
    public class UpdateIndustrialParkCommand : Command
    {
        public int Id { get; set; }
        public int? Code { get; set; }
        public string Name { get; set; }
    }

    public class UpdateIndustrialParkCommandResponse : CommandResponse
    {
    }
}
