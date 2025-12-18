using Asp.Versioning;
using Emdep.Geos.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Emdep.Geos.API.Controllers.V2590;

[ApiController]
[Route("api/v{version:apiVersion}/apm")]
[ApiVersion("2590")]
public class APMController : ControllerBase
{
    private readonly IConfiguration _config;

    public APMController(IConfiguration config)
    {
        _config = config;
    }

    [HttpGet("departments")]
    public ActionResult<List<Department>> GetDepartments()
    {
        try
        {
            APMManager mgr = new APMManager();
            string conn = _config.GetConnectionString("WorkbenchContext");

            return Ok(mgr.GetDepartmentsForActionPlan_V2590(conn));
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = ex.Message });
        }
    }
}