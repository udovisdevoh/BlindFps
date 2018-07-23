//Pour voir les sprites
function SpritePoolViewer(fov, heightDistanceRatio, parentDomElementId, maxColumnHeight, resolution, windowWidth)
{
	//Constants
	this.minimumTheoriticalSpriteHeight = 40;
	
	//Fields
	this.fov = fov;
	this.heightDistanceRatio = heightDistanceRatio;
	this.spritePool = null;
	this.parentDomElementId = parentDomElementId;
	this.maxColumnHeight = maxColumnHeight;
	this.resolution = resolution;
	this.windowWidth = windowWidth;
	
	//Parts
	this.spriteImageManager = new SpriteImageManager();
	this.spriteRayTracer = new SpriteRayTracer();
}

SpritePoolViewer.prototype.view = function SpritePoolViewer_view(spritePool, player, tracerResult, map)
{
	//We create dom elements if needed
	if (this.spritePool == null)
	{
		this.spritePool = spritePool;
		this.createDomElements(this.spritePool.count());
	}
	
	for (var i in spritePool.internalList)
		if (spritePool.internalList[i] != player)
			if (this.spriteRayTracer.canSee(player, spritePool.internalList[i], map))
				this.tryShowSprite(spritePool.internalList[i], i, player);
			else
				document.getElementById("sprite" + i).style.visibility="hidden";
}

SpritePoolViewer.prototype.createDomElements = function SpritePoolViewer_createDomElements(howMany)
{
	var parentDomElement = document.getElementById(this.parentDomElementId);	
	for (var i = 0 ; i < howMany; i++)
	{
		var sprite = document.createElement('img');
		sprite.className = "Sprite";
		sprite.setAttribute("id", "sprite" + i);
		sprite.setAttribute("alt", "sprite" + i);
		parentDomElement.appendChild(sprite);
	}
}

SpritePoolViewer.prototype.tryShowSprite = function SpritePoolViewer_tryShowSprite(sprite, givenId, player)
{
	//Don't show if sprite is current player
	if (sprite == player)
	{
		document.getElementById("sprite" + givenId).style.visibility="hidden";
		return;
	}
		
	//Theoretical means: as if it was a div column
	var straightDistance = Optics.getStraightDistance(player, sprite.x, sprite.y);
	var theoreticalColumnHeight = Optics.getColumnHeight(straightDistance, this.maxColumnHeight, this.heightDistanceRatio);
	var theoreticalTopMargin = Optics.getColumnTopMargin(this.maxColumnHeight,theoreticalColumnHeight, player.jumpHeight, player.isCrouch);	
	var zIndex = Optics.getColumnZIndex(straightDistance);

	//Don't show if sprite is too far
	if (theoreticalColumnHeight < this.minimumTheoriticalSpriteHeight)
	{
		document.getElementById("sprite" + givenId).style.visibility="hidden";
		return;
	}
		
	var angle = Optics.getSpriteAngle(player, sprite) - player.angle;
	
	
	
	var spriteImageInfo = this.spriteImageManager.getSpriteImageInfo(sprite);
	
	//Don't show if has no image
	if (spriteImageInfo == null)
	{
		document.getElementById("sprite" + givenId).style.visibility="hidden";
		return;
	}
	
	var imageHeight = Math.floor(spriteImageInfo.height / this.maxColumnHeight * theoreticalColumnHeight);
	var imageWidth = Math.floor(spriteImageInfo.width / this.maxColumnHeight * theoreticalColumnHeight);
	var topMargin = Math.floor(theoreticalTopMargin + theoreticalColumnHeight - imageHeight - (sprite.jumpHeight * imageHeight));
	
	
	
	var xPosition = Math.floor(this.getXPosition(angle, this.fov, this.windowWidth, imageWidth));
	
	
	//Don't show if it's too much at the right or left
	if (xPosition > this.windowWidth || xPosition + imageWidth < 0)
	{
		document.getElementById("sprite" + givenId).style.visibility="hidden";
		return;
	}
	
	/*
	//Ugly hack, must eventually remove:
	if (xPosition + imageWidth >= this.windowWidth)
		xPosition = this.windowWidth - (xPosition + imageWidth);
		
	
	//Ugly hack, must eventually remove:
	if (topMargin + imageHeight >= this.maxColumnHeight)
		topMargin = this.maxColumnHeight - imageHeight;*/
	
	
	/*var rightNegativeMarginIfNeeded = 0;
	if (xPosition + imageWidth >= this.windowWidth)
		rightNegativeMarginIfNeeded = this.windowWidth - (xPosition + imageWidth);*/
	
	//var leftNegativeMargin = imageWidth / (-2); //Warning, could be larger if picture is almost out of viewable area
	
	/*var negativeBottomMarginIfNeeded = 0;
	if (theoreticalColumnHeight + theoreticalTopMargin > this.maxColumnHeight)
	{
		negativeBottomMarginIfNeeded = this.maxColumnHeight - (theoreticalColumnHeight + theoreticalTopMargin);
	}*/
		
	var domElement = document.getElementById("sprite" + givenId);
	domElement.setAttribute("src", spriteImageInfo.imageFile);
	domElement.style.visibility = "visible";
	domElement.style.width = imageWidth + "px";
	domElement.style.height = imageHeight + "px";
	domElement.style.top = topMargin + "px";
	domElement.style.left = xPosition + "px";
	domElement.style.zIndex = zIndex;
}

SpritePoolViewer.prototype.getXPosition = function SpritePoolViewer_getXPosition(angle, fov, windowWidth, imageWidth)
{
	return angle / fov * windowWidth + (windowWidth/2) - (imageWidth/2);
}