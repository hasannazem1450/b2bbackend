using System.Threading;
using System.Threading.Tasks;
using B2B.Application.Contracts.Commands.Authentication;
using B2B.Application.Contracts.Commands.IndustrialPark;
using B2B.Application.Contracts.Queries.BaseInfo.City;
using B2B.Application.Contracts.Queries.BaseInfo.IndustrialPark;
using B2B.Controllers;
using B2B.Framework.Contracts.Makers;
using Microsoft.AspNetCore.Mvc;

namespace B2B.Host.Controllers.BaseInfo.IndustrialPark
{
    public class IndustrialParkController : MainController
    {
        public IndustrialParkController(IDistributor distributor) : base(distributor)
        {
        }

        [HttpGet("read-industrial-park")]
        public async Task<IActionResult> ReadCity(CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadIndustrialParkQuery, ReadIndustrialParkQueryResponse>(new ReadIndustrialParkQuery(), cancellationToken);

            return OkApiResult(result);
        }

        //TODO:Complete The IndustrialPark CRUD
       
        [HttpPost("create-industrial-park")]
        public async Task<IActionResult> CreateIndustrialPark(CreateIndustrialParkCommand query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<CreateIndustrialParkCommand, CreateIndustrialParkCommandResponse>(query, cancellationToken);

            return OkApiResult(result);
        }

        [HttpDelete("delete-industrial-park")]
        public async Task<IActionResult> DeleteIndustrialPark(CancellationToken cancellationToken)
        {

            var result = await Distributor.Push<DeleteIndustrialParkCommand, DeleteIndustrialParkCommandResponse>(new DeleteIndustrialParkCommand(), cancellationToken);

            return OkApiResult(result);
        }

        [HttpPut("update-industrial-park")]
        public async Task<IActionResult> UpdateIndustrialPark(CancellationToken cancellationToken)
        {

            var result = await Distributor.Push<UpdateIndustrialParkCommand, UpdateIndustrialParkCommandResponse>(new UpdateIndustrialParkCommand(), cancellationToken);

            return OkApiResult(result);
        }
    }
}
