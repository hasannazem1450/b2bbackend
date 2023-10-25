using B2B.Application.Contracts.Commands.Product;
using B2B.Application.Contracts.Repository.Product;
using B2B.Framework.Contracts.Abstracts;
using B2B.Domain.ProductBase;
namespace B2B.Application.CommandHandlers.Product
{
    public class UpdateProductCommandHandler : CommandHandler<UpdateProductCommand, UpdateProductCommandResponse>
    {
        private readonly IProductRepository _productRepository;


        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public override async Task<UpdateProductCommandResponse> Executor(UpdateProductCommand command)
        {
            var product = new Domain.ProductBase.Product();

            await _productRepository.Update(product);

            return new UpdateProductCommandResponse();
        }
    }
}
