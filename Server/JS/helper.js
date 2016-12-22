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

module.exports.setPlayerListName = function (pos, name)
{	
	return playerList[pos].name = name;
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

module.exports.removePlayerList = function (pos, p)
{	
	return playerList[pos] = null;
}

module.exports.player = function()
{
	return playerScript;
}