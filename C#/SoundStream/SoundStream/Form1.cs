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
        private List<int> _favorites;
        private List<Playlist> _playlists;
        private Music _player;
        private User _user;
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

        public List<int> Favorites
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

        public List<Playlist> Playlists
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
        #endregion

        #region Methods

        #region Constructor
        public frmMain(Db pDatabase,User pUser)
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
            this.Musics = this.Database.GetMusics();
            this.Playlists = this.Database.GetPlaylists(this.User.Id);
            this.Favorites = this.Database.GetFavorites(this.User.Id);
        }

        #endregion
    }
}
