using Asp.Versioning;
using Emdep.Geos.Core.Interfaces;
using Emdep.Geos.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Emdep.Geos.API.Controllers.V2570;

[ApiController]
[Route("api/v{version:apiVersion}/apm")]
[ApiVersion("2570")]
public class APMController : ControllerBase
{
    private readonly IAPMRepository _repository;

    public APMController(IAPMRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("responsibles")]
    public async Task<ActionResult<List<Responsible>>> GetActiveInactiveResponsible(
        int idCompany,
        string selectedPeriod,
        string idsOrganization,
        string idsDepartments,
        int idPermission)
    {
        try
        {
            var data = await _repository.GetActiveInactiveResponsibleAsync(
                idCompany,
                selectedPeriod,
                idsOrganization,
                idsDepartments,
                idPermission);

            return Ok(data);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = ex.Message });
        }
    }
}