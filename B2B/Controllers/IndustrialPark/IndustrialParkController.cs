using B2B.Application.Contracts.Commands.IndustrialPark;
using B2B.Application.Contracts.Queries.BaseInfo.IndustrialPark;
using B2B.Controllers;
using B2B.Framework.Contracts.Makers;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace B2B.Host.Controllers.IndustrialPark
{
    public class IndustrialParkController: MainController
    {
        public IndustrialParkController(IDistributor distributor) : base(distributor)
        {
        }

        [HttpGet("read-IndustrialPark")]
        public async Task<IActionResult> ReadIndustrialPark(CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadIndustrialParkQuery, ReadIndustrialParkQueryResponse>(new ReadIndustrialParkQuery(), cancellationToken);

            return OkApiResult(result);
        }

        //TODO:Complete The Province CRUD
        [HttpPost("create-IndustrialPark")]
        public async Task<IActionResult> CreateIndustrialPark(CreateIndustrialParkCommand query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<CreateIndustrialParkCommand, CreateIndustrialParkCommandResponse>(query, cancellationToken);

            return OkApiResult(result);
        }

        [HttpDelete("delete-IndustrialPark")]
        public async Task<IActionResult> DeleteIndustrialPark(CancellationToken cancellationToken)
        {

            var result = await Distributor.Push<DeleteIndustrialParkCommand, DeleteIndustrialParkCommandResponse>(new DeleteIndustrialParkCommand(), cancellationToken);

            return OkApiResult(result);
        }

        [HttpPut("update-IndustrialPark")]
        public async Task<IActionResult> UpdateIndustrialPark(CancellationToken cancellationToken)
        {

            var result = await Distributor.Push<UpdateIndustrialParkCommand, UpdateIndustrialParkCommandResponse>(new UpdateIndustrialParkCommand(), cancellationToken);

            return OkApiResult(result);
        }
    }
}
