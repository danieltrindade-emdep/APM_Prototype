using Emdep.Geos.Services.Core.Models;
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
        public string UserGender { get; set; }

        // Dependências (Agora no Placeholders.cs se não tiveres os ficheiros)
        public PeopleType PeopleType { get; set; }
        public Company Company { get; set; }
        public Company ImportContactCompany { get; set; }

        // Removido ImageSource OwnerImage

        public byte? IdPersonGender { get; set; }
        public DateTime? CreatedIn { get; set; }
        public DateTime? DisabledIn { get; set; }
        public bool IsSelected { get; set; }
        public bool IsSalesResponsible { get; set; }
        public string Login { get; set; }

        public byte[] ImageBytes { get; set; } // Mantém-se apenas os bytes

        public int IdSalesTeam { get; set; }
        public int? IdCompanyDepartment { get; set; }

        public List<LogEntriesByContact> LogEntriesByContact { get; set; } = new();
        public List<LogEntriesByContact> CommentsByContact { get; set; } = new();

        public LookupValue CompanyDepartment { get; set; }
        public string JobTitle { get; set; }
        public string ImageText { get; set; }

        // Contact details
        public int? IdContactInfluenceLevel { get; set; }
        public int? IdContactEmdepAffinity { get; set; }
        public int? IdContactProductInvolved { get; set; }
        public int? IdCompetitor { get; set; }

        public Competitor Competitor { get; set; }
        public LookupValue InfluenceLevel { get; set; }
        public LookupValue EmdepAffinity { get; set; }
        public LookupValue ProductInvolved { get; set; }
        public LookupValue Gender { get; set; }

        public bool IsSiteResponsibleExist { get; set; } = true;
        public int IdCreator { get; set; }
        public People Creator { get; set; }
        public string SalesOwner { get; set; }
        public int IdSiteSalesOwner { get; set; }
        public bool IsChecked { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsFirstToContact { get; set; }

        public List<SitesWithCustomer> SitesList { get; set; } = new();

        public Group Group { get; set; }
        public Country Country { get; set; }
        public Customer Customer { get; set; }

        public List<Company> AllCompanies { get; set; } = new();
        public List<Company> FilteredCompanies { get; set; } = new();

        public string EmployeeCode { get; set; }
        public int ModifiedByPeople { get; set; }
        public People Modifier { get; set; }
        public DateTime? ModifiedInPeople { get; set; }
        public string JobDescriptionTitle { get; set; }

        // Propriedades calculadas simples
        public string FullName => $"{Name} {Surname}".Trim();

        public string SalesOwnerNameEmployeeCodesWithInitialLetters => $"{EmployeeCode}_{GetInitials(Name)}";

        public long CustomerNumberOfEmployees { get; set; }
        public long CustomerSizeInSquareMeters { get; set; }
        public string CustomerBusiness { get; set; }
        public string AnnualSalesTargetCurrency { get; set; }
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