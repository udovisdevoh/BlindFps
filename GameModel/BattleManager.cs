using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlindFPS
{
    public class BattleManager
    {
        #region Public Methods
        public void Update(SpritePool spritePool, SharedConsciousness sharedConsciousness, AbstractHumanoid currentPlayer)
        {
            foreach (AbstractHumanoid sprite in spritePool)
            {
                Update(sprite, spritePool, sharedConsciousness, currentPlayer);
            }
        }
        #endregion

        #region Private Methods
        private void Update(AbstractHumanoid attacker, SpritePool spritePool, SharedConsciousness sharedConsciousness, AbstractHumanoid currentPlayer)
        {
            bool IsAttackerAttackAtParoxism;
            double damage;
            bool isFastAttack = false;

            if (attacker.StrongAttackCycle.IsAtParoxism)
            {
                damage = attacker.AttackPowerStrong;
                IsAttackerAttackAtParoxism = true;
            }
            else if (attacker.FastAttackCycle.IsAtParoxism)
            {
                damage = attacker.AttackPowerFast;
                IsAttackerAttackAtParoxism = true;
                isFastAttack = true;
            }
            else if (attacker.SpinAttackCycle.IsFired)
            {
                damage = attacker.AttackPowerStrong;
                IsAttackerAttackAtParoxism = true;
            }
            else
            {
                return;
            }



            if (IsAttackerAttackAtParoxism && attacker.ReceivedAttackCycle.GetCycleState() <= 0)
            {
                foreach (AbstractHumanoid attacked in spritePool)
                {
                    if (attacked == attacker)
                        continue;

                    if (BattlePhysics.IsWithinAttackRange(attacker, attacked))
                    {
                        if (BattlePhysics.IsInAttackOrBlockAngle(attacker, attacked))
                        {
                            if (BattlePhysics.IsInAttackHeight(attacker, attacked))
                            {
                                if (!attacked.IsBlock || !BattlePhysics.IsInAttackOrBlockAngle(attacked, attacker) || !BattlePhysics.IsInBlockingHeight(attacked, attacker))
                                {
                                    //We abort attacked's attack
                                    attacked.FastAttackCycle.Reset();
                                    attacked.StrongAttackCycle.Reset();
                                    attacked.BlockSuccessCycle.Reset();
                                    attacked.SpinChargeAttackCycle.Reset();
                                    attacked.SpinAttackCycle.Reset();

                                    attacked.FastAttackCycle.IsNeedToClickAgain = true;
                                    attacked.StrongAttackCycle.IsNeedToClickAgain = true;

                                    attacked.ReceivedAttackAngleRadian = attacker.AngleRadian;
                                    attacked.ReceivedAttackCycle.Fire();

                                    if (isFastAttack)
                                    {
                                        attacked.ReceivedAttackCycle.PercentComplete = 0.25;
                                        attacked.ReceivedAttackCycle.IsForward = false;
                                        attacked.IsJustReceivedFastAttack = true;
                                    }
                                    else
                                    {
                                        if (attacker.IsCrouch || attacker.PositionZ >= 0)
                                            attacked.IsJustReceivedStrongKick = true;
                                        else
                                            attacked.IsJustReceivedStrongPunch = true;
                                    }

                                    attacked.LatestAttacker = attacker;
                                    attacked.LatestAttackerDamage = damage;

                                    if (!(attacked is Player))
                                    {
                                        attacked.StateJumpCrouch.Reset();
                                        attacked.StateMovement.Reset();
                                        attacked.StateAttackBlock.Reset();
                                        if (attacked.StateAttackBlock.GetCurrentState() == SpriteStates.SpinCharge)
                                        {
                                            attacked.StateAttackBlock.Reset();
                                        }
                                    }

                                    if (!(attacker is Player))
                                    {
                                        attacker.StateJumpCrouch.Renew();
                                        attacker.StateMovement.Renew();
                                        attacker.StateAttackBlock.Renew();
                                    }
                                }
                                else if (attacked.IsBlock)
                                {
                                    attacked.BlockSuccessCycle.Reset();
                                    attacked.BlockSuccessCycle.Fire();
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion
    }
}
