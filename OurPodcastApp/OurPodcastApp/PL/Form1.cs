using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OurPodcastApp {
    public partial class Form1 : Form {
        // Delegate Signature
        public delegate void delUpdatelvMain();
        // Cancellation Token Source
        CancellationTokenSource cts = new CancellationTokenSource(); // To allow timeouts on asynchronous tasks
        // Declaring threads
        ThreadStart threadStart;
        Thread myUpdaterThread;
        // Constructor
        public Form1() {
            InitializeComponent(); // Generate the visual form
        }
        // Form_Load
        private void Form1_Load(object sender, EventArgs e) {
            // Instantiate thread start object and pass in what method it will call
            threadStart = new ThreadStart(StartMyThread);
            myUpdaterThread = new Thread(threadStart);

            Workfiles.CheckOrCreateWorkFiles(); // Check that the work files exist
            Workfolders.CheckOrCreateWorkspaceFolders(); // Check that the work folders exist

            btnNewFeed.Enabled = false; // Disabling all buttons - they will become enabled at appropriate times
            btnSaveFeed.Enabled = false;
            btnDelFeed.Enabled = false;
            btnNewCat.Enabled = false;
            btnSaveCat.Enabled = false;
            btnDelCat.Enabled = false;

            EntityLogicLayer.GetPersistentFeedListFromSaveFile(); // !Disk Operation! Load the FeedFile.txt into the persistent Feed variable
            List<ListViewItem> myListView = EntityLogicLayer.SetPersistentFeedListToLvMain();
            Populate.updateListView(lvMain, myListView);

            lvMain.FullRowSelect = true; // Make the selector cover the full row

            string[] listOfGenres = Genre.ReadGenres(); // !Disk operation!
            Populate.updateList(lbxGenre, listOfGenres); // Add the list of genres to the list box
            Populate.updateList(cbxGenre, listOfGenres); // Add the list of genres to the combo box
            cbxGenre.Items.RemoveAt(0); // Remove "All Genres" from the combo box
            string[] listOfFrequencies = Frequencies.ReadFrequencies(); // No longer disk operation
            Populate.updateList(cbxUpFreq, listOfFrequencies); // Add the list of frequencies to the combo box

            myUpdaterThread.Start(); // Start the update-wannabe-daemon
        } // No space between method declarations in our coding standard means that they are directly connected to the method above
        private void StartMyThread() {
            delUpdatelvMain DelUpdateListView = new delUpdatelvMain(UpdatelvMain);
            while (true) {
                this.lvMain.BeginInvoke(DelUpdateListView); 
                Thread.Sleep(60000); // Sleeps the thread for 1 minute
            }
        } // No space between method declarations in our coding standard means that they are directly connected to the method above
        public void UpdatelvMain() {
            if (EntityLogicLayer.CheckForUpdates()) { // !Web Request! Checks if there are updates for the RSS feeds. If there are, it returns true and removes the current saved XML file and fetches a new one, updating everything accordingly.
                List<ListViewItem> persistentFeed = EntityLogicLayer.SetPersistentFeedListToLvMain(); // Get the persistent Feed variable as a List<ListViewItem>
                Populate.updateListView(lvMain, persistentFeed); // Loop through all the items in the List<ListViewItem>, and then adds them to the ListView lvMain
                EntityLogicLayer.SetPersistentFeedListToSaveFile(); // Update the FeedFile.txt (episode count)
                MessageBox.Show("Main ListView has been checked for updates, and if there were any it has updated the ListView accordingly.");
            }
        }

        // Onclick Event(s)
        private void btnNewCat_Click(object sender, EventArgs e) {
            Genre.AddGenre(txtGenre.Text); // Add the genre that is in the text field to the list box
            var listOfGenres = Genre.ReadGenres();
            Populate.updateList(lbxGenre, listOfGenres); // Update the contents of the list box
            Populate.updateList(cbxGenre, listOfGenres); // Update the contents of the combo box
            cbxGenre.Items.RemoveAt(0); // Remove the "All Genres" genre from the combo box
            txtGenre.Clear(); // Clear the input field
            txtGenre.Focus(); // Return focus to the input field
        }

        private void btnNewFeed_Click(object sender, EventArgs e) {
            // Adds a new feed in all aspects of save variables, listviews and save files
            if (txtUrl.Text != null && cbxUpFreq.SelectedItem != null && cbxGenre.SelectedItem != null) {
                if (Validation.IsValidURL(txtUrl.Text)) {
                    try {
                        cts.CancelAfter(2500); // Time out (terminate) async operation if it has not completed after 2.5 seconds
                        Task asyncAddingFeed = new Task(() => AddNewFeedToPersistent(cts)); // I MUST make this a new method to be able to pass in a parameter.
                        asyncAddingFeed.Start();
                    } catch (OperationCanceledException) {
                        MessageBox.Show("The web request to add a new feed timed out! (Exceeded 2.5 second response time)");
                    } catch (Exception ex) {
                        MessageBox.Show(ex.Message);
                    }
                } else {
                    MessageBox.Show("Make sure that the URL is correct!");
                }
            } else {
                MessageBox.Show("Make sure you have filled out all fields!");
            }
        }
        private void AddNewFeedToPersistent(CancellationTokenSource ct) {
            string feedURL = txtUrl.Text;
            string[] existingFeedURLs = EntityLogicLayer.GetAllPersistentFeedListURLs();
            if (!Validation.IsDuplicate(feedURL, existingFeedURLs) && Validation.IsValidURL(feedURL)) {
                string updateFrequency = cbxUpFreq.SelectedItem.ToString();
                string genre = cbxGenre.SelectedItem.ToString();
                EntityLogicLayer.GenerateNewFeed(feedURL, updateFrequency, genre); // New feed in ListViewItem format
                List<ListViewItem> mainView = EntityLogicLayer.SetPersistentFeedListToLvMain(); // Returns new listview for lvMain
                Populate.updateListView(lvMain, mainView); // Add the new ListViewItem to the main ListView
                EntityLogicLayer.SetPersistentFeedListToSaveFile(); // Save the persistent feed variable to the FeedFile
                txtUrl.Clear(); // Clear the textfield where the URL was put in
                Populate.refreshSelection(lvMain, lbxGenre, lbxEpisodes, tbxDescription, lblFeedTitle); // Refresh the selected items in Genre (to sort lvMain and everything else accordingly)
            } else {
                MessageBox.Show("A feed with this URL already exists!");
            }

        }

        private void btnSaveCat_Click(object sender, EventArgs e) {
            if (lbxGenre.SelectedIndex >= 1) { // If category selected is index 1 or higher
                lbxGenre.Items[lbxGenre.SelectedIndex] = txtGenre.Text; // Set the currently selected index to match the text field txtPoseidon
            }
            Workfiles.ClearFile(Genre.GetGenrePath()); // Clear the genre file
            Populate.updateList(cbxGenre, Genre.UpdateGenreFile(lbxGenre)); // Update the list box and re-write the genre file to match the new content in the list box
            cbxGenre.Items.RemoveAt(0); // Remove the "All Genres" genre from the combo box
        }

        private void btnSaveFeed_Click(object sender, EventArgs e) {
            if (lvMain.SelectedItems.Count == 1) {
                int selectedFeed = lvMain.SelectedItems[0].Index;
                EntityLogicLayer.UpdateItemFrequencyFromPersistent(selectedFeed, cbxUpFreq.Text);
                EntityLogicLayer.UpdateItemGenreFromPersistent(selectedFeed, cbxGenre.Text);
                List<ListViewItem> persistentFeedList = EntityLogicLayer.SetPersistentFeedListToLvMain(); // Take a snapshot of lvMain and put it into the persistent feed variable
                Populate.updateListView(lvMain, persistentFeedList);
                EntityLogicLayer.SetPersistentFeedListToSaveFile(); // Save the persistent feed variable to the FeedFile
                                                                    // Populate.refreshSelection(lbxGenre);
                Populate.refreshSelection(lvMain, lbxGenre, lbxEpisodes, tbxDescription, lblFeedTitle); // Refresh the selected items in Genre (to sort lvMain accordingly)
            } else {
                MessageBox.Show("No item selected, or more than one item selected!");
            }
        }

        private void btnDelCat_Click(object sender, EventArgs e) {
            if (lbxGenre.SelectedIndex >= 1) { // If category selected is index 1 or higher
                Genre.DeleteGenre(lbxGenre); // Delete the genre from the list box
                Workfiles.ClearFile(Genre.GetGenrePath()); // Clear the genre file
                Populate.updateList(cbxGenre, Genre.UpdateGenreFile(lbxGenre)); // Update the list box and re-write the genre file to match the new content in the list box
                cbxGenre.Items.RemoveAt(0); // Remove the "All Genres" genre from the combo box
            } else {
                txtGenre.Clear(); // Clear the input field
            }
        }

        private void btnDelFeed_Click(object sender, EventArgs e) {
            if (lvMain.SelectedItems.Count == 1) {
                EntityLogicLayer.DeleteFeedItemFromPersistent(lvMain.SelectedItems[0].Index); // Deletes the Feed item from the PersistentFeedList variable in ELL and deletes the physical .xml file from the harddrive
                List<ListViewItem> mainList = EntityLogicLayer.SetPersistentFeedListToLvMain(); // Returns a List<ListViewItem> representing the PersistentFeedList from ELL 
                Populate.updateListView(lvMain, mainList); // Populating the GUI with the new List of ListViewItems
                EntityLogicLayer.SetPersistentFeedListToSaveFile(); // Saves the PersistentFeedList to FeedFile.txt
                Populate.refreshSelection(lvMain, lbxGenre, lbxEpisodes, tbxDescription, lblFeedTitle); // Refresh the selected items in Genre (to sort all ListViews and ListBoxes accordingly)
            } else {
                MessageBox.Show("No item selected, or more than one item selected!");
            }
        }
        // SelectedIndexChanged Event(s)
        private void lvMain_SelectedIndexChanged(object sender, EventArgs e) {
            if (lvMain.SelectedItems.Count == 1) { // If one and ONLY one item is selected
                Populate.updateList(lbxEpisodes, EntityLogicLayer.GetEpisodesFromPersistent(lvMain.SelectedItems[0].Index)); // Update the Episodes list box for the currently selected feed, and load the episodes into the list
                lblFeedTitle.Text = lvMain.SelectedItems[0].SubItems[1].Text; // Get the feed title from the selected list view item, and set the label to the feed title
                txtUrl.Text = lvMain.SelectedItems[0].SubItems[4].Text; // Get the URL from the selected list view item, and set the input field to match the newly selected item's URL
                cbxUpFreq.SelectedItem = lvMain.SelectedItems[0].SubItems[2].Text; // Set the selected item in the combo box to match the currently selected item in the list view
                cbxGenre.SelectedItem = lvMain.SelectedItems[0].SubItems[3].Text; // Set the selected item in the combo box to match the currently selected item in the list view

                // Feed button logic
                btnNewFeed.Enabled = false;
                btnSaveFeed.Enabled = true;
                btnDelFeed.Enabled = true;

                txtUrl.Enabled = false;
            } else {
                Populate.clearBoxes(lbxEpisodes, tbxDescription, lblFeedTitle); // Take a guess
                // Feed button logic
                btnNewFeed.Enabled = true;
                btnSaveFeed.Enabled = false;
                btnDelFeed.Enabled = false;

                txtUrl.Enabled = true;
            }
        }

        private void lbxGenre_SelectedIndexChanged(object sender, EventArgs e) {
            // It is important that the text-field modifiers come before the button state modifiers. This is because there are listeners who change the button states upon text change. This means that if you change the buttons first, and then the text, the listeners will fire and modify the button states to what the listeners say they should be rather than what you want it to be here.
            if (lbxGenre.SelectedItems.Count == 1) { // If one thing, and only one thing is selected
                if (lbxGenre.SelectedIndex >= 1) { // If any index above 0 is selected (anything that is NOT the first item)
                    // Filter lvMain after the genre selected
                    string selectedGenre = lbxGenre.SelectedItem.ToString();
                    EntityLogicLayer.SetFilteredFeedList(selectedGenre); // Sets the variable FilteredFeedList in ELL based on the selected genre
                    List<ListViewItem> filteredFeedList = EntityLogicLayer.SetFilteredFeedListToLvMain(); // Returns a List<ListViewItem> representing the FilteredFeedList from ELL
                    Populate.updateListView(lvMain, filteredFeedList); // Updates the GUI

                    txtGenre.Text = selectedGenre;

                    // Genre button logic
                    btnNewCat.Enabled = false;
                    btnSaveCat.Enabled = true;
                    btnDelCat.Enabled = true;
                    // Feed button logic
                    btnSaveFeed.Enabled = false;
                } else if (lbxGenre.SelectedIndex == 0) { // To not allow people to modify the first entry ("All genres").
                    // Show all items
                    List<ListViewItem> persistentFeedList = EntityLogicLayer.SetPersistentFeedListToLvMain();
                    Populate.updateListView(lvMain, persistentFeedList);

                    txtGenre.Clear();
                    // Genre button logic
                    btnNewCat.Enabled = false;
                    btnSaveCat.Enabled = false;
                    btnDelCat.Enabled = false;
                    // Feed button logic
                    btnSaveFeed.Enabled = true;
                }
            } else { // If nothing is selected
                txtGenre.Clear();
                // Genre button logic
                btnNewCat.Enabled = true;
                btnSaveCat.Enabled = false;
                btnDelCat.Enabled = false;
            }
            Populate.clearBoxes(lbxEpisodes, tbxDescription, lblFeedTitle); // Take a guess
        }

        private void lbxEpisodes_SelectedIndexChanged(object sender, EventArgs e) {
            if (lvMain.SelectedItems.Count == 1) { // If only one episode is selected
                // Gets the description of the specific episode selected in the listbox Episodes from the specific feed selected in the listview lvMain, and populates the appropriate textbox with it
                int episodeIndex = lbxEpisodes.SelectedIndex; // Currently selected index
                int feedIndex = lvMain.SelectedItems[0].Index;
                string description = EntityLogicLayer.GetEpisodeDescriptionFromPersistent(feedIndex, episodeIndex);
                Populate.updateList(tbxDescription, description); // Update the text box txtDescription
            } else { // If more than one episode is selected
                tbxDescription.Clear();
            }
        }

        // KeyDown/KeyUp/KeyPress Event(s)
        private void txtUrl_TextChanged(object sender, EventArgs e) {
            btnNewFeed.Enabled = string.IsNullOrWhiteSpace(txtUrl.Text) ? false : true;
        }

        private void txtGenre_TextChanged(object sender, EventArgs e) {
            btnNewCat.Enabled = string.IsNullOrWhiteSpace(txtGenre.Text) ? false : true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            myUpdaterThread.Abort();
        }

        private void btnSelectChecker_Click(object sender, EventArgs e) { // This is inclement
            string selectedThings = "You have selected:\n";
            bool somethingWasSelected = false;
            if (lbxEpisodes.SelectedItems.Count == 1) {
                selectedThings += new Episode().EntityType();
                somethingWasSelected = true;
            }
            if (lvMain.SelectedItems.Count == 1) {
                selectedThings += new Feed().EntityType();
                somethingWasSelected = true;
            }
            if (lbxGenre.SelectedItems.Count == 1) {
                selectedThings += new Genre().EntityType();
                somethingWasSelected = true;
            }
            if (somethingWasSelected) {
                MessageBox.Show(selectedThings);
            } else {
                MessageBox.Show("You have not selected anything.");
            }
        }
    }
}