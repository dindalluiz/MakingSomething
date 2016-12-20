function Player(_id, _x, _y, _name, _socket)
{
	this.id = _id;
	this.x = _x;
	this.y = _y;
	this.name = _name;
	this.room = null;
	this.socket = _socket;
}