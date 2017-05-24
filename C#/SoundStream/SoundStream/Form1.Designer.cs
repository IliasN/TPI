namespace SoundStream
{
    partial class frmMain
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tpPlaylists = new System.Windows.Forms.TabPage();
            this.btnDeletePlaylist = new System.Windows.Forms.Button();
            this.tbxNewPlaylist = new System.Windows.Forms.TextBox();
            this.btnCreatePlaylist = new System.Windows.Forms.Button();
            this.btnDelFromPlaylist = new System.Windows.Forms.Button();
            this.lblPlaylist = new System.Windows.Forms.Label();
            this.cmbPlaylist = new System.Windows.Forms.ComboBox();
            this.lsbPlaylist = new System.Windows.Forms.ListBox();
            this.tpFavorites = new System.Windows.Forms.TabPage();
            this.btnRemoveFav = new System.Windows.Forms.Button();
            this.lsbFavorites = new System.Windows.Forms.ListBox();
            this.tpMusic = new System.Windows.Forms.TabPage();
            this.cmbPlaylistToAdd = new System.Windows.Forms.ComboBox();
            this.btnAddToPlaylist = new System.Windows.Forms.Button();
            this.btnAddFavorites = new System.Windows.Forms.Button();
            this.lsbMusiques = new System.Windows.Forms.ListBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.tbxSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.tbVolume = new System.Windows.Forms.TrackBar();
            this.lblVolume = new System.Windows.Forms.Label();
            this.tbTime = new System.Windows.Forms.TrackBar();
            this.lblTimeMax = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblVolumeValue = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tmrMain = new System.Windows.Forms.Timer(this.components);
            this.tcMain.SuspendLayout();
            this.tpPlaylists.SuspendLayout();
            this.tpFavorites.SuspendLayout();
            this.tpMusic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTime)).BeginInit();
            this.SuspendLayout();
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tpPlaylists);
            this.tcMain.Controls.Add(this.tpFavorites);
            this.tcMain.Controls.Add(this.tpMusic);
            this.tcMain.Location = new System.Drawing.Point(12, 53);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(969, 467);
            this.tcMain.TabIndex = 0;
            // 
            // tpPlaylists
            // 
            this.tpPlaylists.Controls.Add(this.btnDeletePlaylist);
            this.tpPlaylists.Controls.Add(this.tbxNewPlaylist);
            this.tpPlaylists.Controls.Add(this.btnCreatePlaylist);
            this.tpPlaylists.Controls.Add(this.btnDelFromPlaylist);
            this.tpPlaylists.Controls.Add(this.lblPlaylist);
            this.tpPlaylists.Controls.Add(this.cmbPlaylist);
            this.tpPlaylists.Controls.Add(this.lsbPlaylist);
            this.tpPlaylists.Location = new System.Drawing.Point(4, 22);
            this.tpPlaylists.Name = "tpPlaylists";
            this.tpPlaylists.Padding = new System.Windows.Forms.Padding(3);
            this.tpPlaylists.Size = new System.Drawing.Size(961, 441);
            this.tpPlaylists.TabIndex = 2;
            this.tpPlaylists.Text = "Playlists";
            this.tpPlaylists.UseVisualStyleBackColor = true;
            // 
            // btnDeletePlaylist
            // 
            this.btnDeletePlaylist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeletePlaylist.Location = new System.Drawing.Point(489, 398);
            this.btnDeletePlaylist.Name = "btnDeletePlaylist";
            this.btnDeletePlaylist.Size = new System.Drawing.Size(129, 35);
            this.btnDeletePlaylist.TabIndex = 13;
            this.btnDeletePlaylist.Text = "Supprimer cette playlist";
            this.btnDeletePlaylist.UseVisualStyleBackColor = true;
            this.btnDeletePlaylist.Click += new System.EventHandler(this.btnDeletePlaylist_Click);
            // 
            // tbxNewPlaylist
            // 
            this.tbxNewPlaylist.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tbxNewPlaylist.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbxNewPlaylist.Location = new System.Drawing.Point(759, 406);
            this.tbxNewPlaylist.Name = "tbxNewPlaylist";
            this.tbxNewPlaylist.Size = new System.Drawing.Size(196, 20);
            this.tbxNewPlaylist.TabIndex = 12;
            this.tbxNewPlaylist.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxNewPlaylist_KeyDown);
            // 
            // btnCreatePlaylist
            // 
            this.btnCreatePlaylist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreatePlaylist.Location = new System.Drawing.Point(624, 398);
            this.btnCreatePlaylist.Name = "btnCreatePlaylist";
            this.btnCreatePlaylist.Size = new System.Drawing.Size(129, 35);
            this.btnCreatePlaylist.TabIndex = 10;
            this.btnCreatePlaylist.Text = "Créer la playlist :";
            this.btnCreatePlaylist.UseVisualStyleBackColor = true;
            this.btnCreatePlaylist.Click += new System.EventHandler(this.btnCreatePlaylist_Click);
            // 
            // btnDelFromPlaylist
            // 
            this.btnDelFromPlaylist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelFromPlaylist.Location = new System.Drawing.Point(7, 398);
            this.btnDelFromPlaylist.Name = "btnDelFromPlaylist";
            this.btnDelFromPlaylist.Size = new System.Drawing.Size(129, 35);
            this.btnDelFromPlaylist.TabIndex = 9;
            this.btnDelFromPlaylist.Text = "Supprimer de la playlist";
            this.btnDelFromPlaylist.UseVisualStyleBackColor = true;
            this.btnDelFromPlaylist.Click += new System.EventHandler(this.btnDelFromPlaylist_Click);
            // 
            // lblPlaylist
            // 
            this.lblPlaylist.AutoSize = true;
            this.lblPlaylist.Location = new System.Drawing.Point(16, 13);
            this.lblPlaylist.Name = "lblPlaylist";
            this.lblPlaylist.Size = new System.Drawing.Size(45, 13);
            this.lblPlaylist.TabIndex = 2;
            this.lblPlaylist.Text = "Playlist :";
            // 
            // cmbPlaylist
            // 
            this.cmbPlaylist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlaylist.FormattingEnabled = true;
            this.cmbPlaylist.Location = new System.Drawing.Point(67, 10);
            this.cmbPlaylist.Name = "cmbPlaylist";
            this.cmbPlaylist.Size = new System.Drawing.Size(151, 21);
            this.cmbPlaylist.TabIndex = 1;
            this.cmbPlaylist.SelectedIndexChanged += new System.EventHandler(this.cmbPlaylist_SelectedIndexChanged);
            // 
            // lsbPlaylist
            // 
            this.lsbPlaylist.FormattingEnabled = true;
            this.lsbPlaylist.Location = new System.Drawing.Point(7, 37);
            this.lsbPlaylist.Name = "lsbPlaylist";
            this.lsbPlaylist.Size = new System.Drawing.Size(948, 355);
            this.lsbPlaylist.TabIndex = 0;
            this.lsbPlaylist.SelectedIndexChanged += new System.EventHandler(this.lsbPlaylist_SelectedIndexChanged);
            // 
            // tpFavorites
            // 
            this.tpFavorites.Controls.Add(this.btnRemoveFav);
            this.tpFavorites.Controls.Add(this.lsbFavorites);
            this.tpFavorites.Location = new System.Drawing.Point(4, 22);
            this.tpFavorites.Name = "tpFavorites";
            this.tpFavorites.Padding = new System.Windows.Forms.Padding(3);
            this.tpFavorites.Size = new System.Drawing.Size(961, 441);
            this.tpFavorites.TabIndex = 1;
            this.tpFavorites.Text = "Favoris";
            this.tpFavorites.UseVisualStyleBackColor = true;
            // 
            // btnRemoveFav
            // 
            this.btnRemoveFav.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveFav.Location = new System.Drawing.Point(6, 396);
            this.btnRemoveFav.Name = "btnRemoveFav";
            this.btnRemoveFav.Size = new System.Drawing.Size(119, 37);
            this.btnRemoveFav.TabIndex = 9;
            this.btnRemoveFav.Text = "Supprimer des favoris";
            this.btnRemoveFav.UseVisualStyleBackColor = true;
            this.btnRemoveFav.Click += new System.EventHandler(this.btnRemoveFav_Click);
            // 
            // lsbFavorites
            // 
            this.lsbFavorites.FormattingEnabled = true;
            this.lsbFavorites.Location = new System.Drawing.Point(6, 6);
            this.lsbFavorites.Name = "lsbFavorites";
            this.lsbFavorites.Size = new System.Drawing.Size(949, 381);
            this.lsbFavorites.TabIndex = 1;
            this.lsbFavorites.SelectedIndexChanged += new System.EventHandler(this.lsbFavorites_SelectedIndexChanged);
            // 
            // tpMusic
            // 
            this.tpMusic.Controls.Add(this.cmbPlaylistToAdd);
            this.tpMusic.Controls.Add(this.btnAddToPlaylist);
            this.tpMusic.Controls.Add(this.btnAddFavorites);
            this.tpMusic.Controls.Add(this.lsbMusiques);
            this.tpMusic.Location = new System.Drawing.Point(4, 22);
            this.tpMusic.Name = "tpMusic";
            this.tpMusic.Padding = new System.Windows.Forms.Padding(3);
            this.tpMusic.Size = new System.Drawing.Size(961, 441);
            this.tpMusic.TabIndex = 0;
            this.tpMusic.Text = "Musiques";
            this.tpMusic.UseVisualStyleBackColor = true;
            // 
            // cmbPlaylistToAdd
            // 
            this.cmbPlaylistToAdd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlaylistToAdd.FormattingEnabled = true;
            this.cmbPlaylistToAdd.Location = new System.Drawing.Point(246, 408);
            this.cmbPlaylistToAdd.Name = "cmbPlaylistToAdd";
            this.cmbPlaylistToAdd.Size = new System.Drawing.Size(151, 21);
            this.cmbPlaylistToAdd.TabIndex = 15;
            // 
            // btnAddToPlaylist
            // 
            this.btnAddToPlaylist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddToPlaylist.Location = new System.Drawing.Point(126, 402);
            this.btnAddToPlaylist.Name = "btnAddToPlaylist";
            this.btnAddToPlaylist.Size = new System.Drawing.Size(114, 31);
            this.btnAddToPlaylist.TabIndex = 14;
            this.btnAddToPlaylist.Text = "Ajouter à la playlist :";
            this.btnAddToPlaylist.UseVisualStyleBackColor = true;
            this.btnAddToPlaylist.Click += new System.EventHandler(this.btnAddToPlaylist_Click);
            // 
            // btnAddFavorites
            // 
            this.btnAddFavorites.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddFavorites.Location = new System.Drawing.Point(6, 402);
            this.btnAddFavorites.Name = "btnAddFavorites";
            this.btnAddFavorites.Size = new System.Drawing.Size(114, 31);
            this.btnAddFavorites.TabIndex = 13;
            this.btnAddFavorites.Text = "Ajouter aux favoris";
            this.btnAddFavorites.UseVisualStyleBackColor = true;
            this.btnAddFavorites.Click += new System.EventHandler(this.btnAddFavorites_Click);
            // 
            // lsbMusiques
            // 
            this.lsbMusiques.FormattingEnabled = true;
            this.lsbMusiques.Location = new System.Drawing.Point(6, 12);
            this.lsbMusiques.Name = "lsbMusiques";
            this.lsbMusiques.Size = new System.Drawing.Size(949, 381);
            this.lsbMusiques.TabIndex = 12;
            this.lsbMusiques.SelectedIndexChanged += new System.EventHandler(this.lsbMusiques_SelectedIndexChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(536, 25);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(66, 13);
            this.lblSearch.TabIndex = 11;
            this.lblSearch.Text = "Recherche :";
            // 
            // tbxSearch
            // 
            this.tbxSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.tbxSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.tbxSearch.Location = new System.Drawing.Point(619, 22);
            this.tbxSearch.Name = "tbxSearch";
            this.tbxSearch.Size = new System.Drawing.Size(232, 20);
            this.tbxSearch.TabIndex = 10;
            this.tbxSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxSearch_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(857, 16);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(114, 31);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "Recherche";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlay.Location = new System.Drawing.Point(16, 523);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(102, 37);
            this.btnPlay.TabIndex = 1;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnPause
            // 
            this.btnPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPause.Location = new System.Drawing.Point(124, 523);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(102, 37);
            this.btnPause.TabIndex = 2;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // tbVolume
            // 
            this.tbVolume.Location = new System.Drawing.Point(849, 526);
            this.tbVolume.Maximum = 100;
            this.tbVolume.Name = "tbVolume";
            this.tbVolume.Size = new System.Drawing.Size(104, 45);
            this.tbVolume.TabIndex = 3;
            this.tbVolume.Value = 50;
            this.tbVolume.Scroll += new System.EventHandler(this.tbVolume_Scroll);
            // 
            // lblVolume
            // 
            this.lblVolume.AutoSize = true;
            this.lblVolume.Location = new System.Drawing.Point(795, 537);
            this.lblVolume.Name = "lblVolume";
            this.lblVolume.Size = new System.Drawing.Size(48, 13);
            this.lblVolume.TabIndex = 4;
            this.lblVolume.Text = "Volume :";
            // 
            // tbTime
            // 
            this.tbTime.Location = new System.Drawing.Point(293, 526);
            this.tbTime.Maximum = 100;
            this.tbTime.Name = "tbTime";
            this.tbTime.Size = new System.Drawing.Size(447, 45);
            this.tbTime.TabIndex = 5;
            this.tbTime.Scroll += new System.EventHandler(this.tbTime_Scroll);
            // 
            // lblTimeMax
            // 
            this.lblTimeMax.AutoSize = true;
            this.lblTimeMax.Location = new System.Drawing.Point(746, 535);
            this.lblTimeMax.Name = "lblTimeMax";
            this.lblTimeMax.Size = new System.Drawing.Size(40, 13);
            this.lblTimeMax.TabIndex = 6;
            this.lblTimeMax.Text = "00 : 00";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(247, 535);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(40, 13);
            this.lblTime.TabIndex = 7;
            this.lblTime.Text = "00 : 00";
            // 
            // lblVolumeValue
            // 
            this.lblVolumeValue.AutoSize = true;
            this.lblVolumeValue.Location = new System.Drawing.Point(959, 535);
            this.lblVolumeValue.Name = "lblVolumeValue";
            this.lblVolumeValue.Size = new System.Drawing.Size(19, 13);
            this.lblVolumeValue.TabIndex = 8;
            this.lblVolumeValue.Text = "50";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(16, 567);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(12, 13);
            this.lblTitle.TabIndex = 9;
            this.lblTitle.Text = "/";
            // 
            // tmrMain
            // 
            this.tmrMain.Enabled = true;
            this.tmrMain.Interval = 500;
            this.tmrMain.Tick += new System.EventHandler(this.tmrMain_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(989, 589);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblVolumeValue);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblTimeMax);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.tbTime);
            this.Controls.Add(this.tbxSearch);
            this.Controls.Add(this.lblVolume);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.tbVolume);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.tcMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1009, 632);
            this.MinimumSize = new System.Drawing.Size(1009, 632);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SoundStream";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.tcMain.ResumeLayout(false);
            this.tpPlaylists.ResumeLayout(false);
            this.tpPlaylists.PerformLayout();
            this.tpFavorites.ResumeLayout(false);
            this.tpMusic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tpMusic;
        private System.Windows.Forms.TabPage tpFavorites;
        private System.Windows.Forms.TabPage tpPlaylists;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.TrackBar tbVolume;
        private System.Windows.Forms.Label lblVolume;
        private System.Windows.Forms.TrackBar tbTime;
        private System.Windows.Forms.Label lblTimeMax;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblVolumeValue;
        private System.Windows.Forms.Button btnAddFavorites;
        private System.Windows.Forms.ListBox lsbMusiques;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox tbxSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cmbPlaylistToAdd;
        private System.Windows.Forms.Button btnAddToPlaylist;
        private System.Windows.Forms.Button btnRemoveFav;
        private System.Windows.Forms.ListBox lsbFavorites;
        private System.Windows.Forms.Button btnDelFromPlaylist;
        private System.Windows.Forms.Label lblPlaylist;
        private System.Windows.Forms.ComboBox cmbPlaylist;
        private System.Windows.Forms.ListBox lsbPlaylist;
        private System.Windows.Forms.Button btnCreatePlaylist;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Timer tmrMain;
        private System.Windows.Forms.Button btnDeletePlaylist;
        private System.Windows.Forms.TextBox tbxNewPlaylist;
    }
}

