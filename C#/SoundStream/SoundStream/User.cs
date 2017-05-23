/*
Auteur : N'hairi Ilias
Version : 1.0
Date : 23.05.2017
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundStream
{
    public class User
    {
        #region Fields
        private int _id;
        private string _pseudo;
        #endregion

        #region Properties
        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string Pseudo
        {
            get
            {
                return _pseudo;
            }

            set
            {
                _pseudo = value;
            }
        }
        #endregion

        #region Methods

        #region Constructor
        public User(int id, string pseudo)
        {
            this.Id = id;
            this.Pseudo = pseudo;
        }
        #endregion

        #endregion
    }
}
