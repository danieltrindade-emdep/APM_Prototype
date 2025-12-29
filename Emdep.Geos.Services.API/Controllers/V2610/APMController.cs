using Asp.Versioning;
using Emdep.Geos.Core.Interfaces;
using Emdep.Geos.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Emdep.Geos.API.Controllers.V2610;

[ApiController]
[Route("api/v{version:apiVersion}/apm")]
[ApiVersion("2610")]
public class APMController : ControllerBase
{
    private readonly IAPMRepository _repository;

    public APMController(IAPMRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("customers-with-site")]
    public async Task<ActionResult<List<APMCustomer>>> GetCustomersWithSite()
    {
        try
        {
            var data = await _repository.GetCustomersWithSitesAsync();

            return Ok(data);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = ex.Message });
        }
    }
}