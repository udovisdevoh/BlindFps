using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlindFPS
{
    class CachedWaveMap : AbstractMap
    {
        #region Constants
        private double precision = 0.01;
        #endregion

        #region Fields
        private WaveMap waveMap;

        private WaveMapCache waveMapCache;

        private ColorMap colorMap;
        #endregion

        #region Constructor
        public CachedWaveMap(Random random)
        {
            waveMap = new WaveMap(random);
            waveMapCache = new WaveMapCache(waveMap, precision);
            colorMap = new ColorMap(random,waveMap.Width,waveMap.Height);
        }
        #endregion

        #region Public Methods
        public override AbstractMatterType GetMatterTypeAt(double x, double y)
        {
            return waveMapCache.GetValueAt(x, y);
        }

        public override int Width
        {
            get { return waveMap.Width; }
        }

        public override int Height
        {
            get { return waveMap.Height; }
        }

        public override void GetColors(double x, double y, double originalBrightness, out double red, out double green, out double blue)
        {
            red = colorMap.GetRedMultiplicatorAt(x, y);
            green = colorMap.GetGreenMultiplicatorAt(x, y);
            blue = colorMap.GetBlueMultiplicatorAt(x, y);

            double totalMultiplicator = red + green + blue;

            red = red / totalMultiplicator * 3.0 * originalBrightness;
            green = green / totalMultiplicator * 3.0 * originalBrightness;
            blue = blue / totalMultiplicator * 3.0 * originalBrightness;

            red = Math.Max(0, red);
            green = Math.Max(0, green);
            blue = Math.Max(0, blue);

            red = Math.Min(255, red);
            green = Math.Min(255, green);
            blue = Math.Min(255, blue);
        }
        #endregion
    }
}
