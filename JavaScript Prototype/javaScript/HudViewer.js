function HudViewer(height, parentDomElementId)
{
	//Constants
	this.meleeImpactCycleTime = 1.5;

	//Fields
	this.height = height;
	this.parentDomElementId = parentDomElementId;
	this.jumpHeightAtCycleBegin = 0;
	
	//Construction
	this.createDomElementList(parentDomElementId);
}

HudViewer.prototype.createDomElementList = function HudViewer_createDomElementList(parentDomElementId)
{
	var parentDomElement = document.getElementById(parentDomElementId);
	
	var healthInfoLabel = document.createElement('div');
	healthInfoLabel.className = "HudLabel";
	healthInfoLabel.setAttribute("id", "healthInfoLabel");
	healthInfoLabel.style.top = this.height + "px";
	healthInfoLabel.style.right = "32px";	
	healthInfoLabel.innerHTML="HEALTH";
	parentDomElement.appendChild(healthInfoLabel);
	
	var healthInfoLabel = document.createElement('div');
	healthInfoLabel.className = "HudLabel";
	healthInfoLabel.setAttribute("id", "fragsLabel");
	healthInfoLabel.style.top = this.height + "px";
	healthInfoLabel.style.right = "144px";	
	healthInfoLabel.innerHTML="FRAGS";
	parentDomElement.appendChild(healthInfoLabel);
	
	var healthInfo = document.createElement('div');
	healthInfo.className = "HudStats";
	healthInfo.setAttribute("id", "healthInfo");
	healthInfo.style.top = (this.height + 10) + "px";
	healthInfo.style.right = "32px";	
	parentDomElement.appendChild(healthInfo);
	
	var fragsInfo = document.createElement('div');
	fragsInfo.className = "HudStats";
	fragsInfo.setAttribute("id", "fragsInfo");
	fragsInfo.style.top = (this.height + 10) + "px";
	fragsInfo.style.right = "144px";	
	parentDomElement.appendChild(fragsInfo);
	
	var punch001 = document.createElement('div');
	punch001.className = "HudWeapon";
	punch001.setAttribute("id", "punch001");
	punch001.style.left = "10%";
	punch001.style.top = this.height - 282 + "px";
	parentDomElement.appendChild(punch001);
	
	var punch002 = document.createElement('div');
	punch002.className = "HudWeapon";
	punch002.setAttribute("id", "punch002");
	punch002.style.left = "16%";
	punch002.style.top = this.height - 383 + "px";
	parentDomElement.appendChild(punch002);
	
	var kick001 = document.createElement('div');
	kick001.className = "HudWeapon";
	kick001.setAttribute("id", "kick001");
	kick001.style.left = "33%";
	kick001.style.top = this.height - 214 + "px";
	parentDomElement.appendChild(kick001);
	
	
	var kick002 = document.createElement('div');
	kick002.className = "HudWeapon";
	kick002.setAttribute("id", "kick002");
	kick002.style.left = "33%";
	kick002.style.top = this.height - 259 + "px";
	parentDomElement.appendChild(kick002);
	
	var kick003 = document.createElement('div');
	kick003.className = "HudWeapon";
	kick003.setAttribute("id", "kick003");
	kick003.style.left = "33%";
	kick003.style.top = this.height - 283 + "px";
	parentDomElement.appendChild(kick003);
	
	var block001 = document.createElement('div');
	block001.className = "HudWeapon";
	block001.setAttribute("id", "block001");
	block001.style.left = "5%";
	block001.style.top = this.height - 438 + "px";
	parentDomElement.appendChild(block001);
}

HudViewer.prototype.hideAll = function HudViewer_hideAll()
{
	document.getElementById("punch001").style.visibility="hidden";
	document.getElementById("punch002").style.visibility="hidden";
	document.getElementById("kick001").style.visibility="hidden";
	document.getElementById("kick002").style.visibility="hidden";
	document.getElementById("kick003").style.visibility="hidden";
	document.getElementById("block001").style.visibility="hidden";
}

HudViewer.prototype.view = function HudViewer_view(attackCycle, jumpHeight, isCrouch, isBlock, health, fragCount)
{
	document.getElementById("healthInfo").innerHTML = Math.floor(health);
	document.getElementById("fragsInfo").innerHTML = fragCount;

	if (isCrouch)
		jumpHeight = -0.75;

	this.hideAll();
	
	if (attackCycle == 0)
		this.jumpHeightAtCycleBegin = jumpHeight;
			
	if (attackCycle >= this.meleeImpactCycleTime * 2.5)
	{
		if (this.jumpHeightAtCycleBegin == 0)
		{
			if (isBlock)
				this.showFrame("block001");
			else
				this.showFrame("punch001");
		}
		else
		{
			if (isBlock)
				this.showFrame("block001");
			this.showFrame("kick001");
		}
	}
	else if (attackCycle >= this.meleeImpactCycleTime * 2)
	{
		if (this.jumpHeightAtCycleBegin == 0)
		{
			this.showFrame("punch002");
		}
		else
		{
			this.showFrame("kick001");
		}
	}
	else if (attackCycle >= this.meleeImpactCycleTime * 1.5)
	{
		if (this.jumpHeightAtCycleBegin == 0)
		{
			this.showFrame("punch002");
		}
		else
		{
			this.showFrame("kick002");
		}
	}
	else if (attackCycle >= this.meleeImpactCycleTime)
	{
		if (this.jumpHeightAtCycleBegin == 0)
		{
			this.showFrame("punch002");
		}
		else
		{
			this.showFrame("kick003");
		}
	}
	else if (attackCycle >= this.meleeImpactCycleTime / 2)
	{
		if (this.jumpHeightAtCycleBegin == 0)
		{
			this.showFrame("punch002");
		}
		else
		{
			this.showFrame("kick002");
		}
	}
	else
	{
		if (this.jumpHeightAtCycleBegin == 0)
		{
			if (isBlock)
				this.showFrame("block001");
			else
				this.showFrame("punch001");
		}
		else
		{
			if (isBlock)
				this.showFrame("block001");
			this.showFrame("kick001");
		}
	}
}

HudViewer.prototype.showFrame = function HudViewer_showFrame(frameName)
{
	document.getElementById(frameName).style.visibility="visible";
}