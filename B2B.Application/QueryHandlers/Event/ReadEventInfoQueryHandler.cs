using B2B.Application.Contracts.Queries.Event;
using B2B.Application.Contracts.Repository.Event;
using B2B.Application.Contracts.Services.Event;
using B2B.Framework.Contracts.Markers;

namespace B2B.Application.QueryHandlers.Event;

public class ReadEventInfoQueryHandler : IQueryHandler<ReadEventInfoQuery, ReadEventInfoQueryResponse>
{
    private readonly IEventInfoRepository _eventInfoRepository;
    private readonly IEventInfoService _eventInfoService;

    public ReadEventInfoQueryHandler(IEventInfoRepository eventInfoRepository, IEventInfoService eventInfoService)
    {
        _eventInfoRepository = eventInfoRepository;
        _eventInfoService = eventInfoService;
    }

    public async Task<ReadEventInfoQueryResponse> Execute(ReadEventInfoQuery query, CancellationToken cancellationToken)
    {
        var eventInfo = await _eventInfoRepository.ReadEventInfoById(query.Id);

        var result = new ReadEventInfoQueryResponse
        {
            Data = await _eventInfoService.ConvertToDto(eventInfo)
        };

        return result;
    }
}