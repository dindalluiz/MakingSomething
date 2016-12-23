function Player()
{
	this.id = null;
	this.name = null;
	this.room = null;
	this.server = [];
	this.customID = null;
	this.arrayIDServer = [];
	
	this.addServer = function(_server)
	{
		this.server.push(_server);
	}

	this.addIDServer = function(_id, nameServer)
	{
		this.arrayIDServer.push({server: nameServer, id: _id});
	}
}

module.exports.create = function()
{
	return new Player();
}