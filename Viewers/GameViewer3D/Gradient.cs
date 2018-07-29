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
    class Gradient
    {
        #region Fields
        private Surface surface;

        private Color topColor;

        private Color bottomColor;
        #endregion

        #region Constructor
        public Gradient(int width, int height)
        {
            surface = new Surface(width, height);
            
            double red, green, blue;
            red = green = blue = 0;

            bottomColor = Color.FromArgb(255, (int)red, (int)green, (int)blue);

            double incrementer = (double)height / (double)(width * 4);

            for (short y = (short)(height / 2); y >= 0; y--)
            {
                red += incrementer;
                green += incrementer;
                blue += incrementer;

                red = Math.Max(0, red);
                green = Math.Max(0, green);
                blue = Math.Max(0, blue);
                red = Math.Min(255, red);
                green = Math.Min(255, green);
                blue = Math.Min(255, blue);
                surface.Draw(new Line(0, y, (short)(width - 1), y), Color.FromArgb(255, (int)red, (int)green, (int)blue));
            }

            red = green = blue = 0;
            for (short y = (short)(height / 2); y < height; y++)
            {
                red += incrementer;
                green += incrementer;
                blue += incrementer / 1.5;

                red = Math.Max(0, red);
                green = Math.Max(0, green);
                blue = Math.Max(0, blue);
                red = Math.Min(255, red);
                green = Math.Min(255, green);
                blue = Math.Min(255, blue);
                surface.Draw(new Line(0, y, (short)(width - 1), y), Color.FromArgb(255, (int)red, (int)green, (int)blue));
            }

            topColor = Color.FromArgb(255, (int)red, (int)green, (int)blue);
        }
        #endregion

        #region Properties
        public Surface Surface
        {
            get { return surface; }
        }
        #endregion
    }
}
