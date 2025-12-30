using System.ComponentModel.DataAnnotations.Schema;

namespace Emdep.Geos.Core.Models
{
    public class APMCustomer
    {
        [NotMapped]
        public string Group { get; set; }
        [NotMapped]
        public string Site { get; set; }
        [NotMapped]
        public string Region { get; set; }
        [NotMapped]
        public int IdSite { get; set; }
        [NotMapped]
        public int IdRegion { get; set; }
        [NotMapped]
        public int IdCustomer { get; set; }
        [NotMapped]
        public string GroupName { get; set; }
        [NotMapped]
        public int IdCompany { get; set; }
    }
}

