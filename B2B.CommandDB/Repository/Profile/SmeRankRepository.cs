using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.Contracts.Repository.Profile;
using B2B.CommandDB;
using B2B.Domain.Profile;
using Microsoft.EntityFrameworkCore;

namespace B2B.CommandDb.Repository.Profile
{
    public class SmeRankRepository : BaseRepository, ISmeRankRepository
    {
        public SmeRankRepository(BaseProjectCommandDb db) : base(db)
        {
        }

        public async Task<SmeRank> ReadSmeRankById(int id)
        {
            var result = await _Db.SmeRanks.FirstOrDefaultAsync(s => s.Id == id);

            return result;
        }
    }
}
