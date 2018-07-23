using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using SdlDotNet.Graphics;
using SdlDotNet.Core;
using SdlDotNet.Graphics.Primitives;

namespace CvmFight
{
    class SpriteCache3D
    {
        #region Fields
        private bool isEnableSpriteCache;

        private bool isEnableLazySpriteImageLoad;
        #endregion

        #region Parts
        private SpriteScallableFrame[,] internalSpriteFrameMap = new SpriteScallableFrame[32, 32];
        #endregion

        #region Constructor
        public SpriteCache3D(bool isEnableSpriteCache, bool isEnableLazySpriteImageLoad)
        {
            this.isEnableLazySpriteImageLoad = isEnableLazySpriteImageLoad;
            this.isEnableSpriteCache = isEnableSpriteCache;
        }
        #endregion

        #region Public Methods
        public Surface GetSurface(byte spriteStatus, byte spriteAngle, int spriteHeight)
        {
            return internalSpriteFrameMap[spriteAngle, spriteStatus].GetScaledSurface(spriteHeight, isEnableSpriteCache);
        }

        public void AddFrame(SpriteScallableFrame spriteFrame)
        {
            internalSpriteFrameMap[spriteFrame.Angle, spriteFrame.Status] = spriteFrame;
        }

        public void SetOffset(byte spriteAngle, byte spriteStatus, double xOffset, double yOffset)
        {
            internalSpriteFrameMap[spriteAngle, spriteStatus].XOffset = xOffset;
            internalSpriteFrameMap[spriteAngle, spriteStatus].YOffset = yOffset;
        }

        public double GetOffsetX(byte angleType, byte spriteStatus)
        {
            return internalSpriteFrameMap[angleType, spriteStatus].XOffset;
        }

        public double GetOffsetY(byte angleType, byte spriteStatus)
        {
            return internalSpriteFrameMap[angleType, spriteStatus].YOffset;
        }

        public double GetSizeMultiplicator(byte angleType, byte spriteStatus)
        {
            return internalSpriteFrameMap[angleType, spriteStatus].SizeMultiplicator;
        }

        public void SetSizeMultiplicator(byte angleType, byte spriteStatus, double sizeMultiplicator)
        {
            internalSpriteFrameMap[angleType, spriteStatus].SizeMultiplicator = sizeMultiplicator;
        }
        #endregion
    }
}
