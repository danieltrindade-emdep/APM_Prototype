using Asp.Versioning;
using Emdep.Geos.Contracts.APM;
using Emdep.Geos.Core.Interfaces;
using Emdep.Geos.Core.Models;
using Emdep.Geos.Services.Core.Helpers;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Emdep.Geos.API.Controllers.V2690;

[ApiController]
[Route("api/v{version:apiVersion}/apm")]
[ApiVersion("2690")]
public class APMController(IAPMRepository repository, IMapper mapper, ILogger<APMController> logger) : ControllerBase
{
    [HttpGet("filters")]
    [ProducesResponseType(typeof(APMFiltersViewDTO), StatusCodes.Status200OK)]
    public async Task<ActionResult<APMFiltersViewDTO>> GetFilters()
    {
        // TODO: Obter o ID do utilizador logado (ex: via Claims)
        int currentUserId = 1;
        // TODO: Obter a Location atual ou contexto necessário para os Responsáveis
        string currentLocationId = "1";

        logger.LogInformation("Fetching APM filters. User: {UserId}, Location: {LocationId}", currentUserId, currentLocationId);

        var locations = await repository.GetAuthorizedLocationListByIdUserAsync(currentUserId);
        var responsibles = await repository.GetResponsibleByLocationAsync(currentLocationId);
        var businessUnits = await repository.GetLookupValuesAsync((int)LookupKeyEnum.BusinessUnit);
        var origins = await repository.GetLookupValuesAsync((int)LookupKeyEnum.Origin);
        var departments = await repository.GetDepartmentsForActionPlanAsync();
        var customers = await repository.GetCustomersWithSitesAndResponsibleAsync();
        var themes = await repository.GetLookupValuesAsync((int)LookupKeyEnum.Theme);
        var availableYears = await repository.GetAvailableYearsAsync();

        var response = new APMFiltersViewDTO
        {
            AvailableYears = availableYears,
            Locations = mapper.Map<List<LocationFilterDTO>>(locations),
            Responsibles = mapper.Map<List<ResponsibleFilterDTO>>(responsibles),
            BusinessUnits = mapper.Map<List<GenericLookupFilterDTO>>(businessUnits),
            Origins = mapper.Map<List<GenericLookupFilterDTO>>(origins),
            Departments = mapper.Map<List<GenericLookupFilterDTO>>(departments),
            Customers = mapper.Map<List<GenericLookupFilterDTO>>(customers),
            Themes = mapper.Map<List<ThemeFilterDTO>>(themes)
        };

        return Ok(response);
    }

    [HttpGet("details")]
    public async Task<ActionResult<List<ActionPlan>>> GetActionPlanDetails(string selectedPeriod, int idUser, CancellationToken cancellationToken)
    {
        logger.LogInformation("Fetching Action Plan details. Period: {Period}, User: {UserId}", selectedPeriod, idUser);
        var data = await repository.GetActionPlanDetailsAsync(selectedPeriod, idUser, cancellationToken);
        return Ok(data);
    }

    [HttpGet("authorized-locations/{idUser}")]
    public async Task<ActionResult<List<AuthorizedLocation>>> GetAuthorizedLocationListByIdUser(int idUser, CancellationToken cancellationToken)
    {
        logger.LogInformation("Fetching authorized locations for User: {UserId}", idUser);
        var data = await repository.GetAuthorizedLocationListByIdUserAsync(idUser, cancellationToken);
        return Ok(data);
    }

    [HttpGet("ybp-codes")]
    public async Task<ActionResult<List<YBPCode>>> GetAllYBPCode(CancellationToken cancellationToken)
    {
        logger.LogInformation("Fetching all YBP Codes.");
        var data = await repository.GetAllYBPCodeAsync(cancellationToken);
        return Ok(data);
    }

    [HttpGet("customers-sites-responsible")]
    public async Task<ActionResult<List<CustomerResponsible>>> GetCustomersWithSitesAndResponsible(CancellationToken cancellationToken)
    {
        logger.LogInformation("Fetching Customers with Sites and Responsibles.");
        var data = await repository.GetCustomersWithSitesAndResponsibleAsync(cancellationToken);
        return Ok(data);
    }
}