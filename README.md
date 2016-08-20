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

TrackUser(string userId)

```
CrossGAXamarin.Current.TrackUser("userId");
```

#### Contributors
* [alexrainman](https://github.com/alexrainman)

Thanks!

#### License
Licensed under repo license
