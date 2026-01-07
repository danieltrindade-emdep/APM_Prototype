using Asp.Versioning;
using Emdep.Geos.Core.Interfaces;
using Emdep.Geos.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Emdep.Geos.API.Controllers.V2670;

[ApiController]
[Route("api/v{version:apiVersion}/apm")]
[ApiVersion("2670")]
public class APMController(IAPMRepository repository, ILogger<APMController> logger) : ControllerBase
{

    [HttpGet("responsibles-by-location")]
    public async Task<ActionResult<List<Responsible>>> GetResponsibleByLocation([FromQuery] string idCompanyLocation, CancellationToken cancellationToken)
    {
        logger.LogInformation("Fetching responsibles for Location: {LocationId}", idCompanyLocation);
        var data = await repository.GetResponsibleByLocationAsync(idCompanyLocation, cancellationToken);
        return Ok(data);
    }
}