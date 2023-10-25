using B2B.Domain.Event;
using B2B.Domain.Profile;
using B2B.Framework.Contracts.Abstracts;

namespace B2B.Domain.BaseInfo;

public class Province : Entity<int>
{
    public Province(string name, int? code, int countryId)
    {
        Name = name;
        Code = code;
        CountryId = countryId;
    }

    public int Id { get; protected set; }
    public string Name { get; protected set; }
    public int? Code { get; protected set; }

    public int CountryId { get; protected set; }
    public Country Country { get; protected set; }

    public ICollection<City> Cities { get; set; }
    public ICollection<EventInfo> EventsInfos { get; set; }
}