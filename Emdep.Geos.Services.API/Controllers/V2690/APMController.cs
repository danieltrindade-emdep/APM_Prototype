using Asp.Versioning;
using Emdep.Geos.Core.Interfaces;
using Emdep.Geos.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Emdep.Geos.API.Controllers.V2690;

[ApiController]
[Route("api/v{version:apiVersion}/apm")]
[ApiVersion("2690")]
public class APMController(IAPMRepository repository) : ControllerBase
{
    [HttpGet("details")]
    public async Task<ActionResult<List<ActionPlan>>> GetActionPlanDetails(string selectedPeriod, int idUser)
    {
        var data = await repository.GetActionPlanDetailsAsync(selectedPeriod, idUser);
        return Ok(data);
    }

    [HttpGet("authorized-locations/{idUser}")]
    public async Task<ActionResult<List<AuthorizedLocation>>> GetAuthorizedLocationListByIdUser(int idUser)
    {
        var data = await repository.GetAuthorizedLocationListByIdUserAsync(idUser);
        return Ok(data);
    }

    [HttpGet("ybp-codes")]
    public async Task<ActionResult<List<YBPCode>>> GetAllYBPCode()
    {
        var data = await repository.GetAllYBPCodeAsync();
        return Ok(data);
    }

    [HttpGet("customers-sites-responsible")]
    public async Task<ActionResult<List<CustomerResponsible>>> GetCustomersWithSitesAndResponsible()
    {
        var data = await repository.GetCustomersWithSitesAndResponsibleAsync();
        return Ok(data);
    }
}