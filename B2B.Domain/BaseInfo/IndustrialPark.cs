using B2B.Domain.Profile;
using B2B.Framework.Contracts.Abstracts;

namespace B2B.Domain.BaseInfo;

public class IndustrialPark : Entity<int>
{
    public IndustrialPark(string name, int? code)
    {
        Name = name;
        Code = code;
    }

    public int Id { get; set; }
    public int? Code { get; set; }
    public string Name { get; set; }

    public ICollection<SmeProfile> SmeProfiles { get; set; }
}