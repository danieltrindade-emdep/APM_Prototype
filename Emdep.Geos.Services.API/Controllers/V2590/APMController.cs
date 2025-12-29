using Asp.Versioning;
using Emdep.Geos.Core.Interfaces;
using Emdep.Geos.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Emdep.Geos.API.Controllers.V2590;

[ApiController]
[Route("api/v{version:apiVersion}/apm")]
[ApiVersion("2590")]
public class APMController : ControllerBase
{
    private readonly IAPMRepository _repository;

    public APMController(IAPMRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("departments")]
    public async Task<ActionResult<List<Department>>> GetDepartments()
    {
        try
        {
            var data = await _repository.GetDepartmentsForActionPlanAsync();

            return Ok(data);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = ex.Message });
        }
    }
}