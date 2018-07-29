using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlindFPS
{
    /// <summary>
    /// Monster's artificial intelligence
    /// </summary>
    public class Ai
    {
        #region Fields
        private int howManyFrameBeforeChoosingPreyAgain;

        private Random random;
        #endregion

        #region Constructor
        public Ai(Random random, int howManyMonster)
        {
            howManyFrameBeforeChoosingPreyAgain = howManyMonster;

            this.random = random;
        }
        #endregion

        #region Public Methods
        public void Animate(AbstractHumanoid predator, AbstractMap map, SpritePool spritePool, SharedConsciousness sharedConsciousness, double timeDelta, int fov, Random random, AbstractHumanoid currentPlayer)
        {
            AbstractHumanoid prey;

            if (random.Next(howManyFrameBeforeChoosingPreyAgain) == 0)
            {
                prey = TryChoosePrey(predator, spritePool, sharedConsciousness, map, fov, currentPlayer);
                predator.LatestSelectedPrey = prey;
            }
            else
            {
                prey = predator.LatestSelectedPrey;
            }

            
            predator.IsNeedToJumpAgain = false;
            predator.IsBlock = false;

            byte currentStateJumpCrouch = predator.StateJumpCrouch.GetCurrentState();

            //We manage jumping state
            if (currentStateJumpCrouch == SpriteStates.Jump)
            {
                predator.IsCrouch = false;
                Physics.MakeJump(predator, timeDelta);
            }

            //We manage crouch state
            if (currentStateJumpCrouch == SpriteStates.Crouch)
            {
                predator.IsCrouch = true;
            }


            //We manage standing state
            if (currentStateJumpCrouch == SpriteStates.Stand)
            {
                predator.IsCrouch = false;
                predator.IsNeedToJumpAgain = false;
            }

            //We manage walking
            if (prey != null)
            {
                if (random.Next(5) == 0 && !predator.SpinAttackCycle.IsFired)
                    predator.AngleRadian = Optics.GetSpriteAngleToSpriteRadian(predator, prey);

                byte currentAttackBlockState = predator.StateAttackBlock.GetCurrentState();
                byte currentAttackTypeState = predator.StateAttackType.GetCurrentState();
                byte currentMovementState = predator.StateMovement.GetCurrentState();

                if (currentAttackBlockState == SpriteStates.SpinCharge)
                    predator.StateAttackType.Reset();

                if (predator.SpinChargeAttackCycle.IsFired)
                    currentAttackBlockState = SpriteStates.SpinCharge;
                    

                if (currentMovementState == SpriteStates.Offensive)
                {
                    Physics.TryMakeWalk(predator, spritePool, map, timeDelta);
                }
                else if (currentMovementState == SpriteStates.Defensive)
                {
                    Physics.TryMakeWalk(predator, Math.PI, spritePool, map, timeDelta);
                }
                else if (currentMovementState == SpriteStates.FurtiveLeft)
                {
                    Physics.TryMakeWalk(predator, Math.PI * 1.5, spritePool, map, timeDelta);
                }
                else if (currentMovementState == SpriteStates.FurtiveRight)
                {
                    Physics.TryMakeWalk(predator, Math.PI * 0.5, spritePool, map, timeDelta);
                }



                //We manage attacking,  and blocking
                bool isWithinAttackRange = BattlePhysics.IsWithinAttackRange(predator, prey);
                bool isWithinAttackOrBlockAngle = BattlePhysics.IsInAttackOrBlockAngle(predator, prey);

                
                if (currentAttackBlockState == SpriteStates.Block && predator.PositionZ > 0)
                    currentAttackBlockState = SpriteStates.Attack;

                if (isWithinAttackRange || isWithinAttackOrBlockAngle)
                {
                    if (predator.ReceivedAttackCycle.IsAtBegining)
                    {
                        if (currentAttackBlockState == SpriteStates.Attack)
                        {
                            if (currentAttackTypeState == SpriteStates.FastAttack)
                            {
                                if (random.Next(2) == 1)
                                {
                                    if (BattlePhysics.IsWithinAttackRange(predator, prey, 1.5) && isWithinAttackOrBlockAngle)
                                    {
                                        predator.FastAttackCycle.UnFire();
                                        predator.FastAttackCycle.Fire();
                                    }
                                }
                            }
                            else if (currentAttackTypeState == SpriteStates.StrongAttack)
                            {
                                if (random.Next(2) == 1)
                                {
                                    if (BattlePhysics.IsWithinAttackRange(predator, prey, 1.5) && isWithinAttackOrBlockAngle)
                                    {
                                        predator.StrongAttackCycle.UnFire();
                                        predator.StrongAttackCycle.Fire();
                                    }
                                }
                            }
                            predator.SpinChargeAttackCycle.Reset();
                        }
                        else if (currentAttackBlockState == SpriteStates.SpinCharge)
                        {
                            if (IsReadyToSpin(predator) && BattlePhysics.IsWithinAttackRange(predator, prey, 1.5))
                            {
                                if (random.Next(3) == 1)
                                {
                                    predator.SpinAttackCycle.Reset();
                                    predator.SpinAttackCycle.Fire();
                                    predator.SpinChargeAttackCycle.Reset();
                                    predator.StateAttackBlock.Reset();
                                }
                            }
                            else if (!predator.SpinAttackCycle.IsFired)
                            {
                                if (predator.SpinChargeAttackCycle.IsFired)
                                    predator.SpinChargeAttackCycle.Update(timeDelta);
                                else
                                    predator.SpinChargeAttackCycle.Fire();
                            }
                        }
                        else if (currentAttackBlockState == SpriteStates.Block && !predator.SpinAttackCycle.IsFired)
                        {
                            predator.StrongAttackCycle.UnFire();
                            predator.SpinAttackCycle.UnFire();
                            predator.SpinChargeAttackCycle.Reset();
                            predator.FastAttackCycle.UnFire();
                            predator.IsBlock = true;
                        }
                        else
                        {
                            predator.SpinChargeAttackCycle.Reset();
                        }
                    }
                }


                predator.StateAttackBlock.Update(timeDelta, random);
                predator.StateAttackType.Update(timeDelta, random);
                predator.StateMovement.Update(timeDelta, random);
            }
            else
            {
                if (!predator.SpinAttackCycle.IsFired && !Physics.TryMakeWalk(predator, spritePool, map, timeDelta))
                {
                    predator.AngleDegree = (double)random.Next(360);
                }
            }

            predator.StateJumpCrouch.Update(timeDelta,random);
        }

        private bool IsReadyToSpin(AbstractHumanoid predator)
        {
            return predator.SpinChargeAttackCycle.IsAtParoxism && !predator.SpinAttackCycle.IsFired;
        }
        #endregion

        #region Private Methods
        private AbstractHumanoid TryChoosePrey(AbstractHumanoid predator, SpritePool spritePool, SharedConsciousness sharedConsciousness, AbstractMap map, int fov, AbstractHumanoid currentPlayer)
        {
            AbstractHumanoid closestPrey = null;
            double closestDistance = -1;
            foreach (AbstractHumanoid prey in spritePool)
            {
                if (prey == predator)
                    continue;

                //if (!Physics.IsWithinAttackRange(predator, prey) && !sharedConsciousness.IsSpriteViewable(predator, prey, map, fov))
                //    continue;


                if (sharedConsciousness.IsSpriteViewable(predator, prey, map, fov) || (sharedConsciousness.IsSpriteViewable(prey, predator, map, fov) && predator.LatestAttacker == prey))
                {
                    double currentDistance = Physics.GetSpriteDistance(predator, prey);

                    if (closestPrey == null || currentDistance < closestDistance)
                    {
                        closestPrey = prey;
                        closestDistance = currentDistance;
                    }   
                }
            }

            return closestPrey;
        }    
        #endregion
    }
}
