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
        private string _name;
        private List<int> _musics;
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

        public List<int> Musics
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
        #endregion

        #region Methods

        #region Constructor
        public Playlist(string pName, List<int> pMusics)
        {
            this.Name = pName;
            this.Musics = pMusics;
        }
        #endregion

        #endregion
    }
}
