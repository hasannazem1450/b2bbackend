using B2B.Application.Contracts.Commands.Profile.UserProfile;
using B2B.Domain.Profile;
using B2B.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.Application.Contracts.Repository.Profile
{
    public interface IUserProfileRepository : IRepository
    {
        Task<List<UserProfile>> ReadAll();
        Task<List<UserProfile>> ReadByUserId(Guid userid);
        Task Delete(int id);
        Task Create(UserProfile userProfile);
    }
}
