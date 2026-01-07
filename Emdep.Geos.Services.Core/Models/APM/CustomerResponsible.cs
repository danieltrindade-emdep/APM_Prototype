namespace Emdep.Geos.Core.Models
{
    public class CustomerResponsible
    {
        public int IdSite { get; set; }
        public string SiteName { get; set; }
        public string CountryIso { get; set; }
        public string Country { get; set; }
        public int IdCustomer { get; set; }
        public string CustomerName { get; set; }
        public int IdSalesOwner { get; set; }
        public string SalesOwner { get; set; }
        public string SalesOwnerPlant { get; set; }
        public int IdCompany { get; set; }
        public int? IdZone { get; set; }
        public string Region { get; set; }
    }
}