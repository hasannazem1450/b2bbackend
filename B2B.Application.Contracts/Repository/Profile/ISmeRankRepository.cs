using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Domain.Profile;
using B2B.Framework.Contracts.Markers;

namespace B2B.Application.Contracts.Repository.Profile
{
    public interface ISmeRankRepository : IRepository
    {
        Task<SmeRank> ReadSmeRankById (int id);
    }
}
