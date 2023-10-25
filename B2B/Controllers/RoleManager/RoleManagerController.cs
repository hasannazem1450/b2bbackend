using System.Threading;
using System.Threading.Tasks;
using B2B.Application.Contracts.Commands.Authentication;
using B2B.Application.Contracts.Commands.RoleManager;
using B2B.Application.Contracts.Queries.RoleManager;
using B2B.Controllers;
using B2B.Framework.Contracts.Makers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace B2B.Host.Controllers.RoleManager
{

    namespace B2B.Host.Controllers.Authentication
    {
        public class RoleManagerController : MainController
        {
            public RoleManagerController(IDistributor distributor) : base(distributor)
            {
            }

            [HttpPost("create-role")]
            public async Task<IActionResult> CreateRole(CreateRoleCommand query, CancellationToken cancellationToken)
            {
                var result = await Distributor.Push<CreateRoleCommand, CreateRollCommandResponse>(query, cancellationToken);

                return OkApiResult(result);
            }

            [HttpDelete("delete-role")]
            public async Task<IActionResult> DeleteRole(DeleteRoleCommand query, CancellationToken cancellationToken)
            {
                var result = await Distributor.Push<DeleteRoleCommand, DeleteRoleCommandResponse>(query, cancellationToken);

                return OkApiResult(result);
            }

            [HttpPut("update-role")]
            public async Task<IActionResult> UpdateRole(UpdateRoleCommand query, CancellationToken cancellationToken)
            {
                var result = await Distributor.Push<UpdateRoleCommand, UpdateRoleCommandResponse>(query, cancellationToken);

                return OkApiResult(result);
            }

            [HttpGet("read-role")]
            public async Task<IActionResult> ReadRole(CancellationToken cancellationToken)
            {
                var result = await Distributor.Send<ReadRoleQuery, ReadRoleQueryResponse>(new ReadRoleQuery(), cancellationToken);

                return OkApiResult(result);
            }
        }
    }
}
