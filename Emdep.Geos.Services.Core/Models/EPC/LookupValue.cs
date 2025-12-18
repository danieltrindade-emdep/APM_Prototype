using Emdep.Geos.Services.Core.Models;

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
        public byte[] ImageData { get; set; }
        public int? Position { get; set; }
        public double SalesQuotaAmount { get; set; }
        public double SalesQuotaAmountWithExchangeRate { get; set; }

        // "Tag" geralmente é usado para guardar dados temporários de UI.
        // Mantive como object, mas pondera se é mesmo necessário enviar isto na API.
        public object Tag { get; set; }

        public DateTime? ExchangeRateDate { get; set; }
        public byte IdSalesQuotaCurrency { get; set; }
        public double? Percentage { get; set; }

        // Dependência: SalesStatusType (Tens de criar este modelo)
        public List<SalesStatusType> SalesStatusTypes { get; set; } = new();

        // Dependência: LookupKey (Tens de criar este modelo)
        public LookupKey LookupKey { get; set; }

        public bool InUse { get; set; }
        public ulong Count { get; set; }
        public double? Average { get; set; }
        public decimal CountValue { get; set; }
        public string Abbreviation { get; set; }

        public List<string> LookupValueImages { get; set; } = new();

        public int IdRegion { get; set; }
        public string Region { get; set; }
        public double CurrencyConversionRate { get; set; }
        public double ConvertedAmount { get; set; }
        public int Days { get; set; }
        public decimal Hours { get; set; }
        public bool IsUpdatedRow { get; set; }
        public string CategoryName { get; set; }
        public int? IdParent { get; set; }
        public int? IdParentNew { get; set; }
        public string CategoryType { get; set; }
        public string EquipmentType { get; set; }

        // Dependência: TemplateTag (Tens de criar este modelo)
        public List<TemplateTag> TagValueList { get; set; } = new();

        public int IdTemplateSettings { get; set; }
        public int IdEmployee { get; set; }
        public bool IsEnabled { get; set; } = true;
        public byte[] ImageInBytes { get; set; }
        public bool IsSelected { get; set; }

        // O método ToString() pode ser útil para debugging, por isso mantive-o simples
        public override string ToString() => Value;
    }
}