using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace SoundStream
{
    /// <summary>
    /// La classe musique sert à créer un lecteur et à lire la musique depuis un URL http
    /// </summary>
    public class Music
    {
        #region Fields
        private WindowsMediaPlayer _player;
        public event EventHandler<MyEventArgs> StateChanged;
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
            this.Player.PlayStateChange += Wplayer_PlayStateChange;
        }
        #endregion

        /// <summary>
        /// Lance le media
        /// </summary>
        public void Play()
        {
            this.Player.controls.play();
        }

        /// <summary>
        /// Met le media en pause en cours
        /// </summary>
        public void Pause()
        {
            this.Player.controls.pause();
        }

        /// <summary>
        /// Stop le media en cours
        /// </summary>
        public void Stop()
        {
            this.Player.controls.stop();
        }

        /// <summary>
        /// Règle le volume 
        /// </summary>
        /// <param name="value">Valeur du volume (0-100)</param>
        public void SetVolume(int value)
        {
            this.Player.settings.volume = value;
        }

        /// <summary>
        /// Quand l'état du lecteur change renvoi l'état
        /// </summary>
        /// <param name="NewState">Le nouvel état</param>
        private void Wplayer_PlayStateChange(int NewState)
        {
            EventHandler<MyEventArgs> handler = StateChanged;
            MyEventArgs args = new MyEventArgs();
            args.Value = NewState;
            handler(this,args);
        }

        /// <summary>
        /// Entre l'URL du média à lire
        /// </summary>
        /// <param name="pUrl">URL du média</param>
        public void SetUrl(string pUrl)
        {
            this.Player.URL = pUrl;
            this.Play();
        }

        /// <summary>
        /// Récupère la durée du média
        /// </summary>
        /// <returns>La durée du média en secondes</returns>
        public int GetDuration()
        {
            return (int)this.Player.currentMedia.duration;
        }

        /// <summary>
        /// Récupère la position du lecteur dans le média
        /// </summary>
        /// <returns>la position du lecteur dans le média en secondes</returns>
        public int GetCurrentPosition()
        {
            return (int)this.Player.controls.currentPosition;
        }

        /// <summary>
        /// Change la position du lecteur dans le média
        /// </summary>
        /// <param name="pCurrentToSet"></param>
        public void SetCurrentPosition(int pCurrentToSet)
        {
            this.Player.controls.currentPosition = pCurrentToSet;
        }

        #endregion
    }

    public class MyEventArgs : EventArgs
    {
        private int _value;

        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }
    }
}
