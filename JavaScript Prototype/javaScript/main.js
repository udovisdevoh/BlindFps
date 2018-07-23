var IE = document.all?true:false;
if (!IE)
	document.captureEvents(Event.MOUSEMOVE)
document.onmousemove = getMouseXY;

var isPressLeft = false;
var isPressRight = false;
var isPressUp = false;
var isPressDown = false;
var isPressSpace = false;
var isPressCrouch = false;
var wasPressSpace = false;
var isMouseLeftDown = false;
var mouseX = 0;
var mouseY = 0;
var oldMouseX = 0;
var oldMouseY = 0;
var mouseDeltaX = 0;
var mouseDeltaY = 0;

function main()
{
	document.onkeydown = keyDownHandler;
	document.onkeyup = keyUpHandler;
	document.onmousedown = mouseDownHandler;
	document.onmouseup = mouseUpHandler;
	var gameModel = new GameModel("mainScreen");
	gameModel.update();
}

function getKeyCode(e)
{
	if (navigator.appName == "Microsoft Internet Explorer")
		return event.keyCode; 
	return e.which;
}

function mouseDownHandler(e)
{
	if (IE)
	{
		if (event.button==1)
		{
			isMouseLeftDown = true;
		}
		else if (event.button==2)
		{
			isMouseRightDown = true;
		}
	}
	else
	{
		if (e.which == 1)
		{
			isMouseLeftDown = true;
		}
		else if (e.which == 3)
		{
			isMouseRightDown = true;
		}
	}
}

function mouseUpHandler(e)
{
	if (IE)
	{
		if (event.button==1)
		{
			isMouseLeftDown = false;
		}
		else if (event.button==2)
		{
			isMouseRightDown = false;
		}
	}
	else
	{
		if (e.which == 1)
		{
			isMouseLeftDown = false;
		}
		else if (e.which == 3)
		{
			isMouseRightDown = false;
		}
	}
}

function keyDownHandler(e)
{
	var unicode = getKeyCode(e);
	var key = String.fromCharCode(unicode);
		
	if (unicode == 37 || unicode == 65)
	{
		isPressLeft = true;
		isPressRight = false;
	}
	else if (unicode == 39 || unicode == 68)
	{
		isPressRight = true;
		isPressLeft = false;
	}
	else if (unicode == 38 || unicode == 87)
	{
		isPressUp = true;
		isPressDown = false;
	}
	else if (unicode == 40 || unicode == 83)
	{
		isPressDown = true;
		isPressUp = false;
	}
	else if (unicode == 32)
		isPressSpace = true;
	else if (unicode == 67 || unicode == 16)
		isPressCrouch = true;
}

function keyUpHandler(e)
{
	var unicode = getKeyCode(e);
	var key = String.fromCharCode(unicode);
		
	if (unicode == 37 || unicode == 65)
		isPressLeft = false;
	else if (unicode == 39 || unicode == 68)
		isPressRight = false;
	else if (unicode == 38 || unicode == 87)
		isPressUp = false;
	else if (unicode == 40 || unicode == 83)
		isPressDown = false;
	else if (unicode == 32)
		isPressSpace = false;
	else if (unicode == 67 || unicode == 16)
		isPressCrouch = false;
}

function getMouseXY(e)
{
	oldMouseX = mouseX;
	oldMouseY = mouseY;
	
	if (IE)
	{
		// grab the x-y pos.s if browser is IE
		mouseX = event.clientX + document.body.scrollLeft
		mouseY = event.clientY + document.body.scrollTop
	}
	else
	{
		// grab the x-y pos.s if browser is NS
		mouseX = e.pageX
		mouseY = e.pageY
	}
	
	mouseDeltaX = mouseX - oldMouseX;
	mouseDeltaY = mouseY- oldMouseY;
}

function sinDegree(x)
{
	return Math.sin(x * Math.PI / 180);
}

function cosDegree(x)
{
	return Math.cos(x * Math.PI / 180);
}

function tanDegree(x)
{
	return Math.tan(x * Math.PI / 180);
}

function aSinDegree(x)
{
	return Math.asin(x) / Math.PI * 180;
}

function aCosDegree(x)
{
	return Math.acos(x) / Math.PI * 180;
}

function aTanDegree2(x, y)
{
	return Math.atan2(x, y) / Math.PI * 180;
}

function aTanDegreeWeird(x)
{
	return Math.atan(x) / Math.PI * 180;
}

function fixAngle(angle)
{
	while (angle > 360)
		angle -= 360;
	while (angle < 0)
		angle += 360;
		
	return angle;
}