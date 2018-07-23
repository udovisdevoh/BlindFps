using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using SdlDotNet.Graphics;
using SdlDotNet.Core;
using SdlDotNet.Graphics.Primitives;

namespace CvmFight
{
    class EnergyBarViewer
    {
        #region Fields
        private Rectangle rectangle = new Rectangle();
        #endregion

        #region Public Method
        public void View(Surface surface, AbstractHumanoid sprite, Point spritePosition, double theoreticalColumnHeight)
        {
            int barHeight = (int)(theoreticalColumnHeight / 100.0);

            if (barHeight < 1)
                return;

            int barWidth = (int)(theoreticalColumnHeight * sprite.Health / 1000.0);

            rectangle.X = spritePosition.X;
            rectangle.Y = spritePosition.Y - barHeight * 2;
            rectangle.Width = barWidth;
            rectangle.Height = barHeight;
            
            surface.Fill(rectangle, Color.Yellow);

            if (sprite.Health < sprite.DefaultHealth)
            {
                rectangle.X += barWidth;
                rectangle.Width = (int)(theoreticalColumnHeight * (sprite.DefaultHealth - Math.Min(sprite.Health, sprite.DefaultHealth)) / 1000.0);

                surface.Fill(rectangle, Color.Red);
            }
        }
        #endregion
    }
}
