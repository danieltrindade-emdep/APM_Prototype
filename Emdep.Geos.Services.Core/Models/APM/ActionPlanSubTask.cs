namespace Emdep.Geos.Core.Models
{
    public class ActionPlanSubTask
    {
        public long IdTask { get; set; }
        public long? IdParent { get; set; }
        public int TaskNumber { get; set; }
        public string Title { get; set; }

        public string EmployeeCode { get; set; }
        public int IdEmployee { get; set; }
        public string FirstName { get; set; }
        public string Responsible { get; set; }
        public int IdGender { get; set; }

        public int IdLookupStatus { get; set; }
        public string Status { get; set; }
        public string StatusHTMLColor { get; set; }
        public int IdLookupPriority { get; set; }
        public string Priority { get; set; }
        public int IdLookupTheme { get; set; }
        public string Theme { get; set; }
        public string ThemeHTMLColor { get; set; }

        public DateTime DueDate { get; set; }
        public int? DueDays { get; set; }
        public string DueColor { get; set; }
        public DateTime? OpenDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public DateTime? OriginalDueDate { get; set; }
        public DateTime? LastUpdated { get; set; }
        public int? Duration { get; set; }
        public int ChangeCount { get; set; }

        public int? IdDelegated { get; set; }
        public string DelegatedTo { get; set; }
        public string DelegatedDisplayName { get; set; }

        public int Comments { get; set; }
        public string TaskLastComments { get; set; }
        public int Files { get; set; }
        public int Progress { get; set; }

        public int IdLocation { get; set; }
        public long IdActionPlan { get; set; }
        public int IdCompany { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public int IdDepartment { get; set; }
        public string Country { get; set; }
        public string CountryIso { get; set; }
        public int IdSite { get; set; }
        public string SiteName { get; set; }
        public int IdCustomer { get; set; }
        public string CustomerName { get; set; }

        public int? ClosedBy { get; set; }
        public string ClosedByName { get; set; }
        public DateTime CreatedIn { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public string TaskResponsibleDisplayName { get; set; }

        public int? IdOTItem { get; set; }
        public string NumItem { get; set; }
        public string Code { get; set; }
        public long? IdOT { get; set; }
        public string OTCodeAndItemNumber { get; set; }
        public string Participant { get; set; }
        public string OriginWeek { get; set; }
        public string TaskCode { get; set; }
        public long ParentTaskNumber { get; set; }
    }
}