using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.Contracts.Commands.BaseInfo.IndustrialPark;
using B2B.Framework.Contracts.Markers;

namespace B2B.Application.Contracts.Services.BaseInfo.IndustrialPark
{
    public interface IIndustrialParkService : IService
    {
        Task<List<IndustrialParkDto>> Read();
    }
}
