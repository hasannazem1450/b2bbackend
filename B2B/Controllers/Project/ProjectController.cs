using System.Threading;
using System.Threading.Tasks;
using B2B.Application.Contracts.Commands;
using B2B.Application.Contracts.Repository;
using B2B.Framework.Contracts.Makers;
using Microsoft.AspNetCore.Mvc;

namespace B2B.Controllers.Project
{
    public class ProjectController : MainController
    {
        public ProjectController(IDistributor distributor) : base(distributor)
        {
        }

        [HttpPost("create-project")]
        public async Task<IActionResult> GetPaymentToken(CreateProjectCommand query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<CreateProjectCommand, CreateProjectCommandResponse>(query, cancellationToken);

            return OkApiResult(result);
        }
    }
}
