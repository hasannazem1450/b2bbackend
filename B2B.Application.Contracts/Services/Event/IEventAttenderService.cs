using B2B.Application.Contracts.Commands.Event;
using B2B.Domain.Event;
using B2B.Framework.Contracts.Markers;

namespace B2B.Application.Contracts.Services.Event;

public interface IEventAttenderService : IService
{
    Task<List<EventAttenderDto>> ConvertToDto(List<EventAttender> eventAttenders);
    Task<EventAttenderDto> ConvertToDto(EventAttender eventAttender);
}