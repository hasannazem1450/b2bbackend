using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.Contracts.Commands.BaseInfo.IndustrialPark;
using B2B.Application.Contracts.Repository.BaseInfo;
using B2B.Application.Contracts.Services.BaseInfo.IndustrialPark;

namespace B2B.Application.Services.BaseInfo.IndustrialPark
{
    public class IndustrialParkService : IIndustrialParkService
    {
        private readonly IIndustrialParkRepository _industrialParkRepository;

        public IndustrialParkService(IIndustrialParkRepository industrialParkRepository)
        {
            _industrialParkRepository = industrialParkRepository;
        }

        public async Task<List<IndustrialParkDto>> Read()
        {
            var industrialPark = await _industrialParkRepository.Read();

            var result = new List<IndustrialParkDto>();

            foreach (var item in industrialPark)
            {
                var dto = new IndustrialParkDto()
                {
                    Id = item.Id,
                    Code = item.Code,
                    Name = item.Name,
                };

                result.Add(dto);
            }

            return result;
        }
    }
}
