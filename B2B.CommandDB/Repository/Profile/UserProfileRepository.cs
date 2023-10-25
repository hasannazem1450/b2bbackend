using B2B.Application.Contracts.Commands.Profile.UserProfile;
using B2B.Application.Contracts.Repository.Profile;
using B2B.CommandDB;
using B2B.Domain.Profile;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.CommandDb.Repository.Profile
{
    public class UserProfileRepository : BaseRepository, IUserProfileRepository
    {
        public UserProfileRepository(BaseProjectCommandDb db) : base(db)
        {
        }

        public async Task<List<UserProfile>> ReadAll()
        {
            var result = await _Db.UserProfiles.ToListAsync();

            return result;
        }
        public async Task<List<UserProfile>> ReadByUserId(Guid userid)
        {
            var result = await _Db.UserProfiles.Where(c => c.UserId == userid).ToListAsync();

            return result;
        }
        public async Task Delete(int id)
        {
            var userProfile = await _Db.UserProfiles.FirstOrDefaultAsync(s => s.Id == id);

            _Db.UserProfiles.Remove(userProfile);

            await _Db.SaveChangesAsync();

        }
        public async Task Create(UserProfile userProfile)
        {
            await _Db.UserProfiles.AddAsync(userProfile);
            await _Db.SaveChangesAsync();
        }


        public async Task<UserProfile> GetSmeTypeById(int id)
        {
            var result = await _Db.UserProfiles.FirstOrDefaultAsync(s => s.Id == id);

            return result;
        }
    }
}
