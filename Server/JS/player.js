function Player()
{
	this.id = null;
	this.name = null;
	this.room = null;
	this.server = [];
	
	this.addServer = function(_server)
	{
		this.server.push(_server);
	}
}

module.exports.create = function()
{
	return new Player();
}