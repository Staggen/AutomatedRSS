using System;
using System.IO;
using System.Linq;
using System.Xml;

namespace OurPodcastApp {
    class Validation {
        public static bool IsDuplicate(string newContent, string[] content) {
            return content.Any((g) => String.Equals(g, newContent, StringComparison.OrdinalIgnoreCase));
        }

        public static bool IsFileWritten(string filePath) {
            return File.Exists(filePath);
        }

        public static bool IsDirectory(string dirPath) {
            return Directory.Exists(dirPath);
        }

        public static bool IsValidURL(string URL) {
            return URL.StartsWith("https://") || URL.StartsWith("http://") ? true : false;
        }

        public static bool IsValidXML(XmlDocument myDocument) {
            return String.Equals(myDocument.ChildNodes[0].Name, "rss", StringComparison.OrdinalIgnoreCase);
        }
    }
}
