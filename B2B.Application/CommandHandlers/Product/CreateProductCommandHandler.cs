using B2B.Application.Contracts.Commands.Product;
using B2B.Application.Contracts.Repository.Product;
using B2B.Framework.Contracts.Abstracts;
using B2B.Domain.ProductBase;


namespace B2B.Application.CommandHandlers.Product
{
    public class CreateProductCommandHandler : CommandHandler<CreateProductCommand, CreateProductCommandResponse>
    {
        private readonly IProductRepository _productRepository;


        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public override async Task<CreateProductCommandResponse> Executor(CreateProductCommand command)
        {
            var product = new Domain.ProductBase.Product();

            await _productRepository.Create(product);

            return new CreateProductCommandResponse();
        }
    }
}
