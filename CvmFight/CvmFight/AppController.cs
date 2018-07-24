using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using SdlDotNet.Graphics;
using SdlDotNet.Core;
using SdlDotNet.Input;
using SdlDotNet.Audio;
using System.Windows.Forms;
using System.Threading;

namespace CvmFight
{
    public class AppController
    {
        #region Constants
        /// <summary>
        /// Width of screen
        /// </summary>
        private const int screenWidth = 1280;

        /// <summary>
        /// Height of screen
        /// </summary>
        private const int screenHeight = 720;

        /// <summary>
        /// How many columns in ray tracer
        /// </summary>
        private static int idealRayTracerResolution = 320;

        /// <summary>
        /// Minimum resolution of ray tracer's distance's unit size
        /// </summary>
        private const double rayDistanceResolution = 0.01;

        /// <summary>
        /// Field of view (degrees)
        /// </summary>
        private const int fov = 110;

        /// <summary>
        /// Desired frame per seconds
        /// </summary>
        private const int targetFps = 60;

        /// <summary>
        /// How many enemies
        /// </summary>
        private const int monsterCount = 0;

        /// <summary>
        /// Whether we hide mouse cursor
        /// </summary>
        private const bool isHideMouseCursor = true;

        /// <summary>
        /// Whether we play in full screen
        /// </summary>
        private const bool isFullScreen = false;

        /// <summary>
        /// Whether we cache sprites
        /// </summary>
        private const bool isEnableSpriteCache = false;

        /// <summary>
        /// Whether we load sprites only when first needed
        /// </summary>
        private const bool isEnableLazySpriteImageLoad = false;

        /// <summary>
        /// Whether we enable sound effects and music
        /// </summary>
        private const bool isSoundOn = true;
        #endregion

        #region Members
        /// <summary>
        /// Random number generator
        /// </summary>
        private Random random = new Random();

        /// <summary>
        /// The map, the player and the monsters
        /// </summary>
        private World world;

        /// <summary>
        /// To view the game's graphics
        /// </summary>
        private AbstractGameViewer gameViewer;

        /// <summary>
        /// Which keys and mouse buttons are up or down and mouse position
        /// </summary>
        private InputState inputState = new InputState();

        /// <summary>
        /// 1D Ray tracer engine
        /// </summary>
        private RayTracer rayTracer;

        /// <summary>
        /// Manages melee fighting logic
        /// </summary>
        private BattleManager battleManager = new BattleManager();

        /// <summary>
        /// Monster's artificial intelligence (shared between monsters)
        /// </summary>
        private Ai ai;
        
        /// <summary>
        /// Position at the center of the screen (for mouse)
        /// </summary>
        private Point screenCenterPosition;

        /// <summary>
        /// Previous frame's time
        /// </summary>
        private DateTime previousFrameTime = DateTime.Now;

        /// <summary>
        /// Manage's damage (to players and monsters) logic
        /// </summary>
        private DamageManager damageManager = new DamageManager();

        /// <summary>
        /// Surface on which we draw the game's graphics
        /// </summary>
        private Surface mainSurface;
        #endregion

        #region Constructors
        public AppController()
        {
            mainSurface = Video.SetVideoMode(screenWidth, screenHeight, false, false, isFullScreen, true);

            idealRayTracerResolution = RayTracer.GetValidResolution(idealRayTracerResolution, screenWidth);
            rayTracer = new RayTracer(idealRayTracerResolution, fov, rayDistanceResolution);

            world = new World(random, monsterCount);
            ai = new Ai(random,world.SpritePool.Count);

            gameViewer = new GameViewer3D(mainSurface, screenWidth, screenHeight, rayTracer.ColumnCount, world.SpritePool, rayTracer.Fov, isEnableSpriteCache, random, isEnableLazySpriteImageLoad, world.Map, isSoundOn);
            screenCenterPosition = new Point(screenWidth / 2, screenHeight / 2);
        }
        #endregion

        #region Public Methods and event handlers
        public void Start()
        {
            if (isHideMouseCursor)
            {
                Mouse.ShowCursor = false;
            }

            Events.TargetFps = targetFps;
            Events.Tick += Update;
            Events.KeyboardDown += OnKeyboardDown;
            Events.KeyboardUp += OnKeyboardUp;
            Events.MouseMotion += OnMouseMotion;
            Events.MouseButtonDown += OnMouseDown;
            Events.MouseButtonUp += OnMouseUp;
            Events.Run();
        }

        public void Update(object sender, TickEventArgs args)
        {
            //Thread.CurrentThread.Priority = ThreadPriority.Highest;

            //We process the time multiplicator
            double timeDelta = ((TimeSpan)(DateTime.Now - previousFrameTime)).TotalMilliseconds / 16.0;
            previousFrameTime = DateTime.Now;


            //We clear the sprite's shared consciousness because sprite positions changed
            world.SharedConsciousness.Clear();

            //We update the sprites
            foreach (AbstractSprite sprite in world.SpritePool)
                sprite.Update(timeDelta, world.SpritePool, world.Map);


            if (inputState.IsPressUp != inputState.IsPressDown)
            {
                if (inputState.IsPressUp)
                {
                    Physics.TryMakeWalk(world.CurrentPlayer, world.SpritePool, world.Map, timeDelta);
                }
                else if (inputState.IsPressDown)
                {
                    Physics.TryMakeWalk(world.CurrentPlayer, Math.PI, world.SpritePool, world.Map, timeDelta);
                }
            }

            if (inputState.IsPressLeft != inputState.IsPressRight)
            {
                if (inputState.IsPressLeft)
                    Physics.TryMakeWalk(world.CurrentPlayer, Math.PI * 1.5, world.SpritePool, world.Map, timeDelta);
                else if (inputState.IsPressRight)
                    Physics.TryMakeWalk(world.CurrentPlayer, Math.PI * 0.5, world.SpritePool, world.Map, timeDelta);
            }


 
            //Crouch and jump
            world.CurrentPlayer.IsCrouch = inputState.IsPressCrouch;   

            if (inputState.IsPressJump)
            {
                world.CurrentPlayer.IsCrouch = false;
                Physics.MakeJump(world.CurrentPlayer,timeDelta);
            }
            else
            {
                world.CurrentPlayer.IsNeedToJumpAgain = false;
            }

            //We manage attack buttons
            if (inputState.IsPressMouseButtonLeft)
            {
                if (world.CurrentPlayer.ReceivedAttackCycle.GetCycleState() <= 0)
                {
                    if (!world.CurrentPlayer.FastAttackCycle.IsFired)
                    {
                        world.CurrentPlayer.StrongAttackCycle.Fire();
                    }
                }

                if (world.CurrentPlayer.SpinChargeAttackCycle.IsAtParoxism)
                {
                    world.CurrentPlayer.SpinChargeAttackCycle.IsNeedToClickAgain = true;
                }
                else
                {
                    world.CurrentPlayer.SpinChargeAttackCycle.Fire();
                    world.CurrentPlayer.SpinChargeAttackCycle.Update(timeDelta);
                }
            }
            else if (inputState.IsPressMouseButtonRight)
            {
                if (world.CurrentPlayer.ReceivedAttackCycle.GetCycleState() <= 0)
                {
                    if (!world.CurrentPlayer.StrongAttackCycle.IsFired)
                    {
                        world.CurrentPlayer.FastAttackCycle.Fire();
                    }
                }
            }
            else
            {
                if (world.CurrentPlayer.StrongAttackCycle.IsAtBegining)
                    world.CurrentPlayer.StrongAttackCycle.UnFire();
                if (world.CurrentPlayer.FastAttackCycle.IsAtBegining)
                    world.CurrentPlayer.FastAttackCycle.UnFire();

                if (world.CurrentPlayer.SpinChargeAttackCycle.IsAtParoxism && !world.CurrentPlayer.FastAttackCycle.IsFired && !world.CurrentPlayer.StrongAttackCycle.IsFired)
                {
                    world.CurrentPlayer.SpinAttackCycle.Reset();
                    world.CurrentPlayer.SpinAttackCycle.Fire();
                }
                world.CurrentPlayer.SpinChargeAttackCycle.Reset();
            }


            world.CurrentPlayer.IsBlock = false;
            //Automatic Blocking
            if (world.CurrentPlayer.StrongAttackCycle.IsAtBegining)
            {
                if (world.CurrentPlayer.FastAttackCycle.IsAtBegining)
                {
                    if (!world.CurrentPlayer.SpinAttackCycle.IsFired)
                    {
                        if (world.CurrentPlayer.ReceivedAttackCycle.IsAtBegining)
                        {
                            if (!world.CurrentPlayer.SpinChargeAttackCycle.IsFired)
                            {
                                if (!inputState.IsPressJump)
                                {
                                    world.CurrentPlayer.IsBlock = true;
                                }
                            }
                        }
                    }
                }
            }



            //We animate the sprites using the AI
            foreach (AbstractHumanoid sprite in world.SpritePool)
                if (sprite != world.CurrentPlayer)
                    ai.Animate(sprite, world.Map, world.SpritePool, world.SharedConsciousness, timeDelta, rayTracer.Fov, random, world.CurrentPlayer);

            //We perform fighting logic
            battleManager.Update(world.SpritePool, world.SharedConsciousness, world.CurrentPlayer);

            //We perform damage logic
            bool isNeedRefreshHud;
            damageManager.Update(world.SpritePool, world.CurrentPlayer, world.Map, timeDelta, out isNeedRefreshHud);


            rayTracer.Trace(world.CurrentPlayer, world.Map);

            Physics.TryMakeRotate(world.CurrentPlayer, inputState.MouseMotionX);

            world.CurrentPlayer.TryMouseLook(inputState.MouseMotionY);

            inputState.MouseMotionX = 0;
            inputState.MouseMotionY = 0;

            gameViewer.Update(world, rayTracer);

            if (isNeedRefreshHud)
            {
                gameViewer.DirthenHud();
                world.Spawner.TryRespawn(world.SpritePool, world.Map);
            }
        }

        public void OnKeyboardDown(object sender, KeyboardEventArgs args)
        {
            if (args.Key == Key.UpArrow || args.Key == Key.W)
                inputState.IsPressUp = true;
            else if (args.Key == Key.DownArrow || args.Key == Key.S)
                inputState.IsPressDown = true;
            else if (args.Key == Key.LeftArrow || args.Key == Key.A)
                inputState.IsPressLeft = true;
            else if (args.Key == Key.RightArrow || args.Key == Key.D)
                inputState.IsPressRight = true;
            else if (args.Key == Key.LeftShift || args.Key == Key.C)
                inputState.IsPressCrouch = true;
            else if (args.Key == Key.Space)
                inputState.IsPressJump = true;
            else if (args.Key == Key.Tab)
                gameViewer.IsMiniMapOn = !gameViewer.IsMiniMapOn;
        }

        public void OnKeyboardUp(object sender, KeyboardEventArgs args)
        {
            if (args.Key == Key.UpArrow || args.Key == Key.W)
                inputState.IsPressUp = false;
            else if (args.Key == Key.DownArrow || args.Key == Key.S)
                inputState.IsPressDown = false;
            else if (args.Key == Key.LeftArrow || args.Key == Key.A)
                inputState.IsPressLeft = false;
            else if (args.Key == Key.RightArrow || args.Key == Key.D)
                inputState.IsPressRight = false;
            else if (args.Key == Key.LeftShift || args.Key == Key.C)
                inputState.IsPressCrouch = false;
            else if (args.Key == Key.Space)
                inputState.IsPressJump = false;
            else if (args.Key == Key.Escape)
                Events.QuitApplication();
        }

        public void OnMouseMotion(object sender, MouseMotionEventArgs args)
        {
            short relativeX = (short)(inputState.CurrentX - args.X);
            short relativeY = (short)(inputState.CurrentY - args.Y);

            inputState.CurrentX = args.X;
            inputState.CurrentY = args.Y;

            inputState.MouseMotionX = relativeX;
            inputState.MouseMotionY = relativeY;

            if (isHideMouseCursor)
            {
                Mouse.MousePosition = screenCenterPosition;
            }
        }

        public void OnMouseDown(object sender, MouseButtonEventArgs args)
        {
            if (args.Button == MouseButton.PrimaryButton)
                inputState.IsPressMouseButtonLeft = true;
            else if (args.Button == MouseButton.SecondaryButton)
                inputState.IsPressMouseButtonRight = true;
            else if (args.Button == MouseButton.MiddleButton)
                inputState.IsPressMouseButtonCenter = true;
        }

        public void OnMouseUp(object sender, MouseButtonEventArgs args)
        {
            if (args.Button == MouseButton.PrimaryButton)
                inputState.IsPressMouseButtonLeft = false;
            else if (args.Button == MouseButton.SecondaryButton)
                inputState.IsPressMouseButtonRight = false;
            else if (args.Button == MouseButton.MiddleButton)
                inputState.IsPressMouseButtonCenter = false;
        }
        #endregion

        #region Static
        public static void Main(string[] args)
        {
            AppController program = new AppController();
            program.Start();
        }
        #endregion
    }
}