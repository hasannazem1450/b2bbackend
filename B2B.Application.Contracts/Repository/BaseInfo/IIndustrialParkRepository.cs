using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.Contracts.Commands.BaseInfo.IndustrialPark;
using B2B.Domain.BaseInfo;
using B2B.Framework.Contracts.Markers;

namespace B2B.Application.Contracts.Repository.BaseInfo
{
    public interface IIndustrialParkRepository :IRepository
    {
        Task<List<Domain.BaseInfo.IndustrialPark>> ReadIndustrialParkByDto(IndustrialParkDto industrialParkDto);
        Task<Domain.BaseInfo.IndustrialPark> ReadIndustrialParkById(int id);
        Task<List<Domain.BaseInfo.IndustrialPark>> Read();
    }
}
