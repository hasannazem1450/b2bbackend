using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Framework.Contracts.Abstracts;

namespace B2B.Application.Contracts.Commands.News
{
    public class CreateNewsCommand : Command
    {
        public string Title { get; set; }
        public string HeadLine { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public int SmeProfileId { get; set; }
    }

    public class CreateNewsCommandResponse : CommandResponse
    {
    }
}
