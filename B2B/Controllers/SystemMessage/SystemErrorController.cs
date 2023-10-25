using System.Threading;
using System.Threading.Tasks;
using B2B.Application.Contracts.Commands.SystemMessage;
using B2B.Application.Contracts.Queries.SystemMessages;
using B2B.Configurations.RegisterTypes;
using B2B.Controllers;
using B2B.Framework.Contracts.Abstracts;
using B2B.Framework.Contracts.Makers;
using Microsoft.AspNetCore.Mvc;

namespace B2B.Host.Controllers.SystemMessage
{
    public class SystemErrorController : MainController
    {
        public SystemErrorController(IDistributor distributor) : base(distributor)
        {
        }

        [HttpGet("get-all-system-errors")]
        public async Task<IActionResult> GetAllSystemErrors(CancellationToken cancellation)
        {
            var query = new GetAllSystemErrorsQuery();

            var result = await Distributor.Send<GetAllSystemErrorsQuery, GetAllSystemErrorsQueryResponse>(query, cancellation);

            return OkApiResult(result.List);
        }

        [HttpPost("create-system-error-command")]
        public async Task<IActionResult> CreateSystemError(CreateSystemMessageCommand command,
            CancellationToken cancellation)
        {
            var result = await Distributor.Push<CreateSystemMessageCommand, CommandResponse>(command, cancellation);

            return OkApiResult(result);
        }

        [HttpPut("update-system-error-command")]
        public async Task<IActionResult> UpdateSystemError(UpdateSystemMessageCommand command,
            CancellationToken cancellation)
        {
            var result = await Distributor.Push<UpdateSystemMessageCommand, CommandResponse>(command, cancellation);

            return OkApiResult(result);
        }

        [HttpDelete("delete-system-error-message-by-language")]
        public async Task<IActionResult> DeleteSystemErrorMessageByLanguage(DeleteSystemMessageByLanguageCommand command,
            CancellationToken cancellation)
        {
            var result = await Distributor.Push<DeleteSystemMessageByLanguageCommand, CommandResponse>(command, cancellation);

            return OkApiResult(result);
        }
    }
}
