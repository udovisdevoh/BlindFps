using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace BlindFPS
{
    class RayTracerPoint
    {
        #region Fields
        private double x = 0;

        private double y = 0;
        #endregion

        #region Public Methods
        public void Trace(AbstractHumanoid viewerSprite, double angleDegree, double rayDistanceResolution, AbstractMap map)
        {
            double xMove = Math.Cos(angleDegree / 180 * Math.PI) * rayDistanceResolution;
            double yMove = Math.Sin(angleDegree / 180 * Math.PI) * rayDistanceResolution;

            x = viewerSprite.PositionX;
            y = viewerSprite.PositionY;
            
            while (true)
            {
                x += xMove;
                y += yMove;

                xMove *= 1.01;
                yMove *= 1.01;

                if (x < 0 || y < 0 || x > map.Width || y > map.Height)
                {
                    break;
                }

                if (map.GetMatterTypeAt(x, y) != null)
                {
                    break;
                }
            }

            if (x < 0)
            {
                x = 0;
            }
            else if (x > map.Width)
            {
                x = map.Width - xMove;
            }

            if (y < 0)
            {
                y = 0;
            }
            else if (y > map.Height)
            {
                y = map.Height - yMove;
            }
        }
        #endregion

        #region Properties
        public double X
        {
            get { return x; }
        }

        public double Y
        {
            get { return y; }
        }
        #endregion
    }
}
