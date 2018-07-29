using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CvmFight
{
    abstract class AbstractProjectile : AbstractSprite
    {
        #region Public Methods
        public override void Update(double timeDelta, SpritePool spritePool, AbstractMap map)
        {
            BattlePhysics.MoveProjectile(this, spritePool, map, timeDelta);
        }

        public abstract double GetDefaultDistance();

        public abstract double GetRadius();
        #endregion
    }
}
