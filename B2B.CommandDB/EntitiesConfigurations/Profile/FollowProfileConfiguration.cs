using B2B.Domain.Profile.FollowProfile;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace B2B.CommandDb.EntitiesConfigurations.Profile
{
    public class FollowProfileConfiguration : IEntityTypeConfiguration<FollowProfile>
    {
        public void Configure(EntityTypeBuilder<FollowProfile> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
