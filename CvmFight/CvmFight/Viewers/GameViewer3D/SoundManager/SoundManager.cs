using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SdlDotNet.Audio;

namespace CvmFight
{
    class SoundManager
    {
        #region Constants
        public const int Block = 0;

        public const int FastAttempt = 1;
        
        public const int FastHit = 2;

        public const int Jump = 3;

        public const int Ko = 4;

        public const int Perfect = 5;

        public const int StrongKickAttempt = 6;

        public const int StrongKickHit = 7;

        public const int StrongPunchAttempt = 8;

        public const int StrongPunchHit = 9;

        public const int YouLose = 10;

        public const int YouWin = 11;

        public const int SpinAttack = 12;

        public const int SpinCharge = 13;

        public const int SpinChargeEnemy = 14;
        #endregion

        #region Constructor
        public SoundManager(Random random)
        {
            Mixer.ChannelsAllocated = 64;
        }
        #endregion

        #region Public Methods
        public void Update(AbstractHumanoid sprite, AbstractHumanoid currentPlayer)
        {
            Channel channel = null;

            if (!sprite.IsAlive)
            {
                if (sprite == currentPlayer)
                {
                    //channel = Play(YouLose);
                }
                else if (sprite.LatestAttacker == currentPlayer)
                {
                    if (currentPlayer.Health >= currentPlayer.DefaultHealth)
                    {
                        //channel = Play(Perfect);
                    }
                    else
                    {
                        //channel = Play(YouWin);
                    }
                }
                else
                {
                    //channel = Play(Ko);
                }
            }
            else if (sprite.IsJustReceivedStrongPunch)
            {
                //channel = Play(StrongPunchHit);
            }
            else if (sprite.IsJustReceivedStrongKick)
            {
                //channel = Play(StrongKickHit);
            }
            else if (sprite.IsJustReceivedFastAttack)
            {
                //channel = Play(FastHit);
            }
            else if (sprite.CurrentJumpAcceleration == sprite.MaxJumpAcceleration)
            {
                //warning, jump is forced when getting hit so we must evaluate getting hit before jump
                //channel = Play(Jump);
            }
            else if (sprite.IsBlock && sprite.BlockSuccessCycle.IsFired && sprite.BlockSuccessCycle.IsAtBegining && sprite.BlockSuccessCycle.IsForward)
            {
                //channel = Play(Block);
            }
            else if (sprite.StrongAttackCycle.IsAtBegining && sprite.StrongAttackCycle.IsFired && sprite.StrongAttackCycle.IsForward)
            {
                /*if (sprite.IsCrouch || sprite.PositionZ > 0)
                    channel = Play(StrongKickAttempt);
                else
                    channel = Play(StrongPunchAttempt);*/
            }
            else if (sprite.FastAttackCycle.IsAtBegining && sprite.FastAttackCycle.IsFired && sprite.FastAttackCycle.IsForward)
            {
                //channel = Play(FastAttempt);
            }
            else if (sprite.SpinAttackCycle.IsAtBegining && sprite.SpinAttackCycle.IsFired)
            {
                //channel = Play(SpinAttack);
            }
            else if (sprite == currentPlayer && sprite.SpinChargeAttackCycle.IsAtParoxism && !sprite.SpinChargeAttackCycle.IsNeedToClickAgain)
            {
                //channel = Play(SpinCharge);
            }
            else if (sprite != currentPlayer && sprite.SpinChargeAttackCycle.IsFired && sprite.SpinChargeAttackCycle.IsAtBegining)
            {
                //channel = Play(SpinChargeEnemy);
            }

            //We set the volume and the panning according to the distance
            if (channel != null)
            {
                //We set the volume
                double straightDistance = Optics.GetStraightDistance(currentPlayer, sprite);
                if (straightDistance <= 0)
                    channel.Volume = 128;
                else
                    channel.Volume = (int)(1.0 / straightDistance * 128.0);
            }
        }
        #endregion
    }
}
