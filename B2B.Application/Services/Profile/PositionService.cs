using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.Contracts.Commands.Profile.Position;
using B2B.Application.Contracts.Repository.Profile.Member;
using B2B.Application.Contracts.Services.Profile.Member;

namespace B2B.Application.Services.Profile
{
    public class PositionService : IPositionService
    {

        private readonly IPositionRepository _positionRepository;

        public PositionService(IPositionRepository positionRepository)
        {
            _positionRepository = positionRepository;
        }

        public async Task<List<PositionDto>> Read()
        {
            var position = await _positionRepository.Read();

            var result = new List<PositionDto>();

            foreach (var item in position)
            {
                var dto = new PositionDto()
                {
                    Id = item.Id,
                    Name = item.Name,
                };

                result.Add(dto);
            }

            return result;
        }

        public async Task<PositionDto> ReadById(int id)
        {
            var result = await _positionRepository.ReadById(id);

            var dto = new PositionDto()
            {
                Id = result.Id,
                Name = result.Name
            };

            return dto;
        }
    }
}
