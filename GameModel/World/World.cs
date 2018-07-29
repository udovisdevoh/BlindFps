using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CvmFight
{
    /// <summary>
    /// Represents the map, the player and the monsters
    /// </summary>
    public class World
    {
        #region Members
        /// <summary>
        /// How many desired monsters
        /// </summary>
        private int monsterCount;

        /// <summary>
        /// Current player
        /// </summary>
        private Player currentPlayer = new Player();

        /// <summary>
        /// Map
        /// </summary>
        private AbstractMap map;

        /// <summary>
        /// Sprite pool
        /// </summary>
        private SpritePool spritePool;

        /// <summary>
        /// Manages spawning and respawning
        /// </summary>
        private Spawner spawner;

        /// <summary>
        /// Sprite shared consciousness
        /// </summary>
        private SharedConsciousness sharedConsciousness;

        /// <summary>
        /// Random number generator
        /// </summary>
        private Random random;
        #endregion

        #region Constructor
        public World(Random random, int monsterCount)
        {
            this.monsterCount = monsterCount;
            this.random = random;
            spawner = new Spawner(random);
            //map = new HardCodedMap();
            //map = new CachedWaveMap(random);
            map = new MapFromImage("CvmFight/Assets/Maps/CvmMap.png", random);
            spritePool = new SpritePool(currentPlayer);

            sharedConsciousness = new SharedConsciousness(spritePool.Count);

            for (int i = 0; i < monsterCount; i++)
            {
                int randomNumber = random.Next(3);
                if (randomNumber == 0)
                    spritePool.Add(new MonsterStickMan());
                else if (randomNumber == 1)
                    spritePool.Add(new MonsterNutKunDo());
                else
                    spritePool.Add(new MonsterAladdin());
            }

            spawner.TryRespawn(spritePool,map);
        }
        #endregion

        #region Properties
        public AbstractMap Map
        {
            get { return map; }
        }

        public SpritePool SpritePool
        {
            get { return spritePool; }
        }

        public Player CurrentPlayer
        {
            get{return currentPlayer;}
        }

        public SharedConsciousness SharedConsciousness
        {
            get { return sharedConsciousness; }
        }

        public Spawner Spawner
        {
            get { return spawner; }
        }
        #endregion
    }
}