using Asp.Versioning;
using Emdep.Geos.Core.Interfaces;
using Emdep.Geos.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Emdep.Geos.API.Controllers.V2690;

[ApiController]
[Route("api/v{version:apiVersion}/apm")]
[ApiVersion("2690")]
public class APMController : ControllerBase
{
    private readonly IAPMRepository _repository;

    // Construtor limpo: Apenas injetamos o Repositório
    public APMController(IAPMRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("details")]
    public async Task<ActionResult<List<ActionPlan>>> GetActionPlanDetails(string selectedPeriod, int idUser)
    {
        try
        {
            var data = await _repository.GetActionPlanDetailsAsync(selectedPeriod, idUser);

            return Ok(data);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = ex.Message });
        }
    }

    [HttpGet("authorized-locations/{idUser}")]
    public async Task<ActionResult<List<AuthorizedLocation>>> GetAuthorizedLocationListByIdUser(int idUser)
    {
        try
        {
            var data = await _repository.GetAuthorizedLocationListByIdUserAsync(idUser);

            return Ok(data);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = ex.Message });
        }
    }

    [HttpGet("ybp-codes")]
    public async Task<ActionResult<List<YBPCode>>> GetAllYBPCode()
    {
        try
        {
            var data = await _repository.GetAllYBPCodeAsync();

            return Ok(data);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = ex.Message });
        }
    }

    [HttpGet("customers-sites-responsible")]
    public async Task<ActionResult<List<CustomerResponsible>>> GetCustomersWithSitesAndResponsible()
    {
        try
        {
            var data = await _repository.GetCustomersWithSitesAndResponsibleAsync();
            return Ok(data);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = ex.Message });
        }
    }
}