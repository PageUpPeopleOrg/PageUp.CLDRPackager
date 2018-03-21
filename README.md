# PageUp.CldrPackager

[![Build status](https://ci.appveyor.com/api/projects/status/173uu2q27d1gddy3?svg=true)](https://ci.appveyor.com/project/PageUp/pageup-cldrpackager-dok55)

> To publish a new package version to NuGet, increment the version in `.\src\PageUp.CldrPackager.csproj` file. 
> ```
> <PropertyGroup>
>     <Version>0.0.1</Version>
> </PropertyGroup>
> ```

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
