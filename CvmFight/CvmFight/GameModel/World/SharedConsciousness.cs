using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CvmFight
{
    /// <summary>
    /// Represents common conscousness among sprites
    /// </summary>
    public class SharedConsciousness
    {
        #region Fields
        private int spriteCount;

        private Dictionary<AbstractHumanoid, Dictionary<AbstractHumanoid,bool>> internalList = new Dictionary<AbstractHumanoid, Dictionary<AbstractHumanoid,bool>>();
        #endregion

        #region Constructor
        public SharedConsciousness(int spriteCount)
        {
            this.spriteCount = spriteCount;
        }
        #endregion

        #region Public Methods
        public void Clear()
        {
            foreach (Dictionary<AbstractHumanoid,bool> spriteList in internalList.Values)
                spriteList.Clear();
        }

        public bool IsSpriteViewable(AbstractHumanoid viewerSprite, AbstractHumanoid viewedSprite, AbstractMap map, int fov)
        {
            Dictionary<AbstractHumanoid, bool> viewedList;
            if (!internalList.TryGetValue(viewerSprite, out viewedList))
            {
                viewedList = new Dictionary<AbstractHumanoid, bool>();
                internalList.Add(viewerSprite, viewedList);
            }

            bool isViewed;
            if (!viewedList.TryGetValue(viewedSprite, out isViewed))
            {
                isViewed = Optics.IsSpriteViewable(viewerSprite, viewedSprite, map, fov);
                viewedList.Add(viewedSprite, isViewed);
            }

            return isViewed;
        }
        #endregion
    }
}
