/*
Author : N'hairi Ilias
Version : 1.0
Date : 23.05.2017
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql;

namespace SoundStream
{
    /// <summary>
    /// The Db class is used to connect to the database and to execute requests
    /// </summary>
    public class Db
    {
        #region Fields
        private string _user;
        private string _pass;
        private string _adress;
        private string _database;
        private MySqlConnection _connection;
        #endregion

        #region Properties
        public string User
        {
            get { return _user; }
            set { _user = value; }
        }
        public string Pass
        {
            get { return _pass; }
            set { _pass = value; }
        }
        public string Adress
        {
            get { return _adress; }
            set { _adress = value; }
        }
        public string Database
        {
            get { return _database; }
            set { _database = value; }
        }
        private MySqlConnection Connection
        {
            get { return _connection; }
            set { _connection = value; }
        }
        #endregion

        #region Methods

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pAdress">Database ip adress</param>
        /// <param name="pUser">Username for the database</param>
        /// <param name="pPass">The password of the account</param>
        /// <param name="pDatabase">The name of the database</param>
        public Db(string pAdress, string pUser,string pPass,string pDatabase)
        {
            this.Connection = null;
            this.Adress = pAdress;
            this.User = pUser;
            this.Pass = pPass;
            this.Database = pDatabase;
            string connectionString = string.Format(@"server={0};userid={1};password={2};database={3}",this.Adress,this.User,this.Pass,this.Database);
            try
            {
                this.Connection = new MySqlConnection(connectionString);
                this.Connection.Open();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString(),"Erreur " + ex.Source);
            }
        }
        #endregion

        /// <summary>
        /// Check if the connection informations sent by the user are right
        /// </summary>
        /// <param name="pseudo">The username</param>
        /// <param name="pass">The password (MD5)</param>
        /// <returns>Null if the informations are false and return an user object if the informations are right</returns>
        public User TestConnection(string pseudo ,string pass)
        {
            User currentUser = null;
            if (IsConnected())
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM users WHERE pseudoUser = @pseudo AND passUser = @pass", this.Connection);
                cmd.Parameters.AddWithValue("@pseudo", pseudo.ToString());
                cmd.Parameters.AddWithValue("@pass", pass.ToString());
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    currentUser = new User(Convert.ToInt32(reader[0]), reader[1].ToString());
                }
                reader.Close();
            }
            return currentUser;
        }

        /// <summary>
        /// Check if the username is already used
        /// </summary>
        /// <param name="pseudo">The name to check</param>
        /// <returns>A line if</returns>
        public bool AccountAlreadyExists(string pseudo)
        {
            bool userExists = false;
            if (IsConnected())
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM users WHERE pseudoUser = @pseudo", this.Connection);
                cmd.Parameters.AddWithValue("@pseudo", pseudo.ToString());
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    userExists = true;
                }
                reader.Close();
            }
            return userExists;
        }

        /// <summary>
        /// Create an account in the database
        /// </summary>
        /// <param name="pseudo">the new username</param>
        /// <param name="pass">The password of the user hashed in md5</param>
        public void CreateAccount(string pseudo, string pass)
        {
            if (IsConnected())
            {
                MySqlCommand cmd = new MySqlCommand("INSERT INTO users (pseudoUser,passUser,privilegesUser) VALUES (@pseudo,@pass,0)", this.Connection);
                cmd.Parameters.AddWithValue("@pseudo", pseudo.ToString());
                cmd.Parameters.AddWithValue("@pass", pass.ToString());
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Get the music by the artist name or the music title
        /// </summary>
        /// <param name="pTitle">title to search</param>
        /// <param name="pArtist">artist to search</param>
        /// <returns>A list of "MusicData" objects</returns>
        public List<MusicData> GetMusics(string pTitle, string pArtist)
        {
            List<MusicData> output = new List<MusicData>();
            if (IsConnected())
            {
                MySqlCommand cmd = new MySqlCommand("SELECT idMusic,titleMusic,labelType,fileName,nameArtist FROM musics,artists,types WHERE musics.idArtist = artists.idArtist AND musics.idType = types.idType AND (musics.titleMusic = @title OR artists.nameArtist = @artist);", this.Connection);
                cmd.Parameters.AddWithValue("@title", pTitle.ToString());
                cmd.Parameters.AddWithValue("@artist", pArtist.ToString());
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    output.Add(new MusicData(Convert.ToInt32(reader[0]),reader[1].ToString(),reader[2].ToString(),reader[3].ToString(),reader[4].ToString()));
                }
                reader.Close();
            }
            return output;
        }

        /// <summary>
        /// Get the musics from a playlist
        /// </summary>
        /// <param name="pId">The id of the user wich we want the playlists</param>
        /// <returns>A list of "MusicData" objects</returns>
        public List<MusicData> GetPlaylistsMusics(int pId)
        {
            List<MusicData> output = new List<MusicData>();
            if (IsConnected())
            {
                MySqlCommand cmd = new MySqlCommand("SELECT DISTINCT musics.idMusic,musics.titleMusic,types.labelType,musics.fileName,artists.nameArtist,playlists.namePlaylist,playlists.idPlaylist FROM musics,favorites,contain,users,playlists,types,artists WHERE users.idUser = playlists.idUser AND contain.idPlaylist = playlists.idPlaylist AND contain.idMusic = musics.idMusic AND users.idUser = @id AND types.idType = musics.idType AND musics.idArtist = artists.idArtist", this.Connection);
                cmd.Parameters.AddWithValue("@id", pId.ToString());
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    output.Add(new MusicData(Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(),reader[5].ToString(),Convert.ToInt32(reader[6])));
                }
                reader.Close();
            }
            return output;
        }

        /// <summary>
        /// Get the favorites musics from a user
        /// </summary>
        /// <param name="pId">The id of the user wich we want the favorites</param>
        /// <returns>A list of "MusicData" objects</returns>
        public List<MusicData> GetFavorites(int pId)
        {
            List<MusicData> output = new List<MusicData>();
            if (IsConnected())
            {
                MySqlCommand cmd = new MySqlCommand("SELECT musics.idMusic,musics.titleMusic,types.labelType,musics.fileName,artists.nameArtist FROM musics,artists,types,users,favorites WHERE musics.idType = types.idType AND musics.idArtist = artists.idArtist AND users.idUser = favorites.idUser AND musics.idMusic = favorites.idMusic AND users.idUser = @id", this.Connection);
                cmd.Parameters.AddWithValue("@id", pId.ToString());
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    output.Add(new MusicData(Convert.ToInt32(reader[0]), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString()));
                }
                reader.Close();
            }
            return output;
        }

        /// <summary>
        /// Get all the titles and artists name for the autocomplete
        /// </summary>
        /// <returns>A list of strings</returns>
        public List<string> GetAutocomplete()
        {
            List<string> output = new List<string>();
            if (IsConnected())
            {
                MySqlCommand cmd = new MySqlCommand("SELECT DISTINCT titleMusic FROM musics", this.Connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    output.Add(reader[0].ToString());
                }
                reader.Close();
                cmd = new MySqlCommand("SELECT DISTINCT nameArtist FROM artists", this.Connection);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    output.Add(reader[0].ToString());
                }
                reader.Close();
            }
            return output;
        }

        /// <summary>
        /// Add a favorite for a user
        /// </summary>
        /// <param name="pIdUser">The user id</param>
        /// <param name="pIdMusic">The music id</param>
        public void AddFavorite(int pIdUser, int pIdMusic)
        {
            if (IsConnected())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO favorites (idUser,idMusic) VALUES (@idUser,@idMusic)", this.Connection);
                    cmd.Parameters.AddWithValue("@idUser", pIdUser.ToString());
                    cmd.Parameters.AddWithValue("@idMusic", pIdMusic.ToString());
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    return;
                }
            }
        }

        /// <summary>
        /// Add a song to a playlist
        /// </summary>
        /// <param name="pIdPlaylist">The id of the playlist to add the song to</param>
        /// <param name="pIdMusic">The id of the music to add</param>
        public void AddToPlaylist(int pIdPlaylist, int pIdMusic)
        {
            if (IsConnected())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO contain (idPlaylist,idMusic) VALUES (@idPlaylist,@idMusic)", this.Connection);
                    cmd.Parameters.AddWithValue("@idPlaylist", pIdPlaylist.ToString());
                    cmd.Parameters.AddWithValue("@idMusic", pIdMusic.ToString());
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    return;
                }
            }
        }

        /// <summary>
        /// Get the informations of all the playlists from a user
        /// </summary>
        /// <param name="pIdUser">The user wich we want the playlists id</param>
        /// <returns>A list of "Playlist" object</returns>
        public List<Playlist> GetPlaylistsData(int pIdUser)
        {
            List<Playlist> output = new List<Playlist>();
            if (IsConnected())
            {
                MySqlCommand cmd = new MySqlCommand("SELECT playlists.namePlaylist,playlists.idPlaylist FROM playlists,users WHERE users.idUser = @id AND playlists.idUser = users.idUser", this.Connection);
                cmd.Parameters.AddWithValue("@id", pIdUser.ToString());
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    output.Add(new Playlist(Convert.ToInt32(reader[1]), reader[0].ToString()));
                }
                reader.Close();
            }
            return output;
        }

        /// <summary>
        /// Delete a music from a playlist
        /// </summary>
        /// <param name="pIdPlaylist">the playlist wich we want to modify</param>
        /// <param name="pIdMusic">The music id to remove</param>
        public void DeleteFromPlaylist(int pIdPlaylist,int pIdMusic)
        {
            if (IsConnected())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM contain WHERE idPlaylist = @idPlaylist AND idMusic = @idMusic", this.Connection);
                    cmd.Parameters.AddWithValue("@idPlaylist", pIdPlaylist.ToString());
                    cmd.Parameters.AddWithValue("@idMusic", pIdMusic.ToString());
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    return;
                }
            }
        }

        /// <summary>
        /// delete a playlist from the database
        /// </summary>
        /// <param name="pIdPlaylist">The id of the playlist we want to delete</param>
        public void DeletePlaylist(int pIdPlaylist)
        {
            if (IsConnected())
            {
                try
                {
                    //First we delete all the song in that playlist to avoid key constraint
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM contain WHERE idPlaylist = @idPlaylist", this.Connection);
                    cmd.Parameters.AddWithValue("@idPlaylist", pIdPlaylist.ToString());
                    cmd.ExecuteNonQuery();
                    cmd = new MySqlCommand("DELETE FROM playlists WHERE idPlaylist = @idPlaylist", this.Connection);
                    cmd.Parameters.AddWithValue("@idPlaylist", pIdPlaylist.ToString());
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    return;
                }
            }
        }

        /// <summary>
        /// Create a playlist if it doesnt already exists for the same user.
        /// </summary>
        /// <param name="pName">The playlist name</param>
        /// <param name="pIdUser">The id of the creator</param>
        public void CreatePlaylist(string pName, int pIdUser)
        {
            if (IsConnected())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO playlists (namePlaylist,idUser) SELECT @name,@idUser WHERE NOT EXISTS (SELECT * FROM playlists WHERE namePlaylist = @name AND idUser = @idUser)", this.Connection);
                    cmd.Parameters.AddWithValue("@name", pName);
                    cmd.Parameters.AddWithValue("@idUser", pIdUser.ToString());
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    return;
                }
            }
        }

        /// <summary>
        /// Delete a music from the favorites of a user
        /// </summary>
        /// <param name="pIdUser">The id of the user</param>
        /// <param name="pIdMusic">The music to remove from the user favorites</param>
        public void DeleteFromFavorites(int pIdUser,int pIdMusic)
        {
            if (IsConnected())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM favorites WHERE idUser = @idUser AND idMusic = @idMusic", this.Connection);
                    cmd.Parameters.AddWithValue("@idMusic", pIdMusic);
                    cmd.Parameters.AddWithValue("@idUser", pIdUser.ToString());
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    return;
                }
            }
        }

        /// <summary>
        /// Check if the connexion to the database is open
        /// </summary>
        /// <returns>True if the application is connected to the database</returns>
        private bool IsConnected()
        {
            return (this.Connection.State == System.Data.ConnectionState.Open);
        }

        /// <summary>
        /// Close the database connetion
        /// </summary>
        public void Close()
        {
            this.Connection.Close();
        }

        #endregion
    }
}
