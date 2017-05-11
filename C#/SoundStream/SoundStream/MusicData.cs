using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundStream
{
    public class MusicData
    {
        #region Fields
        private int _id;
        private string _title;
        private string _type;
        private string _fileName;
        private string _artist;
        private string _playlist;
        private int _idPlaylist;
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

        public string Title
        {
            get
            {
                return _title;
            }

            set
            {
                _title = value;
            }
        }

        public string Type
        {
            get
            {
                return _type;
            }

            set
            {
                _type = value;
            }
        }

        public string FileName
        {
            get
            {
                return _fileName;
            }

            set
            {
                _fileName = value;
            }
        }

        public string Artist
        {
            get
            {
                return _artist;
            }

            set
            {
                _artist = value;
            }
        }

        public string Playlist
        {
            get
            {
                return _playlist;
            }

            set
            {
                _playlist = value;
            }
        }

        public int IdPlaylist
        {
            get
            {
                return _idPlaylist;
            }

            set
            {
                _idPlaylist = value;
            }
        }
        #endregion

        #region Methods

        #region Constructor
        public MusicData(int id,string title,string type,string filename,string artist,string playlist = "",int pIdPlaylist = -1)
        {
            this.Id = id;
            this.Title = title;
            this.Type = type;
            this.FileName = filename;
            this.Artist = artist;
            this.Playlist = playlist;
            this.IdPlaylist = pIdPlaylist;
        }
        #endregion

        #endregion
    }
}
