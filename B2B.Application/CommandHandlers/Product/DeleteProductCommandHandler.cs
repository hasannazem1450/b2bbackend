using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.Contracts.Commands.Product;
using B2B.Application.Contracts.Repository.Product;
using B2B.Framework.Contracts.Abstracts;

namespace B2B.Application.CommandHandlers.Product
{
    public class DeleteProductCommandHandler : CommandHandler<DeleteProductCommand, DeleteProductCommandResponse>
    {
        private readonly IProductRepository _newsRepository;


        public DeleteProductCommandHandler(IProductRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public override async Task<DeleteProductCommandResponse> Executor(DeleteProductCommand command)
        {
            await _newsRepository.Delete(command.Id);

            return new DeleteProductCommandResponse();
        }
    }
}
