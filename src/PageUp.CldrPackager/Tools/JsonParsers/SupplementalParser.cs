using Newtonsoft.Json.Linq;
using PageUp.CldrPackager.Tools.JsonParsers.Schemas;

namespace PageUp.CldrPackager.Tools.JsonParsers
{
    /// <summary>
    /// Parses JSONs valid against the "Supplemental" schema.
    /// </summary>
    internal sealed class SupplementalParser : CldrJsonParser
    {
        public SupplementalParser() : base(CldrJsonParser.Get("Supplemental"))
        {
        }

        public override CldrJsonMetadata ExtractMetadata(JObject obj)
        {
            return new CldrJsonMetadata
            {
                CldrVersion = obj.SelectToken("supplemental.version._cldrVersion").ToString()
            };
        }

        public override void RemoveMetadata(JObject obj)
        {
            obj.SelectToken("supplemental.version")?.Parent?.Remove();
        }
    }
}
