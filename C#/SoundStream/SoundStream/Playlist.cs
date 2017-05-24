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

namespace SoundStream
{
    public class Playlist
    {
        #region Fields
        private int _id;
        private string _name;
        #endregion

        #region Properties
        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

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
        #endregion

        #region Methods

        #region Constructor
        public Playlist(int pId, string pName)
        {
            this.Id = pId;
            this.Name = pName;
        }
        #endregion

        #endregion
    }
}
