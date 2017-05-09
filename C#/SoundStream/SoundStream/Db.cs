﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql;

namespace SoundStream
{
    /// <summary>
    /// La classe BDD sert à se connecter à la base de données et à executer des requetes
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

        public List<MusicData> GetMusics()
        {
            List<MusicData> output = new List<MusicData>();
            if (IsConnected())
            {
                MySqlCommand cmd = new MySqlCommand("SELECT idMusic,titleMusic,labelType,fileName,nameArtist FROM musics,artists,types WHERE musics.idArtist = artists.idArtist AND musics.idType = types.idType;", this.Connection);
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
        /// Check if the connexion to the database is open
        /// </summary>
        /// <returns>True if the application is connected to the database</returns>
        private bool IsConnected()
        {
            return (this.Connection.State == System.Data.ConnectionState.Open);
        }

        /// <summary>
        /// Ferme la base de données
        /// </summary>
        public void Close()
        {
            this.Connection.Close();
        }

        #endregion
    }
}
