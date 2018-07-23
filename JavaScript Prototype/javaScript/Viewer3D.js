function Viewer3D(parentElementId, map, player, rayTracerPointCount, parentDomName, isColored, fov)
{
	//Constants
	this.tileWidth = 32;
	this.tileHeight = 32;
	this.playerSize = 4;
	this.resolution = rayTracerPointCount;
	this.maxColumnHeight = 700;
	this.heightDistanceRatio = 2;
	
	//Fields
	this.parentDomName = parentDomName;
	this.isColored = isColored;
	this.fov = fov;
	this.windowWidth = this.getWindowWidth();
	
	//Parts
	this.hudViewer = new HudViewer(this.maxColumnHeight, parentDomName);
	this.spritePoolViewer = new SpritePoolViewer(this.fov, this.heightDistanceRatio, parentDomName, this.maxColumnHeight, this.resolution, this.windowWidth);
	
	//Construction
	this.createViewableElements()
}

Viewer3D.prototype.view = function Viewer3D_view(map, player, tracerResult, spritePool)
{
	var incrementor = 1 / this.resolution;
	
	var id = 0;	
	var columnHeight;
	
	for (var i = 0; i < tracerResult.count; i++)
	{
		var straightDistance = Optics.getStraightDistance(player, tracerResult.getX(i), tracerResult.getY(i));
		columnHeight = Optics.getColumnHeight(straightDistance, this.maxColumnHeight, this.heightDistanceRatio);
		
		var div = document.getElementById("column" + id);		
		var topMargin = Optics.getColumnTopMargin(this.maxColumnHeight,columnHeight, player.jumpHeight, player.isCrouch);
		
		var columnHeightMinusTopMarginIfNeeded = columnHeight;
		
		if (columnHeight + topMargin > this.maxColumnHeight)
			columnHeightMinusTopMarginIfNeeded = this.maxColumnHeight - topMargin;
		
		div.style.height = columnHeightMinusTopMarginIfNeeded + "px";
		
		div.style.zIndex = Optics.getColumnZIndex(straightDistance);
		
		
		div.style.top = topMargin + "px";
		
		var brightness = Math.round(columnHeight / this.maxColumnHeight * 255);
		
		
		brightness = Math.min(255,brightness);
		brightness = Math.max(0,brightness);
		
		
		if (this.isColored)
			div.style.backgroundColor = map.colorMap.getColoredBrightness(tracerResult.getX(i), tracerResult.getY(i), brightness);
		else
			div.style.backgroundColor = "rgb("+brightness+","+brightness+","+brightness+")";
		
		id++;
	}
	
	this.hudViewer.view(player.currentAttackCycle, player.jumpHeight, player.isCrouch, player.isBlock, player.health, player.fragCount);
	this.spritePoolViewer.view(spritePool, player, tracerResult, map);
}

Viewer3D.prototype.createViewableElements = function Viewer3D_createViewableElements()
{
	var parentDomElement = document.getElementById(this.parentDomName);
	var width = this.windowWidth / this.resolution;
	
	var id = 0;
	for (var i = 0; i < this.resolution; i++)
	{
		var column = document.createElement('div');
		column.className = "Column";
		column.setAttribute("id", "column" + i);
		column.style.width = width +1+ "px";
		column.style.left = width * id - 1 + "px";
		parentDomElement.appendChild(column);
		id++;
	}
}

Viewer3D.prototype.getWindowWidth = function Viewer3D_getWindowWidth()
{
	var myWidth = 0, myHeight = 0;
	if( typeof( window.innerWidth ) == 'number' )
	{
		//Non-IE
		myWidth = window.innerWidth;
		myHeight = window.innerHeight;
	}
	else if
	( document.documentElement && ( document.documentElement.clientWidth || document.documentElement.clientHeight ) )
	{
		//IE 6+ in 'standards compliant mode'
		myWidth = document.documentElement.clientWidth;
		myHeight = document.documentElement.clientHeight;
	}
	else if
	( document.body && ( document.body.clientWidth || document.body.clientHeight ) )
	{
		//IE 4 compatible
		myWidth = document.body.clientWidth;
		myHeight = document.body.clientHeight;
	}
	return myWidth;
}

Viewer3D.prototype.getDistance = function Viewer3D_getDistance(player, rayPositionX, rayPositionY)
{
	var xDistance = Math.abs(player.x - rayPositionX);
	var yDistance = Math.abs(player.y - rayPositionY);

	return Math.sqrt(xDistance + yDistance);
}

Viewer3D.prototype.getRayDifferenceAngle = function Viewer3D_getRayDifferenceAngle(playerPosition, rayPositionAngle)
{
	var angle = Math.abs(playerPosition.angle - rayPositionAngle);
	angle = fixAngle(angle);
	return angle;
}