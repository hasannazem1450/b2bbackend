using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.Contracts.Commands.Profile.SmeMember;
using B2B.Framework.Contracts.Markers;

namespace B2B.Application.Contracts.Services.Profile
{
    public interface ISmeMemberService : IService
    {
        Task<SmeMemberDto> ReadById(int id);

        Task<List<SmeMemberDto>> Read();
    }
}
