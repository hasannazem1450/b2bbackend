using B2B.Application.Contracts.Commands.Product;
using B2B.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.Application.Contracts.Queries.Product
{

    public class ReadProductQuery : Query
    {

    }

    public class ReadProductQueryResponse : QueryResponse
    {
        public ReadProductQueryResponse()
        {
            List = new List<ProductDto>();
        }
        public List<ProductDto> List { get; set; }
    }
}
