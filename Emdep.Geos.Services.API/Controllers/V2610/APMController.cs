using Asp.Versioning;
using Emdep.Geos.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Emdep.Geos.API.Controllers.V2610;

[ApiController]
[Route("api/v{version:apiVersion}/apm")]
[ApiVersion("2610")]
public class APMController : ControllerBase
{
    private readonly IConfiguration _config;

    public APMController(IConfiguration config)
    {
        _config = config;
    }

    [HttpGet("customers-with-site")]
    public ActionResult<List<APMCustomer>> GetCustomersWithSite()
    {
        try
        {
            APMManager mgr = new APMManager();
            string conn = _config.GetConnectionString("WorkbenchContext");

            return Ok(mgr.GetCustomersWithSite_V2610(conn));
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = ex.Message });
        }
    }
}