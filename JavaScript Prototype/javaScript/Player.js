//Joueur
function Player(x,y)
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
	this.currentAttackCycle = 0;
	this.currentPainCycle = 0; //Dans les nombres négatif lorsque subit attaque
	this.walkCycle = 0;
	this.damageAngle = 0;
	this.isCrouch = false;
	this.isBlock = false;
	this.health = this.maxHealth;
	this.fragCount = 0;
	this.lastUnitAttackedThis = null;
	
	//Parts
	this.physics = new Physics();
}

Player.prototype.update = function Player_update(map, spritePool)
{
	if (this.currentPainCycle < 0)
	{
		this.currentPainCycle += this.painCycleSpeed;
		this.walk(this.painDamageSpeed * this.painCycleSpeed, (this.angle * -1) + this.damageAngle, map, this.isCrouch, spritePool)
		this.currentPainCycle = Math.min(this.currentPainCycle,0);
		this.health -= this.painCycleSpeed;
	}
}

Player.prototype.walk = function Player_walk(distance, rotationAngle, map, isCrouch, spritePool)
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

Player.prototype.rotate = function Player_rotate(angleDifference)
{
	this.angle += angleDifference;
	this.angle = fixAngle(this.angle);
}

Player.prototype.startJump = function Player_startJump()
{
	this.fallSpeed = 0;
	this.jumpSpeed = this.startingJumpSpeed;
	this.continueJump();
}

Player.prototype.continueJump = function Player_continueJump()
{
	this.jumpHeight += this.jumpSpeed;
	this.jumpSpeed -= this.jumpSpeedAcceleration;
	this.jumpSpeed = Math.max(0, this.jumpSpeed);
	this.jumpHeight = Math.max(0, this.jumpHeight);//To prevent falling in the ground
}

Player.prototype.continueFall = function Player_continueFall()
{
	if (this.jumpHeight > 0)
	{
		this.jumpHeight -= this.fallSpeed;
		this.jumpHeight = Math.max(0,this.jumpHeight);
		this.fallSpeed += this.fallSpeedAcceleration;
	}
}

Player.prototype.attack = function Player_attack()
{
	this.currentAttackCycle++;
	this.currentAttackCycle = Math.min(this.currentAttackCycle, this.endOfAttackCycle);
}