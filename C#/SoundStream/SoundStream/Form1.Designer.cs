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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpMusic = new System.Windows.Forms.TabPage();
            this.tpFavorites = new System.Windows.Forms.TabPage();
            this.tpPlaylists = new System.Windows.Forms.TabPage();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.tbVolume = new System.Windows.Forms.TrackBar();
            this.lblVolume = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.lblTimeMax = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblVolumeValue = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbxSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.lsbMusiques = new System.Windows.Forms.ListBox();
            this.btnAddFavorites = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tpMusic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpMusic);
            this.tabControl1.Controls.Add(this.tpFavorites);
            this.tabControl1.Controls.Add(this.tpPlaylists);
            this.tabControl1.Location = new System.Drawing.Point(12, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(969, 465);
            this.tabControl1.TabIndex = 0;
            // 
            // tpMusic
            // 
            this.tpMusic.Controls.Add(this.btnAddFavorites);
            this.tpMusic.Controls.Add(this.lsbMusiques);
            this.tpMusic.Controls.Add(this.lblSearch);
            this.tpMusic.Controls.Add(this.tbxSearch);
            this.tpMusic.Controls.Add(this.btnSearch);
            this.tpMusic.Location = new System.Drawing.Point(4, 22);
            this.tpMusic.Name = "tpMusic";
            this.tpMusic.Padding = new System.Windows.Forms.Padding(3);
            this.tpMusic.Size = new System.Drawing.Size(961, 439);
            this.tpMusic.TabIndex = 0;
            this.tpMusic.Text = "Musiques";
            this.tpMusic.UseVisualStyleBackColor = true;
            // 
            // tpFavorites
            // 
            this.tpFavorites.Location = new System.Drawing.Point(4, 22);
            this.tpFavorites.Name = "tpFavorites";
            this.tpFavorites.Padding = new System.Windows.Forms.Padding(3);
            this.tpFavorites.Size = new System.Drawing.Size(961, 439);
            this.tpFavorites.TabIndex = 1;
            this.tpFavorites.Text = "Favoris";
            this.tpFavorites.UseVisualStyleBackColor = true;
            // 
            // tpPlaylists
            // 
            this.tpPlaylists.Location = new System.Drawing.Point(4, 22);
            this.tpPlaylists.Name = "tpPlaylists";
            this.tpPlaylists.Padding = new System.Windows.Forms.Padding(3);
            this.tpPlaylists.Size = new System.Drawing.Size(961, 439);
            this.tpPlaylists.TabIndex = 2;
            this.tpPlaylists.Text = "Playlists";
            this.tpPlaylists.UseVisualStyleBackColor = true;
            // 
            // btnPlay
            // 
            this.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlay.Location = new System.Drawing.Point(16, 493);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(102, 37);
            this.btnPlay.TabIndex = 1;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            // 
            // btnPause
            // 
            this.btnPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPause.Location = new System.Drawing.Point(124, 493);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(102, 37);
            this.btnPause.TabIndex = 2;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            // 
            // tbVolume
            // 
            this.tbVolume.Location = new System.Drawing.Point(849, 496);
            this.tbVolume.Maximum = 100;
            this.tbVolume.Name = "tbVolume";
            this.tbVolume.Size = new System.Drawing.Size(104, 45);
            this.tbVolume.TabIndex = 3;
            this.tbVolume.Value = 50;
            // 
            // lblVolume
            // 
            this.lblVolume.AutoSize = true;
            this.lblVolume.Location = new System.Drawing.Point(795, 507);
            this.lblVolume.Name = "lblVolume";
            this.lblVolume.Size = new System.Drawing.Size(48, 13);
            this.lblVolume.TabIndex = 4;
            this.lblVolume.Text = "Volume :";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(293, 496);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(447, 45);
            this.trackBar1.TabIndex = 5;
            this.trackBar1.Value = 50;
            // 
            // lblTimeMax
            // 
            this.lblTimeMax.AutoSize = true;
            this.lblTimeMax.Location = new System.Drawing.Point(746, 505);
            this.lblTimeMax.Name = "lblTimeMax";
            this.lblTimeMax.Size = new System.Drawing.Size(40, 13);
            this.lblTimeMax.TabIndex = 6;
            this.lblTimeMax.Text = "00 : 00";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(247, 505);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(40, 13);
            this.lblTime.TabIndex = 7;
            this.lblTime.Text = "00 : 00";
            // 
            // lblVolumeValue
            // 
            this.lblVolumeValue.AutoSize = true;
            this.lblVolumeValue.Location = new System.Drawing.Point(959, 505);
            this.lblVolumeValue.Name = "lblVolumeValue";
            this.lblVolumeValue.Size = new System.Drawing.Size(19, 13);
            this.lblVolumeValue.TabIndex = 8;
            this.lblVolumeValue.Text = "50";
            // 
            // btnSearch
            // 
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(330, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(114, 31);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "Recherche";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // tbxSearch
            // 
            this.tbxSearch.Location = new System.Drawing.Point(92, 16);
            this.tbxSearch.Name = "tbxSearch";
            this.tbxSearch.Size = new System.Drawing.Size(232, 20);
            this.tbxSearch.TabIndex = 10;
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(9, 19);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(66, 13);
            this.lblSearch.TabIndex = 11;
            this.lblSearch.Text = "Recherche :";
            // 
            // lsbMusiques
            // 
            this.lsbMusiques.FormattingEnabled = true;
            this.lsbMusiques.Location = new System.Drawing.Point(6, 51);
            this.lsbMusiques.Name = "lsbMusiques";
            this.lsbMusiques.Size = new System.Drawing.Size(949, 342);
            this.lsbMusiques.TabIndex = 12;
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
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(993, 554);
            this.Controls.Add(this.lblVolumeValue);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblTimeMax);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.lblVolume);
            this.Controls.Add(this.tbVolume);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmMain";
            this.Text = "SoundStream";
            this.tabControl1.ResumeLayout(false);
            this.tpMusic.ResumeLayout(false);
            this.tpMusic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpMusic;
        private System.Windows.Forms.TabPage tpFavorites;
        private System.Windows.Forms.TabPage tpPlaylists;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.TrackBar tbVolume;
        private System.Windows.Forms.Label lblVolume;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label lblTimeMax;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblVolumeValue;
        private System.Windows.Forms.Button btnAddFavorites;
        private System.Windows.Forms.ListBox lsbMusiques;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox tbxSearch;
        private System.Windows.Forms.Button btnSearch;
    }
}

