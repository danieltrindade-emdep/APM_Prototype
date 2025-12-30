using Emdep.Geos.Services.Core.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Emdep.Geos.Core.Models
{
    public class LookupValue
    {
        public int IdLookupValue { get; set; }
        public string Value { get; set; }
        public string HtmlColor { get; set; }
        public byte IdLookupKey { get; set; }
        public long? IdImage { get; set; }
        public string ImageName { get; set; }
        [NotMapped]
        public byte[] ImageData { get; set; }
        public int? Position { get; set; }
        [NotMapped]
        public double SalesQuotaAmount { get; set; }
        [NotMapped]
        public double SalesQuotaAmountWithExchangeRate { get; set; }
        [NotMapped]
        [JsonIgnore]
        public object Tag { get; set; }
        [NotMapped]
        public DateTime? ExchangeRateDate { get; set; }
        [NotMapped]
        public byte IdSalesQuotaCurrency { get; set; }
        [NotMapped]
        public double? Percentage { get; set; }
        [NotMapped]
        public List<SalesStatusType> SalesStatusTypes { get; set; } = new();
        [JsonIgnore]
        public LookupKey LookupKey { get; set; }
        public bool InUse { get; set; }
        [NotMapped]
        public ulong Count { get; set; }
        [NotMapped]
        public double? Average { get; set; }
        [NotMapped]
        public decimal CountValue { get; set; }
        public string Abbreviation { get; set; }
        [NotMapped]
        public List<string> LookupValueImages { get; set; } = new();
        [NotMapped]
        public int IdRegion { get; set; }
        [NotMapped]
        public string Region { get; set; }
        [NotMapped]
        public double CurrencyConversionRate { get; set; }
        [NotMapped]
        public double ConvertedAmount { get; set; }
        [NotMapped]
        public int Days { get; set; }
        [NotMapped]
        public decimal Hours { get; set; }
        [NotMapped]
        public bool IsUpdatedRow { get; set; }
        [NotMapped]
        public string CategoryName { get; set; }
        [NotMapped]
        public int? IdParent { get; set; }
        public int? IdParentNew { get; set; }
        [NotMapped]
        public string CategoryType { get; set; }
        [NotMapped]
        public string EquipmentType { get; set; }
        [NotMapped]
        public List<TemplateTag> TagValueList { get; set; } = new();
        [NotMapped]
        public int IdTemplateSettings { get; set; }
        [NotMapped]
        public int IdEmployee { get; set; }
        [NotMapped]
        public bool IsEnabled { get; set; } = true;
        [NotMapped]
        public byte[] ImageInBytes { get; set; }
        [NotMapped]
        public bool IsSelected { get; set; }
    }
}