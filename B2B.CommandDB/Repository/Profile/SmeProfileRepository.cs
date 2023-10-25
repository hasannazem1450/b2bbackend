using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B2B.Application.Contracts.Repository;
using B2B.Application.Contracts.Repository.Profile;
using B2B.CommandDB;
using B2B.Domain.Profile;
using Microsoft.EntityFrameworkCore;

namespace B2B.CommandDb.Repository.Profile
{
    public class SmeProfileRepository : BaseRepository, ISmeProfileRepository
    {
        public SmeProfileRepository(BaseProjectCommandDb db) : base(db)
        {
        }

        public async Task Create(Domain.Profile.SmeProfile smeProfile)
        {
            await _Db.SmeProfiles.AddAsync(smeProfile);
            await _Db.SaveChangesAsync();
            var smeprofileforselector = _Db.SmeProfiles.Where(x => x.Id == smeProfile.Id).FirstOrDefault();
            
            if (smeprofileforselector != null)
            {
                UserProfile userProfile = new UserProfile()
                {
                    UserId = smeProfile.CreatedBy,
                    ProfileId = smeProfile.Id,
                    ProfileName = smeProfile.SmeName,
                    ProfileLogo = smeProfile.Logo,
                    ProfileType = (int)smeProfile.SmeRankId,
                    UserName = ""
                };
                await _Db.UserProfiles.AddAsync(userProfile);
                await _Db.SaveChangesAsync();
            }

        }

        public async Task Update(SmeProfile smeProfile)
        {
            _Db.SmeProfiles.Update(smeProfile);

            await _Db.SaveChangesAsync();
        }

        public async Task<List<SmeProfile>> Read()
        {
            var result = await _Db.SmeProfiles.Include(i => i.City).Include(i => i.IndustrialPark).ToListAsync();

            return result;
        }

        public async Task<SmeProfile> ReadById(int? id)
        {
            var result = await _Db.SmeProfiles.Include(i => i.City.Province).Include(i => i.IndustrialPark).FirstOrDefaultAsync(s => s.Id == id);

            return result;
        }

        public async Task Delete(int id)
        {
            var smeProfile = await _Db.SmeProfiles.FirstOrDefaultAsync(s => s.Id == id);
            smeProfile.SetIsDeleted(true);

            await _Db.SaveChangesAsync();
        }

        public async Task<List<SmeProfile>> ReadLast(int count)
        {
            var result = await _Db.SmeProfiles.Include(i => i.City).Include(i => i.IndustrialPark).OrderByDescending(o => o.Id).Take(count).ToListAsync();

            return result;
        }
    }
}
