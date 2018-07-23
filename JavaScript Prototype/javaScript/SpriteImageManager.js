function SpriteImageManager()
{
	//Parts
	this.stickManWalk002_001 = new SpriteImageInfo("./images/StickmanWalk-002-001LowRes.gif", 148, 569);
	this.stickManWalk002_002 = new SpriteImageInfo("./images/StickmanWalk-002-002LowRes.gif", 154, 569);
}

SpriteImageManager.prototype.getSpriteImageInfo = function SpriteImageManager_getSpriteImageInfo(sprite)
{
	if (sprite instanceof MonsterStickMan)
	{
		if (sprite.walkCycle < 5)
		{
			return this.stickManWalk002_002;
		}
		else
		{
			return this.stickManWalk002_001;
			alert("mofo");
		}
	}
	
	return null;
}