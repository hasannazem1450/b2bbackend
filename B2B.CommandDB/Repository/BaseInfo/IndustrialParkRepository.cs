using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.Contracts.Commands.BaseInfo.IndustrialPark;
using B2B.Application.Contracts.Repository.BaseInfo;
using B2B.CommandDB;
using B2B.Domain.BaseInfo;
using B2B.Utilities.Extensions;
using Microsoft.EntityFrameworkCore;

namespace B2B.CommandDb.Repository.BaseInfo
{
    public class IndustrialParkRepository : BaseRepository, IIndustrialParkRepository
    {
        public IndustrialParkRepository(BaseProjectCommandDb db) : base(db)
        {
        }

        public async Task<List<IndustrialPark>> ReadIndustrialParkByDto(IndustrialParkDto industrialParkDto)
        {
            var query = _Db.IndustrialParks.AsQueryable();

            if (industrialParkDto.Id != null)
                query = query.Where(q => q.Id == industrialParkDto.Id);
            if (industrialParkDto.Code != null)
                query = query.Where(q => q.Code == q.Code);
            if (!industrialParkDto.Name.IsNullOrEmptyExtension())
                query = query.Where(q => q.Name == q.Name);

            return await query.ToListAsync();

        }

        public async Task<IndustrialPark> ReadIndustrialParkById(int id)
        {
            var result = await _Db.IndustrialParks.FirstOrDefaultAsync(i => i.Id == id);

            return result;
        }

        public async Task<List<IndustrialPark>> Read()
        {
            var result = await _Db.IndustrialParks.ToListAsync();

            return result;
        }
    }
}
