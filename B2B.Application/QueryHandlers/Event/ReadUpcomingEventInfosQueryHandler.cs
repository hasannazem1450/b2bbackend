using B2B.Application.Contracts.Commands.Event;
using B2B.Application.Contracts.Queries.Event;
using B2B.Application.Contracts.Repository.Event;
using B2B.Framework.Contracts.Markers;
using System.Linq;
using B2B.Application.Contracts.Services.Event;

namespace B2B.Application.QueryHandlers.Event;

public class
    ReadUpcomingEventInfosQueryHandler : IQueryHandler<ReadUpcomingEventInfosQuery, ReadUpcomingEventInfosQueryResponse>
{
    private readonly IEventInfoRepository _eventInfoRepository;
    private readonly IEventInfoService _eventInfoService;

    public ReadUpcomingEventInfosQueryHandler(IEventInfoRepository eventInfoRepository, IEventInfoService eventInfoService)
    {
        _eventInfoRepository = eventInfoRepository;
        _eventInfoService = eventInfoService;
    }

    public async Task<ReadUpcomingEventInfosQueryResponse> Execute(ReadUpcomingEventInfosQuery query, CancellationToken cancellationToken)
    {
        var fromDate = DateTime.Today;
        var toDate = DateTime.Today.AddDays(60);

        var eventInfos = await _eventInfoRepository.ReadEventInfos();

        var eventInfosDto = await _eventInfoService.ConvertToDto(eventInfos);
        eventInfosDto = await _eventInfoService.FilterByDate(eventInfosDto, fromDate, toDate);

        var result = new ReadUpcomingEventInfosQueryResponse
        {
            List = eventInfosDto
        };

        return result;
    }
}