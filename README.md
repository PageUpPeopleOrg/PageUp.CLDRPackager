[![Build Status](https://travis-ci.org/PageUpPeopleOrg/PageUp.CldrPackager.svg?branch=master)](https://travis-ci.org/PageUpPeopleOrg/PageUp.CldrPackager)

.NET Standard compliant CLDR (Common Locale Definition Library. 
Visit http://cldr.unicode.org/ for more information) library which can be consumed by monolith and microservices.

### CLDR Packager

Its job is to provide parsing mechanism for CLDR Json data (say https://www.npmjs.com/package/cldr-dates-modern).

The parser forms a tree like structure and provide meaningful APIs to access relevant data. The data can also be written to (and read from) the binary file as illustrated below

```csharp
var data = CldrData.LoadFromFile("cldr.bin");
var path = "dates.calendars.gregorian.months.format.abbreviated.1";
Console.WriteLine(data.GetValue(path, enGB)); 
```

## Wiki
To know more, please visit https://github.com/pgolebiowski/Onism.Cldr/wiki


## License
[The MIT License](LICENSE). Basically, you can do whatever you want as long as you include the original copyright and license notice in any copy or substantial use of this work.
