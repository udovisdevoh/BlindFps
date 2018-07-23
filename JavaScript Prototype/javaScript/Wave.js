//Une onde simple (d'une forme simple)
function Wave()
{
	//Contants
	this.functionSine = 0;
	this.functionSquare = 1;
	this.functionSaw = 2;
	this.functionTriangle = 3;

	//Fields
	this.waveFormType = this.functionSine;
	this.amplitude = 1;
	this.phase = 0;
	this.length = 1;
	this.isInvertedSaw = false;
}

//Get Y value at X point
Wave.prototype.getValueAt = function Wave_getValueAt(x)
{
	if (this.waveFormType == this.functionSine)
	{
		return Math.sin((x + this.phase) * this.length) * this.amplitude;
	}
	else if (this.waveFormType == this.functionSquare)
	{
		var value = Math.sin((x + this.phase) * this.length) * this.amplitude;
				
		if (value <= 0)
			value = -1;
		else
			value = 1;
			
		return value;
	}
	else if (this.waveFormType == this.functionSaw)
	{
		var length = this.length / 4;
		var value = ((x + this.phase) * length) - Math.floor((x + this.phase) * length);
				
		value -=1;
		value *=2;
		value +=1;
		
		if (this.isInvertedSaw)
			value *= -1;
	
		return value;
	}
	else if (this.waveFormType == this.functionTriangle)
	{
		var value = Math.sin((x + this.phase) * this.length) * this.amplitude;
		
		value = Math.asin(value) / Math.PI *2;
		
		return value;
	}
}