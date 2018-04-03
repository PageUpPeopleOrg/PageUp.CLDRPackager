using System;

namespace PageUp.CldrPackager.Tools
{
    internal class VersionFieldConsistencyAssurer
    {
        private string initialVersion;
        private string initialPath;
        private bool isVersionSet;
        private readonly string fieldName;

        public VersionFieldConsistencyAssurer(string fieldName)
        {
            this.fieldName = fieldName;
            this.isVersionSet = false;
        }

        public void AssureVersionIsConsistent(string version, string filePath)
        {
            if (version == null)
            {
                return;
            }

            if (!this.isVersionSet)
            {
                this.initialVersion = version;
                this.initialPath = filePath;
                this.isVersionSet = true;
                return;
            }

            if (string.Equals(this.initialVersion, version))
            {
                return;
            }

            var first = $"Version '{this.initialVersion}' was found in the file '{this.initialPath}'.";
            var second = $"Version '{version}' was found in the file '{filePath}'.";
            throw new FormatException($"Inconsistent {this.fieldName} versions detected.\n{first}\n{second}");
        }
    }
}
