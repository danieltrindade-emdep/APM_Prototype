namespace Emdep.Geos.Core.Models
{
    public class ActionPlan
    {
        public long IdActionPlan { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int IdCompany { get; set; }
        public string Location { get; set; }
        public string Country { get; set; }
        public string CountryIso { get; set; }
        public string EmployeeCode { get; set; }
        public int IdUser { get; set; }
        public int IdEmployee { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int IdGender { get; set; }
        public int IdLookupValue { get; set; }
        public string Origin { get; set; }
        public int IdBusinessUnit { get; set; }
        public string BusinessUnit { get; set; }
        public string BusinessUnitHtmlColor { get; set; }
        public int TotalActionItems { get; set; }
        public int TotalOpenItems { get; set; }
        public int TotalClosedItems { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public DateTime CreatedIn { get; set; }
        public int IdDepartment { get; set; }
        public string Department { get; set; }
        public string OriginDescription { get; set; }
        public string ActionPlanResponsibleDisplayName { get; set; }
        public int IdSite { get; set; }
        public string SiteName { get; set; }
        public int IdCustomer { get; set; }
        public string CustomerName { get; set; }
        public int IdZone { get; set; }
        public string Region { get; set; }
        public string TaskCode { get; set; }
        public List<ActionPlanTask> TaskList { get; set; } = new();
    }
}