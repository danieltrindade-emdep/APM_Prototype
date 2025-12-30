using Emdep.Geos.Services.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Emdep.Geos.Core.Models
{
    public class Company
    {
        public int IdCompany { get; set; }

        public string Name { get; set; }

        public byte? IsStillActive { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedIn { get; set; }

        public byte? IdCountry { get; set; }

        public string City { get; set; }

        public string CIF { get; set; }

        public string Address { get; set; }

        public string Telephone { get; set; }

        public string Fax { get; set; }

        public string Email { get; set; }

        public string RegisteredName { get; set; }

        public string ZipCode { get; set; }

        public string Region { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedIn { get; set; }

        public string Website { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public byte IsCompany { get; set; }

        public byte IsOrganization { get; set; }

        public byte IsLocation { get; set; }

        public string Alias { get; set; }

        [NotMapped]
        public bool IsSiteImageAvailable { get; set; }

        public int? IdEnterpriseGroup { get; set; }

        [NotMapped]
        public bool IsExist { get; set; }

        [NotMapped]
        public bool IsUpdate { get; set; }

        [NotMapped]
        public List<SalesStatusType> SalesStatusTypes { get; set; } = new();

        [NotMapped]
        public string BusinessProductString { get; set; }

        [NotMapped]
        public SalesTargetBySite SalesTargetBySite { get; set; }

        [NotMapped]
        public string FullName { get; set; }

        [NotMapped]
        public Customer Customer { get; set; }

        [NotMapped]
        public string PostCode { get; set; }

        [NotMapped]
        public string LocationLatitude { get; set; }

        [NotMapped]
        public string ShortName { get; set; }

        [NotMapped]
        public string LocationLongitude { get; set; }

        [NotMapped]
        public int? IdSalesResponsible { get; set; }

        [NotMapped]
        public int? IdSalesResponsibleAssemblyBU { get; set; }

        [NotMapped]
        public double? Amount { get; set; }

        [NotMapped]
        public string StatusName { get; set; }

        [NotMapped]
        public int? Line { get; set; }

        [NotMapped]
        public int? CuttingMachines { get; set; }

        [NotMapped]
        public string ConnectPlantId { get; set; }

        [NotMapped]
        public string ConnectPlantConstr { get; set; }

        [NotMapped]
        public double? Size { get; set; }

        [NotMapped]
        public int? NumberOfEmployees { get; set; }

        [NotMapped]
        public byte? IdBusinessField { get; set; }

        [NotMapped]
        public byte? IdBusinessCenter { get; set; }

        [NotMapped]
        public string IdBusinessProduct { get; set; }

        [NotMapped]
        public List<SitesByBusinessProduct> BusinessProductList { get; set; } = new();

        [NotMapped]
        public byte? IdBusinessType { get; set; }

        [NotMapped]
        public int IdCustomer { get; set; }

        [NotMapped]
        public LookupValue BusinessField { get; set; }

        [NotMapped]
        public LookupValue BusinessCenter { get; set; }

        [NotMapped]
        public LookupValue BusinessType { get; set; }

        [NotMapped]
        public User SalesResponsible { get; set; }

        [NotMapped]
        public User SalesResponsibleAssemblyBU { get; set; }

        [NotMapped]
        public bool IsPermission { get; set; }

        [NotMapped]
        public People People { get; set; }

        [NotMapped]
        public People PeopleSalesResponsibleAssemblyBU { get; set; }

        [NotMapped]
        public string SiteNameWithoutCountry { get; set; }

        [NotMapped]
        public string BothLongitudeLatitude { get; set; }

        [NotMapped]
        public double Age { get; set; }

        [NotMapped]
        public double DecimalAge { get; set; }

        [NotMapped]
        public List<SalesTargetBySite> SalesTargetBySiteLst { get; set; } = new();

        [NotMapped]
        public SalesStatusType SalesStatusTypeWon { get; set; }

        [NotMapped]
        public string LanguageForDocumentation { get; set; }

        [NotMapped]
        public List<LogEntryBySite> LogEntryBySites { get; set; } = new();

        [NotMapped]
        public string GroupPlantName { get; set; }

        [NotMapped]
        public Country GroupCountry { get; set; }

        [JsonIgnore]
        public Country Country { get; set; }
        [JsonIgnore]

        public EnterpriseGroup EnterpriseGroup { get; set; }
        [JsonIgnore]
        public List<User> Users { get; set; } = new();

        public List<SiteUserPermission> SiteUserPermissions { get; set; } = new();

        public List<GeosProvider> GeosProviders { get; set; } = new();

        public List<Supplier> Suppliers { get; set; } = new();

        public List<Customer> Customers { get; set; } = new();

        public List<Offer> Offers { get; set; } = new();

        [NotMapped]
        [JsonIgnore]
        public CountryGroup CountryGroup { get; set; }

        [NotMapped]
        public string Coordinates => $"{Latitude} {Longitude}";

        [NotMapped]
        public uint EmployeesCount { get; set; }

        public string TimeZoneIdentifier { get; set; }

        [NotMapped]
        public People PeopleCreatedBy { get; set; }

        [NotMapped]
        public List<CompanyChangelog> CompanyChangelogs { get; set; } = new();

        [NotMapped]
        public List<Employee> Employees { get; set; } = new();

        [NotMapped]
        public DateTime EstablishmentDate { get; set; }

        [NotMapped]
        public byte[] ImageInBytes { get; set; }

        [NotMapped]
        public bool IsImageDeleted { get; set; }

        [NotMapped]
        public string FileExtension { get; set; }

        [NotMapped]
        public CompanySetting CompanySetting { get; set; }

        [NotMapped]
        public CompanyAnnualSchedule CompanyAnnualSchedule { get; set; }

        [NotMapped]
        public List<CompanySchedule> CompanySchedules { get; set; } = new();

        [NotMapped]
        public string ServiceProviderUrl { get; set; }

        [NotMapped]
        public int IdCurrency { get; set; }

        [NotMapped]
        public string Iso { get; set; }

        [NotMapped]
        public List<People> SalesOwnerList { get; set; } = new();

        [NotMapped]
        public string SalesOwnerUnbound { get; set; }

        [NotMapped]
        public string RegisteredNumber { get; set; }

        [NotMapped]
        public int IdSource { get; set; }

        [NotMapped]
        public string SourceName { get; set; }

        [NotMapped]
        public LookupValue Source { get; set; }

        [NotMapped]
        public string SalesOwnerEnabled { get; set; }

        [NotMapped]
        public string SalesOwnerDisabled { get; set; }

        [NotMapped]
        public string IP { get; set; }

        [NotMapped]
        public string Code { get; set; }

        [NotMapped]
        public string DatabaseIP { get; set; }

        [NotMapped]
        public bool IsSelected { get; set; }

        [NotMapped]
        public string CountryIconUrl { get; set; }

        [NotMapped]
        public int Idincoterm { get; set; }

        [NotMapped]
        public int IdPaymentType { get; set; }

        [NotMapped]
        public List<ShippingAddress> CompanyShippingAddress { get; set; } = new();

        [NotMapped]
        public List<ShippingAddress> ShippingAddressOfCompany { get; set; } = new();

        [NotMapped]
        public string PaymentTerm { get; set; }

        [NotMapped]
        public int IdBusinessUnit { get; set; }

        [NotMapped]
        public string BusinessUnit { get; set; }

        [NotMapped]
        public int IdCompanyLogo { get; set; }

        [NotMapped]
        public int IdCompanyType { get; set; }

        [NotMapped]
        public LookupValue CompanyType { get; set; }

        [NotMapped]
        public LookupValue CompanyLogo { get; set; }

        [NotMapped]
        public int? IdStatus { get; set; }

        [NotMapped]
        public LookupValue Status { get; set; }

        [NotMapped]
        public string FullAddress { get; set; }

        [NotMapped]
        public int ContactCount { get; set; }

        [NotMapped]
        public int IdPerson { get; set; }

        [NotMapped]
        public bool IsSelectedRow { get; set; }

        [NotMapped]
        public bool IsCoordinatesNull { get; set; }

        [NotMapped]
        public int IdPersonGender { get; set; }

        [NotMapped]
        public byte[] OwnerImageBytes { get; set; }

        [NotMapped]
        public List<People> SalesOwnerListForImages { get; set; } = new();

        [NotMapped]
        public string ModifiedByPeople { get; set; }

        [NotMapped]
        public int IdRegion { get; set; }

        public override string ToString() => Alias ?? "---";
    }
}