using B2B.Application.Contracts.Commands.Profile.FollowProfile;
using B2B.Application.Contracts.Queries.Profile.FollowProfile;
using B2B.Application.Contracts.Services.Profile;
using B2B.Framework.Contracts.Markers;


namespace B2B.Application.QueryHandlers.Profile.FollowProfile
{
    public class ReadFollowProfileQueryHandler : IQueryHandler<ReadFollowProfileQuery, ReadFollowProfileQueryResponse>
    {

        private readonly IFollowProfileService _followProfileService;

        public ReadFollowProfileQueryHandler(IFollowProfileService followProfileService)
        {
            _followProfileService = followProfileService;
        }

        public async Task<ReadFollowProfileQueryResponse> Execute(ReadFollowProfileQuery query,
            CancellationToken cancellationToken)
        {
            var followProfile = await _followProfileService.Read();

            var result = new ReadFollowProfileQueryResponse();

            foreach (var item in followProfile)
            {
                var dto = new FollowProfileDto()
                {
                    Id = item.Id,
                    FollowProfileId = item.FollowProfileId,
                    MyProfileId = item.MyProfileId,
                    FollowProfileLogo = item.FollowProfileLogo,
                    FollowProfileName = item.FollowProfileName,

                };


                result.List.Add(dto);
            }

            return result;
        }
    }
}
