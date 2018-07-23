//Monstre simple
function MonsterStickMan(x,y)
{
	//Constants
	this.walkSpeed = 0.25;
	this.painDamageSpeed = 0.05;
	this.jumpSpeedMultipler = 1.01;
	this.maxJumpHeight = 100;
	this.fallSpeedAcceleration = 0.06;
	this.jumpSpeedAcceleration = 0.01;
	this.startingJumpSpeed = 0.15;
	this.maxHealth = 100;
	this.endOfAttackCycle = 3.75;
	this.attackRange = 0.6;//this includes diameter
	this.crouchDistaceMultiplier = 0.5;
	this.jumpDistaceMultiplier = 1.5;
	this.diameter = 0.4;
	this.painCycleSpeed = 1;

	//Fields
	this.x = x;
	this.y = y;
	this.angle = 180;
	this.jumpHeight = 0;
	this.jumpSpeed = 0;
	this.fallSpeed = 0;
	this.currentAttackCycle = 0; //Dans les nombres négatif lorsque subit attaque
	this.damageAngle = 0;
	this.currentPainCycle = 0;
	this.walkCycle = 0;
	this.isCrouch = false;
	this.isBlock = false;
	this.health = this.maxHealth;
	this.fragCount = 0;
	this.lastUnitAttackedThis = null;
	
	//Parts
	this.physics = new Physics();
	this.ai = new Ai();
	this.behaviorManager = new BehaviorManager();
}

MonsterStickMan.prototype.update = function MonsterStickMan_update(map, spritePool)
{
	//Ask the AI to move the monster 
	this.ai.tryControlMonster(this, map, spritePool);
	
	if (this.currentPainCycle < 0)
	{
		this.currentPainCycle += this.painCycleSpeed;
		this.walk(this.painDamageSpeed * this.painCycleSpeed, (this.angle * -1) + this.damageAngle, map, this.isCrouch, spritePool)
		this.currentPainCycle = Math.min(this.currentPainCycle,0);
		this.health -= this.painCycleSpeed;
	}
}

MonsterStickMan.prototype.tryJump = function MonsterStickMan_tryJump()
{
	if (!this.isCrouch && this.jumpHeight == 0)
		this.startJump();
	else if (this.jumpSpeed > 0 && this.jumpHeight < this.maxJumpHeight && this.fallSpeed == 0)
		this.continueJump();
	else
		this.continueFall();
}

MonsterStickMan.prototype.startJump = function MonsterStickMan_startJump()
{
	this.fallSpeed = 0;
	this.jumpSpeed = this.startingJumpSpeed;
	this.continueJump();
}

MonsterStickMan.prototype.continueJump = function MonsterStickMan_continueJump()
{
	this.jumpHeight += this.jumpSpeed;
	this.jumpSpeed -= this.jumpSpeedAcceleration;
	this.jumpSpeed = Math.max(0, this.jumpSpeed);
	this.jumpHeight = Math.max(0, this.jumpHeight);//To prevent falling in the ground
}

MonsterStickMan.prototype.continueFall = function MonsterStickMan_continueFall()
{
	if (this.jumpHeight > 0)
	{
		this.jumpHeight -= this.fallSpeed;
		this.jumpHeight = Math.max(0,this.jumpHeight);
		this.fallSpeed += this.fallSpeedAcceleration;
	}
}

MonsterStickMan.prototype.walk = function MonsterStickMan_walk(distance, rotationAngle, map, isCrouch, spritePool)
{
	if (isCrouch)
		distance *= this.crouchDistaceMultiplier;
	else if (this.jumpHeight > 0)
		distance *= this.jumpDistaceMultiplier;

	//rotationAngle is for straffing, not for walking forward
	var xMove = cosDegree(this.angle + rotationAngle) * distance;
	var yMove = sinDegree(this.angle + rotationAngle) * distance;
	
	var radius = this.diameter / 2;
	
	var isValidXMove = this.physics.testMapCollision(this.x + xMove, this.y, radius, map);
	isValidXMove &= this.physics.testSpriteCollision(this.x + xMove, this.y, radius, this, spritePool);
	
	var isValidYMove = this.physics.testMapCollision(this.x, this.y + yMove, radius, map);
	isValidYMove &= this.physics.testSpriteCollision(this.x, this.y + yMove, radius, this, spritePool);
	
	if (isValidXMove && isValidYMove)
	{
		this.x += xMove;
		this.y += yMove;
	}
	else if (isValidYMove)
	{
		this.y += yMove;
	}
	else if (isValidXMove)
	{
		this.x += xMove;
	}
}

MonsterStickMan.prototype.attack = function MonsterStickMan_tryAttack()
{
	this.currentAttackCycle++;
	if (this.currentAttackCycle > this.endOfAttackCycle)
		this.currentAttackCycle = 0;
}