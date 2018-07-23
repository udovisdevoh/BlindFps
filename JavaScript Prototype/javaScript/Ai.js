//Ai de monstre
function Ai()
{
	//Constants
	this.distanceWeight = 1;
	this.healthWeight = 1;
	this.humanWeight = 2;
	this.behaviorAgressive = 0;
	this.behaviorFlee = 1;
	this.behaviorFurtive = 2;
	
	//Parts
	this.physics = new Physics();
}

Ai.prototype.tryControlMonster = function Ai_tryControlMonster(predator, map, spritePool)
{
	//We choose a victim sprite (boost chances picking human user)
	//Always favor closer sprites and sprites with less health
	var victimSprite = this.chooseVictimSprite(predator, map, spritePool);

	
	//We get angle according to current behavior
	var currentBehavior = predator.behaviorManager.getCurrentBehavior();
	if (currentBehavior == this.behaviorAgressive)
		predator.angle = this.getAgressiveAngle(predator, map, victimSprite);
	else if (currentBehavior == this.behaviorFlee)
		predator.angle = this.getFleeAngle(predator, map, victimSprite);
	else if (currentBehavior == this.behaviorFurtive)
		predator.angle = this.getFurtiveAngle(predator, map, victimSprite);
	
	predator.angle = fixAngle(predator.angle);
	
	//If victim is crouch, ai's behavior is flee, we jump
	if (victimSprite.isCrouch && currentBehavior == this.behaviorFlee)
		predator.tryJump();
	if (!victimSprite.isCrouch && victimSprite.jumpHeight > 0 && currentBehavior == this.behaviorAgressive)
		predator.tryJump();
	else
		predator.continueFall();
		
	//If victim is blocking and not jumping and not crouched, we crouch
	if (victimSprite.isBlock && !victimSprite.isCrouch && victimSprite.jumpHeight == 0)
		predator.isCrouch = true;
	else
		predator.isCrouch = false;
		
	//If victim is attacking, we block
	if (victimSprite.currentAttackCycle > 0)
		predator.isBlock = true;
	else
		predator.isBlock = false;
		
	//We try to walk to destination
	predator.walk(predator.walkSpeed, predator.angle, map, predator.isCrouch, spritePool)
	predator.walkCycle = predator.walkCycle+1;
	if (predator.walkCycle > 10)
		predator.walkCycle = 0;
	
	//We try to attack prey if it's possible
	if (this.physics.getDistance(predator, victimSprite) < predator.attackRange)
	{
		predator.attack();
	}
}

//Choose a victim among all candidates
Ai.prototype.chooseVictimSprite = function Ai_chooseVictimSprite(predator, map, spritePool)
{
	var currentScore;
	var bestScore = -1;
	var bestVictim = null;
	
	var victimCandidate;
	for (var i in spritePool.internalList)
	{
		victimCandidate = spritePool.internalList[i];
		if (predator != victimCandidate)
		{
			currentScore = this.compileVictimCandidateScore(predator, map, victimCandidate);
			if (currentScore > bestScore || bestScore == -1)
			{
				bestScore = currentScore;
				bestVictim = victimCandidate;
			}
		}
	}
	
	if (bestVictim == null)
		throw("couldn't find victim for monster");

	return bestVictim;
}

Ai.prototype.compileVictimCandidateScore = function Ai_compileVictimCandidateScore(predator, map, victimCandidate)
{
	var distanceScore = 1 / this.physics.getDistance(predator, victimCandidate) * this.distanceWeight;
	var healthScore = 1 / victimCandidate.health * this.healthWeight;

	var score = distanceScore + healthScore;
	if (victimCandidate instanceof Player)
		score = Math.max(score, score * this.humanWeight);
		
	return score;
}

Ai.prototype.getAgressiveAngle = function Ai_getAgressiveAngle(predatorSprite, map, victimSprite)
{
	return Optics.getSpriteAngle(predatorSprite, victimSprite);
}

Ai.prototype.getFleeAngle = function Ai_getFleeAngle(predatorSprite, map, victimSprite)
{
	return Optics.getSpriteAngle(predatorSprite, victimSprite) * -1;
}

Ai.prototype.getFurtiveAngle = function Ai_getFurtiveAngle(predatorSprite, map, victimSprite)
{
	var fullVectorX = victimSprite.x - predatorSprite.x;
	var fullVectorY = predatorSprite.y - victimSprite.y;	
	return fixAngle(aTanDegreeWeird(fullVectorX / fullVectorY));
}

/*Ai.prototype.getRandomAngle = function Ai_getRandomAngle(predatorSprite, map, victimSprite)
{
	return Math.floor(Math.random() * 360);
}*/