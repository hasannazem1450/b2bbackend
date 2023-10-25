using B2B.Application.Contracts.Commands.Event;
using B2B.Application.Contracts.Repository.Event;
using B2B.Domain.Event;
using B2B.Framework.Contracts.Abstracts;

namespace B2B.Application.CommandHandlers.Event;

public class CreateEventInfoCommandHandler : CommandHandler<CreateEventInfoCommand, CreateEventInfoCommandResponse>
{
    private readonly IEventInfoRepository _eventRepository;


    public CreateEventInfoCommandHandler(IEventInfoRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public override async Task<CreateEventInfoCommandResponse> Executor(CreateEventInfoCommand command)
    {
        var ev = new EventInfo(command.Name, command.Photo, command.StartDate, command.EndDate, command.Periority,
            command.ProvinceId);

        await _eventRepository.Create(ev);

        return new CreateEventInfoCommandResponse();
    }
}