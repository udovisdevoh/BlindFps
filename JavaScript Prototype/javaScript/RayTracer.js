function RayTracer(howManyColumn, fov)
{
	//Fields
	this.fov = fov;
	this.howManyColumn = howManyColumn;
	this.rayDistanceResolution = 0.01;
	
	//Parts
	this.tracerResult = new TracerResult(howManyColumn);
}

RayTracer.prototype.trace = function RayTracer_trace(player, map)
{
	var startAngle = player.angle - this.fov / 2;
	var endAngle = player.angle + this.fov / 2;
	
	var angleResolution = this.fov / this.howManyColumn;
	
	
	startAngle = fixAngle(startAngle);
	endAngle = fixAngle(endAngle);
	

	var pointCounter = 0;
	for (var angle = startAngle; pointCounter < this.howManyColumn ; angle += angleResolution)
	{
		angle = fixAngle(angle);
		//On met le résultat de la trace dans "tracerResult")
		this.tracePositionUnit(pointCounter, angle, player.x, player.y, map, this.rayDistanceResolution, this.tracerResult);		
		pointCounter++;
	}
	
	return this.tracerResult;
}

RayTracer.prototype.tracePositionUnit = function RayTracer_tracePositionUnit(pointCounter, angle, x, y, map, distanceResolution, tracerResult)
{
	var xMove = cosDegree(angle) * distanceResolution;
	var yMove = sinDegree(angle) * distanceResolution;
		
	while (true)
	{
		x += xMove;
		y += yMove;
		
		xMove*=1.01;
		yMove*=1.01;
		
		if (x < 0 || y < 0 || x > map.width || y > map.height)
			break;
		
		if (map.getValueAt(x, y) == 1)
			break;
	}
	
	tracerResult.setPositionUnit(pointCounter, x, y, angle);
}