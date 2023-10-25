using B2B.Domain.Event;
using B2B.Framework.Contracts.Markers;

namespace B2B.Application.Contracts.Repository.Event;

public interface IEventInfoRepository : IRepository
{
    Task<EventInfo> ReadEventInfoById(int id);

    Task Delete(int id);

    Task Update(EventInfo ev);

    Task Create(EventInfo ev);

    Task<List<EventInfo>> ReadEventInfos();
}