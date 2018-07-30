using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlindFPS
{
    public class EcholocationCycle
    {
        #region Members
        private int totalFrameCount;

        private int columnWidth;

        private int totalColumnCount;

        private int currentColumn = 0;

        private int currentFrame = 0;

        private int scanPointCount;

        private bool isBounceBack = false;

        private bool isCurrenlyMovingForward = true;

        private bool isMirrorScanPoint;

        private Random random = new Random();
        //private int columnOffset = 0;
        #endregion

        #region Constructors
        public EcholocationCycle(int frameRate,
            int cycleLengthMs,
            int rayTraceResolution,
            bool isBounceBack,
            int scanPointCount,
            bool isMirrorScanPoint,
            double fieldOfViewRatio)
        {
            this.totalColumnCount = rayTraceResolution;
            /*if (fieldOfViewRatio != 1.0)
            {
                this.totalColumnCount = Math.Min(this.totalColumnCount, (int)Math.Round((double)this.totalColumnCount * (double)fieldOfViewRatio));
                this.columnOffset = (rayTraceResolution - this.totalColumnCount) / 2;
            }*/

            this.totalFrameCount = cycleLengthMs * frameRate / 1000;
            this.columnWidth = (this.totalColumnCount / this.totalFrameCount) / scanPointCount;
            this.isBounceBack = isBounceBack;
            this.scanPointCount = scanPointCount;
            this.isMirrorScanPoint = isMirrorScanPoint;
        }
        #endregion

        public void IncrementFrame()
        {
            if (this.isCurrenlyMovingForward)
            {
                ++this.currentFrame;
                if (this.currentFrame > totalFrameCount)
                {
                    if (this.isBounceBack)
                    {
                        this.isCurrenlyMovingForward = false;
                    }
                    else
                    {
                        currentFrame = 0;
                    }
                }
            }
            else
            {
                --this.currentFrame;
                if (this.currentFrame < 0)
                {
                    currentFrame = 0;
                    this.isCurrenlyMovingForward = true;
                }
            }

            this.currentColumn = Math.Min(this.totalColumnCount - 1, Math.Max(0, this.currentFrame * this.totalColumnCount / this.totalFrameCount));
        }

        public bool IsHighlightedColumn(int columnId)
        {
            /*
            columnId -= this.columnOffset;

            if (columnId > this.totalColumnCount)
            {
                return false;
            }
            else if (columnId < 0)
            {
                return false;
            }*/

            /*
            columnId += random.Next(0, this.columnWidth) - this.columnWidth / 2;
            columnId = Math.Min(columnId, this.totalColumnCount - 1);
            columnId = Math.Max(columnId, 0);*/


            columnId = columnId * this.scanPointCount;

            bool isOdd = true;
            while (columnId > this.totalColumnCount)
            {
                columnId -= this.totalColumnCount;
                isOdd = !isOdd;
            }

            if (isOdd && this.isMirrorScanPoint)
            {
                columnId = totalColumnCount - columnId;
            }

            return this.currentColumn == columnId;
        }
    }
}
