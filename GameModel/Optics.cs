using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlindFPS
{
    static class Optics
    {
        #region Constants
        private const double rayDistanceResolution = 0.01;
        #endregion

        #region Public Methods
        public static double FixAngleDegree(double angle)
        {
	        while (angle > 360)
		        angle -= 360;
	        while (angle < 0)
		        angle += 360;
        		
	        return angle;
        }

        public static bool IsSpriteViewable(AbstractSprite viewerSprite, AbstractSprite viewedSprite, AbstractMap map, int fov)
        {
            if (viewerSprite == viewedSprite)
                return true;


            double angleRadian = FixAngleRadian(GetSpriteAngleToSpriteRadian(viewerSprite, viewedSprite));
            double angleDegree = FixAngleDegree(angleRadian / Math.PI * 180);


            double minimumViewingAngle = FixAngleDegree(viewerSprite.AngleDegree - (double)fov / 1.8);
            double maximumViewingAngle = FixAngleDegree(viewerSprite.AngleDegree + (double)fov / 1.8);


            if (maximumViewingAngle > minimumViewingAngle)
            {
                if (angleDegree < minimumViewingAngle)
                {
                    return false;
                }
                if (angleDegree > maximumViewingAngle)
                {
                    return false;
                }
            }
            else
            {
                if (angleDegree < minimumViewingAngle && angleDegree > maximumViewingAngle)
                {
                    return false;
                }
            }

            double xMove = Math.Cos(angleRadian) * rayDistanceResolution;
            double yMove = Math.Sin(angleRadian) * rayDistanceResolution;

            double x = viewerSprite.PositionX;
            double y = viewerSprite.PositionY;

            double xDistanceToPerform = Math.Abs(viewerSprite.PositionX - viewedSprite.PositionX);
            double yDistanceToPerform = Math.Abs(viewerSprite.PositionY - viewedSprite.PositionY);



            double xDistance = 0;
            double yDistance = 0;

            while (true)
            {
                x += xMove;
                y += yMove;

                xDistance += Math.Abs(xMove);
                yDistance += Math.Abs(yMove);

                if (xDistance >= xDistanceToPerform && yDistance >= yDistanceToPerform)
                {
                    return true;
                }

                if (map.GetMatterTypeAt(x, y) != null)
                {
                    return false;
                }

                if (x < 0 || y < 0 || x > map.Width || y > map.Height)
                {
                    return false;
                }
            }
        }

        public static double FixAngleRadian(double angle)
        {
            while (angle > Math.PI * 2)
                angle -= Math.PI * 2;
            while (angle < 0)
                angle += Math.PI * 2;

            return angle;
        }

        public static double GetSpriteAngleToSpriteRadian(AbstractSprite viewerSprite, AbstractSprite viewedSprite)
        {
            double fullVectorX = viewedSprite.PositionX - viewerSprite.PositionX;
            double fullVectorY = viewedSprite.PositionY - viewerSprite.PositionY;
            return Math.Atan2(fullVectorY, fullVectorX);
        }

        public static double GetStraightDistance(AbstractSprite sprite, RayTracerPoint rayTracerPoint)
        {
            double viewAxisX = Math.Cos(sprite.AngleRadian);
            double viewAxisY = Math.Sin(sprite.AngleRadian);
            double relativePointX = rayTracerPoint.X - sprite.PositionX;
            double relativePointY = rayTracerPoint.Y - sprite.PositionY;
            return viewAxisX * relativePointX + viewAxisY * relativePointY;
        }

        public static double GetStraightDistance(AbstractSprite viewerSprite, AbstractSprite viewedSprite)
        {
            double viewAxisX = Math.Cos(viewerSprite.AngleRadian);
            double viewAxisY = Math.Sin(viewerSprite.AngleRadian);
            double relativePointX = viewedSprite.PositionX - viewerSprite.PositionX;
            double relativePointY = viewedSprite.PositionY - viewerSprite.PositionY;
            return viewAxisX * relativePointX + viewAxisY * relativePointY;
        }

        public static double GetColumnHeight(double distance, double maxColumnHeight, double heightDistanceRatio)
        {
            double columnHeight;
            if (distance == 0)
                columnHeight = maxColumnHeight;
            else
                columnHeight = maxColumnHeight / (distance * heightDistanceRatio);

            return columnHeight;
        }

        public static double GetColumnTopMargin(double maxColumnHeight, double columnHeight, double zPosition, bool isCrouch, double mouseLook)
        {
            if (isCrouch)
                zPosition = -0.75;

            //Jump height from 0 to 1
            double jumpOffset = (zPosition * columnHeight / 2);
            return Math.Round((maxColumnHeight - columnHeight) / 2 + jumpOffset) + mouseLook * maxColumnHeight;
        }

        public static double GetBrightness(double columnHeight, double maxColumnHeight)
        {
            return Math.Round(columnHeight / maxColumnHeight * 255);
        }
        #endregion
    }
}
