using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace BlindFPS
{
    public class Spawner
    {
        #region Fields and parts
        private AbstractMap map = null;

        private EmptyMapLocationCache emptyMapLocationCache;

        private Random random;
        #endregion

        #region Constructor
        public Spawner(Random random)
        {
            this.random = random;
        }
        #endregion

        #region Public Methods
        public void TryRespawn(SpritePool spritePool, AbstractMap map)
        {
            foreach (AbstractHumanoid sprite in spritePool)
                if (!sprite.IsAlive)
                    Respawn(sprite, map, spritePool);
        }
        #endregion

        #region Private Methods
        private void Respawn(AbstractHumanoid fighter, AbstractMap map, SpritePool spritePool)
        {
            if (this.map != map)
            {
                this.map = map;
                emptyMapLocationCache = new EmptyMapLocationCache(this.map);
            }

            Point point;
            do
            {
                point = emptyMapLocationCache.GetRandomAvailableLocation(map, spritePool, random);
                fighter.PositionX = (double)point.X + 0.5;
                fighter.PositionY = (double)point.Y + 0.5;
            } while (Physics.IsDetectCollision(fighter, spritePool, map));

            fighter.Health = fighter.DefaultHealth;
            fighter.AngleDegree = random.Next(360);
            fighter.ReceivedAttackCycle.Reset();
        }
        #endregion
    }
}
