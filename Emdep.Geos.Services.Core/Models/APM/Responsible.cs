namespace Emdep.Geos.Core.Models
{
    public class Responsible
    {
        public uint IdEmployee { get; set; }
        public string EmployeeCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public int IdGender { get; set; }
        public int IdCompany { get; set; }
        public string OrganizationCode { get; set; }
        public int IdJDScope { get; set; }
        public int IdRegion { get; set; }
        public int IdCountry { get; set; }
        public int IdEmployeeStatus { get; set; }
        public string JobCode { get; set; }
        public string EmployeeContactValue { get; set; }
        public int IdUser { get; set; }
        public string Login { get; set; }
        public string ResponsibleDisplayName { get; set; }
    }
}