using Emdep.Geos.Services.Core.Models;

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

        // Dependência: Currency (Vais precisar de criar esta classe também)
        public Currency Currency { get; set; }

        public int IdOrganizationCode { get; set; }

        // No original a propriedade chamava-se 'Organization' mas usava o campo 'organizationCode'
        public string Organization { get; set; }

        public int IdOrganizationRegion { get; set; }
        public string OrganizationRegion { get; set; }
        public int IdEmployeeStatus { get; set; }
        public bool IsInActive { get; set; }
        public bool IsTaskField { get; set; }
        public string FullName { get; set; }
        public string EmployeeDepartments { get; set; }
        public string JobCode { get; set; }

        // REMOVIDO: ImageSource OwnerImage (Incompatível com API)

        // Mantido o array de bytes (Isto é o que vais enviar via JSON)
        public byte[] ImageInBytes { get; set; }

        public string EmployeeCodeWithIdGender { get; set; }
        public int IdUser { get; set; }
        public string UserName { get; set; }
        public string ResponsibleDisplayName { get; set; }
        public string JobDescriptionTitle { get; set; }
        public int IdTask { get; set; }
    }
}