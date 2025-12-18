using Emdep.Geos.Services.Core.Models;

namespace Emdep.Geos.Core.Models
{
    public class APMActionPlan
    {
        public long IdActionPlan { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int IdCompany { get; set; }
        public string Location { get; set; }
        public int IdEmployee { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Propriedade calculada simples pode ficar
        public string FullName => $"{FirstName} {LastName}";

        public int IdLookupValue { get; set; }
        public string BusinessUnit { get; set; }
        public int TotalActionItems { get; set; }
        public int TotalOpenItems { get; set; }
        public int TotalClosedItems { get; set; }
        public int Percentage { get; set; }
        public string TotalClosedColor { get; set; }
        public int IdLookupOrigin { get; set; }
        public string Origin { get; set; }
        public string Name { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedIn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedIn { get; set; }

        // Classes Dependentes (Vamos ter de criar estas também!)
        public List<APMActionPlanTask> TaskList { get; set; } = new();
        public Country Country { get; set; }
        public string EmployeeCode { get; set; }
        public int IdGender { get; set; }

        public List<LogEntriesByActionPlan> ActionPlanLogEntries { get; set; } = new();
        public List<ActionPlanComment> CommentList { get; set; } = new();

        public string CreatedByName { get; set; }
        public int IdLookupBusinessUnit { get; set; }
        public int IdDepartment { get; set; }
        public string Department { get; set; }
        public string BusinessUnitHTMLColor { get; set; }
        public string OriginDescription { get; set; }
        public bool IsActionPlanDeleted { get; set; }
        public int ResponsibleIdUser { get; set; }
        public string ActionPlanResponsibleDisplayName { get; set; }
        public int IdCustomer { get; set; }
        public int IdSite { get; set; }
        public string Site { get; set; }
        public string Group { get; set; }
        public string GroupName { get; set; }
        public int IdZone { get; set; }
        public string Zone { get; set; }
        public int MaxTaskNumber { get; set; }
        public string YBPCode { get; set; }
        public int IdFiveYearBusinessPlansTaskCodes { get; set; }
    }
}