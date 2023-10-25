using B2B.Application.Contracts.Commands.Profile.UserProfile;
using B2B.Application.Contracts.Repository.Profile;
using B2B.Application.Contracts.Services.Profile;

namespace B2B.Application.Services.Profile
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public UserProfileService(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        public async Task<List<UserProfileDto>> ReadAll()
        {
            var read = await _userProfileRepository.ReadAll();

            var result = read.Select(item => new UserProfileDto()
            {
                Id = item.Id,
                UserName = item.UserName,
                ProfileLogo = item.ProfileLogo,
                ProfileName = item.ProfileName,
                ProfileType = item.ProfileType,
                UserId = item.UserId,
                ProfileId = item.ProfileId
            })
                 .ToList();

            return result;
        }

        public async Task<List<UserProfileDto>> ReadByUserId(Guid userid)
        {
            var readbyuserid = await _userProfileRepository.ReadByUserId(userid);

            var result = readbyuserid.Select(item => new UserProfileDto()
            {
                Id = item.Id,
                UserName = item.UserName,
                ProfileLogo = item.ProfileLogo,
                ProfileName = item.ProfileName,
                ProfileType = item.ProfileType,
                UserId = item.UserId,
                ProfileId = item.ProfileId
            })
                .ToList();

            return result;
        }
    }
}
