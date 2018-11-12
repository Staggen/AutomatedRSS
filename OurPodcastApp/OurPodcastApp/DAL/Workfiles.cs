using System.IO;
using System.Windows.Forms;

namespace OurPodcastApp {
    class Workfiles {
        public enum Files {
            ConfigFile,
            FeedFile,
            GenreFile
        }

        public static string[] WorkFiles = {
            @"TeamN2037\Config.txt",
            @"TeamN2037\FeedFile.txt",
            @"TeamN2037\Genres.txt"
        };

        public static string GetFile(Files name) {
            return WorkFiles[(int)name];
        }

        public static void ClearFile(string filePath) {
            using (var stream = new FileStream(filePath, FileMode.Truncate, FileAccess.Write)) {
                // This makes the opened file contain 0 bytes of data, i.e nothing, effectively clearing the file.
            }
        }

        public static void CheckOrCreateWorkFiles() {
            var total = WorkFiles.Length;
            string conclusion = "";
            for (int i = 0; i < total; i++) {
                var fileName = GetFile((Files)i);
                var fileEnum = ((Files)i);
                if (!Validation.IsFileWritten(fileName)) {
                    switch (fileEnum) {
                        case Files.ConfigFile:
                            CreateConfig();
                            break;
                        case Files.FeedFile:
                            File.Create(fileName);
                            break;
                        case Files.GenreFile:
                            Genre.CreateGenres();
                            break;
                    }
                    conclusion += "Created and loaded the file '" + fileName + "'\n";
                } else {
                    conclusion += "The file '" + fileName + "' loaded correctly.\n";
                }
            }
            MessageBox.Show(conclusion);
        }

        public static void CreateConfig() {
            string filePath = GetFile(Files.ConfigFile);
            if (!File.Exists(filePath)) {
                Serializer.Serialize(filePath, Workfolders.WorkFolders);
            }
        }
    }
}