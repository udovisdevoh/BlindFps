//Used to check whether a sprite can be seen or not
function SpriteRayTracer()
{
	//Constants
	this.rayDistanceResolution = 0.05;
}

//Whether watcher sprite can see watched sprite
SpriteRayTracer.prototype.canSee = function SpriteRayTracer_canSee(watcherSprite, watchedSprite, map)
{
	var angle = fixAngle(Optics.getSpriteAngle(watcherSprite, watchedSprite));


	
	var xMove = cosDegree(angle) * this.rayDistanceResolution;
	var yMove = sinDegree(angle) * this.rayDistanceResolution;
	
	var x = watcherSprite.x;
	var y = watcherSprite.y;
	
	var xDistanceToPerform = Math.abs(watcherSprite.x - watchedSprite.x);
	var yDistanceToPerform = Math.abs(watcherSprite.y - watchedSprite.y);
	

	
	var xDistance = 0;
	var yDistance = 0;

	while (true)
	{
		x += xMove;
		y += yMove;

		xDistance += Math.abs(xMove);
		yDistance += Math.abs(yMove);

		if (map.getValueAt(x, y) == 1)
		{
			return false;
		}
		
		if (x < 0 || y < 0 || x > map.width || y > map.height)
		{
			return false;
		}
		
		/*if (Math.floor(x * this.spriteDetectionResolution) == Math.floor(watchedSprite.x * this.spriteDetectionResolution))
			if (Math.floor(y * this.spriteDetectionResolution) == Math.floor(watchedSprite.y * this.spriteDetectionResolution))
				return true;*/
				
		if (xDistance >= xDistanceToPerform && yDistance >= yDistanceToPerform)
		{
			return true;
		}
	}
	
	return false;
}