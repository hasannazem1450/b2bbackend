
using B2B.Application.Contracts.Commands.Product;
using B2B.Application.Contracts.Queries.Product;
using B2B.Application.Contracts.Services.Product;
using B2B.Application.Services.Product;
using B2B.Framework.Contracts.Markers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace B2B.Application.QueryHandlers.Profile.Product
{
    public class ReadProductQueryHandler : IQueryHandler<ReadProductQuery, ReadProductQueryResponse>
    {

        private readonly IProductService _productService;

        public ReadProductQueryHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<ReadProductQueryResponse> Execute(ReadProductQuery query,
            CancellationToken cancellationToken)
        {
            var product = await _productService.Read();

            var result = new ReadProductQueryResponse();

            foreach (var item in product)
            {
                var dto = new ProductDto()
                {
                    Id = item.Id,
                    //Position = item.Position,
                    //Name = item.Name,
                    //ProfilePhoto = item.ProfilePhoto,
                    SmeProfile = item.SmeProfile,
                };


                result.List.Add(dto);
            }

            return result;
        }
    }
}
