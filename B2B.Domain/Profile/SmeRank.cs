using B2B.Framework.Contracts.Abstracts;

namespace B2B.Domain.Profile;

public class SmeRank : Entity<int>
{
    public SmeRank(string title)
    {
        Title = title;
    }

    public int Id { get; set; }
    public string Title { get; set; }

    public ICollection<SmeProfile> SmeProfiles { get; set; }
}