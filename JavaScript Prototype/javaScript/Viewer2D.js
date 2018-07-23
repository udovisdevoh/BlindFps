function Viewer2D(parentElementId, map, player, rayTracerPointCount, poolSpriteCount)
{
	//Constants
	this.tileWidth = 32;
	this.tileHeight = 32;
	this.playerSize = Math.round(player.diameter * this.tileWidth);
	this.rayTracerSize = 4;
	
	//Fields
	this.parentElementId = parentElementId;
	
	//Construction	
	this.createRayTracerPoints(rayTracerPointCount);
	this.createSpritePoints(poolSpriteCount);
	this.createPlayerPosition();
	this.createTiles(map);
	this.createInfo();
}

Viewer2D.prototype.createTiles = function Viewer2D_createTiles(map)
{
	var parentDomElement = document.getElementById(this.parentElementId);
	for (var x = 0; x < map.width; x++)
	{
		for (var y = 0; y < map.height; y++)
		{
			var tile = document.createElement("div");
			tile.setAttribute("id","tile" + x + "-" + y);
			tile.className = "Tile";
			parentDomElement.appendChild(tile);
		}
	}
}

Viewer2D.prototype.createInfo = function Viewer2D_createInfo()
{
	//Info sur l'angle
	var parentDomElement = document.getElementById(this.parentElementId);
	var angleInfo = document.createElement("div");
	angleInfo.setAttribute("id","angleInfo");
	angleInfo.className = "AngleInfo";
	parentDomElement.appendChild(angleInfo);
	
	//Info sur la hauteur de saut
	var jumpHeightInfo = document.createElement("div");
	jumpHeightInfo.setAttribute("id","jumpHeightInfo");
	jumpHeightInfo.className = "JumpHeightInfo";
	parentDomElement.appendChild(jumpHeightInfo);
	
	//Info sur le cycle d'attaque
	var attackCycleInfo = document.createElement("div");
	attackCycleInfo.setAttribute("id","attackCycleInfo");
	attackCycleInfo.className = "AttackCycleInfo";
	parentDomElement.appendChild(attackCycleInfo);
	
	//Info sur le health
	var healthInfo = document.createElement("div");
	healthInfo.setAttribute("id","healthInfo");
	healthInfo.className = "HealthInfo2D";
	parentDomElement.appendChild(healthInfo);
}

Viewer2D.prototype.createPlayerPosition = function Viewer2D_createPlayerPosition()
{
	var parentDomElement = document.getElementById(this.parentElementId);
	var player2D = document.createElement("div");
	player2D.setAttribute("id","player2D");
	player2D.className = "Player2D";
	player2D.style.width = this.playerSize + "px";
	player2D.style.height = this.playerSize + "px";
	parentDomElement.appendChild(player2D);
}

Viewer2D.prototype.createRayTracerPoints = function Viewer2D_createRayTracerPoints(count)
{
	var parentDomElement = document.getElementById(this.parentElementId);
	for (var i = 0; i < count; i++)
	{
		var rayTracerPoint = document.createElement("div");
		rayTracerPoint.setAttribute("id","rayTracerPoint" + i);
		rayTracerPoint.className = "RayTracerPoint";
		parentDomElement.appendChild(rayTracerPoint);
	}
}

Viewer2D.prototype.createSpritePoints = function Viewer2D_createSpritePoints(count)
{
	var parentDomElement = document.getElementById(this.parentElementId);
	for (var i = 0; i < count; i++)
	{
		var spritePoint = document.createElement("div");
		spritePoint.setAttribute("id","spritePoint" + i);
		spritePoint.className = "SpritePoint";
		parentDomElement.appendChild(spritePoint);
	}
}

Viewer2D.prototype.view = function Viewer2D_view(map, player, tracerResult, spritePool)
{
	//On affiche la map
	for (var x = 0; x < map.width; x++)
	{
		for (var y = 0; y < map.height; y++)
		{
			var tile = document.getElementById("tile" + x + "-" + y);
			tile.style.width = this.tileWidth + "px";
			tile.style.height = this.tileHeight + "px";
			tile.style.top = y * this.tileHeight + "px";
			tile.style.left = x * this.tileWidth + "px";
			if (map.getValueAt(x,y) == 0)
			{
				tile.style.backgroundColor = "#000";
			}
			else if (map.getValueAt(x,y) == 1)
			{
				tile.style.backgroundColor = "#888";
			}
		}
	}
	
	//On affiche le player
	var player2D = document.getElementById("player2D");
	player2D.style.left = Math.round(player.x * this.tileWidth - this.playerSize / 2) + "px";
	player2D.style.top = Math.round(player.y * this.tileHeight - this.playerSize / 2) + "px";
	
	//On affiche les points de ray tracer
	this.viewRayTracerPoints(tracerResult);
	
	//On affiche les sprites du sprite pool
	this.viewSpritePool(spritePool);
	
	//On affiche la hauteur de saut
	var jumpHeightInfo = document.getElementById("jumpHeightInfo");
	jumpHeightInfo.innerHTML = player.jumpHeight;
	
	//On affiche le cycle d'attaque
	var attackCycleInfo = document.getElementById("attackCycleInfo");
	attackCycleInfo.innerHTML = player.currentAttackCycle;
	
	//On affiche l'angle
	var angleInfo = document.getElementById("angleInfo");
	angleInfo.innerHTML = player.angle;
	
	//On affiche le health
	var healthInfo = document.getElementById("healthInfo");
	healthInfo.innerHTML = player.health;
}

Viewer2D.prototype.viewRayTracerPoints = function Viewer2D_viewRayTracerPoints(tracerResult)
{
	for (var i = 0 ; i < tracerResult.count; i++)
	{
		var rayTracerDom = document.getElementById("rayTracerPoint"+i);
		rayTracerDom.style.left = Math.round(tracerResult.getX(i) * this.tileWidth) -  this.rayTracerSize/2 + "px";
		rayTracerDom.style.top = Math.round(tracerResult.getY(i) * this.tileHeight) -  this.rayTracerSize/2 + "px";
		rayTracerDom.style.width = this.rayTracerSize + "px";
		rayTracerDom.style.height = this.rayTracerSize + "px";
		rayTracerDom.style.backgroundColor = "rgb(0,0," +(i*16) + 64 + ")";
	}
}

Viewer2D.prototype.viewSpritePool = function Viewer2D_viewSpritePool(spritePool)
{
	for (var i in spritePool.internalList)
	{
		var sprite = spritePool.internalList[i];
		var diameter = Math.round(sprite.diameter * this.tileWidth);
		var spriteDom = document.getElementById("spritePoint"+i);
		spriteDom.style.left = Math.round(sprite.x * this.tileWidth - diameter / 2) + "px";
		spriteDom.style.top = Math.round(sprite.y * this.tileHeight - diameter / 2) + "px";
		spriteDom.style.width = diameter + "px";
		spriteDom.style.height = diameter + "px";
	}
}