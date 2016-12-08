using Plugin.GAXamarin.Abstractions;
using System;
using Android.Gms.Analytics;
using Android.Content;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Linq;
using Android.Runtime;

namespace Plugin.GAXamarin
{
	/// <summary>
	/// Implementation for Feature
	/// </summary>
	public class GAXamarinImplementation : IGAXamarin
	{
		public static GoogleAnalytics GAInstance;
		public static Tracker GATracker;

		public static void Init(Context context, string trackingId, int localDispatchPeriod = 1800, bool trackUncaughtExceptions = true, bool enableAutoActivityTracking = false)
		{
			GAInstance = GoogleAnalytics.GetInstance(context);
			GAInstance.SetLocalDispatchPeriod(localDispatchPeriod);

			GATracker = GAInstance.NewTracker(trackingId);

			GATracker.EnableExceptionReporting(false);

			GATracker.EnableAutoActivityTracking(enableAutoActivityTracking);

			if (trackUncaughtExceptions)
			{
				AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
				{
					var ex = (Exception)e.ExceptionObject;
					TrackUnhandledException(ex);
				};

				TaskScheduler.UnobservedTaskException += (sender, e) =>
				{
					var ex = e.Exception;
					TrackUnhandledException(ex);
				};
			}
		}

		public void TrackUser(string userId)
		{
			GATracker.Set("&uid", userId);
		}

		public void TrackScreen(string screenName, int dimensionIndex = 0, string dimensionValue = null,
								int metricIndex = 0, float metricValue = 0f)
		{
			var builder = new HitBuilders.ScreenViewBuilder();

			if (dimensionIndex > 0 && !string.IsNullOrEmpty(dimensionValue))
				builder.SetCustomDimension(dimensionIndex, dimensionValue);

			if (metricIndex > 0)
				builder.SetCustomMetric(metricIndex, metricValue);

			GATracker.SetScreenName(screenName);
			GATracker.Send(builder.Build());
		}

		public void TrackEvent(string eventCategory, string eventAction, string eventLabel = "AppEvent",
							   int dimensionIndex = 0, string dimensionValue = null,
							   int metricIndex = 0, float metricValue = 0f)
		{
			var builder = new HitBuilders.EventBuilder();

			if (dimensionIndex > 0 && !string.IsNullOrEmpty(dimensionValue))
				builder.SetCustomDimension(dimensionIndex, dimensionValue);

			if (metricIndex > 0)
				builder.SetCustomMetric(metricIndex, metricValue);

			builder.SetCategory(eventCategory);
			builder.SetAction(eventAction);
			builder.SetLabel(eventLabel);

			GATracker.Send(builder.Build());
		}

		public void TrackTime(string timingCategory, string timingName, long timingInterval, string timingLabel = "AppSpeed",
							  int dimensionIndex = 0, string dimensionValue = null,
							  int metricIndex = 0, float metricValue = 0f)
		{
			var builder = new HitBuilders.TimingBuilder();

			if (dimensionIndex > 0 && !string.IsNullOrEmpty(dimensionValue))
				builder.SetCustomDimension(dimensionIndex, dimensionValue);

			if (metricIndex > 0)
				builder.SetCustomMetric(metricIndex, metricValue);

			builder.SetCategory(timingCategory);
			builder.SetVariable(timingName);
			builder.SetLabel(timingLabel);

			builder.SetValue(timingInterval);

			GATracker.Send(builder.Build());
		}

		public void TrackException(string exceptionMessage, bool isFatal)
		{
			var builder = new HitBuilders.ExceptionBuilder();
			builder.SetDescription(exceptionMessage);
			builder.SetFatal(isFatal);

			GATracker.Send(builder.Build());
		}

		public static void TrackUnhandledException(Exception ex)
		{
			var builder = new HitBuilders.EventBuilder();

			builder.SetCategory("Crashes");
			builder.SetAction(ex.Message);
			builder.SetLabel(ex.ToString());

			GATracker.Send(builder.Build());
		}
	}
}