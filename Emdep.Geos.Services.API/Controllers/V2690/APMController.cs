using Asp.Versioning;
using Emdep.Geos.API.Configuration; // Namespace dos settings
using Emdep.Geos.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Emdep.Geos.API.Controllers.V2690;

[ApiController]
[Route("api/v{version:apiVersion}/apm")]
[ApiVersion("2690")]
public class APMController : ControllerBase
{
    private readonly IConfiguration _config;
    private readonly APMSettings _settings;

    public APMController(IConfiguration config, IOptions<APMSettings> settings)
    {
        _config = config;
        _settings = settings.Value;
    }

    private string GetConn() => _config.GetConnectionString("WorkbenchContext");

    [HttpGet("details")]
    public ActionResult<List<APMActionPlan>> GetActionPlanDetails(string selectedPeriod, int idUser)
    {
        try
        {
            APMManager mgr = new APMManager();
            // Requer ConnectionString e CountryFilePath
            return Ok(mgr.GetActionPlanDetails_V2690(
                GetConn(),
                selectedPeriod,
                idUser,
                _settings.Paths.CountryFilePath));
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = ex.Message });
        }
    }

    [HttpGet("authorized-locations/{idUser}")]
    public ActionResult<List<Company>> GetAuthorizedLocationListByIdUser(int idUser)
    {
        try
        {
            APMManager mgr = new APMManager();
            // Requer ConnectionString e CountryFilePath
            return Ok(mgr.GetAuthorizedLocationListByIdUser_V2690(
                GetConn(),
                idUser,
                _settings.Paths.CountryFilePath));
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = ex.Message });
        }
    }
}