using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace CvmFight
{
    class MapFromImage : AbstractMap
    {
        #region Constants
        private double precision = 0.025;
        #endregion

        #region Fields
        private AbstractMatterType[,] mapCache;

        private int width;

        private int height;

        private int imageWidth;

        private int imageHeight;

        private ColorMap colorMap;

        private ImageCache imageCache;
        #endregion

        #region Constructor
        public MapFromImage(string imageFileName, Random random)
        {
            Bitmap bitmap = new Bitmap(imageFileName);

            imageWidth = bitmap.Width;
            imageHeight = bitmap.Height;

            width = (int)Math.Ceiling((double)imageWidth * precision);
            height = (int)Math.Ceiling((double)imageHeight * precision);

            imageCache = new ImageCache(imageFileName);

            if (!imageCache.TryLoadMapCache(out mapCache, bitmap.Width, bitmap.Height))
            {
                mapCache = new AbstractMatterType[imageWidth, imageHeight];

                AbstractMatterType wall = new MatterTypeWall();

                Color currentPixelColor;
                for (int x = 0; x < bitmap.Width; x++)
                {
                    for (int y = 0; y < bitmap.Height; y++)
                    {
                        currentPixelColor = bitmap.GetPixel(x, y);

                        if (currentPixelColor.R > 128)
                            mapCache[x, y] = null;
                        else
                            mapCache[x, y] = wall;
                    }
                }

                imageCache.SaveCache(mapCache, bitmap.Width, bitmap.Height);
            }

            colorMap = new ColorMap(random, width, height);
        }
        #endregion

        #region Public Methods
        public override AbstractMatterType GetMatterTypeAt(double x, double y)
        {
            x /= precision;
            y /= precision;

            int intX = (int)x;
            int intY = (int)y;

            intX = Math.Max(0, intX);
            intX = Math.Min(imageWidth - 1, intX);

            intY = Math.Max(0, intY);
            intY = Math.Min(imageHeight - 1, intY);

            return mapCache[intX, intY];
        }

        public override int Width
        {
            get { return width; }
        }

        public override int Height
        {
            get { return height; }
        }

        public override void GetColors(double x, double y, double originalBrightness, out double red, out double green, out double blue)
        {
            /*red = green = blue = originalBrightness;*/

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
