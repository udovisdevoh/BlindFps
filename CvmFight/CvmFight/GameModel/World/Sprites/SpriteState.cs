using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CvmFight
{
    public class SpriteState
    {
        #region Fields
        private double currentTime = 0;

        private double maxTime = 0;

        private double averageMaxTime;

        private byte[] stateList;

        private byte currentState;
        #endregion

        #region Constructor
        public SpriteState(byte state0, byte state1, byte state2, byte state3, byte state4, byte state5, byte state6, double averageMaxTime)
        {
            this.averageMaxTime = averageMaxTime;

            stateList = new byte[7];
            stateList[0] = state0;
            stateList[1] = state1;
            stateList[2] = state2;
            stateList[3] = state3;
            stateList[4] = state4;
            stateList[5] = state5;
            stateList[6] = state6;

            currentState = stateList[0];
        }

        public SpriteState(byte state0, byte state1, byte state2, byte state3, byte state4, byte state5, double averageMaxTime)
        {
            this.averageMaxTime = averageMaxTime;

            stateList = new byte[6];
            stateList[0] = state0;
            stateList[1] = state1;
            stateList[2] = state2;
            stateList[3] = state3;
            stateList[4] = state4;
            stateList[5] = state5;

            currentState = stateList[0];
        }

        public SpriteState(byte state0, byte state1, byte state2, byte state3, byte state4, double averageMaxTime)
        {
            this.averageMaxTime = averageMaxTime;

            stateList = new byte[5];
            stateList[0] = state0;
            stateList[1] = state1;
            stateList[2] = state2;
            stateList[3] = state3;
            stateList[4] = state4;

            currentState = stateList[0];
        }

        public SpriteState(byte state0, byte state1, byte state2, byte state3, double averageMaxTime)
        {
            this.averageMaxTime = averageMaxTime;

            stateList = new byte[4];
            stateList[0] = state0;
            stateList[1] = state1;
            stateList[2] = state2;
            stateList[3] = state3;

            currentState = stateList[0];
        }

        public SpriteState(byte state0, byte state1, byte state2, double averageMaxTime)
        {
            this.averageMaxTime = averageMaxTime;

            stateList = new byte[3];
            stateList[0] = state0;
            stateList[1] = state1;
            stateList[2] = state2;

            currentState = stateList[0];
        }

        public SpriteState(byte state0, byte state1, double averageMaxTime)
        {
            this.averageMaxTime = averageMaxTime;

            stateList = new byte[2];
            stateList[0] = state0;
            stateList[1] = state1;

            currentState = stateList[0];
        }
        #endregion

        #region Public Methods
        public byte GetCurrentState()
        {
            return currentState;
        }

        public void Update(double timeDelta, Random random)
        {
            currentTime += timeDelta;

            if (currentTime >= maxTime)
            {
                currentState = stateList[random.Next(stateList.Length)];
                currentTime = 0;
                maxTime = random.NextDouble() * averageMaxTime * 2.0;
            }
        }

        /// <summary>
        /// Reset cycle and get another behavior
        /// </summary>
        public void Reset()
        {
            currentTime = maxTime;
        }

        /// <summary>
        /// Renew cycle and keep current behavior
        /// </summary>
        public void Renew()
        {
            currentTime = 0;
        }
        #endregion
    }
}
