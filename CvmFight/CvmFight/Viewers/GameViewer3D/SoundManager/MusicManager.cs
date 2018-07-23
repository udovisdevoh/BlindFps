using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SdlDotNet.Audio;

namespace CvmFight
{
    class MusicManager
    {
        #region Fields
        private Random random;

        private List<string> musicFileNameList;

        private Dictionary<string, Music> musicCache;
        #endregion

        #region Constructor
        public MusicManager(Random random)
        {
            musicCache = new Dictionary<string, Music>();
            MusicPlayer.EnableMusicFinishedCallback();
            this.random = random;
            musicFileNameList = new List<string>();
            musicFileNameList.Add("CvmFight/Assets/Musics/iCanFeelItHey.ogg");
            musicFileNameList.Add("CvmFight/Assets/Musics/WaveBuilder - Made in indonesia.ogg");
            musicFileNameList.Add("CvmFight/Assets/Musics/WaveBuilder - Epic JediHads.ogg");
            musicFileNameList.Add("CvmFight/Assets/Musics/WaveBuilder - Gypsy Orion.ogg");
            musicFileNameList.Add("CvmFight/Assets/Musics/WaveBuilder - MadeInJapan.ogg");
        }
        #endregion

        #region Public Methods
        public void PlayRandomMusic()
        {
            string musicFileName = musicFileNameList[random.Next(musicFileNameList.Count)];
            Music music;
            if (!musicCache.TryGetValue(musicFileName, out music))
            {
                music = new Music(musicFileName);
                musicCache.Add(musicFileName, music);
            }

            music.Play();
        }
        #endregion
    }
}
