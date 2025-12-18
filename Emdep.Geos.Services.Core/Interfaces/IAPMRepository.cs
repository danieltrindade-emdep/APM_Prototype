using Emdep.Geos.Core.Models;

namespace Emdep.Geos.Core.Interfaces
{
    public interface IAPMRepository
    {
        // 1. GetActiveInactiveResponsibleForActionPlan_V2570
        // Nota: O original devolvia List<Responsible>. Aqui usamos IEnumerable (mais leve) ou List.
        Task<List<Responsible>> GetActiveInactiveResponsibleAsync(
            int idCompany,
            string selectedPeriod,
            string idsOrganization,
            string idsDepartments,
            int idPermission);

        // 2. GetLookupValues_V2550
        // Nota: O original usava "byte key".
        Task<IList<LookupValue>> GetLookupValuesAsync(byte key);

        // 3. GetDepartmentsForActionPlan_V2590
        Task<List<Department>> GetDepartmentsAsync();

        // 4. GetCustomersWithSite_V2610
        // Nota: Precisas do modelo APMCustomer (adiciona ao Placeholders se não tiveres)
        Task<List<APMCustomer>> GetCustomersWithSiteAsync();

        // 5. GetActionPlanDetails_V2690
        Task<List<APMActionPlan>> GetActionPlanDetailsAsync(string selectedPeriod, int idUser);

        // 6. GetAuthorizedLocationListByIdUser_V2690
        Task<List<Company>> GetAuthorizedLocationsAsync(int idUser);
    }
}