using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SdlDotNet.Graphics.Primitives;
using SdlDotNet.Graphics;

namespace BlindFPS
{
    class SpritePrimitiveCache
    {
        #region Fields
        private Dictionary<AbstractHumanoid, IPrimitive> internalCache = new Dictionary<AbstractHumanoid, IPrimitive>();
        #endregion

        #region Public Methods
        public bool TryGetValue(AbstractHumanoid sprite, out IPrimitive circle)
        {
            return internalCache.TryGetValue(sprite, out circle);
        }

        public void Add(AbstractHumanoid sprite, IPrimitive circle)
        {
            internalCache.Add(sprite, circle);
        }
        #endregion
    }
}
