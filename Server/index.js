var io = require('socket.io')({
	transports: ['websocket'],
});

//include ('./JS/player.js');

io.attach(4567);

function Player(_id, _x, _y, _name, _socket)
{
	this.id = _id;
	this.x = _x;
	this.y = _y;
	this.name = _name;
	this.room = null;
	this.socket = _socket;
}

var playerList = [];

console.log("Vai serginhooo")

io.on('connection', function(socket){
    var player = new Player(socket.id,0, 0, "", socket);
	
	playerList.push(player);
	
	socket.on('updatePos', function(data){
		playerList[_id].x = data.posX;
		playerList[_id].y = data.posY;
		io.emit('updatePos', {id: data.id, x: data.posX, y: data.posY});
	});
	
	socket.on('login', function(data, fn){
		console.log("Tentou logar "+data.login+" "+data.pass);
		if (data.login == "user")
		{
			if (data.pass == "123")
			{
				console.log("logou");
				fn({message: "true"});
			}
			else
			{
				console.log("senha errada");
				socket.emit('login', {message: 'false'});
			}
		}
		else
		{
			console.log("login errado");
			socket.emit('login', {message: 'false'});
		}
	});
})
