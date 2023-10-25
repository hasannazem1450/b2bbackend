using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.Contracts.Commands.BaseInfo.Province;
using B2B.Domain.BaseInfo;
using B2B.Framework.Contracts.Markers;

namespace B2B.Application.Contracts.Repository.BaseInfo
{
    public interface IProvinceRepository :IRepository
    {
        Task<List<Province>> ReadByDto(ProvinceDto provinceDto);
        Task<Province> ReadById(int id);
        Task<List<Province>> Read();
    }
}
