using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CvmFight
{
    /// <summary>
    /// Represents a hardcoded game map
    /// </summary>
    class HardCodedMap : AbstractMap
    {
        #region Fields
        /// <summary>
        /// Map's width
        /// </summary>
        private int width = 16;

        /// <summary>
        /// Map's height
        /// </summary>
        private int height = 16;

        /// <summary>
        /// Internal map data
        /// </summary>
        private AbstractMatterType[,] internalMap;
        #endregion

        #region Construction
        /// <summary>
        /// Create hardcoded map
        /// </summary>
        public HardCodedMap()
        {
            internalMap = new AbstractMatterType[height, width];

            AbstractMatterType wall = new MatterTypeWall();
            AddRow(0, new AbstractMatterType[] { wall, wall, wall, wall, wall, wall, wall, wall, wall, wall, wall, wall, wall, wall, wall, wall });
            AddRow(1, new AbstractMatterType[] { wall, null, null, null, wall, null, null, wall, null, wall, null, null, null, null, null, wall });
            AddRow(2, new AbstractMatterType[] { wall, null, wall, null, null, null, null, wall, null, null, null, null, null, wall, null, wall });
            AddRow(3, new AbstractMatterType[] { wall, null, wall, null, null, null, null, wall, null, null, null, null, null, wall, null, wall });
            AddRow(4, new AbstractMatterType[] { wall, null, wall, wall, wall, wall, null, wall, null, null, null, null, wall, wall, null, wall });
            AddRow(5, new AbstractMatterType[] { wall, null, null, wall, wall, wall, null, wall, null, null, null, null, wall, null, null, wall });
            AddRow(6, new AbstractMatterType[] { wall, null, null, null, null, null, null, wall, null, null, null, null, wall, null, wall, wall });
            AddRow(7, new AbstractMatterType[] { wall, null, null, wall, wall, null, wall, wall, wall, wall, null, null, wall, null, wall, wall });
            AddRow(8, new AbstractMatterType[] { wall, null, null, wall, wall, null, wall, wall, wall, wall, null, null, wall, null, null, wall });
            AddRow(9, new AbstractMatterType[] { wall, null, null, null, null, null, wall, wall, wall, wall, null, wall, wall, null, null, wall });
            AddRow(10, new AbstractMatterType[] { wall, null, wall, wall, wall, null, wall, wall, null, null, null, null, wall, null, wall, wall });
            AddRow(11, new AbstractMatterType[] { wall, null, wall, null, null, null, null, wall, wall, null, null, null, wall, null, wall, wall });
            AddRow(12, new AbstractMatterType[] { wall, null, wall, wall, wall, null, null, wall, wall, null, null, null, null, null, null, wall });
            AddRow(13, new AbstractMatterType[] { wall, null, null, null, null, null, null, null, null, null, null, null, null, null, null, wall });
            AddRow(14, new AbstractMatterType[] { wall, null, null, null, null, null, null, wall, null, null, wall, null, wall, null, null, wall });
            AddRow(15, new AbstractMatterType[] { wall, wall, wall, wall, wall, wall, wall, wall, wall, wall, wall, wall, wall, wall, wall, wall });
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Returns matter type at specified coordinates
        /// </summary>
        /// <param name="x">x</param>
        /// <param name="y">y</param>
        /// <returns>matter type at specified coordinates</returns>
        public override AbstractMatterType GetMatterTypeAt(double x, double y)
        {
            if (x >= width || x < 0 || y >= height || y < 0)
                throw new ArgumentException("x-y coordinates out of bound");
            return internalMap[(int)Math.Floor(y), (int)Math.Floor(x)];
        }

        public override void GetColors(double x, double y, double originalBrightness, out double redMultiplicator, out double greenMultiplicator, out double blueMultiplicator)
        {
            redMultiplicator = originalBrightness;
            greenMultiplicator = originalBrightness;
            blueMultiplicator = originalBrightness;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Add a row to the map
        /// </summary>
        /// <param name="args"></param>
        private void AddRow(int rowId, AbstractMatterType[] row)
        {
            int columnId = 0;
            foreach (AbstractMatterType matterType in row)
            {
                internalMap[rowId, columnId] = matterType;
                columnId++;
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// Width
        /// </summary>
        public override int Width
        {
            get { return width; }
        }

        /// <summary>
        /// Height
        /// </summary>
        public override int Height
        {
            get { return height; }
        }
        #endregion
    }
}