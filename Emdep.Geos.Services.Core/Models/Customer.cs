using Emdep.Geos.Services.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Emdep.Geos.Core.Models
{
    public class Customer
    {
        public int IdCustomer { get; set; }
        public int? IdCompany { get; set; }
        public string CustomerName { get; set; }
        [NotMapped]
        public string Email { get; set; }
        [NotMapped]
        public byte IdCustomerType { get; set; }
        [NotMapped]
        public string Logo { get; set; }
        [NotMapped]
        public string PatternForConnectorReferences { get; set; }
        [NotMapped]
        public string Web { get; set; }
        [NotMapped]
        public sbyte IsStillActive { get; set; }
        [NotMapped]
        public bool IsEnabled { get; set; }
        [JsonIgnore]
        public Company Company { get; set; }
        [NotMapped]
        [JsonIgnore]
        public List<Company> Companies { get; set; } = new();
        [NotMapped]
        public List<CustomerSort> CustomerSorts { get; set; } = new();
    }
}