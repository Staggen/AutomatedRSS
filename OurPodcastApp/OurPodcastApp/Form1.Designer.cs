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
            this.lvlMain = new System.Windows.Forms.ListView();
            this.Episodes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Frequency = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Genre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.cmbUpFreq = new System.Windows.Forms.ComboBox();
            this.cmbGenre = new System.Windows.Forms.ComboBox();
            this.lbxCat = new System.Windows.Forms.ListBox();
            this.btnNewFeed = new System.Windows.Forms.Button();
            this.btnSaveFeed = new System.Windows.Forms.Button();
            this.btnDelFeed = new System.Windows.Forms.Button();
            this.lbxFeed = new System.Windows.Forms.ListBox();
            this.pnlEpInfo = new System.Windows.Forms.Panel();
            this.txtPoseidon = new System.Windows.Forms.TextBox();
            this.btnDelCat = new System.Windows.Forms.Button();
            this.btnSaveCat = new System.Windows.Forms.Button();
            this.btnNewCat = new System.Windows.Forms.Button();
            this.lblUrl = new System.Windows.Forms.Label();
            this.lblUpdFeed = new System.Windows.Forms.Label();
            this.lblGenFeed = new System.Windows.Forms.Label();
            this.lblPoseidon = new System.Windows.Forms.Label();
            this.lblFeedInfo = new System.Windows.Forms.Label();
            this.lblGenre = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lvlMain
            // 
            this.lvlMain.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Episodes,
            this.Name,
            this.Frequency,
            this.Genre});
            this.lvlMain.Location = new System.Drawing.Point(14, 13);
            this.lvlMain.Name = "lvlMain";
            this.lvlMain.Size = new System.Drawing.Size(430, 220);
            this.lvlMain.TabIndex = 0;
            this.lvlMain.UseCompatibleStateImageBehavior = false;
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(13, 255);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(174, 20);
            this.txtUrl.TabIndex = 1;
            // 
            // cmbUpFreq
            // 
            this.cmbUpFreq.FormattingEnabled = true;
            this.cmbUpFreq.Location = new System.Drawing.Point(194, 255);
            this.cmbUpFreq.Name = "cmbUpFreq";
            this.cmbUpFreq.Size = new System.Drawing.Size(121, 21);
            this.cmbUpFreq.TabIndex = 2;
            // 
            // cmbGenre
            // 
            this.cmbGenre.FormattingEnabled = true;
            this.cmbGenre.Location = new System.Drawing.Point(322, 255);
            this.cmbGenre.Name = "cmbGenre";
            this.cmbGenre.Size = new System.Drawing.Size(121, 21);
            this.cmbGenre.TabIndex = 3;
            // 
            // lbxCat
            // 
            this.lbxCat.FormattingEnabled = true;
            this.lbxCat.Location = new System.Drawing.Point(451, 29);
            this.lbxCat.Name = "lbxCat";
            this.lbxCat.Size = new System.Drawing.Size(338, 199);
            this.lbxCat.TabIndex = 4;
            // 
            // btnNewFeed
            // 
            this.btnNewFeed.Location = new System.Drawing.Point(207, 282);
            this.btnNewFeed.Name = "btnNewFeed";
            this.btnNewFeed.Size = new System.Drawing.Size(75, 23);
            this.btnNewFeed.TabIndex = 5;
            this.btnNewFeed.Text = "New";
            this.btnNewFeed.UseVisualStyleBackColor = true;
            // 
            // btnSaveFeed
            // 
            this.btnSaveFeed.Location = new System.Drawing.Point(288, 282);
            this.btnSaveFeed.Name = "btnSaveFeed";
            this.btnSaveFeed.Size = new System.Drawing.Size(75, 23);
            this.btnSaveFeed.TabIndex = 6;
            this.btnSaveFeed.Text = "Save";
            this.btnSaveFeed.UseVisualStyleBackColor = true;
            // 
            // btnDelFeed
            // 
            this.btnDelFeed.Location = new System.Drawing.Point(369, 282);
            this.btnDelFeed.Name = "btnDelFeed";
            this.btnDelFeed.Size = new System.Drawing.Size(75, 23);
            this.btnDelFeed.TabIndex = 7;
            this.btnDelFeed.Text = "Delete";
            this.btnDelFeed.UseVisualStyleBackColor = true;
            // 
            // lbxFeed
            // 
            this.lbxFeed.FormattingEnabled = true;
            this.lbxFeed.Location = new System.Drawing.Point(13, 310);
            this.lbxFeed.Name = "lbxFeed";
            this.lbxFeed.Size = new System.Drawing.Size(430, 121);
            this.lbxFeed.TabIndex = 8;
            // 
            // pnlEpInfo
            // 
            this.pnlEpInfo.Location = new System.Drawing.Point(450, 310);
            this.pnlEpInfo.Name = "pnlEpInfo";
            this.pnlEpInfo.Size = new System.Drawing.Size(337, 120);
            this.pnlEpInfo.TabIndex = 9;
            // 
            // txtPoseidon
            // 
            this.txtPoseidon.Location = new System.Drawing.Point(450, 255);
            this.txtPoseidon.Name = "txtPoseidon";
            this.txtPoseidon.Size = new System.Drawing.Size(338, 20);
            this.txtPoseidon.TabIndex = 10;
            // 
            // btnDelCat
            // 
            this.btnDelCat.Location = new System.Drawing.Point(712, 281);
            this.btnDelCat.Name = "btnDelCat";
            this.btnDelCat.Size = new System.Drawing.Size(75, 23);
            this.btnDelCat.TabIndex = 11;
            this.btnDelCat.Text = "Delete";
            this.btnDelCat.UseVisualStyleBackColor = true;
            // 
            // btnSaveCat
            // 
            this.btnSaveCat.Location = new System.Drawing.Point(631, 282);
            this.btnSaveCat.Name = "btnSaveCat";
            this.btnSaveCat.Size = new System.Drawing.Size(75, 23);
            this.btnSaveCat.TabIndex = 12;
            this.btnSaveCat.Text = "Save";
            this.btnSaveCat.UseVisualStyleBackColor = true;
            // 
            // btnNewCat
            // 
            this.btnNewCat.Location = new System.Drawing.Point(550, 282);
            this.btnNewCat.Name = "btnNewCat";
            this.btnNewCat.Size = new System.Drawing.Size(75, 23);
            this.btnNewCat.TabIndex = 13;
            this.btnNewCat.Text = "New";
            this.btnNewCat.UseVisualStyleBackColor = true;
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
            // lblFeedInfo
            // 
            this.lblFeedInfo.AutoSize = true;
            this.lblFeedInfo.Location = new System.Drawing.Point(13, 291);
            this.lblFeedInfo.Name = "lblFeedInfo";
            this.lblFeedInfo.Size = new System.Drawing.Size(34, 13);
            this.lblFeedInfo.TabIndex = 18;
            this.lblFeedInfo.Text = "[feed]";
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblGenre);
            this.Controls.Add(this.lblFeedInfo);
            this.Controls.Add(this.lblPoseidon);
            this.Controls.Add(this.lblGenFeed);
            this.Controls.Add(this.lblUpdFeed);
            this.Controls.Add(this.lblUrl);
            this.Controls.Add(this.btnNewCat);
            this.Controls.Add(this.btnSaveCat);
            this.Controls.Add(this.btnDelCat);
            this.Controls.Add(this.txtPoseidon);
            this.Controls.Add(this.pnlEpInfo);
            this.Controls.Add(this.lbxFeed);
            this.Controls.Add(this.btnDelFeed);
            this.Controls.Add(this.btnSaveFeed);
            this.Controls.Add(this.btnNewFeed);
            this.Controls.Add(this.lbxCat);
            this.Controls.Add(this.cmbGenre);
            this.Controls.Add(this.cmbUpFreq);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.lvlMain);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvlMain;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.ComboBox cmbUpFreq;
        private System.Windows.Forms.ComboBox cmbGenre;
        private System.Windows.Forms.ListBox lbxCat;
        private System.Windows.Forms.Button btnNewFeed;
        private System.Windows.Forms.Button btnSaveFeed;
        private System.Windows.Forms.Button btnDelFeed;
        private System.Windows.Forms.ListBox lbxFeed;
        private System.Windows.Forms.Panel pnlEpInfo;
        private System.Windows.Forms.TextBox txtPoseidon;
        private System.Windows.Forms.Button btnDelCat;
        private System.Windows.Forms.Button btnSaveCat;
        private System.Windows.Forms.Button btnNewCat;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.Label lblUpdFeed;
        private System.Windows.Forms.Label lblGenFeed;
        private System.Windows.Forms.Label lblPoseidon;
        private System.Windows.Forms.Label lblFeedInfo;
        private System.Windows.Forms.Label lblGenre;
        private System.Windows.Forms.ColumnHeader Episodes;
        private System.Windows.Forms.ColumnHeader Name;
        private System.Windows.Forms.ColumnHeader Frequency;
        private System.Windows.Forms.ColumnHeader Genre;
    }
}

