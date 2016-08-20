using System;

namespace Plugin.GAXamarin.Abstractions
{
  /// <summary>
  /// Interface for GAXamarin
  /// </summary>
  public interface IGAXamarin
  {
        /*
         * You only need to set User ID on a tracker once.
         * By setting it on the tracker, the ID will be sent with all subsequent hits
         */
        void TrackUser(string userId);

        /*
         * @param ScreenName The name of an application screen.
         */
        void TrackScreen(string screenName, int dimensionIndex = 0, string dimensionValue = null,
                         int metricIndex = 0, float metricValue = 0f);

        /*
         * @param EventCategory completely upon requirements.
         */
        void TrackEvent(string eventCategory, string eventAction, string eventLabel = "AppEvent",
                        int dimensionIndex = 0, string dimensionValue = null,
                        int metricIndex = 0, float metricValue = 0f);

        /*
		 * @params TimingCategory, TimingName completely upon requirements.
         * @param TimingInterval The time it takes to load a resource.
         */
        void TrackTime(string timingCategory, string timingName, long timingInterval, string timingLabel = "AppSpeed",
                      int dimensionIndex = 0, string dimensionValue = null,
                      int metricIndex = 0, float metricValue = 0f);

        void TrackException(string exceptionMessage, bool isFatal);
    }
}
