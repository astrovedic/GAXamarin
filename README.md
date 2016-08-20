# GAXamarin

Google Analytics Plugin for Xamarin and Windows

#### Setup
* Available on NuGet: https://www.nuget.org/packages/Plugin.GAXamarin/ [![NuGet](https://img.shields.io/nuget/v/Plugin.GAXamarin.svg?label=NuGet)](https://www.nuget.org/packages/Plugin.GAXamarin/)
* Install in your PCL project and Client projects.

```
//Android
GAXamarinImplementation.Init(this, "XX-XXXXXXXX-X");

//iOS
GAXamarinImplementation.Init("XX-XXXXXXXX-X");

//Windows
GAXamarinImplementation.Init("XX-XXXXXXXX-X");
```

**Requirements**

|Platform|Supported|Version|Component|
| ------------------- | :-----------: | :-----------: | :------------------: |
|Xamarin.iOS Unified|Yes|iOS 8.1+|Google Analytics Component for iOS|
|Xamarin.Android|Yes|API 15+|Google Play Service - Analytics|
|Windows|Yes|8+|Google Analytics SDK 1.3|

#### Usage

**TrackUser(string userId)**

You only need to set User ID on a tracker once. By setting it on the tracker, the ID will be sent with all subsequent hits.

```
CrossGAXamarin.Current.TrackUser("userId");
```

**TrackScreen(string screenName, int dimensionIndex = 0, string dimensionValue = null, int metricIndex = 0, float metricValue = 0f)**

@param ScreenName The name of an application screen.
            
**Screens** in Google Analytics represent content users are viewing within your app. Measuring screen views allows you to see which content is being viewed most by your users, and how they are navigating between different pieces of content.

**Custom dimension** values can be sent with any Google Analytics hit type, including screen views, events and user timings. The defined scope of the custom dimension will determine, at processing time, which hits are associated with the dimension value.

**Custom metric** values are aggregated in reports just like other pre-defined metrics in Google Analytics.

**Scope** determines which hits will be associated with a particular custom dimension value. There are four levels of scope: product, hit, session, and user:

* Product – value is applied to the product for which it has been set (Enhanced Ecommerce only).
* Hit – value is applied to the single hit for which it has been set.
* Session – value is applied to all hits in a single session.
* User – value is applied to all hits in current and future sessions, until value changes or custom dimension is made inactive.

```
CrossGAXamarin.Current.TrackScreen("Main Screen");
```

**TrackEvent(string eventCategory, string eventAction, string eventLabel = "AppEvent", int dimensionIndex = 0, string dimensionValue = null, int metricIndex = 0, float metricValue = 0f)**

@param EventCategory completely upon requirements.

Events are a useful way to collect data about a user's interaction with interactive components of your app, like button presses or the use of a particular item in a game.

|Field Name|Type|Required|Description|
| ------------------- | :-----------: | :-----------: | :------------------: |
|Category|String|Yes|The event category|
|Action|String|Yes|The event action|
|Label|String|No|The event label|
|Value|Long|No|The event value|

```
CrossGAXamarin.Current.TrackEvent("Screen Lifecycle", "OnAppearing");
```

**TrackTime(string timingCategory, string timingName, long timingInterval, string timingLabel = "AppSpeed", int dimensionIndex = 0, string dimensionValue = null, int metricIndex = 0, float metricValue = 0f)**

@params TimingCategory, TimingName completely upon requirements.
@param TimingInterval the time it takes to load a resource.

```
CrossGAXamarin.Current.TrackTime("Mapping", "GetTimeTypes", 200);
```



```
CrossGAXamarin.Current.TrackException("Java.Net.SocketClosed", true);
```

#### Contributors
* [alexrainman](https://github.com/alexrainman)

Thanks!

#### License
Licensed under repo license
