using Emdep.Geos.Services.Core.Models;

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
        public bool IsSiteImageAvailable { get; set; }
        public int? IdEnterpriseGroup { get; set; }
        public bool IsExist { get; set; }
        public bool IsUpdate { get; set; }

        // Dependências (Agora cobertas pelo Placeholders.cs)
        public List<SalesStatusType> SalesStatusTypes { get; set; } = new();
        public string BusinessProductString { get; set; }
        public SalesTargetBySite SalesTargetBySite { get; set; }
        public string FullName { get; set; }
        public Customer Customer { get; set; }
        public string PostCode { get; set; }
        public string LocationLatitude { get; set; }
        public string ShortName { get; set; }
        public string LocationLongitude { get; set; }
        public int? IdSalesResponsible { get; set; }
        public int? IdSalesResponsibleAssemblyBU { get; set; }
        public double? Amount { get; set; }
        public string StatusName { get; set; }
        public int? Line { get; set; }
        public int? CuttingMachines { get; set; }
        public string ConnectPlantId { get; set; }
        public string ConnectPlantConstr { get; set; }
        public double? Size { get; set; }
        public int? NumberOfEmployees { get; set; }
        public byte? IdBusinessField { get; set; }
        public byte? IdBusinessCenter { get; set; }
        public string IdBusinessProduct { get; set; }

        public List<SitesByBusinessProduct> BusinessProductList { get; set; } = new();

        public byte? IdBusinessType { get; set; }
        public int IdCustomer { get; set; }
        public LookupValue BusinessField { get; set; }
        public LookupValue BusinessCenter { get; set; }
        public LookupValue BusinessType { get; set; }

        // Removido ImageSource SiteImage

        public User SalesResponsible { get; set; }
        public User SalesResponsibleAssemblyBU { get; set; }
        public bool IsPermission { get; set; }
        public People People { get; set; }
        public People PeopleSalesResponsibleAssemblyBU { get; set; }
        public string SiteNameWithoutCountry { get; set; }
        public string BothLongitudeLatitude { get; set; }
        public double Age { get; set; }
        public double DecimalAge { get; set; }
        public List<SalesTargetBySite> SalesTargetBySiteLst { get; set; } = new();
        public SalesStatusType SalesStatusTypeWon { get; set; }
        public string LanguageForDocumentation { get; set; }
        public List<LogEntryBySite> LogEntryBySites { get; set; } = new();
        public string GroupPlantName { get; set; }
        public Country GroupCountry { get; set; }
        public Country Country { get; set; }
        public EnterpriseGroup EnterpriseGroup { get; set; }

        // Listas de Coleções
        public List<User> Users { get; set; } = new();
        public List<SiteUserPermission> SiteUserPermissions { get; set; } = new();
        public List<GeosProvider> GeosProviders { get; set; } = new();
        public List<Supplier> Suppliers { get; set; } = new();
        public List<Customer> Customers { get; set; } = new();
        public List<Offer> Offers { get; set; } = new();

        public CountryGroup CountryGroup { get; set; }
        public string Coordinates => $"{Latitude} {Longitude}";
        public uint EmployeesCount { get; set; }
        public string TimeZoneIdentifier { get; set; }
        public People PeopleCreatedBy { get; set; }
        public List<CompanyChangelog> CompanyChangelogs { get; set; } = new();
        public List<Employee> Employees { get; set; } = new();
        public DateTime EstablishmentDate { get; set; }
        public byte[] ImageInBytes { get; set; }
        public bool IsImageDeleted { get; set; }
        public string FileExtension { get; set; }

        public CompanySetting CompanySetting { get; set; }
        public CompanyAnnualSchedule CompanyAnnualSchedule { get; set; }
        public List<CompanySchedule> CompanySchedules { get; set; } = new();

        public string ServiceProviderUrl { get; set; }
        public int IdCurrency { get; set; }
        public string Iso { get; set; }
        public List<People> SalesOwnerList { get; set; } = new();
        public string SalesOwnerUnbound { get; set; }
        public string RegisteredNumber { get; set; }
        public int IdSource { get; set; }
        public string SourceName { get; set; }
        public LookupValue Source { get; set; }
        public string SalesOwnerEnabled { get; set; }
        public string SalesOwnerDisabled { get; set; }
        public string IP { get; set; }
        public string Code { get; set; }
        public string DatabaseIP { get; set; }
        public bool IsSelected { get; set; }
        public string CountryIconUrl { get; set; }
        public int Idincoterm { get; set; }
        public int IdPaymentType { get; set; }

        // Simplifiquei as listas de ShippingAddress (CRM vs OTM) para usar o placeholder genérico
        public List<ShippingAddress> CompanyShippingAddress { get; set; } = new();
        public List<ShippingAddress> ShippingAddressOfCompany { get; set; } = new();

        public string PaymentTerm { get; set; }
        public int IdBusinessUnit { get; set; }
        public string BusinessUnit { get; set; }
        public int IdCompanyLogo { get; set; }
        public int IdCompanyType { get; set; }
        public LookupValue CompanyType { get; set; }
        public LookupValue CompanyLogo { get; set; }
        public int? IdStatus { get; set; }
        public LookupValue Status { get; set; }
        public string FullAddress { get; set; }
        public int ContactCount { get; set; }
        public int IdPerson { get; set; }

        // Removido ImageSource OwnerImage

        public bool IsSelectedRow { get; set; }
        public bool IsCoordinatesNull { get; set; }
        public int IdPersonGender { get; set; }
        public byte[] OwnerImageBytes { get; set; }
        public List<People> SalesOwnerListForImages { get; set; } = new();
        public string ModifiedByPeople { get; set; }
        public int IdRegion { get; set; }

        public override string ToString() => Alias ?? "---";
    }
}