namespace Emdep.Geos.Core.Models
{
    public class LookupValue
    {
        public int IdLookupValue { get; set; }
        public string Value { get; set; }
        public int IdLookupKey { get; set; }
        public string HtmlColor { get; set; }
        public int? IdImage { get; set; }
        public int? Position { get; set; }
        public string Abbreviation { get; set; }
        public int? IdParent { get; set; }
        public string ImageName { get; set; }
        public bool InUse { get; set; }
        public string Value_es { get; set; }
        public string Value_fr { get; set; }
        public string Value_pt { get; set; }
        public string Value_ro { get; set; }
        public string Value_ru { get; set; }
        public string Value_zh { get; set; }
    }
}