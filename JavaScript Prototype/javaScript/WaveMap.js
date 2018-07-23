//Représente la map du jeu
function WaveMap()
{
	//Fields
	this.width = 16;
	this.height = 16;
	this.cacheResolution = 0.01;
	
	//Parts
	this.colorMap = new ColorMap();
	this.cache = new Array();
	
	//Random map fluctiuation numbers
	this.freq1 = Math.random() * 0.8 + 0.8;
	this.freq2 = Math.random() * 0.8 + 0.8;
	this.freq3 = Math.random() * 0.2 + 0.1;
	this.freq4 = Math.random() * 0.2 + 0.1;
	this.freq5 = Math.random() * 0.01 + 0.01;
	this.freq6 = Math.random() * 0.01 + 0.01;
	this.amp1 = Math.random() * 3;
	this.amp2 = Math.random() * 3;
	this.amp3 = Math.random() * 3;
	this.amp4 = Math.random() * 3;
	this.amp5 = Math.random() * 3;
	this.amp6 = Math.random() * 3;
	this.phase1 = Math.random() * Math.PI * 2 - Math.PI;
	this.phase2 = Math.random() * Math.PI * 2 - Math.PI;
	this.phase3 = Math.random() * Math.PI * 2 - Math.PI;
	this.phase4 = Math.random() * Math.PI * 2 - Math.PI;
	this.phase5 = Math.random() * Math.PI * 2 - Math.PI;
	this.phase6 = Math.random() * Math.PI * 2 - Math.PI;
	
	//Map
	this.data = new Array();
	 this.data[0] = new Array(1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1);
	 this.data[1] = new Array(1,0,0,0,0,0,1,1,0,0,0,0,0,0,0,1);
	 this.data[2] = new Array(1,0,1,1,0,0,1,1,0,0,0,0,0,1,0,1);
	 this.data[3] = new Array(1,0,1,1,0,0,1,1,1,0,0,1,0,1,0,1);
	 this.data[4] = new Array(1,0,1,1,0,0,1,1,1,0,0,1,1,1,0,1);
	 this.data[5] = new Array(1,0,0,1,0,0,1,1,1,0,0,0,1,0,0,1);
	 this.data[6] = new Array(1,0,0,1,0,0,1,1,1,0,0,0,1,0,1,1);
	 this.data[7] = new Array(1,0,0,1,0,0,1,1,1,1,0,0,1,0,1,1);
	 this.data[8] = new Array(1,0,0,1,0,0,1,1,1,1,0,0,1,0,0,1);
	 this.data[9] = new Array(1,0,0,1,0,0,1,1,1,1,0,1,1,0,0,1);
	this.data[10] = new Array(1,0,0,1,0,0,1,1,0,0,0,0,1,0,1,1);
	this.data[11] = new Array(1,0,0,1,0,0,0,1,1,0,0,0,1,0,1,1);
	this.data[12] = new Array(1,0,0,0,0,0,0,1,1,0,0,0,0,0,0,1);
	this.data[13] = new Array(1,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1);
	this.data[14] = new Array(1,0,0,0,0,0,0,1,0,0,0,0,1,0,0,1);
	this.data[15] = new Array(1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1);
}

WaveMap.prototype.getValueAt = function WaveMap_getValueAt(x,y)
{
	var cacheX = x / this.cacheResolution;
	cacheX = Math.floor(cacheX);
	
	var cacheY = y / this.cacheResolution;
	cacheY = Math.floor(cacheY);

	if (this.cache[cacheX] === undefined)
		this.cache[cacheX] = new Array();
	
	if (this.cache[cacheX][cacheY] != undefined)
		return this.cache[cacheX][cacheY];


	var valueStraight = this.getValueAtStraightMode(x,y);
	
	if (valueStraight == 0)
		return 0;
	
	var valueWave = this.getValueAtWaveMode(x,y);
	
	var smallerValue = Math.min(valueStraight, valueWave);
	
	this.cache[cacheX][cacheY] = smallerValue;
	
	return smallerValue;
}

WaveMap.prototype.getValueAtStraightMode = function WaveMap_getValueAtStraightMode(x,y)
{
	x = Math.floor(x);
	y = Math.floor(y);
	
	while (x < 0)
		x += this.width;
	
	while (y < 0)
		y += this.height;
		
	while (x >= this.width)
		x -= this.width;
	
	while (y >= this.height)
		y -= this.height;

	var row = this.data[y];
	return row[x];
}

WaveMap.prototype.getValueAtWaveMode = function WaveMap_getValueAtWaveMode(x,y)
{
	x+= Math.sin(x * this.freq3 + this.phase3) * this.amp3 + Math.sin(Math.sqrt(Math.pow(x,2) + Math.pow(y,2)) * this.freq5 + this.phase5) * this.amp5 + Math.sin(y * this.freq1 + this.phase1) * this.amp1;
	y+= Math.sin(y * this.freq4 + this.phase4) * this.amp4 + Math.sin(Math.sqrt(Math.pow(x,2) + Math.pow(y,2)) * this.freq6 + this.phase6) * this.amp6 - Math.sin(x * this.freq2 + this.phase2) * this.amp2;
	
	//x+= Math.sin(x * this.freq3 + this.phase3) * this.amp3;
	//y+= Math.sin(y * this.freq4 + this.phase4) * this.amp4;
	
	x = Math.floor(x);
	y = Math.floor(y);
	
	while (x < 0)
		x += this.width;
	
	while (y < 0)
		y += this.height;
		
	while (x >= this.width)
		x -= this.width;
	
	while (y >= this.height)
		y -= this.height;

	var row = this.data[y];
	
	return row[x];
}