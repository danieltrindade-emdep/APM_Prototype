using Asp.Versioning;
using Emdep.Geos.Core.Interfaces;
using Emdep.Geos.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Emdep.Geos.API.Controllers.V2590;

[ApiController]
[Route("api/v{version:apiVersion}/apm")]
[ApiVersion("2590")]
public class APMController(IAPMRepository repository) : ControllerBase
{

    [HttpGet("departments")]
    public async Task<ActionResult<List<Department>>> GetDepartments(CancellationToken cancellationToken)
    {
        var data = await repository.GetDepartmentsForActionPlanAsync(cancellationToken);
        return Ok(data);
    }
}