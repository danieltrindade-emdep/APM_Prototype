using Asp.Versioning;
using Emdep.Geos.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Emdep.Geos.API.Controllers.V2550;

[ApiController]
[Route("api/v{version:apiVersion}/apm")]
[ApiVersion("2550")]
public class APMController : ControllerBase
{
    // Esta versão não precisa de config nem settings (o método antigo não pedia)

    [HttpGet("lookup-values/{key}")]
    public ActionResult<IList<LookupValue>> GetLookupValues(byte key)
    {
        try
        {
            // O código original usava CrmManager
            CrmManager mgr = new CrmManager();
            var list = mgr.GetLookupValues(key);
            return Ok(list);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = ex.Message });
        }
    }
}