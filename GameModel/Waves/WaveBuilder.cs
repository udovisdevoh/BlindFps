using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialArt.Waves;

namespace Waves
{
    class WaveBuilder
    {
        #region Public Methods
        /// <summary>
        /// Create a wavepack
        /// </summary>
        /// <param name="waveCount">how many wave in wave pack</param>
        /// <param name="random">random number generator</param>
        /// <returns>wave pack</returns>
        public IWave Build(int waveCount, Random random)
        {
            WavePack wavePack = new WavePack();
            for (int i = 0; i < waveCount; i++)
            {
                WaveFunction waveFunction = WaveFunctions.GetRandomWaveFunction(random,true);
                double phase = (random.NextDouble() * 2.0) - 1.0;
                double amplitude = random.NextDouble();
                double frequency = random.NextDouble();
                wavePack.Add(new Wave(amplitude,frequency,phase));
            }
            wavePack.Normalize();
            return wavePack;
        }
        #endregion
    }
}
