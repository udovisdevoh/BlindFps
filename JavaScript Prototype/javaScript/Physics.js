function Physics()
{
	//constants
	this.collisionResolution = 0.01;
}

Physics.prototype.testMapCollision = function Physics_testMapCollision(x, y, radius, map)
{
	if (radius == 0)
		return map.getValueAt(x, y) == 0;

	var distance = 0;
	
	if (!this.testMapCollision(x,y,0,map))
		return false;
	
	for (var distance = this.collisionResolution; distance < radius; distance += this.collisionResolution)
	{
		if (!this.testMapCollision(x,y+distance,0,map))
			return false;
		else if (!this.testMapCollision(x,y-distance,0,map))
			return false;
		else if (!this.testMapCollision(x+distance,y,0,map))
			return false;
		else if (!this.testMapCollision(x-distance,y,0,map))
			return false;
	}
	
	return true;
}

Physics.prototype.testSpriteCollision = function Physics_testSpriteCollision(x, y, radius, subject, spritePool)
{
	for (var i in spritePool.internalList)
		if (subject != spritePool.internalList[i])
			if (!this.testSpriteCollisionSingle(x, y, radius, subject, spritePool.internalList[i]))
				return false;
	return true;
}

Physics.prototype.testSpriteCollisionSingle = function Physics_testSpriteCollisionSingle(x, y, radius, subject, sprite)
{
	var spriteRadius = sprite.diameter / 2;
	
	/* On peut sauter par dessus un unit (pas possible pour l'instant)
	if (Math.abs(subject.jumpHeight - sprite.jumpHeight) >= 0.5) 
		return true;
	if (Math.abs(subject.jumpHeight - sprite.jumpHeight) >= 0.25 && subject.isCrouch != sprite.isCrouch)
		return true;*/
	
	if (x + radius > sprite.x - spriteRadius && x - radius < sprite.x + spriteRadius)
	{
		if (y + radius > sprite.y - spriteRadius && y - radius < sprite.y + spriteRadius)
		{
			return false;
		}
		else if (y - radius < sprite.y + spriteRadius && y + radius > sprite.y - spriteRadius)
		{
			return false;
		}
	}
	else if (x - radius < sprite.x + spriteRadius && x + radius > sprite.x - spriteRadius)
	{
		if (y + radius > sprite.y - spriteRadius && y - radius < sprite.y + spriteRadius)
		{
			return false;
		}
		else if (y - radius < sprite.y + spriteRadius && y + radius > sprite.y - spriteRadius)
		{
			return false;
		}
	}
	
	return true;
}

Physics.prototype.getDistance = function Physics_getDistance(sprite1, sprite2)
{
	return Math.sqrt(Math.pow(sprite1.x - sprite2.x, 2) + Math.pow(sprite1.y - sprite2.y,2));
}