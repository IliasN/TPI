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
        #endregion

        #region Methods

        #region Constructor
        public MusicData(int id,string title,string type,string filename)
        {
            this.Id = id;
            this.Title = title;
            this.Type = type;
            this.FileName = filename;
        }
        #endregion

        #endregion
    }
}
