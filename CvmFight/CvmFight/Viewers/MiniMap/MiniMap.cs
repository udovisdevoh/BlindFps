using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using SdlDotNet.Graphics;
using SdlDotNet.Core;
using SdlDotNet.Graphics.Primitives;

namespace CvmFight
{
    class MiniMap
    {
        #region Fields and parts
        private double precision;

        private SpritePrimitiveCache circleCache = new SpritePrimitiveCache();

        private SpritePrimitiveCache angleLineCache = new SpritePrimitiveCache();

        private AbstractMap currentMap = null;

        private Surface mapSurface = null;

        private int screenWidth;

        private int screenHeight;
        #endregion

        #region Constructor
        public MiniMap(int screenWidth, int screenHeight, AbstractMap map)
        {
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;

            int mapSize = Math.Max(map.Width, map.Height);
            int screenSize = Math.Min(screenWidth, screenHeight);

            precision = mapSize / ((double)screenSize * 0.9);

        }
        #endregion

        #region Public Methods
        public void Update(World world, RayTracer rayTracer, Surface surface)
        {
            surface.Blit(GetOrCreateMapSurface(world.Map));
            foreach (AbstractHumanoid sprite in world.SpritePool)
                DrawSprite(sprite, world.SharedConsciousness.IsSpriteViewable(world.CurrentPlayer, sprite, world.Map, rayTracer.Fov), surface);

            DrawRayTracer(world.Map, rayTracer, surface);
        }
        #endregion

        #region Private Methods
        private Surface GetOrCreateMapSurface(AbstractMap map)
        {
            if (this.currentMap != map)
            {
                this.currentMap = map;
                mapSurface = null;
            }

            if (mapSurface != null)
                return mapSurface;

            int pixelWidth = (int)Math.Ceiling((double)map.Width / precision);
            int pixelHeight = (int)Math.Ceiling((double)map.Height / precision);

            mapSurface = new Surface(pixelWidth, pixelHeight);

            int pixelLocationX = 0;
            for (double mapLocationX = 0; mapLocationX < map.Width; mapLocationX += precision)
            {
                int pixelLocationY = 0;
                for (double mapLocationY = 0; mapLocationY < map.Height; mapLocationY += precision)
                {
                    if (map.GetMatterTypeAt(mapLocationX, mapLocationY) != null)
                        if (PointLoader.IsPositionValid(pixelLocationX, pixelLocationY))
                            mapSurface.Draw(PointLoader.GetPoint(pixelLocationX, pixelLocationY), Color.Gray);
                    pixelLocationY++;
                }
                pixelLocationX++;
            }

            mapSurface.Transparent = true;

            return mapSurface;
        }

        private void DrawSprite(AbstractHumanoid sprite, bool isViewable, Surface surface)
        {
            DrawSpriteBounds(sprite, isViewable, surface);
            DrawSpriteAngle(sprite, surface);
        }

        private void DrawSpriteAngle(AbstractHumanoid sprite, Surface surface)
        {
            int pixelLocationX = (int)(sprite.PositionX / precision);
            int pixelLocationY = (int)(sprite.PositionY / precision);

            double realEndingLocationX = sprite.PositionX + Math.Cos(sprite.AngleRadian) * sprite.Diameter;
            double realEndingLocationY = sprite.PositionY + Math.Sin(sprite.AngleRadian) * sprite.Diameter;

            short pixelEndingLocationX = (short)(realEndingLocationX / precision);
            short pixelEndingLocationY = (short)(realEndingLocationY / precision);

            IPrimitive primitive;
            Line angleLine;

            if (angleLineCache.TryGetValue(sprite, out primitive))
            {
                angleLine = (Line)primitive;
            }
            else
            {
                angleLine = new Line();
            }

            angleLine.XPosition1 = (short)pixelLocationX;
            angleLine.YPosition1 = (short)pixelLocationY;


            angleLine.XPosition2 = pixelEndingLocationX;
            angleLine.YPosition2 = pixelEndingLocationY;


            surface.Draw(angleLine, Color.White);
        }

        private void DrawSpriteBounds(AbstractHumanoid sprite, bool isViewable, Surface surface)
        {
            int pixelLocationX = (int)(sprite.PositionX / precision);
            int pixelLocationY = (int)(sprite.PositionY / precision);
            int radius = (int)(sprite.Radius / precision);

            IPrimitive primitive;
            Circle circle;

            if (circleCache.TryGetValue(sprite, out primitive))
            {
                circle = (Circle)primitive;
            }
            else
            {
                circle = new Circle((short)pixelLocationX, (short)pixelLocationY, (short)radius);
                circleCache.Add(sprite, circle);
            }

            circle.PositionX = (short)pixelLocationX;
            circle.PositionY = (short)pixelLocationY;

            if (sprite is Player)
                surface.Draw(circle, Color.MediumBlue);
            else if (isViewable)
                surface.Draw(circle, Color.Magenta);
            else
                surface.Draw(circle, Color.Orange);
        }

        private void DrawRayTracer(AbstractMap map, RayTracer rayTracer, Surface surface)
        {
            int positionX;
            int positionY;
            foreach (RayTracerPoint rayTracerPoint in rayTracer)
            {
                positionX = (int)(rayTracerPoint.X / precision);
                positionY = (int)(rayTracerPoint.Y / precision);

                if (PointLoader.IsPositionValid(positionX, positionY))
                    surface.Draw(PointLoader.GetPoint(positionX, positionY), Color.White);
            }
        }
        #endregion
    }
}
