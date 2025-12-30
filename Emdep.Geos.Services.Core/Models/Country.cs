using Emdep.Geos.Services.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Emdep.Geos.Core.Models
{
    public class Country
    {
        public byte IdCountry { get; set; }

        public string Name { get; set; }

        public int IdContinent { get; set; }

        public List<Company> Sites { get; set; } = new();

        [NotMapped]
        public sbyte Eu_member { get; set; }

        [NotMapped]
        public sbyte EuroZone { get; set; }

        [NotMapped]
        public string Iso { get; set; }

        [NotMapped]
        public string Printable_name { get; set; }

        [NotMapped]
        public string Iso3 { get; set; }

        [NotMapped]
        public short Numcode { get; set; }

        [NotMapped]
        public string MainLanguage { get; set; }

        [NotMapped]
        public string Observations { get; set; }

        [NotMapped]
        public float StandardVAT { get; set; }

        [NotMapped]
        public sbyte StrictCustoms { get; set; }

        [NotMapped]
        public sbyte Mercosur_member { get; set; }

        [NotMapped]
        public sbyte IdCurrency { get; set; }

        [NotMapped]
        public int IdZone { get; set; }

        [NotMapped]
        [JsonIgnore]
        public Zone Zone { get; set; }

        [NotMapped]
        public long IdCountryGroup { get; set; }

        [NotMapped]
        public CountryGroup CountryGroup { get; set; }

        [NotMapped]
        public byte[] CountryIconBytes { get; set; }

        [NotMapped]
        public int IdRegion { get; set; }

        [NotMapped]
        public uint IdGroup { get; set; }

        [NotMapped]
        public string CountryIconUrl { get; set; }

        [NotMapped]
        public string State { get; set; }
    }
}