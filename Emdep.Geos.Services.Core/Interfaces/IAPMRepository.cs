using Emdep.Geos.Core.Models;

namespace Emdep.Geos.Core.Interfaces
{
    public interface IAPMRepository
    {

        Task<IEnumerable<LookupValue>> GetLookupValuesAsync(int key);
        Task<List<Department>> GetDepartmentsForActionPlanAsync();
        Task<List<ActionPlan>> GetActionPlanDetailsAsync(string selectedPeriod, int idUser);
        Task<List<AuthorizedLocation>> GetAuthorizedLocationListByIdUserAsync(int idUser);
        Task<List<Responsible>> GetResponsibleByLocationAsync(string idCompanyLocation);
        Task<List<YBPCode>> GetAllYBPCodeAsync();
        Task<List<CustomerResponsible>> GetCustomersWithSitesAndResponsibleAsync();
    }
}