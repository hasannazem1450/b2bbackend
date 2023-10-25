using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Domain.Profile;
using B2B.Framework.Contracts.Markers;

namespace B2B.Application.Contracts.Repository.Profile
{
    public interface ISmeProfileRepository : IRepository
    {
        Task Create(Domain.Profile.SmeProfile smeProfile);
        Task Update(Domain.Profile.SmeProfile smeProfile);
        Task Delete(int id);
        Task<List<SmeProfile>> Read();
        Task<SmeProfile> ReadById(int? id);
        Task<List<SmeProfile>> ReadLast(int count);
    }
}
