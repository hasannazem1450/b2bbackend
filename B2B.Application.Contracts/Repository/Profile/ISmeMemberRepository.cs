using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Domain.Profile;
using B2B.Framework.Contracts.Markers;

namespace B2B.Application.Contracts.Repository.Profile
{
    public interface ISmeMemberRepository : IRepository
    {
        Task<SmeMember> ReadById(int id);

        Task<List<SmeMember>> Read();

        Task Delete(int id);

        Task Update(SmeMember smeMember);

        Task Create(SmeMember smeMember);
    }
}
