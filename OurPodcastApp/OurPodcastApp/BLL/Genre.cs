using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace OurPodcastApp {
    public class Genre : Entity {
        private static readonly string GenresPath = Workfolders.GetFolder(
            Workfolders.Folders.TeamN2037) + "genres.txt";

        private static readonly string[] DefaultGenres = {
            @"All genres",
            @"Action",
            @"Comedy",
            @"Social Commentary",
            @"Talk Show"
        };

        public static string GetGenrePath() {
            return GenresPath;
        }

        public static void CreateGenres() {
            if (!File.Exists(GenresPath)) {
                Serializer.Serialize(GenresPath, DefaultGenres);
            }
        }

        public static string[] ReadGenres() {
            return Serializer.Deserialize(GenresPath);
        }

        public static void AddGenre(string newGen) {
            try {
                if (!Validation.IsDuplicate(newGen, ReadGenres())) {
                    Serializer.Serialize(GenresPath, newGen);
                } else {
                    throw new GenreException("A genre with this name already exists!");
                }
            } catch (GenreException ex) {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        public static string[] UpdateGenreFile(ListBox lbxGenre) {
            // Creates a new List of strings to hold all the items in the ListBox.
            List<string> currentGenres = new List<string>();
            // Iterates through the items in the ListBox and adds them to the List of strings.
            foreach (var item in lbxGenre.Items) {
                currentGenres.Add(item.ToString());
            }
            // Sends the genre.txt file and the List of strings (as an array) to the serializer to update the file.
            Serializer.Serialize(GenresPath, currentGenres.ToArray());
            // Also returns the string array for use in other methods.
            return currentGenres.ToArray();
        }

        public static void DeleteGenre(ListBox genreBox) {
            genreBox.Items.Remove(genreBox.SelectedItem); // Removes the list box item;
        }

        public override string EntityType() {
            return "A genre.\n";
        }
    }
}