using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CvmFight
{
    class EmptyMapLocationCache
    {
        #region Fields
        private List<Point> internalCache = new List<Point>();
        #endregion

        #region Public Methods
        public EmptyMapLocationCache(AbstractMap map)
        {
            for (int x = 0; x < map.Width; x++)
            {
                for (int y = 0; y < map.Height; y++)
                {
                    if (map.GetMatterTypeAt(x, y) == null)
                    {
                        internalCache.Add(new Point(x, y));
                    }
                }
            }
        }

        public Point GetRandomAvailableLocation(AbstractMap map, SpritePool spritePool, Random random)
        {
            return internalCache[random.Next(internalCache.Count)];
        }
        #endregion
    }
}
