using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlindFPS
{
    public abstract class AbstractSprite : IComparable<AbstractSprite>
    {
        #region Fields
        /// <summary>
        /// Sprite's maximum jump acceleration
        /// </summary>
        private double maxJumpAcceleration = 1.0;

        /// <summary>
        /// Sprite's current jump force
        /// </summary>
        private double currentJumpAcceleration = 0.0;

        /// <summary>
        /// Whether sprite must jump again because he has no cynetic energy left
        /// </summary>
        private bool isNeedToJumpAgain = false;

        /// <summary>
        /// Distance to a reference sprite (which could be anything)
        /// </summary>
        private double distanceToReferenceSprite;

        /// <summary>
        /// sprite's angle
        /// </summary>
        private double angleRadian = 0.0;

        /// <summary>
        /// x coordinate position
        /// </summary>
        private double positionX = 0.0;

        /// <summary>
        /// y coordinate position
        /// </summary>
        private double positionY = 0.0;

        /// <summary>
        /// sprite's radius
        /// </summary>
        private double radius = 0.0;

        /// <summary>
        /// Jump speed multiplier
        /// </summary>
        private double jumpSpeedMultiplier = 1.6;

        /// <summary>
        /// Sprite's default walking distance per tick
        /// </summary>
        private double defaultWalkingDistance = 0.1;

        /// <summary>
        /// height from the ground
        /// </summary>
        private double positionZ = 0.0;
        #endregion

        #region IComparable<AbstractSprite> Members
        public int CompareTo(AbstractSprite other)
        {
            return (int)(other.distanceToReferenceSprite * 100 - distanceToReferenceSprite * 100);
        }
        #endregion

        #region Public Methods
        public abstract void Update(double timeDelta, SpritePool spritePool, AbstractMap abstractMap);
        #endregion

        #region Properties
        /// <summary>
        /// Sprite's max jump acceleration
        /// </summary>
        public double MaxJumpAcceleration
        {
            get { return maxJumpAcceleration; }
            set { maxJumpAcceleration = value; }
        }

        /// <summary>
        /// Sprite's diameter
        /// </summary>
        public double Diameter
        {
            get { return radius * 2; }
            set { radius = value / 2; }
        }

        /// <summary>
        /// Sprite's current jump force
        /// </summary>
        public double CurrentJumpAcceleration
        {
            get { return currentJumpAcceleration; }
            set { currentJumpAcceleration = value; }
        }

        /// <summary>
        /// Distance to a reference sprite (which could be anything)
        /// </summary>
        public double DistanceToReferenceSprite
        {
            get { return distanceToReferenceSprite; }
            set { distanceToReferenceSprite = value; }
        }

        /// <summary>
        /// Return angle in radian from -1 to 1
        /// </summary>
        public double AngleRadian
        {
            get
            {
                return angleRadian;
            }

            set
            {
                while (value >= Math.PI * 2)
                    value -= Math.PI * 2;

                while (value < 0)
                    value += Math.PI * 2;

                angleRadian = value;
            }
        }

        /// <summary>
        /// Angle in degree (from 0 to 360)
        /// </summary>
        public double AngleDegree
        {
            get
            {
                return angleRadian / Math.PI * 180.0;
            }

            set
            {
                AngleRadian = value / 180.0 * Math.PI;
            }
        }

        /// <summary>
        /// x coordinate position
        /// </summary>
        public double PositionX
        {
            get { return positionX; }
            set { positionX = value; }
        }

        /// <summary>
        /// y coordinate position
        /// </summary>
        public double PositionY
        {
            get { return positionY; }
            set { positionY = value; }
        }

        /// <summary>
        /// Sprite's radius
        /// </summary>
        public double Radius
        {
            get { return radius; }
            set { radius = value; }
        }

        public double JumpSpeedMultiplier
        {
            get { return jumpSpeedMultiplier; }
            set { jumpSpeedMultiplier = value; }
        }

        /// <summary>
        /// Sprite's default walking distance per tick
        /// </summary>
        public double DefaultWalkingDistance
        {
            get { return defaultWalkingDistance; }
            set { defaultWalkingDistance = value; }
        }

        /// <summary>
        /// z coordinate position
        /// </summary>
        public double PositionZ
        {
            get { return positionZ; }
            set { positionZ = value; }
        }

        /// <summary>
        /// Whether sprite must jump again because he has no cynetic energy left
        /// </summary>
        public bool IsNeedToJumpAgain
        {
            get { return isNeedToJumpAgain; }
            set { isNeedToJumpAgain = value; }
        }
        #endregion
    }
}
