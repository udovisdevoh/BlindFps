function BehaviorManager()
{
	//Constants
	this.amplitude = 30;
	this.phase = 100;
	
	//Fields
	this.currentCycleTime = 0;
	this.currentBehavior = 0;
	
	//Construction
	this.maxCycleTime = 0;
}

BehaviorManager.prototype.getCurrentBehavior = function BehaviorManager_getCurrentBehavior()
{
	if (this.currentCycleTime == 0)
	{
		this.currentBehavior = Math.floor(Math.random() * 3);
	}
	
	this.currentCycleTime++;
	
	if (this.currentCycleTime > this.maxCycleTime)
	{
		this.currentCycleTime = 0;
		this.maxCycleTime = Math.floor(Math.random() * this.amplitude + this.phase);
	}
	
	return this.currentBehavior;
}