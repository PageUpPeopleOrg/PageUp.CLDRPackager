using System;
using PageUp.CldrPackager.Tools;
using Xunit;

namespace PageUp.CldrPackager.Test
{
    public class VersionFieldConsistencyAssurerTest
    {
        [Fact]
        public void MatchingVersionsValidateCorrectly()
        {
            const string version = "1.1.0";
            const string path1 = "path/a";
            const string path2 = "path/b";

            var assurer = new VersionFieldConsistencyAssurer("Test");

            assurer.AssureVersionIsConsistent(version, path1);
            assurer.AssureVersionIsConsistent(version, path2);
        }

        [Fact]
        public void NullVersionDoesNotFailValidation()
        {
            const string version = "1.1.0";
            const string path1 = "path/a";
            const string path2 = "path/b";
            const string path3 = "path/c";
            const string path4 = "path/d";

            var assurer = new VersionFieldConsistencyAssurer("Test");

            assurer.AssureVersionIsConsistent(null, path1);
            assurer.AssureVersionIsConsistent(version, path2);
            assurer.AssureVersionIsConsistent(null, path3);
            assurer.AssureVersionIsConsistent(version, path4);
        }

        [Fact]
        public void VersionMismatchThrowsFormatException()
        {
            const string version1 = "1.1.0";
            const string version2 = "1.2.0";
            const string path1 = "path/a";
            const string path2 = "path/b";

            var assurer = new VersionFieldConsistencyAssurer("Test");

            assurer.AssureVersionIsConsistent(version1, path1);
            Assert.Throws<FormatException>(() => assurer.AssureVersionIsConsistent(version2, path2));
        }
    }
}
