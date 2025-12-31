namespace Emdep.Geos.Core.Models
{
    public class AuthorizedLocation
    {
        public int IdCompany { get; set; }
        public string CompanyName { get; set; }
        public string Alias { get; set; }
        public int IdCountry { get; set; }
        public string CountryName { get; set; }
        public string CountryISO { get; set; }

        public bool IsLocation { get; set; }
        public bool IsOrganization { get; set; }
        public bool IsCompany { get; set; }
        public bool IsStillActive { get; set; }

        public int IdCurrency { get; set; }

        public string Region { get; set; }
        public int IdRegion { get; set; }

        public string CountryIconUrl => string.IsNullOrEmpty(CountryISO)
            ? string.Empty
            : $"https://api.emdep.com/GEOS/Images?FilePath=/Images/Countries/{CountryISO}.png";
    }
}