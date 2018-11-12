using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;

namespace OurPodcastApp {
    class EntityLogicLayer {
        private static FeedList PersistentFeedList = new FeedList(); // Center point of the program
        private static FeedList FilteredFeedList = new FeedList(); // FilteredFeedList is used as the part of PersistentFeedList that matches the currently selected Genre

        public static string[] GetAllPersistentFeedListURLs() { // Get all PersistentFeedList URLs
            string[] allFeedURLs = new string[PersistentFeedList.Count];
            int counter = 0;
            foreach (Feed item in PersistentFeedList) {
                allFeedURLs[counter] = item.FeedURL;
                counter++;
            }
            return allFeedURLs;
        }

        public static void UpdateItemFrequencyFromPersistent(int selectedFeed, string newUpdateFrequency) {
            PersistentFeedList[selectedFeed].UpdateFrequency = newUpdateFrequency; // Updates a specific Feed item's UpdateFrequency
        }

        public static void UpdateItemGenreFromPersistent(int selectedFeed, string newGenre) {
            PersistentFeedList[selectedFeed].Genre = newGenre; // Update a specific FeedItem's Genre
        }

        public static void SetFilteredFeedList(string inputGenre) { // Set the FilteredFeedList as PersistentFeedList filtered by currently selected Genre
            FilteredFeedList.Clear(); 
            foreach(Feed item in PersistentFeedList) {
                if(item.Genre == inputGenre) {
                    FilteredFeedList.Add(item);
                }
            }
        }

        public static EpisodeList GetEpisodesFromPersistent(int lvMainSelected) {
            return PersistentFeedList[lvMainSelected].Episodes; // Get an EpisodeList from PersistentFeedList rather than making continuous unneccessary disk operations 
        }

        public static string GetEpisodeDescriptionFromPersistent(int lvMainSelected, int lbxEpisodesSelected) {
            return PersistentFeedList[lvMainSelected].Episodes[lbxEpisodesSelected].Description; // Get the description of a specific feed's specific episode 
        }

        public static void DeleteFeedItemFromPersistent(int selectedIndex) {
            string filePath = XmlTools.GetFeedXmlFilePath(PersistentFeedList[selectedIndex].Title);
            PersistentFeedList.Remove(PersistentFeedList[selectedIndex]); // Removes the Feed item from PersistentFeedList
            XmlTools.DeleteLocalXMLFile(filePath); // Removes the physical .xml file from the harddrive
        }

        public static List<ListViewItem> SetPersistentFeedListToLvMain() {
            List<ListViewItem> list = new List<ListViewItem>();
            foreach (Feed item in PersistentFeedList) {
                ListViewItem listItem = Converter.FeedToLVI(item); // Converts Feed to ListViewItem
                list.Add(listItem);
            }
            return list;
        }

        public static List<ListViewItem> SetFilteredFeedListToLvMain() {
            List<ListViewItem> list = new List<ListViewItem>();
            foreach (Feed item in FilteredFeedList) {
                ListViewItem listItem = Converter.FeedToLVI(item); // Converts Feed to ListViewItem
                list.Add(listItem);
            }
            return list;
        }

        public static void SetPersistentFeedListToSaveFile() { // Save the persistent feed list to the feed file
            string[] entireFeed = new string[PersistentFeedList.Count]; // Holding array for the entire feed
            for (int i = 0; i < PersistentFeedList.Count; i++) {
                string[] singleItem = Converter.FeedToSA(PersistentFeedList[i]); // Run through the items in the list of feeds
                string serializedItem = Serializer.SerializeList(singleItem); // Write the individual ListViewItem string arrays into a single serialized item
                entireFeed[i] = serializedItem; // Add the item to the holding array
            }
            Workfiles.ClearFile(Workfiles.GetFile(Workfiles.Files.FeedFile)); // Clear the FeedFile
            Serializer.Serialize(Workfiles.GetFile(Workfiles.Files.FeedFile), entireFeed); // Write entireFeed to the feed file
        }

        public static void GetPersistentFeedListFromSaveFile() {
            string[] singleItem = Serializer.Deserialize(Workfiles.GetFile(Workfiles.Files.FeedFile));
            List<ListViewItem> listItems = Serializer.DeserializeList(singleItem); // Deserialize the feed file (where we save the things that are to be put into the list view items)
            PersistentFeedList.Clear(); // Clear out the persistent feed list
            foreach (ListViewItem item in listItems) { // Go through all the newly created ListViewItems
                Feed feedItem = Converter.LVIToFeed(item); // Convert ListViewItems to Feed objects
                feedItem.Episodes = GetEpisodes(feedItem.Title); // Assign the EpisodeList field on the Feed objects
                PersistentFeedList.Add(feedItem); // Add the feed objects to the persistent feed list
            }
        }

        public static int GetEpisodeCount(string path) {
            return XmlTools.GetEpisodeInfo(path).Count; // Can be both local and external path (web request)
        }

        public static EpisodeList GetEpisodes(string feedTitle) {
            EpisodeList episodeList = new EpisodeList();
            string fileName = Converter.FeedTitleToLegalFilename(feedTitle); // Modify the feedTitle to a filesystem-legal title. We remove all the characters that are not allowed in file names.
            string feedPath = Workfolders.GetFolder(Workfolders.Folders.SavePodData) + fileName;
            int numberOfEpisodes = GetEpisodeCount(feedPath); // Gets the number of episodes in a specific feed
            string[] myKeys = new string[numberOfEpisodes];
            string[] myValues = new string[numberOfEpisodes];
            Dictionary<string, string> episodeDictionary = XmlTools.GetEpisodeInfo(feedPath); // Get a dictionary filled with all the episode titles and corresponding descriptions.
            episodeDictionary.Keys.CopyTo(myKeys, 0); // Required to access the keys by position
            episodeDictionary.Values.CopyTo(myValues, 0); // Required to access the values by position
            for (int i = 0; i < numberOfEpisodes; i++) {
                episodeList.Add(new Episode { Title = myKeys[i], Description = myValues[i] }); // Making new objects of Episode containing the Title and Description of episodes
            }
            return episodeList;
        }

        public static void GenerateNewFeed(string feedURL, string updateFrequency, string genre) {
            XmlDocument myRSSFeed = XmlTools.GetXmlDocument(feedURL); // !WebRequest! GetXmlDocument returns a xml document loaded with whatever was returned from the URL passed into the method
            if (Validation.IsValidXML(myRSSFeed)) { // If the XmlDocument is a real RSS feed
                string feedTitle = myRSSFeed.SelectSingleNode("//rss/channel/title").InnerText; // Get feedTitle
                XmlTools.SaveFeedToFile(feedURL, feedTitle); // Saves the RSS feed to a local xml file
                string filePath = XmlTools.GetFeedXmlFilePath(feedTitle);
                PersistentFeedList.Add(new Feed { // Return a new Feed object
                    EpisodeCount = GetEpisodeCount(filePath),
                    Title = feedTitle,
                    UpdateFrequency = updateFrequency,
                    Genre = genre,
                    FeedURL = feedURL,
                    LastCheckForUpdates = DateTime.Now.ToUniversalTime(),
                    Episodes = GetEpisodes(feedTitle)
                });
            }
        }

        public static bool CheckForUpdates() { // USE AS ASYNCHRONOUS TASK
            bool wasUpdated = false;
            bool[] updateTimeExpired = Updater.CheckForUpdates(PersistentFeedList); // Get list of bools indicating whether timestamp of last check for updates + the update frequency is LESS than current time
            for (int i = 0; i < PersistentFeedList.Count; i++) { // Go through the persistent feed list
                if (updateTimeExpired[i] == true) { // If the last time it checked for updates + the items update frequency is < current time
                    wasUpdated = true;
                    string feedURL = PersistentFeedList[i].FeedURL; // Get the URL for the item
                    string feedTitle = PersistentFeedList[i].Title;
                    // Re-fetch the entire XML file with all the episodes and their descriptions
                    XmlTools.SaveFeedToFile(feedURL, feedTitle); // !Web-Request!
                    // Update the Feed items EpisodeCount and Episodes properties
                    PersistentFeedList[i].EpisodeCount = GetEpisodeCount(XmlTools.GetFeedXmlFilePath(feedTitle));
                    PersistentFeedList[i].Episodes = GetEpisodes(feedTitle);
                    PersistentFeedList[i].LastCheckForUpdates = DateTime.Now.ToUniversalTime(); // Give the Feed item a new timestamp
                }
            }
            return wasUpdated;
        }
    }
}