# StaticMap [![Build status](https://ci.appveyor.com/api/projects/status/g0tv13g83kialg7a?svg=true)](https://ci.appveyor.com/project/olevett/staticmap)
StaticMap is a library to generate and display static image maps across UWP platforms, in the same vein as this [blog post]( http://www.jeff.wilcox.name/2012/01/jeffwilcox-maps/).

Using static images instead of the full blown maps control can massively improve performance where the added interactions aren't necessary.

## Usage
There is a sample project in StaticMaps.UWP.Sample, which boils down to
- create a provider
- use the control

```Xaml
...
xmlns:staticMaps="using:StaticMaps"
...

<Page.Resources>
    <staticMaps:GoogleMapsProvider x:Key="MapProvider"/>
</Page.Resources>

<Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
    <staticMaps:StaticMap
      Height="200"
      Width="100"
      MapProvider="{StaticResource MapProvider}"
      />
</Grid>
```

## Supported Providers
Currently, only GoogleMaps is supported, using the GoogleMapsProvider.
