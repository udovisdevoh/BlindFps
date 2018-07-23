//Les monstres et leur positions
function SpritePool(monsterCount)
{
	//Constants
	this.monsterCount = monsterCount;
	
	//Fields
	this.internalList = new Array();
	
	//Construction
	for (var i = 0; i < this.monsterCount; i++)
		this.internalList.push(new MonsterStickMan(0, 0));
}

SpritePool.prototype.count = function SpritePool_count()
{
	return this.internalList.length;
}

//On update tous les sprites en utilisant la map comme référence pour les déplacements par l'ai
SpritePool.prototype.update = function SpritePool_update(map, spritePool)
{
	for (var i in this.internalList)
		this.internalList[i].update(map, spritePool);
}

//On update tous les sprites en utilisant la map comme référence pour les déplacements par l'ai
SpritePool.prototype.push = function SpritePool_push(sprite)
{
	this.internalList.push(sprite);
}