using B2B.Application.Contracts.Commands.Profile.UserProfile;
using B2B.Application.Contracts.Queries.Profile.UserProfile;
using B2B.Controllers;
using B2B.Framework.Contracts.Makers;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace B2B.Host.Controllers.UserProfile
{
    public class UserProfileController : MainController
    {
        public UserProfileController(IDistributor distributor) : base(distributor)
        {
        }

        [HttpPost("create-sme-profile")]
        public async Task<IActionResult> CreateUserProfile(CreateUserProfileCommand query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<CreateUserProfileCommand, CreateUserProfileCommandResponse>(query, cancellationToken);

            return OkApiResult(result);
        }

        [AllowAnonymous]
        [HttpGet("read-all-userprofiles")]
        public async Task<IActionResult> ReadAllUserProfile([FromQuery] ReadAllUserProfileQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadAllUserProfileQuery, ReadAllUserProfileQueryResponse>(new ReadAllUserProfileQuery(), cancellationToken);

            return OkApiResult(result);
        }

        [AllowAnonymous]
        [HttpGet("read-userprofiles")]
        public async Task<IActionResult> ReadUserProfileByUserId([FromQuery] ReadUserProfileQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadUserProfileQuery, ReadUserProfileQueryResponse>(query, cancellationToken);

            return OkApiResult(result);
        }

        
    }
}
