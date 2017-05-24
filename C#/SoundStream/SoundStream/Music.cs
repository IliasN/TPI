/*
Author : N'hairi Ilias
Version : 1.0
Date : 23.05.2017
*/
using WMPLib;

namespace SoundStream
{
    /// <summary>
    /// This class handles the playing of the music via web links
    /// </summary>
    public class Music
    {
        #region Fields
        private WindowsMediaPlayer _player;
        #endregion

        #region Properties
        public WindowsMediaPlayer Player
        {
            get { return _player; }
            set { _player = value; }
        }
        #endregion

        #region Methods

        #region Constructor
        public Music()
        {
            this.Player = new WindowsMediaPlayer();
            this.SetVolume(50);
        }
        #endregion

        /// <summary>
        /// Start the media
        /// </summary>
        public void Play()
        {
            this.Player.controls.play();
        }

        /// <summary>
        /// Pauses the media
        /// </summary>
        public void Pause()
        {
            this.Player.controls.pause();
        }

        /// <summary>
        /// Stop the media
        /// </summary>
        public void Stop()
        {
            this.Player.controls.stop();
        }

        /// <summary>
        /// Set the volume 
        /// </summary>
        /// <param name="value">Valeur du volume (0-100)</param>
        public void SetVolume(int value)
        {
            this.Player.settings.volume = value;
        }

        /// <summary>
        /// Change the url to get the song
        /// </summary>
        /// <param name="pUrl">URL du média</param>
        public void SetUrl(string pUrl)
        {
            this.Player.URL = pUrl;
            this.Play();
        }

        /// <summary>
        /// Get the media duration
        /// </summary>
        /// <returns>the media duration in secondes</returns>
        public int GetDuration()
        {
            return (int)this.Player.currentMedia.duration;
        }

        /// <summary>
        /// Get the position of the media
        /// </summary>
        /// <returns>the position of the media in secondes</returns>
        public int GetCurrentPosition()
        {
            return (int)this.Player.controls.currentPosition;
        }

        /// <summary>
        /// Change the position of the media
        /// </summary>
        /// <param name="pCurrentToSet">The new position to set in secondes</param>
        public void SetCurrentPosition(int pCurrentToSet)
        {
            this.Player.controls.currentPosition = pCurrentToSet;
        }

        #endregion
    }
}
