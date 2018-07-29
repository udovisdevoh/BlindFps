using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using SdlDotNet.Graphics;
using SdlDotNet.Core;
using SdlDotNet.Graphics.Primitives;

namespace BlindFPS
{
    class ColumnViewer
    {
        #region Fields and parts
        private int columnCount;

        private int columnWidthPixel;

        private int screenWidth;

        private int screenHeight;

        private double heightDistanceRatio = 2;

        private Rectangle[] rectangleCache;

        private EcholocationCycle echolocationCycle;
        #endregion

        #region Constructor
        public ColumnViewer(int screenWidth, int screenHeight, int columnCount, double heightDistanceRatio, EcholocationCycle echolocationCycle)
        {
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
            this.columnCount = columnCount;
            this.columnWidthPixel = screenWidth / columnCount;
            this.heightDistanceRatio = heightDistanceRatio;
            this.echolocationCycle = echolocationCycle;

            this.rectangleCache = new Rectangle[columnCount];
            for (int i = 0; i < columnCount; i++)
            {
                this.rectangleCache[i] = new Rectangle();
                this.rectangleCache[i].Width = columnWidthPixel;
            }
        }
        #endregion

        #region Public Methods
        public void Update(AbstractHumanoid currentPlayer, RayTracer rayTracer, AbstractMap map, Surface surface)
        {
            int columnXLeftMargin = 0;
            for (int columnId = 0; columnId < columnCount; columnId++)
            {
                double straightDistance = Optics.GetStraightDistance(currentPlayer, rayTracer[columnId]);
                double columnHeight = Optics.GetColumnHeight(straightDistance, screenHeight, heightDistanceRatio);
                double topMargin = Optics.GetColumnTopMargin(screenHeight, columnHeight, currentPlayer.PositionZ, currentPlayer.IsCrouch, currentPlayer.MouseLook);
                
                Rectangle rectangle = rectangleCache[columnId];
                rectangle.X = columnXLeftMargin;
                rectangle.Y = (int)topMargin;
                rectangle.Height = (int)columnHeight;

                columnXLeftMargin += columnWidthPixel;

                double brightness = Optics.GetBrightness(Math.Min(screenHeight, columnHeight), screenHeight);

                double red, green, blue;

                map.GetColors(rayTracer[columnId].X, rayTracer[columnId].Y, brightness, out red, out green, out blue);
                
                if (echolocationCycle.IsHighlightedColumn(columnId))
                {
                    red = Math.Max(0, Math.Min(255, 256 - red));
                    green = Math.Max(0, Math.Min(255, 256 - green));
                    blue = Math.Max(0, Math.Min(255, 256 - blue));
                }

                surface.Fill(rectangle, Color.FromArgb(255, (byte)(red), (byte)(green), (byte)(blue)));
            }
        }
        #endregion
    }
}
