using Emdep.Geos.Contracts.ETMModule;
using Emdep.Geos.Core.Models;
using Emdep.Geos.Services.API.Configuration;
using Mapster;

namespace Emdep.Geos.Services.API.Mapping
{
    public class ActionPlanViewMapping : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<ActionPlan, APMTableViewDTO>()
                .Map(dest => dest.Name, src => src.Description)
                .Map(dest => dest.Responsible, src => src.ActionPlanResponsibleDisplayName)
                .Map(dest => dest.YBPCode, src => src.TaskCode)
                .Map(dest => dest.Customer, src => $"{src.CustomerName} ({src.SiteName})")
                .Map(dest => dest.TotalTasks, src => src.TotalActionItems)
                .Map(dest => dest.OpenTasks, src => src.TotalOpenItems)
                .Map(dest => dest.ClosedTasks, src => src.TotalClosedItems)
                .Map(dest => dest.Tasks, src => src.TaskList);

            config.NewConfig<ActionPlanTask, TaskViewDTO>()
                .Map(dest => dest.Item, src => src.TaskNumber)
                .Map(dest => dest.Responsible, src => src.TaskResponsibleDisplayName)
                .Map(dest => dest.DelegatedTo, src => src.DelegatedDisplayName)
                .Map(dest => dest.StatusColor, src => src.StatusHTMLColor)
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
                .Map(dest => dest.Id, src => (int)src.IdEmployee)
                .Map(dest => dest.Name, src => src.FullName)
                .Map(dest => dest.DisplayName, src => src.ResponsibleDisplayName)
                .Map(dest => dest.ImageUrl, src => $"{GlobalSettings.EmployeesRoundedUrl}{src.EmployeeCode}.png");

            config.NewConfig<AuthorizedLocation, LocationFilterDTO>()
                .Map(dest => dest.Id, src => src.IdCompany)
                .Map(dest => dest.Name, src => src.Alias);
            // 4. Department (Novo)
            config.NewConfig<Department, GenericLookupFilterDTO>()
                .Map(dest => dest.Id, src => (int)src.IdDepartment)
                .Map(dest => dest.Name, src => src.DepartmentName);

            config.NewConfig<LookupValue, GenericLookupFilterDTO>()
                .Map(dest => dest.Id, src => src.IdLookupValue)
                .Map(dest => dest.Name, src => src.Value);

            config.NewConfig<LookupValue, ThemeFilterDTO>()
                .Map(dest => dest.Id, src => src.IdLookupValue)
                .Map(dest => dest.Name, src => src.Value)
                .Map(dest => dest.HtmlColor, src => src.HtmlColor);
        }
    }
}
