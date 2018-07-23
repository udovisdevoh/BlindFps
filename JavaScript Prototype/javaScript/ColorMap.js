//Représente une map de couleurs
function ColorMap()
{
	//Constants
	this.cacheResolution = 0.1;
	this.cacheBrightnessResolution = 1;
	
	//Parts
	this.waveBuilder = new WaveBuilder();
	this.waveRedX = this.waveBuilder.buildColorWavePack();
	this.waveGreenX = this.waveBuilder.buildColorWavePack();
	this.waveBlueX = this.waveBuilder.buildColorWavePack();
	this.waveRedY = this.waveBuilder.buildColorWavePack();
	this.waveGreenY = this.waveBuilder.buildColorWavePack();
	this.waveBlueY = this.waveBuilder.buildColorWavePack();
	
	//Parts
	this.cache = new Array();
}

ColorMap.prototype.getColoredBrightness = function ColorMap_getColoredBrightness(x, y, brightness)
{
	var cacheX = x / this.cacheResolution;
	cacheX = Math.floor(cacheX);
	
	var cacheY = y / this.cacheResolution;
	cacheY = Math.floor(cacheY);
	
	var cacheBrightness = brightness;// / this.cacheBrightnessResolution;
	cacheBrightness = Math.floor(cacheBrightness);

	if (this.cache[cacheX] === undefined)
		this.cache[cacheX] = new Array();
		
	if (this.cache[cacheX][cacheY] === undefined)
		this.cache[cacheX][cacheY] = new Array();
	
	if (this.cache[cacheX][cacheY][cacheBrightness] != undefined)
		return this.cache[cacheX][cacheY][cacheBrightness];

	x/=10;
	y/=10;

	var red = this.waveRedX.getValueAt(x) + this.waveRedX.getValueAt(y);
	var green = this.waveGreenX.getValueAt(x) + this.waveGreenY.getValueAt(y);
	var blue = this.waveBlueX.getValueAt(x) + this.waveBlueY.getValueAt(y);
	
	while (red > 1)
		red -= 1;
	while (green > 1)
		green -= 1;
	while (blue > 1)
		blue -= 1;
	while (red < 0)
		red += 1;
	while (green < 0)
		green += 1;
	while (blue < 0)
		blue += 1;
	
	var totalBrightness = red+green+blue;	
	
	red *= brightness*3 / totalBrightness;
	green *= brightness*3 / totalBrightness;
	blue *= brightness*3 / totalBrightness;
	
	red = Math.min(255,red);
	green = Math.min(255,green);
	blue = Math.min(255,blue);
	
	red = Math.max(0,red);
	green = Math.max(0,green);
	blue = Math.max(0,blue);
	
	red = red / 2 + brightness / 2;
	green = green / 2 + brightness / 2;
	blue = blue / 2 + brightness / 2;
	
	red = Math.round(red);
	green = Math.round(green);
	blue = Math.round(blue);
	
	var cacheValue = "rgb("+red+","+green+","+blue+")";
	
	this.cache[cacheX][cacheY][cacheBrightness] = cacheValue;
	
	return cacheValue;
}