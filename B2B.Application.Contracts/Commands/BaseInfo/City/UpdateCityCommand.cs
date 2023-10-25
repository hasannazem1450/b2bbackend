using B2B.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.Application.Contracts.Commands.BaseInfo.City
{
    public class UpdateCityCommand : Command
    {
        public string Name { get; set; }
        public int? Code { get; set; }
        public int ProvinceId { get; set; }
    }

    public class UpdateCityCommandResponse : CommandResponse
    {
    }
}
