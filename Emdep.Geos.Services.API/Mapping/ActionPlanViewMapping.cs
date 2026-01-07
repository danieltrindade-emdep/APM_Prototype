using Emdep.Geos.Contracts.APM;
using Emdep.Geos.Core.Models;
using Emdep.Geos.Services.API.Configuration;
using Mapster;
using Microsoft.Extensions.Options;

namespace Emdep.Geos.Services.API.Mapping
{
    public class ActionPlanViewMapping : IRegister
    {
        private readonly APMSettings _settings;

        public ActionPlanViewMapping(IOptions<APMSettings> options)
        {
            _settings = options.Value;
        }

        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<ActionPlan, APMTableViewDTO>()
                .Map(dest => dest.Name, src => src.Description)
                .Map(dest => dest.CountryIconUrl, src =>
                    string.IsNullOrEmpty(src.CountryIso)
                    ? string.Empty
                    : $"{_settings.Images.BaseUrlCountries}{src.CountryIso}.png")
                .Map(dest => dest.Responsible, src => src.ActionPlanResponsibleDisplayName)
                .Map(dest => dest.YBPCode, src => src.TaskCode)
                .Map(dest => dest.Customer, src => $"{src.CustomerName} ({src.SiteName})")
                .Map(dest => dest.TotalTasks, src => src.TotalActionItems)
                .Map(dest => dest.OpenTasks, src => src.TotalOpenItems)
                .Map(dest => dest.ClosedTasks, src => src.TotalClosedItems)
                .Map(dest => dest.ClosedTasksColor, src => CalculateClosedTasksColor(src.TotalActionItems, src.TotalClosedItems))
                .Map(dest => dest.WorkComplete, src => CalculateWorkComplete(src.TotalActionItems, src.TotalClosedItems))
                .Map(dest => dest.Tasks, src => src.TaskList);

            config.NewConfig<ActionPlanTask, TaskViewDTO>()
                .Map(dest => dest.Item, src => src.TaskNumber)
                .Map(dest => dest.Responsible, src => src.TaskResponsibleDisplayName)
                .Map(dest => dest.DelegatedTo, src => src.DelegatedDisplayName)
                .Map(dest => dest.StatusColor, src => src.StatusHTMLColor)
                .Map(dest => dest.PriorityColor, src => GetPriorityColor(src.Priority))
                .Map(dest => dest.YBPCode, src => src.TaskCode)
                .Map(dest => dest.Customer, src => $"{src.CustomerName} ({src.SiteName})")
                .Map(dest => dest.CreationDate, src => src.CreatedIn)
                .Map(dest => dest.DueDaysColor, src => src.DueColor)
                .Map(dest => dest.OTItem, src => src.OTCodeAndItemNumber)
                .Map(dest => dest.ClosedBy, src => src.ClosedByName)
                .Map(dest => dest.CreatedBy, src => src.CreatedByName)
                .Map(dest => dest.SubTasks, src => src.SubTaskList);

            config.NewConfig<ActionPlanSubTask, SubTaskViewDTO>()
                .Map(dest => dest.Item, src => $"{src.ParentTaskNumber}.{src.TaskNumber}")
                .Map(dest => dest.Responsible, src => src.TaskResponsibleDisplayName)
                .Map(dest => dest.StatusColor, src => src.StatusHTMLColor)
                .Map(dest => dest.PriorityColor, src => GetPriorityColor(src.Priority))
                .Map(dest => dest.YBPCode, src => src.TaskCode)
                .Map(dest => dest.DueDaysColor, src => src.DueColor)
                .Map(dest => dest.CreationDate, src => src.CreatedIn)
                .Map(dest => dest.ClosedBy, src => src.ClosedByName)
                .Map(dest => dest.CreatedBy, src => src.CreatedByName)
                .Map(dest => dest.OTItem, src => src.OTCodeAndItemNumber);

            config.NewConfig<CustomerResponsible, GenericLookupFilterDTO>()
                .Map(dest => dest.Id, src => src.IdSite)
                .Map(dest => dest.Name, src => $"{src.CustomerName} ({src.SiteName})");

            config.NewConfig<Responsible, ResponsibleFilterDTO>()
                .Map(dest => dest.Id, src => src.IdEmployee)
                .Map(dest => dest.DisplayName, src => src.ResponsibleDisplayName)
                .Map(dest => dest.ImageUrl, src => $"{_settings.Images.BaseUrlRounded}{src.EmployeeCode}.png")
                .Map(dest => dest.BackupImageUrl, src => $"{_settings.Images.BaseUrlNormal}{src.EmployeeCode}.png");

            config.NewConfig<AuthorizedLocation, LocationFilterDTO>()
                .Map(dest => dest.Id, src => src.IdCompany)
                .Map(dest => dest.Name, src => src.Alias)
                .Map(dest => dest.CountryIconUrl, src =>
                        string.IsNullOrEmpty(src.CountryIso)
                        ? string.Empty
                        : $"{_settings.Images.BaseUrlCountries}{src.CountryIso}.png");

            config.NewConfig<Department, GenericLookupFilterDTO>()
                .Map(dest => dest.Id, src => src.IdDepartment)
                .Map(dest => dest.Name, src => src.DepartmentName);

            config.NewConfig<LookupValue, GenericLookupFilterDTO>()
                .Map(dest => dest.Id, src => src.IdLookupValue)
                .Map(dest => dest.Name, src => src.Value);

            config.NewConfig<LookupValue, ThemeFilterDTO>()
                .Map(dest => dest.Id, src => src.IdLookupValue)
                .Map(dest => dest.Name, src => src.Value)
                .Map(dest => dest.HtmlColor, src => src.HtmlColor);
        }

        #region Logic Helpers
        private static int CalculateWorkComplete(int total, int closed)
        {
            return total == 0 ? 0 : (int)((double)closed / total * 100);
        }

        private static string CalculateClosedTasksColor(int total, int closed)
        {
            if (total == 0) return "#ff0000"; // Red

            int workComplete = CalculateWorkComplete(total, closed);

            return workComplete switch
            {
                <= 24 => "#ff0000", // Red
                <= 49 => "#ffa500", // Orange
                <= 74 => "#ffff00", // Yellow
                <= 99 => "#90ee90", // LightGreen
                100 => "#008000",   // Green
                _ => "#ff0000"      // Red (Default)
            };
        }

        private static string GetPriorityColor(string priority)
        {
            return (priority?.ToLower()) switch
            {
                "low" => "#55c867",    // Green
                "medium" => "#eef91b", // Yellow
                "high" => "#f43705",   // Red
                _ => "Transparent"
            };
        }
        #endregion
    }
}
