using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Framework.Contracts.Abstracts;

namespace B2B.Application.Contracts.Commands.Event
{
    public class UpdateEventInfoCommand : Command
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Periority { get; set; }
        public int ProvinceId { get; set; }
    }

    public class UpdateEventInfoCommandResponse : CommandResponse
    {
    }
}
