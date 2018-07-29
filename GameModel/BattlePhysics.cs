using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CvmFight
{
    static class BattlePhysics
    {
        #region Public Methods
        /// <summary>
        /// Throw a projectile sprite
        /// </summary>
        /// <param name="projectile">projectile sprite</param>
        /// <param name="spritePool">sprite pool</param>
        /// <param name="map">map</param>
        /// <param name="timeDelta">time delta</param>
        public static void MoveProjectile(AbstractProjectile projectile, SpritePool spritePool, AbstractMap map, double timeDelta)
        {
            double xMove = Math.Cos(projectile.AngleRadian) * projectile.DefaultWalkingDistance * timeDelta;
            double yMove = Math.Sin(projectile.AngleRadian) * projectile.DefaultWalkingDistance * timeDelta;
            projectile.PositionX += xMove;
            projectile.PositionY += yMove;
        }

        /// <summary>
        /// Whether prey is withing predator's attack range
        /// </summary>
        /// <param name="predator">predator sprite</param>
        /// <param name="prey">prey sprite</param>
        /// <returns>Whether prey is withing predator's attack range</returns>
        public static bool IsWithinAttackRange(AbstractHumanoid predator, AbstractSprite prey)
        {
            return Physics.GetSpriteDistance(predator, prey) <= GetAttackRange(predator, prey);// predatorAttackRange + prey.Radius;
        }

        /// <summary>
        /// Whether prey is withing predator's attack range
        /// </summary>
        /// <param name="predator">predator sprite</param>
        /// <param name="prey">prey sprite</param>
        /// <returns>Whether prey is withing predator's attack range</returns>
        public static bool IsWithinAttackRange(AbstractHumanoid predator, AbstractHumanoid prey, double multiplicator)
        {
            return Physics.GetSpriteDistance(predator, prey) <= GetAttackRange(predator, prey) * multiplicator;// predatorAttackRange + prey.Radius;
        }

        /// <summary>
        /// Whether sprite 1 can attack or block sprite 2 because angle allows it
        /// </summary>
        /// <param name="sprite1">sprite 1</param>
        /// <param name="sprite2">sprite 2</param>
        /// <returns>Whether sprite 1 can attack or block sprite 2 because angle allows it</returns>
        public static bool IsInAttackOrBlockAngle(AbstractHumanoid sprite1, AbstractHumanoid sprite2)
        {
            double angleToSprite = Optics.GetSpriteAngleToSpriteRadian(sprite1, sprite2);

            double attackAngleRange = sprite1.AttackAngleRange;

            if (Math.Abs(angleToSprite - sprite1.AngleRadian) < attackAngleRange)
                return true;
            else if (Math.Abs(angleToSprite - sprite1.AngleRadian + Math.PI * 2.0) < attackAngleRange)
                return true;
            else if (Math.Abs(angleToSprite - sprite1.AngleRadian + Math.PI * 2.0) < attackAngleRange)
                return true;

            return false;
        }

        /// <summary>
        /// Whether predator can attack prey
        /// </summary>
        /// <param name="predator">predator</param>
        /// <param name="prey">prey</param>
        /// <returns>whether predator can attack prey</returns>
        public static bool IsInAttackHeight(AbstractHumanoid predator, AbstractHumanoid prey)
        {
            if (predator.IsCrouch)
            {
                if (prey.IsCrouch)
                {
                    return true;
                }
                else if (prey.PositionZ <= predator.Height / 2)
                {
                    return true;
                }
            }
            else
            {
                if (!prey.IsCrouch)
                {
                    return true;
                }
                else if (predator.PositionZ > 0 && predator.PositionZ < prey.Height / 2)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Whether sprite 1 has a valid height to block sprite2's attack
        /// </summary>
        /// <param name="sprite1">sprite 1</param>
        /// <param name="sprite2">sprite 2</param>
        /// <returns>whether sprite 1 has a valid height to block sprite2's attack</returns>
        public static bool IsInBlockingHeight(AbstractHumanoid sprite1, AbstractHumanoid sprite2)
        {
            if (!sprite1.IsCrouch && !sprite2.IsCrouch && sprite1.PositionZ <= 0 && sprite2.PositionZ <= 0)
                return true;

            if (sprite1.PositionZ > sprite2.Height / 4)
                return false;

            if (sprite1.IsCrouch && sprite2.PositionZ > 0)
                return false;

            if (!sprite1.IsCrouch && sprite2.IsCrouch)
                return false;

            return true;
        }

        public static double BuildSpinAttackRotation(double firstAngle, double percentComplete)
        {
            return Optics.FixAngleRadian(firstAngle + (percentComplete * 2.0 * Math.PI));
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Distance for which predator sprite can attack prey
        /// </summary>
        /// <param name="predator">predator</param>
        /// <param name="prey">prey</param>
        /// <returns>Distance for which predator sprite can attack prey</returns>
        private static double GetAttackRange(AbstractHumanoid predator, AbstractSprite prey)
        {
            double predatorAttackRange = predator.AttackRange;
            if (predator.PositionZ > 0)
                predatorAttackRange *= predator.AttackRangeJumpMultiplier;
            else if (predator.IsCrouch)
                predatorAttackRange *= predator.AttackRangeCrouchMultiplier;

            return predatorAttackRange;
        }
        #endregion
    }
}
