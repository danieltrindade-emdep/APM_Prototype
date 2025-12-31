using Dapper;
using Emdep.Geos.Core.Interfaces;
using Emdep.Geos.Core.Models;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System.Data;

namespace Emdep.Geos.Infrastructure.Repositories
{
    public class APMRepository : IAPMRepository
    {
        private readonly string _connectionString;

        public APMRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("WorkbenchContext");
        }

        #region Methods
        public async Task<List<ActionPlan>> GetActionPlanDetailsAsync(string selectedPeriod, int idUser)
        {
            const string spName = "APM_GetActionPlanDetails_V2690";

            using (var conn = new MySqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("_SelectedPeriod", selectedPeriod);
                parameters.Add("_iduser", idUser);

                using (var multi = await conn.QueryMultipleAsync(spName, parameters, commandType: CommandType.StoredProcedure))
                {
                    var plans = (await multi.ReadAsync<ActionPlan>()).ToList();
                    var tasks = (await multi.ReadAsync<ActionPlanTask>()).ToList();
                    var subTasks = (await multi.ReadAsync<ActionPlanSubTask>()).ToList();

                    var plansDictionary = plans.ToDictionary(p => p.IdActionPlan);
                    var tasksDictionary = tasks.ToDictionary(t => t.IdTask);

                    foreach (var sub in subTasks)
                    {
                        if (sub.IdParent.HasValue && tasksDictionary.TryGetValue(sub.IdParent.Value, out var parentTask))
                        {
                            parentTask.SubTaskList.Add(sub);
                        }
                    }

                    foreach (var task in tasks)
                    {
                        if (plansDictionary.TryGetValue(task.IdActionPlan, out var plan))
                        {
                            plan.TaskList.Add(task);
                        }
                    }

                    return plans;
                }
            }
        }

        public async Task<IEnumerable<LookupValue>> GetLookupValuesAsync(int key)
        {
            const string sql = @"
        SELECT 
            IdLookupValue, 
            Value, 
            HtmlColor, 
            Position, 
            IdLookupKey, 
            Abbreviation, 
            ImageName, 
            IdParent,
            InUse
        FROM lookup_values 
        WHERE IdLookupKey = @Key 
          AND InUse = 1 
        ORDER BY Position";

            using (var conn = new MySqlConnection(_connectionString))
            {
                var result = await conn.QueryAsync<LookupValue>(sql, new { Key = key });

                return result;
            }
        }

        public async Task<List<Department>> GetDepartmentsForActionPlanAsync()
        {
            const string spName = "APM_GetDepartmentsForActionPlan_V2590";

            using (var conn = new MySqlConnection(_connectionString))
            {
                var result = await conn.QueryAsync<Department>(
                    spName,
                    commandType: CommandType.StoredProcedure
                );

                return result.ToList();
            }
        }

        public async Task<List<Responsible>> GetResponsibleByLocationAsync(string idCompanyLocation)
        {
            const string spName = "APM_GetResponsibleByLocation_V2670";

            using (var conn = new MySqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("_IdCompanyLocation", idCompanyLocation);

                var result = await conn.QueryAsync<Responsible>(
                    spName,
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return result.ToList();
            }
        }

        public async Task<List<YBPCode>> GetAllYBPCodeAsync()
        {
            const string spName = "APM_GetAllYBPCode";

            using (var conn = new MySqlConnection(_connectionString))
            {
                var result = await conn.QueryAsync<YBPCode>(
                    spName,
                    commandType: CommandType.StoredProcedure
                );

                return result.ToList();
            }
        }

        public async Task<List<CustomerResponsible>> GetCustomersWithSitesAndResponsibleAsync()
        {
            const string spName = "APM_GetCustomersWithSitesAndResponsible_V2690";

            using (var conn = new MySqlConnection(_connectionString))
            {
                var result = await conn.QueryAsync<CustomerResponsible>(
                    spName,
                    commandType: CommandType.StoredProcedure
                );

                return result.ToList();
            }
        }

        public async Task<List<AuthorizedLocation>> GetAuthorizedLocationListByIdUserAsync(int idUser)
        {
            const string spName = "APM_GetAuthorizedLocationListByIdUser_V2690";

            using (var conn = new MySqlConnection(_connectionString))
            {
                var parameters = new DynamicParameters();
                parameters.Add("_idUser", idUser);

                var result = await conn.QueryAsync<AuthorizedLocation>(
                    spName,
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return result.ToList();
            }
        }
        #endregion

    }
}