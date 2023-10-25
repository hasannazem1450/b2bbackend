using B2B.Configurations.RegisterTypes;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using B2B.Application.Contracts.Queries;
using B2B.Controllers;
using B2B.Framework.Contracts.Makers;
using B2B.Application.Contracts.Queries.Product;
using B2B.Application.Contracts.Commands.Product;
using System.Threading;

namespace B2B.Host.Controllers.Product
{
    public class ProductController : MainController
    {
        public ProductController(IDistributor distributor) : base(distributor)
        {
        }
        [HttpGet("read-product")]
        public async Task<IActionResult> ReadProduct([FromQuery] ReadProductQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadProductQuery, ReadProductQueryResponse>(query, cancellationToken);

            return OkApiResult(result);
        }
        [HttpPost("create-product")]
        public async Task<IActionResult> CreateProduct(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<CreateProductCommand, CreateProductCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
        [HttpPut("update-product")]
        public async Task<IActionResult> UpdateProduct(UpdateProductCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<UpdateProductCommand, UpdateProductCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }

        [HttpDelete("delete-product")]
        public async Task<IActionResult> DeleteProduct(DeleteProductCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<DeleteProductCommand, DeleteProductCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }

    }
}

