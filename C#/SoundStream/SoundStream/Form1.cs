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
            this.Playlists = this.Database.GetPlaylists(this.User.Id);
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


        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            this.Musics = this.Database.GetMusics(tbxSearch.Text, tbxSearch.Text);
            lsbMusiques.DataSource = this.Musics.Select(music => music.Artist + " - " + music.Title).ToList();
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

        #endregion


    }
}
