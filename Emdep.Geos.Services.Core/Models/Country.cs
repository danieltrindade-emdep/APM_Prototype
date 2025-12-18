using Emdep.Geos.Services.Core.Models;

namespace Emdep.Geos.Core.Models
{
    public class Country
    {
        public byte IdCountry { get; set; }
        public string Name { get; set; }
        public int IdContinent { get; set; }

        // Dependência: Company (Já existe ou está no placeholder)
        public List<Company> Sites { get; set; } = new();

        public sbyte Eu_member { get; set; }
        public sbyte EuroZone { get; set; }
        public string Iso { get; set; }
        public string Printable_name { get; set; }
        public string Iso3 { get; set; }
        public short Numcode { get; set; }
        public string MainLanguage { get; set; }
        public string Observations { get; set; }
        public float StandardVAT { get; set; }
        public sbyte StrictCustoms { get; set; }
        public sbyte Mercosur_member { get; set; }
        public sbyte IdCurrency { get; set; }
        public int IdZone { get; set; }

        // Dependência: Zone (Precisas de adicionar ao Placeholders.cs)
        public Zone Zone { get; set; }

        public long IdCountryGroup { get; set; }

        // Dependência: CountryGroup (Precisas de adicionar ao Placeholders.cs)
        public CountryGroup CountryGroup { get; set; }

        public byte[] CountryIconBytes { get; set; }
        // Removido: ImageSource CountryIconImage (Incompatível com API)

        public int IdRegion { get; set; }
        public uint IdGroup { get; set; }
        public string CountryIconUrl { get; set; }
        public string State { get; set; }
    }
}