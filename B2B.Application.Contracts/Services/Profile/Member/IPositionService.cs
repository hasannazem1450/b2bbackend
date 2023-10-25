using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.Contracts.Commands.Profile.Position;
using B2B.Framework.Contracts.Markers;

namespace B2B.Application.Contracts.Services.Profile.Member
{
    public interface IPositionService : IService
    {

        Task<List<PositionDto>> Read();

        Task<PositionDto> ReadById(int id);
    }
}
