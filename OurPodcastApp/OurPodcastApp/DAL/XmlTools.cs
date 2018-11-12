using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;

namespace OurPodcastApp {
    public class XmlTools {
        public static XmlDocument GetXmlDocument(string URL) {
            XmlDocument myDocument = new XmlDocument();
            myDocument.Load(URL); // !Possible Web Request!
            return myDocument;
        }

        public static string GetFeedXmlFilePath(string feedTitle) {
            string fileName = Converter.FeedTitleToLegalFilename(feedTitle);
            return Workfolders.GetFolder(Workfolders.Folders.SavePodData) + fileName;
        }

        public static void SaveFeedToFile(string URL, string feedTitle) {
            XmlDocument document = GetXmlDocument(URL); // Get the document from the URL
            string filePath = GetFeedXmlFilePath(feedTitle); // Get/Generate the filePath for the new file
            if (File.Exists(filePath)) { // If the file already exists, we have to remove and remake it to update it
                File.Delete(filePath);
            }
            document.Save(filePath); // Save the rss file to a local xml document for later use
        }

        public static void DeleteLocalXMLFile(string filePath) {
            if (File.Exists(filePath)) {
                File.Delete(filePath);
            }
        }

        public static Dictionary<string, string> GetEpisodeInfo(string path) {
            Dictionary<string, string> episodeDictionary = new Dictionary<string, string>(); // Make dictionary
            string fixedDescription;
            XmlDocument document = GetXmlDocument(path); // Load the document into a holding variable
            XmlNodeList titles = document.SelectNodes("//rss/channel/item/title"); // List of XML nodes matching selector
            XmlNodeList descriptions = document.SelectNodes("//rss/channel/item/description"); // --||--
            for (int i = 0; i < titles.Count; i++) { // titles and descriptions SHOULD be equally long
                fixedDescription = Regex.Replace(descriptions[i].InnerText,@"<.*?>",""); // Remove HTML formating
                episodeDictionary.Add(titles[i].InnerText, fixedDescription); // Add titles and descriptions to the dictionary
            }
            return episodeDictionary; // Return dictionary
        }
    }
}