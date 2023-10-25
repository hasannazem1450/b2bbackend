using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.Contracts.Commands.BaseInfo.Province;
using B2B.Application.Contracts.Repository.BaseInfo;
using B2B.Application.Contracts.Services.BaseInfo.Province;

namespace B2B.Application.Services.BaseInfo.Province
{
    public class ProvinceService : IProvinceService
    {
        private readonly IProvinceRepository _provinceRepository;

        public ProvinceService(IProvinceRepository provinceRepository)
        {
            _provinceRepository = provinceRepository;
        }

        //public async Task<List<ProvinceDto>> Read()
        //{
        //    var province = await _provinceRepository.Read();

        //    var result = new List<ProvinceDto>();

        //    foreach (var item in province)
        //    {
        //        var dto = new ProvinceDto()
        //        {
        //            Id = item.Id,
        //            ProvinceCode = item.Code,
        //            Cities = item.Cities,
        //            Country = item.Country,
        //            ProvinceName = item.Name,
        //            SmeProfiles = item.SmeProfiles,
        //        };

        //        result.Add(dto);
        //    }

        //    return result;
        //}

        public async Task<List<ProvinceDtoDropdown>> Read()
        {
            var province = await _provinceRepository.Read();

            var result = new List<ProvinceDtoDropdown>();

            foreach (var item in province)
            {
                var dto = new ProvinceDtoDropdown()
                {
                    Value = item.Id,
                    Label = item.Name,
                };

                result.Add(dto);
            }

            return result;
        }

        public async Task<List<ProvinceDtoDropdown>> ReadForDropdown()
        {
            var province = await _provinceRepository.Read();

            var result = new List<ProvinceDtoDropdown>();

            foreach (var item in province)
            {
                var dto = new ProvinceDtoDropdown()
                {
                    Value = item.Id,
                    Label = item.Name,
                };

                result.Add(dto);
            }

            return result;
        }
    }
}
