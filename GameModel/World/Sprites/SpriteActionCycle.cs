using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlindFPS
{
    public class SpriteActionCycle
    {
        #region Fields
        private double cycleLength;

        private double currentCyclePosition;

        private bool isForward = true;

        private bool isFired;

        private bool isNeedToClickAgain = false;

        private bool isBouncingBack = true;

        private bool isAutoReset = false;
        #endregion

        #region Constructor
        /// <summary>
        /// Create a sprite cycle
        /// </summary>
        /// <param name="cycleLength">cycle length</param>
        public SpriteActionCycle(double cycleLength): this(cycleLength,true){}

        public SpriteActionCycle(double cycleLength, bool isBouncingBack) : this(cycleLength,isBouncingBack,false) {}

        /// <summary>
        /// Create a sprite cycle
        /// </summary>
        /// <param name="cycleLength">cycle length</param>
        /// <param name="isBouncingBack">whether the cycle is bouncing back at the end (default: true)</param>
        /// <param name="isAutoReset">whether the cycle is reseting after it reaches its paroxysm (default: false)</param>
        public SpriteActionCycle(double cycleLength, bool isBouncingBack, bool isAutoReset)
        {
            this.isBouncingBack = isBouncingBack;
            this.isAutoReset = isAutoReset;
            this.cycleLength = cycleLength;
        }
        #endregion

        #region Public Method
        public void Fire()
        {
            if (!isNeedToClickAgain)
                isFired = true;
        }

        public void Update(double timeDelta)
        {
            if (currentCyclePosition > cycleLength)
            {
                if (isAutoReset)
                {
                    Reset();
                    return;
                }
                else if (isBouncingBack)
                {
                    isForward = false;
                }
                else
                {
                    currentCyclePosition = cycleLength;
                    return;
                }
            }
            else if (currentCyclePosition < 0)
            {
                isForward = true;
                isFired = false;
                isNeedToClickAgain = true;
            }


            if (isFired)
            {
                if (isForward)
                {
                    currentCyclePosition += timeDelta / 10;
                }
                else
                {
                    currentCyclePosition -= timeDelta / 10;
                }
            }
            else
            {
                currentCyclePosition = 0;
            }
        }

        /// <summary>
        /// Don't use that to know when attack occurs in game logic
        /// </summary>
        /// <returns></returns>
        public int GetCycleState()
        {
            int state = 0;
            /*if (currentCyclePosition > cycleLength / 2)
            {
                state = 2;
            }
            else if (currentCyclePosition > 0)
            {
                state = 1;
            }*/

            if (isForward)
            {
                if (currentCyclePosition > cycleLength * 0.75)
                {
                    state = 2;
                }
                else if (currentCyclePosition > 0)
                {
                    state = 1;
                }
            }
            else
            {
                if (currentCyclePosition > cycleLength * 0.5)
                {
                    state = 2;
                }
                else if (currentCyclePosition > 0)
                {
                    state = 1;
                }
            }

            return state;
        }

        public void UnFire()
        {
            isNeedToClickAgain = false;
        }

        public void Reset()
        {
            UnFire();
            isForward = true;
            isFired = false;
            currentCyclePosition = 0;
        }
        #endregion

        #region Properties
        public bool IsAtParoxism
        {
            get { return currentCyclePosition > cycleLength; }
        }

        public bool IsFired
        {
            get { return isFired; }
        }

        public bool IsForward
        {
            get { return isForward; }
            set { isForward = value; }
        }

        public bool IsAtBegining
        {
            get { return currentCyclePosition <= 0; }
        }

        public double PercentComplete
        {
            get
            {
                return currentCyclePosition / cycleLength;
            }

            set
            {
                currentCyclePosition = this.cycleLength * value;
            }
        }

        public bool IsNeedToClickAgain
        {
            get { return isNeedToClickAgain; }
            set { isNeedToClickAgain = value; }
        }
        #endregion
    }
}
