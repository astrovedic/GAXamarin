using Plugin.GAXamarin.Abstractions;
using System;
using System.Threading.Tasks;
#if WINDOWS_PHONE
using System.Windows;
#else
using Windows.UI.Xaml;
#endif

namespace Plugin.GAXamarin
{
  /// <summary>
  /// Implementation for Feature
  /// </summary>
  public class GAXamarinImplementation : IGAXamarin
  {
        public static void Init(string trackingId, int localDispatchPeriod = 0, bool trackUncaughtExceptions = true)
        {
            var config = new GoogleAnalytics.EasyTrackerConfig();

            config.TrackingId = trackingId;
            config.DispatchPeriod = new TimeSpan(localDispatchPeriod * 1000);
            config.ReportUncaughtExceptions = false;

			if (trackUncaughtExceptions)
			{
#if WINDOWS_PHONE
                Application.Current.UnhandledException += (sender, e) =>
				{
                    var ex = e.ExceptionObject;
                    TrackUnhandledException(ex);
				};
#else
                Application.Current.UnhandledException += (sender, e) =>
                {
                    var ex = e.Exception;
                    TrackUnhandledException(ex);
                };
#endif

                TaskScheduler.UnobservedTaskException += (sender, e) =>
				{
					var ex = e.Exception;
					TrackUnhandledException(ex);
				};
			}

            GoogleAnalytics.EasyTracker.Current.Config = config;
        }

        public void TrackUser(string userId)
        {
            GoogleAnalytics.EasyTracker.GetTracker().UserId = userId;
        }

        public void TrackScreen(string screenName, int dimensionIndex = 0, string dimensionValue = null,
            int metricIndex = 0, float metricValue = 0)
        {
            if (dimensionIndex > 0 && !string.IsNullOrEmpty(dimensionValue))
                GoogleAnalytics.EasyTracker.GetTracker().SetCustomDimension(dimensionIndex, dimensionValue);

            if (metricIndex > 0)
                GoogleAnalytics.EasyTracker.GetTracker().SetCustomMetric(metricIndex, (long)metricValue);

            GoogleAnalytics.EasyTracker.GetTracker().SendView(screenName);
        }

        public void TrackEvent(string eventCategory, string eventAction, string eventLabel = "AppEvent",
            int dimensionIndex = 0, string dimensionValue = null,
            int metricIndex = 0, float metricValue = 0)
        {
            if (dimensionIndex > 0 && !string.IsNullOrEmpty(dimensionValue))
                GoogleAnalytics.EasyTracker.GetTracker().SetCustomDimension(dimensionIndex, dimensionValue);

            if (metricIndex > 0)
                GoogleAnalytics.EasyTracker.GetTracker().SetCustomMetric(metricIndex, (long)metricValue);

            GoogleAnalytics.EasyTracker.GetTracker().SendEvent(eventCategory, eventAction, eventLabel, 0);
        }

        public void TrackTime(string timingCategory, string timingName, long timingInterval, string timinglabel = "AppSpeed",
            int dimensionIndex = 0, string dimensionValue = null,
            int metricIndex = 0, float metricValue = 0)
        {
            if (dimensionIndex > 0 && !string.IsNullOrEmpty(dimensionValue))
                GoogleAnalytics.EasyTracker.GetTracker().SetCustomDimension(dimensionIndex, dimensionValue);

            if (metricIndex > 0)
                GoogleAnalytics.EasyTracker.GetTracker().SetCustomMetric(metricIndex, (long)metricValue);

            GoogleAnalytics.EasyTracker.GetTracker().SendTiming(new TimeSpan(timingInterval), timingCategory, timingName, timinglabel);
        }

        public void TrackException(string exceptionMessage, bool isFatal)
        {
            GoogleAnalytics.EasyTracker.GetTracker().SendException(exceptionMessage, isFatal);
        }

		public static void TrackUnhandledException(Exception ex)
		{
			GoogleAnalytics.EasyTracker.GetTracker().SendEvent("Crashes", ex.Message, ex.ToString(), 0);
		}
    }
}