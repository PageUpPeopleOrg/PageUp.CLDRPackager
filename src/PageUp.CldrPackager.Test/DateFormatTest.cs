using Xunit;
using System;
using PageUp.CldrPackager.Tools;
using PageUp.CldrPackager.Tools.Subsetting;

namespace PageUp.CldrPackager.Test
{
    public class DateFormatTest
    {
        private readonly CldrData _data;
        private readonly CldrLocale _locale;

        private readonly string _fullDateFormat = "EEEE, d MMMM y";
        private readonly string _fullDatePath = "dates.calendars.gregorian.dateFormats.full";

        private readonly string _longDateFormat = "d MMMM y";
        private readonly string _longDatePath = "dates.calendars.gregorian.dateFormats.long";

        private readonly string _shortDateFormat = "d/M/yy";
        private readonly string _shortDatePath = "dates.calendars.gregorian.dateFormats.short";

        private readonly string _mediumDateFormat = "d MMM y";
        private readonly string _mediumDatePath = "dates.calendars.gregorian.dateFormats.medium";

        public DateFormatTest()
        {
            var inputDirectory = @"node_modules";
            var patterns = new PatternCollectionBuilder().Build();

            _locale = new CldrLocale("en", null, "AU");

            var builder = new CldrDataBuilder();
            _data = builder.Build(inputDirectory, patterns);
        }

        [Fact]
        public void FullFormatTest()
        {
            Assert.Equal(_fullDateFormat, _data.GetValue(_fullDatePath, _locale));
        }

        [Fact]
        public void LongFormatTest()
        {
            Assert.Equal(_longDateFormat, _data.GetValue(_longDatePath, _locale));
        }

        [Fact]
        public void ShortFormatTest()
        {
            Assert.Equal(_shortDateFormat, _data.GetValue(_shortDatePath, _locale));
        }

        [Fact]
        public void MediumFormatTest()
        {
            Assert.Equal(_mediumDateFormat, _data.GetValue(_mediumDatePath, _locale));
        }
    }
}