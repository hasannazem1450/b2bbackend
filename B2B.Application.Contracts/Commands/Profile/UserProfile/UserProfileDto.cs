using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2B.Application.Contracts.Commands.Profile.UserProfile
{
    public class UserProfileDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string ProfileName { get; set; }
        public string ProfileLogo { get; set; }
        public int ProfileType { get; set; }
        public Guid UserId { get; set; }  
        public int ProfileId { get; set; }  
    }
}
