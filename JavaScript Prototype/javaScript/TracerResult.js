//Représente le résultat du scan du ray tracer
function TracerResult(count)
{
	//fields
	this.count = count;

	//Listes des positions x des rayons
	this.positionXList = new Array();
	
	//Listes des positions x des rayons
	this.positionYList = new Array();
	
	//Listes des positions x des rayons
	this.positionAngleList = new Array();
}

TracerResult.prototype.setPositionUnit = function TracerResult_setPositionUnit(rayId, x, y, angle)
{
	this.positionXList[rayId] = x;
	this.positionYList[rayId] = y;
	this.positionAngleList[rayId] = angle;
}

TracerResult.prototype.getX = function TracerResult_getX(rayId)
{
	return this.positionXList[rayId];
}

TracerResult.prototype.getY = function TracerResult_getY(rayId)
{
	return this.positionYList[rayId];
}

TracerResult.prototype.getAngle = function TracerResult_getAngle(rayId)
{
	return this.positionAngleList[rayId];
}