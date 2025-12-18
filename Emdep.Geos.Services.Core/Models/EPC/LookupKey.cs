namespace Emdep.Geos.Core.Models
{
    public class LookupKey
    {
        public byte IdLookupKey { get; set; }
        public string LookupKeyName { get; set; }
        public sbyte IsEditable { get; set; }

        // Dependência: LookupValue (que refatorámos no passo anterior)
        public List<LookupValue> LookupValues { get; set; } = new();
    }
}