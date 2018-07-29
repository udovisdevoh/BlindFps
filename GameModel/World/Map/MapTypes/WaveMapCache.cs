using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CvmFight
{
    class WaveMapCache
    {
        #region Fields
        private AbstractMatterType[,] internalCache;

        private int width;

        private int height;

        private double precision;
        #endregion

        #region Constructor
        public WaveMapCache(AbstractMap sourceMap, double precision)
        {
            this.precision = precision;
            this.width = width = (int)Math.Ceiling((double)(sourceMap.Width) / precision);
            this.height = height = (int)Math.Ceiling((double)(sourceMap.Height) / precision);

            internalCache = new AbstractMatterType[width, height];

            double sourceX = 0;
            for (int x = 0; x < this.width; x++)
            {
                double sourceY = 0;
                for (int y = 0; y < this.width; y++)
                {
                    internalCache[x, y] = sourceMap.GetMatterTypeAt(sourceX, sourceY);

                    sourceY += precision;
                }
                sourceX += precision;
            }
        }

        public AbstractMatterType GetValueAt(double x, double y)
        {
            int xInt = (int)Math.Floor((double)(x) / precision);
            int yInt = (int)Math.Floor((double)(y) / precision);

            if (xInt < 0)
                xInt = 0;
            if (yInt < 0)
                yInt = 0;
            if (xInt >= width)
                xInt = width-1;
            if (yInt >= height)
                yInt = height-1;

            return internalCache[xInt, yInt];
        }
        #endregion
    }
}
