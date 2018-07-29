using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace BlindFPS
{
    class RayTracer : IEnumerable<RayTracerPoint>
    {
        #region Fields
        private int fov;

        private int columnCount;

        private List<RayTracerPoint> pointList;

        private double rayDistanceResolution;
        #endregion

        #region Constructor
        public RayTracer(int howManyColumn, int fov, double rayDistanceResolution)
        {
            this.fov = fov;
            this.columnCount = howManyColumn;
            this.rayDistanceResolution = rayDistanceResolution;

            pointList = new List<RayTracerPoint>(this.columnCount);
            for (int i = 0; i < howManyColumn; i++)
            {
                pointList.Add(new RayTracerPoint());
            }
        }
        #endregion

        #region Public Methods
        public List<RayTracerPoint> Trace(AbstractHumanoid viewerSprite, AbstractMap map)
        {
            double startAngle = viewerSprite.AngleDegree - fov / 2;
            double endAngle = viewerSprite.AngleDegree + fov / 2;
            double angleResolution = (double)fov / (double)columnCount;

            startAngle = Optics.FixAngleDegree(startAngle);
            endAngle = Optics.FixAngleDegree(endAngle);

            int pointCounter = 0;
            for (double angle = startAngle; pointCounter < columnCount; angle += angleResolution)
            {
                angle = Optics.FixAngleDegree(angle);

                pointList[pointCounter].Trace(viewerSprite, angle, rayDistanceResolution, map);

                pointCounter++;
            }

            return pointList;
        }
        #endregion

        #region IEnumerable<RayTracerPoint> Members
        public IEnumerator<RayTracerPoint> GetEnumerator()
        {
            return pointList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return pointList.GetEnumerator();
        }
        #endregion

        #region Properties
        public int ColumnCount
        {
            get { return columnCount; }
        }

        public int Fov
        {
            get { return fov; }
        }

        public RayTracerPoint this[int id]
        {
            get { return pointList[id]; }
        }
        #endregion

        #region Static methods
        public static int GetValidResolution(int idealRayTracerResolution, int screenWidth)
        {
            int validResolution = screenWidth;
            int divider = 1;

            do
            {
                if (screenWidth % divider == 0)
                {
                    validResolution = screenWidth / divider;
                }
                divider++;
            } while (validResolution > idealRayTracerResolution);

            return validResolution;
        }
        #endregion
    }
}