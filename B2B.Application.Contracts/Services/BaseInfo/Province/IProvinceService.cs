using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.Contracts.Commands.BaseInfo.Province;
using B2B.Framework.Contracts.Markers;

namespace B2B.Application.Contracts.Services.BaseInfo.Province
{
    public interface IProvinceService : IService
    {
        //Task<List<ProvinceDto>> Read();
        Task<List<ProvinceDtoDropdown>> Read();
    }
}
