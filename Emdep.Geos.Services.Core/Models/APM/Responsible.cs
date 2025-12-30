using Emdep.Geos.Services.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Emdep.Geos.Core.Models
{
    public class Responsible
    {
        public uint IdEmployee { get; set; }
        public string EmployeeCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int IdGender { get; set; }
        public int IdCompanyShift { get; set; }

        [NotMapped]
        public Currency Currency { get; set; }

        public int IdOrganizationCode { get; set; }

        public string Organization { get; set; }

        public int IdOrganizationRegion { get; set; }
        public string OrganizationRegion { get; set; }
        public int IdEmployeeStatus { get; set; }
        public bool IsInActive { get; set; }
        [NotMapped]
        public bool IsTaskField { get; set; }
        public string FullName { get; set; }
        [NotMapped]
        public string EmployeeDepartments { get; set; }
        [NotMapped]
        public string JobCode { get; set; }
        [NotMapped]
        public byte[] ImageInBytes { get; set; }
        [NotMapped]
        public string EmployeeCodeWithIdGender { get; set; }
        [NotMapped]
        public int IdUser { get; set; }
        [NotMapped]
        public string UserName { get; set; }
        [NotMapped]
        public string ResponsibleDisplayName { get; set; }
        [NotMapped]
        public string JobDescriptionTitle { get; set; }
        [NotMapped]
        public int IdTask { get; set; }
    }
}