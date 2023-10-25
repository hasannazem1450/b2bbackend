using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.Contracts.Commands.BaseInfo.Province;
using B2B.Application.Contracts.Repository.BaseInfo;
using B2B.CommandDB;
using B2B.Domain.BaseInfo;
using B2B.Utilities.Extensions;
using Microsoft.EntityFrameworkCore;

namespace B2B.CommandDb.Repository.BaseInfo
{
    public class ProvinceRepository : BaseRepository, IProvinceRepository
    {
        public ProvinceRepository(BaseProjectCommandDb db) : base(db)
        {
        }

        public async Task<List<Province>> ReadByDto(ProvinceDto provinceDto)
        {
            var query = _Db.Provinces.AsQueryable();

            if (provinceDto.Id != null)
                query = _Db.Provinces.Where(p => p.Id == provinceDto.Id);

            if (provinceDto.ProvinceCode != null)
                query = _Db.Provinces.Where(p => p.Code == provinceDto.ProvinceCode);

            if (!provinceDto.ProvinceName.IsNotNullOrEmpty())
                query = _Db.Provinces.Where(p => p.Name == provinceDto.ProvinceName);

            return await query.ToListAsync();
        }

        public async Task<Province> ReadById(int id)
        {
            var result = await _Db.Provinces.FirstOrDefaultAsync(p => p.Id == id);

            return result;
        }

        public async Task<List<Province>> Read()
        {
            var result = await _Db.Provinces.ToListAsync();

            return result;
        }
    }
}
