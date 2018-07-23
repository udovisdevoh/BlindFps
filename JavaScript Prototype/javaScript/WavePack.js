//Un paquet d'ondes
function WavePack()
{
	//Constants
	this.normalizationResolution = 0.001;
	
	//Parts
	this.internalList = new Array();
	
	//Fields
	this.normalizationMultiplicator = 1;
}

//Get Y value at X point
WavePack.prototype.getValueAt = function WavePack_getValueAt(x)
{
	var value = 0;
	for (var i in this.internalList)
		value += this.internalList[i].getValueAt(x);
	return value * this.normalizationMultiplicator;
}

//Add a wave
WavePack.prototype.add = function WavePack_add(wave)
{
	this.internalList.push(wave);
}

//Normalize a wavePack
WavePack.prototype.normalize = function WavePack_normalize()
{
	var currentMaximum =- 1;
	var currentValue;
	for (var i = -1; i < 1; i+= this.normalizationResolution)
	{
		currentValue = this.getValueAt(i);
		if (currentMaximum == -1 || Math.abs(currentValue) > currentMaximum)
			currentMaximum = Math.abs(currentValue);
	}
	
	this.normalizationMultiplicator = 1 / currentMaximum;
}