using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace OurPodcastApp {
    class Converter {
        public static string FeedTitleToLegalFilename(string feedTitle) {
            string legalTitle = Regex.Replace(feedTitle, @"[/:*|\\<>?]+", ""); // Rename the title to something that only contains legal file characters
            return legalTitle + ".xml";
        }

        public static Feed LVIToFeed(ListViewItem lvItem) {
            if (Int32.TryParse(lvItem.SubItems[0].Text, out int tempCount) && DateTime.TryParse(lvItem.SubItems[5].Text, out DateTime tempDate)) {
                return new Feed {
                    EpisodeCount = tempCount,
                    Title = lvItem.SubItems[1].Text,
                    UpdateFrequency = lvItem.SubItems[2].Text,
                    Genre = lvItem.SubItems[3].Text,
                    FeedURL = lvItem.SubItems[4].Text,
                    LastCheckForUpdates = tempDate
                };
            } else {
                throw new FormatException("ListViewItem in incorrect format, failure to convert appropriately!");
            }
        }

        public static string[] FeedToSA(Feed feed) {
            return new string[] {
                feed.EpisodeCount.ToString(),
                feed.Title,
                feed.UpdateFrequency,
                feed.Genre,
                feed.FeedURL,
                feed.LastCheckForUpdates.ToString()
            };
        }

        public static ListViewItem FeedToLVI(Feed feed) {
            string[] array = new string[] {
                feed.EpisodeCount.ToString(),
                feed.Title,
                feed.UpdateFrequency,
                feed.Genre,
                feed.FeedURL,
                feed.LastCheckForUpdates.ToString()
            };
            return new ListViewItem(array);
        }
    }
}
