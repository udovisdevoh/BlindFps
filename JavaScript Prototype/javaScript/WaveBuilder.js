//Une fabrique de paquet d'ondes
function WaveBuilder()
{
	//Constants
	this.roomWaveCount = 5;
	this.colorWaveCount = 5;
	this.maxRoomWallSegment = 4;
}

WaveBuilder.prototype.buildRoomWavePack = function WaveBuilder_buildRoomWavePack()
{
	var wavePack = new WavePack();
	for (var i = 0; i < this.roomWaveCount; i++)
	{
		var wave = this.buildRoomWave();
		wavePack.add(wave);
	}
	wavePack.normalize();
	return wavePack;
}

WaveBuilder.prototype.buildColorWavePack = function WaveBuilder_buildRoomWavePack()
{
	var wavePack = new WavePack();
	for (var i = 0; i < this.colorWaveCount; i++)
	{
		var wave = this.buildRoomWave();
		wavePack.add(wave);
	}
	wavePack.normalize();
	return wavePack;
}

WaveBuilder.prototype.buildRoomWave = function WaveBuilder_buildRoomWave()
{
	var wave = new Wave();
	wave.waveFormType = Math.floor(Math.random() * 4);
	wave.amplitude = Math.random();
	wave.phase = (Math.random() * 2) - 1;
	wave.length = (Math.floor(Math.random() * this.maxRoomWallSegment) + 1);
	if (Math.random() >= 0.5)
		wave.isInvertedSaw = true;
	return wave;
}

WaveBuilder.prototype.buildPovWave = function WaveBuilder_buildPovWave()
{
	var wave = new Wave();
	wave.waveFormType = 0;
	wave.amplitude = 1;
	wave.phase = 0.587;
	wave.length = 1;
	wave.isInvertedSaw = false;
	return wave;
}

WaveBuilder.prototype.buildPositionWave = function WaveBuilder_buildPositionWave()
{
	var wave = new Wave();
	wave.waveFormType = 0;
	wave.amplitude = 0.5;
	wave.phase = 0;
	wave.length = 3;
	wave.isInvertedSaw = false;
	return wave;
}