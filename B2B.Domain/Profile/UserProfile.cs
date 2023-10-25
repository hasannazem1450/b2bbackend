using B2B.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.Domain.Profile
{
    public class UserProfile : Entity<int>
    {
        public UserProfile()
        {
            //TODO:Create Guard
            //UserId = userid;
        }
        public UserProfile(Guid userid ,int profileid ,string profilelogo,string profilename ,string username ,int profiletype)
        {
            //TODO:Create Guard
            UserId = userid;
            ProfileId = profileid;  
            ProfileType = profiletype;
            ProfileName = profilename;
            ProfileLogo = profilelogo;
            UserName = username;

        }

        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int ProfileId { get; set; }
        public string ProfileLogo { get; set; }
        public string ProfileName { get; set; }
        public string UserName { get; set; }
        public int ProfileType { get; set; }

    }
}
