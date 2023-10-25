using B2B.Application.Contracts.Commands.Event;
using B2B.Application.Contracts.Repository.Event;
using B2B.Domain.Event;
using B2B.Framework.Contracts.Abstracts;
using B2B.Framework.Contracts.Common.Enums;

namespace B2B.Application.CommandHandlers.Event;

public class CreateEventAttenderCommandHandler : CommandHandler<CreateEventAttenderCommand, CreateEventAttenderCommandResponse>
{
    private readonly IEventAttenderRepository _eventAttenderRepository;

    public CreateEventAttenderCommandHandler(IEventAttenderRepository eventAttenderRepository)
    {
        _eventAttenderRepository = eventAttenderRepository;
    }

    public override async Task<CreateEventAttenderCommandResponse> Executor(CreateEventAttenderCommand command)
    {
        var eventAttender = new EventAttender(command.SmeProfileId, command.EventInfoId, (EventAttenderType)command.EventAttenderType,
            command.ContactNumber);

        await _eventAttenderRepository.Create(eventAttender);

        return new CreateEventAttenderCommandResponse();
    }
}