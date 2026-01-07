using Dapper;
using Emdep.Geos.Core.Interfaces;
using Emdep.Geos.Core.Models;
using Emdep.Geos.Infrastructure.Constants;
using System.Data;

namespace Emdep.Geos.Infrastructure.Repositories
{
    public class APMRepository(IDbConnection dbConnection) : IAPMRepository
    {
        #region Methods
        public async Task<List<ActionPlan>> GetActionPlanDetailsAsync(string selectedPeriod, int idUser, CancellationToken cancellationToken = default)
        {
            var parameters = new DynamicParameters();
            parameters.Add("_SelectedPeriod", selectedPeriod);
            parameters.Add("_iduser", idUser);

            var command = new CommandDefinition(
                APMConstants.StoredProcedures.APM_GetActionPlanDetails,
                parameters,
                commandType: CommandType.StoredProcedure,
                cancellationToken: cancellationToken
            );

            using (var multi = await dbConnection.QueryMultipleAsync(command))
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

        public async Task<IEnumerable<LookupValue>> GetLookupValuesAsync(int key, CancellationToken cancellationToken = default)
        {
            var command = new CommandDefinition(
                APMConstants.SqlQueries.GetLookupValuesQuery,
                new { Key = key },
                cancellationToken: cancellationToken
            );

            return await dbConnection.QueryAsync<LookupValue>(command);
        }

        public async Task<List<Department>> GetDepartmentsForActionPlanAsync(CancellationToken cancellationToken = default)
        {
            var command = new CommandDefinition(
               APMConstants.StoredProcedures.APM_GetDepartmentsForActionPlan,
               commandType: CommandType.StoredProcedure,
               cancellationToken: cancellationToken
           );

            var result = await dbConnection.QueryAsync<Department>(command);

            return result.ToList();
        }

        public async Task<List<Responsible>> GetResponsibleByLocationAsync(string idCompanyLocation, CancellationToken cancellationToken = default)
        {
            var parameters = new DynamicParameters();
            parameters.Add("_IdCompanyLocation", idCompanyLocation);

            var command = new CommandDefinition(
                APMConstants.StoredProcedures.APM_GetResponsibleByLocation,
                parameters,
                commandType: CommandType.StoredProcedure,
                cancellationToken: cancellationToken
            );

            var result = await dbConnection.QueryAsync<Responsible>(command);

            return result.ToList();
        }

        public async Task<List<YBPCode>> GetAllYBPCodeAsync(CancellationToken cancellationToken = default)
        {
            var command = new CommandDefinition(
                APMConstants.StoredProcedures.APM_GetAllYBPCode,
                commandType: CommandType.StoredProcedure,
                cancellationToken: cancellationToken
            );

            var result = await dbConnection.QueryAsync<YBPCode>(command);

            return result.ToList();
        }

        public async Task<List<CustomerResponsible>> GetCustomersWithSitesAndResponsibleAsync(CancellationToken cancellationToken = default)
        {
            var command = new CommandDefinition(
                APMConstants.StoredProcedures.APM_GetCustomersWithSitesAndResponsible,
                commandType: CommandType.StoredProcedure,
                cancellationToken: cancellationToken
            );

            var result = await dbConnection.QueryAsync<CustomerResponsible>(command);

            return result.ToList();
        }

        public async Task<List<AuthorizedLocation>> GetAuthorizedLocationListByIdUserAsync(int idUser, CancellationToken cancellationToken = default)
        {
            var parameters = new DynamicParameters();
            parameters.Add("_idUser", idUser);

            var command = new CommandDefinition(
                APMConstants.StoredProcedures.APM_GetAuthorizedLocationListByIdUser,
                parameters,
                commandType: CommandType.StoredProcedure,
                cancellationToken: cancellationToken
            );

            var result = await dbConnection.QueryAsync<AuthorizedLocation>(command);

            return result.ToList();
        }

        public async Task<List<int>> GetAvailableYearsAsync(CancellationToken cancellationToken = default)
        {
            var command = new CommandDefinition(
                APMConstants.SqlQueries.GetAvailableYearsQuery,
                commandType: CommandType.Text,
                cancellationToken: cancellationToken
            );

            var result = await dbConnection.QueryAsync<int>(command);

            return result.ToList();
        }

        #endregion

    }
}