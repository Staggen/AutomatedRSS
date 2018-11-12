using System;

namespace OurPodcastApp {
    public class Updater {
        public static bool[] CheckForUpdates(FeedList feedList) {
            // Returns a list of bools indicating whether the last timestamp + update frequency is LESS than current time
            bool[] updates = new bool[feedList.Count];
            int counter = 0;
            foreach (Feed item in feedList) {
                updates[counter] = CompareTimestamps(item);
                counter++;
            }
            return updates;
        }

        public static bool CompareTimestamps(Feed item) {
            // Checks if timestamp + update frequency is LESS than current time
            switch (item.UpdateFrequency) {
                case "Ten minutes":
                    return item.LastCheckForUpdates.AddMinutes(10) < DateTime.Now.ToUniversalTime();
                case "One hour":
                    return item.LastCheckForUpdates.AddHours(1) < DateTime.Now.ToUniversalTime();
                case "One day":
                    return item.LastCheckForUpdates.AddDays(1) < DateTime.Now.ToUniversalTime();
                case "One week":
                    return item.LastCheckForUpdates.AddDays(7) < DateTime.Now.ToUniversalTime();
                case "One month":
                    return item.LastCheckForUpdates.AddMonths(1) < DateTime.Now.ToUniversalTime();
                default: // This shouldn't be able to happen
                    return false;
            }
        }
    }
}