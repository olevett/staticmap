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

### Properties on the control
- __MapProvider__ sets the source of generated maps. This is required for anything to happen. Must implement {{IMapProvider}}, with {{GoogleMapsProvider}} currently the only one available
- __Center__ sets where the map should be centred, must be of type Coordinate. Optional, and shouldn't be used with __EncodedPolyline__
- __EncodedPolyline__ displays an [encoded polyline](https://developers.google.com/maps/documentation/utilities/polylinealgorithm) on the map, shouldn't be used with __Center__

The height and width of the supplied static image are inferred automatically from the size of the control.

## Supported Providers
Currently, only GoogleMaps is supported, using the GoogleMapsProvider.
