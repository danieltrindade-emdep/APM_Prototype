using Emdep.Geos.Services.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Emdep.Geos.Core.Models
{
    public class APMActionPlan
    {
        [NotMapped]
        public long IdActionPlan { get; set; }

        [NotMapped]
        public string Code { get; set; }

        [NotMapped]
        public string Description { get; set; }

        [NotMapped]
        public int IdCompany { get; set; }

        [NotMapped]
        public string Location { get; set; }

        [NotMapped]
        public int IdEmployee { get; set; }

        [NotMapped]
        public string FirstName { get; set; }

        [NotMapped]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";

        [NotMapped]
        public int IdLookupValue { get; set; }

        [NotMapped]
        public string BusinessUnit { get; set; }

        [NotMapped]
        public int TotalActionItems { get; set; }

        [NotMapped]
        public int TotalOpenItems { get; set; }

        [NotMapped]
        public int TotalClosedItems { get; set; }

        [NotMapped]
        public int Percentage { get; set; }

        [NotMapped]
        public string TotalClosedColor { get; set; }

        [NotMapped]
        public int IdLookupOrigin { get; set; }

        [NotMapped]
        public string Origin { get; set; }

        [NotMapped]
        public string Name { get; set; }

        [NotMapped]
        public int ModifiedBy { get; set; }

        [NotMapped]
        public DateTime ModifiedIn { get; set; }

        [NotMapped]
        public int CreatedBy { get; set; }

        [NotMapped]
        public DateTime? CreatedIn { get; set; }

        [NotMapped]
        public List<APMActionPlanTask> TaskList { get; set; } = new();

        [NotMapped]
        public Country Country { get; set; }

        [NotMapped]
        public string EmployeeCode { get; set; }

        [NotMapped]
        public int IdGender { get; set; }

        [NotMapped]
        public List<LogEntriesByActionPlan> ActionPlanLogEntries { get; set; } = new();

        [NotMapped]
        public List<ActionPlanComment> CommentList { get; set; } = new();

        [NotMapped]
        public string CreatedByName { get; set; }

        [NotMapped]
        public int IdLookupBusinessUnit { get; set; }

        [NotMapped]
        public int IdDepartment { get; set; }

        [NotMapped]
        public string Department { get; set; }

        [NotMapped]
        public string BusinessUnitHTMLColor { get; set; }

        [NotMapped]
        public string OriginDescription { get; set; }

        [NotMapped]
        public bool IsActionPlanDeleted { get; set; }

        [NotMapped]
        public int ResponsibleIdUser { get; set; }

        [NotMapped]
        public string ActionPlanResponsibleDisplayName { get; set; }

        [NotMapped]
        public int IdCustomer { get; set; }

        [NotMapped]
        public int IdSite { get; set; }

        [NotMapped]
        public string Site { get; set; }

        [NotMapped]
        public string Group { get; set; }

        [NotMapped]
        public string GroupName { get; set; }

        [NotMapped]
        public int IdZone { get; set; }

        [NotMapped]
        public string Zone { get; set; }

        [NotMapped]
        public int MaxTaskNumber { get; set; }

        [NotMapped]
        public string YBPCode { get; set; }

        [NotMapped]
        public int IdFiveYearBusinessPlansTaskCodes { get; set; }
    }
}