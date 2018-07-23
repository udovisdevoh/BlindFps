function Optics()
{
}

Optics.getStraightDistance = function Optics_getStraightDistance(sprite, pointX, pointY)
{
	var viewAxisX = cosDegree(sprite.angle);
	var viewAxisY = sinDegree(sprite.angle);
	var relativePointX = pointX - sprite.x;
	var relativePointY = pointY - sprite.y;
	return viewAxisX * relativePointX + viewAxisY * relativePointY;
}

Optics.getColumnHeight = function Optics_getColumnHeight(distance, maxColumnHeight, heightDistanceRatio)
{
	var columnHeight;
	if (distance == 0)
		columnHeight = maxColumnHeight;
	else
		columnHeight = maxColumnHeight / (distance * heightDistanceRatio);
		
	columnHeight = Math.min(maxColumnHeight,columnHeight);
	
	return columnHeight;
}

Optics.getColumnTopMargin = function Optics_getColumnTopMargin(maxColumnHeight, columnHeight, jumpHeight, isCrouch)
{
	if (isCrouch)
		jumpHeight = -0.75;

	//Jump height from 0 to 1
	var jumpOffset = (jumpHeight * columnHeight / 2);
	return Math.round((maxColumnHeight - columnHeight) /2 + jumpOffset);
}

Optics.getColumnZIndex = function Optics_getColumnZIndex(straightDistance)
{
	return 1000 - Math.floor(straightDistance);
}

Optics.getSpriteAngle = function Optics_getSpriteAngle(predatorSprite, victimSprite)
{
	var fullVectorX = victimSprite.x - predatorSprite.x;
	var fullVectorY = victimSprite.y - predatorSprite.y;
	return fixAngle(aTanDegree2(fullVectorY,fullVectorX));
}