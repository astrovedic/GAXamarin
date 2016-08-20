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

```
CrossGAXamarin.Current.TrackUser("userId");
```

You only need to set User ID on a tracker once. By setting it on the tracker, the ID will be sent with all subsequent hits.

**TrackScreen(string screenName, int dimensionIndex = 0, string dimensionValue = null, int metricIndex = 0, float metricValue = 0f)**

```
CrossGAXamarin.Current.TrackScreen("Main Screen", 1, "Male"); // Gender is a pre-defined custom dimension
```

@param ScreenName The name of an application screen.
            
**Screens** 

In Google Analytics represent content users are viewing within your app. Measuring screen views allows you to see which content is being viewed most by your users, and how they are navigating between different pieces of content.

**Custom dimension** 

Custom dimension values can be sent with any Google Analytics hit type, including screen views, events and user timings. The defined scope of the custom dimension will determine, at processing time, which hits are associated with the dimension value.

* If you store the gender of signed-in users in a CRM system, you could combine this information with your Analytics data to see Pageviews by gender.

**Custom metric** 

Custom metric values are aggregated in reports just like other pre-defined metrics in Google Analytics.

* If you're a game developer, metrics like "level completions" or "high score" may be more relevant to you than pre-defined metrics like Screenviews. By tracking this data with custom metrics, you can track progress against your most important metrics in flexible and easy-to-read custom reports.

**Scope** 

Determines which hits will be associated with a particular custom dimension value. There are four levels of scope: product, hit, session, and user:

* Product – value is applied to the product for which it has been set (Enhanced Ecommerce only).
* Hit – value is applied to the single hit for which it has been set.
* Session – value is applied to all hits in a single session.
* User – value is applied to all hits in current and future sessions, until value changes or custom dimension is made inactive.

**TrackEvent(string eventCategory, string eventAction, string eventLabel = "AppEvent", int dimensionIndex = 0, string dimensionValue = null, int metricIndex = 0, float metricValue = 0f)**

```
CrossGAXamarin.Current.TrackEvent("Screen Lifecycle", "OnAppearing");
```

@params EventCategory, EventAction completely upon requirements.

Events are a useful way to collect data about a user's interaction with interactive components of your app, like button presses or the use of a particular item in a game.

**TrackTime(string timingCategory, string timingName, long timingInterval, string timingLabel = "AppSpeed", int dimensionIndex = 0, string dimensionValue = null, int metricIndex = 0, float metricValue = 0f)**

```
CrossGAXamarin.Current.TrackTime("Mapping", "GetTimeTypes", 200);
```

@params TimingCategory, TimingName completely upon requirements.
@param TimingInterval the time it takes to load a resource.

Measuring user timings provides a native way to measure a period of time in Google Analytics. This can be useful to measure resource load times.

User timing data can be found primarily in the App Speed User Timings report.

**TrackException(string exceptionMessage, bool isFatal)**

```
CrossGAXamarin.Current.TrackException("Java.Net.SocketClosed", true);
```

Crash and exception measurement allows you to measure the number and type of caught and uncaught crashes and exceptions that occur in your app.

Uncaught exceptions represent instances where your app encountered unexpected conditions at runtime and are often fatal, causing the app to crash. Uncaught exceptions are sent to Google Analytics automatically by setting the TrackUncaughtExceptions configuration value to true.

##### Documentation

https://analytics.google.com

https://developers.google.com/analytics/devguides/collection/

**Android**

https://developers.google.com/analytics/devguides/collection/android/v4/

**iOS**

https://developers.google.com/analytics/devguides/collection/ios/v3/

**Create and edit Custom Dimensions and Metrics**

https://support.google.com/analytics/answer/2709829?hl=en&ref_topic=2709827

**Scope**

https://support.google.com/analytics/answer/2709828#scope

**Google Analytics SDK for Windows**

https://googleanalyticssdk.codeplex.com/

#### Contributors
* [alexrainman](https://github.com/alexrainman)

Thanks!

#### License
Licensed under repo license
