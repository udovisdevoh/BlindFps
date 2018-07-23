//Model de jeu
function GameModel(parentElementId)
{
	//Constants
	this.turnSpeed = 10;
	this.refreshTime = 30;
	this.rayTracerPointCount = 100;
	this.fov = 110;
	this.monsterCount = 2;
	this.isColored = false;
	this.isWaveMap = false;
	this.isEnableMonsterMove = true;
	
	//Fields
	this.parentElementId = parentElementId;
	this.timeInterval = 0;
	
	//Parts
	if (this.isWaveMap)
		this.map = new WaveMap();
	else
		this.map = new Map();
	this.player = new Player(5.5, 14.5);
	this.spritePool = new SpritePool(this.monsterCount);
	this.spritePool.push(this.player);
	this.rayTracer = new RayTracer(this.rayTracerPointCount,this.fov);
	//this.viewer = new Viewer2D(this.parentElementId, this.map, this.player, this.rayTracerPointCount, this.spritePool.count());
	this.viewer = new Viewer3D(this.parentElementId, this.map, this.player, this.rayTracerPointCount, this.parentElementId, this.isColored, this.fov);
	this.fightManager = new FightManager();
	
	//Construction
	this.spawner = new Spawner();
	this.spawner.respawnSpritePoolMembers(this.spritePool, this.map);
}

GameModel.prototype.update = function GameModel_update()
{
	//On prend le temp courant en ms
	var msTime = new Date().getTime();
	
	//On crouch
	if (this.player.jumpHeight == 0)
		this.player.isCrouch = isPressCrouch;

	//Deplacements, block
	this.player.isBlock = false;
	if (isPressUp)
	{
		this.player.walk(this.player.walkSpeed,0, this.map, this.player.isCrouch, this.spritePool);
	}
	else if (isPressDown)
	{
		this.player.walk(this.player.walkSpeed * -1,0, this.map, this.player.isCrouch, this.spritePool);
		this.player.isBlock = true;
	}
		
	if (isPressLeft)
		this.player.walk(this.player.walkSpeed, 270,this.map, this.player.isCrouch, this.spritePool);
	else if (isPressRight)
		this.player.walk(this.player.walkSpeed, 90, this.map, this.player.isCrouch, this.spritePool);
	
	//On saute ou on tombe
	if (!this.player.isCrouch && isPressSpace && !wasPressSpace && this.player.jumpHeight == 0)
		this.player.startJump();
	else if (isPressSpace && this.player.jumpSpeed > 0 && this.player.jumpHeight < this.player.maxJumpHeight && this.player.fallSpeed == 0)
		this.player.continueJump();
	else
		this.player.continueFall();
	wasPressSpace = isPressSpace;
	
	//Attaque par click de souris
	if (isMouseLeftDown)
		this.player.attack();
	else
		this.player.currentAttackCycle = 0;
	
	//Deplacement de la souris
	this.player.rotate(this.turnSpeed * mouseDeltaX / 10);
	mouseDeltaX = 0;
	
	
	//Deplacement des monstres
	if (this.isEnableMonsterMove)
		this.spritePool.update(this.map, this.spritePool);
	
	//Gestion des combats
	this.fightManager.updateSpritePool(this.spritePool);
	
	//Gestion des morts
	this.spawner.respawnDeadUnits(this.spritePool, this.map);

	//On affiche la vue du jeu
	this.viewer.view(this.map, this.player, this.rayTracer.trace(this.player, this.map), this.spritePool);
	
	//On prépare le prochain refresh
	this.timeInterval = new Date().getTime() - msTime;
	var gameModel = this;
	setTimeout(function GameModel_update() { gameModel.update(); }, Math.max(this.refreshTime - this.timeInterval,0));
}