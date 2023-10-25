using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Framework.Contracts.Abstracts;

namespace B2B.Application.Contracts.Queries
{
    public class ReadProjectQuery : Query
    {
        public string ProjectName { get; set; }
        public int Price { get; set; }
    }

    public class ReadProjectResponse : Query
    {
        public int ProjectName { get; set; }
        public int Price { get; set; }
    }
}
