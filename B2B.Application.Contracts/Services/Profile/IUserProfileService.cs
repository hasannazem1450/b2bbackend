using B2B.Application.Contracts.Commands.Profile.UserProfile;
using B2B.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.Application.Contracts.Services.Profile
{
    public interface IUserProfileService : IService
    {
        Task<List<UserProfileDto>> ReadAll();
        Task<List<UserProfileDto>> ReadByUserId(Guid userid);

    }
}
