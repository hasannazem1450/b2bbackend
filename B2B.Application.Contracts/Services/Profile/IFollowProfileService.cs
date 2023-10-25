using B2B.Application.Contracts.Commands.Profile.FollowProfile;
using B2B.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.Application.Contracts.Services.Profile
{
    public interface IFollowProfileService : IService
    {
        Task<FollowProfileDto> ReadById(int id);

        Task<List<FollowProfileDto>> Read();
    }
}
