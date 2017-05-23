/*
Auteur : N'hairi Ilias
Version : 1.0
Date : 23.05.2017
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoundStream
{
    public partial class frmMain : Form
    {
        #region Fields
        private Db _database;
        private List<MusicData> _musics;
        private List<MusicData> _favorites;
        private List<MusicData> _playlists;
        private List<Playlist> _playlistsData;
        private List<string> _autoComplete;
        private Music _player;
        private User _user;
        private const string URL = "http://127.0.0.1/TPI/Music/";
        private int _playingId;
        #endregion

        #region Properties
        public Db Database
        {
            get
            {
                return _database;
            }

            set
            {
                _database = value;
            }
        }

        public List<MusicData> Musics
        {
            get
            {
                return _musics;
            }

            set
            {
                _musics = value;
            }
        }

        public List<MusicData> Favorites
        {
            get
            {
                return _favorites;
            }

            set
            {
                _favorites = value;
            }
        }

        public List<MusicData> Playlists
        {
            get
            {
                return _playlists;
            }

            set
            {
                _playlists = value;
            }
        }

        public Music Player
        {
            get
            {
                return _player;
            }

            set
            {
                _player = value;
            }
        }

        public User User
        {
            get
            {
                return _user;
            }

            set
            {
                this._user = value;
            }
        }

        public List<string> AutoComplete
        {
            get
            {
                return _autoComplete;
            }

            set
            {
                _autoComplete = value;
            }
        }

        public int PlayingId
        {
            get
            {
                return _playingId;
            }

            set
            {
                _playingId = value;
            }
        }

        public List<Playlist> PlaylistsData
        {
            get
            {
                return _playlistsData;
            }

            set
            {
                _playlistsData = value;
            }
        }
        #endregion

        #region Methods

        #region Constructor
        public frmMain(Db pDatabase, User pUser)
        {
            InitializeComponent();
            this.Database = pDatabase;
            this.User = pUser;
            this.Player = new Music();
            this.PlayingId = -1;
            UpdateData();

        }
        #endregion

        /// <summary>
        /// Cose all the forms when the app closes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Database.Close();
            this.Player.Stop();
            Environment.Exit(0);
        }

        /// <summary>
        /// Get the favorites and the playlists from the database and put them in the listboxs
        /// </summary>
        private void UpdateData()
        {
            //Clear the lists
            lsbFavorites.DataSource = null;
            lsbPlaylist.DataSource = null;
            //Get the playlists and favorites
            this.Playlists = this.Database.GetPlaylistsMusics(this.User.Id);
            this.PlaylistsData = this.Database.GetPlaylistsData(this.User.Id);
            this.Favorites = this.Database.GetFavorites(this.User.Id);
            //Get the autocomplete data and set it up
            this.AutoComplete = this.Database.GetAutocomplete();
            AutoCompleteStringCollection autoCompleteSource = new AutoCompleteStringCollection();
            foreach (var item in this.AutoComplete)
            {
                autoCompleteSource.Add(item);
            }
            tbxSearch.AutoCompleteCustomSource = autoCompleteSource;
            this.AutoComplete.Clear();

            //Show the favorites in the list
            lsbFavorites.DataSource = this.Favorites.Select(music => music.Artist + " - " + music.Title).ToList();

            //Set the combobox sources to the plalists name
            cmbPlaylist.DataSource = this.PlaylistsData.Select(p => p.Name).ToList();
            cmbPlaylistToAdd.DataSource = cmbPlaylist.DataSource;
            //Stop the launching of a song when its loaded
            this.Player.Stop();
        }

        /// <summary>
        /// Search when the user clicks on the "Recherche" button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        /// <summary>
        /// Get the result of the search in the database then put it in the listbox
        /// </summary>
        private void Search()
        {
            this.Musics = this.Database.GetMusics(tbxSearch.Text, tbxSearch.Text);
            lsbMusiques.DataSource = this.Musics.Select(music => music.Artist + " - " + music.Title).ToList();
            tcMain.SelectedIndex = 2;
            this.Player.Stop();
        }

        /// <summary>
        /// When the user is typing and presses "Enter" start the serch method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }

        /// <summary>
        /// Play the song that have been selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lsbMusiques_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsbMusiques.SelectedIndex != -1)
            {
                //Get the id of the playing music
                this.PlayingId = this.Musics.First(m => m.Artist + " - " + m.Title == lsbMusiques.Items[lsbMusiques.SelectedIndex].ToString()).Id;
                //Load the music
                this.Player.SetUrl(URL + this.Musics.First(m => m.Id == this.PlayingId).FileName);
                //Show the title of the music on the screen
                lblTitle.Text = lsbMusiques.Items[lsbMusiques.SelectedIndex].ToString();
                this.Player.Play();
            }
        }

        /// <summary>
        /// Change the volume
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbVolume_Scroll(object sender, EventArgs e)
        {
            lblVolumeValue.Text = tbVolume.Value.ToString();
            this.Player.SetVolume(tbVolume.Value);
        }

        /// <summary>
        /// Start the music
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPlay_Click(object sender, EventArgs e)
        {
            this.Player.Play();
        }

        /// <summary>
        /// Pause the music
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPause_Click(object sender, EventArgs e)
        {
            this.Player.Pause();
        }

        /// <summary>
        /// Play the music when selected in the listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lsbFavorites_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsbFavorites.SelectedIndex != -1)
            {
                //Recupere l'id de la music en cours
                this.PlayingId = this.Favorites.First(m => m.Artist + " - " + m.Title == lsbFavorites.Items[lsbFavorites.SelectedIndex].ToString()).Id;
                //Charge la musique
                this.Player.SetUrl(URL + this.Favorites.First(m => m.Id == this.PlayingId).FileName);
                //Affiche le nom de la musique
                lblTitle.Text = lsbFavorites.Items[lsbFavorites.SelectedIndex].ToString();
                this.Player.Play();
            }
        }

        /// <summary>
        /// Load the songs in the playlist listbox when the combobox is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbPlaylist_SelectedIndexChanged(object sender, EventArgs e)
        {
            lsbPlaylist.DataSource = this.Playlists.Where(m => m.Playlist == cmbPlaylist.Text).Select(m => m.Artist + " - " + m.Title).ToList();
        }

        /// <summary>
        /// Update the timebar and all it's labels
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrMain_Tick(object sender, EventArgs e)
        {
            SetTimeBar();
        }

        /// <summary>
        /// Update the trabar data
        /// </summary>
        private void SetTimeBar()
        {
            //Check if a music is playing
            if (this.PlayingId != -1)
            {
                tbTime.Maximum = this.Player.GetDuration() + 1;
                tbTime.Value = this.Player.GetCurrentPosition();
                lblTimeMax.Text = SecondesToMMSS(this.Player.GetDuration());
                lblTime.Text = SecondesToMMSS(this.Player.GetCurrentPosition());
            }
        }

        /// <summary>
        /// Change the current time of the music
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbTime_Scroll(object sender, EventArgs e)
        {
            this.Player.SetCurrentPosition(tbTime.Value);
        }

        /// <summary>
        /// Convert secondes into a mm:ss format
        /// </summary>
        /// <param name="pSec">Secondes to convert</param>
        /// <returns>The string in the format mm:ss</returns>
        private string SecondesToMMSS(int pSec)
        {
            int minutes = pSec / 60;
            int secondes = pSec - ((pSec / 60) * 60);
            if (secondes < 10)
                return string.Format("{0}:{1}", minutes.ToString(), "0" + secondes.ToString());
            return string.Format("{0}:{1}", minutes.ToString(), secondes.ToString());
        }

        /// <summary>
        /// Play the music when selected in the listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lsbPlaylist_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsbPlaylist.SelectedIndex != -1)
            {
                //Recupere l'id de la music en cours
                this.PlayingId = this.Playlists.First(m => m.Artist + " - " + m.Title == lsbPlaylist.Items[lsbPlaylist.SelectedIndex].ToString()).Id;
                //Charge la musique
                this.Player.SetUrl(URL + this.Playlists.First(m => m.Id == this.PlayingId).FileName);
                //Affiche le nom de la musique
                lblTitle.Text = lsbPlaylist.Items[lsbPlaylist.SelectedIndex].ToString();
                this.Player.Play();

            }
        }

        /// <summary>
        /// Add a music in the favorites when the user clicks the button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddFavorites_Click(object sender, EventArgs e)
        {
            this.Database.AddFavorite(this.User.Id, this.PlayingId);
            UpdateData();
        }

        /// <summary>
        /// Create a new playlist when the user clicks the button if the name isn't empty
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddToPlaylist_Click(object sender, EventArgs e)
        {
            if (cmbPlaylistToAdd.Text != "")
            {
                this.Database.AddToPlaylist(this.PlaylistsData.First(p => p.Name == cmbPlaylistToAdd.Text).Id, this.PlayingId);
                UpdateData();
            }
            else
                MessageBox.Show("Il faut d'abord sélectionner une playlist.");
        }

        /// <summary>
        /// Delete a song from a playlist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelFromPlaylist_Click(object sender, EventArgs e)
        {
            if (cmbPlaylist.Text != "")
            {
                this.Database.DeleteFromPlaylist(this.PlaylistsData.First(p => p.Name == cmbPlaylist.Text).Id, this.PlayingId);
                UpdateData();
            }
        }

        /// <summary>
        /// Delete a playlist after a messagbox confirms the operation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeletePlaylist_Click(object sender, EventArgs e)
        {
            if (cmbPlaylist.Text != "")
            {
                DialogResult result = MessageBox.Show("Voulez vous vraiment supprimer " + cmbPlaylist.Text + " de vos playlist ?", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    this.Database.DeletePlaylist(this.PlaylistsData.First(p => p.Name == cmbPlaylist.Text).Id);
                    UpdateData();
                }
            }
        }

        /// <summary>
        /// Create a playlist when the button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreatePlaylist_Click(object sender, EventArgs e)
        {
            AddPlaylist();
        }

        /// <summary>
        /// Create a playlist 
        /// </summary>
        private void AddPlaylist()
        {
            if (tbxNewPlaylist.Text.Trim() != "")
            {
                this.Database.CreatePlaylist(tbxNewPlaylist.Text, this.User.Id);
                tbxNewPlaylist.Clear();
                UpdateData();
            }
            else
            {
                MessageBox.Show("Impossible de créer une playlist avec ce nom.");
            }
        }

        /// <summary>
        /// When "Enter" is pressed in the new playlist textbox create the playlist
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbxNewPlaylist_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                AddPlaylist();
        }

        /// <summary>
        /// Delete a music from the favorites
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveFav_Click(object sender, EventArgs e)
        {
            this.Database.DeleteFromFavorites(this.User.Id, this.PlayingId);
            UpdateData();
        }

        #endregion


    }
}
