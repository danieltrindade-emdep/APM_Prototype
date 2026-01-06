using Asp.Versioning;
using Emdep.Geos.Contracts.ETMModule;
using Emdep.Geos.Core.Interfaces;
using Emdep.Geos.Core.Models;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Emdep.Geos.API.Controllers.V2690;

[ApiController]
[Route("api/v{version:apiVersion}/apm")]
[ApiVersion("2690")]
public class APMController(IAPMRepository repository, IMapper mapper) : ControllerBase
{
    [HttpGet("filters")]
    [ProducesResponseType(typeof(APMFiltersViewDTO), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetFilters()
    {
        const int LOOKUP_BUSINESS_UNIT = 2;
        const int LOOKUP_ORIGIN = 154;
        const int LOOKUP_THEME = 155;

        // TODO: Obter o ID do utilizador logado (ex: via Claims)
        int currentUserId = 1;
        // TODO: Obter a Location atual ou contexto necessário para os Responsáveis
        string currentLocationId = "1";

        // --- 1. DISPARAR TODOS OS PEDIDOS EM PARALELO ---
        // Em vez de 'await' um a um, lançamos as tarefas todas ao mesmo tempo.

        var tLocations = repository.GetAuthorizedLocationListByIdUserAsync(currentUserId);
        var tResponsibles = repository.GetResponsibleByLocationAsync(currentLocationId);
        var tBusinessUnits = repository.GetLookupValuesAsync(LOOKUP_BUSINESS_UNIT);
        var tOrigins = repository.GetLookupValuesAsync(LOOKUP_ORIGIN);
        var tDepartments = repository.GetDepartmentsForActionPlanAsync();
        var tCustomers = repository.GetCustomersWithSitesAndResponsibleAsync();
        var tThemes = repository.GetLookupValuesAsync(LOOKUP_THEME);

        // Exemplo para os Anos (se criares o método no repo)
        // var tYears = repository.GetAvailableActionPlanYearsAsync();

        // --- 2. ESPERAR QUE TUDO CHEGUE ---
        await Task.WhenAll(tLocations, tResponsibles, tBusinessUnits, tOrigins, tDepartments, tCustomers, tThemes);

        // --- 3. MAPEAMENTO (CONVERSÃO) ---
        // Aqui usamos as regras que definiste no ActionPlanViewMapping.cs

        var response = new APMFiltersViewDTO
        {
            // Anos: Podes implementar lógica aqui ou vir do repo.
            // Exemplo estático temporário baseado na tua regra antiga:
            AvailableYears = Enumerable.Range(2020, DateTime.Now.Year - 2020 + 2).ToList(),

            Locations = mapper.Map<List<LocationFilterDTO>>(tLocations.Result),

            Responsibles = mapper.Map<List<ResponsibleFilterDTO>>(tResponsibles.Result),

            BusinessUnits = mapper.Map<List<GenericLookupFilterDTO>>(tBusinessUnits.Result),

            Origins = mapper.Map<List<GenericLookupFilterDTO>>(tOrigins.Result),

            Departments = mapper.Map<List<GenericLookupFilterDTO>>(tDepartments.Result),

            Customers = mapper.Map<List<GenericLookupFilterDTO>>(tCustomers.Result),

            Themes = mapper.Map<List<ThemeFilterDTO>>(tThemes.Result)
        };

        return Ok(response);
    }

    [HttpGet("details")]
    public async Task<ActionResult<List<ActionPlan>>> GetActionPlanDetails(string selectedPeriod, int idUser, CancellationToken cancellationToken)
    {
        var data = await repository.GetActionPlanDetailsAsync(selectedPeriod, idUser, cancellationToken);
        return Ok(data);
    }

    [HttpGet("authorized-locations/{idUser}")]
    public async Task<ActionResult<List<AuthorizedLocation>>> GetAuthorizedLocationListByIdUser(int idUser, CancellationToken cancellationToken)
    {
        var data = await repository.GetAuthorizedLocationListByIdUserAsync(idUser, cancellationToken);
        return Ok(data);
    }

    [HttpGet("ybp-codes")]
    public async Task<ActionResult<List<YBPCode>>> GetAllYBPCode(CancellationToken cancellationToken)
    {
        var data = await repository.GetAllYBPCodeAsync(cancellationToken);
        return Ok(data);
    }

    [HttpGet("customers-sites-responsible")]
    public async Task<ActionResult<List<CustomerResponsible>>> GetCustomersWithSitesAndResponsible(CancellationToken cancellationToken)
    {
        var data = await repository.GetCustomersWithSitesAndResponsibleAsync(cancellationToken);
        return Ok(data);
    }
}