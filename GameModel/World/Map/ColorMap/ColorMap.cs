using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialArt.Waves;
using Waves;

namespace CvmFight
{
    class ColorMap
    {
        #region Constants
        private double precision = 0.1;
        #endregion

        #region Fields
        private IWave wavePackRedX;

        private IWave wavePackGreenX;

        private IWave wavePackBlueX;

        private IWave wavePackRedY;

        private IWave wavePackGreenY;

        private IWave wavePackBlueY;

        private ColorMapCache colorMapCacheRed;

        private ColorMapCache colorMapCacheGreen;

        private ColorMapCache colorMapCacheBlue;
        #endregion

        #region Constructor
        public ColorMap(Random random, int width, int height)
        {
            WaveBuilder waveBuilder = new WaveBuilder();

            wavePackRedX = waveBuilder.Build(3, random);
            wavePackGreenX = waveBuilder.Build(3, random);
            wavePackBlueX = waveBuilder.Build(3, random);

            wavePackRedY = waveBuilder.Build(3, random);
            wavePackGreenY = waveBuilder.Build(3, random);
            wavePackBlueY = waveBuilder.Build(3, random);

            colorMapCacheRed = new ColorMapCache(wavePackRedX, wavePackRedY, width, height, precision);
            colorMapCacheGreen = new ColorMapCache(wavePackGreenX, wavePackGreenY, width, height, precision);
            colorMapCacheBlue = new ColorMapCache(wavePackBlueX, wavePackBlueY, width, height, precision);
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// From color map, returns red multiplicator
        /// </summary>
        /// <param name="x">x</param>
        /// <param name="y">x</param>
        /// <returns>red color multiplicator at x,y</returns>
        public double GetRedMultiplicatorAt(double x, double y)
        {
            return colorMapCacheRed.GetRedMultiplicatorAt(x, y);
        }

        /// <summary>
        /// From color map, returns green color multiplicator
        /// </summary>
        /// <param name="x">x</param>
        /// <param name="y">x</param>
        /// <returns>green color multiplicator at x,y</returns>
        public double GetGreenMultiplicatorAt(double x, double y)
        {
            return colorMapCacheGreen.GetRedMultiplicatorAt(x, y);
        }

        /// <summary>
        /// From color map, returns blue color multiplicator
        /// </summary>
        /// <param name="x">x</param>
        /// <param name="y">y</param>
        /// <returns>blue color multiplicator at x,y</returns>
        public double GetBlueMultiplicatorAt(double x, double y)
        {
            return colorMapCacheBlue.GetRedMultiplicatorAt(x, y);
        }
        #endregion
    }
}