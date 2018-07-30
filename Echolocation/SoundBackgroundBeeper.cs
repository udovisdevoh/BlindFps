using SdlDotNet.Audio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlindFPS
{
    public class SoundBackgroundBeeper
    {
        private Dictionary<int, Sound> sounds;

        private int[] frequencies;

        public SoundBackgroundBeeper()
        {
            this.sounds = new Dictionary<int, Sound>();
            Mixer.ChannelsAllocated = 64;

            string[] files = Directory.GetFiles("Assets/Audio");

            foreach (string file in files)
            {
                if (file.ToLowerInvariant().EndsWith(".wav"))
                {
                    int indexOfWav = file.ToLowerInvariant().IndexOf(".wav");
                    string frequencyDescription = file.ToLowerInvariant().Substring(0, indexOfWav);
                    int indexOfSine = frequencyDescription.IndexOf("sine_");
                    frequencyDescription = frequencyDescription.Substring(indexOfSine + 5);
                    int frequency = int.Parse(frequencyDescription);
                    Sound sound = new Sound(file);
                    sounds.Add(frequency, sound);
                }
            }

            this.frequencies = new int[this.sounds.Count];

            int index = 0;
            foreach (int frequency in this.sounds.Keys.OrderBy(frequency => frequency))
            {
                this.frequencies[index] = frequency;
                ++index;
            }
        }

        public void Play(int frequency, byte volume, byte left, byte right)
        {
            frequency = this.GetClosestAvailableFrequency(frequency);
            try
            {
                Channel channel = this.sounds[frequency].Play();
                channel.SetPanning(left, right);
                channel.Volume = volume;
            }
            catch (Exception)
            {
                // Nothing
            }
        }

        private int GetClosestAvailableFrequency(int desiredFrequency)
        {
            int closestFrequency = this.frequencies[0];
            for (int index = 0; index < this.frequencies.Length; ++index)
            {
                if (desiredFrequency < closestFrequency)
                {
                    return closestFrequency;
                }

                closestFrequency = this.frequencies[index];
            }

            return closestFrequency;
        }
    }
}
