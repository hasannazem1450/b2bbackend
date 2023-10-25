using B2B.Framework.Contracts.Abstracts;
using B2B.Framework.Contracts.Common;
using B2B.Framework.Contracts.Makers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace B2B.Controllers;

[Authorize]
[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
//[SystemMessageActionFilter]
public class MainController : ControllerBase
{
    protected readonly IDistributor Distributor;

    public MainController(IDistributor distributor)
    {
        Distributor = distributor;
    }

    protected IActionResult OkApiResult(dynamic tResult)
    {
        return Ok(new ApiResult(CommandResponseSuccessful.CreateSuccessful(), tResult));
    }

    protected IActionResult OkApiResult()
    {
        return Ok(new ApiResult(CommandResponseSuccessful.CreateSuccessful()));
    }
}