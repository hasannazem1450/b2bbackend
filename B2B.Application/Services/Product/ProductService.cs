using B2B.Application.Contracts.Commands.Product;
using B2B.Application.Contracts.Repository.Product;
using B2B.Application.Contracts.Services.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.Application.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDto> ReadById(int id)
        {
            var product = await _productRepository.ReadById(id);

            return new ProductDto()
            {
                Id = product.Id,
                //Title = product.Title,
                //HeadLine = product.HeadLine,
                //Description = product.Description,
                //Photo = product.Photo,
                //SmeProfile = product.SmeProfile,
            };
        }

        public async Task<List<ProductDto>> Read()
        {
            var news = await _productRepository.Read();

            var result = new List<ProductDto>();

            foreach (var item in news)
            {
                var dto = new ProductDto()
                {
                    Id = item.Id,
                    //Title = item.Title,
                    //HeadLine = item.HeadLine,
                    //Description = item.Description,
                    //Photo = item.Photo,
                    //SmeProfile = item.SmeProfile,
                };

                result.Add(dto);
            }

            return result;
        }

        public async Task<List<ProductDto>> ReadProductBySmeProfileId(int SmeProfileId)
        {
            var product = await _productRepository.ReadProductBySmeProfileId(SmeProfileId);

            var result = new List<ProductDto>();

            foreach (var item in product)
            {
                var dto = new ProductDto()
                {
                    Id = item.Id,
                    //Title = item.Title,
                    //HeadLine = item.HeadLine,
                    //Description = item.Description,
                    //Photo = item.Photo,
                    //SmeProfile = item.SmeProfile,
                };

                result.Add(dto);
            }

            return result;
        }
    }
}
