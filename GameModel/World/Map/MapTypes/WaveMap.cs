using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialArt.Waves;
using Waves;

namespace CvmFight
{
    class WaveMap : AbstractMap
    {
        #region Parts
        /// <summary>
        /// Hard coded map used as seed for wave interference
        /// </summary>
        private HardCodedMap hardCodedMap = new HardCodedMap();

        /// <summary>
        /// To add interference on x axis
        /// </summary>
        private IWave waveX;

        /// <summary>
        /// To add interference on y axis
        /// </summary>
        private IWave waveY;
        #endregion

        #region Constructors
        /// <summary>
        /// Create wave map
        /// </summary>
        /// <param name="random">random number generator</param>
        public WaveMap(Random random)
        {
            WaveBuilder wavePackBuilder = new WaveBuilder();
            waveX = wavePackBuilder.Build(3, random);
            waveY = wavePackBuilder.Build(3, random);
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Returns matter type at specified coordinates, null if empty space
        /// </summary>
        /// <param name="x">x</param>
        /// <param name="y">y</param>
        /// <returns>matter type at specified coordinates, null if empty space</returns>
        public override AbstractMatterType GetMatterTypeAt(double x, double y)
        {
            AbstractMatterType hardCodedMatterType = hardCodedMap.GetMatterTypeAt(x, y);
            if (hardCodedMatterType == null)
                return null;

            x += waveX[Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2))];
            y += waveY[Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2))];

            while (x < 0)
                x += hardCodedMap.Width;
            while (x >= hardCodedMap.Width)
                x -= hardCodedMap.Width;
            while (y < 0)
                y += hardCodedMap.Height;
            while (y >= hardCodedMap.Height)
                y -= hardCodedMap.Height;

            return hardCodedMap.GetMatterTypeAt(x, y);
        }

        public override void GetColors(double x, double y, double originalBrightness, out double red, out double green, out double blue)
        {
            red = originalBrightness;
            green = originalBrightness;
            blue = originalBrightness;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Map's width
        /// </summary>
        public override int Width
        {
            get { return hardCodedMap.Width; }
        }

        /// <summary>
        /// Map's height
        /// </summary>
        public override int Height
        {
            get { return hardCodedMap.Height; }
        }
        #endregion
    }
}