namespace Emdep.Geos.Contracts.APM
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
        public int Id { get; init; }
        public string Name { get; init; }
    }

    public record LocationFilterDTO
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string CountryIso { get; init; }
        public string CountryIconUrl { get; init; }
    }

    public record ResponsibleFilterDTO
    {
        public int Id { get; init; }
        public string DisplayName { get; init; }
        public string EmployeeCode { get; init; }
        public int IdGender { get; init; }
        public string ImageUrl { get; init; }
        public string BackupImageUrl { get; init; }
    }

    public record ThemeFilterDTO
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string HtmlColor { get; init; }
    }
}
