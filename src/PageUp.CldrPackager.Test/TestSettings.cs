using System;
using System.IO;
using System.Reflection;

namespace PageUp.CldrPackager.Test
{
    public static class TestSettings
    {
        private const string CldrFileInputDirectory = "node_modules/@pageup/locale/cldr";

        public static string GetCldrFileInputDirectoryPath()
        {
            return new Uri(Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase),
                CldrFileInputDirectory)).LocalPath;
        }
    }
}