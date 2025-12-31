using Asp.Versioning;
using Emdep.Geos.Core.Interfaces;
using Emdep.Geos.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Emdep.Geos.API.Controllers.V2550;

[ApiController]
[Route("api/v{version:apiVersion}/apm")]
[ApiVersion("2550")]
public class APMController : ControllerBase
{
    private readonly IAPMRepository _repository;

    public APMController(IAPMRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("lookupvalues/{key}")]
    public async Task<ActionResult<IEnumerable<LookupValue>>> GetLookupValues(int key)
    {
        try
        {
            var data = await _repository.GetLookupValuesAsync(key);
            return Ok(data);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = ex.Message });
        }
    }
}