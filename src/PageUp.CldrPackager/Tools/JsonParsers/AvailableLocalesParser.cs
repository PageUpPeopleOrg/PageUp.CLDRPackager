using PageUp.CldrPackager.Tools.JsonParsers.Schemas;

namespace PageUp.CldrPackager.Tools.JsonParsers
{
    /// <summary>
    /// Parses JSONs valid against the "AvailableLocales" schema.
    /// </summary>
    internal sealed class AvailableLocalesParser : CldrJsonParser
    {
        public AvailableLocalesParser() : base(CldrJsonParser.Get("AvailableLocales"))
        {
        }
    }
}