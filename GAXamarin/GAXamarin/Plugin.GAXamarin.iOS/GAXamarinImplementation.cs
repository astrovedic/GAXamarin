using Plugin.GAXamarin.Abstractions;
using System;
using Google.Analytics;

namespace Plugin.GAXamarin
{
  /// <summary>
  /// Implementation for GAXamarin
  /// </summary>
  public class GAXamarinImplementation : IGAXamarin
  {
        public static ITracker Tracker;

        public static void Init(string trackingId, int localDispatchPeriod = 20)
        {
            Gai.SharedInstance.DispatchInterval = localDispatchPeriod;
            Gai.SharedInstance.TrackUncaughtExceptions = true;

            Tracker = Gai.SharedInstance.GetTracker(trackingId);
        }

        public void TrackUser(string userId)
        {
            Gai.SharedInstance.DefaultTracker.Set(GaiConstants.UserId, userId);
        }

        public void TrackScreen(string screenName, int dimensionIndex = 0, string dimensionValue = null,
                                int metricIndex = 0, float metricValue = 0f)
        {
            if (dimensionIndex > 0 && !string.IsNullOrEmpty(dimensionValue))
                Gai.SharedInstance.DefaultTracker.Set(Fields.CustomDimension((nuint)dimensionIndex), dimensionValue);

            if (metricIndex > 0)
                Gai.SharedInstance.DefaultTracker.Set(Fields.CustomMetric((nuint)metricIndex), metricValue.ToString());

            Gai.SharedInstance.DefaultTracker.Set(GaiConstants.ScreenName, screenName);
            Gai.SharedInstance.DefaultTracker.Send(DictionaryBuilder.CreateScreenView().Build());
        }

        public void TrackEvent(string eventCategory, string eventAction, string eventLabel = "AppEvent",
                               int dimensionIndex = 0, string dimensionValue = null,
                               int metricIndex = 0, float metricValue = 0f)
        {
            if (dimensionIndex > 0 && !string.IsNullOrEmpty(dimensionValue))
                Gai.SharedInstance.DefaultTracker.Set(Fields.CustomDimension((nuint)dimensionIndex), dimensionValue);

            if (metricIndex > 0)
                Gai.SharedInstance.DefaultTracker.Set(Fields.CustomMetric((nuint)metricIndex), metricValue.ToString());

            Gai.SharedInstance.DefaultTracker.Send(DictionaryBuilder.CreateEvent(eventCategory, eventAction, eventLabel, null).Build());
            Gai.SharedInstance.Dispatch();
        }

        public void TrackTime(string timingCategory, string timingName, long timingInterval, string timingLabel = "AppSpeed",
                              int dimensionIndex = 0, string dimensionValue = null,
                              int metricIndex = 0, float metricValue = 0f)
        {
            if (dimensionIndex > 0 && !string.IsNullOrEmpty(dimensionValue))
                Gai.SharedInstance.DefaultTracker.Set(Fields.CustomDimension((nuint)dimensionIndex), dimensionValue);

            if (metricIndex > 0)
                Gai.SharedInstance.DefaultTracker.Set(Fields.CustomMetric((nuint)metricIndex), metricValue.ToString());

            Gai.SharedInstance.DefaultTracker.Send(DictionaryBuilder.CreateTiming(timingCategory, timingInterval, timingName, timingLabel).Build());
        }

        public void TrackException(string exceptionMessage, bool isFatal)
        {
            Gai.SharedInstance.DefaultTracker.Send(DictionaryBuilder.CreateException(exceptionMessage, isFatal).Build());
        }
    }
}