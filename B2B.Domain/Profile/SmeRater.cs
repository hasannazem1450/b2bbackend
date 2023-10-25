using B2B.Framework.Contracts.Abstracts;

namespace B2B.Domain.Profile;

public class SmeRater : Entity<int>
{
    public SmeRater(string raterName)
    {
        RaterName = raterName;
    }

    public int Id { get; protected set; }
    public string RaterName { get; protected set; }
    public ICollection<SmeProfile> SmeProfiles { get; set; }
}