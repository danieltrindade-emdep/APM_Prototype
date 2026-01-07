using Asp.Versioning;
using Emdep.Geos.Core.Interfaces;
using Emdep.Geos.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Emdep.Geos.API.Controllers.V2550;

[ApiController]
[Route("api/v{version:apiVersion}/apm")]
[ApiVersion("2550")]
public class APMController(IAPMRepository repository, ILogger<APMController> logger) : ControllerBase
{

    [HttpGet("lookupvalues/{key}")]
    public async Task<ActionResult<IEnumerable<LookupValue>>> GetLookupValues(int key, CancellationToken cancellationToken)
    {
        logger.LogInformation("Fetching lookup values for Key: {Key}", key);
        var data = await repository.GetLookupValuesAsync(key, cancellationToken);
        return Ok(data);
    }
}