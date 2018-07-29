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

        private int columnFrameCount;

        private int totalColumnCount;

        private int currentColumn = 0;

        private int currentFrame = 0;

        private int scanPointCount;

        private bool isBounceBack = false;

        private bool isCurrenlyMovingForward = true;

        private bool isMirrorScanPoint;
        #endregion

        #region Constructors
        public EcholocationCycle(int frameRate,
            int cycleLengthMs,
            int rayTraceResolution,
            bool isBounceBack,
            int scanPointCount,
            bool isMirrorScanPoint)
        {
            this.totalFrameCount = cycleLengthMs * frameRate / 1000;
            this.columnFrameCount = this.totalFrameCount / rayTraceResolution;
            this.totalColumnCount = rayTraceResolution;
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
