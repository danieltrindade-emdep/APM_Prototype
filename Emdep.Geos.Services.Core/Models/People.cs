using Emdep.Geos.Services.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Emdep.Geos.Core.Models
{
    public class People
    {
        public int IdPerson { get; set; }

        public int IdEmployee { get; set; }

        public int IdUser { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public byte IdPersonType { get; set; }

        public string Email { get; set; }

        public int IdSite { get; set; }

        public byte IsStillActive { get; set; }

        public string Phone { get; set; }

        public string Phone2 { get; set; }

        public string Observations { get; set; }

        [NotMapped]
        public string UserGender { get; set; }

        // Dependências (Agora no Placeholders.cs se não tiveres os ficheiros)
        [NotMapped]
        [JsonIgnore]
        public PeopleType PeopleType { get; set; }

        [NotMapped]
        [JsonIgnore]
        public Company Company { get; set; }

        [NotMapped]
        [JsonIgnore]
        public Company ImportContactCompany { get; set; }

        public byte? IdPersonGender { get; set; }

        [NotMapped]
        public DateTime? CreatedIn { get; set; }

        [NotMapped]
        public DateTime? DisabledIn { get; set; }

        [NotMapped]
        public bool IsSelected { get; set; }

        [NotMapped]
        public bool IsSalesResponsible { get; set; }

        [NotMapped]
        public string Login { get; set; }

        [NotMapped]
        public byte[] ImageBytes { get; set; } // Mantém-se apenas os bytes

        [NotMapped]
        public int IdSalesTeam { get; set; }

        [NotMapped]
        public int? IdCompanyDepartment { get; set; }

        [NotMapped]
        public List<LogEntriesByContact> LogEntriesByContact { get; set; } = new();

        [NotMapped]
        public List<LogEntriesByContact> CommentsByContact { get; set; } = new();

        [NotMapped]
        [JsonIgnore]
        public LookupValue CompanyDepartment { get; set; }

        [NotMapped]
        public string JobTitle { get; set; }

        [NotMapped]
        public string ImageText { get; set; }

        public int? IdContactInfluenceLevel { get; set; }

        public int? IdContactEmdepAffinity { get; set; }

        public int? IdContactProductInvolved { get; set; }

        public int? IdCompetitor { get; set; }

        [NotMapped]
        [JsonIgnore]
        public Competitor Competitor { get; set; }

        [NotMapped]
        [JsonIgnore]
        public LookupValue InfluenceLevel { get; set; }

        [NotMapped]
        [JsonIgnore]
        public LookupValue EmdepAffinity { get; set; }

        [NotMapped]
        [JsonIgnore]
        public LookupValue ProductInvolved { get; set; }

        [NotMapped]
        [JsonIgnore]
        public LookupValue Gender { get; set; }

        [NotMapped]
        public bool IsSiteResponsibleExist { get; set; } = true;

        public int IdCreator { get; set; }

        [NotMapped]
        [JsonIgnore]
        public People Creator { get; set; }

        [NotMapped]
        public string SalesOwner { get; set; }

        [NotMapped]
        public int IdSiteSalesOwner { get; set; }

        [NotMapped]
        public bool IsChecked { get; set; }

        [NotMapped]
        public bool IsEnabled { get; set; }

        public bool IsFirstToContact { get; set; }

        [NotMapped]
        public List<SitesWithCustomer> SitesList { get; set; } = new();

        [NotMapped]
        [JsonIgnore]
        public Group Group { get; set; }
        [JsonIgnore]
        public Country Country { get; set; }
        [JsonIgnore]
        public Customer Customer { get; set; }
        [JsonIgnore]
        public List<Company> AllCompanies { get; set; } = new();
        [JsonIgnore]
        public List<Company> FilteredCompanies { get; set; } = new();

        [NotMapped]
        public string EmployeeCode { get; set; }

        [NotMapped]
        public int ModifiedByPeople { get; set; }

        [NotMapped]
        [JsonIgnore]
        public People Modifier { get; set; }

        [NotMapped]
        public DateTime? ModifiedInPeople { get; set; }

        [NotMapped]
        public string JobDescriptionTitle { get; set; }

        // Propriedades calculadas simples
        [NotMapped]
        public string FullName => $"{Name} {Surname}".Trim();

        public string SalesOwnerNameEmployeeCodesWithInitialLetters => $"{EmployeeCode}_{GetInitials(Name)}";

        [NotMapped]
        public long CustomerNumberOfEmployees { get; set; }

        [NotMapped]
        public long CustomerSizeInSquareMeters { get; set; }

        [NotMapped]
        public string CustomerBusiness { get; set; }

        [NotMapped]
        public string AnnualSalesTargetCurrency { get; set; }

        [NotMapped]
        public string AnnualSalesTargetAmount { get; set; }

        public override string ToString() => FullName;

        private static string GetInitials(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName)) return string.Empty;
            var words = fullName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (words.Length == 1) return words[0][0].ToString().ToUpper();
            return (words[0][0].ToString() + words[words.Length - 1][0].ToString()).ToUpper();
        }
    }
}