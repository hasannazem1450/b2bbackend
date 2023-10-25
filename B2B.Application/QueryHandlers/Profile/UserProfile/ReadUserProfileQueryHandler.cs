using B2B.Application.Contracts.Queries.Profile.UserProfile;
using B2B.Application.Contracts.Services.Profile;
using B2B.Framework.Contracts.Markers;


namespace B2B.Application.QueryHandlers.Profile.UserProfile
{
    public class ReadUserProfileQueryHandler : IQueryHandler<ReadUserProfileQuery, ReadUserProfileQueryResponse>
    {
        private readonly IUserProfileService _userProfileService;

        public ReadUserProfileQueryHandler(IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }

        public async Task<ReadUserProfileQueryResponse> Execute(ReadUserProfileQuery query,
            CancellationToken cancellationToken)
        {
            var rbui = await _userProfileService.ReadByUserId(query.Metadata.UserId);

            var result = new ReadUserProfileQueryResponse()
            {
                List = rbui
            };

            return result;
        }
    }
}
