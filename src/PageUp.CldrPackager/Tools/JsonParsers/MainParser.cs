using Newtonsoft.Json.Linq;
using PageUp.CldrPackager.Tools.JsonParsers.Schemas;

namespace PageUp.CldrPackager.Tools.JsonParsers
{
    /// <summary>
    /// Parses JSONs valid against the "Main" schema.
    /// </summary>
    internal sealed class MainParser : CldrJsonParser
    {
        public MainParser() : base(CldrJsonParser.Get("Main"))
        {
        }

        public override CldrJsonMetadata ExtractMetadata(JObject obj)
        {
            return new CldrJsonMetadata
            {
                CldrVersion = obj.SelectToken("main.*.identity.version._cldrVersion").ToString(),
                CldrLocale = new CldrLocale(
                    language: obj.SelectToken("main.*.identity.language").ToString(),
                    script: obj.SelectToken("main.*.identity.script")?.ToString(),
                    territory: obj.SelectToken("main.*.identity.territory")?.ToString(),
                    variant: obj.SelectToken("main.*.identity.variant")?.ToString()
                ),
                PageupVersion = obj.SelectToken("main.*.identity.version._pageupVersion").ToString()
            };
        }

        public override void RemoveMetadata(JObject obj)
        {
            obj.SelectToken("main.*.identity").Parent.Remove();
        }

        public override CldrJson PrepareForMerging(CldrLocale locale, JObject obj)
        {
            var dataProperty = obj.SelectToken("main.*.*")?.Parent;
            if (dataProperty == null)
                return null;

            var data = new JObject((JProperty)dataProperty);
            return new CldrJson(locale, data);
        }
    }
}
