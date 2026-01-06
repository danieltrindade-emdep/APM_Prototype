using Emdep.Geos.Core.Models;

namespace Emdep.Geos.Core.Interfaces
{
    public interface IAPMRepository
    {
        Task<IEnumerable<LookupValue>> GetLookupValuesAsync(int key, CancellationToken cancellationToken = default);
        Task<List<Department>> GetDepartmentsForActionPlanAsync(CancellationToken cancellationToken = default);
        Task<List<ActionPlan>> GetActionPlanDetailsAsync(string selectedPeriod, int idUser, CancellationToken cancellationToken = default);
        Task<List<AuthorizedLocation>> GetAuthorizedLocationListByIdUserAsync(int idUser, CancellationToken cancellationToken = default);
        Task<List<Responsible>> GetResponsibleByLocationAsync(string idCompanyLocation, CancellationToken cancellationToken = default);
        Task<List<YBPCode>> GetAllYBPCodeAsync(CancellationToken cancellationToken = default);
        Task<List<CustomerResponsible>> GetCustomersWithSitesAndResponsibleAsync(CancellationToken cancellationToken = default);
    }
}