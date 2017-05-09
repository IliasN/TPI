using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql;

namespace MiniTPI
{
    /// <summary>
    /// La classe BDD sert à se connecter à la base de données et à executer des requetes
    /// </summary>
    public class BDD
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
        public BDD(string pAdress, string pUser,string pPass,string pDatabase)
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
        /// Effectue une requete dans la base de données puis retourne le resultat
        /// </summary>
        /// <param name="pQuery">La requete SQL</param>
        /// <returns>Une liste de résultats</returns>
        public List<string[]> Query(string pQuery)
        {
            if (this.Connection.State == System.Data.ConnectionState.Open)
            {
                List<string[]> data = new List<string[]>();
                string query = pQuery;
                MySqlCommand cmd = new MySqlCommand(query, this.Connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    List<string> tmp = new List<string>();
                    for (int i = 0; i < reader.VisibleFieldCount; i++)
                    {
                        tmp.Add(reader.GetValue(i).ToString());
                    }
                    data.Add(tmp.ToArray());
                }
                reader.Close();
                return data;
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("La connexion à la base de données n'est pas ouverte", "Erreur");
                return null;
            }
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
