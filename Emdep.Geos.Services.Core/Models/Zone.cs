namespace Emdep.Geos.Core.Models
{
    public class Zone
    {
        public int IdZone { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Name_es { get; set; }
        public string Name_fr { get; set; }
        public string Name_pt { get; set; }
        public string Name_ro { get; set; }
        public string Name_ru { get; set; }
        public string Name_zh { get; set; }

        // Dependência: Country (Já existe o ficheiro real)
        public List<Country> Countries { get; set; } = new();
    }
}