using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CvmFight
{
    public class SpritePool : IList<AbstractSprite>
    {
        #region Fields
        private HashSet<AbstractSprite> internalHash = new HashSet<AbstractSprite>();

        private List<AbstractSprite> internalList = new List<AbstractSprite>();
        #endregion

        #region Constructors
        /// <summary>
        /// Create sprite pool
        /// </summary>
        /// <param name="spriteToAdd">sprite to add</param>
        public SpritePool(AbstractHumanoid spriteToAdd)
        {
            Add(spriteToAdd);
        }

        /// <summary>
        /// Create sprite pool
        /// </summary>
        public SpritePool()
        {
        }
        #endregion

        #region IList<AbstractSprite> Membres
        public int IndexOf(AbstractSprite item)
        {
            return internalList.IndexOf(item);
        }

        public void Insert(int index, AbstractSprite item)
        {
            internalList.Insert(index, item);
            internalHash.Add(item);
        }

        public void RemoveAt(int index)
        {
            internalHash.Remove(internalList[index]);
            internalList.RemoveAt(index);
        }

        public AbstractSprite this[int index]
        {
            get
            {
                return internalList[index];
            }
            set
            {
                internalHash.Add(value);
                internalList[index] = value;
            }
        }

        public void Add(AbstractSprite item)
        {
            internalHash.Add(item);
            internalList.Add(item);
        }

        public void Clear()
        {
            internalList.Clear();
            internalHash.Clear();
        }

        public bool Contains(AbstractSprite item)
        {
            return internalHash.Contains(item);
        }

        public void CopyTo(AbstractSprite[] array, int arrayIndex)
        {
            internalList.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return internalList.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(AbstractSprite item)
        {
            return internalHash.Remove(item) && internalList.Remove(item);
        }

        public IEnumerator<AbstractSprite> GetEnumerator()
        {
            return internalList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return internalList.GetEnumerator();
        }
        #endregion

        public void SortByDistance(AbstractSprite referenceSprite)
        {
            foreach (AbstractSprite sprite in internalList)
                sprite.DistanceToReferenceSprite = Optics.GetStraightDistance(referenceSprite, sprite);

            internalList.Sort();
        }
    }
}
