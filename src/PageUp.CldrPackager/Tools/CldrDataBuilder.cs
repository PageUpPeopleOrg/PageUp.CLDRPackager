using System;
using System.IO;
using Newtonsoft.Json.Linq;
using PageUp.CldrPackager.Tools.JsonParsers;
using PageUp.CldrPackager.Tools.Subsetting;

namespace PageUp.CldrPackager.Tools
{
    public class CldrDataBuilder
    {
        private readonly CldrJsonFileFinder fileFinder;
        private readonly VersionFieldConsistencyAssurer cldrVersionConsistencyAssurer;
        private readonly VersionFieldConsistencyAssurer pageUpVersionConsistencyAssurer;
        private readonly CldrJsonParser[] jsonParsers;

        public CldrDataBuilder()
        {
            this.fileFinder = new CldrJsonFileFinder();
            this.cldrVersionConsistencyAssurer = new VersionFieldConsistencyAssurer(@"CLDR");
            this.pageUpVersionConsistencyAssurer = new VersionFieldConsistencyAssurer(@"PageUp");
            this.jsonParsers = new CldrJsonParser[]
            {
                new AvailableLocalesParser(),
                new DefaultContentParser(),
                new MainParser(),
                new RbnfParser(),
                new ScriptMetadataParser(),
                new SegmentsParser(),
                new SupplementalParser()
            };
        }

        public CldrData Build(string directory, PatternCollection patterns)
        {
            var cldrTreeBuilder = new CldrTreeBuilder();
            var pageUpVersion = (string)null;
            var done = 0;

            foreach (var path in this.fileFinder.FindFiles(directory))
            {
                var json = File.ReadAllText(path);
                var token = JObject.Parse(json);
                var wasMatched = false;

                foreach (var parser in this.jsonParsers)
                {
                    if (!parser.IsValid(token))
                        continue;

                    var metadata = parser.ExtractMetadata(token);
                    parser.RemoveMetadata(token);

                    this.cldrVersionConsistencyAssurer.AssureVersionIsConsistent(metadata?.CldrVersion, path);
                    this.pageUpVersionConsistencyAssurer.AssureVersionIsConsistent(metadata?.PageUpVersion, path);
                    pageUpVersion = metadata?.PageUpVersion ?? pageUpVersion;

                    token.Subset(patterns);

                    var toAdd = parser.PrepareForMerging(metadata?.CldrLocale, token);
                    cldrTreeBuilder.Add(toAdd);
                    
                    wasMatched = true;
                }

                if (!wasMatched)
                {
                    // react depending on the options (-ignore, -warning, -error)
                }
                done++;
                if (done % 100 == 0)
                Console.WriteLine($"{done} files processed");
            }
            if (done % 100 != 0)
                Console.WriteLine($"{done} files processed");
            
            return new CldrData
            {
                Tree = cldrTreeBuilder.Tree,
                PageUpVersion = pageUpVersion
            };
        }
    }
}
