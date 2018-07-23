//Représente la map du jeu
function Map()
{
	//Fields
	this.width = 16;
	this.height = 16;
	
	//Parts
	this.colorMap = new ColorMap();
	
	//Map
	this.data = new Array();
	 this.data[0] = new Array(1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1);
	 this.data[1] = new Array(1,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1);
	 this.data[2] = new Array(1,0,1,0,0,0,0,1,0,0,0,0,0,1,0,1);
	 this.data[3] = new Array(1,0,1,0,0,0,0,1,0,0,0,0,0,1,0,1);
	 this.data[4] = new Array(1,0,1,1,0,0,0,1,0,0,0,0,1,1,0,1);
	 this.data[5] = new Array(1,0,0,1,0,0,0,1,0,0,0,0,1,0,0,1);
	 this.data[6] = new Array(1,0,0,1,0,0,0,1,0,0,0,0,1,0,1,1);
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

Map.prototype.getValueAt = function Map_getValueAt(x,y)
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