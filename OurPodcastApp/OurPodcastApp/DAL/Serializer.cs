using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace OurPodcastApp {
    class Serializer {
        public static void Serialize(string path, string[] content) {
            using (var stream = new FileStream(path, FileMode.Append, FileAccess.Write)) {
                using (var writer = new StreamWriter(stream)) {
                    foreach (var item in content) {
                        writer.Write(item + "|");
                    }
                    writer.Close();
                }
            }
        }

        public static void Serialize(string path, string addedContent) {
            using (var stream = new FileStream(path, FileMode.Append, FileAccess.Write)) {
                using (var writer = new StreamWriter(stream)) {
                    writer.Write(addedContent + "|");
                    writer.Close();
                }
            }
        }

        public static string[] Deserialize(string path) {
            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read)) {
                using (var reader = new StreamReader(stream)) {
                    var content = reader.ReadToEnd();
                    reader.Close();
                    return content.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                }
            }
        }

        public static string SerializeList(string[] content) {
            return string.Join("`", content);
        }

        public static List<ListViewItem> DeserializeList(string[] content) {
            var listTuple = new List<string[]>();
            var listItemTuple = new List<ListViewItem>();
            foreach (var item in content) {
                listTuple.Add(item.Split(new char[] { '`' }, StringSplitOptions.RemoveEmptyEntries));
            }
            foreach (var item in listTuple) {
                listItemTuple.Add(new ListViewItem(item));
            }
            return listItemTuple;
        }
    }
}