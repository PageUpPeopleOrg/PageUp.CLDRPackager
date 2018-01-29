using PageUp.CldrPackager.Tools.JsonParsers.Schemas;

namespace PageUp.CldrPackager.Tools.JsonParsers
{
    /// <summary>
    /// Parses JSONs valid against the "DefaultContent" schema.
    /// </summary>
    internal sealed class DefaultContentParser : CldrJsonParser
    {
        public DefaultContentParser() : base(CldrJsonParser.Get("DefaultContent"))
        {
        }
    }
}