//Sert a determiner des places random aux sprites et a les récussiter
function Spawner()
{
	this.map = null;
	this.availablePositionCacheX = null;
	this.availablePositionCacheY = null;
}

Spawner.prototype.respawnSpritePoolMembers = function Spawner_respawnSpritePoolMembers(spritePool, map)
{
	for (var i in spritePool.internalList)
		this.respawnSprite(spritePool.internalList[i],map);
}

Spawner.prototype.respawnSprite = function Spawner_respawnSprite(sprite, map)
{
	if (this.map != map)
	{
		this.map = map;
		this.buildAvailablePositionCache(this.map);
	}

	if (this.availablePositionCacheX.length < 1)
		throw("No position available");
		
	var id = Math.floor(Math.random() * this.availablePositionCacheX.length);
	
	sprite.x = this.availablePositionCacheX[id] + 0.5;
	sprite.y = this.availablePositionCacheY[id] + 0.5;
	sprite.angle = Math.floor(Math.random() * 360);
	sprite.health = sprite.maxHealth;
	sprite.currentPainCycle = 0;
	
	//On donne les frags au tueur
	if (sprite.lastUnitAttackedThis != null)
	{
		sprite.lastUnitAttackedThis.fragCount++;
		sprite.lastUnitAttackedThis = null;
	}
}

Spawner.prototype.buildAvailablePositionCache = function Spawner_buildAvailablePositionCache(map)
{
	this.availablePositionCacheX = new Array();
	this.availablePositionCacheY = new Array();
	
	var id = 0;
	for (var x = 0; x < map.width ; x++)
	{
		for (var y = 0; y < map.width ; y++)
		{
			if (map.getValueAt(x,y) == 0)
			{
				this.availablePositionCacheX[id] = x;
				this.availablePositionCacheY[id] = y;
				id++;
			}
		}
	}		
}

Spawner.prototype.respawnDeadUnits = function Spawner_respawnDeadUnits(spritePool, map)
{
	for (var i in spritePool.internalList)
		if (spritePool.internalList[i].health <= 0)
			this.respawnSprite(spritePool.internalList[i],map);
}