using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.Application.Contracts.Commands.BaseInfo.IndustrialPark
{
    public class IndustrialParkDto
    {
        public int Id { get; set; }
        public int? Code { get; set; }
        public string Name { get; set; }
    }
}
