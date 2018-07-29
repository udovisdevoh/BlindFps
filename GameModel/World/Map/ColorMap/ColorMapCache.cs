using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArtificialArt.Waves;

namespace CvmFight
{
    class ColorMapCache
    {
        #region Fields
        private double precision;

        private double[,] internalData;
        #endregion

        #region Constructor
        public ColorMapCache(IWave waveX, IWave waveY, int width, int height, double precision)
        {
            this.precision = precision;

            int intWidth = (int)Math.Ceiling(width / precision);
            int intHeight = (int)Math.Ceiling(height / precision);

            internalData = new double[intWidth, intHeight];

            double value;
            for (int x = 0; x < intWidth; x++)
            {
                for (int y = 0; y < intHeight; y++)
                {
                    value = waveX[x / 100.0] + waveY[y / 100.0];

                    while (value > 1.0)
                        value -= 1.0;

                    while (value < 0)
                        value += 1.0;

                    internalData[x, y] = (value + 1.0) / 2.0;
                }
            }
        }
        #endregion

        #region Public Methods
        public double GetRedMultiplicatorAt(double x, double y)
        {
            int intX = (int)Math.Floor(x / precision);
            int intY = (int)Math.Floor(y / precision);
            return internalData[intX, intY];
        }
        #endregion
    }
}
