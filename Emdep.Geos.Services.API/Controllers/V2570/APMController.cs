using Asp.Versioning;
using Emdep.Geos.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Emdep.Geos.API.Controllers.V2570;

[ApiController]
[Route("api/v{version:apiVersion}/apm")]
[ApiVersion("2570")]
public class APMController : ControllerBase
{
    private readonly IConfiguration _config;

    public APMController(IConfiguration config)
    {
        _config = config;
    }

    [HttpGet("responsibles")]
    public ActionResult<List<Responsible>> GetActiveInactiveResponsible(
        int idCompany,
        string selectedPeriod,
        string idsOrganization,
        string idsDepartments,
        int idPermission)
    {
        try
        {
            APMManager mgr = new APMManager();
            string conn = _config.GetConnectionString("WorkbenchContext");

            return Ok(mgr.GetActiveInactiveResponsibleForActionPlan_V2570(
                conn, idCompany, selectedPeriod, idsOrganization, idsDepartments, idPermission));
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = ex.Message });
        }
    }
}