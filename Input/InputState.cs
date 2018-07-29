using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlindFPS
{
    /// <summary>
    /// Which keys and mouse buttons are up or down and mouse position
    /// </summary>
    class InputState
    {
        #region Fields
        private bool isPressUp = false;

        private bool isPressDown = false;

        private bool isPressLeft = false;

        private bool isPressRight = false;

        private bool isPressCrouch = false;

        private bool isPressJump = false;

        private bool isPressMouseButtonLeft = false;

        private bool isPressMouseButtonRight = false;

        private bool isPressMouseButtonCenter = false;

        private short currentMouseRelativeX = 0;
        
        private short currentMouseRelativeY = 0;
        #endregion

        #region Properties
        public bool IsPressUp
        {
            get { return isPressUp; }
            set { isPressUp = value; }
        }

        public bool IsPressDown
        {
            get { return isPressDown; }
            set { isPressDown = value; }
        }

        public bool IsPressLeft
        {
            get { return isPressLeft; }
            set { isPressLeft = value; }
        }

        public bool IsPressRight
        {
            get { return isPressRight; }
            set { isPressRight = value; }
        }

        public bool IsPressCrouch
        {
            get { return isPressCrouch; }
            set{isPressCrouch = value;}
        }

        public bool IsPressJump
        {
            get { return isPressJump; }
            set { isPressJump = value; }
        }

        public bool IsPressMouseButtonLeft
        {
            get { return isPressMouseButtonLeft; }
            set { isPressMouseButtonLeft = value; }
        }

        public bool IsPressMouseButtonRight
        {
            get { return isPressMouseButtonRight; }
            set { isPressMouseButtonRight = value; }
        }

        public bool IsPressMouseButtonCenter
        {
            get { return isPressMouseButtonCenter; }
            set { isPressMouseButtonCenter = value; }
        }

        public short MouseMotionX
        {
            get { return currentMouseRelativeX; }
            set { currentMouseRelativeX = value; }
        }

        public short MouseMotionY
        {
            get { return currentMouseRelativeY; }
            set { currentMouseRelativeY = value; }
        }

        public int RecenterOffsetX { get; internal set; }
        public int RecenterOffsetY { get; internal set; }
        #endregion
    }
}
