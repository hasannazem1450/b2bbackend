using B2B.Application.Contracts.Commands.Profile.FollowProfile;
using B2B.Application.Contracts.Queries.Profile.FollowProfile;
using B2B.Controllers;
using B2B.Framework.Contracts.Makers;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace B2B.Host.Controllers.FollowProfile
{
    public class FollowProfileController : MainController
    {
        public FollowProfileController(IDistributor distributor) : base(distributor)
        {
        }

        [HttpGet("read-FollowProfile")]
        public async Task<IActionResult> ReadSmeProfileNews([FromQuery] ReadFollowProfileQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadFollowProfileQuery, ReadFollowProfileQueryResponse>(query, cancellationToken);

            return OkApiResult(result);
        }

        [HttpPost("create-FollowProfile")]
        public async Task<IActionResult> CreateNews(CreateFollowProfileCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<CreateFollowProfileCommand, CreateFollowProfileCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }



        [HttpPut("update-FollowProfile")]
        public async Task<IActionResult> UpdateNews(UpdateFollowProfileCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<UpdateFollowProfileCommand, UpdateFollowProfileCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }

        [HttpDelete("delete-FollowProfile")]
        public async Task<IActionResult> DeleteNews(DeleteFollowProfileCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<DeleteFollowProfileCommand, DeleteFollowProfileCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
    }
}
