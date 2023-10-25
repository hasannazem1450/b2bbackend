using B2B.Application.Contracts.Queries.Profile.UserProfile;
using B2B.Application.Contracts.Services.Profile;
using B2B.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.Application.QueryHandlers.Profile.UserProfile
{
  
    public class ReadAllUserProfileQueryHandler : IQueryHandler<ReadAllUserProfileQuery, ReadAllUserProfileQueryResponse>
    {
        private readonly IUserProfileService _userProfileService;

        public ReadAllUserProfileQueryHandler(IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }

        public async Task<ReadAllUserProfileQueryResponse> Execute(ReadAllUserProfileQuery query,
            CancellationToken cancellationToken)
        {
            var ra = await _userProfileService.ReadAll();

            var result = new ReadAllUserProfileQueryResponse()
            {
                List = ra
            };

            return result;
        }
    }
}
