using System.Collections.Generic;
using System.Windows.Forms;

namespace OurPodcastApp {
    class Populate {
        // This class populates the GUI in varying ways
        public static void updateList(ListBox list, List<string> content) {
            list.Items.Clear();
            foreach (var item in content) {
                list.Items.Add(item);
            }
        }

        public static void updateList(ListBox list, string[] content) {
            list.Items.Clear();
            foreach (var item in content) {
                list.Items.Add(item);
            }
        }

        public static void updateList(ListBox list, EpisodeList content) {
            list.Items.Clear();
            foreach (var item in content) {
                list.Items.Add(item.Title);
            }
        }

        public static void updateList(ComboBox box, List<string> content) {
            box.Items.Clear();
            foreach (var item in content) {
                box.Items.Add(item);
            }
        }

        public static void updateList(ComboBox box, string[] content) {
            box.Items.Clear();
            foreach (var item in content) {
                box.Items.Add(item);
            }
        }

        public static void updateList(TextBox box, string content) {
            box.Clear();
            box.Text = content;
        }

        public static void updateListView(ListView view, ListViewItem content) {
            view.Items.Add(content);
        }

        public static void updateListView(ListView view, List<ListViewItem> contents) {
            view.Items.Clear();
            foreach (var item in contents) {
                view.Items.Add(item);
            }
        }

        public static void refreshSelection(ListView lvMain, ListBox lbxGenre, ListBox lbxEpisodes, TextBox tbxDescription, Label lblFeedTitle) {
            int selectedGenre = lbxGenre.SelectedIndex;

            clearBoxes(lbxEpisodes, tbxDescription, lblFeedTitle);
            lvMain.SelectedItems.Clear();
            lbxGenre.ClearSelected();
            
            lbxGenre.SelectedIndex = selectedGenre;
        }

        public static void clearBoxes(ListBox lbxEpisodes, TextBox tbxDescription, Label lblFeedTitle) {
            lbxEpisodes.Items.Clear();
            tbxDescription.Clear();
            lblFeedTitle.Text = "Feed Title: ";
        }
    }
}