using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Domain.Profile;
using B2B.Domain.Profile.FollowProfile;
using B2B.Framework.Contracts.Markers;

namespace B2B.Application.Contracts.Repository.Profile.IFollowProfileRepository
{
    public interface IFollowProfileRepository : IRepository
    {
        Task<FollowProfile> ReadById(int id);

        Task<List<FollowProfile>> Read();

        Task Delete(int id);

        Task Update(FollowProfile followProfile);

        Task Create(FollowProfile followProfile);
    }
}
