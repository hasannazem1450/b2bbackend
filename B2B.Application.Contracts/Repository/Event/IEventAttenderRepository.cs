using B2B.Domain.Event;
using B2B.Framework.Contracts.Markers;

namespace B2B.Application.Contracts.Repository.Event;

public interface IEventAttenderRepository : IRepository
{
    Task Create(EventAttender eventAttender);
    Task<EventAttender> ReadById(int id);
    Task<List<EventAttender>> ReadByEvent(int eventId);
    Task<List<EventAttender>> ReadByAttender(int smeProfileId);
}