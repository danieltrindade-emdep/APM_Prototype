using Asp.Versioning;
using Emdep.Geos.Core.Interfaces;
using Emdep.Geos.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Emdep.Geos.API.Controllers.V2550;

[ApiController]
[Route("api/v{version:apiVersion}/apm")]
[ApiVersion("2550")]
public class APMController(IAPMRepository repository) : ControllerBase
{

    [HttpGet("lookupvalues/{key}")]
    public async Task<ActionResult<IEnumerable<LookupValue>>> GetLookupValues(int key)
    {
        var data = await repository.GetLookupValuesAsync(key);
        return Ok(data);
    }
}