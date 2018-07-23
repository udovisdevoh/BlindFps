using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CvmFight
{
    class SpriteCache3DBuilder
    {
        #region Public Methods
        public SpriteCache3D Build(AbstractHumanoid sprite, bool isEnableSpriteCache, bool isEnableLazySpriteImageLoad)
        {
            SpriteCache3D spriteCache = new SpriteCache3D(isEnableSpriteCache, isEnableLazySpriteImageLoad);
            if (sprite is MonsterStickMan)
            {
                BuildStickMan(spriteCache, isEnableLazySpriteImageLoad);
            }
            else if (sprite is MonsterNutKunDo)
            {
                BuildNutKunDo(spriteCache, isEnableLazySpriteImageLoad);
            }
            else if (sprite is MonsterAladdin)
            {
                BuildAladdin(spriteCache, isEnableLazySpriteImageLoad);
            }
            return spriteCache;
        }
        #endregion

        #region Private Methods
        private void BuildStickMan(SpriteCache3D spriteCache, bool isEnableLazySpriteImageLoad)
        {
            string pathPrefix = "CvmFight/Assets/Sprites/StickMan/";

            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Walk1, pathPrefix + "StickManFrontWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Walk2, pathPrefix + "StickManFrontWalk2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Punch1, pathPrefix + "StickManFrontPunch1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Punch2, pathPrefix + "StickManFrontPunch2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Kick1, pathPrefix + "StickManFrontKick1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Kick2, pathPrefix + "StickManFrontKick2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Block, pathPrefix + "StickManFrontBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Crouch, pathPrefix + "StickManFrontCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.CrouchBlock, pathPrefix + "StickManFrontCrouchBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Hit, pathPrefix + "StickManFrontHit.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.CrouchHit, pathPrefix + "StickManFrontCrouchHit.png", isEnableLazySpriteImageLoad));

            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Walk1, pathPrefix + "StickManLeftWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Walk2, pathPrefix + "StickManLeftWalk2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Punch1, pathPrefix + "StickManFrontWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Punch2, pathPrefix + "StickManLeftPunch2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Kick1, pathPrefix + "StickManLeftKick1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Kick2, pathPrefix + "StickManLeftKick2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Block, pathPrefix + "StickManLeftBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Crouch, pathPrefix + "StickManLeftCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.CrouchBlock, pathPrefix + "StickManLeftCrouchBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Hit, pathPrefix + "StickManLeftHit.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.CrouchHit, pathPrefix + "StickManLeftCrouch.png", isEnableLazySpriteImageLoad));

            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Walk1, pathPrefix + "StickManLeftWalk1.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Walk2, pathPrefix + "StickManLeftWalk2.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Punch1, pathPrefix + "StickManFrontWalk1.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Punch2, pathPrefix + "StickManLeftPunch2.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Kick1, pathPrefix + "StickManLeftKick1.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Kick2, pathPrefix + "StickManLeftKick2.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Block, pathPrefix + "StickManLeftBlock.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Crouch, pathPrefix + "StickManLeftCrouch.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.CrouchBlock, pathPrefix + "StickManLeftCrouchBlock.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Hit, pathPrefix + "StickManLeftHit.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.CrouchHit, pathPrefix + "StickManLeftCrouch.png", true, isEnableLazySpriteImageLoad));

            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Walk1, pathPrefix + "StickManBackWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Walk2, pathPrefix + "StickManBackWalk2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Punch1, pathPrefix + "StickManBackWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Punch2, pathPrefix + "StickManBackWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Kick1, pathPrefix + "StickManBackWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Kick2, pathPrefix + "StickManBackWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Block, pathPrefix + "StickManBackWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Crouch, pathPrefix + "StickManBackCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.CrouchBlock, pathPrefix + "StickManBackCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Hit, pathPrefix + "StickManBackHit.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.CrouchHit, pathPrefix + "StickManBackCrouch.png", isEnableLazySpriteImageLoad));

            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Walk1, pathPrefix + "StickManFrontLeftWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Walk2, pathPrefix + "StickManFrontLeftWalk2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Punch1, pathPrefix + "StickManFrontWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Punch2, pathPrefix + "StickManFrontLeftPunch2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Block, pathPrefix + "StickManFrontLeftBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Hit, pathPrefix + "StickManFrontLeftHit.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Crouch, pathPrefix + "StickManLeftCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.CrouchBlock, pathPrefix + "StickManLeftCrouchBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.CrouchHit, pathPrefix + "StickManLeftCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Kick1, pathPrefix + "StickManFrontLeftKick1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Kick2, pathPrefix + "StickManFrontLeftKick2.png", isEnableLazySpriteImageLoad));

            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Walk1, pathPrefix + "StickManFrontLeftWalk1.png", true));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Walk2, pathPrefix + "StickManFrontLeftWalk2.png", true));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Punch1, pathPrefix + "StickManFrontWalk1.png", true));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Punch2, pathPrefix + "StickManFrontLeftPunch2.png", true));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Block, pathPrefix + "StickManFrontLeftBlock.png", true));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Hit, pathPrefix + "StickManFrontLeftHit.png", true));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Crouch, pathPrefix + "StickManLeftCrouch.png", true));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.CrouchBlock, pathPrefix + "StickManLeftCrouchBlock.png", true));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.CrouchHit, pathPrefix + "StickManLeftCrouch.png", true));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Kick1, pathPrefix + "StickManFrontLeftKick1.png", true));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Kick2, pathPrefix + "StickManFrontLeftKick2.png", true));

            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Walk1, pathPrefix + "StickManBackLeftWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Walk2, pathPrefix + "StickManBackLeftWalk2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Block, pathPrefix + "StickManBackLeftBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Punch1, pathPrefix + "StickManFrontWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Punch2, pathPrefix + "StickManBackLeftPunch2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Hit, pathPrefix + "StickManBackLeftHit.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Crouch, pathPrefix + "StickManBackLeftCrouchBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.CrouchBlock, pathPrefix + "StickManBackLeftCrouchBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.CrouchHit, pathPrefix + "StickManBackLeftCrouchBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Kick1, pathPrefix + "StickManBackLeftKick1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Kick2, pathPrefix + "StickManBackLeftKick2.png", isEnableLazySpriteImageLoad));

            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Walk1, pathPrefix + "StickManBackLeftWalk1.png", true));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Walk2, pathPrefix + "StickManBackLeftWalk2.png", true));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Block, pathPrefix + "StickManBackLeftBlock.png", true));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Punch1, pathPrefix + "StickManFrontWalk1.png", true));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Punch2, pathPrefix + "StickManBackLeftPunch2.png", true));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Hit, pathPrefix + "StickManBackLeftHit.png", true));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Crouch, pathPrefix + "StickManBackLeftCrouchBlock.png", true));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.CrouchBlock, pathPrefix + "StickManBackLeftCrouchBlock.png", true));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.CrouchHit, pathPrefix + "StickManBackLeftCrouchBlock.png", true));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Kick1, pathPrefix + "StickManBackLeftKick1.png", true));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Kick2, pathPrefix + "StickManBackLeftKick2.png", true));




            //For non-centered sprites images
            spriteCache.SetOffset(SpriteScallableFrame.Front, SpriteScallableFrame.Kick1, 0.5, 0);
            spriteCache.SetOffset(SpriteScallableFrame.Front, SpriteScallableFrame.Kick2, 0.5, 0);

            spriteCache.SetOffset(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Kick2, -0.5, 0);
            spriteCache.SetOffset(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Kick2, 0.5, 0);

            spriteCache.SetOffset(SpriteScallableFrame.Left, SpriteScallableFrame.Kick2, -0.5, 0);
            spriteCache.SetOffset(SpriteScallableFrame.Right, SpriteScallableFrame.Kick2, 0.5, 0);

            spriteCache.SetOffset(SpriteScallableFrame.Left, SpriteScallableFrame.Punch2, -0.5, 0);
            spriteCache.SetOffset(SpriteScallableFrame.Right, SpriteScallableFrame.Punch2, 0.5, 0);
            spriteCache.SetOffset(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Punch2, -0.5, 0);
            spriteCache.SetOffset(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Punch2, 0.5, 0);
            spriteCache.SetOffset(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Punch2, -0.5, 0);
            spriteCache.SetOffset(SpriteScallableFrame.BackRight, SpriteScallableFrame.Punch2, 0.5, 0);



            //For different scalling of the image
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Back, SpriteScallableFrame.Kick1, 0.5);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Back, SpriteScallableFrame.Kick2, 0.5);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Back, SpriteScallableFrame.Crouch, 0.5);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Back, SpriteScallableFrame.CrouchBlock, 0.5);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Back, SpriteScallableFrame.CrouchHit, 0.5);

            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Front, SpriteScallableFrame.Crouch, 0.5);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Front, SpriteScallableFrame.CrouchBlock, 0.5);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Front, SpriteScallableFrame.CrouchHit, 0.5);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Front, SpriteScallableFrame.Kick1, 0.666);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Front, SpriteScallableFrame.Kick2, 0.75);

            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Left, SpriteScallableFrame.Crouch, 0.5);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Left, SpriteScallableFrame.CrouchBlock, 0.5);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Left, SpriteScallableFrame.CrouchHit, 0.5);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Left, SpriteScallableFrame.Kick1, 0.5);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Left, SpriteScallableFrame.Kick2, 0.5);

            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Right, SpriteScallableFrame.Crouch, 0.5);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Right, SpriteScallableFrame.CrouchBlock, 0.5);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Right, SpriteScallableFrame.CrouchHit, 0.5);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Right, SpriteScallableFrame.Kick1, 0.5);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Right, SpriteScallableFrame.Kick2, 0.5);

            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Crouch, 0.5);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.BackLeft, SpriteScallableFrame.CrouchBlock, 0.5);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.BackLeft, SpriteScallableFrame.CrouchHit, 0.5);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Kick1, 0.5);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Kick2, 0.5);

            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.BackRight, SpriteScallableFrame.Crouch, 0.5);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.BackRight, SpriteScallableFrame.CrouchBlock, 0.5);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.BackRight, SpriteScallableFrame.CrouchHit, 0.5);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.BackRight, SpriteScallableFrame.Kick1, 0.5);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.BackRight, SpriteScallableFrame.Kick2, 0.5);

            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Crouch, 0.5);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.CrouchBlock, 0.5);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.CrouchHit, 0.5);

            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Crouch, 0.5);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.FrontRight, SpriteScallableFrame.CrouchBlock, 0.5);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.FrontRight, SpriteScallableFrame.CrouchHit, 0.5);




            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Kick1, 0.666);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Kick2, 0.75);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Kick1, 0.666);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Kick2, 0.75);
        }

        private void BuildNutKunDo(SpriteCache3D spriteCache, bool isEnableLazySpriteImageLoad)
        {
            string pathPrefix = "CvmFight/Assets/Sprites/NutKunDo/";

            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Walk1, pathPrefix + "NutKunDoFrontWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Walk2, pathPrefix + "NutKunDoFrontWalk2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Punch1, pathPrefix + "NutKunDoFrontPunch1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Punch2, pathPrefix + "NutKunDoFrontPunch2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Kick1, pathPrefix + "NutKunDoFrontCrouchPunch1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Kick2, pathPrefix + "NutKunDoFrontCrouchPunch2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Block, pathPrefix + "NutKunDoFrontBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Crouch, pathPrefix + "NutKunDoFrontCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.CrouchBlock, pathPrefix + "NutKunDoFrontCrouchBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Hit, pathPrefix + "NutKunDoFrontHit.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.CrouchHit, pathPrefix + "NutKunDoFrontCrouchHit.png", isEnableLazySpriteImageLoad));

            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Walk1, pathPrefix + "NutKunDoBackWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Walk2, pathPrefix + "NutKunDoBackWalk2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Punch1, pathPrefix + "NutKunDoBackPunch1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Punch2, pathPrefix + "NutKunDoBackPunch2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Kick1, pathPrefix + "NutKunDoBackCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Kick2, pathPrefix + "NutKunDoBackCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Block, pathPrefix + "NutKunDoBackWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Crouch, pathPrefix + "NutKunDoBackCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.CrouchBlock, pathPrefix + "NutKunDoBackCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Hit, pathPrefix + "NutKunDoBackHit.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.CrouchHit, pathPrefix + "NutKunDoBackCrouch.png", isEnableLazySpriteImageLoad));

            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Walk1, pathPrefix + "NutKunDoLeftWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Walk2, pathPrefix + "NutKunDoLeftWalk2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Punch1, pathPrefix + "NutKunDoLeftPunch1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Punch2, pathPrefix + "NutKunDoLeftPunch2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Kick1, pathPrefix + "NutKunDoLeftCrouchPunch1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Kick2, pathPrefix + "NutKunDoLeftCrouchPunch2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Block, pathPrefix + "NutKunDoLeftBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Crouch, pathPrefix + "NutKunDoLeftCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.CrouchBlock, pathPrefix + "NutKunDoLeftCrouchBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Hit, pathPrefix + "NutKunDoLeftHit.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.CrouchHit, pathPrefix + "NutKunDoLeftCrouchHit.png", isEnableLazySpriteImageLoad));

            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Walk1, pathPrefix + "NutKunDoLeftWalk1.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Walk2, pathPrefix + "NutKunDoLeftWalk2.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Punch1, pathPrefix + "NutKunDoLeftPunch1.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Punch2, pathPrefix + "NutKunDoLeftPunch2.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Kick1, pathPrefix + "NutKunDoLeftCrouchPunch1.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Kick2, pathPrefix + "NutKunDoLeftCrouchPunch2.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Block, pathPrefix + "NutKunDoLeftBlock.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Crouch, pathPrefix + "NutKunDoLeftCrouch.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.CrouchBlock, pathPrefix + "NutKunDoLeftCrouchBlock.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Hit, pathPrefix + "NutKunDoLeftHit.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.CrouchHit, pathPrefix + "NutKunDoLeftCrouchHit.png", true, isEnableLazySpriteImageLoad));

            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Walk1, pathPrefix + "NutKunDoFrontLeftWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Walk2, pathPrefix + "NutKunDoFrontLeftWalk2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Punch1, pathPrefix + "NutKunDoFrontLeftPunch1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Punch2, pathPrefix + "NutKunDoFrontLeftPunch2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Kick1, pathPrefix + "NutKunDoFrontLeftCrouchPunch1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Kick2, pathPrefix + "NutKunDoFrontLeftCrouchPunch2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Block, pathPrefix + "NutKunDoFrontLeftBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Crouch, pathPrefix + "NutKunDoFrontLeftCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.CrouchBlock, pathPrefix + "NutKunDoFrontLeftCrouchBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Hit, pathPrefix + "NutKunDoFrontLeftHit.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.CrouchHit, pathPrefix + "NutKunDoFrontLeftCrouchHit.png", isEnableLazySpriteImageLoad));

            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Walk1, pathPrefix + "NutKunDoFrontLeftWalk1.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Walk2, pathPrefix + "NutKunDoFrontLeftWalk2.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Punch1, pathPrefix + "NutKunDoFrontLeftPunch1.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Punch2, pathPrefix + "NutKunDoFrontLeftPunch2.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Kick1, pathPrefix + "NutKunDoFrontLeftCrouchPunch1.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Kick2, pathPrefix + "NutKunDoFrontLeftCrouchPunch2.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Block, pathPrefix + "NutKunDoFrontLeftBlock.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Crouch, pathPrefix + "NutKunDoFrontLeftCrouch.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.CrouchBlock, pathPrefix + "NutKunDoFrontLeftCrouchBlock.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Hit, pathPrefix + "NutKunDoFrontLeftHit.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.CrouchHit, pathPrefix + "NutKunDoFrontLeftCrouchHit.png", true, isEnableLazySpriteImageLoad));

            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Walk1, pathPrefix + "NutKunDoBackLeftWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Walk2, pathPrefix + "NutKunDoBackLeftWalk2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Punch1, pathPrefix + "NutKunDoBackLeftPunch1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Punch2, pathPrefix + "NutKunDoBackLeftPunch2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Kick1, pathPrefix + "NutKunDoBackLeftCrouchPunch1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Kick2, pathPrefix + "NutKunDoBackLeftCrouchPunch2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Block, pathPrefix + "NutKunDoBackLeftBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Crouch, pathPrefix + "NutKunDoBackLeftCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.CrouchBlock, pathPrefix + "NutKunDoBackLeftCrouchBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Hit, pathPrefix + "NutKunDoBackLeftHit.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.CrouchHit, pathPrefix + "NutKunDoBackLeftCrouchHit.png", isEnableLazySpriteImageLoad));

            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Walk1, pathPrefix + "NutKunDoBackLeftWalk1.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Walk2, pathPrefix + "NutKunDoBackLeftWalk2.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Punch1, pathPrefix + "NutKunDoBackLeftPunch1.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Punch2, pathPrefix + "NutKunDoBackLeftPunch2.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Kick1, pathPrefix + "NutKunDoBackLeftCrouchPunch1.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Kick2, pathPrefix + "NutKunDoBackLeftCrouchPunch2.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Block, pathPrefix + "NutKunDoBackLeftBlock.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Crouch, pathPrefix + "NutKunDoBackLeftCrouch.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.CrouchBlock, pathPrefix + "NutKunDoBackLeftCrouchBlock.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Hit, pathPrefix + "NutKunDoBackLeftHit.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.CrouchHit, pathPrefix + "NutKunDoBackLeftCrouchHit.png", true, isEnableLazySpriteImageLoad));


            //For different scalling
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Front, SpriteScallableFrame.Crouch, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Front, SpriteScallableFrame.CrouchBlock, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Front, SpriteScallableFrame.CrouchHit, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Front, SpriteScallableFrame.Kick1, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Front, SpriteScallableFrame.Kick2, 0.6);

            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Back, SpriteScallableFrame.Crouch, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Back, SpriteScallableFrame.CrouchBlock, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Back, SpriteScallableFrame.CrouchHit, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Back, SpriteScallableFrame.Kick1, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Back, SpriteScallableFrame.Kick2, 0.6);

            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Left, SpriteScallableFrame.Crouch, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Left, SpriteScallableFrame.CrouchBlock, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Left, SpriteScallableFrame.CrouchHit, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Left, SpriteScallableFrame.Kick1, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Left, SpriteScallableFrame.Kick2, 0.6);

            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Right, SpriteScallableFrame.Crouch, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Right, SpriteScallableFrame.CrouchBlock, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Right, SpriteScallableFrame.CrouchHit, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Right, SpriteScallableFrame.Kick1, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Right, SpriteScallableFrame.Kick2, 0.6);

            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Crouch, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.CrouchBlock, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.CrouchHit, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Kick1, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Kick2, 0.6);

            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Crouch, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.FrontRight, SpriteScallableFrame.CrouchBlock, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.FrontRight, SpriteScallableFrame.CrouchHit, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Kick1, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Kick2, 0.6);

            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Crouch, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.BackLeft, SpriteScallableFrame.CrouchBlock, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.BackLeft, SpriteScallableFrame.CrouchHit, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Kick1, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Kick2, 0.6);

            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.BackRight, SpriteScallableFrame.Crouch, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.BackRight, SpriteScallableFrame.CrouchBlock, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.BackRight, SpriteScallableFrame.CrouchHit, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.BackRight, SpriteScallableFrame.Kick1, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.BackRight, SpriteScallableFrame.Kick2, 0.6);

            //Offsets
            spriteCache.SetOffset(SpriteScallableFrame.Left, SpriteScallableFrame.Punch2, -0.5, 0);
            spriteCache.SetOffset(SpriteScallableFrame.Right, SpriteScallableFrame.Punch2, 0.5, 0);
            spriteCache.SetOffset(SpriteScallableFrame.Left, SpriteScallableFrame.Kick2, -0.5, 0);
            spriteCache.SetOffset(SpriteScallableFrame.Right, SpriteScallableFrame.Kick2, 0.5, 0);

            spriteCache.SetOffset(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Punch2, -0.5, 0);
            spriteCache.SetOffset(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Punch2, 0.5, 0);
            spriteCache.SetOffset(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Kick2, -0.5, 0);
            spriteCache.SetOffset(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Kick2, 0.5, 0);

            spriteCache.SetOffset(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Punch2, -0.333, 0);
            spriteCache.SetOffset(SpriteScallableFrame.BackRight, SpriteScallableFrame.Punch2, 0.333, 0);
            spriteCache.SetOffset(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Kick2, -0.333, 0);
            spriteCache.SetOffset(SpriteScallableFrame.BackRight, SpriteScallableFrame.Kick2, 0.333, 0);
        }

        private void BuildAladdin(SpriteCache3D spriteCache, bool isEnableLazySpriteImageLoad)
        {
            string pathPrefix = "CvmFight/Assets/Sprites/Aladdin/";

            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Walk1, pathPrefix + "AladdinFrontWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Walk2, pathPrefix + "AladdinFrontWalk2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Punch1, pathPrefix + "AladdinFrontPunch1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Punch2, pathPrefix + "AladdinFrontPunch2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Kick1, pathPrefix + "AladdinFrontCrouchPunch1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Kick2, pathPrefix + "AladdinFrontCrouchPunch2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Block, pathPrefix + "AladdinFrontBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Crouch, pathPrefix + "AladdinFrontCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.CrouchBlock, pathPrefix + "AladdinFrontCrouchBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.Hit, pathPrefix + "AladdinFrontHit.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Front, SpriteScallableFrame.CrouchHit, pathPrefix + "AladdinFrontCrouchHit.png", isEnableLazySpriteImageLoad));

            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Walk1, pathPrefix + "AladdinBackWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Walk2, pathPrefix + "AladdinBackWalk2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Punch1, pathPrefix + "AladdinBackWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Punch2, pathPrefix + "AladdinBackWalk2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Kick1, pathPrefix + "AladdinBackCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Kick2, pathPrefix + "AladdinBackCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Block, pathPrefix + "AladdinBackWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Crouch, pathPrefix + "AladdinBackCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.CrouchBlock, pathPrefix + "AladdinBackCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.Hit, pathPrefix + "AladdinBackWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Back, SpriteScallableFrame.CrouchHit, pathPrefix + "AladdinBackCrouch.png", isEnableLazySpriteImageLoad));

            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Walk1, pathPrefix + "AladdinLeftWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Walk2, pathPrefix + "AladdinLeftWalk2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Punch1, pathPrefix + "AladdinLeftWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Punch2, pathPrefix + "AladdinLeftPunch2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Kick1, pathPrefix + "AladdinLeftCrouchPunch1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Kick2, pathPrefix + "AladdinLeftCrouchPunch2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Block, pathPrefix + "AladdinLeftBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Crouch, pathPrefix + "AladdinLeftCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.CrouchBlock, pathPrefix + "AladdinLeftCrouchBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.Hit, pathPrefix + "AladdinLeftHit.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Left, SpriteScallableFrame.CrouchHit, pathPrefix + "AladdinLeftCrouchHit.png", isEnableLazySpriteImageLoad));

            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Walk1, pathPrefix + "AladdinLeftWalk1.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Walk2, pathPrefix + "AladdinLeftWalk2.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Punch1, pathPrefix + "AladdinLeftWalk1.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Punch2, pathPrefix + "AladdinLeftPunch2.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Kick1, pathPrefix + "AladdinLeftCrouchPunch1.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Kick2, pathPrefix + "AladdinLeftCrouchPunch2.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Block, pathPrefix + "AladdinLeftBlock.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Crouch, pathPrefix + "AladdinLeftCrouch.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.CrouchBlock, pathPrefix + "AladdinLeftCrouchBlock.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.Hit, pathPrefix + "AladdinLeftHit.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Right, SpriteScallableFrame.CrouchHit, pathPrefix + "AladdinLeftCrouchHit.png", true, isEnableLazySpriteImageLoad));

            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Walk1, pathPrefix + "AladdinFrontLeftWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Walk2, pathPrefix + "AladdinFrontLeftWalk2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Punch1, pathPrefix + "AladdinFrontLeftWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Punch2, pathPrefix + "AladdinFrontLeftPunch2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Kick1, pathPrefix + "AladdinFrontLeftCrouchPunch1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Kick2, pathPrefix + "AladdinFrontLeftCrouchPunch2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Block, pathPrefix + "AladdinFrontLeftBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Crouch, pathPrefix + "AladdinFrontLeftCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.CrouchBlock, pathPrefix + "AladdinFrontLeftCrouchBlock.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Hit, pathPrefix + "AladdinFrontLeftHit.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.CrouchHit, pathPrefix + "AladdinFrontLeftCrouchHit.png", isEnableLazySpriteImageLoad));

            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Walk1, pathPrefix + "AladdinFrontLeftWalk1.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Walk2, pathPrefix + "AladdinFrontLeftWalk2.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Punch1, pathPrefix + "AladdinFrontLeftWalk1.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Punch2, pathPrefix + "AladdinFrontLeftPunch2.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Kick1, pathPrefix + "AladdinFrontLeftCrouchPunch1.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Kick2, pathPrefix + "AladdinFrontLeftCrouchPunch2.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Block, pathPrefix + "AladdinFrontLeftBlock.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Crouch, pathPrefix + "AladdinFrontLeftCrouch.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.CrouchBlock, pathPrefix + "AladdinFrontLeftCrouchBlock.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Hit, pathPrefix + "AladdinFrontLeftHit.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.FrontRight, SpriteScallableFrame.CrouchHit, pathPrefix + "AladdinFrontLeftCrouchHit.png", true, isEnableLazySpriteImageLoad));

            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Walk1, pathPrefix + "AladdinBackLeftWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Walk2, pathPrefix + "AladdinBackLeftWalk2.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Punch1, pathPrefix + "AladdinBackLeftWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Punch2, pathPrefix + "AladdinBackLeftWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Kick1, pathPrefix + "AladdinBackLeftCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Kick2, pathPrefix + "AladdinBackLeftCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Block, pathPrefix + "AladdinBackLeftWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Crouch, pathPrefix + "AladdinBackLeftCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.CrouchBlock, pathPrefix + "AladdinBackLeftCrouch.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Hit, pathPrefix + "AladdinBackLeftWalk1.png", isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackLeft, SpriteScallableFrame.CrouchHit, pathPrefix + "AladdinBackLeftCrouch.png", isEnableLazySpriteImageLoad));

            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Walk1, pathPrefix + "AladdinBackLeftWalk1.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Walk2, pathPrefix + "AladdinBackLeftWalk2.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Punch1, pathPrefix + "AladdinBackLeftWalk1.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Punch2, pathPrefix + "AladdinBackLeftWalk1.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Kick1, pathPrefix + "AladdinBackLeftCrouch.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Kick2, pathPrefix + "AladdinBackLeftCrouch.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Block, pathPrefix + "AladdinBackLeftWalk1.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Crouch, pathPrefix + "AladdinBackLeftCrouch.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.CrouchBlock, pathPrefix + "AladdinBackLeftCrouch.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.Hit, pathPrefix + "AladdinBackLeftWalk1.png", true, isEnableLazySpriteImageLoad));
            spriteCache.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.BackRight, SpriteScallableFrame.CrouchHit, pathPrefix + "AladdinBackLeftCrouch.png", true, isEnableLazySpriteImageLoad));


            //For different scalling
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Front, SpriteScallableFrame.Crouch, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Front, SpriteScallableFrame.CrouchBlock, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Front, SpriteScallableFrame.CrouchHit, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Front, SpriteScallableFrame.Kick1, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Front, SpriteScallableFrame.Kick2, 0.6);

            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Back, SpriteScallableFrame.Crouch, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Back, SpriteScallableFrame.CrouchBlock, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Back, SpriteScallableFrame.CrouchHit, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Back, SpriteScallableFrame.Kick1, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Back, SpriteScallableFrame.Kick2, 0.6);

            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Left, SpriteScallableFrame.Crouch, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Left, SpriteScallableFrame.CrouchBlock, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Left, SpriteScallableFrame.CrouchHit, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Left, SpriteScallableFrame.Kick1, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Left, SpriteScallableFrame.Kick2, 0.6);

            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Right, SpriteScallableFrame.Crouch, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Right, SpriteScallableFrame.CrouchBlock, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Right, SpriteScallableFrame.CrouchHit, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Right, SpriteScallableFrame.Kick1, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.Right, SpriteScallableFrame.Kick2, 0.6);

            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Crouch, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.CrouchBlock, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.CrouchHit, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Hit, 0.66);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Kick1, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Kick2, 0.6);

            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Crouch, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.FrontRight, SpriteScallableFrame.CrouchBlock, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.FrontRight, SpriteScallableFrame.CrouchHit, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Kick1, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Kick2, 0.6);

            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Crouch, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.BackLeft, SpriteScallableFrame.CrouchBlock, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.BackLeft, SpriteScallableFrame.CrouchHit, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Kick1, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Kick2, 0.6);

            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.BackRight, SpriteScallableFrame.Crouch, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.BackRight, SpriteScallableFrame.CrouchBlock, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.BackRight, SpriteScallableFrame.CrouchHit, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.BackRight, SpriteScallableFrame.Kick1, 0.6);
            spriteCache.SetSizeMultiplicator(SpriteScallableFrame.BackRight, SpriteScallableFrame.Kick2, 0.6);

            //Offsets
            spriteCache.SetOffset(SpriteScallableFrame.Left, SpriteScallableFrame.Punch2, -0.5, 0);
            spriteCache.SetOffset(SpriteScallableFrame.Right, SpriteScallableFrame.Punch2, 0.5, 0);
            spriteCache.SetOffset(SpriteScallableFrame.Left, SpriteScallableFrame.Kick2, -0.5, 0);
            spriteCache.SetOffset(SpriteScallableFrame.Right, SpriteScallableFrame.Kick2, 0.5, 0);

            spriteCache.SetOffset(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Punch2, -0.5, 0);
            spriteCache.SetOffset(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Punch2, 0.5, 0);
            spriteCache.SetOffset(SpriteScallableFrame.FrontLeft, SpriteScallableFrame.Kick2, -0.5, 0);
            spriteCache.SetOffset(SpriteScallableFrame.FrontRight, SpriteScallableFrame.Kick2, 0.5, 0);

            spriteCache.SetOffset(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Punch2, -0.333, 0);
            spriteCache.SetOffset(SpriteScallableFrame.BackRight, SpriteScallableFrame.Punch2, 0.333, 0);
            spriteCache.SetOffset(SpriteScallableFrame.BackLeft, SpriteScallableFrame.Kick2, -0.333, 0);
            spriteCache.SetOffset(SpriteScallableFrame.BackRight, SpriteScallableFrame.Kick2, 0.333, 0);
        }
        #endregion
    }
}