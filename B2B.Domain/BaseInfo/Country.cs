using B2B.Framework.Contracts.Abstracts;

namespace B2B.Domain.BaseInfo;

public class Country : Entity<int>
{
    public Country(string name, int? code)
    {
        Name = name;
        Code = code;
    }

    public int Id { get; protected set; }
    public string Name { get; protected set; }
    public int? Code { get; protected set; }

    public ICollection<Province> Provinces { get; set; }
}