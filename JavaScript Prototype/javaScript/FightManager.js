//Fight manager
function FightManager()
{
	//Constants
	this.distanceWeight = 1;
	this.angleAccuracyWeight = 1;
	this.totalHealthWeight = 10;
	this.minimumAttackAngleAccuracy = 0.9;
	this.minimumBlockAngleAccuracy = 0.9;
	this.meleeImpactCycleTime = 2;
	this.minimumJumpHeightForJumpOverCrouch = 0.46;
	this.maximumJumpHeightForAirBlockStandAttack = 0.3;
	
	//parts
	this.physics = new Physics();
}

FightManager.prototype.updateSpritePool = function FightManager_updateSpritePool(spritePool)
{
	for (var i in spritePool.internalList)
		this.updateSprite(spritePool.internalList[i], spritePool);
}

FightManager.prototype.updateSprite = function FightManager_updateSprite(predator, spritePool)
{
	for (var i in spritePool.internalList)
	{
		var preyCandidate = spritePool.internalList[i];
		if (predator != preyCandidate)
		{
			this.tryPerformAttack(predator, preyCandidate);
		}
	}
}

FightManager.prototype.tryPerformAttack = function FightManager_tryPerformAttack(predator, prey)
{
	//If not currently attacking
	if (predator.currentAttackCycle != this.meleeImpactCycleTime)
		return;
	
	var distanceFromPreySurface = this.physics.getDistance(predator, prey) - (prey.diameter / 2);
	
	//If prey out of range
	if (distanceFromPreySurface > predator.attackRange)
		return;
		
	//If prey is dead
	if (prey.health <= 0)
		return;
	
	//From 0 to 1
	var angleAccuracy = this.getAttackAngleAccuracy(predator, prey);
	
	//If prey in wrong angle
	if (angleAccuracy < this.minimumAttackAngleAccuracy)
		return;
	
	//If prey is blocking
	if (prey.isBlock)
	{
		//If prey has a good blocking/attacking angle
		if (this.getAttackAngleAccuracy(prey, predator) >=  this.minimumBlockAngleAccuracy)
		{
			if (predator.isCrouch && prey.isCrouch) //If both are crouch
			{
				return;
			}
			else if (!predator.isCrouch && predator.isCrouch.jumpHeight == 0) //If predator is standing
			{
				//If prey is not jumping or jumping very slightly
				if (prey.jumpHeight < this.maximumJumpHeightForAirBlockStandAttack)
				{
					return;
				}
			}
			else if (predator.jumpHeight > this.minimumJumpHeightForJumpOverCrouch)
			{
				if (prey.jumpHeight > 0 || !prey.isCrouch)
					return;
			}
			else if (predator.jumpHeight > 0)
			{
				return;
			}
		}
	}
	
	//If predator is crouch and prey jumps high enough
	if (predator.isCrouch && prey.jumpHeight > this.minimumJumpHeightForJumpOverCrouch)
		return;
	
	//If predator is standing and prey is crouch and predator is not jumping high enough
	if (!predator.isCrouch && predator.jumpHeight < this.minimumJumpHeightForJumpOverCrouch && prey.isCrouch)
		return;
	
	var damage = this.totalHealthWeight * ((distanceFromPreySurface * this.distanceWeight) + (angleAccuracy * this.angleAccuracyWeight));
	
	//We perform the damage on the prey
	prey.currentPainCycle = Math.min(prey.currentPainCycle,(damage * -1));
	prey.damageAngle = predator.angle;
	prey.lastUnitAttackedThis = predator;
}

FightManager.prototype.getAttackAngleAccuracy = function FightManager_getAttackAngleAccuracy(predator, prey)
{
	var fullVectorX = prey.x - predator.x;
	var fullVectorY = prey.y - predator.y;
	var bestAngle = fixAngle(aTanDegree2(fullVectorY,fullVectorX));

	var angleDifference = Math.abs(predator.angle - bestAngle);
	
	angleDifference = fixAngle(angleDifference);
	
	if (angleDifference > 180)
		angleDifference -= 360;
		
	angleDifference = Math.abs(angleDifference);
	
	return (360 - angleDifference) / 360;
}