namespace OurPodcastApp {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.lvMain = new System.Windows.Forms.ListView();
            this.clhEpisodes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhFrequency = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clhGenre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.cbxUpFreq = new System.Windows.Forms.ComboBox();
            this.cbxGenre = new System.Windows.Forms.ComboBox();
            this.lbxGenre = new System.Windows.Forms.ListBox();
            this.btnNewFeed = new System.Windows.Forms.Button();
            this.btnSaveFeed = new System.Windows.Forms.Button();
            this.btnDelFeed = new System.Windows.Forms.Button();
            this.lbxEpisodes = new System.Windows.Forms.ListBox();
            this.txtGenre = new System.Windows.Forms.TextBox();
            this.btnDelCat = new System.Windows.Forms.Button();
            this.btnSaveCat = new System.Windows.Forms.Button();
            this.btnNewCat = new System.Windows.Forms.Button();
            this.lblUrl = new System.Windows.Forms.Label();
            this.lblUpdFeed = new System.Windows.Forms.Label();
            this.lblGenFeed = new System.Windows.Forms.Label();
            this.lblPoseidon = new System.Windows.Forms.Label();
            this.lblFeedTitle = new System.Windows.Forms.Label();
            this.lblGenre = new System.Windows.Forms.Label();
            this.tbxDescription = new System.Windows.Forms.TextBox();
            this.btnSelectChecker = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvMain
            // 
            this.lvMain.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clhEpisodes,
            this.clhTitle,
            this.clhFrequency,
            this.clhGenre});
            this.lvMain.HideSelection = false;
            this.lvMain.Location = new System.Drawing.Point(12, 17);
            this.lvMain.Name = "lvMain";
            this.lvMain.Size = new System.Drawing.Size(430, 220);
            this.lvMain.TabIndex = 0;
            this.lvMain.UseCompatibleStateImageBehavior = false;
            this.lvMain.View = System.Windows.Forms.View.Details;
            this.lvMain.SelectedIndexChanged += new System.EventHandler(this.lvMain_SelectedIndexChanged);
            // 
            // clhEpisodes
            // 
            this.clhEpisodes.Text = "Episodes";
            this.clhEpisodes.Width = 55;
            // 
            // clhTitle
            // 
            this.clhTitle.Text = "Title";
            this.clhTitle.Width = 171;
            // 
            // clhFrequency
            // 
            this.clhFrequency.Text = "Frequency";
            this.clhFrequency.Width = 80;
            // 
            // clhGenre
            // 
            this.clhGenre.Text = "Genre";
            this.clhGenre.Width = 120;
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(13, 255);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(174, 20);
            this.txtUrl.TabIndex = 1;
            this.txtUrl.TextChanged += new System.EventHandler(this.txtUrl_TextChanged);
            // 
            // cbxUpFreq
            // 
            this.cbxUpFreq.FormattingEnabled = true;
            this.cbxUpFreq.Location = new System.Drawing.Point(194, 255);
            this.cbxUpFreq.Name = "cbxUpFreq";
            this.cbxUpFreq.Size = new System.Drawing.Size(121, 21);
            this.cbxUpFreq.TabIndex = 2;
            // 
            // cbxGenre
            // 
            this.cbxGenre.FormattingEnabled = true;
            this.cbxGenre.Location = new System.Drawing.Point(322, 255);
            this.cbxGenre.Name = "cbxGenre";
            this.cbxGenre.Size = new System.Drawing.Size(121, 21);
            this.cbxGenre.TabIndex = 3;
            // 
            // lbxGenre
            // 
            this.lbxGenre.FormattingEnabled = true;
            this.lbxGenre.Location = new System.Drawing.Point(451, 34);
            this.lbxGenre.Name = "lbxGenre";
            this.lbxGenre.Size = new System.Drawing.Size(338, 199);
            this.lbxGenre.TabIndex = 4;
            this.lbxGenre.SelectedIndexChanged += new System.EventHandler(this.lbxGenre_SelectedIndexChanged);
            // 
            // btnNewFeed
            // 
            this.btnNewFeed.Location = new System.Drawing.Point(207, 282);
            this.btnNewFeed.Name = "btnNewFeed";
            this.btnNewFeed.Size = new System.Drawing.Size(75, 23);
            this.btnNewFeed.TabIndex = 5;
            this.btnNewFeed.Text = "New";
            this.btnNewFeed.UseVisualStyleBackColor = true;
            this.btnNewFeed.Click += new System.EventHandler(this.btnNewFeed_Click);
            // 
            // btnSaveFeed
            // 
            this.btnSaveFeed.Location = new System.Drawing.Point(288, 282);
            this.btnSaveFeed.Name = "btnSaveFeed";
            this.btnSaveFeed.Size = new System.Drawing.Size(75, 23);
            this.btnSaveFeed.TabIndex = 6;
            this.btnSaveFeed.Text = "Save";
            this.btnSaveFeed.UseVisualStyleBackColor = true;
            this.btnSaveFeed.Click += new System.EventHandler(this.btnSaveFeed_Click);
            // 
            // btnDelFeed
            // 
            this.btnDelFeed.Location = new System.Drawing.Point(369, 282);
            this.btnDelFeed.Name = "btnDelFeed";
            this.btnDelFeed.Size = new System.Drawing.Size(75, 23);
            this.btnDelFeed.TabIndex = 7;
            this.btnDelFeed.Text = "Delete";
            this.btnDelFeed.UseVisualStyleBackColor = true;
            this.btnDelFeed.Click += new System.EventHandler(this.btnDelFeed_Click);
            // 
            // lbxEpisodes
            // 
            this.lbxEpisodes.FormattingEnabled = true;
            this.lbxEpisodes.HorizontalExtent = 100;
            this.lbxEpisodes.HorizontalScrollbar = true;
            this.lbxEpisodes.Location = new System.Drawing.Point(14, 324);
            this.lbxEpisodes.Name = "lbxEpisodes";
            this.lbxEpisodes.Size = new System.Drawing.Size(775, 199);
            this.lbxEpisodes.TabIndex = 8;
            this.lbxEpisodes.SelectedIndexChanged += new System.EventHandler(this.lbxEpisodes_SelectedIndexChanged);
            // 
            // txtGenre
            // 
            this.txtGenre.Location = new System.Drawing.Point(450, 255);
            this.txtGenre.Name = "txtGenre";
            this.txtGenre.Size = new System.Drawing.Size(338, 20);
            this.txtGenre.TabIndex = 10;
            this.txtGenre.TextChanged += new System.EventHandler(this.txtGenre_TextChanged);
            // 
            // btnDelCat
            // 
            this.btnDelCat.Location = new System.Drawing.Point(714, 282);
            this.btnDelCat.Name = "btnDelCat";
            this.btnDelCat.Size = new System.Drawing.Size(75, 23);
            this.btnDelCat.TabIndex = 11;
            this.btnDelCat.Text = "Delete";
            this.btnDelCat.UseVisualStyleBackColor = true;
            this.btnDelCat.Click += new System.EventHandler(this.btnDelCat_Click);
            // 
            // btnSaveCat
            // 
            this.btnSaveCat.Location = new System.Drawing.Point(633, 282);
            this.btnSaveCat.Name = "btnSaveCat";
            this.btnSaveCat.Size = new System.Drawing.Size(75, 23);
            this.btnSaveCat.TabIndex = 12;
            this.btnSaveCat.Text = "Save";
            this.btnSaveCat.UseVisualStyleBackColor = true;
            this.btnSaveCat.Click += new System.EventHandler(this.btnSaveCat_Click);
            // 
            // btnNewCat
            // 
            this.btnNewCat.Location = new System.Drawing.Point(552, 282);
            this.btnNewCat.Name = "btnNewCat";
            this.btnNewCat.Size = new System.Drawing.Size(75, 23);
            this.btnNewCat.TabIndex = 13;
            this.btnNewCat.Text = "New";
            this.btnNewCat.UseVisualStyleBackColor = true;
            this.btnNewCat.Click += new System.EventHandler(this.btnNewCat_Click);
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(14, 240);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(32, 13);
            this.lblUrl.TabIndex = 14;
            this.lblUrl.Text = "URL:";
            // 
            // lblUpdFeed
            // 
            this.lblUpdFeed.AutoSize = true;
            this.lblUpdFeed.Location = new System.Drawing.Point(192, 240);
            this.lblUpdFeed.Name = "lblUpdFeed";
            this.lblUpdFeed.Size = new System.Drawing.Size(86, 13);
            this.lblUpdFeed.TabIndex = 15;
            this.lblUpdFeed.Text = "Update frequecy";
            // 
            // lblGenFeed
            // 
            this.lblGenFeed.AutoSize = true;
            this.lblGenFeed.Location = new System.Drawing.Point(320, 240);
            this.lblGenFeed.Name = "lblGenFeed";
            this.lblGenFeed.Size = new System.Drawing.Size(36, 13);
            this.lblGenFeed.TabIndex = 16;
            this.lblGenFeed.Text = "Genre";
            // 
            // lblPoseidon
            // 
            this.lblPoseidon.AutoSize = true;
            this.lblPoseidon.Location = new System.Drawing.Point(448, 240);
            this.lblPoseidon.Name = "lblPoseidon";
            this.lblPoseidon.Size = new System.Drawing.Size(130, 13);
            this.lblPoseidon.TabIndex = 17;
            this.lblPoseidon.Text = "Search/Edit/Create genre";
            // 
            // lblFeedTitle
            // 
            this.lblFeedTitle.AutoSize = true;
            this.lblFeedTitle.Location = new System.Drawing.Point(10, 307);
            this.lblFeedTitle.Name = "lblFeedTitle";
            this.lblFeedTitle.Size = new System.Drawing.Size(57, 13);
            this.lblFeedTitle.TabIndex = 18;
            this.lblFeedTitle.Text = "Feed Title:";
            // 
            // lblGenre
            // 
            this.lblGenre.AutoSize = true;
            this.lblGenre.Location = new System.Drawing.Point(448, 13);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new System.Drawing.Size(44, 13);
            this.lblGenre.TabIndex = 20;
            this.lblGenre.Text = "Genres:";
            // 
            // tbxDescription
            // 
            this.tbxDescription.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.tbxDescription.Location = new System.Drawing.Point(12, 529);
            this.tbxDescription.Multiline = true;
            this.tbxDescription.Name = "tbxDescription";
            this.tbxDescription.ReadOnly = true;
            this.tbxDescription.Size = new System.Drawing.Size(615, 199);
            this.tbxDescription.TabIndex = 21;
            // 
            // btnSelectChecker
            // 
            this.btnSelectChecker.Location = new System.Drawing.Point(633, 529);
            this.btnSelectChecker.Name = "btnSelectChecker";
            this.btnSelectChecker.Size = new System.Drawing.Size(155, 199);
            this.btnSelectChecker.TabIndex = 22;
            this.btnSelectChecker.Text = "What have I selected?";
            this.btnSelectChecker.UseVisualStyleBackColor = true;
            this.btnSelectChecker.Click += new System.EventHandler(this.btnSelectChecker_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 747);
            this.Controls.Add(this.btnSelectChecker);
            this.Controls.Add(this.tbxDescription);
            this.Controls.Add(this.lblGenre);
            this.Controls.Add(this.lblFeedTitle);
            this.Controls.Add(this.lblPoseidon);
            this.Controls.Add(this.lblGenFeed);
            this.Controls.Add(this.lblUpdFeed);
            this.Controls.Add(this.lblUrl);
            this.Controls.Add(this.btnNewCat);
            this.Controls.Add(this.btnSaveCat);
            this.Controls.Add(this.btnDelCat);
            this.Controls.Add(this.txtGenre);
            this.Controls.Add(this.lbxEpisodes);
            this.Controls.Add(this.btnDelFeed);
            this.Controls.Add(this.btnSaveFeed);
            this.Controls.Add(this.btnNewFeed);
            this.Controls.Add(this.lbxGenre);
            this.Controls.Add(this.cbxGenre);
            this.Controls.Add(this.cbxUpFreq);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.lvMain);
            this.Name = "Form1";
            this.Text = " ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvMain;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.ComboBox cbxUpFreq;
        private System.Windows.Forms.ComboBox cbxGenre;
        private System.Windows.Forms.ListBox lbxGenre;
        private System.Windows.Forms.Button btnNewFeed;
        private System.Windows.Forms.Button btnSaveFeed;
        private System.Windows.Forms.Button btnDelFeed;
        private System.Windows.Forms.ListBox lbxEpisodes;
        private System.Windows.Forms.TextBox txtGenre;
        private System.Windows.Forms.Button btnDelCat;
        private System.Windows.Forms.Button btnSaveCat;
        private System.Windows.Forms.Button btnNewCat;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.Label lblUpdFeed;
        private System.Windows.Forms.Label lblGenFeed;
        private System.Windows.Forms.Label lblPoseidon;
        private System.Windows.Forms.Label lblFeedTitle;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.ColumnHeader clhEpisodes;
        private System.Windows.Forms.ColumnHeader clhTitle;
        private System.Windows.Forms.ColumnHeader clhFrequency;
        private System.Windows.Forms.ColumnHeader clhGenre;
        private System.Windows.Forms.TextBox tbxDescription;
        private System.Windows.Forms.Button btnSelectChecker;
    }
}

