using B2B.Application.Contracts.Commands.Product;
using B2B.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.Application.Contracts.Services.Product
{
    public interface IProductService : IService
    {
        Task<ProductDto> ReadById(int id);
        Task<List<ProductDto>> Read();
        Task<List<ProductDto>> ReadProductBySmeProfileId(int SmeProfileId);
    }
}
