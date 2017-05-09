using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace SoundStream
{
    public partial class frmConnection : Form
    {
        #region Fields$
        private BDD _database;
        #endregion

        #region Properties
        public BDD Database
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
        #endregion

        #region Methods

        #region Constructor
        public frmConnection()
        {
            InitializeComponent();
            this.Database = new BDD("127.0.0.1", "root", "", "tpi");
        }
        #endregion

        private void llblSwitch_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tbxConfPass.Visible = !tbxConfPass.Visible;
            lblConfirmPass.Visible = !lblConfirmPass.Visible;
            if(btnAccept.Text == "Connexion")
            {
                btnAccept.Text = "Inscription";
                llblSwitch.Text = "Connexion";
            }
            else
            {
                btnAccept.Text = "Connexion";
                llblSwitch.Text = "Inscription";
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (btnAccept.Text == "Connexion")
            {
                if (this.Database.TestConnection(tbxName.Text, PasswordHash(tbxPass.Text)) != null)
                {
                    MessageBox.Show("Connexion reussie");
                }
            }
            else
            {

            }
        }

        /// <summary>
        /// https://coderwall.com/p/4puszg/c-convert-string-to-md5-hash
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private string PasswordHash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }

        #endregion
    }
}
