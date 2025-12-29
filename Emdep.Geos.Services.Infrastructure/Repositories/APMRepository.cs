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
        public async Task<List<APMActionPlan>> GetActionPlanDetailsAsync(string selectedPeriod, int idUser)
        {
            var actionPlanList = new List<APMActionPlan>();

            using (var conn = new MySqlConnection(_connectionString))
            using (var cmd = new MySqlCommand("APM_GetActionPlanDetails_V2690", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_SelectedPeriod", selectedPeriod);
                cmd.Parameters.AddWithValue("_iduser", idUser);

                await conn.OpenAsync();

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var plan = new APMActionPlan
                        {
                            IdActionPlan = GetLong(reader, "IdActionPlan"),
                            Code = GetString(reader, "Code"),
                            Description = GetString(reader, "Description"),
                            IdCompany = GetInt(reader, "IdCompany"),
                            Location = GetString(reader, "Location"),
                            IdEmployee = GetInt(reader, "IdEmployee"),
                            FirstName = GetString(reader, "FirstName"),
                            LastName = GetString(reader, "LastName"),
                            IdGender = GetInt(reader, "IdGender"),
                            EmployeeCode = GetString(reader, "EmployeeCode"),
                            ResponsibleIdUser = GetInt(reader, "IdUser"),
                            IdLookupOrigin = GetInt(reader, "IdLookupValue"),
                            Origin = GetString(reader, "Origin"),
                            IdLookupBusinessUnit = GetInt(reader, "IdBusinessUnit"),
                            BusinessUnit = GetString(reader, "BusinessUnit"),
                            BusinessUnitHTMLColor = GetString(reader, "BusinessUnitHtmlColor"),
                            TotalActionItems = GetInt(reader, "TotalActionItems"),
                            TotalOpenItems = GetInt(reader, "TotalOpenItems"),
                            TotalClosedItems = GetInt(reader, "TotalClosedItems"),
                            CreatedBy = GetInt(reader, "CreatedBy"),
                            CreatedByName = GetString(reader, "CreatedByName"),
                            CreatedIn = GetDateTime(reader, "CreatedIn"),
                            IdDepartment = GetInt(reader, "IdDepartment"),
                            Department = GetString(reader, "Department"),
                            OriginDescription = GetString(reader, "OriginDescription"),
                            ActionPlanResponsibleDisplayName = GetString(reader, "ActionPlanResponsibleDisplayName"),
                            IdSite = GetInt(reader, "IdSite"),
                            Group = GetString(reader, "CustomerName"),
                            Site = GetString(reader, "SiteName"),
                            IdZone = GetInt(reader, "IdZone"),
                            Zone = GetString(reader, "Region"),
                            YBPCode = GetString(reader, "TaskCode"),

                            TaskList = new List<APMActionPlanTask>()
                        };

                        if (!IsDBNull(reader, "Country"))
                        {
                            plan.Country = new Country
                            {
                                Name = GetString(reader, "Country"),
                                Iso = GetString(reader, "CountryIso"),
                                CountryIconUrl = $"https://api.emdep.com/GEOS/Images?FilePath=/Images/Countries/{GetString(reader, "CountryIso")}.png"
                            };
                        }

                        if (!string.IsNullOrEmpty(plan.Group))
                        {
                            plan.GroupName = string.IsNullOrEmpty(plan.Site)
                                ? plan.Group
                                : $"{plan.Group} ({plan.Site})";
                        }

                        actionPlanList.Add(plan);
                    }

                    if (await reader.NextResultAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            long idActionPlan = GetLong(reader, "IdActionPlan");

                            var parentPlan = actionPlanList.FirstOrDefault(p => p.IdActionPlan == idActionPlan);

                            if (parentPlan != null)
                            {
                                var task = new APMActionPlanTask
                                {
                                    IdActionPlan = idActionPlan,
                                    IdActionPlanTask = GetLong(reader, "IdTask"),
                                    TaskNumber = GetInt(reader, "TaskNumber"),
                                    Title = GetString(reader, "Title"),
                                    Status = GetString(reader, "Status"),
                                    StatusHTMLColor = GetString(reader, "StatusHTMLColor"),
                                    Priority = GetString(reader, "Priority"),
                                    DueDate = GetDateTime(reader, "DueDate"),
                                    Responsible = GetString(reader, "Responsible"),
                                    SubTaskList = new List<APMActionPlanSubTask>()
                                };
                                parentPlan.TaskList.Add(task);
                            }
                        }
                    }

                    if (await reader.NextResultAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            long idParentTask = GetLong(reader, "IdParent");

                            var parentTask = actionPlanList
                                .SelectMany(ap => ap.TaskList)
                                .FirstOrDefault(t => t.IdActionPlanTask == idParentTask);

                            if (parentTask != null)
                            {
                                var subTask = new APMActionPlanSubTask
                                {
                                    IdActionPlan = GetLong(reader, "IdActionPlan"),
                                    IdParent = idParentTask,
                                    SubTaskNumber = GetLong(reader, "TaskNumber"),
                                    Title = GetString(reader, "Title"),
                                    Status = GetString(reader, "Status"),
                                    StatusHTMLColor = GetString(reader, "StatusHTMLColor"),
                                    Responsible = GetString(reader, "Responsible")
                                };
                                parentTask.SubTaskList.Add(subTask);
                            }
                        }
                    }
                }
            }
            return actionPlanList;
        }

        public async Task<IList<LookupValue>> GetLookupValuesAsync(byte key)
        {
            var list = new List<LookupValue>();
            string sql = "SELECT IdLookupValue, Value, HtmlColor, Position, IdLookupKey FROM lookup_values WHERE IdLookupKey = @Key ORDER BY Position";

            using (var conn = new MySqlConnection(_connectionString))
            using (var cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Key", key);
                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        list.Add(new LookupValue
                        {
                            IdLookupValue = GetInt(reader, "IdLookupValue"),
                            Value = GetString(reader, "Value"),
                            HtmlColor = GetString(reader, "HtmlColor"),
                            Position = GetInt(reader, "Position"),
                            IdLookupKey = (byte)GetInt(reader, "IdLookupKey")
                        });
                    }
                }
            }
            return list;
        }

        public async Task<List<Department>> GetDepartmentsForActionPlanAsync()
        {
            var list = new List<Department>();
            using (var conn = new MySqlConnection(_connectionString))
            using (var cmd = new MySqlCommand("APM_GetDepartmentsForActionPlan_V2590", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        list.Add(new Department
                        {
                            IdDepartment = (uint)GetInt(reader, "IdDepartment"),
                            DepartmentName = GetString(reader, "DepartmentName"),
                            Abbreviation = GetString(reader, "Abbreviation")
                        });
                    }
                }
            }
            return list;
        }

        public async Task<List<APMCustomer>> GetCustomersWithSitesAsync()
        {
            var list = new List<APMCustomer>();
            using (var conn = new MySqlConnection(_connectionString))
            using (var cmd = new MySqlCommand("GetCustomersWithSites_V2610", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var c = new APMCustomer
                        {
                            IdCustomer = GetInt(reader, "IdCustomer"),
                            Group = GetString(reader, "CustomerName"),
                            Site = GetString(reader, "SiteName"),
                            Region = GetString(reader, "Region"),
                            IdRegion = GetInt(reader, "IdZone"),
                            IdSite = GetInt(reader, "IdSite")
                        };

                        if (!string.IsNullOrEmpty(c.Group) && !string.IsNullOrEmpty(c.Site))
                        {
                            c.GroupName = $"{c.Group}({c.Site})";
                        }

                        list.Add(c);
                    }
                }
            }
            return list;
        }

        public async Task<List<Company>> GetAuthorizedLocationListByIdUserAsync(int idUser)
        {
            var list = new List<Company>();
            using (var conn = new MySqlConnection(_connectionString))
            using (var cmd = new MySqlCommand("APM_GetAuthorizedLocationListByIdUser_V2690", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_idUser", idUser);

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var comp = new Company
                        {
                            IdCompany = GetInt(reader, "IdCompany"),
                            Name = GetString(reader, "CompanyName"),
                            Alias = GetString(reader, "Alias"),
                            ShortName = GetString(reader, "Alias"),
                            Iso = GetString(reader, "CountryISO"),
                            IdCountry = (byte)GetInt(reader, "IdCountry"),
                            IsLocation = (byte)GetInt(reader, "IsLocation"),
                            IsOrganization = (byte)GetInt(reader, "IsOrganization"),
                            IsCompany = (byte)GetInt(reader, "IsCompany"),
                            IsStillActive = (byte)GetInt(reader, "IsStillActive"),
                            IdCurrency = GetInt(reader, "IdCurrency"),
                            IdRegion = GetInt(reader, "IdRegion"),
                            Region = GetString(reader, "Region")
                        };

                        if (!IsDBNull(reader, "IdCountry"))
                        {
                            comp.Country = new Country
                            {
                                IdCountry = (byte)GetInt(reader, "IdCountry"),
                                Name = GetString(reader, "CountryName")
                            };
                        }

                        if (!string.IsNullOrEmpty(comp.Iso))
                        {
                            comp.CountryIconUrl = $"https://api.emdep.com/GEOS/Images?FilePath=/Images/Countries/{comp.Iso}.png";
                        }

                        list.Add(comp);
                    }
                }
            }
            return list;
        }

        public async Task<List<Responsible>> GetActiveInactiveResponsibleAsync(
            int idCompany, string selectedPeriod, string idsOrganization, string idsDepartments, int idPermission)
        {
            var list = new List<Responsible>();
            using (var conn = new MySqlConnection(_connectionString))
            using (var cmd = new MySqlCommand("APM_GetActiveInactiveResponsibleForActionPlan_V2570", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("_IdCompany", idCompany);
                cmd.Parameters.AddWithValue("_SelectedPeriod", selectedPeriod);
                cmd.Parameters.AddWithValue("_idsOrganizationPlant", idsOrganization);
                cmd.Parameters.AddWithValue("_idsDepartment", idsDepartments);
                cmd.Parameters.AddWithValue("_idPermission", idPermission);

                await conn.OpenAsync();
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var responsible = new Responsible
                        {
                            IdEmployee = (uint)GetInt(reader, "IdEmployee"),
                            EmployeeCode = GetString(reader, "EmployeeCode"),
                            FirstName = GetString(reader, "FirstName"),
                            LastName = GetString(reader, "LastName"),
                            FullName = GetString(reader, "FullName"),
                            IdGender = GetInt(reader, "IdGender"),
                            IdOrganizationCode = GetInt(reader, "IdCompany"),
                            Organization = GetString(reader, "OrganizationCode"),
                            IdEmployeeStatus = GetInt(reader, "IdEmployeeStatus"),
                            JobCode = GetString(reader, "JobCode")
                        };

                        if (!string.IsNullOrEmpty(responsible.EmployeeCode) && responsible.IdGender != 0)
                        {
                            responsible.EmployeeCodeWithIdGender = $"{responsible.EmployeeCode}_{responsible.IdGender}";
                        }

                        list.Add(responsible);
                    }
                }
            }
            return list;
        }

        #endregion

        #region Helpers
        private bool IsDBNull(MySqlDataReader reader, string colName)
        {
            try
            {
                return reader.IsDBNull(reader.GetOrdinal(colName));
            }
            catch (IndexOutOfRangeException)
            {
                return true;
            }
        }

        private string GetString(MySqlDataReader reader, string colName)
        {
            if (IsDBNull(reader, colName)) return null;
            return reader.GetString(reader.GetOrdinal(colName));
        }

        private int GetInt(MySqlDataReader reader, string colName)
        {
            if (IsDBNull(reader, colName)) return 0;
            return reader.GetInt32(reader.GetOrdinal(colName));
        }

        private long GetLong(MySqlDataReader reader, string colName)
        {
            if (IsDBNull(reader, colName)) return 0;
            return reader.GetInt64(reader.GetOrdinal(colName));
        }

        private DateTime GetDateTime(MySqlDataReader reader, string colName)
        {
            if (IsDBNull(reader, colName)) return DateTime.MinValue;
            return reader.GetDateTime(reader.GetOrdinal(colName));
        }
        #endregion


    }
}