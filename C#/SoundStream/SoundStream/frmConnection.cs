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
        private Db _database;
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
        #endregion

        #region Methods

        #region Constructor
        public frmConnection()
        {
            InitializeComponent();
            this.Database = new Db("127.0.0.1", "root", "", "tpi");
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
                User testUser = this.Database.TestConnection(tbxName.Text, PasswordHash(tbxPass.Text));
                if (testUser != null)
                {
                    frmMain mainWindow = new frmMain(this.Database,testUser);
                    this.Hide();
                    mainWindow.ShowDialog();
                    return;
                }
            }
            if (tbxName.Text != "" && tbxPass.Text != "" && tbxConfPass.Text != "" && tbxConfPass.Text == tbxPass.Text && btnAccept.Text == "Inscription" && this.Database.TestConnection(tbxName.Text, PasswordHash(tbxPass.Text)) == null)
            {
                this.Database.CreateAccount(tbxName.Text, PasswordHash(tbxPass.Text));
                MessageBox.Show("Votre compte a bien été crée");
            }
            else
            {
                MessageBox.Show("Votre compte n'a pas pu être crée.");
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
