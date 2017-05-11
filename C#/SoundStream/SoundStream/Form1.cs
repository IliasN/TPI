﻿using System;
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

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void UpdateData()
        {
            //Recuperation des playlists et favoris
            this.Playlists = this.Database.GetPlaylistsMusics(this.User.Id);
            this.Favorites = this.Database.GetFavorites(this.User.Id);
            //Recuperation et application de l'autocomplete pour la recherche
            this.AutoComplete = this.Database.GetAutocomplete();
            AutoCompleteStringCollection autoCompleteSource = new AutoCompleteStringCollection();
            foreach (var item in this.AutoComplete)
            {
                autoCompleteSource.Add(item);
            }
            tbxSearch.AutoCompleteCustomSource = autoCompleteSource;
            this.AutoComplete.Clear();

            //Affichage favoris
            lsbFavorites.DataSource = this.Favorites.Select(music => music.Artist + " - " + music.Title).ToList();

            //Recupere les noms des playlists
            cmbPlaylist.DataSource = this.Playlists.GroupBy(m => m.Playlist).Select(grp => grp.First().Playlist).ToList();
            cmbPlaylistToAdd.DataSource = cmbPlaylist.DataSource;
            //Empeche de lancer une musique automatiquement
            this.Player.Stop();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            this.Musics = this.Database.GetMusics(tbxSearch.Text, tbxSearch.Text);
            lsbMusiques.DataSource = this.Musics.Select(music => music.Artist + " - " + music.Title).ToList();
            tcMain.SelectedIndex = 2;
            this.Player.Stop();
        }

        private void tbxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }

        private void lsbMusiques_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Recupere l'id de la music en cours
            this.PlayingId = this.Musics.First(m => m.Artist + " - " + m.Title == lsbMusiques.Items[lsbMusiques.SelectedIndex].ToString()).Id;
            //Charge la musique
            this.Player.SetUrl(URL + this.Musics.First(m => m.Id == this.PlayingId).FileName);
            //Affiche le nom de la musique
            lblTitle.Text = lsbMusiques.Items[lsbMusiques.SelectedIndex].ToString();
            this.Player.Play();
        }

        private void tbVolume_Scroll(object sender, EventArgs e)
        {
            lblVolumeValue.Text = tbVolume.Value.ToString();
            this.Player.SetVolume(tbVolume.Value);
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            this.Player.Play();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            this.Player.Pause();
        }

        private void lsbFavorites_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Recupere l'id de la music en cours
            this.PlayingId = this.Favorites.First(m => m.Artist + " - " + m.Title == lsbFavorites.Items[lsbFavorites.SelectedIndex].ToString()).Id;
            //Charge la musique
            this.Player.SetUrl(URL + this.Favorites.First(m => m.Id == this.PlayingId).FileName);
            //Affiche le nom de la musique
            lblTitle.Text = lsbFavorites.Items[lsbFavorites.SelectedIndex].ToString();
            this.Player.Play();
        }

        private void cmbPlaylist_SelectedIndexChanged(object sender, EventArgs e)
        {
            lsbPlaylist.DataSource = this.Playlists.Where(m => m.Playlist == cmbPlaylist.Text).Select(m => m.Artist + " - " + m.Title).ToList();
        }

        private void tmrMain_Tick(object sender, EventArgs e)
        {
            SetTimeBar();
        }

        private void SetTimeBar()
        {
            if (this.PlayingId != -1)
            {
                tbTime.Maximum = this.Player.GetDuration() + 1;
                tbTime.Value = this.Player.GetCurrentPosition();
                lblTimeMax.Text = SecondesToMMSS(this.Player.GetDuration());
                lblTime.Text = SecondesToMMSS(this.Player.GetCurrentPosition());
            }
        }

        private void tbTime_Scroll(object sender, EventArgs e)
        {
            this.Player.SetCurrentPosition(tbTime.Value);
        }

        private string SecondesToMMSS(int pSec)
        {
            int minutes = pSec / 60;
            int secondes = pSec - ((pSec / 60) * 60);
            if (secondes < 10)
                return string.Format("{0}:{1}", minutes.ToString(), "0" + secondes.ToString());
            return string.Format("{0}:{1}", minutes.ToString(), secondes.ToString());
        }

        private void lsbPlaylist_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Recupere l'id de la music en cours
            this.PlayingId = this.Playlists.First(m => m.Artist + " - " + m.Title == lsbPlaylist.Items[lsbPlaylist.SelectedIndex].ToString()).Id;
            //Charge la musique
            this.Player.SetUrl(URL + this.Playlists.First(m => m.Id == this.PlayingId).FileName);
            //Affiche le nom de la musique
            lblTitle.Text = lsbPlaylist.Items[lsbPlaylist.SelectedIndex].ToString();
            this.Player.Play();
        }

        private void btnAddFavorites_Click(object sender, EventArgs e)
        {
            this.Database.AddFavorite(this.User.Id, this.PlayingId);
            UpdateData();
        }

        private void btnAddToPlaylist_Click(object sender, EventArgs e)
        {
            if (cmbPlaylistToAdd.Text != "")
            {
                this.Database.AddToPlaylist(this.Playlists.First(p => p.Playlist == cmbPlaylistToAdd.Text).IdPlaylist, this.PlayingId);
                UpdateData();
            }
            else
                MessageBox.Show("Il faut d'abord sélectionner une playlist.");
        }

        #endregion


    }
}
