using System.IO;
using System.Windows.Forms;

namespace OurPodcastApp {
    class Workfolders {
        public enum Folders {
            TeamN2037,
            SavePodData
        }

        public static string[] WorkFolders = {
            @"TeamN2037\",
            @"TeamN2037\SavePodData\"
        };

        public static string GetFolder(Folders name) {
            return WorkFolders[(int)name];
        }

        public static void CheckOrCreateWorkspaceFolders() {
            var total = WorkFolders.Length;
            string conclusion = "";
            for (int i = 0; i < total; i++) {
                var dirName = GetFolder((Folders)i);
                var folderEnum = ((Folders)i);
                if (!Validation.IsDirectory(dirName)) {
                    switch (folderEnum) {
                        case Folders.TeamN2037:
                            Directory.CreateDirectory(dirName);
                            Workfiles.CreateConfig();
                            break;
                        case Folders.SavePodData:
                            Directory.CreateDirectory(dirName);
                            break;
                    }
                    conclusion += "Created and loaded the directory '" + dirName + "'\n";
                } else {
                    conclusion += "The directory '" + dirName + "' loaded correctly.\n";
                }
            }
            MessageBox.Show(conclusion);            
        }
    }
}