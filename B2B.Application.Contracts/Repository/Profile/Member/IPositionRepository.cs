using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Domain.Profile.Member;
using B2B.Framework.Contracts.Markers;

namespace B2B.Application.Contracts.Repository.Profile.Member
{
    public interface IPositionRepository : IRepository
    {
        Task Create(Position position);

        Task Update(Position position);

        Task<List<Position>> Read();

        Task<Position> ReadById(int id);

        Task Delete(int id);
    }
}
