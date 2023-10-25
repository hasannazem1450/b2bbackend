using System.Threading;
using System.Threading.Tasks;
using B2B.Application.Contracts.Commands.Event;
using B2B.Application.Contracts.Queries.Event;
using B2B.Controllers;
using B2B.Framework.Contracts.Makers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace B2B.Host.Controllers.Event;

[AllowAnonymous]
public class EventAttenderController : MainController
{
    public EventAttenderController(IDistributor distributor) : base(distributor)
    {
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(CreateEventAttenderCommand command, CancellationToken cancellationToken)
    {
        var result =
            await Distributor.Push<CreateEventAttenderCommand, CreateEventAttenderCommandResponse>(command,
                cancellationToken);

        return OkApiResult(result);
    }

    [HttpGet("read-attender-types")]
    public async Task<IActionResult> ReadAttenderTypes([FromQuery] ReadAttenderTypesQuery query,
        CancellationToken cancellationToken)
    {
        var result =
            await Distributor.Send<ReadAttenderTypesQuery, ReadAttenderTypesQueryResponse>(query, cancellationToken);

        return OkApiResult(result);
    }
}