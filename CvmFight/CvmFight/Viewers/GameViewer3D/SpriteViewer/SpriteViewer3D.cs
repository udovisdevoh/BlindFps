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
    class SpriteViewer3D
    {
        #region Fields and parts
        private int screenWidth;

        private int screenHeight;

        private int fov;

        private double heightDistanceRatio;

        private SpriteCollectionCache3D spriteCollectionCache3D;

        private SpriteCache3D splatCache3D;

        private SpriteCache3D chargeCache3D;

        private EnergyBarViewer energyBarViewer;

        private Random random;

        private Rectangle rectangle = new Rectangle();
        #endregion

        #region Constructor
        public SpriteViewer3D(int screenWidth, int screenHeight, SpritePool spritePool, int fov, double heightDistanceRatio, bool isEnableSpriteCache, bool isEnableLazySpriteImageLoad, Random random)
        {
            this.random = random;
            this.heightDistanceRatio = heightDistanceRatio;
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
            this.fov = fov;
            spriteCollectionCache3D = new SpriteCollectionCache3D(spritePool, isEnableSpriteCache, isEnableLazySpriteImageLoad);

            splatCache3D = new SpriteCache3D(isEnableSpriteCache, isEnableLazySpriteImageLoad);
            splatCache3D.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Undefined, SpriteScallableFrame.Undefined, "CvmFight/Assets/Sprites/Effects/splat001.png", isEnableLazySpriteImageLoad));

            chargeCache3D = new SpriteCache3D(isEnableSpriteCache, isEnableLazySpriteImageLoad);
            chargeCache3D.AddFrame(new SpriteScallableFrame(SpriteScallableFrame.Undefined, SpriteScallableFrame.Undefined, "CvmFight/Assets/Sprites/Effects/charge001.png", isEnableLazySpriteImageLoad));

            energyBarViewer = new EnergyBarViewer();
        }
        #endregion

        #region Public Methods
        public void View(AbstractHumanoid viewerSprite, AbstractHumanoid viewedSprite, Surface mainSurface)
        {
            double angleDegree = (Optics.GetSpriteAngleToSpriteRadian(viewerSprite, viewedSprite) - viewerSprite.AngleRadian) / Math.PI * 180.0;
            double straightDistance = Optics.GetStraightDistance(viewerSprite, viewedSprite);
            double theoreticalColumnHeight = Optics.GetColumnHeight(straightDistance, screenHeight, heightDistanceRatio);
            double topMargin = Optics.GetColumnTopMargin(screenHeight, theoreticalColumnHeight, viewerSprite.PositionZ, viewerSprite.IsCrouch, viewerSprite.MouseLook);


            while (angleDegree < (0 - fov / 2))
                angleDegree += 360.0;

            while (angleDegree > (0 + fov / 2))
                angleDegree -= 360.0;


            //byte brightness = (byte)(columnHeight / maxColumnHeight * 255);

            int spriteHeight = (int)(theoreticalColumnHeight * 0.6 * viewedSprite.Height);
            int destinationX = 0;
            int destinationY;

            

            byte angleType = GetAngleType(viewerSprite.AngleDegree, viewedSprite.AngleDegree);

            byte spriteStatus;



            int attackCycleState = Math.Max(viewedSprite.StrongAttackCycle.GetCycleState(), viewedSprite.FastAttackCycle.GetCycleState());

            int receivedAttackCycleState = viewedSprite.ReceivedAttackCycle.GetCycleState();

            if (viewedSprite.SpinAttackCycle.IsFired)
                attackCycleState = 2;

            if (viewedSprite.IsCrouch)
            {
                if (receivedAttackCycleState != 0)
                {
                    spriteStatus = SpriteScallableFrame.CrouchHit;
                }
                else if (attackCycleState == 2)
                {
                    spriteStatus = SpriteScallableFrame.Kick2;
                }
                else if (attackCycleState == 1)
                {
                    spriteStatus = SpriteScallableFrame.Kick1;
                }
                else if (viewedSprite.IsBlock)
                {
                    spriteStatus = SpriteScallableFrame.CrouchBlock;
                }
                else
                {
                    spriteStatus = SpriteScallableFrame.Crouch;
                }
            }
            else
            {
                if (receivedAttackCycleState != 0)
                {
                    spriteStatus = SpriteScallableFrame.Hit;
                }
                else if (attackCycleState == 1)
                {
                    if (viewedSprite.PositionZ > 0)
                    {
                        spriteStatus = SpriteScallableFrame.Kick1;
                    }
                    else
                    {
                        spriteStatus = SpriteScallableFrame.Punch1;
                    }
                }
                else if (attackCycleState == 2)
                {
                    if (viewedSprite.PositionZ > 0)
                    {
                        spriteStatus = SpriteScallableFrame.Kick2;
                    }
                    else
                    {
                        spriteStatus = SpriteScallableFrame.Punch2;
                    }
                }
                else if (viewedSprite.IsBlock)
                {
                    spriteStatus = SpriteScallableFrame.Block;
                }
                else if (viewedSprite.PositionZ > 0) //jump looks like crouch
                {
                    spriteStatus = SpriteScallableFrame.Crouch ;
                }
                else if (viewedSprite.WalkCycle.IsForward)
                {
                    spriteStatus = SpriteScallableFrame.Walk1;
                }
                else
                {
                    spriteStatus = SpriteScallableFrame.Walk2;
                }
            }

            SpriteCache3D spriteCache3D = spriteCollectionCache3D.GetSpriteCache(viewedSprite);

            spriteHeight = (int)(((double)spriteHeight) * spriteCache3D.GetSizeMultiplicator(angleType, spriteStatus));

            Surface spriteSurface = spriteCache3D.GetSurface(spriteStatus, angleType, spriteHeight);

            int offsetX = (int)spriteCache3D.GetOffsetX(angleType, spriteStatus) * spriteSurface.Width;
            int offsetY = (int)spriteCache3D.GetOffsetY(angleType, spriteStatus) * spriteSurface.Width;

            destinationX = (int)(getXPosition(angleDegree, fov, screenWidth, spriteSurface.Width)) + offsetX;
            destinationY = (int)(topMargin + theoreticalColumnHeight - spriteSurface.Height) + offsetY;

            destinationY -= (int)(viewedSprite.PositionZ * theoreticalColumnHeight / 2);

            if (PointLoader.IsPositionValid(destinationX, destinationY))
            {
                if (destinationX < 0)
                {
                    rectangle.X = destinationX * -1;
                    rectangle.Y = 0;
                    rectangle.Width = spriteSurface.Width;
                    rectangle.Height = spriteSurface.Height - destinationX;

                    mainSurface.Blit(spriteSurface, PointLoader.GetPoint(0, destinationY), rectangle);
                }
                /*else if (destinationX + spriteSurface.Height > screenHeight)
                {
                    rectangle.X = 0;
                    rectangle.Y = 0;
                    rectangle.Width = spriteSurface.Width;
                    rectangle.Height = screenHeight - destinationX;

                    mainSurface.Blit(spriteSurface, PointLoader.GetPoint(destinationX, destinationY), rectangle);
                }*/
                else
                {
                    mainSurface.Blit(spriteSurface, PointLoader.GetPoint(destinationX, destinationY));
                }
            }

            //We show the viewed sprite's energy bar
            energyBarViewer.View(mainSurface, viewedSprite, PointLoader.GetPoint(destinationX, destinationY), theoreticalColumnHeight);


            //We show splat image on views sprite if the sprite is getting attacked by viewer sprite
            if (viewedSprite.LatestAttacker == viewerSprite && viewedSprite.ReceivedAttackCycle.IsFired)
            {
                int viewedSpriteReceivedAttack = viewedSprite.ReceivedAttackCycle.GetCycleState();
                if (viewedSpriteReceivedAttack >= 0 && (viewedSpriteReceivedAttack == 0 || random.Next(6) == 0))
                    mainSurface.Blit(splatCache3D.GetSurface(SpriteScallableFrame.Undefined, SpriteScallableFrame.Undefined, spriteHeight), PointLoader.GetPoint(destinationX, destinationY));
            }

            //We show charging for charging sprites
            if (viewedSprite.SpinChargeAttackCycle.IsFired && random.Next(2) == 0)
            {
                int chargeSpriteHeight = destinationY + (int)((double)(spriteHeight) * (1.0 - viewedSprite.SpinChargeAttackCycle.PercentComplete));
                mainSurface.Blit(chargeCache3D.GetSurface(SpriteScallableFrame.Undefined, SpriteScallableFrame.Undefined, spriteHeight / 10), PointLoader.GetPoint(destinationX, chargeSpriteHeight));
            }
        }

        private byte GetAngleType(double viewerAngleDegree, double viewedAngleDegree)
        {          
            double relativeAngle = Optics.FixAngleDegree(viewedAngleDegree - viewerAngleDegree + 180);


            byte angleType = SpriteScallableFrame.Front;

            /*if (relativeAngle >= 337 || relativeAngle <= 22 )
                angleType = SpriteScallableFrame.Front;
            else */if (relativeAngle >= 157 && relativeAngle <= 202)
                angleType = SpriteScallableFrame.Back;
            if (relativeAngle >= 67 && relativeAngle <= 112)
                angleType = SpriteScallableFrame.Left;
            else if (relativeAngle >= 247 && relativeAngle <= 292)
                angleType = SpriteScallableFrame.Right;
            else if (relativeAngle >= 22 && relativeAngle <= 67)
                angleType = SpriteScallableFrame.FrontLeft;
            else if (relativeAngle >= 292 && relativeAngle <= 337)
                angleType = SpriteScallableFrame.FrontRight;
            else if (relativeAngle >= 112 && relativeAngle <= 157)
                angleType = SpriteScallableFrame.BackLeft;
            else if (relativeAngle >= 202 && relativeAngle <= 247)
                angleType = SpriteScallableFrame.BackRight;

            return angleType;
        }
        #endregion

        #region Private Methods
        private double getXPosition(double angleDegree, int fov, int screenWidth, int spriteWidth)
        {
            return angleDegree / (double)(fov) * (double)(screenWidth) + ((double)(screenWidth) / 2.0) -((double)(spriteWidth) / 2.0);
        }
        #endregion
    }
}
