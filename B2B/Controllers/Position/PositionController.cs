using System.Threading;
using System.Threading.Tasks;
using B2B.Application.Contracts.Commands.Profile.Position;
using B2B.Application.Contracts.Commands.Profile.SmeProfile;
using B2B.Application.Contracts.Queries.Profile.Member;
using B2B.Controllers;
using B2B.Framework.Contracts.Makers;
using Microsoft.AspNetCore.Mvc;

namespace B2B.Host.Controllers.Position
{
    public class PositionController : MainController
    {
        public PositionController(IDistributor distributor) : base(distributor)
        {
        }

        [HttpPost("create-position")]
        public async Task<IActionResult> CreatePosition(CreatePositionCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<CreatePositionCommand, CreatePositionCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }

        [HttpGet("read-position")]
        public async Task<IActionResult> ReadPosition(CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadPositionQuery, ReadPositionQueryResponse>(new ReadPositionQuery(), cancellationToken);

            return OkApiResult(result);
        }

        [HttpPut("update-position")]
        public async Task<IActionResult> UpdatePosition(UpdatePositionCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<UpdatePositionCommand, UpdatePositionCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }

        [HttpDelete("delete-position")]
        public async Task<IActionResult> DeletePosition(DeletePositionCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<DeletePositionCommand, DeletePositionCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }

    }
}
