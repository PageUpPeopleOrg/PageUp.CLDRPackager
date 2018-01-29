using PageUp.CldrPackager.Tools.JsonParsers.Schemas;

namespace PageUp.CldrPackager.Tools.JsonParsers
{
    /// <summary>
    /// Parses JSONs valid against the "ScriptMetadata" schema.
    /// </summary>
    internal sealed class ScriptMetadataParser : CldrJsonParser
    {
        public ScriptMetadataParser() : base(CldrJsonParser.Get("ScriptMetadata"))
        {
        }
    }
}
