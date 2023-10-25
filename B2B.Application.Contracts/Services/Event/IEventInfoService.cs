using B2B.Application.Contracts.Commands.Event;
using B2B.Domain.Event;
using B2B.Framework.Contracts.Common.Enums;
using B2B.Framework.Contracts.Markers;

namespace B2B.Application.Contracts.Services.Event;

public interface IEventInfoService : IService
{
    Task<List<EventInfoDto>> ConvertToDto(List<EventInfo> eventInfos);
    Task<EventInfoDto> ConvertToDto(EventInfo eventInfo);


    Task<EventInfoState> GetState(EventInfo eventInfo);

    Task<List<EventInfoDto>> FilterByName(List<EventInfoDto> eventInfos, string name);
    Task<List<EventInfoDto>> FilterByProvince(List<EventInfoDto> eventInfos, int provinceId);
    Task<List<EventInfoDto>> FilterByState(List<EventInfoDto> eventInfos, EventInfoState eventInfoState);
    Task<List<EventInfoDto>> FilterByState(List<EventInfoDto> eventInfos, List<EventInfoState> eventInfoStates);
    Task<List<EventInfoDto>> FilterByDate(List<EventInfoDto> eventInfos, DateTime fromDate, DateTime toDate);
}