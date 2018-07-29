using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CvmFight
{
    /// <summary>
    /// Game viewer (3d or minimap, etc)
    /// </summary>
    abstract class AbstractGameViewer
    {
        public abstract void Update(World world, RayTracer rayTracer);

        public abstract bool IsMiniMapOn
        {
            get;
            set;
        }
    }
}
