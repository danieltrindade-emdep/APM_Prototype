using Emdep.Geos.Services.Core.Models;

namespace Emdep.Geos.Core.Models
{
    public class Customer
    {
        public int IdCustomer { get; set; }
        public int? IdCompany { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public byte IdCustomerType { get; set; }
        public string Logo { get; set; }
        public string PatternForConnectorReferences { get; set; }
        public string Web { get; set; }
        public sbyte IsStillActive { get; set; }
        public bool IsEnabled { get; set; }

        // Dependência: Company
        public Company Company { get; set; }
        public List<Company> Companies { get; set; } = new();

        // Dependência: CustomerSort (Está no Placeholders.cs)
        public List<CustomerSort> CustomerSorts { get; set; } = new();
    }
}