using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SdlDotNet.Audio;

namespace CvmFight
{
    class CachedSound
    {
        #region Fields
        private Sound sound = null;

        private string soundFileName;
        #endregion

        #region Constructor
        public CachedSound(string soundFileName)
        {
            this.soundFileName = soundFileName;
            GetSound();
        }
        #endregion

        #region Public Method
        public Sound GetSound()
        {
            if (sound == null)
                sound = new Sound(soundFileName);

            return sound;
        }
        #endregion
    }
}
