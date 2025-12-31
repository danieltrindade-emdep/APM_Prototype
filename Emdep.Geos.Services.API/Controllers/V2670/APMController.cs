using Asp.Versioning;
using Emdep.Geos.Core.Interfaces;
using Emdep.Geos.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Emdep.Geos.API.Controllers.V2670;

[ApiController]
[Route("api/v{version:apiVersion}/apm")]
[ApiVersion("2670")]
public class APMController : ControllerBase
{
    private readonly IAPMRepository _repository;

    public APMController(IAPMRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("responsibles-by-location")]
    public async Task<ActionResult<List<Responsible>>> GetResponsibleByLocation([FromQuery] string idCompanyLocation)
    {
        try
        {
            if (string.IsNullOrEmpty(idCompanyLocation))
            {
                return BadRequest(new { error = "Parameter 'idCompanyLocation' is required." });
            }

            var data = await _repository.GetResponsibleByLocationAsync(idCompanyLocation);

            return Ok(data);
        }
        catch (Exception ex)
        {
            // Em produção, deve-se usar um logger aqui (ex: Serilog)
            return StatusCode(500, new { error = ex.Message });
        }
    }
}