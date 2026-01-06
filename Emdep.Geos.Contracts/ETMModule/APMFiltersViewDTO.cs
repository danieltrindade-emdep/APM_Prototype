namespace Emdep.Geos.Contracts.ETMModule
{
    public class APMFiltersViewDTO
    {
        public List<int> AvailableYears { get; init; } = [];
        public List<LocationFilterDTO> Locations { get; init; } = [];
        public List<ResponsibleFilterDTO> Responsibles { get; init; } = [];
        public List<GenericLookupFilterDTO> BusinessUnits { get; init; } = [];
        public List<GenericLookupFilterDTO> Origins { get; init; } = [];
        public List<GenericLookupFilterDTO> Departments { get; init; } = [];
        public List<GenericLookupFilterDTO> Customers { get; init; } = [];
        public List<ThemeFilterDTO> Themes { get; init; } = [];
    }

    public record GenericLookupFilterDTO
    {
        public int Id { get; init; } // IdLookupValue
        public string Name { get; init; } // Value
    }

    public record LocationFilterDTO
    {
        public int Id { get; init; } // IdCompany
        public string Name { get; init; } // Alias
        public string CountryIso { get; init; }
    }

    public record ResponsibleFilterDTO
    {
        public int Id { get; init; } // IdEmployee
        public string Name { get; init; } // FullName
        public string DisplayName { get; init; } // ResponsibleDisplayName
        public string EmployeeCode { get; init; }
        public int IdGender { get; init; }
        public string ImageUrl { get; init; }
    }

    public record ThemeFilterDTO
    {
        public int Id { get; init; } // IdLookupValue
        public string Name { get; init; } // Value
        public string HtmlColor { get; init; }
    }
}
