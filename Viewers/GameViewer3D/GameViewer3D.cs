using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using SdlDotNet.Graphics;
using SdlDotNet.Core;
using SdlDotNet.Graphics.Primitives;

namespace BlindFPS
{
    class GameViewer3D : AbstractGameViewer
    {
        #region Constants
        private double heightDistanceRatio = 2;
        #endregion

        #region Fields and parts
        private bool isMiniMapOn;

        private bool isSoundOn;

        private int screenWidth;

        private int screenHeight;

        private Surface mainSurface;

        private ColumnViewer columnViewer;

        private Gradient gradient;

        private MiniMap minimap;

        private Random random;
        #endregion

        #region Constructor
        public GameViewer3D(Surface mainSurface, int screenWidth, int screenHeight, int columnCount, SpritePool spritePool, int fov, Random random, AbstractMap map, bool isSoundOn, EcholocationCycle echolocationCycle, EcholocationBeeper echolocationBeeper)
        {
            this.mainSurface = mainSurface;
            this.isSoundOn = isSoundOn;
            this.random = random;
            minimap = new MiniMap(screenWidth, screenHeight, map);

            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;

            this.gradient = new Gradient(screenWidth, screenHeight * 2);

            columnViewer = new ColumnViewer(this.screenWidth, this.screenHeight, columnCount, heightDistanceRatio, echolocationCycle, echolocationBeeper);
        }
        #endregion

        #region Public Methods
        public override void Update(World world, RayTracer rayTracer)
        {
            int receivedAttackCycle = world.CurrentPlayer.ReceivedAttackCycle.GetCycleState();
            if (receivedAttackCycle > 0 && (receivedAttackCycle == 0 || (random.Next(6) == 0)))
            {
                mainSurface.Fill(Color.Red);
            }
            else
            {
                int gradientOffset = (int)(world.CurrentPlayer.MouseLook * screenHeight) - screenHeight / 2;
                mainSurface.Blit(gradient.Surface, PointLoader.GetPoint(0, gradientOffset));

                columnViewer.Update(world.CurrentPlayer, rayTracer, world.Map, mainSurface);

                if (isMiniMapOn)
                    minimap.Update(world, rayTracer, mainSurface);
            }

            mainSurface.Update();
        }
        #endregion

        #region Properties
        public override bool IsMiniMapOn
        {
            get { return isMiniMapOn; }
            set { isMiniMapOn = value; }
        }
        #endregion
    }
}