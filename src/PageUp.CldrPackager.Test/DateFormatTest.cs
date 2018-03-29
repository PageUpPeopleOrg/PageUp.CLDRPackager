using Xunit;
using PageUp.CldrPackager.Tools;
using PageUp.CldrPackager.Tools.Subsetting;

namespace PageUp.CldrPackager.Test
{
    public class DateFormatTest
    {
        private static readonly CldrData _data;

        private readonly string _fullDatePath = "dates.calendars.gregorian.dateFormats.full";
        private readonly string _longDatePath = "dates.calendars.gregorian.dateFormats.long";
        private readonly string _shortDatePath = "dates.calendars.gregorian.dateFormats.short";
        private readonly string _mediumDatePath = "dates.calendars.gregorian.dateFormats.medium";

        static DateFormatTest()
        {
            var inputDirectory = @"node_modules/@pageup/locale/cldr";
            var patterns = new PatternCollectionBuilder().Build();

            var builder = new CldrDataBuilder();
            _data = builder.Build(inputDirectory, patterns);
        }

        [Fact]
        public void FullAUFormatTest()
        {
            var locale = new CldrLocale("en", null, "AU");
            Assert.Equal("EEEE, d MMMM y", _data.GetValue(_fullDatePath, locale));
        }

        [Fact]
        public void LongAUFormatTest()
        {
            var locale = new CldrLocale("en", null, "AU");
            Assert.Equal("d MMMM y", _data.GetValue(_longDatePath, locale));
        }

        [Fact]
        public void ShortAUFormatTest()
        {
            var locale = new CldrLocale("en", null, "AU");
            Assert.Equal("d/M/yy", _data.GetValue(_shortDatePath, locale));
        }

        [Fact]
        public void MediumAUFormatTest()
        {
            var locale = new CldrLocale("en", null, "AU");
            Assert.Equal("d MMM y", _data.GetValue(_mediumDatePath, locale));
        }

        [Fact]
        public void FullUSFormatTest()
        {
            var locale = new CldrLocale("en");
            Assert.Equal("EEEE, MMMM d, y", _data.GetValue(_fullDatePath, locale));
        }

        [Fact]
        public void LongUSFormatTest()
        {
            var locale = new CldrLocale("en");
            Assert.Equal("MMMM d, y", _data.GetValue(_longDatePath, locale));
        }

        [Fact]
        public void ShortUSFormatTest()
        {
            var locale = new CldrLocale("en");
            Assert.Equal("M/d/yy", _data.GetValue(_shortDatePath, locale));
        }

        [Fact]
        public void MediumUSFormatTest()
        {
            var locale = new CldrLocale("en");
            Assert.Equal("MMM d, y", _data.GetValue(_mediumDatePath, locale));
        }
    }
}