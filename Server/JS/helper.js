var playerScript = require('./player.js');

var playerList = [];

module.exports.generateID = function(ids, limit)
{
	if(ids == null)
		return 0;
	
	for(var i=0;i<limit;i++)
	{
		if(ids[i] == null || ids[i] == -1)
		{
			return i;
		}
	}
}

module.exports.getPlayerList = function ()
{	
	return playerList;
}

module.exports.getAllPlayersInServer = function (server)
{	
	var array = [];

	for(i=0;i<playerList.length;i++)
	{
		for(j=0;j<playerList[i].server.length;j++)
		{
			if(playerList[i].server[j] == server)
			{
				array.push(playerList[i]);
			}
		}
	}
	
	return array;
}

module.exports.getUserByID = function (id)
{	
	for(i=0;i<playerList.length;i++)
	{
		if(playerList[i].id == id)
		{
			return playerList[i];
		}
	}	
}


module.exports.setPlayerListName = function (id, name)
{	
	for(i=0;i<playerList.length;i++)
	{
		if(playerList[i].id == id)
		{
			return playerList[i].name = name;
		}
	}
}

module.exports.formatString = function (array, c)
{	
	var str = "";
	
	for(var i=0;i<array.length;i++)
	{
		if(array[i] != null)
			str += array[i].name+c;
	}
	
	return str;
}

module.exports.addPlayerList = function (pos, p)
{	
	return playerList[pos] = p;
}

module.exports.removePlayerList = function (id)
{
	for(i=0;i<playerList.length;i++)
	{
		if(playerList[i].id == id)
		{
			return playerList[i] = null;
		}
	}	
}

module.exports.player = function()
{
	return playerScript;
}